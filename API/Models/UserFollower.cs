using System;


namespace API.Models
{
    public class UserFollower
    {
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid UserFollowersId { get; set; }
        public ApplicationUser FollowingUser { get; set; }
    }
}