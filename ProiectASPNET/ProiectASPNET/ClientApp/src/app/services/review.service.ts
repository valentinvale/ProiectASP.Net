import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})

export class ReviewService {
  constructor(private apiService: ApiService) { }
  
    getReviews(): Observable<any> {
      return this.apiService.get('Review');
    }

    getReviewByUserAndBookId(userId: number, bookId: number): Observable<any> {
      return this.apiService.get(`Review/${userId}/${bookId}`);
    }

    getReviewById(reviewId: number): Observable<any> {
      return this.apiService.get(`Review/${reviewId}`);
    }
  
    postReview(review: any): Observable<any> {
      return this.apiService.post('Review', review);
    }

    deleteReview(reviewId: number): Observable<any> {
      return this.apiService.delete(`Review/${reviewId}`);
    }

}
