using System;
using System.Collections.Generic;
using BookStore.AppData.Models;

namespace BookStore.AppData.Entities
{
    public class Order
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Basket> Products { get; } = new List<Basket>();
        
        public int CustomerId { get; set; }

        public DateTime CreationDate { get; } = DateTime.Now;

        public DateTime DateOfCompletion { get; } = DateTime.Now.AddDays(3);

        public float TotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            Completed,
            InProcess
        }
    }
}
