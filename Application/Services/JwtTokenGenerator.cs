﻿using Application.Contracts.Services;
using Azure.Messaging;
using Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            try
            {

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {

                    //new(JwtRegisteredClaimNames.Sub, user.LoginName),
                    //new(ClaimTypes.NameIdentifier, user.EmployeeId),
                    //new(ClaimTypes.Role, user.Role.RoleName),
                    new Claim ("EmployeeID",user.EmployeeId),
                    new Claim ("LoginName",user.LoginName),
                    new Claim ("Name",user.FirstName + " " + user.LastName),
                    new Claim ("Role",user.Role.RoleName),
                    new Claim ("LoginDateTime", DateTime.Now.ToString("hh:mm tt")),

                };

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while generating the token.", ex);
            }


        }
    }

}
