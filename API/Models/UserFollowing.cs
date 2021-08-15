using System;


namespace API.Models
{
    public class UserFolloweing
    {
        public Guid Id {get; set;}
        public Guid UserFollowingId {get; set;}
        public Guid ApplicationUserId {get; set;}
        public ApplicationUser User {get; set;}

        public Guid UserFolloweringId {get; set;}
        public ApplicationUser FollowerUser {get; set;}
    }
}