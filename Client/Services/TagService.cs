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
    public class TagService : ITagService
    {
        private readonly HttpClient _httpClient;
        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();

        public event Action OnChange;

        public async Task<List<TagDto>> GetTags()
        {
            Tags = await _httpClient.GetFromJsonAsync<List<TagDto>>($"api/tag"); ;
            return Tags;
        }

        public async Task<TagDto> GetTag(int id)
        {
            return await _httpClient.GetFromJsonAsync<TagDto>($"api/tag/{id}");
        }

        public async Task<List<TagDto>> CreateTag(TagDto tag)
        {
            var result = await _httpClient.PostAsJsonAsync<TagDto>($"api/tag", tag);
            Tags = await result.Content.ReadFromJsonAsync<List<TagDto>>();
            OnChange.Invoke();
            return Tags;
        }

        public async Task<List<TagDto>> UpdateTag(TagDto tag)
        {
            Console.Write(tag);
            var result = await _httpClient.PutAsJsonAsync<TagDto>($"api/tag/{tag.TAG_id}", tag);
            Tags = await result.Content.ReadFromJsonAsync<List<TagDto>>();
            OnChange.Invoke();
            return Tags;
        }

        public async Task<List<TagDto>> DeleteTag(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Tag/{id}");
            Tags = await result.Content.ReadFromJsonAsync<List<TagDto>>();
            OnChange.Invoke();
            return Tags;
        }

        

       

        
    }
}
