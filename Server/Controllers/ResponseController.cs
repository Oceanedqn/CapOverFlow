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
    public class ResponseController : ControllerBase
    {
        private readonly DataContext _context;
        public ResponseController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<PublicationDto>> GetDbResponses()
        {
            List<ResponseDto> responses = await _context.ResponsesDb.ToListAsync();
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();
            List<PublicationDto> publicationsSelect = new List<PublicationDto>();

            foreach(var response in responses)
            {
                publicationsSelect.Add(publications.Find(h => h.PbcId == response.RspPubliId));
            }
            return publicationsSelect;
        }

        private async Task<List<PublicationDto>> GetResponseById(int idPubli)
        {            
            List<ResponseDto> responsesSelect = new List<ResponseDto>();
            List<PublicationDto> publicationsSelect = new List<PublicationDto>();

            List<ResponseDto> reponses = await _context.ResponsesDb.ToListAsync();
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();
            
            foreach (var response in reponses)
            {
                if (response.PbcId == idPubli)
                {
                    responsesSelect.Add(response);
                }
            }
           
            foreach(var rep in responsesSelect)
            {
                publicationsSelect.Add(publications.Find(h => h.PbcId == rep.RspPubliId));
            }

            return publicationsSelect;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponses()
        {
            return base.Ok(await GetDbResponses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponse(int id)
        {
            var responses = await GetResponseById(id);
            return Ok(responses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResponse(ResponseDto response)
        {
            _context.ResponsesDb.Add(response);
            await _context.SaveChangesAsync();

            return Ok(await GetResponseById(response.RspId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            var dbResponse = await _context.ResponsesDb.FirstOrDefaultAsync(h => h.RspId == id);
            _context.ResponsesDb.Remove(dbResponse);

            var dbPublication = await _context.PublicationsDb.FirstOrDefaultAsync(h => h.PbcId == dbResponse.PbcId);
            _context.PublicationsDb.Remove(dbPublication);

            await _context.SaveChangesAsync();
            return Ok(await GetDbResponses());
        }


    }
}
