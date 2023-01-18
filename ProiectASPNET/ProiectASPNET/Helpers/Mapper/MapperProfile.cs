using AutoMapper;
using ProiectASPNET.Models;
using ProiectASPNET.Models.DTOs;

namespace ProiectASPNET.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Review, ReviewDTO>();

            CreateMap<BookDTO, Book>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<Quote, QuoteDTO>();
            CreateMap<QuoteDTO, Quote>();

            CreateMap<CreateBookDTO, Book>();
            CreateMap<Book, CreateBookDTO>();

            CreateMap<Review, CreateReviewDTO>();
            CreateMap<CreateReviewDTO, Review>();

            CreateMap<Author, CreateAuthorDTO>();
            CreateMap<CreateAuthorDTO, Author>();


            CreateMap<AuthorInBookDTO, Book>();
            CreateMap<Book, AuthorInBookDTO>().ForMember(
                dest => dest.Authors,
                opt => opt.MapFrom(src => src.AuthorsLink.Select(x => x.Author))
            );

            CreateMap<AuthorAndReviewInBook, Book>();
            CreateMap<Book, AuthorAndReviewInBook>().ForMember(
                dest => dest.Authors,
                opt => opt.MapFrom(src => src.AuthorsLink.Select(x => x.Author))
            );

            CreateMap<Quote, QuoteDTO>();
            CreateMap<QuoteDTO, Quote>();

            CreateMap<Quote, CreateQuoteDTO>();
            CreateMap<CreateQuoteDTO, Quote>();

        }
    }
}
