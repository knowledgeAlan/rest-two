using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_two.data;
using rest_two.Dtos.stock;
using rest_two.interfaces;
using rest_two.Mappers;

namespace rest_two.Controllers
{
    [Route("/api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {

        private readonly ApplicationDBContext _context;
        
        private readonly IStockRepository stockRepository;


        public StockController(ApplicationDBContext context,IStockRepository iStockRepository){
            _context = context;
            stockRepository = iStockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var stocks = await stockRepository.GetAllAsync();
            var stockDto = stocks.Select(s=> s.ToStockDto());

            return Ok(stocks);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute]int id){

            var stock = await stockRepository.GetByIdAsync(id);

            if(stock == null){
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockRequestDto){

            var stockModel = createStockRequestDto.ToStockFromCreateDto();

            await stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById),new {id = stockModel.Id},stockModel.ToStockDto());
        }


        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]  UpdateStockRequestDto updateStockRequestDto){

            var stockModel = await stockRepository.UpdateAsync(id, updateStockRequestDto);

            if(stockModel == null){
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }



        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel = await stockRepository.DeleteAsync(id);

            if(stockModel == null){
                return NotFound();
            }


            _context.Stocks.Remove(stockModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}