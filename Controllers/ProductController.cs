using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.AppData;
using BookStore.AppData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ApplicationContext DataBase { get; set; }

        public ProductController(ApplicationContext context)
        {
            DataBase = context;

            if (!DataBase.Products.Any())
            {
                DataBase.Products.Add(new Product
                {
                    Name = "«Война и мир»",
                    Descriptoin =
                        "«Война и мир» Л. Н. Толстого — книга на все времена. Кажется, что она существовала всегда, настолько знакомым кажется текст, едва мы открываем первые страницы романа, настолько памятны многие его эпизоды: охота и святки, первый бал Наташи Ростовой, лунная ночь в Отрадном, князь Андрей в сражении при Аустерлице... Сцены «мирной», семейной жизни сменяются картинами, имеющими значение для хода всей мировой истории, но для Толстого они равноценны, связаны в едином потоке времени. Каждый эпизод важен не только для развития сюжета, но и как одно из бесчисленных проявлений жизни, которая насыщена в каждом своем моменте и которую учит любить Толстой.",
                    Count = 5,
                    Price = 250
                });
                DataBase.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = DataBase.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!DataBase.Products.Any(p => p.Id == id))
            {
                return NotFound();
            }

            var product = DataBase.Products.Single(p => p.Id == id);

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            DataBase.Add(product);

            DataBase.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Put([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!DataBase.Products.Contains(product))
            {
                return NotFound();
            }

            DataBase.Update(product);

            DataBase.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!DataBase.Products.Any(p => p.Id == id))
            {
                return NotFound();
            }

            var product = DataBase.Products.Single(p => p.Id == id);

            DataBase.Remove(product);
            DataBase.SaveChanges();

            return Ok(product);
        }
    }
}