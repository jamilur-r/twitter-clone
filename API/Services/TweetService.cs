using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Data;
using API.Models;
using API.Utility;


namespace API.Services
{
    public class TweetService
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TweetService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        public async Task<List<Tweet>> getall()
        {
            try
            {
                List<Tweet> tweets = await _context.tweets
                    .Include(t => t.Tweeter)
                    .Include(t => t.Tags)
                    .ToListAsync();
                return tweets;

            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<Tweet> getOne(Guid id)
        {
            try
            {
                Tweet tweet = await _context.tweets
                    .Where(tw => tw.TweetId == id)
                    .Include(t => t.Tags)
                    .Include(t => t.Tweeter)
                    .FirstAsync();

                return tweet;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<Tweet> create(
            string body,
            IFormFile image,
            string uid
        )
        {
            try
            {
                ApplicationUser user = await _context.Users
                    .Where(u => u.Id == uid)
                    .FirstAsync();

                if (image != null)
                {

                    Utils utils = new Utils();
                    string image_url = await utils.Upload(image, _env);
                    Tweet tweet = new Tweet
                    {
                        Body = body,
                        Tweeter = user,
                        Image = image_url
                    };
                    await _context.tweets.AddAsync(tweet);
                    await _context.SaveChangesAsync();
                    return tweet;
                }
                else
                {
                    Tweet tweet = new Tweet
                    {
                        Body = body,
                        Tweeter = user,
                    };
                    await _context.tweets.AddAsync(tweet);
                    await _context.SaveChangesAsync();
                    return tweet;
                }
            }
            catch (System.Exception)
            {

                // return null;
                throw;
            }
        }

        public async Task<Tweet> addTags(List<string> tags, Guid id)
        {
            try
            {
                Tweet tweet = await _context.tweets.Where(tw => tw.TweetId == id)
                    .Include(tw => tw.Tweeter)
                    .Include(tw => tw.Tags)
                    .FirstAsync();

                foreach (var item in tags)
                {
                    Tag tag = new Tag
                    {
                        Body = item,
                        Tweet = tweet
                    };
                    await _context.tags.AddAsync(tag);
                    tweet.Tags.Add(tag);
                }
                await _context.SaveChangesAsync();
                return tweet;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
