using System.ComponentModel.DataAnnotations;

namespace FullstackAssignment.Models;

public class Product
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Category { get; set; }

    [Range(1, double.MaxValue)]
    public required decimal Price { get; set; }

    [Range(1, int.MaxValue)]
    public required int MinimumQuantity { get; set; }

    [Range(1, 100)]
    public decimal DiscountRange { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}