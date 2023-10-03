using CleanArichitecture.Application.DTOs.WeblogCategory;

namespace CleanArichitecture.Application.DTOs.Weblog
{
    public class WeblogDTOs
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public WeblogCategoryDTOs WeblogCategoryDTOs { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }
    }
}