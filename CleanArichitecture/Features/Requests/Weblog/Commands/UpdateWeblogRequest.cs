using CleanArichitecture.Application.DTOs.Weblog;
using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Commands
{
    public class UpdateWeblogRequest:IRequest<Unit>
    {
        public UpdateWeblogDTOs UpdateWeblogDTOs { get; set; }
    }
}