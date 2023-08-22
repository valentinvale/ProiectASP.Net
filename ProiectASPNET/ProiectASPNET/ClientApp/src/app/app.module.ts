import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponentComponent } from './components/home-component/home-component.component';
import { LoginComponentComponent } from './components/login-component/login-component.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BooksComponent } from './components/books/books.component';
import { AuthorsComponent } from './components/authors/authors.component';
import { LeaderboardComponent } from './components/leaderboard/leaderboard.component';
import { BookComponent } from './components/book/book.component';
import { SignupComponent } from './components/signup/signup.component';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponentComponent,
    LoginComponentComponent,
    NavbarComponent,
    BooksComponent,
    AuthorsComponent,
    LeaderboardComponent,
    BookComponent,
    SignupComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponentComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponentComponent } ,
      { path: 'books', component: BooksComponent } , 
      { path: 'authors', component: AuthorsComponent } ,
      { path: 'leaderboard', component: LeaderboardComponent } ,
      { path: 'book/:id', component: BookComponent },
      { path: 'signup', component: SignupComponent}
    ])
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
