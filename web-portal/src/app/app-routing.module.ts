import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { LegalPersonEditComponent } from './pages/legal-person-edit/legal-person-edit.component';
import { NaturalPersonCreateComponent } from './pages/natural-person-create/natural-person-create.component';
import { PersonEditComponent } from './pages/person-edit/person-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'person/edit/:id', component: PersonEditComponent }
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
  LegalPersonEditComponent,
  NaturalPersonCreateComponent,
  PersonEditComponent
];
