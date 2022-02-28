using CapOverFlow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services.Interfaces
{
    public interface IBaseService<T>
    {
        List<T> Entities { get; set; }

        event Action OnChange;

        Task<List<T>> GetEntities();

        Task<T> GetEntity(int id);

        Task<T> CreateEntity(T tag);

        Task<List<T>> UpdateEntity(T tag, int id);

        Task<List<T>> DeleteEntity(int id);
    }
}
