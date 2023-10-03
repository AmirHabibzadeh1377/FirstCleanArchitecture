using AutoMapper;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Commands
{
    public class DeleteWeblogCommandHandler : IRequestHandler<DeleteWeblogCommandRequest,Unit>
    {
        #region Fields

        private readonly IWeblogRepository _weblogRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public DeleteWeblogCommandHandler(IMapper mapper, IWeblogRepository weblogRepo)
        {
            _mapper = mapper;
            _weblogRepo = weblogRepo;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(DeleteWeblogCommandRequest request, CancellationToken cancellationToken)
        {
            var weblog =await _weblogRepo.GetById(request.WeblogId);
            await _weblogRepo.Delete(weblog);
            return Unit.Value;
        }

        #endregion
    }
}