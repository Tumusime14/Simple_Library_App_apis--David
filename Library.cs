namespace LibraryApp
{


    public class Library
    {
        public List<Book> books = new List<Book>();

        public AddNewBook()
        {
            Console.WriteLine("Enter Book Title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Enter Author's firstname");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Author's lastname");
            string lname = Console.ReadLine();

            Console.WriteLine("Data successful added!");


        }


    }
}
