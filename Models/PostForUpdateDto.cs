using System.ComponentModel.DataAnnotations;

namespace website_backend.Models
{
    public class PostCreationDto
    {
        [Required(ErrorMessage = "You should provide a title.")]
        [MaxLength(64)]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "You should provide a type.")]
        [MaxLength(64)]
        public string Type { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Body { get; set; }

    }
}
