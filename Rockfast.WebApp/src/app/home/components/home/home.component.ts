import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { Observable } from 'rxjs';
import { IUser } from '../../../users/models/user';

@Component({
  selector: 'rf-app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  
  users$!: Observable<IUser[]>;
  
  constructor(private userService: UserService){}
  
  
  ngOnInit(): void {
    this.users$ = this.userService.getUsers();
  }
  
  onUserSelected($event: IUser) {
    console.log($event);
  }

}
