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
        public PublicationService(HttpClient httpClient) : base(httpClient, "publication")
        {
        }
    }
}
