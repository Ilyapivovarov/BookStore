using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.AppData;
using BookStore.AppData.Entities;
using BookStore.AppData.Models;
using BookStore.Auth.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static BookStore.AppData.Entities.User;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationContext DataBase { get; set; }
        private IOptions<AuthOptions> AuthOptions { get; set; }

        public AuthController(ApplicationContext context, IOptions<AuthOptions> authOptions)
        {
            DataBase = context;
            AuthOptions = authOptions;
            
            if (!DataBase.Users.Any())
            {
                DataBase.Users.Add(new User
                {
                    Email = "admin@mail.com",
                    FirstName = "Ad",
                    LastName = "Min",
                    Password = "admin@mail.com",
                    Roles = new Role[] { Role.Admin }
                });
                
                DataBase.Users.Add(new User
                {
                    Email = "user@mail.com",
                    FirstName = "Us",
                    LastName = "Er",
                    Password = "user@mail.com",
                    Roles = new Role[] { Role.User }
                });
                DataBase.SaveChanges();
            }
          

        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = GenerateJwt(user);

                return Ok(new
                {
                    access_token = token,
                });
            }

            return Unauthorized();
        }

        private User AuthenticateUser(string email, string password)
        {
            var user = DataBase.Users.Single(u => u.Email == email && u.Password == password);
            return user;
        }

        private string GenerateJwt(User user)
        {
            var authParams = AuthOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("fullName", user.FirstName + " " + user.LastName),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
