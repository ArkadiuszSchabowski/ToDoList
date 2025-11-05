import { Routes } from '@angular/router';
import { HomeComponent } from './components/public/home/home.component';
import { TaskFormComponent } from './components/public/task-form/task-form.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'task-form', component: TaskFormComponent },
  { path: '**', component: HomeComponent },
];
