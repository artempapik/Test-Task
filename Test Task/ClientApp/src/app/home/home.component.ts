import { ClientDataService } from '../services/client-data.service';
import { ShareDataService } from '../services/share-data.service';
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
  clientId: number = 1;
  isAddingTask: boolean = false;

  constructor(
    private clientDataService: ClientDataService,
    private taskDataService: TaskDataService,
    private shareDataService: ShareDataService
  ) { }

  ngOnInit() {
    this.clientDataService
      .getClients()
      .subscribe((data: Client[]) => {
        this.clients = data;
        this.clients.sort((a, b) => a.firstName > b.firstName ? 1 : -1);
      });
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
      .subscribe(_ => { }, _ => { },
        () => {
          this.isAddingTask = false;
          this.taskDataService
            .getClientTasks(this.clientId)
            .subscribe((data: Task[]) => this.tasks = data);
        });
  }

  editTask(id: number) {
    this.shareDataService.taskId = id;
  }

  deleteTask(id: number) {
    this.taskDataService
      .deleteTask(id)
      .subscribe(_ => { }, _ => { },
        () => this.taskDataService
          .getClientTasks(this.clientId)
          .subscribe((data: Task[]) => this.tasks = data))
  }

  userFilterChange(value: string) {
    if (value === 'Name') {
      this.clients.sort((a, b) => a.firstName > b.firstName ? 1 : -1);
    } else if (value === 'City') {
      this.clients.sort((a, b) => a.address > b.address ? 1 : -1);
    }
  }
}
