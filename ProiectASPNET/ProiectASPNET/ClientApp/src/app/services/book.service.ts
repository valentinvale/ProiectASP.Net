import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})

export class BookService {

    constructor(private apiService: ApiService, private router: Router) { }

    getBooks(): Observable<any> {
        return this.apiService.get('Book');
    }

    goToBook(id: number) {
        this.router.navigate(['/book', id]);
    }

    getBookById(id: number): Observable<any> {
        return this.apiService.get('Book/getBookById/' + id);
    }

}