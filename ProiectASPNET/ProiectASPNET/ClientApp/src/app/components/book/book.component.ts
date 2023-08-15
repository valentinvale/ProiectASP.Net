import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { ReviewService } from 'src/app/services/review.service';
import { ApiService } from 'src/app/services/api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  book: any;
  reviewTitleValue: String = '';
  reviewTextValue: String = '';
  reviewRatingValue: String = '1';


  constructor(private readonly route: ActivatedRoute, private readonly bookService: BookService, private readonly reviewService: ReviewService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.bookService.getBookById(id).subscribe(data => {
        this.book = data;
        console.log(this.book);
      });
    });
  }

  addReview(): void {
    console.log('add review');
    console.log(this.reviewTitleValue)
    console.log(this.reviewTextValue)
    console.log(this.reviewRatingValue)

    if (this.reviewRatingValue != '' && this.reviewTitleValue != '') {
      const newReview = {
        HeadLine: this.reviewTitleValue,
        ReviewText: this.reviewTextValue,
        Rating: Number(this.reviewRatingValue),
        BookId: this.book[0].id,
        UserId: this.book[0].id

      }

      console.log(newReview);

      this.reviewService.postReview(newReview).subscribe((data: any) => {
        console.log(data);

        this.book[0].reviews.push(data); // folosim book[0] pentru ca HTTPPOST intoarce un array cu un singur element :/

        console.log(this.book);

        this.reviewTitleValue = '';
        this.reviewTextValue = '';
        this.reviewRatingValue = '1';

      });
    }
    else {
      console.log("Fields cannot be empty");
    }

    

    



  }

}
