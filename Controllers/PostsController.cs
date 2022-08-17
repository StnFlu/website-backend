using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using website_backend.Models;
using website_backend.Services;

namespace website_backend.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;

        private readonly IWebsiteRepository _websiteInfoRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public PostsController(IWebsiteRepository websiteInfoRepository, ILogger<CommentsController> logger, IMapper mapper, IMailService mailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _websiteInfoRepository = websiteInfoRepository ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PostWithoutCommentsDto>>> GetPosts()
        {
            var postEntities = await _websiteInfoRepository.GetPostsAsync();

            return Ok(_mapper.Map<IEnumerable<PostWithoutCommentsDto>>(postEntities));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetPost(int id, bool includeComments = false)
        {
            var post = await _websiteInfoRepository.GetPostAsync(id, includeComments);
            if (post == null) return NotFound();

            if (includeComments) return Ok(_mapper.Map<PostDto>(post));

            return Ok(_mapper.Map<PostWithoutCommentsDto>(post));
        }

        [HttpPut("{postId}")]
        public async Task<ActionResult> UpdatePost(
        int postId,
        int commentId,
        CommentCreationDto post)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var postEntity = await _websiteInfoRepository.GetPostAsync(postId, false);

            _mapper.Map(post, postEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{postId}")]

        public async Task<ActionResult> PartiallyUpdatePost(
         int postId,
         int commentId,
         JsonPatchDocument<PostForUpdateDto> patchComment)
        {
            if (!await _websiteInfoRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var postEntity = await _websiteInfoRepository.GetPostAsync(postId, false);

            var postToPatch = _mapper.Map<PostForUpdateDto>(postEntity);

            patchComment.ApplyTo(postToPatch, ModelState);

            if (!TryValidateModel(postToPatch)) return BadRequest(ModelState);

            _mapper.Map(postToPatch, postEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeletePost(int postId)
        {
            var postEntity = await _websiteInfoRepository.GetPostAsync(postId, false);
            if (postEntity == null)
            {
                return NotFound();
            }

            _mailService.Send(subject: $"Post {postId} was deleted.", message: "It truly was");

            _websiteInfoRepository.DeletePost(postEntity);

            await _websiteInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }

}
