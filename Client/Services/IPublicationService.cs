using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared;

namespace CapOverFlow.Client.Services
{
    public interface IPublicationService
    {
        //event Action OnChange;

        List<PublicationDto> Publications { get; set; }

        Task<List<PublicationDto>> GetPublications();
    }
}
