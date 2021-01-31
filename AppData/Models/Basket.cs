using System;
using BookStore.AppData.Entities;

namespace BookStore.AppData.Models
{
    public class Basket
    {
        public int Count { get; set; }

        public Product Product { get; set; }
    }
}
