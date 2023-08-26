import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})

export class QuoteService {
  constructor(private apiService: ApiService) { }

  getQuotes(): Observable<any> {
    return this.apiService.get('Quote');
  }

  postQuote(quote: any): Observable<any> {
    return this.apiService.post('Quote', quote);
  }

  deleteQuote(quoteId: number): Observable<any> {
    return this.apiService.delete(`Quote/${quoteId}`);
  }
  
}
