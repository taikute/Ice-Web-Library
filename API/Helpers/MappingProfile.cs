using API.Data;
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
            CreateMap<Book, BookEditModel>().ReverseMap();
            CreateMap<Book, BookSearchModel>().ReverseMap();
            CreateMap<BookCreateModel, Book>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Publisher, PublisherModel>().ReverseMap();
        }
    }
}
