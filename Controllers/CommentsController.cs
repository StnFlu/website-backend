using AutoMapper;
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
        private readonly IWebsiteRepository _websiteInfoRepository;
        private readonly IMapper _mapper;

        public CommentsController(IWebsiteRepository websiteInfoRepository, IMapper mapper, ILogger<CommentsController> logger, IMailService mailService, PostsDataStore postsDataStore)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _websiteInfoRepository = websiteInfoRepository ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments(int postId)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                _logger.LogInformation($"Post with id {postId} not found");
                return NotFound();
            }
            var getComments = await _websiteInfoRepository.GetCommentsAsync(postId);

            return Ok(_mapper.Map<IEnumerable<CommentDto>>(getComments));
        }

        [HttpGet("{commentid}", Name = "GetComment")]
        public async Task<ActionResult<CommentDto>> GetComment(int postId, int commentId)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }
            var getComment = await _websiteInfoRepository.GetCommentAsync(postId, commentId);

            if (getComment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDto>(getComment));
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment(
           int postId,
           CommentCreationDto comment)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var finalComment = _mapper.Map<Entities.Comment>(comment);

            await _websiteInfoRepository.AddCommentForPostAsync(postId, finalComment);

            await _websiteInfoRepository.SaveChangesAsync();

            var createdCommentToReturn = _mapper.Map<Models.CommentDto>(finalComment);

            return CreatedAtRoute("GetComment",
                new
                {
                    postId = postId,
                    commentId = createdCommentToReturn.Id
                },
                createdCommentToReturn);
        }

        [HttpPut("{commentid}")]
        public async Task<ActionResult> UpdateComment(
          int postId,
          int commentId,
          CommentCreationDto comment)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }
            var commentEntity = await _websiteInfoRepository.GetCommentAsync(postId, commentId);

            if (commentEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(comment, commentEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{commentid}")]
        public async Task<ActionResult> PartiallyUpdateComment(
         int postId,
         int commentId,
         JsonPatchDocument<CommentForUpdateDto> patchComment)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var commentEntity = await _websiteInfoRepository.GetCommentAsync(postId, commentId);

            if (commentEntity == null)
            {
                return NotFound();
            }

            var commentToPatch = _mapper.Map<CommentForUpdateDto>(commentEntity);

            patchComment.ApplyTo(commentToPatch, ModelState);

            if (!TryValidateModel(commentToPatch)) return BadRequest(ModelState);

            _mapper.Map(commentToPatch, commentEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteComment(int postId, int commentId)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var commentEntity = await _websiteInfoRepository.GetCommentAsync(postId, commentId);

            if (commentEntity == null)
            {
                return NotFound();
            }
            _mailService.Send(subject: $"Post {postId} was deleted.", message: "It truly was");

            _websiteInfoRepository.DeleteComment(commentEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
