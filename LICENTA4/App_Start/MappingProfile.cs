using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LICENTA4.Dtos;
using LICENTA4.Models;

namespace LICENTA4.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
        }
    }
}