namespace CleanArichitecture.Application.DTOs.Weblog
{
    public interface IWeblogDTOs
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }
    }
}