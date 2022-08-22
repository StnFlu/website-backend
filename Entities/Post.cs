using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website_backend.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        public string? Body { get; set; }

        [Required]
        [MaxLength(64)]
        public string Type { get; set; }


        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Post(string title, string type)
        {
            Title = title;
            Type = type;
        }
    }
}
