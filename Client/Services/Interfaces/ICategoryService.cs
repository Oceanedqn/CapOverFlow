using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;

namespace CapOverFlow.Client.Services.Interfaces
{
    interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();

        Task<CategoryDto> GetCategory(int id);
    }
}
