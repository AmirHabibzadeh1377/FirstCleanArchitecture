using AutoMapper;
using CleanArchitecture.Application.Test.Mocks.WeblogCategoryRepository;
using CleanArchitecture.Application.Test.Mocks.WeblogRepository;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Features.Handlers.Weblog.Commands;
using CleanArichitecture.Application.Features.Requests.Weblog.Commands;
using CleanArichitecture.Application.Persistance.ServiceContract;
using CleanArichitecture.Application.Profiles;
using CleanArichitecture.Application.Responses;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.Test.Weblogs.Commands
{
    public class CreateWeblogCommandTest
    {
        #region Fields 

        private readonly IMapper _mapper;
        private readonly Mock<IWeblogRepository> _mockRepo;
        private readonly Mock<IWeblogCategoryRepository> _mockCategoryRepository;
        CreateWeblogDTOs _createWeblogDto;

        #endregion

        #region Ctor

        public CreateWeblogCommandTest()
        {
            _mockRepo = WeblogMockRepository.GetWeblogRepository();
            _mockCategoryRepository = WeblogCategoryMockRepository.GetWeblogCategoryRepository();
            var  mapperConfiguration = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfiguration.CreateMapper();
            _createWeblogDto = new CreateWeblogDTOs
            {
                Name = "amir",
                Slug = "test",
                Title = "thi is title",
                WeblogCategoryId = 1
            };
        }

        #endregion

        [Fact]
        public async Task CreateWeblogTest()
        {
            var handler = new CreateWeblogHandler(_mapper,_mockRepo.Object,_mockCategoryRepository.Object);
            var result =await handler.Handle(new CreateWeblogRequest { CreateWeblogDTOs = _createWeblogDto}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

        } 
    }
}
