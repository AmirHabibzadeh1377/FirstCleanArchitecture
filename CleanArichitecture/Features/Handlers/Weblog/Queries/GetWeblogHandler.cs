using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Features.Requests.Weblog.Queries;
using CleanArichitecture.Application.Persistance.ServiceContract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Queries
{
    public class GetWeblogHandler : IRequestHandler<GetWeblogRequest, WeblogListDTOs>
    {
        #region Fields

        private readonly IWeblogRepository _weblogRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public GetWeblogHandler(IMapper mapper, IWeblogRepository weblogRepo)
        {
            _mapper = mapper;
            _weblogRepo = weblogRepo;
        }

        #endregion

        #region Handler

        public async Task<WeblogListDTOs> Handle(GetWeblogRequest request, CancellationToken cancellationToken)
        {
            var weblog =await _weblogRepo.GetById(request.WeblogId);
            var weblogListDto = _mapper.Map<WeblogListDTOs>(weblog);
            return weblogListDto;
        }

        #endregion
    }
}