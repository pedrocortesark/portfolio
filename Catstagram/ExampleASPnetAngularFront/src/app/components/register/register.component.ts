import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private _fb: FormBuilder,
              private auth: AuthService) {
    this.registerForm = this._fb.group({
      'username': ['', Validators.required],
      'password': ['', Validators.required],
      'email': ['', Validators.required]
    })
   }

  ngOnInit(): void {
  }

  register()
  {
    this.auth.register(this.registerForm.value).subscribe(data => {
      console.log(data);
      
    });
  }

  get username()
  {    
    return this.registerForm.get('username');
  }

  get password()
  {
    return this.registerForm.get('password');
  }

  get email()
  {
    return this.registerForm.get('email');
  }

}
