using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Models
{
    [Table("T_Publication_PBC")]
    public partial class PublicationDto
    {
        public PublicationDto()
        {
            Attachements = new HashSet<AttachementDto>();
            Includes = new List<IncludeDto>();
        }

        public int PBC_id { get; set; }
        public string PBC_title { get; set; }
        public string PBC_description { get; set; }
        public bool PBC_resolved { get; set; }
        public DateTime QST_date { get; set; }
        public int USR_id { get; set; }
        public int TYP_id { get; set; }

        public TypeDto Type { get; set; }
        public UserDto User { get; set; }
        public ICollection<AttachementDto> Attachements { get; set; }
        public List<IncludeDto> Includes { get; set; }
    }
}
