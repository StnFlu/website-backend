namespace website_backend.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Body { get; set; }

    }
}
