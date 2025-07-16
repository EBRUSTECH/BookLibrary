
using AutoMapper;
using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Domain.Data;

namespace LibraryManagementSystem.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
