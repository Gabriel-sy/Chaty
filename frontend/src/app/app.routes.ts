import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home/home.component';
import { CadastroComponent } from './components/auth/cadastro/cadastro.component';
import { LoginComponent } from './components/auth/login/login.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { EditComponent } from './components/user/edit/edit.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'login', component: LoginComponent },
  { path: 'user', component: ProfileComponent },
  { path: 'user/edit', component: EditComponent }

];
