using Microsoft.EntityFrameworkCore;
using website_backend.Entities;

namespace website_backend.DbContexts
{
    public class WebsiteContext : DbContext
    {
        private readonly ILogger<WebsiteContext> _logger;


        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        public WebsiteContext(DbContextOptions<WebsiteContext> options, ILogger<WebsiteContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post("Dev Log 1", "Dev Log")
                {
                    Id = 1,
                    Body = "this is dev log one",

                },
                new Post("Dev Log 2", "Dev Log")
                {
                    Id = 2,
                    Body = "this is dev log two",
                },
                new Post("Dev Log 3", "Dev Log")
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

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {

            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;
            _logger.LogInformation(utcNow.ToString());

            foreach (var entry in entries)
            {
                _logger.LogInformation(entry.ToString());

                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = utcNow;
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            break;
                    }
                }
            }
        }
    }
}
