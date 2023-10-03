using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Features.Requests.Weblog.Queries;
using CleanArichitecture.Application.Persistance.ServiceContract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Queries
{
    public class GetWeblogListHnadler : IRequestHandler<GetWeblogListRequest, List<WeblogListDTOs>>
    {
        #region Fields

        private readonly IWeblogRepository _weblogRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetWeblogListHnadler(IWeblogRepository weblogRepo, IMapper mapper)
        {
            _weblogRepo = weblogRepo;
            _mapper = mapper;
        }

        #endregion

        #region Handler

        public async Task<List<WeblogListDTOs>> Handle(GetWeblogListRequest request, CancellationToken cancellationToken)
        {
            var weblog = await _weblogRepo.Get();
            var weblogListDto = _mapper.Map<List<WeblogListDTOs>>(weblog);
            return weblogListDto;
        }

        #endregion
    }
}
