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
    public class TagService : BaseService<TagDto>, ITagService
    {
        public TagService(HttpClient httpClient) : base(httpClient, "tag")
        {
        }


        


        //public async Task<TagDto> UpdateTag(TagDto tag)
        //{
        //    Console.Write(tag);
        //    var result = await _httpClient.PutAsJsonAsync<TagDto>($"api/tag/{tag.TAG_id}", tag);
        //    var temp = await result.Content.ReadFromJsonAsync<TagDto>();
        //    Tags.Add(temp); 
        //    OnChange.Invoke();
        //    return temp;
        //}

        //public async Task<TagDto> DeleteTag(int id)
        //{
        //    var result = await _httpClient.DeleteAsync($"api/Tag/{id}");
        //    var temp = await result.Content.ReadFromJsonAsync<List<TagDto>>();
        //    Tags.Remove(temp.Last());
        //    OnChange.Invoke();
        //    return temp.Last();
        //}        
    }
}
