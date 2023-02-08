import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
    providedIn: 'root'
})

export class LeaderboardService {
    
    constructor(private apiService: ApiService) { }

    getLeaderboard(): Observable<any> {
        return this.apiService.get('Leaderboard');
    }

}