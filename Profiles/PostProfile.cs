using AutoMapper;

namespace website_backend.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Entities.Post, Models.PostWithoutCommentsDto>();
            CreateMap<Entities.Post, Models.PostDto>();
            CreateMap<Models.PostCreationDto, Entities.Post>();
            CreateMap<Models.PostForUpdateDto, Entities.Post>();
            CreateMap<Entities.Post, Models.PostForUpdateDto>();
        }
    }
}
