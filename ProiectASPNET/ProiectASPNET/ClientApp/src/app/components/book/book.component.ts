import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { ReviewService } from 'src/app/services/review.service';
import { QuoteService } from 'src/app/services/quote.service';
import { ApiService } from 'src/app/services/api.service';
import { ActivatedRoute } from '@angular/router';

import jwt_decode from 'jwt-decode';
import { User } from 'oidc-client';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  book: any;
  bookRating: number = 0;
  ratingSum: number = 0;
  numberOfRatings: number = 0;
  reviewTitleValue: String = '';
  reviewTextValue: String = '';
  reviewRatingValue: String = '1';
  quoteTextValue: String = '';
  quoteNotesValue: String = '';
  contentToAdd: String = 'review';
  isLoggedIn: Boolean = false;
  userHasReviewed: Boolean = false;
  userId: any;


  constructor(private readonly route: ActivatedRoute, private readonly bookService: BookService, private readonly reviewService: ReviewService, private readonly quoteService: QuoteService) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null) {
      this.isLoggedIn = true;
    }
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.bookService.getBookById(id).subscribe(data => {
        this.book = data;
        console.log(this.book);
        if (this.book[0].reviews.length > 0) {
          this.ratingSum = 0;
          this.numberOfRatings = this.book[0].reviews.length;
          this.book[0].reviews.forEach((review: any) => {
            this.ratingSum += review.rating;
          });
          this.bookRating = this.ratingSum / this.numberOfRatings;
          this.bookRating = Math.round(this.bookRating * 10) / 10;
        }
        let token = localStorage.getItem('token');
        if (token != null) {
          let decodedToken: any = jwt_decode(token);
          let userId = decodedToken.id;
          this.userId = userId;
          this.reviewService.getReviewByUserAndBookId(userId, id).subscribe((data: any) => {
            if (data != null) {
              this.userHasReviewed = true;
            }
          })
        }
      });
    });
  }

  addReview(): void {
    if (this.isLoggedIn) {
      const token = localStorage.getItem('token');
      if (token != null) {
        const decodedToken: any = jwt_decode(token);
        var userId = decodedToken.id;
        var username = decodedToken.username;
      }
      if (this.reviewRatingValue != '' && this.reviewTitleValue != '') {
        const newReview = {
          HeadLine: this.reviewTitleValue,
          ReviewText: this.reviewTextValue,
          Rating: Number(this.reviewRatingValue),
          Username: username,
          BookId: this.book[0].id,
          UserId: userId

        }

        console.log(newReview);

        this.reviewService.postReview(newReview).subscribe((data: any) => {
          console.log(data);

          this.book[0].reviews.push(data); // folosim book[0] pentru ca HTTPPOST intoarce un array cu un singur element :/
          this.numberOfRatings++;
          this.ratingSum += data.rating;
          this.bookRating = this.ratingSum / this.numberOfRatings;
          this.bookRating = Math.round(this.bookRating * 10) / 10;
          console.log(this.book);
          this.userHasReviewed = true;

          this.reviewTitleValue = '';
          this.reviewTextValue = '';
          this.reviewRatingValue = '1';

        });
      }
      else {
        console.log("Fields cannot be empty");
      }
    }
    console.log(this.userHasReviewed);
  }

  deleteReview(reviewId: number): void {
    // TO DO: make delete button work right after a review is posted
    console.log("delete this review: " + reviewId);
    this.reviewService.getReviewById(reviewId).subscribe((data: any) => {
      console.log("deleted review: " + data)
      this.numberOfRatings--;
      this.ratingSum -= data.rating;
      this.bookRating = this.ratingSum / this.numberOfRatings;
      this.bookRating = Math.round(this.bookRating * 10) / 10;
    });
    this.reviewService.deleteReview(reviewId).subscribe((data: any) => {
      console.log("review deleted");
      this.book[0].reviews = this.book[0].reviews.filter((review: any) => review.id != reviewId);
      this.userHasReviewed = false;
    });
  }

  addQuote(): void {
    if (this.isLoggedIn) {
      const token = localStorage.getItem('token');
      if (token != null) {
        const decodedToken: any = jwt_decode(token);
        var userId = decodedToken.id;
        var username = decodedToken.username;
      }
      if (this.quoteTextValue != '') {
        const newQuote = {
          Text: this.quoteTextValue,
          Notes: this.quoteNotesValue,
          Username: username,
          BookId: this.book[0].id,
          UserId: userId

        }

        console.log(newQuote);

        this.quoteService.postQuote(newQuote).subscribe((data: any) => {
          console.log(data);

          this.book[0].quotes.push(data); // folosim book[0] pentru ca HTTPPOST intoarce un array cu un singur element :/

          console.log(this.book);

          this.quoteNotesValue = '';
          this.quoteTextValue = '';

        });
      }
      else {
        console.log("Fields cannot be empty");
      }


    }

  }

  deleteQuote(quoteId: number): void {
    this.quoteService.deleteQuote(quoteId).subscribe((data: any) => {
      console.log("quote deleted");
      this.book[0].quotes = this.book[0].quotes.filter((quote: any) => quote.id != quoteId);
    });
  }

}
