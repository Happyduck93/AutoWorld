using AutoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AutoLibrary.Services
{
    public interface ICategoryData
    {
        
        //put data in categoryModel to database
        Task<string> CreateCategory(CategoryModel category);

        //delete category with categoryId in database 
        Task<int> DeleteCategory(string categoryId);

        //update data in categoryModel to database
        Task<string> UpdateCategory(CategoryModel category);


        //Get list of codes within same category 
        //string? : nullable
        //Task<List<CategoryModel>> GetCategoryList(string? categoryId);

        Task<List<CategoryModel>> GetCategoryList();

        //get one category Model with a categoryId
        Task<CategoryModel> GetCategoryById(string categoryId);



    }
}
