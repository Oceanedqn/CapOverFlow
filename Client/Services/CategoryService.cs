using CapOverFlow.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace CapOverFlow.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CategoryDto> Cateogries { get; set; } = new List<CategoryDto>();

        public event Action OnChnge;

        public async Task<List<CategoryDto>> GetCategories()
        {
            Cateogries = await _httpClient.GetFromJsonAsync<List<CategoryDto>>($"api/Category");
            return Cateogries;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/Category/{id}");
        }
    }
}
