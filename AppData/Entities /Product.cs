using System;
namespace BookStore.AppData.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descriptoin { get; set; }

        public float Price { get; set; }
        
        public int Count { get; set; } = 0;
    }
}
