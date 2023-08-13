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

  addReview(reviewTitleValue: String, reviewTextValue: String, reviewRatingValue: String): void {
    console.log('add review');
    console.log(reviewTitleValue)
    console.log(reviewTextValue)
    console.log(reviewRatingValue)

    if (reviewRatingValue != '' && reviewTitleValue != '') {
      const newReview = {
        HeadLine: reviewTitleValue,
        ReviewText: reviewTextValue,
        Rating: Number(reviewRatingValue),
        BookId: this.book[0].id,
        UserId: this.book[0].id

      }

      console.log(newReview);

      this.reviewService.postReview(newReview).subscribe((data: any) => {
        console.log(data);

        reviewTitleValue = '';
        reviewTextValue = '';
        reviewRatingValue = '';

      });
    }
    else {
      console.log("Fields cannot be empty");
    }

    

    



  }

}
