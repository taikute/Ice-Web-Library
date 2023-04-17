using API.Data;
using API.Data.Models;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, BookIndexModel>().ReverseMap();           
            CreateMap<Book, BookBaseModel>().ReverseMap();
            CreateMap<Book, BookSearchModel>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Publisher, PublisherModel>().ReverseMap();
        }
    }
}
