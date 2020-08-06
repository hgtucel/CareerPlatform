using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        private IProfileManager _profileManager;

        public UserController(IUserManager userManager, IProfileManager profileManager)
        {
            _userManager = userManager;
            _profileManager = profileManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userManager.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("profile")]
        public IActionResult AddProfile(Profile profile)
        {
            profile.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _profileManager.Add(profile);
            
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
    }
}