using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.AppData.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public int UserId { get; set; }

    }
}
