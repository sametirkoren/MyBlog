using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Interfaces;
using MyBlog.Entities.Concrete;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAllSortedByPostedTimeAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _blogService.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogService.AddAsync(blog);
            return Created("", blog);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id , Blog blog)
        {
            if(id != blog.Id)
            {
                return BadRequest("geçersiz id");
            }

            await _blogService.UpdateAsync(blog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id=id });
            return NoContent();
        }
    }
}