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

        private async Task<List<PublicationDto>> GetDbPublications()
        {
            return await _context.Publication
                .Include(us => us.User)
                .Include(ty => ty.Type)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return base.Ok(await GetDbPublications());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _context.Publication
                .Include(us => us.User)
                .Include(ty => ty.Type)
                .FirstOrDefaultAsync(h => h.PBC_id == id);
            if (question == null)
                return NotFound("Question wasn't found.");
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(PublicationDto publication)
        {

            publication.PBC_resolved = false;
            publication.QST_date = DateTime.Now;
            publication.User.USR_id = 1;
            publication.Type.TYP_id = 1;

            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(PublicationDto publication)
        {
            var dbPubli = await _context.Publication
                .FirstOrDefaultAsync(h => h.PBC_id == publication.PBC_id);
            if (dbPubli == null)
                return NotFound("Question wasn't found.");

            dbPubli.PBC_title = publication.PBC_title;
            dbPubli.PBC_description = publication.PBC_description;
            dbPubli.PBC_resolved = publication.PBC_resolved;
            dbPubli.QST_date = DateTime.Now;
            dbPubli.Type.TYP_id = 1;
            dbPubli.User.USR_id = 1;

            await _context.SaveChangesAsync();

            return Ok(await GetDbPublications());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var dbHPubli = await _context.Publication
                .FirstOrDefaultAsync(h => h.PBC_id == id);
            if (dbHPubli == null)
                return NotFound("Question wasn't found.");

            _context.Publication.Remove(dbHPubli);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }


    }
}
