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

        private async Task<List<ResponseDto>> GetDbResponses()
        {
            List<ResponseDto> responses = await _context.ResponsesDb.ToListAsync();
            return responses;
        }

        private async Task<ResponseDto> GetDbResponseById(int id)
        {
            List<ResponseDto> responses = await _context.ResponsesDb.ToListAsync();
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();

            var reponse = responses.FirstOrDefault(h => h.RspId == id);
            reponse.Pbc = publications.FirstOrDefault(h => h.PbcId == reponse.RspPubliId);
            return reponse;
        }

        private async Task<List<ResponseDto>> GetDbResponsesById(int idPubli)
        {
            List<ResponseDto> responses = await _context.ResponsesDb.ToListAsync();
            List<ResponseDto> responsesList = new List<ResponseDto>();

            foreach(var resp in responses)
            {
                if(resp.PbcId == idPubli)
                {
                    responsesList.Add(resp);
                }
            }
            return responsesList;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponses()
        {
            return base.Ok(await GetDbResponses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPubliResponses(int id)
        {
            var responses = await GetDbResponsesById(id);
            return Ok(responses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResponse(ResponseDto response)
        {          
            _context.ResponsesDb.Add(response);
            await _context.SaveChangesAsync();

            return Ok(await GetDbResponseById(response.RspId));
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
