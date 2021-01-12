using AutoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{
    public interface IBrandData
    {
        Task<string> CreateBrand(BrandModel brand);
        Task<int> DeleteBrand(string brandId);
        Task<string> UpdateBrand(BrandModel brand);
        Task<List<BrandModel>> GetBrandList();
        Task<BrandModel> GetBrandById(string brandId);

        
    }
}
