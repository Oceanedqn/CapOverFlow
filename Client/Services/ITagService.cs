using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared;

namespace CapOverFlow.Client.Services
{
    public interface ITagService
    {
        event Action OnChange;

        List<TagsDto> Tags { get; set; }

        Task<List<TagsDto>> GetTags();

        Task<TagsDto> GetTag(int id);

        Task<List<TagsDto>> CreateTag(TagsDto tag);

        Task<List<TagsDto>> UpdateTag(TagsDto tag, int id);

        Task<List<TagsDto>> DeleteTag(int id);

    }
}
