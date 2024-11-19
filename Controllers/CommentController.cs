using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_two.interfaces;
using rest_two.Mappers;

namespace rest_two.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController :ControllerBase
    {

        private readonly ICommentRepository commentRepository;


        public CommentController(ICommentRepository _commentRepository){
            
            commentRepository = _commentRepository;
        }


        [HttpGet]
        public  IActionResult GetAll(){
            var comments =   commentRepository.GetAll();

            var commentDto = comments.Select(x => x.ToCommentDto());
            
            return Ok(commentDto);

            
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id){
            var comment = commentRepository.GetById(id);

            if(comment == null){
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
    }
}