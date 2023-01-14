using ProiectASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace ProiectASPNET.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorInBook> AuthorsInBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorInBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorInBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.BooksLink)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<AuthorInBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorsLink)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
