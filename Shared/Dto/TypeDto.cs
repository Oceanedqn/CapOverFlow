using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("T_Type_TYP")]
    public partial class TypeDto
    {
        public TypeDto()
        {
            Publications = new HashSet<PublicationDto>();
        }

        public int TYP_id { get; set; }
        public string TYP_name { get; set; }

        public ICollection<PublicationDto> Publications { get; set; }
    }
}
