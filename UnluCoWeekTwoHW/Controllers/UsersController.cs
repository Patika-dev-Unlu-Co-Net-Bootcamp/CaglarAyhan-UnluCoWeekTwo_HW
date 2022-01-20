using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Controllers
{
    public class UsersController : ControllerBase
    {
        [HttpGet("AllUser")]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }
       
    }
}
