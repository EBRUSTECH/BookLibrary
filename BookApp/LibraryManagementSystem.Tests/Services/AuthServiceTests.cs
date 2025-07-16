using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Data.Persistence;
using LibraryManagementSystem.Data.Services;
using LibraryManagementSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace LibraryManagementSystem.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly AppDbContext _context;

        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestAuthDb")
                .Options;
            _context = new AppDbContext(options);
        }

        [Fact]
        public async Task RegisterAndLogin_ReturnsToken()
        {
            var jwtMock = new Mock<IJwtService>();
            jwtMock.Setup(j => j.GenerateToken(It.IsAny<string>(), It.IsAny<string>())).Returns("fake_token");

            var service = new AuthService(_context, jwtMock.Object);
            var registerDto = new RegisterDTO("testuser", "password123");

            await service.RegisterAsync(registerDto);
            var token = await service.LoginAsync(new LoginDTO("testuser", "password123"));

            Assert.Equals("fake_token", token);
        }
    }

}
