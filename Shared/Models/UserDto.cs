using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOverFlow.Shared
{
    [Table("T_User_USR")]
    public class UserDto
    {
        [Key]
        public int USR_id { get; set; }
        public string USR_lastname { get; set; }
        public string USR_firstname { get; set; }
        public string USR_mail { get; set; }
        public int USR_experience { get; set; }
    }
}
