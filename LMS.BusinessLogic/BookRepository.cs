using System.Collections.Generic;
using System.Linq;

namespace LMS.BusinessLogic
{
    public class BookRepository
    {
        private List<Book> _booklist = new List<Book>();

        public void AddBook(Book book)
        {
            // Only add the book if it doesn't already exist (check by ISBN)
            if (!HasBook(book.Isbn))
            {
                _booklist.Add(book);
            }
        }

        public bool HasBook(string isbn)
        {
            return _booklist.Any(b => b.Isbn == isbn);
        }

        public void RemoveBook(string isbn)
        {
            var bookToRemove = _booklist.FirstOrDefault(b => b.Isbn == isbn);
            if (bookToRemove != null)
            {
                _booklist.Remove(bookToRemove);
            }
        }

        public int GetBookCount()
        {
            return _booklist.Count;
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _booklist.FirstOrDefault(b => b.Isbn == isbn);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _booklist.ToList();
        }
    }
}
