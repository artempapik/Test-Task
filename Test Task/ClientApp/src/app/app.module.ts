//layout
//dates

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ClientDataService } from './services/client-data.service';
import { TaskDataService } from './services/task-data.service';
import { EditTaskComponent } from './edit-task/edit-task.component';
import { ShareDataService } from './services/share-data.service';

@NgModule({
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent },
      { path: 'home', component: HomeComponent },
      { path: 'home/edit-task', component: EditTaskComponent }
    ])
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    EditTaskComponent
  ],
  providers: [
    ClientDataService,
    TaskDataService,
    ShareDataService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
