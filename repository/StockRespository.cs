using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rest_two.data;
using rest_two.Dtos.stock;
using rest_two.interfaces;
using rest_two.Models;

namespace rest_two.repository
{
    public class StockRespository : IStockRepository
    {

        private readonly ApplicationDBContext _context;

        public StockRespository(ApplicationDBContext context)
        {
            _context = context;
        }

        public  async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);

            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
           var stockModel =await _context.Stocks.FirstOrDefaultAsync(x -> x.Id == id);

            if(stockModel == null){
                return null;
            }


            _context.Stocks.Remove(stockModel);
            await _context.SaveChanges();

            return stockModel;


        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return  _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync()
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto)
        {
            var existStockModel = await _context.Stocks.FirstOrDefaultAsync(x-> x.id==id);

            if(existStockModel == null){
                return null;
            }

             stockModel.Symbol=stockRequestDto.Symbol;
            stockModel.CompanyName=stockRequestDto.CompanyName;
            stockModel.Purchase=stockRequestDto.Purchase;
            stockModel.LastDiv=stockRequestDto.LastDiv;
            stockModel.Industry=stockRequestDto.Industry;
            stockModel.MarketCap=stockRequestDto.MarketCap;
        }
    }
}