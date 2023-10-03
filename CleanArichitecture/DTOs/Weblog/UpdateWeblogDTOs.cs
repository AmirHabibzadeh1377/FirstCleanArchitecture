using CleanArichitecture.Application.DTOs.WeblogCategory;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CleanArichitecture.Application.DTOs.Weblog
{
    public class UpdateWeblogDTOs:BaseDTO,IWeblogDTOs
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int WeblogCategoryId { get; set; }
        public string Title { get; set; }
    }
}