using CleanArchitecture.Domain.Entities.Weblog;
using CleanArichitecture.Application.Persistance.ServiceContract;
using Moq;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Test.Mocks.WeblogCategoryRepository
{
    public static class WeblogCategoryMockRepository
    {
        public static Mock<IWeblogCategoryRepository> GetWeblogCategoryRepository()
        {
            var weblogCategories = new List<WeblogCategory>();
            var mockRepo =new  Mock<IWeblogCategoryRepository>();
            mockRepo.Setup(m => m.Get()).ReturnsAsync(weblogCategories);

            return mockRepo;
        }
    }
}
