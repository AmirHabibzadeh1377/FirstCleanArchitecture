using CleanArichitecture.Application.DTOs.Weblog;
using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Queries
{
    public class GetWeblogRequest:IRequest<WeblogListDTOs>
    {
        public int WeblogId { get; set; }
    }
}