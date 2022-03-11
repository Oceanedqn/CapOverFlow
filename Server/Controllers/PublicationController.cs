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
        List<TagDto> tags = new List<TagDto>
            {
                new TagDto{TagId=1, TagName="C#", CtgId=1 },
                new TagDto{TagId=2, TagName="SQL", CtgId=2 },
                new TagDto{TagId=3, TagName="Virus", CtgId=3 },
                new TagDto{TagId=4, TagName="Arduino", CtgId=4 },
            };

        List<CategoryDto> categories = new List<CategoryDto>
            {
                new CategoryDto{ CtgId=1, CtgName = "Dev", CtgColor="#3A7CA5", CtgTextColor="#FFFFFF" },
                new CategoryDto{ CtgId=2, CtgName = "Data", CtgColor="#D9DCD6", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=3, CtgName = "Cyber Securite", CtgColor="#81C3D7", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=4, CtgName = "IOT", CtgColor="#16425B", CtgTextColor="#FFFFFF" },
            };

        List<TypeDto> types = new List<TypeDto>
            {
                new TypeDto{ TypId=1, TypName="question" },
                new TypeDto{ TypId=2, TypName="reponse" },
                new TypeDto{ TypId=3, TypName="biblio" },

            };

        List<UserDto> users = new List<UserDto>
            {
                new UserDto{ UsrId=1, UsrLastname = "Duquenne", UsrFirstname="Oceane", UsrMail="ocefrfane.dqn@gmfrfail.com", UsrExperience=0 },
            };

        List<PublicationDto> publications = new List<PublicationDto>
        {
            new PublicationDto{PbcId=1, PbcDate=DateTime.Now, PbcResolved=false, TagId=1, TypId=1,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=2, PbcDate=DateTime.Now, PbcResolved=false, TagId=2, TypId=1,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=3, PbcDate=DateTime.Now, PbcResolved=true, TagId=3, TypId=1,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=4, PbcDate=DateTime.Now, PbcResolved=false, TagId=4, TypId=1,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=5, PbcDate=DateTime.Now, PbcResolved=false, TagId=1, TypId=3,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=6, PbcDate=DateTime.Now, PbcResolved=false, TagId=2, TypId=3,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=7, PbcDate=DateTime.Now, PbcResolved=false, TagId=3, TypId=3,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."},
            new PublicationDto{PbcId=8, PbcDate=DateTime.Now, PbcResolved=false, TagId=4, TypId=3,UsrId=1,PbcTitle="Lorem Ipsum", PbcDescription="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."}
            };

        private async Task<List<PublicationDto>> GetDbPublications()
        {          
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
            foreach (var tag in tags)
            {
                tag.Ctg = categories.FirstOrDefault(ca => ca.CtgId == tag.CtgId);
            }

            var publication = publications.FirstOrDefault(h => h.PbcId == id);
            publication.Tag = tags.FirstOrDefault(ta => ta.TagId == publication.TagId);
            publication.Usr = users.FirstOrDefault(us => us.UsrId == publication.UsrId);
            publication.Typ = types.FirstOrDefault(ty => ty.TypId == publication.TypId);
            return publication;
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

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(PublicationDto publication)
        {
            publications.Add(publication);

            return Ok(await GetPublicationById(publication.PbcId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(PublicationDto publication, int id)
        {

            publications.Where(w => w.PbcId == id).ToList().ForEach(s => s.PbcTitle = publication.PbcTitle);
            publications.Where(w => w.PbcId == id).ToList().ForEach(s => s.PbcResolved = publication.PbcResolved);
            publications.Where(w => w.PbcId == id).ToList().ForEach(s => s.PbcDescription = publication.PbcDescription);

            return Ok(await GetDbPublications());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var dbHPubli = publications
                .FirstOrDefault(h => h.PbcId == id);

            publications.Remove(dbHPubli);
            return Ok(await GetDbPublications());
        }


    }
}
