using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.QuoteOfTheMonthRepository;

namespace ProiectASPNET.Services.QuoteOfTheMonthService
{
    public class QuoteOfTheMonthService : IQuoteOfTheMonthService
    {
        public readonly IQuoteOfTheMonthRepository _quoteOfTheMonthRepository;
        public readonly IMapper _mapper;

        public QuoteOfTheMonthService(IQuoteOfTheMonthRepository quoteOfTheMonthRepository, IMapper mapper)
        {
            _quoteOfTheMonthRepository = quoteOfTheMonthRepository;
            _mapper = mapper;
        }

        public async Task<List<QuoteOfTheMonthDTO>> GetAllQuoteOfTheMonth()
        {
            var quotes = await _quoteOfTheMonthRepository.GetAllQuoteOfTheMonth();
            var quotesDTO = _mapper.Map<List<QuoteOfTheMonthDTO>>(quotes);
            return quotesDTO;
        }
        
        public async Task<List<QuoteOfTheMonthDTO>> CreateQuoteOfTheMonthAsync(CreateQuoteOfTheMonthDTO quoteOfTheMonth)
        {
            var quote = _mapper.Map<QuoteOfTheMonth>(quoteOfTheMonth);
            await _quoteOfTheMonthRepository.CreateAsync(quote);
            await _quoteOfTheMonthRepository.SaveAsync();
            var quotes = await _quoteOfTheMonthRepository.GetAllQuoteOfTheMonth();
            var quotesDTO = _mapper.Map<List<QuoteOfTheMonthDTO>>(quotes);
            return quotesDTO;
        }
    }
}
