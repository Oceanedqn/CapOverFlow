using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared
{
    [Table("T_Attachement_ATC")]
    public class AttachementDto
    {
        [Key]
        public int ATC_id { get; set; }
        public string ATC_name { get; set; }
        public string ATC_content { get; set; }
        public int ATC_date { get; set; }
        public int PBC_id { get; set; }
    }
}
