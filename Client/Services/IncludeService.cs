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
    public class IncludeService : IIncludeService
    {
        private readonly HttpClient _httpClient;
        public IncludeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<IncludeDto> Includes { get; set; } = new List<IncludeDto>();
        
        public event Action OnChange;

        public async Task<List<IncludeDto>> GetIncludes()
        {
            Includes = await _httpClient.GetFromJsonAsync<List<IncludeDto>>("api/include");
            return Includes;
        }

        public async Task<List<IncludeDto>> CreateInclude(IncludeDto include)
        {
            var result = await _httpClient.PostAsJsonAsync<IncludeDto>($"api/include", include);
            Includes = await result.Content.ReadFromJsonAsync<List<IncludeDto>>();
            //OnChange.Invoke();
            return Includes;
        }
    }
}
