using System.ComponentModel.DataAnnotations;

namespace website_backend.Models
{
    public class CommentForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a title.")]
        [MaxLength(64)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Body { get; set; }


    }
}
