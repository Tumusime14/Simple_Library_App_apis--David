namespace LibraryApp
{
    public class Book
    {
        private readonly string title;
        private readonly Author author;
        public Book(string title, Author author)
        {
            this.title = title;
            this.author = author;

        }
    }
}
