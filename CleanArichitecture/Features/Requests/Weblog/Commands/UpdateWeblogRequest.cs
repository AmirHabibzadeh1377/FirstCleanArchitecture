using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Responses;
using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Commands
{
    public class UpdateWeblogRequest:IRequest<BaseCommandResponse>
    {
        public UpdateWeblogDTOs UpdateWeblogDTOs { get; set; }
    }
}