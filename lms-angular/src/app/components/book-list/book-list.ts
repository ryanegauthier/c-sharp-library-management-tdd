import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BookService } from '../../services/book';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './book-list.html',
  styleUrl: './book-list.scss'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  bookCount: number = 0;
  loading: boolean = false;
  error: string = '';

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.loadBooks();
    this.loadBookCount();
  }

  loadBooks(): void {
    this.loading = true;
    this.bookService.getBooks().subscribe({
      next: (books) => {
        this.books = books;
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Error loading books: ' + error.message;
        this.loading = false;
      }
    });
  }

  loadBookCount(): void {
    this.bookService.getBookCount().subscribe({
      next: (count) => {
        this.bookCount = count;
      },
      error: (error) => {
        console.error('Error loading book count:', error);
      }
    });
  }

  deleteBook(isbn: string): void {
    if (confirm(`Are you sure you want to delete the book with ISBN ${isbn}?`)) {
      this.bookService.deleteBook(isbn).subscribe({
        next: () => {
          this.loadBooks();
          this.loadBookCount();
        },
        error: (error) => {
          this.error = 'Error deleting book: ' + error.message;
        }
      });
    }
  }
}
