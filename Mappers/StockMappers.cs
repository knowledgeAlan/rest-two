using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Dtos.stock;
using rest_two.Models;


namespace rest_two.Mappers
{
    public static class StockMappers
    {
        

        public static  StockDto ToStockDto(this Stock stockModel){
                return new StockDto{
                        Id = stockModel.Id,
                        Symbol = stockModel.Symbol,
                        CompanyName = stockModel.CompanyName,
                        Purchase = stockModel.Purchase,
                        LastDiv = stockModel.LastDiv,
                        Industry = stockModel.Industry,
                        MarketCap = stockModel.MarketCap,
                };
        }
    }
}