using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog.Validators;
using CleanArichitecture.Application.Exeptions;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using CleanArichitecture.Application.Responses;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Commands
{
    public class UpdateWeblogHandler : IRequestHandler<UpdateWeblogRequest, BaseCommandResponse>
    {
        #region Fields

        private readonly IWeblogRepository _weblogRepo;
        private readonly IWeblogCategoryRepository _weblogCategoryRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UpdateWeblogHandler(IWeblogRepository weblogRepo, IMapper mapper)
        {
            _weblogRepo = weblogRepo;
            _mapper = mapper;
        }

        #endregion

        #region Handler

        public async Task<BaseCommandResponse> Handle(UpdateWeblogRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateWeblogDTOValidator(_weblogCategoryRepo);
            var validationResult = await validator.ValidateAsync(request.UpdateWeblogDTOs);
            if (!validationResult.IsValid)
            {
                response.Message = "Weblog Update Failds";
                response.Success = false;
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var weblog = await _weblogRepo.GetById(request.UpdateWeblogDTOs.ID);
                _mapper.Map(request.UpdateWeblogDTOs, weblog);
                await _weblogRepo.Update(weblog);
                response.Success = true;
                response.Message = "Weblog Update Succes";
                response.Id = weblog.ID;
            }

            return response;
        }

        #endregion
    }
}