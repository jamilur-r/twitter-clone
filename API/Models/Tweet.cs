using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Tweet
    {
        public Guid TweetId { get; set; }

        [Required]
        [StringLength(300)]
        public string Body { get; set; }

        [DataType(DataType.Upload)]
        public string Image { get; set; }

        public string UserForeignKey { get; set; }
        [ForeignKey("UserForeignKey")]
        public ApplicationUser Tweeter { get; set; }

        public ICollection<Tag> Tags { get; set; }

    }
}