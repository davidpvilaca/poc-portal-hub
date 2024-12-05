import { AuthService, ConfigStateService, CurrentUserDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  user: CurrentUserDto

  constructor(
    private authService: AuthService,
    private configStateService: ConfigStateService
  ) { }

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit(): void {
    this.user = this.configStateService.getOne('currentUser')
  }
}
