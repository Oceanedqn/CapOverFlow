using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Models;
using CapOverFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly DataContext _context;
        public PublicationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublications()
        {
            return Ok(await _context.Publications.ToListAsync());
        }
    }
}
