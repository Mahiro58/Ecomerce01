using System;
using System.Collections.Generic;
using System.Text;

namespace EcomerceStore
{
    internal class Product
    {
        public long Id { get; }
        public string Name { get; }
        public decimal Price { get; private set; }
        public Category Category { get; }
        public int StockQuantity { get; private set; }

        public Product(long id, string name, decimal price, Category category, int stockQuantity)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be negative or zero.", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }
            if (stockQuantity < 0)
            {
                throw new ArgumentException("Stock quantity cannot be negative.", nameof(stockQuantity));
            }

            Id = id;
            Name = name;
            Price = price;
            Category = category;
            StockQuantity = stockQuantity;
        }

        public void DecreasStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            if (quantity > StockQuantity)
            {
                throw new InvalidOperationException("Not enough stock available.");
            }
            StockQuantity -= quantity;
        }

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            StockQuantity += quantity;
        }
    }
}
