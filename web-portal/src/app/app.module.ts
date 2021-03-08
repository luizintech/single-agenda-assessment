import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';

import { RouterModule } from '@angular/router';
import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuNavComponent } from './components/menu-nav/menu-nav.component';
import { PrimaryToolbarComponent } from './components/primary-toolbar/primary-toolbar.component';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';

@NgModule({
  declarations: [
    AppComponent,
    MenuNavComponent,
    PrimaryToolbarComponent,
    routingComponent,
    ContactsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatMenuModule,
    MatToolbarModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthManager
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
