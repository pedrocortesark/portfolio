import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private auth: AuthService, private route: Router) { }

  canActivate(): boolean
  {
    if (this.auth.isAuthenticated()) return true;
    else
    {
      this.route.navigate(["login"]);
      return false;
    }
  }

}
