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
    public class AutoData : IAutoData
    {
        //field
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly SqlConnectionString _sqlConnectionString;

        //constructor
        public AutoData(ISqlDataAccess sqlDataAccess, SqlConnectionString sqlConnectionString)
        {
            _sqlDataAccess = sqlDataAccess;
            _sqlConnectionString = sqlConnectionString;
        }

        //Crete auto
        public async Task<string> CreateAuto(AutoModel auto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@autoId", "", DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
            param.Add("@autoName", auto.AutoName);
            param.Add("@autoDescr", auto.AutoDescr);
            param.Add("@released", auto.ReleasedDate);
            param.Add("@trim", auto.Trim);
            param.Add("@price", auto.Price);
            param.Add("@color", auto.Color);
            param.Add("@year", auto.Year);
            param.Add("@brandId", auto.BrandId);
            param.Add("@autoType", auto.AutoType);

            await _sqlDataAccess.SaveData("dbo.sp_insert_auto",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("@autoId");
        }

        //Delete 
        public async Task<int> DeleteAuto(string autoId)
        {
            return await _sqlDataAccess.SaveData("dbo.sp_delete_auto",
                                                    new { autoId },
                                                    _sqlConnectionString.SqlConnectionName);
            
        }

        public async Task<AutoModel> GetAutoById(string autoId)
        {
            var auto = await _sqlDataAccess.LoadData<AutoModel, dynamic>("dbo.sp_search_auto_by_id",
                                                              new { autoId },
                                                              _sqlConnectionString.SqlConnectionName);
            return auto.FirstOrDefault();
        }

        public async Task<List<AutoModel>> GetAutoList()
        {
            return await _sqlDataAccess.LoadData<AutoModel, dynamic>("dbo.sp_search_auto",
                                                              new { },
                                                              _sqlConnectionString.SqlConnectionName);

        }

       

        public async Task<string> UpdateAuto(AutoModel auto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@autoId", "", DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
            param.Add("@autoName", auto.AutoName);
            param.Add("@autoDescr", auto.AutoDescr);
            param.Add("@released", auto.ReleasedDate);
            param.Add("@trim", auto.Trim);
            param.Add("@price", auto.Price);
            param.Add("@color", auto.Color);
            param.Add("@year", auto.Year);
            param.Add("@brandId", auto.BrandId);
            param.Add("@autoType", auto.AutoType);

            await _sqlDataAccess.SaveData("dbo.sp_update_auto",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("@autoId");
        }




    }
}
