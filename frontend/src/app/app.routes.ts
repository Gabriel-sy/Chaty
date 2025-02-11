import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home/home.component';
import { CadastroComponent } from './components/auth/cadastro/cadastro.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cadastro', component: CadastroComponent }
];
