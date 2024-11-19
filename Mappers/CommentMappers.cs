using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Dtos.comment;
using rest_two.Models;

namespace rest_two.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel){
            
            return new CommentDto

                {
                    Id = commentModel.Id,
                    Title= commentModel.Title,
                    Content = commentModel.Content,
                    CreatedOn = commentModel.CreatedOn,
                    StockId = commentModel.StockId
                }
            ;
        }
    }
}