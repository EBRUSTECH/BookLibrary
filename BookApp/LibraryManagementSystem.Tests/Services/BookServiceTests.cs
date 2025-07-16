/*using AutoMapper;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Data.Services;
using LibraryManagementSystem.Domain.Data;
using LibraryManagementSystem.Core.Mapping;
using Moq;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryManagementSystem.Tests.Services
{
    public class BookServiceTests
    {
        private readonly IMapper _mapper;

        public BookServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CreateBookAsync_ReturnsCreatedBook()
        {
            // Arrange
            var repoMock = new Mock<IRepository<Book>>();
            repoMock.Setup(r => r.AddAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            repoMock.Setup(r => r.SaveAsync()).Returns(Task.CompletedTask);

            var bookService = new BookService(repoMock.Object, _mapper);

            var bookDto = new BookDTO("1", "Test Title", "Test Author", "123456", DateTime.Today);

            // Act
            var result = await bookService.CreateBookAsync(bookDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.Equals(bookDto.Title, result.Title);
            Assert.Equals(bookDto.Author, result.Author);
        }
    }
}
*/