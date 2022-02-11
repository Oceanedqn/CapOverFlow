using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared
{
    [Table("T_Publication_PBC")]
    public class PublicationDto
    {
        [Key]
        public int PBC_id { get; set; } = 0;
        public string PBC_title { get; set; }
        public string PBC_description { get; set; }
        public bool PBC_resolved { get; set; }
        public int QST_date { get; set; }
        public int USR_id { get; set; }
        public int TYP_id { get; set; }
    }
}
