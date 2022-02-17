using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Models;

namespace CapOverFlow.Client.Services
{
    interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();

        Task<CategoryDto> GetCategory(int id);
    }
}
