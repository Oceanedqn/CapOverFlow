﻿using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services.Interfaces
{
    interface IIncludeService
    {
        event Action OnChange;
        List<IncludeDto> Includes { get; set; }
        Task<List<IncludeDto>> GetIncludes();
        Task<List<IncludeDto>> CreateInclude(IncludeDto include);


    }
}
