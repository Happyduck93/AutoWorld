using AutoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{
    public interface ICodeData
    {
        Task<string> CreateCode(CodeModel code);

        Task<int> DeleteCode(string codeId, string categoryId);

        Task<string> UpdateCode(CodeModel code);

        Task<List<CodeModel>> GetCodeListByCategory(string categoryId);
        Task<List<CodeModel>> GetCodeList();


        Task<CodeModel> GetCodeById(string codeId, string categoryId);

        Task<CodeModel> GetCategoryByCode(string codeId);

    }
}
