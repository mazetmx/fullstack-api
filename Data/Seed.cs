using FullstackAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace FullstackAssignment.Data;

public class Seed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new DataContext(
            serviceProvider.GetRequiredService<DbContextOptions<DataContext>>());

        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Username = "Mazen",
                Email = "mazen@mail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd"),
            });
            context.SaveChanges();
        }

        if (context.Products.Any())
        {
            return;
        }

        var products = new List<Product>
            {
                new Product
                {
                    Category = "Electronics",
                    Name = "Wireless Bluetooth Headphones",
                    Price = 99.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 15,
                    ImageUrl = "https://picsum.photos/300/200?random=1",
                },
                new Product
                {
                    Category = "Electronics",
                    Name = "Smartphone",
                    Price = 699.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 10,
                    ImageUrl = "https://picsum.photos/300/200?random=2",
                },
                new Product
                {
                    Category = "Books",
                    Name = "Angular Development Guide",
                    Price = 29.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 0,
                    ImageUrl = "https://picsum.photos/300/200?random=3",
                },
                new Product
                {
                    Category = "Home & Garden",
                    Name = "Coffee Maker",
                    Price = 49.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 20,
                    ImageUrl = "https://picsum.photos/300/200?random=4",
                },
                new Product
                {
                    Category = "Clothing",
                    Name = "Cotton T-Shirt",
                    Price = 19.99m,
                    MinimumQuantity = 2,
                    DiscountRange = 5,
                    ImageUrl = "https://picsum.photos/300/200?random=5",
                },
                new Product
                {
                    Category = "Sports",
                    Name = "Yoga Mat",
                    Price = 34.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 0,
                    ImageUrl = "https://picsum.photos/300/200?random=6",
                },
                new Product
                {
                    Category = "Electronics",
                    Name = "Laptop Stand",
                    Price = 39.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 25,
                    ImageUrl = "https://picsum.photos/300/200?random=7",
                },
                new Product
                {
                    Category = "Home & Garden",
                    Name = "Desk Lamp",
                    Price = 24.99m,
                    MinimumQuantity = 1,
                    DiscountRange = 0,
                    ImageUrl = "https://picsum.photos/300/200?random=8",
                }
            };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
