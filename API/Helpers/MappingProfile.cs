using API.Data;
using API.Models.BookModels;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookIndexM>().ReverseMap();
            CreateMap<BookAuthor, TestM>().ReverseMap();
        }
    }
}
