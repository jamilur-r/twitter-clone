using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using API.Data;
using API.Services;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using API.Models.Forms;



namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("tweet")]
    public class TweetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private TweetService _service;
        public TweetController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
            _service = new TweetService(_context, environment);
        }


        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> getOne([FromBody] Guid id)
        {
            try
            {
                return Ok(await _service.getOne(id));
            }
            catch (System.Exception)
            {

                return Problem("Error");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("all")]
        public async Task<IActionResult> getall()
        {
            try
            {
                return Ok(await _service.getall());
            }
            catch (System.Exception)
            {

                return Problem("Error");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("new")]
        public async Task<IActionResult> create([FromForm] TweetCreateForm form)
        {
            try
            {

                return Ok(await _service.create(form.body, form.img, form.uid));
            }
            catch (System.Exception)
            {

                return Problem("ERROR");
                // throw;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("new/tag")]
        public async Task<IActionResult> addTag([FromBody] AddTagForm form)
        {
            try
            {
                List<string> tags = new List<string>();
                foreach (var item in form.tag_str.Split(','))
                {
                    tags.Add(item);
                }
                return Ok(await _service.addTags(tags, form.tid));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}