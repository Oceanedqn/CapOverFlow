using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;

namespace CapOverFlow.Client.Services.Interfaces
{
    public interface IPublicationService : IBaseService<PublicationDto>
    {
        Task<List<PublicationDto>> GetPublicationResponsesByListComment(List<ResponseDto> responses);
    }


}
