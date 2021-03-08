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
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';

import { RouterModule } from '@angular/router';
import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuNavComponent } from './components/menu-nav/menu-nav.component';
import { PrimaryToolbarComponent } from './components/primary-toolbar/primary-toolbar.component';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';

@NgModule({
  declarations: [
    AppComponent,
    MenuNavComponent,
    PrimaryToolbarComponent,
    routingComponent
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
    MatDividerModule,
    MatCardModule,
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
