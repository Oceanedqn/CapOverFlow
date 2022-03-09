using CapOverFlow.Client.Services.Interfaces;
using CapOverFlow.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CapOverFlow.Client.Services
{
    public class CommentService : BaseService<CommentDto>, ICommentService
    {
        public CommentService(HttpClient httpClient) : base(httpClient, "comment")
        {

        }
    }
}
