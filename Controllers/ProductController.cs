using System.Linq;
using System.Threading.Tasks;
using BookStore.AppData;
using BookStore.AppData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                DataBase.Products.AddRange(
                    new Product
                    {
                        Name = "Война и мир",
                        Descriptoin =
                            "«Война и мир» Л. Н. Толстого — книга на все времена. Кажется, что она существовала всегда, настолько " +
                            "знакомым кажется текст, едва мы открываем первые страницы романа, настолько памятны многие его эпизоды: " +
                            "охота и святки, первый бал Наташи Ростовой, лунная ночь в Отрадном, князь Андрей в сражении при Аустерлице... " +
                            "Сцены «мирной», семейной жизни сменяются картинами, имеющими значение для хода всей мировой истории, но для Толстого они " +
                            "равноценны, связаны в едином потоке времени. Каждый эпизод важен не только для развития сюжета, но и как одно из " +
                            "бесчисленных проявлений жизни, которая насыщена в каждом своем моменте и которую учит любить Толстой.",
                        Count = 5,
                        Price = 250
                    },
                    new Product()
                    {
                        Name = "Вино из одуванчиков",
                        Descriptoin =
                            "Классический роман Брэдбери с автобиографической основой, вошедший в золотой фонд мировой литературы. " +
                            "Трогательная история о детстве и взрослении, мечтах и безграничных возможностях, юношеском максимализме, счастье, " +
                            "разрушительности войны, страхе потерять близких, дружбе, единении с сокровенным и о том: • почему взрослые и дети —" +
                            "два разных народа; • никому не важно, о чем говорят взрослые; • каждый человек для себя — один-единственный на свете.",
                        Count = 5,
                        Price = 800
                    }, 
                    new Product()
                    {
                        Name = "Гарри Поттер и Принц-полукровка",
                        Descriptoin = 
                            "Министерство магии терпит поражение за поражением в битвах с Волан-де-Мортом. Даже маглы страдают от второй войны - каждый" +
                            " день происходят катастрофы, причины которых никому не ведомы.  Но и на войне жизнь продолжается. Гарри, Рон и Гермиона," +
                            " как и все шестнадцатилетние, учатся, ходят на вечеринки и влюбляются. Однако опасность все ближе. Несмотря на все усилия" +
                            " Дамблдора по защите школы, в Хогвартсе происходят очень странные события. Омут памяти на этот раз откроет Гарри самую большую" +
                            " тайну Темного Лорда, и ради того, чтобы победить, Гарри вынужден пожертвовать самым дорогим... Какую сторону в этой войне примет" +
                            " загадочный Принц-полукровка?",
                        Count = 5,
                        Price = 1500
                    }
                    );
                DataBase.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = DataBase.Products.OrderBy(p => p.Name).ToList();
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
            return Ok(product);
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
        public async Task<IActionResult> Delete(int id)
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
            await DataBase.SaveChangesAsync();

            return Ok(product);
        }
    }
}