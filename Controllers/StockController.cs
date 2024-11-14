using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_two.data;
using rest_two.Dtos.stock;
using rest_two.Mappers;

namespace rest_two.Controllers
{
    [Route("/api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {

        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var stocks = await _context.Stocks.ToListAsync();
            var stockDto = stocks.Select(s=> s.ToStockDto());

            return Ok(stocks);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id){

            var stock = _context.Stocks.Find(id);

            if(stock == null){
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto createStockRequestDto){

            var stockModel = createStockRequestDto.ToStockFromCreateDto();

            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new {id = stockModel.Id},stockModel.ToStockDto());
        }


        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute]int id,[FromBody]  UpdateStockRequestDto updateStockRequestDto){

            var stockModel = _context.Stocks.FirstOrDefault(x=>x.Id == id);

            if(stockModel == null){
                return NotFound();
            }
            stockModel.Symbol=updateStockRequestDto.Symbol;
            stockModel.CompanyName=updateStockRequestDto.CompanyName;
            stockModel.Purchase=updateStockRequestDto.Purchase;
            stockModel.LastDiv=updateStockRequestDto.LastDiv;
            stockModel.Industry=updateStockRequestDto.Industry;
            stockModel.MarketCap=updateStockRequestDto.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());
        }



        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id){
            var stockModel = _context.Stocks.FirstOrDefault(x=>x.Id == id);

            if(stockModel == null){
                return NotFound();
            }


            _context.Stocks.Remove(stockModel);

            _context.SaveChanges();

            return NoContent();
        }
        
    }
}