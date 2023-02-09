import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { ApiService } from 'src/app/services/api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  book: any;

  constructor(private readonly route: ActivatedRoute, private readonly bookService: BookService) { }

  ngOnInit(): void {
      this.route.params.subscribe(params => {
      const id = params['id'];
      this.bookService.getBookById(id).subscribe(data => {
        this.book = data;
        console.log(this.book);
      });
    });
  }

  

}
