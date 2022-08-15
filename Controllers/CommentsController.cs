using Microsoft.AspNetCore.Mvc;
using website_backend.Models;

namespace website_backend.Controllers
{
    [Route("api/posts/{postId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> GetComments(int postId)
        {
            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);

            if (post == null) return NotFound();


            return Ok(post.Comments);
        }

        [HttpGet("{commentid}")]
        public ActionResult<CommentDto> GetComment(int postId, int commentId)
        {
            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null) return NotFound();

            return Ok(comment);
        }
    }
}
