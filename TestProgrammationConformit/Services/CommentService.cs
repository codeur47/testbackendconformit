using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Infrastructures;
using AutoMapper;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services
{
    public class CommentService : ICommentService
    {
        private readonly ConformitContext _conformitContext;

        public CommentService(ConformitContext conformitContext)
        {
            _conformitContext = conformitContext;
        }

        public void CreateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            _conformitContext.Comment.Add(comment);
        }

        public void DeleteComment(int id)
        {
            _conformitContext.Comment.Remove(_conformitContext.Comment.FirstOrDefault(c => c.CommentId == id));
            SaveChanges();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _conformitContext.Comment.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _conformitContext.Comment.FirstOrDefault(c => c.CommentId == id);
        }

        

        public bool SaveChanges()
        {
            return (_conformitContext.SaveChanges() >= 0);
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
