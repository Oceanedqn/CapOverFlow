using System;
using System.Collections.Generic;

#nullable disable

namespace CapOverFlow.Shared.Dto
{
    public partial class CategoryDto
    {
        public CategoryDto()
        {
        }

        public int CtgId { get; set; }
        public string CtgName { get; set; }
        public string CtgColor { get; set; }
    }
}
