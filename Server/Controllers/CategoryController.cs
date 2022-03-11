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
    public class CategoryController : ControllerBase
    {

        List<CategoryDto> categories = new List<CategoryDto>
            {
                new CategoryDto{ CtgId=1, CtgName = "Dev", CtgColor="#3A7CA5", CtgTextColor="#FFFFFF" },
                new CategoryDto{ CtgId=2, CtgName = "Data", CtgColor="#D9DCD6", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=3, CtgName = "Cyber Securite", CtgColor="#81C3D7", CtgTextColor="#000000" },
                new CategoryDto{ CtgId=4, CtgName = "IOT", CtgColor="#16425B", CtgTextColor="#FFFFFF" },
            };

        private List<CategoryDto> GetDbCategories()
        {
            return categories;
        }

        [HttpGet]
        public List<CategoryDto> GetCategories()
        {
            return GetDbCategories();
        }

        [HttpGet("{id}")]
        public CategoryDto GetCategory(int id)
        {
            var category = categories.FirstOrDefault(h => h.CtgId == id);
            return category;
        }
    }
}
