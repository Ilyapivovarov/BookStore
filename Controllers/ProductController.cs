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
        public ApplicationContext DataBase { get; set; }

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value); 

        public ProductController(ApplicationContext context)
        {
            DataBase = context;

            if (!DataBase.Products.Any())
            {
                DataBase.Products.Add(new Product { Name = "test", Descriptoin = "asd" });

                DataBase.SaveChanges();
            }
        }
        // GET: api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(UserId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
