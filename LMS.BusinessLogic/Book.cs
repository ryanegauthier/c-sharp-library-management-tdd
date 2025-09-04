namespace LMS.BusinessLogic
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Isbn { get; }

        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.Isbn = isbn;
        }
    }
}
