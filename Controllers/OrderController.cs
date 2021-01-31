﻿using System;
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
            UpdateOrders();

        }

        [HttpGet]
        public IActionResult Get()
        {
            var orderCurUser = DataBase.Orders.Where(o => o.Customer.Id == UserId).ToList();
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
                .Where(o => o.Customer.Id == UserId && o.Id == id)
                .ToList();

            return Ok(ordersCurUser);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Basket[] basket)
        {
            if (basket == null)
            {
                return BadRequest();
            }
            if (!basket.Any())
            {
                return NoContent();
            }

            // var curUser = DataBase.Users.Single(u => u.Id == UserId);
            //
            // var order = new Order
            // {
            //     Name = "Заказ №" + UserId.ToString() + "-" + DateTime.UtcNow.Ticks.ToString(),
            //     Status = Order.OrderStatus.InProcess,
            //     Customer = curUser
            // };

            // foreach (var item in basket)
            // {
            //     order.Products.Add(new Basket {Count = item.Count, Product = item.Product});
            // }
            
            
            return Ok(basket.ToString());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!DataBase.Orders.Any(o => o.Id == id))
            {
                return NotFound();
            }

            var order = DataBase.Orders.Single(o => o.Id == id);

            DataBase.Remove(order);
            await DataBase.SaveChangesAsync();

            return Ok();
        }

        private async void UpdateOrders()
        {
            var orders = DataBase.Orders.Where(o => o.DateOfCompletion < DateTime.Today).ToList();
            foreach (var order in DataBase.Orders)
            {
                order.Status = Order.OrderStatus.Completed;
            }

            await DataBase.SaveChangesAsync();
        }
    }
}