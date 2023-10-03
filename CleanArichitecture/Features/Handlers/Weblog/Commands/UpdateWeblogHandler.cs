using AutoMapper;
using CleanArichitecture.Application.DTOs.Weblog.Validators;
using CleanArichitecture.Application.Exeptions;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Features.Handlers.Weblog.Commands
{
    public class UpdateWeblogHandler : IRequestHandler<UpdateWeblogRequest, Unit>
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

        public async Task<Unit> Handle(UpdateWeblogRequest request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateWeblogDTOValidator(_weblogCategoryRepo);
            var validationResult = await validator.ValidateAsync(request.UpdateWeblogDTOs);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            #endregion

            var weblog = await _weblogRepo.GetById(request.UpdateWeblogDTOs.ID);
            _mapper.Map(request.UpdateWeblogDTOs, weblog);
            await _weblogRepo.Update(weblog);
            return Unit.Value;
        }

        #endregion
    }
}