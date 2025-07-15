using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
