using CleanArichitecture.Application.DTOs.Weblog;
using MediatR;
using System.Collections.Generic;

namespace CleanArichitecture.Application.Features.Requests.Weblog.Queries
{
    public class GetWeblogListRequest : IRequest<List<WeblogListDTOs>>
    {
    }
}
