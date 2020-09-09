import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

//Components
import { RegisterComponent } from './components/register/register.component'
import { LoginComponent } from './components/login/login.component';
import { CreatepostComponent } from './components/createpost/createpost.component';
import { ListCatsComponent } from './components/list-cats/list-cats.component';
import { DetailsCatComponent } from './components/details-cat/details-cat.component';
import { EditCatComponent } from './components/edit-cat/edit-cat.component';


//Services
import { AuthService } from './services/auth.service';
import { CatService } from './services/cat.service';
import { AuthGuardService } from './services/auth-guard.service';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { TokenInterceptorService } from './services/token-interceptor.service';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreatepostComponent,
    ListCatsComponent,
    DetailsCatComponent,
    EditCatComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AuthService,
    CatService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
