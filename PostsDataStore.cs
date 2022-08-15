using website_backend.Models;
namespace website_backend
{
    public class PostsDataStore
    {
        public List<PostDto> Posts { get; set; }

        public static PostsDataStore Current { get; } = new PostsDataStore();

        public PostsDataStore()
        {
            Posts = new List<PostDto>()
            {
                new PostDto()
                {
                    Id = 1,
                    Title = "Dev Log 1",
                    Body = "this is dev log one",
                    Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 1,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                         new CommentDto()
                        {
                            Id = 2,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                    }
                },
                 new PostDto()
                {
                    Id =2,
                    Title = "Dev Log 2",
                    Body = "this is dev log two",
                      Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 1,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                         new CommentDto()
                        {
                            Id = 2,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                    }
                },
                  new PostDto()
                {
                    Id = 3,
                    Title = "Dev Log 3",
                    Body = "this is dev log three",
                      Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 1,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                         new CommentDto()
                        {
                            Id = 2,
                            Title = "u sure",
                            Body = "it's too cool"
                        },
                    }
                },
            };
        }
    }
}
