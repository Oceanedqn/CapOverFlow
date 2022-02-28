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
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<CategoryDto>> GetDbCategories()
        {
            return await _context.Category
                .Include(ta => ta.Tags)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await GetDbCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Category
                .FirstOrDefaultAsync(h => h.CTG_id == id);
            if (category == null)
                return NotFound("Super Hero wasn't found.");
            return Ok(category);
        }
    }
}
