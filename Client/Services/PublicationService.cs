using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using CapOverFlow.Shared.Dto;
using CapOverFlow.Client.Services.Interfaces;

namespace CapOverFlow.Client.Services
{
    public class PublicationService : BaseService<PublicationDto>, IPublicationService
    {
        private readonly HttpClient _httpClient;
        public PublicationService(HttpClient httpClient) : base(httpClient, "publication")
        {
            _httpClient = httpClient;
        }

        public async Task<List<PublicationDto>> GetPublicationResponsesByListComment(List<ResponseDto> responses)
        {
            var rep = await _httpClient.PostAsJsonAsync($"api/publication/responses", responses);
            return await rep.Content.ReadFromJsonAsync<List<PublicationDto>>();
        }
    }
}
