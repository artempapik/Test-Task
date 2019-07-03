import { ShareDataService } from '../services/share-data.service';
import { TaskDataService } from '../services/task-data.service';
import { Component, OnInit } from '@angular/core';
import { Task } from '../services/task';

@Component({
  selector: 'edit-task',
  templateUrl: './edit-task.component.html'
})

export class EditTaskComponent implements OnInit {
  task: Task = new Task();

  constructor(
    private taskDataService: TaskDataService,
    private shareDataService: ShareDataService
  ) { }

  ngOnInit() {
    this.task.id = this.shareDataService.taskId;
  }

  editTask() {
    this.taskDataService
      .editTask(this.task)
      .subscribe();
  }
}
