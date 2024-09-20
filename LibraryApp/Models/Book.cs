using System.Text.Json.Serialization;

namespace LibraryApp.Models;

public partial class Book
{
    internal readonly object Id;

    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int? AuthorId { get; set; }

    [JsonIgnore]
    public virtual Author? Author { get; set; }
}
