import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../_services/task.service';
import { PaginationDto } from '../../../models/pagination/pagination-dto';
import { PaginationResult } from '../../../models/pagination/pagination-result';
import { GetTaskDto } from '../../../models/task/get-task-dto';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { PageEvent } from '@angular/material/paginator';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatPaginatorModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  paginationDto: PaginationDto = new PaginationDto();
  paginationResult: PaginationResult<GetTaskDto> = new PaginationResult();

  constructor(
    private taskService: TaskService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getTasks();
  }

  changePage(event: PageEvent) {
    this.paginationDto.pageNumber = event.pageIndex + 1;
    this.paginationDto.pageSize = event.pageSize;

    this.taskService.get(this.paginationDto).subscribe({
      next: (response) => {
        this.paginationResult.results = response.results;
        this.paginationResult.totalCount = response.totalCount;
      },
    });
  }

  getTasks() {
    this.taskService.get(this.paginationDto).subscribe({
      next: (response) => {
        this.paginationResult = response;
      },
      error: () => this.toastr.error("Unexpected server error.")
    });
  }

  changeStatus(task: GetTaskDto) {
    let status: string = '';

    if (task.status == 'Pending') {
      status = 'Completed';
    }

    if (task.status == 'Completed') {
      status = 'Pending';
    }

    this.taskService.put(task.id, status).subscribe({
      next: () => this.getTasks(),
      error: () => this.toastr.error("Unexpected server error."),
    });
  }

  removeTask(id: number) {
    this.taskService.remove(id).subscribe({
      next: () => {
        this.getTasks();
        this.toastr.success('Task removed successfully.');
      },
      error: () => this.toastr.error("Unexpected server error."),
    });
  }
}
