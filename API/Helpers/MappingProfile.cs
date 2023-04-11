using API.Data;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookIndexModel>();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Book, BookDetailModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.AuthorName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.CategoryName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher!.PublisherName));
        }
    }
}
