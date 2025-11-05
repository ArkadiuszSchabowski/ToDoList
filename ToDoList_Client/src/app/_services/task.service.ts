import { Injectable } from '@angular/core';
import { PaginationDto } from '../models/pagination/pagination-dto';
import { PaginationResult } from '../models/pagination/pagination-result';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { GetTaskDto } from '../models/task/get-task-dto';
import { environment } from '../../environments/environment';
import { AddTaskDto } from '../models/task/add-task-dto';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  get(dto: PaginationDto): Observable<PaginationResult<GetTaskDto>> {
    let params = new HttpParams()
      .set('PageNumber', dto.pageNumber.toString())
      .set('PageSize', dto.pageSize.toString());
    return this.http.get<PaginationResult<GetTaskDto>>(this.apiUrl + 'task', {
      params,
    });
  }

  post(dto: AddTaskDto) {
        return this.http.post<AddTaskDto>(this.apiUrl + 'task', dto)
  }

  put(id: number, status: string) {
    return this.http.put(this.apiUrl + `task/${id}`, { status });
  }

  remove(id: number) {
    return this.http.delete(this.apiUrl + `task/${id}`);
  }
}
