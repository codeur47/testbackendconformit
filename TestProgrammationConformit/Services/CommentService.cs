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
        private readonly IMapper _mapper;

        public CommentService(ConformitContext conformitContext, IMapper mapper)
        {
            _conformitContext = conformitContext;
            _mapper = mapper;
        }

        public CommentReadDTO CreateComment(CommentCreateDTO commentCreateDTO)
        {
            if (commentCreateDTO == null)
                throw new ArgumentNullException(nameof(commentCreateDTO));

            var comment = _mapper.Map<Comment>(commentCreateDTO);
            _conformitContext.Add(comment);
            SaveChanges();
            if (SaveChanges())
                return _mapper.Map<CommentReadDTO>(comment);
            throw new Exception("Failed to save data");     
        }

        public void DeleteComment(int id)
        {
            _conformitContext.Comment.Remove(_conformitContext.Comment.FirstOrDefault(c => c.CommentId == id));
            SaveChanges();
        }

        public IEnumerable<CommentReadDTO> GetAllComments()
        {
            return _mapper.Map<IEnumerable<CommentReadDTO>>(_conformitContext.Comment.ToList());
        }

        public CommentReadDTO GetCommentById(int id)
        {
            return _mapper.Map<CommentReadDTO>(_conformitContext.Comment.FirstOrDefault(c => c.CommentId == id));
        }

        public void UpdateComment(CommentUpdateDTO commentUpdateDTO, int id)
        {
            var comment = _conformitContext.Comment.FirstOrDefault(c => c.CommentId == id);
            comment.Date = commentUpdateDTO.Date;
            comment.EventFK = commentUpdateDTO.EventFK;
            comment.Title = commentUpdateDTO.Title;
            _conformitContext.Update(comment);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_conformitContext.SaveChanges() >= 0);
        }
    }
}
