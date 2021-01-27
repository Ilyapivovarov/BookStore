using System;
using System.Collections.Generic;

namespace BookStore.AppData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public User Customer { get; set; }
    }
}
