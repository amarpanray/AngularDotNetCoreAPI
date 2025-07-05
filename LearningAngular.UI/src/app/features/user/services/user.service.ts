import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AddUserRequest } from '../models/add-user-request.model';

@Injectable({  providedIn: 'root'})

export class UserService 
{
  constructor(private http: HttpClient) {  }
  
  getAllUsers() : Observable<User[]>
  { 
    return this.http.get<User[]>(`${environment.apiBaseUrl}/api/user`)
  }
addUser(model: AddUserRequest): Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/user`, model);
  }
  


}
