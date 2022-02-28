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


        


    }
}
