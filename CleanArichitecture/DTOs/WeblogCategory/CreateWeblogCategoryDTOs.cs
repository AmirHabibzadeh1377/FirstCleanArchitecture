﻿namespace CleanArichitecture.Application.DTOs.WeblogCategory
{
    public class CreateWeblogCategoryDTOs:IWeblogCategoryDTOs
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}