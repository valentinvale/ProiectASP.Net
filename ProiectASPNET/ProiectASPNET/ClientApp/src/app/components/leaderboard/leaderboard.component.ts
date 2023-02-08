import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { ApiService } from 'src/app/services/api.service';
import { LeaderboardService } from 'src/app/services/leaderboard.service';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {

  leaderboard: any;
  books: any;

  constructor(private readonly leaderboardService: LeaderboardService, private readonly bookService: BookService) { }

  ngOnInit(): void {
    this.leaderboardService.getLeaderboard().subscribe(data => {
      this.leaderboard = data;
      console.log(this.leaderboard);
    });

    this.bookService.getBooks().subscribe(data => {
      this.books = data;
      console.log(this.books);
    });

  }

}
