using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using CapOverFlow.Client.Services.Interfaces;

namespace CapOverFlow.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public List<CategoryDto> Cateogries { get; set; } = new List<CategoryDto>();
        //public CategoryDto Category { get; set; } = new CategoryDto();

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>($"api/category");
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/category/{id}");
        }
    }
}
