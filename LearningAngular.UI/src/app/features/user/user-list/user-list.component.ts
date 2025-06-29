import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit{
   users$?: Observable<User[]>;
   constructor(private userService: UserService){
     }
 ngOnInit(): void {
    this.users$ = this.userService.getAllUsers();
  }

}


 