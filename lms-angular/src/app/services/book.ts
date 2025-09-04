import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  // Use relative URL for production deployment
  private apiUrl = 'https://library-management-svc.onrender.com/api/books';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  getBook(isbn: string): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${isbn}`);
  }

  createBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.apiUrl, book);
  }

  deleteBook(isbn: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${isbn}`);
  }

  getBookCount(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/count`);
  }

  bookExists(isbn: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/exists/${isbn}`);
  }
}
