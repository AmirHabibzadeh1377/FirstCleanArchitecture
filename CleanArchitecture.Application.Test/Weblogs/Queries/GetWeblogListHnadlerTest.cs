using AutoMapper;
using CleanArchitecture.Application.Test.Mocks.WeblogRepository;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Features.Handlers.Weblog.Queries;
using CleanArichitecture.Application.Features.Requests.Weblog.Queries;
using CleanArichitecture.Application.Persistance.ServiceContract;
using CleanArichitecture.Application.Profiles;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.Test.Weblogs.Queries
{
    public class GetWeblogListHnadlerTest
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly Mock<IWeblogRepository> _mockRepo;

        #endregion

        #region Ctor

        public GetWeblogListHnadlerTest()
        {
            _mockRepo = WeblogMockRepository.GetWeblogRepository();
            var mapperConfig = new MapperConfiguration(m =>
           {
               m.AddProfile<MappingProfiles>();
           });

            _mapper = mapperConfig.CreateMapper();
        }

        #endregion

        [Fact]
        public async Task GetWeblogListTest()
        {
            var handler = new GetWeblogListHnadler(_mockRepo.Object,_mapper);
            var result = await handler.Handle(new GetWeblogListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<WeblogListDTOs>>();
        }
    }
}
