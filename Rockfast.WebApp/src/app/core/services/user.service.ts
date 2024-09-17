import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from '../../users/models/user';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getUsers() {
    return this.httpClient.get<IUser[]>(environment.baseUsersApiUrl);
  }
}
