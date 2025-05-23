using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Dtos.comment;
using rest_two.Models;

namespace rest_two.Dtos.stock
{
    public class StockDto
    {
         public int Id { get; set; }

        public string Symbol{ get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;


 
        public decimal Purchase { get; set; } 
       
        public decimal LastDiv{ get; set; }


        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; } 


        public List<CommentDto> Comments{ get; set; } 
    }
}