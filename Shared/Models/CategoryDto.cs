using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Models
{
    [Table("T_Categories_CTG")]
    public partial class CategoryDto
    {
        public CategoryDto()
        {
            Tags = new HashSet<TagDto>();
        }

        public int CTG_id { get; set; }
        public string CTG_name { get; set; }
        public string CTG_color { get; set; }

        public ICollection<TagDto> Tags { get; set; }
    }
}
