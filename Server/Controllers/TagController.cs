using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared;
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


        private async Task<List<TagsDto>> GetDbTags()
        {
            return await _context.Tags.ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return Ok(await GetDbTags());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _context.Tags
                .FirstOrDefaultAsync(h => h.TAG_id == id);
            if (tag == null)
                return NotFound("Super Hero wasn't found.");
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagsDto tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTags());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(TagsDto tag, int id)
        {
            var dbTag = await _context.Tags
                .FirstOrDefaultAsync(h => h.TAG_id == id);
            if (dbTag == null)
                return NotFound("Super Hero wasn't found.");

            dbTag.TAG_name = tag.TAG_name;
            dbTag.TAG_category = tag.TAG_category;

            await _context.SaveChangesAsync();

            return Ok(await GetDbTags());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var dbTag = await _context.Tags
                .FirstOrDefaultAsync(h => h.TAG_id == id);
            if (dbTag == null)
                return NotFound("Super Hero wasn't found.");

            _context.Tags.Remove(dbTag);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTags());
        }

    }
}
