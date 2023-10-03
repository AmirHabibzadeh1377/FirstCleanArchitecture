﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Weblog
{
    public class WeblogCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}