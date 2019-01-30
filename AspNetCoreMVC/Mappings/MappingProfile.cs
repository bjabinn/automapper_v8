using System;
using AutoMapper;
namespace AspNetCoreMVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorEntity, AuthorModel>();
        }
    }
}
