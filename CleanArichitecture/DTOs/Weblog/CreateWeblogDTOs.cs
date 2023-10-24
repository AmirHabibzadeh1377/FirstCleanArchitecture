using CleanArichitecture.Application.DTOs.WeblogCategory;

namespace CleanArichitecture.Application.DTOs.Weblog
{
    public class CreateWeblogDTOs:IWeblogDTOs
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}