﻿using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.GenericRepository;

namespace ProiectASPNET.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ProjectContext context) : base(context)
        {
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

        public async Task<List<Book>> GetBooksByAuthorId(Guid authorId)
        {
            return await _table.Include(x => x.AuthorsLink).ThenInclude(y => y.Author)
                .Where(x => x.AuthorsLink.Any(y => y.AuthorId == authorId)).Include(x => x.Reviews)
                .Include(x => x.Quotes).ToListAsync();
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
