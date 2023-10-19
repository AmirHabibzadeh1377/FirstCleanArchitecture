namespace CleanArchitecture.MVC.Model.ViewModels.WeblogCategory
{
    public class UpdateWeblogCategoryVM:BaseVM
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
