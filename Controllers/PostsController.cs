using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using website_backend.Models;
using website_backend.Services;

namespace website_backend.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IWebsiteRepository _websiteInfoRepository;
        private readonly IMapper _mapper;

        public PostsController(IWebsiteRepository websiteInfoRepository, IMapper mapper)
        {
            _websiteInfoRepository = websiteInfoRepository ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(websiteInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostWithoutCommentsDto>>> GetPosts()
        {
            var postEntities = await _websiteInfoRepository.GetPostsAsync();

            return Ok(_mapper.Map<IEnumerable<PostWithoutCommentsDto>>(postEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id, bool includeComments = false)
        {
            var post = await _websiteInfoRepository.GetPostAsync(id, includeComments);
            if (post == null) return NotFound();

            if (includeComments) return Ok(_mapper.Map<PostDto>(post));

            return Ok(_mapper.Map<PostWithoutCommentsDto>(post));
        }


    }
}
