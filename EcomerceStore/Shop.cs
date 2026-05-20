using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace EcomerceStore
{
    internal class Shop
    {
        public List<Product> Products { get; } = new List<Product>();
        public List<Order> Orders { get; } = new List<Order>();
        public List<User> Users { get; } = new List<User>();

        public void RegisterUser(User user)
        {
            Users.Add(user);
            Console.WriteLine($"{user.FirstName} {user.LastName} has been added.");
        }

        public void Login(string email, string password)
        {
            var user = Users.Find(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"Welcome back, {user.FirstName}!");
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"{product.Name} has been added to the shop.");
        }

        public void ShowProducts()
        {
            Console.WriteLine("Available products:");
            foreach (var product in Products)
            {
                Console.WriteLine($"- {product.Name}: ${product.Price}");
            }
        }

        public void SearchProductByName(string name)
        {
            var product = Products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.WriteLine($"Product found: {product.Name} - ${product.Price}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void ShowProductsByCategory(string category)
        {
            var productsInCategory = Products.FindAll(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (productsInCategory.Count > 0)
            {
                Console.WriteLine($"Products in category '{category}':");
                foreach (var product in productsInCategory)
                {
                    Console.WriteLine($"- {product.Name}: ${product.Price}");
                }
            }
            else
            {
                Console.WriteLine($"No products found in category '{category}'.");
            }
        }
    }
}
