using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var userExists = _authManager.UserExists(userRegisterDto.Email);

            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var register = _authManager.Register(userRegisterDto, userRegisterDto.Password);

            var result = _authManager.CreateAccessToken(register.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var login = _authManager.Login(userLoginDto);
            if (!login.Success)
            {
                return BadRequest(login.Message);
            }

            var token = _authManager.CreateAccessToken(login.Data);

            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token.Message);

        }
    }
}