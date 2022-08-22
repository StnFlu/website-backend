using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website_backend.Entities
{
    public class Post : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        public string? Body { get; set; }


        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Post(string title)
        {
            Title = title;
        }
    }
}
