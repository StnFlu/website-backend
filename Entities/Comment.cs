using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website_backend.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Title { get; set; }
        [MaxLength(512)]
        public string? Body { get; set; }

        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int PostId { get; set; }

        public Comment(string title)
        {
            Title = title;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
    }
}
