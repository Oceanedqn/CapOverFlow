using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class UserDto
    {
        public UserDto()
        {
            PublicationPbcs = new HashSet<PublicationDto>();
        }

        public int UsrId { get; set; }
        public string UsrLastname { get; set; }
        public string UsrFirstname { get; set; }
        public string UsrMail { get; set; }
        public int UsrExperience { get; set; }

        public virtual ICollection<PublicationDto> PublicationPbcs { get; set; }
    }
}
