using Microsoft.AspNetCore.Mvc;
using System;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;
using Zignificant.Repository;

namespace Zignificant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdateController : ControllerBase
    {
        private IBirthdateRepository _birthdateRepository;

        [HttpPut("{birthDateId:int}")]
        public IActionResult UpdateBirtdate([FromRoute] int birthDateId, [FromBody] BirthdateUpdateRequest req)
        {
            try
            {
                _birthdateRepository.Update(req);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public IActionResult CreateBirthDate([FromBody] BirthdateCreateRequest req)
        {
            BirthdateResponse resp = _birthdateRepository.Create(req);
            return CreatedAtAction("GetBirthDateById", new { birthDateId = resp.Id}, resp);
        }

        [HttpDelete("{birthDateId:int}")]
        public IActionResult DeleteBirthdateById([FromRoute] int birthDateId)
        {
            try
            {
                _birthdateRepository.Delete(birthDateId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{birthDateId:int}", Name = "GetBirthDateById")]
        public IActionResult GetBirthDateById([FromRoute] int birthDateId)
        {
            try
            {
                var bday = _birthdateRepository.GetRecordById(birthDateId);
                return Ok(bday);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public IActionResult GetAllBirthdates()
        {
            try
            {
                var bdays = _birthdateRepository.GetAll();
                return Ok(bdays);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        public BirthdateController(IBirthdateRepository birthdateRepository)
        {
            _birthdateRepository = birthdateRepository;
        }
    }
}
