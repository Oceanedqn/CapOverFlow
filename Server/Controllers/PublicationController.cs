using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;
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
            List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();
            List<TagDto> tags = await _context.TagsDb.ToListAsync();
            List<UserDto> users = await _context.UsersDb.ToListAsync();
            List<TypeDto> types = await _context.TypesDb.ToListAsync();
            List<CategoryDto> categories = await _context.CategoriesDb.ToListAsync();

            foreach(var tag in tags)
            {
                tag.Ctg = categories.FirstOrDefault(ca => ca.CtgId == tag.CtgId);
            }

            foreach (var publication in publications)
            {
                publication.Tag = tags.FirstOrDefault(ta => ta.TagId == publication.TagId);
                publication.Usr = users.FirstOrDefault(us => us.UsrId == publication.UsrId);
                publication.Typ = types.FirstOrDefault(ty => ty.TypId == publication.TypId);
            }
            return publications;
        }

        private async Task<PublicationDto> GetPublicationById(int id)
        {
            List<TagDto> tags = await _context.TagsDb.ToListAsync();
            List<UserDto> users = await _context.UsersDb.ToListAsync();
            List<TypeDto> types = await _context.TypesDb.ToListAsync();
            List<CategoryDto> categories = await _context.CategoriesDb.ToListAsync();

            foreach (var tag in tags)
            {
                tag.Ctg = categories.FirstOrDefault(ca => ca.CtgId == tag.CtgId);
            }

            var publication = await _context.PublicationsDb.FirstOrDefaultAsync(h => h.PbcId == id);
            publication.Tag = tags.FirstOrDefault(ta => ta.TagId == publication.TagId);
            publication.Usr = users.FirstOrDefault(us => us.UsrId == publication.UsrId);
            publication.Typ = types.FirstOrDefault(ty => ty.TypId == publication.TypId);
            return publication;
        }

        //private async Task<List<PublicationDto>> GetDbResponses()
        //{
        //    List<ResponseDto> responses = await _context.ResponsesDb.ToListAsync();
        //    List<PublicationDto> publications = await _context.PublicationsDb.ToListAsync();
        //    List<PublicationDto> publicationsSelect = new List<PublicationDto>();

        //    foreach (var response in responses)
        //    {
        //        publicationsSelect.Add(publications.Find(h => h.PbcId == response.RspPubliId));
        //    }
        //    return publicationsSelect;
        //}

        private async Task<List<PublicationDto>> GetResponsesByComments(List<ResponseDto> responses)
        {
            List<PublicationDto> publicationsSelect = new List<PublicationDto>();

            List<TagDto> tags = await _context.TagsDb.ToListAsync();
            List<UserDto> users = await _context.UsersDb.ToListAsync();
            List<TypeDto> types = await _context.TypesDb.ToListAsync();
            List<CategoryDto> categories = await _context.CategoriesDb.ToListAsync();

            foreach (var tag in tags)
            {
                tag.Ctg = categories.FirstOrDefault(ca => ca.CtgId == tag.CtgId);
            }          

            foreach (var rep in responses)
            {
                var publication = await _context.PublicationsDb.FirstOrDefaultAsync(h => h.PbcId == rep.RspPubliId);
                publication.Tag = tags.FirstOrDefault(ta => ta.TagId == publication.TagId);
                publication.Usr = users.FirstOrDefault(us => us.UsrId == publication.UsrId);
                publication.Typ = types.FirstOrDefault(ty => ty.TypId == publication.TypId);

                publicationsSelect.Add(publication);
            }

            return publicationsSelect;
        }



        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return base.Ok(await GetDbPublications());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await GetPublicationById(id);         
            return Ok(question);
        }

        [HttpPost("responses")]
        public async Task<IActionResult> GetResponses(List<ResponseDto> responses)
        {
            return Ok(await GetResponsesByComments(responses));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(PublicationDto publication)
        {
            _context.PublicationsDb.Add(publication);
            await _context.SaveChangesAsync();

            return Ok(await GetPublicationById(publication.PbcId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(PublicationDto publication)
        {
            var dbPubli = await _context.PublicationsDb
                .FirstOrDefaultAsync(h => h.PbcId == publication.PbcId);
           
            dbPubli.PbcTitle = publication.PbcTitle;
            dbPubli.PbcDescription = publication.PbcDescription;
            dbPubli.PbcResolved = publication.PbcResolved;
            dbPubli.TypId = 1;
            dbPubli.UsrId = 1;

            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var dbHPubli = await _context.PublicationsDb
                .FirstOrDefaultAsync(h => h.PbcId == id);

            _context.PublicationsDb.Remove(dbHPubli);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }


    }
}
