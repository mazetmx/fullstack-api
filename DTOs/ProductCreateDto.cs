namespace FullstackAssignment.DTOs;

public class ProductCreateDto
{
    public required string Name { get; set; }

    public required string Category { get; set; }

    public required decimal Price { get; set; }

    public required int MinimumQuantity { get; set; }

    public decimal DiscountRange { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}