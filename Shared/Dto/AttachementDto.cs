using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class AttachementDto
    {
        public int AtcId { get; set; }
        public string AtcName { get; set; }
        public string AtcContent { get; set; }
        public int AtcDate { get; set; }
        public int PbcId { get; set; }

        public virtual PublicationDto Pbc { get; set; }
    }
}
