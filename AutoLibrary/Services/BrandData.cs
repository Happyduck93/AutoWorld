using AutoLibrary.Models;
using AutoLibrary.SqlConnectionData;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{

    /*------------------------------------------------------------------*
     * This class transfer data between MySql database and BrandModel*
     * -----------------------------------------------------------------*/
    public class BrandData : IBrandData
    {
        //field
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly SqlConnectionString _sqlConnectionString;

        //constructor 
        public BrandData(ISqlDataAccess sqlDataAccess, SqlConnectionString sqlConnectionString )
        {
            _sqlDataAccess = sqlDataAccess;
            _sqlConnectionString = sqlConnectionString;
        }

        //Create
        public async Task<string> CreateBrand(BrandModel brand)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@brandId", "", DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
            param.Add("@brandCodeId", brand.BrandCodeId);
            param.Add("@brandCodeDescr", brand.BrandCodeDescr);
            //param.Add("@categoryId", brand.CategoryId);
            param.Add("@brandName", brand.BrandName);
            param.Add("@brandDescr", brand.BrandDescr);
            param.Add("@establishment", brand.EstablishmentDate);
            param.Add("@headquarters", brand.Headquarters);

            await _sqlDataAccess.SaveData("dbo.sp_insert_brand",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
        

            return param.Get<string>("@brandId");
        }

        //Delete
        public async Task<int> DeleteBrand(string brandId)
        {
            return await _sqlDataAccess.SaveData("dbo.sp_delete_brand",
                                          new { brandId },
                                          _sqlConnectionString.SqlConnectionName);
        }

        //get BrandModel by Id
        public async Task<BrandModel> GetBrandById(string brandId)
        {
            var brand = await _sqlDataAccess.LoadData<BrandModel, dynamic>("dbo.sp_search_brand_by_id",
                                                               new { brandId },
                                                               _sqlConnectionString.SqlConnectionName);
            return brand.FirstOrDefault();
        }

    

        //get BrandModel List
        public async Task<List<BrandModel>> GetBrandList()
        {
            return await _sqlDataAccess.LoadData<BrandModel, dynamic>("dbo.sp_search_brand",
                                                               new { },
                                                               _sqlConnectionString.SqlConnectionName);
        }

        //Update
        public async Task<string> UpdateBrand(BrandModel brand)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("brandId", brand.BrandId, DbType.String, direction: ParameterDirection.InputOutput, size: int.MaxValue);
            param.Add("@brandCodeId", brand.BrandCodeId);
            //param.Add("@brandCodeDescr", brand.BrandCodeDescr);
            //param.Add("@categoryId", brand.CategoryId);
            param.Add("@brandName", brand.BrandName);
            param.Add("@brandDescr", brand.BrandDescr);
            param.Add("@establishment", brand.EstablishmentDate);
            param.Add("@headquarters", brand.Headquarters);

            await _sqlDataAccess.SaveData("dbo.sp_update_brand",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("@brandId");
        }
    }
}
