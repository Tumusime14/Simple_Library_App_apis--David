using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TUMUSIME;Initial Catalog=librarydb;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__70DAFC34B9C4834D");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3DE0C20779BFB3BE");

            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__AuthorId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
