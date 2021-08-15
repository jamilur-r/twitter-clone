using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace API.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [DataType(DataType.Upload)]
        public string ProfilePic { get; set; }

        [DataType(DataType.Upload)]
        public string ProfileBanner { get; set; }

        public ICollection<Tweet> Tweets { get; set; }

        public ICollection<UserFolloweing> Followeings { get; set; }
        public ICollection<UserFollower> Followers { get; set; }
    }
}