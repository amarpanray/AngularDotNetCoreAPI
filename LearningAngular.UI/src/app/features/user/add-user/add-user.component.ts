import { Component, OnDestroy  } from '@angular/core';
import { AddUserRequest } from '../models/add-user-request.model';
import { UserService } from '../services/user.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})

export class AddUserComponent implements OnDestroy {
model: AddUserRequest;
private addUserSubscription?: Subscription;
 constructor(private userService: UserService, private router: Router)
     {this.model = { name: '', email: '', id:'' };
    }

    onFormSubmit(): void{ this.addUserSubscription = this.userService.addUser(this.model)
    .subscribe({
      next: (response) =>{
      //  console.log('This was successful')
        this.router.navigateByUrl('admin/users')
      },
      error: (error) =>{
        console.log("An error has been detected.")
      }
    })}
    ngOnDestroy(): void {this.addUserSubscription?.unsubscribe();}

    }

