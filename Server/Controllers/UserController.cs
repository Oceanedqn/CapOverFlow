using CapOverFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;

namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<UserDto> usersList = new List<UserDto>();
        [HttpGet]
        public List<UserDto> GetUsers()
        {
            List<UserDto> users = new List<UserDto>
            {
                new UserDto{ UsrId=1, UsrLastname = "Duquenne", UsrFirstname="Oceane", UsrMail="ocefrfane.dqn@gmfrfail.com", UsrExperience=0 },
            };
            usersList = users;
            return users;
        }
    }
}
