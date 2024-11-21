using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_two.Dtos.comment;
using rest_two.interfaces;
using rest_two.Mappers;

namespace rest_two.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController :ControllerBase
    {

        private readonly ICommentRepository commentRepository;

        private readonly IStockRepository stockRepository;


        public CommentController(ICommentRepository _commentRepository,IStockRepository _stockRepository){
            
            commentRepository = _commentRepository;
            stockRepository = _stockRepository;
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

        [HttpPost("{stockId}")]
        public IActionResult Create([FromRoute] int stockId,CreateCommentDto createCommentDto){


                if(!stockRepository.StockExists(stockId)){
                    return BadRequest("Stock does not exist");
                }

                var commentModel = createCommentDto.ToCommentFromCreate(stockId);

                commentRepository.Create(commentModel);

                return CreatedAtAction(nameof(GetById),new {id=commentModel},commentModel.ToCommentDto());

        }
    }
}