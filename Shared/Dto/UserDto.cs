using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    [Table("T_User_USR")]
    public partial class UserDto
    {
        public UserDto()
        {
            Publications = new HashSet<PublicationDto>();
        }

        public int USR_id { get; set; }
        public string USR_lastname { get; set; }
        public string USR_firstname { get; set; }
        public string USR_mail { get; set; }
        public int USR_experience { get; set; }

        public virtual ICollection<PublicationDto> Publications { get; set; }
    }
}
