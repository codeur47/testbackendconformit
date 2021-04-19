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

        Comment GetCommentById(int id);
        IEnumerable<Comment> GetAllComments();
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}
