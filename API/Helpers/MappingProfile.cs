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
            CreateMap<Book, BookEditModel>().ReverseMap();
        }
    }
}
