using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Data.Persistence;
using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Services
{
    public class AuthService : IAuthService
{
    private readonly AppDbContext _ctx;
    private readonly IJwtService _jwt;

    public AuthService(AppDbContext ctx, IJwtService jwt)
    {
        _ctx = ctx;
        _jwt = jwt;
    }

    public async Task RegisterAsync(RegisterDTO dto)
    {
        if (await _ctx.Users.AnyAsync(u => u.Username == dto.Username))
            throw new ArgumentException("Username already exists");

        using var hmac = new HMACSHA512();
        var user = new User
        {
            Username = dto.Username,
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password))
        };

        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(LoginDTO dto)
    {
        var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Username == dto.Username);
        if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
        if (!hash.SequenceEqual(user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        return _jwt.GenerateToken(user.Id, user.Username);
    }
}
}
