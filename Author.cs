using Interfaces;
namespace LibraryApp
{
    public class Author : IAuthor
    {
        private readonly string Firstname;
        private readonly string Lastname;
        public Author(string firstName, string lastName)
        {
            this.Firstname = firstName;
            this.Lastname = lastName;
        }
    }
}
