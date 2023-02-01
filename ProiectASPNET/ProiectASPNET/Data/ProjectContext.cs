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

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<QuoteOfTheMonth> QuotesOfTheMonth { get; set; }

        public DbSet<Leaderboard> Leaderboards { get; set; }

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

            // many to one

            modelBuilder.Entity<Book>()
                .HasMany(r => r.Reviews)
                .WithOne(b => b.Book);

            modelBuilder.Entity<Book>()
                .HasMany(q => q.Quotes)
                .WithOne(b => b.Book);

            modelBuilder.Entity<QuoteOfTheMonth>()
                .HasOne(q => q.Quote);


            modelBuilder.Entity<QuoteOfTheMonth>()
                .HasOne(l => l.Leaderboard)
                .WithOne(q => q.QuoteOfTheMonth)
                .HasForeignKey<Leaderboard>(l => l.QuoteOfTheMonthId);





            base.OnModelCreating(modelBuilder);
        }

    }
}
