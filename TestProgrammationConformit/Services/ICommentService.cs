using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;

namespace TestProgrammationConformit.Services
{
    public interface ICommentService
    {
        bool SaveChanges();

        IEnumerable<CommentReadDTO> GetAllComments();
    }
}
