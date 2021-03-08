import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { NaturalPersonEditComponent } from './pages/natural-person-edit/natural-person-edit.component';
import { LegalPersonEditComponent } from './pages/legal-person-edit/legal-person-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'person/new', component: NaturalPersonEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponent = [ 
  HomeComponent, 
  LoginComponent, 
  ContactsComponent, 
  NaturalPersonEditComponent,
  LegalPersonEditComponent
];
