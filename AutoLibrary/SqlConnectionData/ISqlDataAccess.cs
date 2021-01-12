using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.SqlConnectionData
{
    public interface ISqlDataAccess
    {
        //The Task class represents a single operation that does not return a value and that usually executes asynchronously. 


        //Returns a list of objects with generic type T 
        //load data from sql database
        //used two generic types : T, U
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string sqlConnectionName);

        //save data to sql database 
        Task<int> SaveData<T>(string storedProcedure, T parameters, string sqlConnectionName);

        //SQL : Structured Query Language
    }
}
