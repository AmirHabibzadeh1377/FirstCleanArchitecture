namespace CleanArichitecture.Application.DTOs.Weblog
{
    public class WeblogListDTOs : BaseDTO
    {
        public string Name { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }
        public string WeblogCategoryName { get; set; }
    }
}