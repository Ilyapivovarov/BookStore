﻿using System;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ApplicationContext DataBase { get; set; }
        public IOptions<AuthOptions> AuthOptions { get; set; }

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
                    Password = "admin@mail.com"
                });
            }

            DataBase.SaveChanges();

        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);

                DataBase.Sessions.Add(new Session { Token = token, UserId = user.Id });

                DataBase.SaveChangesAsync();

                return Ok(new
                {
                    access_token = token,
                });
            }

            return Unauthorized();
        }

        [Route("profile/{token}")]
        [HttpGet]
        public IActionResult GetProfile(string token)
        {
            if (token == null)
            {
                return BadRequest();
            }

            var session = DataBase.Sessions.Single(u => u.Token == token);

            var curUser = DataBase.Users.Single(u => u.Id == session.UserId);

            return Ok(new Profile
            {
                Id = curUser.Id,
                Email = curUser.Email,
                FirstName = curUser.FirstName,
                LastName = curUser.LastName
            });
        }

        private User AuthenticateUser(string email, string password)
        {
            var user = DataBase.Users.Single(u => u.Email == email && u.Password == password);

            return user;
        }

        private string GenerateJWT(User user)
        {
            var authParams = AuthOptions.Value;

            var securityKey = authParams.GetSemmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.FirstName + " " + user.LastName)
            };

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