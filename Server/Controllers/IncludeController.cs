using CapOverFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncludeController : ControllerBase
    {

        private readonly DataContext _context;
        public IncludeController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetIncludes()
        {
            return Ok(await _context.Includes.ToListAsync());
        }
    }

    
}
