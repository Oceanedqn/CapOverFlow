using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class TypeDto
    {
        public TypeDto()
        {
            PublicationPbcs = new HashSet<PublicationDto>();
        }

        public int TypId { get; set; }
        public string TypName { get; set; }

        public virtual ICollection<PublicationDto> PublicationPbcs { get; set; }
    }
}
