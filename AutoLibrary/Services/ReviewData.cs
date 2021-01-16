using AutoLibrary.Models;
using AutoLibrary.SqlConnectionData;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{
    class ReviewData : IReviewData
    {
        //field
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly SqlConnectionString _sqlConnectionString;

        //constructor
        public ReviewData(ISqlDataAccess sqlDataAccess, SqlConnectionString sqlConnectionString)
        {
            _sqlDataAccess = sqlDataAccess;
            _sqlConnectionString = sqlConnectionString;
        }
        
        //Create Review
        public async Task<string> CreateReview(ReviewModel review)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@reviewId", "", DbType.String, direction: System.Data.ParameterDirection.Output, size: int.MaxValue);
            param.Add("@userName", review.UserName);
            param.Add("@reviewDescr", review.ReviewDescr);
            param.Add("@autoId", review.AudoId);
            //userId? Membership.GetUser();
            //using System.Web.Security
            await _sqlDataAccess.SaveData("dbo.sp_insert_review",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("reviewId");
        }

        public Task<int> DeleteReview(string reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewModel> GetReviewById(string ReviewId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewModel>> GetReviewList()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateReview(ReviewModel review)
        {
            throw new NotImplementedException();
        }
    }
}
