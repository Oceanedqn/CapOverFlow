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
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;
        public CommentController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<CommentDto>> GetDbResponses()
        {
            List<CommentDto> comments = await _context.CommentsDb.ToListAsync();
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();

            foreach(var comment in comments)
            {
                comment.Pbc = publications.FirstOrDefault(h => h.PbcId == comment.PbcId);
            }
            return comments;
        }

        private async Task<List<CommentDto>> GetResponseById(int idPubli)
        {
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();
            List<CommentDto> responses = new List<CommentDto>();
            List<CommentDto> comments = await _context.CommentsDb.ToListAsync();

            foreach(var comment in comments)
            {
                if(comment.PbcId == idPubli)
                {
                    comment.Pbc = publications.FirstOrDefault(h => h.PbcId == comment.PbcId);
                    responses.Add(comment);
                }
            }
            return responses;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponses()
        {
            return base.Ok(await GetDbResponses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponse(int idPubli)
        {
            var responses = await GetResponseById(idPubli);
            return Ok(responses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResponse(CommentDto response)
        {
            _context.CommentsDb.Add(response);
            await _context.SaveChangesAsync();

            return Ok(await GetResponseById(response.CmtId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            var dbResponse = await _context.CommentsDb.FirstOrDefaultAsync(h => h.CmtId == id);
            _context.CommentsDb.Remove(dbResponse);

            var dbPublication = await _context.PublicationsDb.FirstOrDefaultAsync(h => h.PbcId == dbResponse.PbcId);
            _context.PublicationsDb.Remove(dbPublication);

            await _context.SaveChangesAsync();
            return Ok(await GetDbResponses());
        }


    }
}
