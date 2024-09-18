import { Component, OnInit, viewChild } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { Observable } from 'rxjs';
import { IUser } from '../../../users/models/user';
import { ITodo } from '../../../todos/models/todo.model';
import { TodoService } from '../../../core/services/todo.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { TodoDialogComponent } from '../../../todos/components/todo-dialog/todo-dialog.component';
import { ITodoDialog, ITodoDialogResponse } from '../../../todos/models/todo-dialog.model';

@Component({
  selector: 'rf-app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  
  todos$!: Observable<ITodo[]>;
  users$!: Observable<IUser[]>;
  
  constructor(private userService: UserService, private todoService: TodoService, private dialog: MatDialog){}
  
  
  ngOnInit(): void {
    this.users$ = this.userService.getUsers$();
  }
  
  onUserSelected(selectedUser: IUser) {
    this.getTodosByUserId(selectedUser.id);
  }

  getTodosByUserId(userId: string) {
    this.todos$ = this.todoService.getTodosByUserId$(userId);
  }
  
  onTodoSelected(todo: ITodo) {
    const todoDialogData: ITodoDialog = {
      ...todo,
      users$: this.users$,
       actionBtnText: 'Delete'
    };
    this.openDialog(todoDialogData);
  }

  onAddTodo() {
    const todoDialogData: ITodoDialog = {
      id: 0,
      name: '',
      userId: '',
      actionBtnText: 'Clear',
      users$: this.users$
    }
    this.openDialog(todoDialogData);
  }

  openDialog(todoDialogData: ITodoDialog) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;    
    dialogConfig.data = todoDialogData;

    const dialogRef = this.dialog.open(TodoDialogComponent, dialogConfig)
    dialogRef.afterClosed().subscribe((val: ITodoDialogResponse | undefined) => {
      if (val) {
        if (val.isDelete) {
          this.todoService.deleteTodo(val.todo).subscribe(res => {
            this.getTodosByUserId(val.todo.userId); // TODO: Use behaviour subjects in service layer to maintain state instead of calling api
          });         
        } else if (val.todo.id > 0) {
          this.todoService.putTodo(val.todo).subscribe(res => {
            this.getTodosByUserId(val.todo.userId);
          });
        } else {
          this.todoService.postTodo(val.todo).subscribe(res => {
            this.getTodosByUserId(val.todo.userId);
          });
        }
      }
    });
  }


}


