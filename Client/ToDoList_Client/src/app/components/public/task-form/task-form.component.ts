import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
  FormGroupDirective,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../../_services/task.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
  ],
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.scss'],
})
export class TaskFormComponent implements OnInit {
  @ViewChild(FormGroupDirective) formGroupDirective!: FormGroupDirective;

  taskForm!: FormGroup;

  statuses = [
    { value: 'Pending', viewValue: 'Pending' },
    { value: 'Completed', viewValue: 'Completed' },
  ];

  constructor(private fb: FormBuilder, private taskService: TaskService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.taskForm = this.fb.group({
      title: [
        null,
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(50),
        ],
      ],
      description: [
        null,
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(200),
        ],
      ],
      status: [null, Validators.required],
    });
  }

  addTask(): void {
    if (this.taskForm.invalid) {
      this.taskForm.markAllAsTouched();
      return;
    }

    const taskData = this.taskForm.value;

    this.taskService.post(taskData).subscribe({
      next: () => {
        this.formGroupDirective.resetForm();

        Object.values(this.taskForm.controls).forEach((control) => {
          control.setErrors(null);
          control.markAsPristine();
          control.markAsUntouched();
          control.updateValueAndValidity({ onlySelf: true, emitEvent: false });
        });

        this.toastr.success("Task added successfully.")
      },
      error: (error) => {
        if(error.status === 409){
          this.toastr.error(error.error);
        } else {
          this.toastr.error("Unexpected server error.")
        }
      },
    });
  }
}
