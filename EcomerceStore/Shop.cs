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

        public void AddProductToCart(User user, Product product, int quantity)
        {
            var cartItem = new CartItem();
            cartItem.Products.Add(product);
            cartItem.Quantity = quantity;
            user.Cart.Add(cartItem);
            Console.WriteLine($"{quantity} x {product.Name} has been added to {user.FirstName}'s cart.");
        }

        public void RemoveProductFromCart(User user, Product product)
        {
            var cartItem = user.Cart.Find(ci => ci.Products.Contains(product));
            if (cartItem != null)
            {
                user.Cart.Remove(cartItem);
                Console.WriteLine($"{product.Name} has been removed from {user.FirstName}'s cart.");
            }
            else
            {
                Console.WriteLine($"{product.Name} is not in {user.FirstName}'s cart.");
            }
        }

        public void Checkout(User user)
        {
            if (user.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }
            decimal total = 0;
            foreach (var cartItem in user.Cart)
            {
                foreach (var product in cartItem.Products)
                {
                    total += product.Price * cartItem.Quantity;
                }
            }
            var order = new Order();
            user.Orders.Add(order);
            Orders.Add(order);
            user.Cart.Clear();
            Console.WriteLine($"Checkout complete! Total amount: ${total}");
        }

        public void ShowUserOrders(User user)
        {
            if (user.Orders.Count == 0)
            {
                Console.WriteLine($"{user.FirstName} has no orders.");
                return;
            }
            Console.WriteLine($"{user.FirstName}'s Orders:");
            foreach (var order in user.Orders)
            {
                Console.WriteLine($"- Order ID: {order.GetHashCode()}");
            }
        }
    }
}
