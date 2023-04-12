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
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<Book, BookDetailModel>();
        }
    }
}
