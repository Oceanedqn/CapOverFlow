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
    public class TagController : ControllerBase
    {
        private readonly DataContext _context;
        public TagController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<TagDto>> GetDbTags()
        {
            return await _context.TagsDb
                .Include(ct => ct.Ctg)
                .Include(pb => pb.PublicationPbcs)
                .ToListAsync();
        }

        private async Task<TagDto> GetTagById(int id)
        {
            var tag = await _context.TagsDb
                .Include(ct => ct.Ctg)
                .Include(pb => pb.PublicationPbcs)
                .FirstOrDefaultAsync(h => h.TagId == id);
            return tag;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return base.Ok(await GetDbTags());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await GetTagById(id);
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagDto tag)
        {
            _context.TagsDb.Add(tag);
            await _context.SaveChangesAsync();

            return Ok(await GetTagById(tag.TagId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(TagDto tag, int id)
        {
            var dbTag = await _context.TagsDb
                .FirstOrDefaultAsync(h => h.TagId == id);
          
            dbTag.TagName = tag.TagName;
            dbTag.CtgId = tag.CtgId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbTags());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var dbTag = await _context.TagsDb
                .FirstOrDefaultAsync(h => h.TagId == id);

            _context.TagsDb.Remove(dbTag);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTags());
        }

    }
}
