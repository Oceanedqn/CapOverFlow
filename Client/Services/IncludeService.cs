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

        public async Task<List<IncludeDto>> GetIncludes()
        {
            return await _httpClient.GetFromJsonAsync<List<IncludeDto>>($"api/include");
        }

    }
}
