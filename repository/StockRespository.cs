using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.Internal;
using rest_two.data;
using rest_two.Dtos.stock;
using rest_two.helpers;
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
           var stockModel =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null){
                return null;
            }


            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;


        }

        public  List<Stock> GetAll(QueryObject queryObject)
        {
            return  _context.Stocks.Include(c=>c.Comments).ToList();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public bool StockExists(int id)
        {
             return _context.Stocks.Any(s=>s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto)
        {
            var existStockModel = await _context.Stocks.FirstOrDefaultAsync(x=> x.Id==id);

            if(existStockModel == null){
                return null;
            }

            existStockModel.Symbol=stockRequestDto.Symbol;
            existStockModel.CompanyName=stockRequestDto.CompanyName;
            existStockModel.Purchase=stockRequestDto.Purchase;
            existStockModel.LastDiv=stockRequestDto.LastDiv;
            existStockModel.Industry=stockRequestDto.Industry;
            existStockModel.MarketCap=stockRequestDto.MarketCap;

            await _context.SaveChangesAsync();
            return existStockModel;
        }
    }
}