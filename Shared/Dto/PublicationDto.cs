using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class PublicationDto
    {
        public PublicationDto()
        {
        }

        public int PbcId { get; set; }
        public string PbcTitle { get; set; }
        public string PbcDescription { get; set; }
        public bool PbcResolved { get; set; }
        public DateTime PbcDate { get; set; }
        public int TagId { get; set; }
        public int UsrId { get; set; }
        public int TypId { get; set; }

        public virtual TagDto Tag { get; set; }
        public virtual TypeDto Typ { get; set; }
        public virtual UserDto Usr { get; set; }
    }
}
