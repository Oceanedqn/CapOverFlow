using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared
{
    [Table("T_Include_ICD")]
    public class IncludeDto
    {
        public int TAG_id { get; set; }
        public int PBC_id { get; set; }
    }
}
