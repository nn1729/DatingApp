import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppUserComponent } from './features/app-user/app-user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppUserComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Dating App';
}
