using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Data.Services;
using LibraryManagementSystem.Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace LibraryManagementSystem.Tests.NewFolder
{
    public class BookServiceTests
    {
        private readonly IMapper _mapper;

        public BookServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CreateBookAsync_ReturnsCreatedBook()
        {
            var repoMock = new Mock<IRepository<Book>>();
            repoMock.Setup(r => r.AddAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            repoMock.Setup(r => r.SaveAsync()).Returns(Task.CompletedTask);

            var service = new BookService(repoMock.Object, _mapper);
            var dto = new BookDTO("Title", "Author", "ISBN", DateTime.Today);

            var result = await service.CreateBookAsync(dto);

            Assert.IsNotNull(result);
            Assert.Equals("Title", result.Title);
        }
    }
}
