using AutoMapper;
using ProiectASPNET.Repositories.QuoteRepository;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Models;
using ProiectASPNET.Repositories.BookRepository;

namespace ProiectASPNET.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quoteRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<QuoteDTO>> CreateQuoteAsync(CreateQuoteDTO quote)
        {
            var quoteEntity = _mapper.Map<Quote>(quote);
            await _quoteRepository.CreateAsync(quoteEntity);
            await _quoteRepository.SaveAsync();
            var quotes = await _quoteRepository.GetAllAsync();
            var quotesDTO = _mapper.Map<List<QuoteDTO>>(quotes);
            return quotesDTO;
        }

        public async Task<List<QuoteDTO>> GetAllQuotes()
        {
            var quotes = await _quoteRepository.GetAllAsync();
            var quotesDTO = _mapper.Map<List<QuoteDTO>>(quotes);
            return quotesDTO;
        }

        public async Task UpdateQuoteAsync(Guid bookId, UpdateQuoteDTO quote)
        {
            var q = _mapper.Map<Quote>(quote);
            q.Book = _bookRepository.FindByIdAsync(bookId).Result;
            _quoteRepository.Update(q);
            await _quoteRepository.SaveAsync();
        }

        public async Task DeleteQuote(Guid quoteId)
        {
            var quote = await _quoteRepository.FindByIdAsync(quoteId);
            _quoteRepository.Delete(quote);
            await _quoteRepository.SaveAsync();
            
        }
        
               
    }

}
