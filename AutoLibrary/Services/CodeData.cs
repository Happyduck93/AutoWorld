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
     *   This class transfer data between MySql database and CodeModel  *
     * -----------------------------------------------------------------*/



    public class CodeData : ICodeData
    {
        //field
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly SqlConnectionString _sqlConnectionString;

        //constructor
        public CodeData(ISqlDataAccess sqlDataAccess, SqlConnectionString sqlConnectionString)
        {
            _sqlDataAccess = sqlDataAccess;
            _sqlConnectionString = sqlConnectionString;
        }

        //Create
        public async Task<string> CreateCode(CodeModel code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", "", DbType.String, direction: ParameterDirection.Output );
            param.Add("@categoryId", code.CategoryId);
            param.Add("@codeDescr", code.CodeDescr);

            await _sqlDataAccess.SaveData("dbo.sp_insert_code",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            
            var id = param.Get<string>("@codeId");
            return id;
        }

        //Delete
        public async Task<int> DeleteCode(string codeId, string categoryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", codeId);
            param.Add("@categoryId", categoryId);
            return await _sqlDataAccess.SaveData("dbo.sp_delete_code",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
        }

        //Update
        public async Task<string> UpdateCode(CodeModel code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", code.CodeId);
            param.Add("@categoryId", code.CategoryId);
            param.Add("@activeYn", code.ActiveYn);
            param.Add("@codeDescr", code.CodeDescr);

            await _sqlDataAccess.SaveData("dbo.sp_update_code",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("@codeId");
        }

        //Get Code List
        public async Task<List<CodeModel>> GetCodeListByCategory(string categoryId)
        {
            return await _sqlDataAccess.LoadData<CodeModel, dynamic>("dbo.sp_search_code_by_category",
                                                 new { categoryId },
                                                 _sqlConnectionString.SqlConnectionName);
        }

        //Get Code with codeId 
        public async Task<CodeModel> GetCodeById(string codeId, string categoryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", codeId);
            param.Add("@categoryId", categoryId);
            var code = await _sqlDataAccess.LoadData<CodeModel, dynamic>("dbo.sp_search_code_by_id",
                                                              param,
                                                              _sqlConnectionString.SqlConnectionName);
            return code.FirstOrDefault();

        }


        ///-------------------------------------------------------
        public async Task<List<CodeModel>> GetCodeList()
        {
            return await _sqlDataAccess.LoadData<CodeModel, dynamic>("dbo.sp_search_code",
                                                 new { },
                                                 _sqlConnectionString.SqlConnectionName);
        }


        public async Task<CodeModel> GetCategoryByCode(string codeId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", codeId);
            param.Add("@category", "", DbType.String, direction: ParameterDirection.Output);
            var category = await _sqlDataAccess.LoadData<CodeModel, dynamic>("dbo.sp_search_category_by_code",
                                                                            param,
                                                                            _sqlConnectionString.SqlConnectionName);
            return category.FirstOrDefault();
        }
    }
}
