using AutoMapper;
using ProiectASPNET.Repositories.QuoteRepository;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<List<QuoteDTO>> GetAllQuotes()
        {
            var quotes = await _quoteRepository.GetAllAsync();
            var quotesDTO = _mapper.Map<List<QuoteDTO>>(quotes);
            return quotesDTO;
        }
    }
    
}
