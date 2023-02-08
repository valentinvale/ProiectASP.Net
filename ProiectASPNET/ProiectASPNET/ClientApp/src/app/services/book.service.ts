import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root'
})

export class BookService {

    constructor(private apiService: ApiService) { }

    getBooks(): Observable<any> {
        return this.apiService.get('Book');
    }

}