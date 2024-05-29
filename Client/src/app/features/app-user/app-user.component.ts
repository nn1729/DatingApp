import { Component, Input, OnInit, inject, input } from '@angular/core';
import { AppUser } from '../../models/appUser';
import { DatingAppClientService } from '../../services/DatingAppClientService';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  templateUrl: './app-user.component.html',
  styleUrl: './app-user.component.scss'
})

export class AppUserComponent implements OnInit {

 private readonly appService: DatingAppClientService = inject(DatingAppClientService);

  @Input()
  appUsers: AppUser[] = [];

  public ngOnInit(): void {

    this.appService.getUsers().subscribe({
      next: response => this.appUsers = response,
      error: error => console.error("Error while fetching the app users"),
      complete: () => console.log("Fetching app users completed")
    })
  }
}
