using Microsoft.AspNetCore.Mvc;
using website_backend.Models;

namespace website_backend.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly PostsDataStore _postsDataStore;


        public PostsController(PostsDataStore postsDataStore)
        {
            _postsDataStore = postsDataStore ?? throw new ArgumentNullException(nameof(postsDataStore));

        }

        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> GetPosts()
        {
            return Ok(_postsDataStore.Posts);
        }

        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(int id)
        {
            var postToReturn = _postsDataStore.Posts.
                FirstOrDefault(post => post.Id == id);
            if (postToReturn == null) return NotFound();
            return Ok(postToReturn);
        }


    }
}
