﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class CommentDto
    {
        public int CmtId { get; set; }
        public int PbcId { get; set; }

        public virtual PublicationDto Pbc { get; set; }
    }
}
