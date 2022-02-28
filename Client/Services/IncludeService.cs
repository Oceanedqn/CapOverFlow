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
    public class IncludeService : BaseService<IncludeDto>, IIncludeService
    {
        public IncludeService(HttpClient httpClient) : base(httpClient, "include")
        {
        }
    }
}
