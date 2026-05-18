using System;
using System.Collections.Generic;
using System.Text;

namespace EcomerceStore
{
    internal class CartItem
    {
        public List<Product> Products { get; } = new List<Product>();
        public int Quantity { get; private set; }


    }
}
