using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using website_backend.Models;
using website_backend.Services;

namespace website_backend.Controllers
{
    [Route("api/posts/{postId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ILogger<CommentsController> _logger;
        private readonly IMailService _mailService;
        private readonly PostsDataStore _postsDataStore;

        public CommentsController(ILogger<CommentsController> logger, IMailService mailService, PostsDataStore postsDataStore)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _postsDataStore = postsDataStore ?? throw new ArgumentNullException(nameof(postsDataStore));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> GetComments(int postId)
        {
            try
            {
                var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
                if (post == null)
                {
                    _logger.LogInformation($"Post with id {postId} not found");
                    return NotFound();
                }
                return Ok(post.Comments);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting post {postId}", ex);
                return StatusCode(500, "A problem happened while handling your request");

            }
        }

        [HttpGet("{commentid}", Name = "GetComment")]
        public ActionResult<CommentDto> GetComment(int postId, int commentId)
        {
            try
            {
                var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
                if (post == null) return NotFound();

                var comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
                if (comment == null) return NotFound();

                return Ok(comment);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting post {postId}", ex);
                return StatusCode(500, "A problem happened while handling your request");

            }
        }

        [HttpPost]
        public ActionResult<CommentDto> CreateComment(
          int postId,
          CommentCreationDto comment)
        {

            var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var maxCommentId = _postsDataStore.Posts.SelectMany(
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

            var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
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

            var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
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
            var post = _postsDataStore.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound();

            var commentFromStore = post.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null) return NotFound();
            _mailService.Send(subject: $"Post {postId} was deleted.", message: "It truly was");
            post.Comments.Remove(commentFromStore);
            return NoContent();
        }
    }
}
