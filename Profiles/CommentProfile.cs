using AutoMapper;

namespace website_backend.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Entities.Comment, Models.CommentDto>();
            CreateMap<Models.CommentCreationDto, Entities.Comment>();
            CreateMap<Models.CommentForUpdateDto, Entities.Comment>();
            CreateMap<Entities.Comment, Models.CommentForUpdateDto>();

        }
    }
}
