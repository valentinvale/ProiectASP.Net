﻿using AutoMapper;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Repositories.BookRepository;

namespace ProiectASPNET.Services.BookService
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;
        public readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            var booksDTO = _mapper.Map<List<BookDTO>>(books);
            return booksDTO;
        }
    }


}