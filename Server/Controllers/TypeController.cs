using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared.Dto;
using CapOverFlow.Server.Data;

namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        List<TypeDto> typList = new List<TypeDto>();

        [HttpGet]
        public List<TypeDto> GetTypes()
        {
            List<TypeDto> types = new List<TypeDto>
            {
                new TypeDto{ TypId=1, TypName="question" },
                new TypeDto{ TypId=2, TypName="reponse" },
                new TypeDto{ TypId=3, TypName="biblio" },

            };
            typList = types;
            return typList;
        }


    }
}
