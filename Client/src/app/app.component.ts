import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppUserComponent } from './features/app-user/app-user.component';
import { NavComponent } from "./features/nav/nav.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, AppUserComponent, NavComponent]
})
export class AppComponent {
  title = 'Dating App';
}
