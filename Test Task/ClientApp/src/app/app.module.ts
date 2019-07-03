import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ClientDataService } from './services/client-data.service';
import { TaskDataService } from './services/task-data.service';

@NgModule({
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent },
      { path: 'home', component: HomeComponent }
    ])
  ],
  declarations: [
    AppComponent,
    HomeComponent
  ],
  providers: [
    ClientDataService,
    TaskDataService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
