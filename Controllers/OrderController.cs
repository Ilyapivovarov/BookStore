using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.AppData;
using BookStore.AppData.Entities;
using BookStore.AppData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : Controller
    {
        
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private ApplicationContext DataBase;

        public OrderController(ApplicationContext context)
        {
            DataBase = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orderCurUser = DataBase.Orders.Include(o => o.Products).Where(o => o.CustomerId == UserId).ToList();
            return Ok(orderCurUser);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!DataBase.Orders.Any(o => o.Id == id))
            {
                return NotFound();
            }

            var ordersCurUser = DataBase.Orders
                .Where(o => o.CustomerId == UserId && o.Id == id)
                .ToList();

            return Ok(ordersCurUser);
        }

        [HttpPost]
        public async Task<IActionResult>  CreateOrder([FromBody] Basket[] basket)
        {
            if (basket == null)
            {
                return BadRequest();
            }
            if (!basket.Any())
            {
                return NoContent();
            }
            var curUser = DataBase.Users.Single(u => u.Id == UserId);
            
            var order = new Order
            {
                Name = "Заказ №" + UserId.ToString() + "-" + DateTime.UtcNow.Ticks.ToString().Substring(4),
                Status = Order.OrderStatus.InProcess,
                CustomerId = curUser.Id
            };

            float totalPrice = 0;
            
            foreach (var item in basket)
            {
                var product = DataBase.Products.Single(p => p.Id == item.ProductId);
                product.Count = product.Count - item.Count;
                order.Products.Add(item);

                totalPrice += item.Count * product.Price;
            }

            order.TotalPrice = totalPrice;
            
            DataBase.Orders.Add(order);
            await DataBase.SaveChangesAsync();
            return Ok();
        }
    }
}
