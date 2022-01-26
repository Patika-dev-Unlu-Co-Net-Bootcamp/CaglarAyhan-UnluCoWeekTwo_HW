using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;
using UnluCoWeekTwoHW.Repositories.Abstract;

namespace UnluCoWeekTwoHW.Controllers
{
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("AllUser")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetAllUsers()
        {
            _userRepository.GetAll();
            return Ok();
        }
        [HttpPost("NewUser")]
        [ProducesResponseType(typeof(Scientist), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult AddUser([FromBody]User user)
        {
            var users = _userRepository.Create(user);
            if (users)
            {
                return Ok();
            }
            return BadRequest();      
        }
       
    }
}
