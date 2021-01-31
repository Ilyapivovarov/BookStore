using System;
using BookStore.AppData.Entities;

namespace BookStore.AppData.Models
{
    public class Basket
    {
        public int Id { get; set; }
        
        public int Count { get; set; }

        public int ProductId { get; set; }
    }
}
