import { EditCatComponent } from './components/edit-cat/edit-cat.component';
import { DetailsCatComponent } from './components/details-cat/details-cat.component';
import { ListCatsComponent } from './components/list-cats/list-cats.component';
import { AuthGuardService } from './services/auth-guard.service';
import { CreatepostComponent } from './components/createpost/createpost.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create', component: CreatepostComponent, canActivate: [AuthGuardService] },
  { path: 'cats', component: ListCatsComponent, canActivate: [AuthGuardService]},
  { path: 'cats/:id', component: DetailsCatComponent, canActivate: [AuthGuardService]},
  { path: 'cats/:id/edit', component: EditCatComponent, canActivate: [AuthGuardService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
