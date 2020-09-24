using System.Text;
using System;
using System.ComponentModel;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Libreria.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Libreria.Dtos;
using AutoMapper;
using Libreria.Models;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController: ControllerBase
    {
        private readonly ILibreria _libreria;
        private readonly IMapper _mapper;

        public TokenController(ILibreria libreria, IMapper mapper)
        {
            _libreria = libreria;
            _mapper = mapper;
        }
        //POST api/token
        [HttpPost]
        public IActionResult Create (UserReadDTO userReadDTO)
        {
            var userModel = _mapper.Map<User>(userReadDTO);
            if (_libreria.ValidUser(userModel))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.Email),
                    new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
                };

                var token = new JwtSecurityToken(
                    new JwtHeader(
                        new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PalabraSecretaMuyLarga")),
                            SecurityAlgorithms.HmacSha256
                        )
                    ),
                    new JwtPayload(claims)
                );

                    var output = new {
                    Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Email = userModel.Email
                };

                return Ok(output);
            }
            else{
                return BadRequest();
            }
        }
    }
}