using System.ComponentModel.DataAnnotations;

namespace FullstackAssignment.Models;

public class User
{
    public int Id { get; set; }

    public required string Username { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public DateTime? LastLogin { get; set; }
}