using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("tag_TAG")]
    public partial class TagDto
    {
        public TagDto()
        {
        }

        public int TAG_id { get; set; }
        public string TAG_name { get; set; }
        public int CTG_id { get; set; }

        public CategoryDto Categories { get; set; }

        public ICollection<PublicationDto> Publications { get; set; }
    }
}
