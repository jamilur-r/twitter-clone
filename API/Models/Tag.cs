using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace API.Models
{
    public class Tag
    {

        public Guid TagId { get; set; }

        [Required]
        public string Body { get; set; }

        public Guid TweetId { get; set; }
        [ForeignKey("TweetId")]
        public Tweet Tweet { get; set; }
    }
}