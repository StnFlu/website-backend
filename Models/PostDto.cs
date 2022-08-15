﻿namespace website_backend.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Body { get; set; }

        public int NumberOfComments
        {
            get
            {
                return Comments.Count;
            }
        }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}
