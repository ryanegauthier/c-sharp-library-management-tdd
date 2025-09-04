import { Routes } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list';
import { BookFormComponent } from './components/book-form/book-form';

export const routes: Routes = [
  { path: '', redirectTo: '/books', pathMatch: 'full' },
  { path: 'books', component: BookListComponent },
  { path: 'books/add', component: BookFormComponent }
];
