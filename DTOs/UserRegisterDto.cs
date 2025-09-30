using System.ComponentModel.DataAnnotations;

namespace FullstackAssignment.DTOs;

public class UserRegisterDto
{
    public required string Username { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }
}