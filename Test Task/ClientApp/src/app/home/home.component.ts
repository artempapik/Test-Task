import { ClientDataService } from '../services/client-data.service';
import { TaskDataService } from '../services/task-data.service';
import { Client } from '../services/client';
import { Component } from '@angular/core';
import { Task } from '../services/task';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  clients: Client[];
  tasks: Task[];
  task: Task = new Task();
  client: Client = new Client();
  clientId: number;
  isAddingTask: boolean = false;

  constructor(
    private clientDataService: ClientDataService,
    private taskDataService: TaskDataService
  ) { }

  ngOnInit() {
    this.clientDataService
      .getClients()
      .subscribe((data: Client[]) => this.clients = data);
  }

  showTaskAdding() {
    this.isAddingTask = !this.isAddingTask;
  }

  viewClientTasks(clientId: number) {
    this.clientId = clientId;

    this.taskDataService
      .getClientTasks(clientId)
      .subscribe((data: Task[]) => this.tasks = data);
  }

  addTask() {
    this.task.clientId = this.clientId;

    this.taskDataService
      .createTask(this.task)
      .subscribe();
  }

  editTask(id: number) {

  }

  deleteTask(id: number) {
    this.taskDataService
      .deleteTask(id)
      .subscribe(_ => { }, _ => { },
        () => this.taskDataService
          .getClientTasks(this.clientId)
          .subscribe((data: Task[]) => this.tasks = data))
  }
}
