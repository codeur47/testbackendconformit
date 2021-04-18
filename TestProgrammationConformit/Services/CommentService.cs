using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Infrastructures;
using AutoMapper;

namespace TestProgrammationConformit.Services
{
    public class CommentService : ICommentService
    {

        private readonly ConformitContext _conformitContext;
        private readonly IMapper _mapper;

        public CommentService(ConformitContext conformitContext, IMapper mapper)
        {
            _conformitContext = conformitContext;
            _mapper = mapper;
        }

        public IEnumerable<CommentReadDTO> GetAllComments()
        {
            return _mapper.Map<IEnumerable<CommentReadDTO>>(_conformitContext.Comment.ToList());
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
