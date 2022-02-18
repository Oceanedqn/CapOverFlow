using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("T_Include_ICD")]
    public partial class IncludeDto
    {
        public int TAG_id { get; set; }
        public int PBC_id { get; set; }

        public PublicationDto Publication { get; set; }
        public TagDto Tag { get; set; }
    }
}
