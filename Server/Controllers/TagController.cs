﻿using System;
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
    public class TagController : ControllerBase
    {
        private readonly DataContext _context;
        public TagController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<TagDto>> GetDbTags()
        {
            return await _context.Tag
                .Include(ct => ct.Categories)
                .Include(ic => ic.Includes)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return base.Ok(await GetDbTags());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _context.Tag
                .Include(ct => ct.Categories)
                .Include(ic => ic.Includes)
                .FirstOrDefaultAsync(h => h.TAG_id == id);
            if (tag == null)
                return NotFound("Super Hero wasn't found.");
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagDto tag)
        {
            _context.Tag.Add(tag);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTags());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(TagDto tag)
        {
            var dbTag = await _context.Tag
                .Include(ct => ct.Categories)
                .FirstOrDefaultAsync(h => h.TAG_id == tag.TAG_id);
            if (dbTag == null)
                return NotFound("Super Hero wasn't found.");

            dbTag.TAG_name = tag.TAG_name;
            dbTag.CTG_id = tag.CTG_id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbTags());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var dbTag = await _context.Tag
                .Include(ct => ct.Categories)
                .FirstOrDefaultAsync(h => h.TAG_id == id);
            if (dbTag == null)
                return NotFound("Super Hero wasn't found.");

            _context.Tag.Remove(dbTag);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTags());
        }

    }
}
