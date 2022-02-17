using CapOverFlow.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Models
{
    [Table("T_Attachement_ATC")]
    public partial class AttachementDto
    {
        public int ATC_id { get; set; }
        public string ATC_name { get; set; }
        public string ATC_content { get; set; }
        public DateTime ATC_date { get; set; }
        public int PBC_id { get; set; }

        public PublicationDto Publication { get; set; }
    }
}
