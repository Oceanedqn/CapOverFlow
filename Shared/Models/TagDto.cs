using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared.Models
{
    [Table("T_Tags_TAG")]
    public class TagDto
    {
        [Key]
        public int TAG_id { get; set; } = 0;
        public string TAG_name { get; set; }
        public int CTG_id { get; set; }
    }
}
