using System;
using System.Collections.Generic;
using System.Text.Json;
using BookStore.AppData.Models;

namespace BookStore.AppData.Entities
{
    public class Order
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Basket> Products { get; set; } = new List<Basket>();

        public User Customer { get; set; }

        public DateTime DateOfCompletion { get; private set; } = DateTime.Today.AddDays(3);

        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            Completed,
            InProcess
        }
    }
}
