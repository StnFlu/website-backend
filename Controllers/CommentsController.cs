using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{commentid}", Name = "GetComment")]
        public ActionResult<CommentDto> GetComment(int postId, int commentId)
        {
            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null) return NotFound();

            return Ok(comment);
        }

        [HttpPost]
        public ActionResult<CommentDto> CreateComment(
          int postId,
          CommentCreationDto comment)
        {

            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var maxCommentId = PostsDataStore.Current.Posts.SelectMany(
                p => p.Comments).Max(c => c.Id);

            var finalComment = new CommentDto()
            {
                Id = ++maxCommentId,
                Title = comment.Title,
                Body = comment.Body
            };

            post.Comments.Add(finalComment);

            return CreatedAtRoute("GetComment",
                new
                {
                    postId = postId,
                    commentId = finalComment.Id
                },
                finalComment);
        }
        [HttpPut("{commentid}")]
        public ActionResult UpdateComment(
          int postId,
          int commentId,
          CommentCreationDto comment)
        {

            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var commentFromStore = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null) return NotFound();

            commentFromStore.Title = comment.Title;
            commentFromStore.Body = comment.Body;

            return NoContent();

        }

        [HttpPatch("{commentid}")]
        public ActionResult PartiallyUpdateComment(
         int postId,
         int commentId,
         JsonPatchDocument<CommentForUpdateDto> patchComment)
        {

            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var commentFromStore = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null) return NotFound();

            var commentToPatch = new CommentForUpdateDto()
            {
                Title = commentFromStore.Title,
                Body = commentFromStore.Body,
            };

            patchComment.ApplyTo(commentToPatch, ModelState);

            if (!TryValidateModel(commentToPatch)) return BadRequest(ModelState);

            commentFromStore.Title = commentToPatch.Title;
            commentFromStore.Body = commentToPatch.Body;

            return NoContent();

        }

        [HttpDelete("{commentId}")]
        public ActionResult DeleteComment(int postId, int commentId)
        {
            var post = PostsDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var commentFromStore = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null) return NotFound();

            post.Comments.Remove(commentFromStore);
            return NoContent();
        }
    }
}
