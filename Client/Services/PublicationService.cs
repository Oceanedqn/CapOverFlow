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
    public class PublicationService : IPublicationService
    {
        private readonly HttpClient _httpClient;

        public PublicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public List<PublicationDto> Questions { get; set; } = new List<PublicationDto>();

        public Task<PublicationDto> GetQuestion()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PublicationDto>> GetQuestions()
        {
            Questions = await _httpClient.GetFromJsonAsync<List<PublicationDto>>("api/publication");
            return Questions;
        }

        public async Task<List<PublicationDto>> CreateQuestion(PublicationDto publication)
        {
            var result = await _httpClient.PostAsJsonAsync<PublicationDto>($"api/Publication", publication);
            Questions = await result.Content.ReadFromJsonAsync<List<PublicationDto>>();
            OnChange.Invoke();
            return Questions;
        }

        public async Task<List<PublicationDto>> UpdateQuestion(PublicationDto publication)
        {
            var result = await _httpClient.PutAsJsonAsync<PublicationDto>($"api/Publication/{publication.PBC_id}", publication);
            Questions = await result.Content.ReadFromJsonAsync<List<PublicationDto>>();
            OnChange.Invoke();
            return Questions;
        }

        public async Task<List<PublicationDto>> DeleteQuestion(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Publication/{id}");
            Questions = await result.Content.ReadFromJsonAsync<List<PublicationDto>>();
            OnChange.Invoke();
            return Questions;
        }
    }
}
