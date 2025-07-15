using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Domain.Data;

namespace LibraryManagementSystem.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _repo.GetAllAsync();
        public async Task<Book?> GetBookByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Book> CreateBookAsync(BookDTO dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _repo.AddAsync(book);
            await _repo.SaveAsync();
            return book;
        }

        public async Task<bool> UpdateBookAsync(int id, BookDTO dto)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return false;
            _mapper.Map(dto, book);
            _repo.Update(book);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return false;
            _repo.Delete(book);
            await _repo.SaveAsync();
            return true;
        }
    }
}
