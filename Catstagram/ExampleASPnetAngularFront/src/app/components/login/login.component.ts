import { Router } from '@angular/router';
import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private _fb: FormBuilder,
              private _authService: AuthService,
              private router: Router) {
    this.loginForm = this._fb.group({
      'username': ['', [Validators.required]],
      'password': ['', Validators.required]
    });
   }

  ngOnInit(): void {
  }

  login()
  {
    this._authService.login(this.loginForm.value).subscribe(data => {
      this._authService.savetoken(data['token']);
      this.router.navigate(['cats']);
    })
  }

  get username()
  {
    return this.loginForm.get('username');
  }

  get password()
  {
    return this.loginForm.get('password');
  }

}
