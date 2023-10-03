using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.WeblogCategory;
using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Commands
{
    public class CreateWeblogRequest:IRequest<int>
    {
        public CreateWeblogDTOs CreateWeblogDTOs{ get; set; }
    }
}