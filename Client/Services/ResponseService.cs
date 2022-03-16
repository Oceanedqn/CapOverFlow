using CapOverFlow.Client.Services.Interfaces;
using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services
{
    public class ResponseService : BaseService<ResponseDto>, IResponseService
    {
        private readonly HttpClient _httpClient;
        public ResponseService(HttpClient httpClient) : base(httpClient, "response")
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResponseDto>> GetCommentsById(int idPubli)
        {
            return await _httpClient.GetFromJsonAsync<List<ResponseDto>>($"api/response/{idPubli}");
        }
    }
}
