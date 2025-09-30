using FullstackAssignment.DTOs;
using FullstackAssignment.Models;
using FullstackAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackAssignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(DataContext context, JwtService jwtService) : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        if (await context.Users.AnyAsync(u => u.Username == dto.Username))
        {
            return BadRequest("This username is taken");
        }

        if (await context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return BadRequest("This email is taken");
        }

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        var token = jwtService.GenerateToken(user);

        return Ok(new {username = user.Username, token});
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password");
        }

        user.LastLogin = DateTime.UtcNow;
        await context.SaveChangesAsync();

        var token = jwtService.GenerateToken(user);

        return Ok(new {username = user.Username, token});
    }
}