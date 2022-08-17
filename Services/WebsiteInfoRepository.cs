using Microsoft.EntityFrameworkCore;
using website_backend.DbContexts;
using website_backend.Entities;

namespace website_backend.Services
{
    public class WebsiteInfoRepository : IWebsiteRepository
    {

        private readonly WebsiteContext _context;

        public WebsiteInfoRepository(WebsiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostAsync(int postId, bool includeComments)
        {
            if (includeComments) return await _context.Posts.Include(p => p.Comments).Where(p => p.Id == postId).FirstOrDefaultAsync();

            return await _context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task<bool> PostExistsAsync(int postId)
        {
            return await _context.Posts.AnyAsync(p => p.Id == postId);
        }

        public async Task<IEnumerable<Comment?>> GetCommentsAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();

        }

        public async Task<Comment?> GetCommentAsync(int postId, int commentId)
        {
            return await _context.Comments.Where(c => c.Id == commentId && c.PostId == postId).FirstOrDefaultAsync();
        }

        public async Task AddCommentForPostAsync(int postId, Comment comment)
        {
            var post = await GetPostAsync(postId, false);
            if (post != null)
            {
                post.Comments.Add(comment);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 1);
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}
