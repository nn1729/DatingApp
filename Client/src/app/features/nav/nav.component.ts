import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { loginUser } from '../../models/loginUser';
import { TokenService } from '../../services/TokenService';


@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {

  private readonly _tokenService = inject(TokenService);

  model: loginUser = {
    userName: '',
    password: ''
  };

  login() {

      this._tokenService.currentUser$()
    }

}
