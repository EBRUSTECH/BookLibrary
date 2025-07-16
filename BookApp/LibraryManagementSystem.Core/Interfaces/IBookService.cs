
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Domain.Data;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book?> GetBookByIdAsync(string id);
        public Task<Book> CreateBookAsync(BookDTO dto);
        public Task<bool> UpdateBookAsync(string id, BookDTO dto);
        public Task<bool> DeleteBookAsync(string id);
    }
}
