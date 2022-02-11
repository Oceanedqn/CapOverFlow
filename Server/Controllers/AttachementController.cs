using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared.Models;
using CapOverFlow.Server.Data;

namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachementController : ControllerBase
    {

        private readonly DataContext _context;
        public AttachementController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttachements()
        {
            return Ok(await _context.Attachements.ToListAsync());
        }


    }
}
