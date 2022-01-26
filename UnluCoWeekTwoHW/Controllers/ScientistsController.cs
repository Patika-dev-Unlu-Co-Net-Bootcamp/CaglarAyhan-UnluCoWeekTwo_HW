using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;
using UnluCoWeekTwoHW.Repositories.Abstract;
using UnluCoWeekTwoHW.Repositories.Concrete;

namespace UnluCoWeekTwoHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScientistsController : ControllerBase
    {
        private readonly IScientistRepository _scientistRepository;
        public ScientistsController(IScientistRepository scientistRepository)
        {
            _scientistRepository = scientistRepository;
        }     
        [HttpGet("getAllScientists")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public  ActionResult<IEnumerable<Scientist>> GetAll()
        {
            var scientistList = _scientistRepository.GetAll();
            if (scientistList != null && scientistList.Any())
            {
                return Ok(scientistList);
            }
            return StatusCode(204);
            
        }
        [HttpGet("getScientist/{id}")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetById(object id)
        {
            var scientistList = _scientistRepository.GetById(id);
            if (scientistList != null && scientistList.Any())
            {
                return Ok(scientistList);
            }
            return StatusCode(204);
        }
        [HttpGet("getScientists/{name}")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetByName(string name)
        {
            var scientistList = _scientistRepository.GetByName(name);
            if (scientistList != null && scientistList.Any())
            {
                return Ok(scientistList);
            }
            return StatusCode(204);
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Created(Scientist scientist)
        {
            _scientistRepository.Create(scientist);
            return Ok(_scientistRepository);
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteById(int id)
        {
            _scientistRepository.Delete(id);

            return Ok();
        }
        [HttpPatch("UpdateStatus")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult ChangeStatus(int id)
        {
            _scientistRepository.ChangeStatus(id);
            return Ok();
        }
        [HttpPut("UpdateScientist")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotModified)]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] Scientist scientist)
        {
            _scientistRepository.Update(scientist);
            return Ok();
        }
    }
}
