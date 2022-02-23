﻿using CapOverFlow.Server.Data;
using CapOverFlow.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        private async Task<List<IncludeDto>> GetDbIncludes()
        {
            return await _context.Include
                .Include(pb => pb.Publication)
                .Include(tg => tg.Tag)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetIncludes()
        {
            return base.Ok(await GetDbIncludes());
        }

        [HttpPost]
        public async Task<IActionResult> CreateInclude(IncludeDto include)
        {
            _context.Include.Add(include);
            await _context.SaveChangesAsync();

            return Ok(await GetDbIncludes());
        }
    }
}
