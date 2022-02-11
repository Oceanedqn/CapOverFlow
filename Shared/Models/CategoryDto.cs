using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared.Models
{
    [Table("T_Categories_CTG")]
    public class CategoryDto
    {
        [Key]
        public int CTG_id { get; set; } = 1;
        public string CTG_name { get; set; }
        public string CTG_color { get; set; }
        
    }
}
