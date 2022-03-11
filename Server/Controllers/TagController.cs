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
        private List<TagDto> tags = new List<TagDto>
            {
                new TagDto{TagId=1, TagName="C#", CtgId=1 },
                new TagDto{TagId=2, TagName="SQL", CtgId=2 },
                new TagDto{TagId=3, TagName="Virus", CtgId=3 },
                new TagDto{TagId=4, TagName="Arduino", CtgId=4 },
            };
        
        private List<CategoryDto> categories = new List<CategoryDto>
            {
                new CategoryDto{ CtgId=1, CtgName = "Dev", CtgColor="#3A7CA5", CtgTextColor="#FFFFFF" },
                new CategoryDto{ CtgId=2, CtgName = "Data", CtgColor="#D9DCD6", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=3, CtgName = "Cyber Securite", CtgColor="#81C3D7", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=4, CtgName = "IOT", CtgColor="#16425B", CtgTextColor="#FFFFFF" },
            };

        private List<TagDto> GetDbTags()
        {
            foreach (var tag in tags)
            {
                tag.Ctg = categories.FirstOrDefault(h => h.CtgId == tag.CtgId);
            }
            return tags;
        }

        private TagDto GetTagById(int id)
        {
            var tag = tags.FirstOrDefault(h => h.TagId == id);
            tag.Ctg = categories.FirstOrDefault(h => h.CtgId == tag.CtgId);
            return tag;
        }

        [HttpGet]
        public List<TagDto> GetTags()
        {
            return GetDbTags();
        }

        [HttpGet("{id}")]
        public TagDto GetTag(int id)
        {
            var tag = GetTagById(id);
            return tag;
        }

        [HttpPost]
        public TagDto CreateTag(TagDto tag)
        {
            tags.Add(tag);

            return GetTagById(tag.TagId);
        }

        [HttpPut("{id}")]
        public List<TagDto> UpdateTag(TagDto tag, int id)
        {          
            tags.Where(w => w.TagId == id).ToList().ForEach(s => s.TagName = tag.TagName);
            tags.Where(w => w.TagId == id).ToList().ForEach(s => s.CtgId = tag.CtgId);
            return GetDbTags();
        }

        [HttpDelete("{id}")]
        public List<TagDto> DeleteTag(int id)
        {
            tags.Remove(tags.FirstOrDefault(h => h.TagId == id));
            return GetDbTags();
        }

    }
}
