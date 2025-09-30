namespace FullstackAssignment.DTOs;

public class ProductEditDto
{
    public string? Name { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? MinimumQuantity { get; set; }

    public decimal? DiscountRange { get; set; }
}