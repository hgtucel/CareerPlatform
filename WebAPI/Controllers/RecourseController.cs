using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecourseController : ControllerBase
    {
        private IRecourseManager _recourseManager;
        private IMapper _mapper;

        public RecourseController(IRecourseManager recourseManager, IMapper mapper)
        {
            _recourseManager = recourseManager;
            _mapper = mapper;
        }

        [HttpPost("{paramsId}")]
        public IActionResult Add([FromRoute] int paramsId, Recourse recourse)
        {
            recourse.RecourseDate = DateTime.Now;
            recourse.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            recourse.AdvertId = paramsId;
            var result = _recourseManager.Add(recourse, int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUser(int userId)
        {
           var resourceUsers = _recourseManager.GetByUserRecourse(userId);

            var result = _mapper.Map<List<RecourseUserListDto>>(resourceUsers.Data);

            if (resourceUsers.Success)
            {
                return Ok(result);
            }

            return BadRequest(resourceUsers.Message);
        }
    }
}