import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css'],
  //providers: [{provide: 'BASE_URL', useValue: 'https://localhost:7067/'}, ApiService]
  
})
export class HomeComponentComponent implements OnInit {

  constructor(private readonly authorService: AuthorService, private readonly bookService: BookService) { }

  authors: any;
  books: any;
  threeRandomNumbersBooks: any;
  threeRandomNumbersAuthors: any;

  ngOnInit(): void {
    this.authorService.getAuthors().subscribe(data => {
      this.authors = data;
      this.threeRandomNumbersAuthors = getThreeRandomInts(0, this.authors.length-1);
      console.log(this.threeRandomNumbersAuthors);
    
    });

    this.bookService.getBooks().subscribe(data => {
      this.books = data;
      this.threeRandomNumbersBooks = getThreeRandomInts(0, this.books.length-1);
      console.log(this.threeRandomNumbersBooks);
      console.log(this.books);
    });

    

    

  }

  goToBook(id: number) {
    this.bookService.goToBook(id);
  }

  

}

function getThreeRandomInts(minn: number, maxx: number) {
  var r = new Array();
  for (var i = 0; i < 3; i++) {
      r[i] = Math.floor(Math.random() * (maxx - minn + 1)) + minn;
  }
  return r;
}

// import { HttpClient } from '@angular/common/http';

// constructor(private http: HttpClient) {}

// ngOnInit() {
//   this.http.get('https://localhost:<port>/api/values').subscribe(data => {
//     console.log(data);
//   });
// }
