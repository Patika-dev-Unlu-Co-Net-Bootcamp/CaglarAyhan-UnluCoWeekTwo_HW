using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetAllUsers()
        {
            _userRepository.GetAll();
            return Ok();
        }
        [HttpPost("NewUser")]
        public IActionResult AddUser([FromBody]User user)
        {
            if (_userRepository.Create(user))
            {
                return Ok();
            }
            return BadRequest();
            
        }
       
    }
}
