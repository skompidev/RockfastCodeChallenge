import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITodo } from '../../todos/models/todo.model';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(private httpClient: HttpClient) { }

  getTodos$() {
    return this.httpClient.get<ITodo[]>(environment.baseTodosApiUrl);
  }

  getTodosByUserId$(userId: string) {
    return this.httpClient.get<ITodo[]>(`${environment.baseTodosApiUrl}/user/${userId}`);
  }

  putTodo(todo: ITodo) {
    return this.httpClient.put<ITodo>(`${environment.baseTodosApiUrl}`, todo);
  }

  postTodo(todo: ITodo) {
    return this.httpClient.post<ITodo>(`${environment.baseTodosApiUrl}`, todo);
  }

  deleteTodo(todo: ITodo) {
    return this.httpClient.delete<boolean>(`${environment.baseTodosApiUrl}/${todo.id}`);
  }
}
