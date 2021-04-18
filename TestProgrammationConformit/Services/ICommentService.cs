using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services
{
    public interface ICommentService
    {
        bool SaveChanges();

        CommentReadDTO GetCommentById(int id);
        IEnumerable<CommentReadDTO> GetAllComments();
        CommentReadDTO CreateComment(CommentCreateDTO commentCreateDTO);
        void UpdateComment(CommentUpdateDTO commentUpdateDTO, int id);
        void DeleteComment(int id);
    }
}
