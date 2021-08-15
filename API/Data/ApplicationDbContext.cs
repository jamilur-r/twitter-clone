using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using API.Models;


namespace API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasMany(s => s.Followers).WithOne(s => s.FollowingUser);
            builder.Entity<ApplicationUser>().HasMany(s => s.Followeings).WithOne(s => s.FollowerUser);
            /*few configurations unrelated to UserFollower entity*/
        }
        public DbSet<Tag> tags { get; set; }
        public DbSet<Tweet> tweets { get; set; }
        public DbSet<UserFollower> followers { get; set; }
        public DbSet<UserFolloweing> followeings { get; set; }
    }
}

