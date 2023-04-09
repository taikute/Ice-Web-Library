using API.Data;
using API.Models.BookModels;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        MappingProfile() 
        {
            CreateMap<Book, BookIndexM>();

        }
    }
}
