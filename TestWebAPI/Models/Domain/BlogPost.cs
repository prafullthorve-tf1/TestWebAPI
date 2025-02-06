﻿namespace TestWebAPI.Models.Domain
{
    public class BlogPost
    {
        public Guid  Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImagesUrl { get; set; }
        public string UrlHandle { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }


    }
}
