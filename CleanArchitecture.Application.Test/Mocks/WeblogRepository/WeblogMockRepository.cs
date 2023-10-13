using CleanArchitecture.Domain.Entities.Weblog;
using CleanArichitecture.Application.Persistance.ServiceContract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Test.Mocks.WeblogRepository
{
    public static class WeblogMockRepository
    {
        public static Mock<IWeblogRepository> GetWeblogRepository()
        {
            var weblogs = new List<Weblog>();
            var mockRepo = new Mock<IWeblogRepository>();
            mockRepo.Setup(w => w.Get()).ReturnsAsync(weblogs);

            mockRepo.Setup(w => w.Add(It.IsAny<Weblog>())).ReturnsAsync((Weblog weblog) =>
            {
                weblogs.Add(weblog);
                return weblog;
            });

            return mockRepo;
        }
    }
}
