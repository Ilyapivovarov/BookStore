using System;
using System.Collections.Generic;
using BookStore.AppData.Models;

namespace BookStore.AppData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Products { get; set; }

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
