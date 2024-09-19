import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodosComponent } from './components/todos/todos.component';
import { TodoDialogComponent } from './components/todo-dialog/todo-dialog.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    TodosComponent,
    TodoDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[
    TodosComponent
  ]
})
export class TodosModule { }
