using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.Weblog.Validators;
using CleanArichitecture.Application.Exeptions;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using CleanArichitecture.Application.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Commands
{
    public class CreateWeblogHandler : IRequestHandler<CreateWeblogRequest, BaseCommandResponse>
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

        public async Task<BaseCommandResponse> Handle(CreateWeblogRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var validation = new CreateWeblogDTOValidator(_weblogCategoryRepo);
            var validationResult = await validation.ValidateAsync(request.CreateWeblogDTOs);
            if (!validationResult.IsValid)
            {
                response.Message = "Creation Faild";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var weblogMapper = _mapper.Map<CleanArchitecture.Domain.Entities.Weblog.Weblog>(request.CreateWeblogDTOs);
                var weblog = await _weblogRepo.Add(weblogMapper);
                response.Message = "Weblog Creation Success";
                response.Success = true;
                response.Id = weblog.ID;
            }

            return response;
        }

        #endregion
    }
}