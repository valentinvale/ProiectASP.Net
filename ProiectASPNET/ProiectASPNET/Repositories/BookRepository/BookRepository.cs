using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly DbSet<Author> _authorsTable;
        private readonly DbSet<Quote> _quotesTable;
        private readonly DbSet<Review> _reviewsTable;
        private readonly DbSet<AuthorInBook> _authorsLinkTable;
        

        public BookRepository(ProjectContext context) : base(context)
        {
            _authorsTable = context.Authors;
            _quotesTable = context.Quotes;
            _reviewsTable = context.Reviews;
            _authorsLinkTable = context.AuthorsInBooks;
        }

        public async Task<List<Book>> GetBooksWithReviewsAsync()
        {
            return await _table.Include(x => x.Reviews).ToListAsync();
        }

        public async Task<List<Book>> GetAuthorsWithBooksAsync()
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author).ToListAsync();
        }

        public async Task<List<Book>> GetAllWithBooksAsync()
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Include(x => x.Reviews).Include(x => x.Quotes).ToListAsync();
        }

        public async Task<List<Book>> GetAllWithBooksNoRQ()
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Include(x => x.Reviews).Include(x => x.Quotes).ToListAsync();
        }

        /*
        public async Task<List<Book>> GetBooksByAuthorId(Guid authorId)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.AuthorsLink.Any(y => y.AuthorId == authorId)).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }
        
        */

        public async Task<List<Book>> GetBooksByAuthorId(Guid authorId)
        {
            
            var books = await _table.ToListAsync();
            var authorsLink = await _authorsLinkTable.Where(x => x.AuthorId == authorId).ToListAsync();
            var authors = await _authorsTable.Where(x => x.Id == authorId).ToListAsync();
            var reviews = await _reviewsTable.ToListAsync();
            var quotes = await _quotesTable.ToListAsync();

            return books.Join(authorsLink,
                b => b.Id,
                al => al.BookId,
                (b, al) => new { Book = b, AuthorsLink = al })
                .Join(authors,
                ba => ba.AuthorsLink.AuthorId,
                a => a.Id,
                (ba, a) => new { BookAuthor = ba, Author = a })
                .GroupBy(baa => baa.BookAuthor.Book.Id)
                .Select(g =>
                {
                    var book = g.First().BookAuthor.Book;
                    book.AuthorsLink = g.Select(x => x.BookAuthor.AuthorsLink).ToList();
                    book.Reviews = reviews.Where(r => r.BookId == book.Id).ToList();
                    book.Quotes = quotes.Where(q => q.BookId == book.Id).ToList();
                    return book;
                })
                .ToList();
        }


        public async Task<List<Book>> GetBooksByAuthorName(string authorName)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.AuthorsLink.Any(y => y.Author.FirstName.Contains(authorName) || y.Author.LastName.Contains(authorName))).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }

        public async Task<List<Book>> GetBooksById(Guid bookId)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.Id == bookId).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }

        public async Task<Book> GetBookByQuoteId(Guid quoteId)
        {
            return await _table.Include(x => x.Quotes).FirstOrDefaultAsync(x => x.Quotes.Any(y => y.Id == quoteId));
        }

        public async Task<List<Book>> GetBooksByTitle(string bookTitle)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.Title.Contains(bookTitle)).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByGenre(string bookGenre)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.Genre.ToLower() == bookGenre.ToLower()).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByISBN(string isbn)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.ISBN.Contains(isbn)).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
        }

    }

}
