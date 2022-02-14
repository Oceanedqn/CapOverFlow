using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Models;

namespace CapOverFlow.Client.Services
{
    public interface ITagService
    {
        event Action OnChange;

        List<TagDto> Tags { get; set; }

        Task<List<TagDto>> GetTags();

        Task<TagDto> GetTag(int id);

        Task<List<TagDto>> CreateTag(TagDto tag);

        Task<List<TagDto>> UpdateTag(TagDto tag);

        Task<List<TagDto>> DeleteTag(int id);

    }
}
