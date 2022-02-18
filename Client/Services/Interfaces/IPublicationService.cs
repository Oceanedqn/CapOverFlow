using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;

namespace CapOverFlow.Client.Services.Interfaces
{
    public interface IPublicationService
    {
        event Action OnChange;

        List<PublicationDto> Questions { get; set; }

        Task<List<PublicationDto>> GetQuestions();

        Task<PublicationDto> GetQuestion();

        Task<List<PublicationDto>> CreateQuestion(PublicationDto publication);

        Task<List<PublicationDto>> UpdateQuestion(PublicationDto publication);

        Task<List<PublicationDto>> DeleteQuestion(int id);

        Task<List<PublicationDto>> GetPubliTags(int id);
    }
}
