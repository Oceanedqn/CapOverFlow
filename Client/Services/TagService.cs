using CapOverFlow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services
{
    public class TagService : ITagService
    {
        private readonly HttpClient _httpClient;
        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<TagsDto> Tags { get; set; } = new List<TagsDto>();

        public event Action OnChange;

        public async Task<List<TagsDto>> GetTags()
        {
            Tags = await _httpClient.GetFromJsonAsync<List<TagsDto>>($"api/Tag");
            return Tags;
        }

        public async Task<TagsDto> GetTag(int id)
        {
            return await _httpClient.GetFromJsonAsync<TagsDto>($"api/Tags/{id}");
        }

        public async Task<List<TagsDto>> CreateTag(TagsDto tag)
        {
            var result = await _httpClient.PostAsJsonAsync<TagsDto>($"api/Tag", tag);
            Tags = await result.Content.ReadFromJsonAsync<List<TagsDto>>();
            return Tags;
        }

        public async Task<List<TagsDto>> UpdateTag(TagsDto tag, int id)
        {
            var result = await _httpClient.PutAsJsonAsync<TagsDto>($"api/Tags/{id}", tag);
            Tags = await result.Content.ReadFromJsonAsync<List<TagsDto>>();
            OnChange.Invoke();
            return Tags;
        }

        public async Task<List<TagsDto>> DeleteTag(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Tags/{id}");
            Tags = await result.Content.ReadFromJsonAsync<List<TagsDto>>();
            OnChange.Invoke();
            return Tags;
        }

        

       

        
    }
}
