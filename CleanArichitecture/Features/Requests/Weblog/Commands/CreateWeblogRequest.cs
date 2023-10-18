using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.WeblogCategory;
using CleanArichitecture.Application.Responses;
using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Commands
{
    public class CreateWeblogRequest:IRequest<BaseCommandResponse>
    {
        public CreateWeblogDTOs CreateWeblogDTOs{ get; set; }
    }
}