using MediatR;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Commands
{
    public class DeleteWeblogCommandRequest:IRequest<Unit>
    {
        public int WeblogId { get; set; }
    }
}