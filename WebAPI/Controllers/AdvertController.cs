using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private IAdvertManager _advertManager;
        private IMapper _mapper;

        public AdvertController(IAdvertManager advertManager, IMapper mapper)
        {
            _advertManager = advertManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _advertManager.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var adverts = _advertManager.GetAll();

            var result = _mapper.Map<List<AdvertListDto>>(adverts.Data);

            if (adverts.Success)
            {
                return Ok(result);
            }
            return BadRequest(adverts.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Advert advert)
        {
            advert.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _advertManager.Add(advert);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, AdvertUpdateDto advertUpdateDto)
        {
            var advert = _advertManager.GetById(id);

            _mapper.Map(advertUpdateDto, advert.Data);

            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            advert.Data.UserId = currentId;
            var result = _advertManager.Update(advert.Data);

             if (result.Success)
             {
                return Ok(result.Message);
             }

             return BadRequest(result.Message);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var advert = _advertManager.GetById(id);

            var result = _advertManager.Delete(advert.Data);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string title)
        {
            var adverts = _advertManager.SearchByTitle(title);

            var result = _mapper.Map<List<AdvertListDto>>(adverts.Data);

            if (adverts.Success)
            {
                return Ok(result);
            }

            return BadRequest(adverts.Message);
        }

    }
}