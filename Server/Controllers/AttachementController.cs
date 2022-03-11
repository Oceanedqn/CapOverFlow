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
    public class AttachementController : ControllerBase
    {

        private readonly DataContext _context;
        public AttachementController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<AttachementDto>> GetDbAttachements()
        {
            List<AttachementDto> attachements = await _context.AttachementsDb.ToListAsync();
            return attachements;
        }

        private async Task<AttachementDto> GetAttachementById(int id)
        {
            var attachement = await _context.AttachementsDb.FirstOrDefaultAsync(h => h.AtcId == id);
            return attachement;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttachements()
        {
            return base.Ok(await GetAttachements());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttachement(int id)
        {
            var attachement = await GetAttachementById(id);
            return Ok(attachement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttachement(AttachementDto attachement, int id)
        {
            var dbAttachement = await _context.AttachementsDb.FirstOrDefaultAsync(h => h.AtcId == id);

            dbAttachement.AtcName = attachement.AtcName;
            dbAttachement.AtcContent = attachement.AtcContent;
            dbAttachement.AtcDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(await GetDbAttachements());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachement(int id)
        {
            var dbAttachement = await _context.AttachementsDb.FirstOrDefaultAsync(h => h.AtcId == id);

            _context.AttachementsDb.Remove(dbAttachement);
            await _context.SaveChangesAsync();
            return Ok(await GetDbAttachements());
        }

    }
}
