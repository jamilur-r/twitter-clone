using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using API.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Services
{

    public class AuthService
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signinManager;
        private readonly IWebHostEnvironment _env;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _env = environment;
        }
        public async Task<ApplicationUser> signIn(string email, string password)
        {
            try
            {
                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                var result = await _signinManager.PasswordSignInAsync(user, password, true, false);
                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<ApplicationUser> signUp(string email, string password, string confirm_pass, string first_name, string last_name)
        {
            try
            {
                if (password == confirm_pass)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        Email = email,
                        UserName = email,
                        FirstName = first_name,
                        LastName = last_name,
                    };
                    ApplicationUser exists = await _userManager.FindByEmailAsync(email);
                    if (exists == null)
                    {
                        await _userManager.CreateAsync(user, password);
                        await _signinManager.SignInAsync(user, true);
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<bool> logout()
        {
            try
            {
                await _signinManager.SignOutAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public async Task<ApplicationUser> addDp(IFormFile image, string email)
        {
            try
            {

                Utils utils = new Utils();
                string image_url = await utils.Upload(image, _env);
                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();


                user.ProfilePic = image_url;
                await _userManager.UpdateAsync(user);
                return user;

            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<ApplicationUser> addBanner(IFormFile image, string email)
        {
            try
            {

                Utils utils = new Utils();
                string image_url = await utils.Upload(image, _env);

                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                user.ProfilePic = image_url;
                await _userManager.UpdateAsync(user);
                return user;

            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<ApplicationUser> follow(string email, string following_email)
        {
            try
            {
                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                ApplicationUser following = await _userManager.Users
                    .Where(u => u.Email == following_email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                user.Followeings.Add(new UserFolloweing
                {
                    User = user,
                    FollowerUser = following
                });

                following.Followers.Add(new UserFollower
                {
                    User = following,
                    FollowingUser = user,
                });

                await _userManager.UpdateAsync(user);
                await _userManager.UpdateAsync(following);

                return user;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ApplicationUser> current(string email)
        {
            try
            {
                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                return user;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<List<ApplicationUser>> allUser(string id)
        {
            try
            {
                List<ApplicationUser> users = await _userManager.Users
                    .Where(u => u.Id != id)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .ToListAsync();

                return users;

            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public async Task<ApplicationUser> getUser(string email)
        {
            try
            {
                ApplicationUser user = await _userManager.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.Tweets)
                    .Include(u => u.Followeings)
                    .Include(u => u.Followers)
                    .FirstAsync();

                return user;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

    }
}