using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using CapOverFlow.Shared.Models;

namespace CapOverFlow.Client.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly HttpClient _httpClient;

        public PublicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<PublicationDto> Publications { get; set; } = new List<PublicationDto>();

        //public event Action OnChange;

        public async Task<List<PublicationDto>> GetPublications()
        {
            Publications = await _httpClient.GetFromJsonAsync<List<PublicationDto>>("api/Publication");
            return Publications;
        }
    }
}
