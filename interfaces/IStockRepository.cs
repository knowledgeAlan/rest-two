using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Dtos.stock;
using rest_two.Models;

namespace rest_two.interfaces
{
    public interface IStockRepository
    {
        List<Stock> GetAllAsync();

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stockModel);


        Task<Stock?> UpdateAsync(int id,UpdateStockRequestDto stockRequestDto);


        Task<Stock?> DeleteAsync(int id);


    }
}