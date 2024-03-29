﻿using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services.Interfaces
{
    interface IResponseService : IBaseService<ResponseDto>
    {
        Task<List<ResponseDto>> GetCommentsById(int idPubli);
    }
}
