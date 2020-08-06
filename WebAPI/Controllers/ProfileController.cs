using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileManager _profileManager;
        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }
        [HttpPost("add")]
        public IActionResult Add(Profile profile)
        {
            profile.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _profileManager.Add(profile);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Profile profile)
        {
            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            profile.Id = id;
            profile.UserId = currentId;

            var result = _profileManager.Update(profile,currentId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}