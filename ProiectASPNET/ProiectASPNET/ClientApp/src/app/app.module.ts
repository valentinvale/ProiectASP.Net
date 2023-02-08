import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponentComponent } from './components/home-component/home-component.component';
import { LoginComponentComponent } from './components/login-component/login-component.component';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponentComponent,
    LoginComponentComponent,
    NavbarComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponentComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponentComponent } , 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
