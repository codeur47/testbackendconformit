using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Services;
using TestProgrammationConformit.Dtos;
using AutoMapper;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public ActionResult<CommentReadDTO> GetCommentById(int id)
        {
            var commentItem = _commentService.GetCommentById(id);
            if (commentItem != null)
            {
                return Ok(_mapper.Map<CommentReadDTO>(commentItem));
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentReadDTO>> GetAllComments()
        {
            var commentItems = _commentService.GetAllComments();
            return Ok(_mapper.Map<IEnumerable<CommentReadDTO>>(commentItems));
        }

        [HttpPost]
        public ActionResult<CommentReadDTO> CreateComment(CommentCreateDTO commentCreateDTO)
        {
            var commentModel = _mapper.Map<Comment>(commentCreateDTO);

            _commentService.CreateComment(commentModel);
            _commentService.SaveChanges();

            var commentReadDto = _mapper.Map<CommentReadDTO>(commentModel);

            return CreatedAtRoute(nameof(GetCommentById), new { Id = commentReadDto.CommentId }, commentReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, CommentUpdateDTO commentUpdateDTO)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            _mapper.Map(commentUpdateDTO, comment);

            _commentService.UpdateComment(comment);

            _commentService.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            _commentService.DeleteComment(id);
            _commentService.SaveChanges();

            return NoContent();
        }
    }
}
