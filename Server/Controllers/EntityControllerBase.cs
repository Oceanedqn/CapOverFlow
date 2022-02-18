using CapOverFlow.Server.Data;
using CapOverFlow.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapOverFlow.Server.Controllers
{
    public class EntityControllerBase : ControllerBase
    {
        private readonly DataContext _context;
        public EntityControllerBase(DataContext context)
        {
            _context = context;
        }

    }
}
