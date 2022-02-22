using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
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
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string PBC_title { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Name is too long.")]
        public string PBC_description { get; set; }
        [Required]
        public bool PBC_resolved { get; set; }
        [Required]
        public DateTime QST_date { get; set; }
        [Required]
        public int USR_id { get; set; }
        [Required]
        public int TYP_id { get; set; }

        public TypeDto Type { get; set; }
        public UserDto User { get; set; }
        public ICollection<AttachementDto> Attachements { get; set; }
        public List<IncludeDto> Includes { get; set; }
    }
}
