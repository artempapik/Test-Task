import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from './task';

@Injectable()
export class TaskDataService {
  private url: string = "/api/tasks";

  constructor(private http: HttpClient) { }

  getClientTasks(clientId: number) {
    return this.http.get(`${this.url}/${clientId}`);
  }

  createTask(task: Task) {
    return this.http.post(this.url, task);
  }

  editTask(task: Task) {
    return this.http.put(this.url, task);
  }

  deleteTask(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
