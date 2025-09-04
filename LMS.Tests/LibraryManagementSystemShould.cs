using LMS.BusinessLogic;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Tests
{
    // TDD -  "C:\Users\Ryan Gauthier\Pictures\TDD cycle.png"
    // Red - Green - Refactor
    // Write a failing test first (Red) - then write the minimum code to make it pass (Green) - then refactor the code to improve its structure and readability (Refactor)

    public class LibraryManagementSystemShould
    {
        [TestCase("1984", "George Orwell", "1234567890")]
        [TestCase("To Kill a Mockingbird", "Harper Lee", "0987654321")]
        [TestCase("The Great Gatsby", "F. Scott Fitzgerald", "1111111111")]
        [TestCase("", "Unknown Author", "2222222222")] // Edge case: empty title
        [TestCase("Very Long Book Title That Exceeds Normal Length", "Author", "3333333333")] // Edge case: long title
        
        public void AddBook_ShouldAddBook(string title, string author, string isbn)
        {
            // given
            // Create a new book and library management system
            var book = new Book(title, author, isbn);
            var library = new BookRepository();

            // when
            // Add the book to the library
            library.AddBook(book);

            //then
            // Verify that the book was added successfully
            Assert.That(library.HasBook(book.Isbn), Is.True);
        }

        [TestCase("1234567890")]
        [TestCase("0987654321")]
        [TestCase("1111111111")]
        [TestCase("")] // Edge case: empty ISBN
        [TestCase("invalid-isbn")] // Edge case: non-numeric ISBN
        
        public void RemoveBook_ShouldRemoveBookFromLibrary(string isbn)
        {
            // given
            var book = new Book("Test Book", "Test Author", isbn);
            var library = new BookRepository();
            library.AddBook(book);

            // when
            library.RemoveBook(isbn);

            // then
            Assert.That(library.HasBook(isbn), Is.False);
        }

        [TestCase(1, "Book1", "Author1", "1111111111")]
        [TestCase(2, "Book1", "Author1", "1111111111", "Book2", "Author2", "2222222222")]
        [TestCase(3, "Book1", "Author1", "1111111111", "Book2", "Author2", "2222222222", "Book3", "Author3", "3333333333")]
        [TestCase(0)] // Edge case: no books
        
        public void GetBookCount_ShouldReturnCorrectNumberOfBooks(int expectedCount, params string[] bookData)
        {
            // given
            var library = new BookRepository();

            // when
            for (int i = 0; i < bookData.Length; i += 3)
            {
                if (i + 2 < bookData.Length)
                {
                    var book = new Book(bookData[i], bookData[i + 1], bookData[i + 2]);
                    library.AddBook(book);
                }
            }

            // then
            Assert.That(library.GetBookCount(), Is.EqualTo(expectedCount));
        }

        [TestCase("1234567890", "1984", "George Orwell")]
        [TestCase("0987654321", "To Kill a Mockingbird", "Harper Lee")]
        [TestCase("1111111111", "The Great Gatsby", "F. Scott Fitzgerald")]
        
        public void GetBookByIsbn_ShouldReturnCorrectBook(string isbn, string expectedTitle, string expectedAuthor)
        {
            // given
            var library = new BookRepository();
            var book = new Book(expectedTitle, expectedAuthor, isbn);
            library.AddBook(book);

            // when
            var retrievedBook = library.GetBookByIsbn(isbn);

            // then
            Assert.That(retrievedBook, Is.Not.Null);
            Assert.That(retrievedBook.Title, Is.EqualTo(expectedTitle));
            Assert.That(retrievedBook.Author, Is.EqualTo(expectedAuthor));
        }

        [TestCase("nonexistent")]
        [TestCase("")]
        [TestCase("invalid-isbn")]
        [TestCase("1234567890")] // Valid ISBN but book not added
        
        public void GetBookByIsbn_WhenBookDoesNotExist_ShouldReturnNull(string isbn)
        {
            // given
            var library = new BookRepository();

            // when
            var retrievedBook = library.GetBookByIsbn(isbn);

            // then
            Assert.That(retrievedBook, Is.Null);
        }

        [TestCase("1984", "George Orwell", "1234567890")]
        [TestCase("To Kill a Mockingbird", "Harper Lee", "0987654321")]
        [TestCase("The Great Gatsby", "F. Scott Fitzgerald", "1111111111")]
        [TestCase("", "Unknown Author", "2222222222")] // Edge case: empty title
        [TestCase("Very Long Book Title That Exceeds Normal Length", "Author", "3333333333")] // Edge case: long title
        
        public void AddDuplicateBook_ShouldNotAddDuplicate(string title, string author, string isbn)
        {
            // given
            var library = new BookRepository();
            var book1 = new Book(title, author, isbn);
            var book2 = new Book(title, author, isbn); // Same ISBN

            // when
            library.AddBook(book1);
            library.AddBook(book2);

            // then
            Assert.That(library.GetBookCount(), Is.EqualTo(1));
        }

        [Test]
        public void RemoveBook_WhenBookDoesNotExist_ShouldNotThrowException()
        {
            // given
            var library = new BookRepository();

            // when & then
            Assert.DoesNotThrow(() => library.RemoveBook("nonexistent"));
        }
    }
}
