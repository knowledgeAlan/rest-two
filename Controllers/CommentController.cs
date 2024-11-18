using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_two.interfaces;

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
        public async Task<IActionResult> GetAll(){
            var comment = await commentRepository.GetAllAsync();
        }
    }
}