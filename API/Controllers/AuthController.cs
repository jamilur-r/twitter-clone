using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using API.Models;
using API.Services;
using System.Threading.Tasks;
using API.Models.Forms;

namespace API.Controllers
{

    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signinManager;
        private AuthService _service;
        public AuthController(
                IWebHostEnvironment environment,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _env = environment;
            _userManager = userManager;
            _signinManager = signInManager;
            _service = new AuthService(_userManager, _signinManager, _env);
        }


        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> signin([FromBody] SignInForm form)
        {
            try
            {
                return Ok(await _service.signIn(form.email, form.password));
            }
            catch (System.Exception)
            {

                return StatusCode(406, new
                {
                    Message = "Something bad happend"
                });
            }
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup([FromBody] SignUpForm form)
        {
            try
            {
                return Ok(await _service.signUp(form.email, form.password, form.confirm_pass, form.first_name, form.last_name));
            }
            catch (System.Exception)
            {

                return StatusCode(406, new
                {
                    Message = "Something bad happend"
                });
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            try
            {
                if (await _service.logout())
                {
                    return Ok();
                }
                else
                {
                    return Problem("Not sure what went wrong");
                }
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");
            }
        }


        [HttpPost]
        [Route("add/dp")]
        [Authorize]
        public async Task<IActionResult> addDp([FromForm] DpUpload form)
        {
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                return Ok(await _service.addDp(form.file, user.Email));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");
            }
        }

        [HttpPost]
        [Route("add/banner")]
        [Authorize]
        public async Task<IActionResult> addbanner([FromForm] BannerUpload form)
        {
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                return Ok(await _service.addBanner(form.file, user.Email));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");
            }
        }

        [HttpPost]
        [Route("follow")]
        [Authorize]
        public async Task<IActionResult> follow([FromBody] FollowForm form)
        {
            try
            {
                return Ok(await _service.follow(form.user_email, form.follower_email));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");
            }
        }

        [HttpGet]
        [Route("current")]
        [Authorize]
        public async Task<IActionResult> current()
        {
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                return Ok(await _service.current(user.Email));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");

            }
        }

        [HttpGet]
        [Route("get/user")]
        [Authorize]
        public async Task<IActionResult> getUser([FromBody]string email)
        {
            try
            {
                return Ok(await _service.getUser(email));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");

            }
        }

        [HttpGet]
        [Route("get/all")]
        [Authorize]
        public async Task<IActionResult> getall()
        {
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

                return Ok(await _service.allUser(user.Id));
            }
            catch (System.Exception)
            {

                return Problem("Not sure what went wrong");

            }
        }
    }
}