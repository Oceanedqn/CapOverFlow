using CapOverFlow.Client.Services.Interfaces;
using CapOverFlow.Shared;
using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        
        private readonly HttpClient _httpClient;

        private readonly string _endPoint;
        public BaseService(HttpClient httpClient, string endPoint)
        {
            _httpClient = httpClient;
            _endPoint = endPoint;

        }

        public List<T> Entities { get; set; } = new List<T>();

        public event Action OnChange;

        public async Task<List<T>> GetEntities()
        {
            Entities = await _httpClient.GetFromJsonAsync<List<T>>($"api/{_endPoint}"); ;
            return Entities;
        }

        public async Task<T> GetEntity(int id)
        {
            return await _httpClient.GetFromJsonAsync<T>($"api/tag/{id}");
        }

        public async Task<T> CreateEntity(T entity)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/{_endPoint}", entity);
            var temp = await result.Content.ReadFromJsonAsync<T>();
            Entities.Add(temp);
            OnChange.Invoke();
            return temp;
        }

        public async Task<List<T>> UpdateEntity(T entity, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/{_endPoint}/{id}", entity);
            Entities = await result.Content.ReadFromJsonAsync<List<T>>();
            OnChange.Invoke();
            return Entities;
        }

        public async Task<List<T>> DeleteEntity(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/{_endPoint}/{id}");
            Entities = await result.Content.ReadFromJsonAsync<List<T>>();
            OnChange.Invoke();
            return Entities;
        }
    }
}
