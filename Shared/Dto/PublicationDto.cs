using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("publication_PBC")]
    public partial class PublicationDto
    {
        public PublicationDto()
        {
            Attachements = new HashSet<AttachementDto>();
        }

        public int PBC_id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string PBC_title { get; set; }
        [Required]
        [StringLength(8000, ErrorMessage = "Name is too long.")]
        public string PBC_description { get; set; }
        [Required]
        public bool PBC_resolved { get; set; }
        [Required]
        public DateTime PBC_date { get; set; }
        [Required]
        public int USR_id { get; set; }
        [Required]
        public int TYP_id { get; set; }
        [Required]
        public int TAG_id { get; set; }

        public TypeDto Type { get; set; }
        public UserDto User { get; set; }
        public TagDto Tag { get; set; }
        public ICollection<AttachementDto> Attachements { get; set; }
    }
}
