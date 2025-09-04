import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from '../../services/book';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book-form.html',
  styleUrl: './book-form.scss'
})
export class BookFormComponent {
  book: Book = {
    title: '',
    author: '',
    isbn: ''
  };
  
  loading: boolean = false;
  error: string = '';
  success: string = '';

  constructor(
    private bookService: BookService,
    private router: Router
  ) { }

  onSubmit(): void {
    if (!this.book.title || !this.book.author || !this.book.isbn) {
      this.error = 'All fields are required.';
      return;
    }

    this.loading = true;
    this.error = '';
    this.success = '';

    this.bookService.createBook(this.book).subscribe({
      next: (createdBook) => {
        this.success = `Book "${createdBook.title}" added successfully!`;
        this.loading = false;
        
        // Reset form
        this.book = {
          title: '',
          author: '',
          isbn: ''
        };
        
        // Navigate back to book list after a short delay
        setTimeout(() => {
          this.router.navigate(['/books']);
        }, 1500);
      },
      error: (error) => {
        this.error = 'Error adding book: ' + error.message;
        this.loading = false;
      }
    });
  }

  onCancel(): void {
    this.router.navigate(['/books']);
  }
}
