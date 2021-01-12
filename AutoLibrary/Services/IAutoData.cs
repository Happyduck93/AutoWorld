using AutoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{
    public interface IAutoData
    {
        Task<string> CreateAuto(AutoModel auto);
        Task<int> DeleteAuto(string AutoId);
        Task<string> UpdateAuto(AutoModel auto);
        Task<List<AutoModel>> GetAutoList();
        Task<AutoModel> GetAutoById(string autoId);
    }
}
