using Microsoft.AspNetCore.Mvc;
using website_backend.Models;

namespace website_backend.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> GetPosts()
        {
            return Ok(PostsDataStore.Current.Posts);
        }

        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(int id)
        {
            var postToReturn = PostsDataStore.Current.Posts.
                FirstOrDefault(post => post.Id == id);
            if (postToReturn == null) return NotFound();
            return Ok(postToReturn);
        }
    }
}
