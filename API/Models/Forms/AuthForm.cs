using System;
using Microsoft.AspNetCore.Http;


namespace API.Models.Forms
{
    public class SignInForm{
        public string email { get; set; }
        public string password { get; set; }
    }

    public class SignUpForm{
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string confirm_pass { get; set; }
    }

    public class DpUpload {
        public IFormFile file { get; set; }
    }

    public class BannerUpload {
        public IFormFile file { get; set; }
    }

    public class FollowForm {
        public string user_email { get; set; }
        public string follower_email { get; set; }
    }

    
}