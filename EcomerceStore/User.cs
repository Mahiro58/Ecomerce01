using System;
using System.Collections.Generic;
using System.Text;

namespace EcomerceStore
{
    internal class User
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; private set; }
        public List<Order> Orders { get; } = new List<Order>();
        public List<Cart> Cart { get; } = new List<Cart>();

        public User(long id, string firstName, string lastName, string email, string password)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be negative or zero.", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or whitespace.", nameof(lastName));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));
            }
            if (email.Contains("@") == false)
            {
                throw new ArgumentException("Email must contain '@' character.", nameof(email));
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

    }
}
