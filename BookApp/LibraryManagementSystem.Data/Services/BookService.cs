using AutoMapper;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Domain.Data;

namespace LibraryManagementSystem.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Book> CreateBookAsync(BookDTO dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _repository.AddAsync(book);
            await _repository.SaveAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _repository.GetAllAsync();

        public async Task<Book?> GetBookByIdAsync(string id) => await _repository.GetByIdAsync(id);

        public async Task<bool> UpdateBookAsync(string id, BookDTO dto)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book is null) return false;

            _mapper.Map(dto, book);
            _repository.Update(book);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book is null) return false;

            _repository.Delete(book);
            await _repository.SaveAsync();
            return true;
        }
    }
}
