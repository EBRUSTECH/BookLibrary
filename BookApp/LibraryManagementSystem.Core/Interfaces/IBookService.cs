using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Domain.Data;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<Book> CreateBookAsync(BookDTO dto);
        public Task<bool> UpdateBookAsync(int id, BookDTO dto);
        public Task<bool> DeleteBookAsync(int id);
    }
}
