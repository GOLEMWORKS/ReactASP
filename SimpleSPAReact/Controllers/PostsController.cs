using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSPAReact.Models;
using SimpleSPAReact.Services.Interfaces;

namespace SimpleSPAReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostService _postService;
        
        [HttpPost]
        public PostModel Create(PostModel model)
        {
            return _postService.Create(model);   
        }
        
        [HttpPatch]
        public PostModel Update(PostModel model)
        {
            return _postService.Update(model);
        }
        
        [HttpGet("{id}")]
        public PostModel Get(int id)
        {
            return _postService.Get(id);
        }
        
        [HttpGet]
        public IEnumerable<PostModel> GetAll()
        {
            return _postService.Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { 
            _postService.Delete(id);
            return Ok();
        }
    }
}
