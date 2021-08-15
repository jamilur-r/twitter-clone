using System;
using Microsoft.AspNetCore.Http;

namespace API.Models.Forms
{
    public class TweetCreateForm
    {
        public string body { get; set; }
        public IFormFile img { get; set; }
        public string uid { get; set; }
    }

    public class AddTagForm
    {
        public string tag_str { get; set; }
        public Guid tid { get; set; }
    }
}