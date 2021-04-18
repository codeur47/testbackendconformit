using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Services;
using TestProgrammationConformit.Dtos;

namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public ActionResult<CommentReadDTO> GetCommentById(int id)
        {
            if (_commentService.GetCommentById(id) != null)
            {
                return Ok(_commentService.GetCommentById(id));
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentReadDTO>> GetAllComments()
        {
            return Ok(_commentService.GetAllComments());
        }

        [HttpPost]
        public ActionResult<CommentReadDTO> CreateComment(CommentCreateDTO commentCreateDTO)
        {
            var commentReadDto = _commentService.CreateComment(commentCreateDTO);
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

            _commentService.UpdateComment(commentUpdateDTO, id);

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

            return NoContent();
        }
    }
}
