using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.Weblog.Validators;
using CleanArichitecture.Application.Exeptions;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Commands
{
    public class CreateWeblogHandler : IRequestHandler<CreateWeblogRequest, int>
    {
        #region Fields

        private readonly IWeblogRepository _weblogRepo;
        private readonly IWeblogCategoryRepository _weblogCategoryRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public CreateWeblogHandler(IMapper mapper, IWeblogRepository weblogRepo, IWeblogCategoryRepository weblogCategoryRepo)
        {
            _mapper = mapper;
            _weblogRepo = weblogRepo;
            _weblogCategoryRepo = weblogCategoryRepo;
        }

        #endregion

        #region Handler

        public async Task<int> Handle(CreateWeblogRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validation = new CreateWeblogDTOValidator(_weblogCategoryRepo);
            var validationResult =await validation.ValidateAsync(request.CreateWeblogDTOs);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            #endregion
            var weblogMapper = _mapper.Map<CleanArchitecture.Domain.Entities.Weblog.Weblog>(request.CreateWeblogDTOs);
            var weblog = await _weblogRepo.Add(weblogMapper);
            return weblog.ID;
        }

        #endregion
    }
}