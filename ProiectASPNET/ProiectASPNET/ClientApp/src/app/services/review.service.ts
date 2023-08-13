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
  
    postReview(review: any): Observable<any> {
      return this.apiService.post('Review', review);
    }
}