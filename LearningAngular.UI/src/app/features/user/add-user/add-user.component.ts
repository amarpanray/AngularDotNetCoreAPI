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
     {this.model = { name: '', description: '', id:'' };
    }

    ngOnDestroy(): void {this.addUserSubscription?.unsubscribe();}

    }

