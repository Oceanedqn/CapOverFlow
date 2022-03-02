using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class TagDto
    {
        public TagDto()
        {
            PublicationPbcs = new HashSet<PublicationDto>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
        public int CtgId { get; set; }

        public virtual CategoryDto Ctg { get; set; }
        public virtual ICollection<PublicationDto> PublicationPbcs { get; set; }
    }
}
