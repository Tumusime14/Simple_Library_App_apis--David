using System.Text.Json.Serialization;

namespace LibraryApp.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
