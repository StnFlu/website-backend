using website_backend.Entities;

namespace website_backend.Services
{
    public interface IWebsiteRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task<Post?> GetPostAsync(int postId, bool includeComments);

        Task<bool> PostExistsAsync(int postId);

        void DeletePost(Post post);


        Task<IEnumerable<Comment?>> GetCommentsAsync(int postId);

        Task<Comment?> GetCommentAsync(int postId, int commentId);

        Task AddCommentForPostAsync(int postId, Comment comment);

        void DeleteComment(Comment comment);

        Task<bool> SaveChangesAsync();
    }
}
