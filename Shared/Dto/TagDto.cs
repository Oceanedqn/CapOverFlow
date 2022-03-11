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
        [Column("TAG_id")]
        public int TagId { get; set; }
        [Column("TAG_name")]
        public string TagName { get; set; }
        [Column("CTG_id")]
        public int CtgId { get; set; }

        public virtual CategoryDto Ctg { get; set; }
    }
}
