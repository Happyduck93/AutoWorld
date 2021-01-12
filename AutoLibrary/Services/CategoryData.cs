
using AutoLibrary.Models;
using AutoLibrary.SqlConnectionData;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{

    /*------------------------------------------------------------------*
     * This class transfer data between MySql database and CategoryModel*
     * -----------------------------------------------------------------*/    

    public class CategoryData : ICategoryData
    {
        //field
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly SqlConnectionString _sqlConnectionString;

        //constructor
        public CategoryData(ISqlDataAccess sqlDataAccess, SqlConnectionString sqlConnectionString )
        {
            _sqlDataAccess = sqlDataAccess;
            _sqlConnectionString = sqlConnectionString;
        }

        //create
        public async Task<string> CreateCategory(CategoryModel category)
        {
            //create a bag to transer date between model and database
            DynamicParameters param = new DynamicParameters();

            param.Add("@categoryId", category.CategoryId);
            param.Add("@categoryDescr", category.CategoryDescr);
            param.Add("@abbrCd", category.AbbrCd);

            await _sqlDataAccess.SaveData("dbo.sp_insert_category",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);

            return param.Get<string>("@categoryId");
        }

        //delete
        public async Task<int> DeleteCategory(string categoryId)
        {
            return await _sqlDataAccess.SaveData("dbo.sp_delete_category",
                                                 new { categoryId },
                                                 _sqlConnectionString.SqlConnectionName);
        }


        //update
        public async Task<string> UpdateCategory(CategoryModel category)
        {
            //create an empty bag 
            DynamicParameters param = new DynamicParameters();
            //fill with the data in passed model
            param.Add("categoryId", category.CategoryId);
            param.Add("@categoryDescr", category.CategoryDescr);
            param.Add("@abbrCd", category.AbbrCd);
            param.Add("@activeYn", category.ActiveYn);

            await _sqlDataAccess.SaveData("dbo.sp_update_category", param, _sqlConnectionString.SqlConnectionName);

            return param.Get<string>("@categoryId");
        }


        ////get category List
        ////return a list of all the categories
        //public async Task<List<CategoryModel>> GetCategoryList(string? categoryId)
        //{
        //    return await _sqlDataAccess.LoadData<CategoryModel, dynamic>("dbo.sp_search_category",
        //                                                                 new { categoryId },
        //                                                                 _sqlConnectionString.SqlConnectionName);
        //}



        public async Task<List<CategoryModel>> GetCategoryList()
        {
            return await _sqlDataAccess.LoadData<CategoryModel, dynamic>("dbo.sp_search_category",
                                                                         new { },
                                                                         _sqlConnectionString.SqlConnectionName);
        }

        public async Task<CategoryModel> GetCategoryById(string categoryId)
        {
            var category = await _sqlDataAccess.LoadData<CategoryModel, dynamic>("dbo.sp_search_category_by_id",
                                                                         new { categoryId },
                                                                         _sqlConnectionString.SqlConnectionName);
            return category.FirstOrDefault();
        }

    }
}
