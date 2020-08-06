using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.Results;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyManager _companyManager;
        private IMapper _mapper;

        public CompanyController(ICompanyManager companyManager, IMapper mapper)
        {
            _companyManager = companyManager;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var company =_companyManager.GetAll();
            var result = _mapper.Map<List<CompanyListDto>>(company.Data);

            if (company.Success)
            {
                return Ok(result);
            }

            return BadRequest(company.Message);

        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm]Company company, [FromForm]IFormFile file)
        {
            company.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (file != null)
            {
                company.Logo = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            var result = _companyManager.Add(company);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var company = _companyManager.GetById(id);

            var result = _mapper.Map<List<CompanyListDto>>(company.Data);

            if (company.Success)
            {
                return Ok(result);
            }
            return BadRequest(company.Message);
        }
    }
}