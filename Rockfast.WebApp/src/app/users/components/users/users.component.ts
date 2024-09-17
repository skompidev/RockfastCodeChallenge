import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../../models/user';

@Component({
  selector: 'rf-app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent {
  @Input() users: Observable<IUser[]> | undefined;
  @Output() userSelected: EventEmitter<IUser> = new EventEmitter<IUser>();


  onUserClick(user: IUser) {
    this.userSelected.emit(user);
  }
}
