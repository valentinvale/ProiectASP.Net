import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root'
})

export class AuthorService {
    
        constructor(private apiService: ApiService) { }
    
        getAuthors(): Observable<any> {
            return this.apiService.get('Author');
        }

    }

