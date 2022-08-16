using Microsoft.EntityFrameworkCore;
using website_backend.Entities;

namespace website_backend.DbContexts
{
    public class WebsiteContext : DbContext
    {
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        public WebsiteContext(DbContextOptions<WebsiteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post("Dev Log 1")
                {
                    Id = 1,
                    Body = "this is dev log one",

                },
                new Post("Dev Log 2")
                {
                    Id = 2,
                    Body = "this is dev log two",

                },
                new Post("Dev Log 3")
                {
                    Id = 3,
                    Body = "this is dev log three",
                }
                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment("Really cool!")
                {
                    Id = 1,
                    PostId = 1,
                    Body = "this is better than anything I could ever do",
                },
                new Comment("Lorem ")
                {
                    Id = 2,
                    PostId = 1,
                    Body = "lorem ipsum is a sample text who cares tho",
                },
                new Comment("Lorem Log 3")
                {
                    Id = 3,
                    PostId = 1,
                    Body = "lorem ipsum is a sample text who cares tho",
                },
                new Comment("Really cool!")
                {
                    Id = 4,
                    PostId = 2,
                    Body = "this is dev log one",
                },
                new Comment("Dev Lorem 2")
                {
                    Id = 5,
                    PostId = 2,
                    Body = "this is dev log two",
                },
                new Comment("Lorem Log 3")
                {
                    Id = 6,
                    PostId = 2,
                    Body = "lorem ipsum is a sample text who cares tho",
                },
                new Comment("Really cool!")
                {
                    Id = 7,
                    PostId = 3,
                    Body = "So this is how you do it!",
                },
                new Comment("Kinda sucks")
                {
                    Id = 8,
                    PostId = 3,
                    Body = "I could do way better",
                },
                new Comment("Lorem ipsum")
                {
                    Id = 9,
                    PostId = 3,
                    Body = "lorem ipsum is a sample text who cares tho",
                }
            );
        }
    }
}
