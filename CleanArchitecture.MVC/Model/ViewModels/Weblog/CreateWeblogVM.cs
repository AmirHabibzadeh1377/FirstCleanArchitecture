using CleanArchitecture.MVC.Model.ViewModels.WeblogCategory;

namespace CleanArchitecture.MVC.Model.ViewModels.Weblog
{
    public class CreateWeblogVM
    {
        #region Ctor

        public CreateWeblogVM()
        {
            WeblogCategoryVMs = new List<WeblogCategoryVM>();
        }

        #endregion

        public string Name { get; set; }
        public string Slug { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }

        #region List Properties

        public List<WeblogCategoryVM> WeblogCategoryVMs{ get; set; }

        #endregion
    }
}
