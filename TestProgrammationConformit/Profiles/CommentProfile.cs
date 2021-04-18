using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Dtos;

namespace TestProgrammationConformit.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReadDTO>();
            CreateMap<CommentCreateDTO, Comment>();
            CreateMap<CommentUpdateDTO, Comment>();
        }
    }
}
