import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { ITodo } from '../../models/todo.model';

@Component({
  selector: 'rf-app-todos',
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.scss'
})
export class TodosComponent {
  @Input() todos$!: Observable<ITodo[]>;
  @Output() todoSelected = new EventEmitter<ITodo>();
  @Output() addTodo = new EventEmitter<any>();
  
  onTodoClick(todo: ITodo) {
    this.todoSelected.emit(todo);
  }
  onAddTodo() {
    this.addTodo.emit();
  }
}
