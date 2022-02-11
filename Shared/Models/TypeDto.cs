using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared
{
    [Table("T_Type_TYP")]
    public class TypeDto
    {
        [Key]
        public int TYP_id { get; set; } = 0;
        public string TYP_name { get; set; }
    }
}
