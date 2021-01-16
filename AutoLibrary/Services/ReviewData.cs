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
    public class ReviewData : IReviewData
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
            //param.Add("@reviewId", "", DbType.String, direction: System.Data.ParameterDirection.Output, size: int.MaxValue);
          
            //param.Add("@userName", review.UserName);
            param.Add("@reviewDescr", review.ReviewDescr);
            param.Add("@autoId", review.AutoId);


            param.Add("userId", "testId");
            //userId? Membership.GetUser();
            //using System.Web.Security
            await _sqlDataAccess.SaveData("dbo.sp_insert_review",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("autoId");
        }

        //Delete
        public async Task<int> DeleteReview(string userId, string autoId)
        {
            return await _sqlDataAccess.SaveData("dbo.sp_delete_review",
                                          new { userId, autoId },
                                          _sqlConnectionString.SqlConnectionName);
        }

        public Task<ReviewModel> GetReviewByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        //Get Review List
        public Task<List<ReviewModel>> GetReviewList(string autoId)
        {
            // return list of reviews with same autoId
            return _sqlDataAccess.LoadData<ReviewModel, dynamic>("dbo.sp_search_review",
                                                                 new { autoId },
                                                                 _sqlConnectionString.SqlConnectionName);
        }

        //Update
        public async Task<string> UpdateReview(ReviewModel review)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@reviewId", review.ReviewId, DbType.String, direction: ParameterDirection.InputOutput, size: int.MaxValue);
            //param.Add("@userName", review.UserName);
            param.Add("@reviewDescr", review.ReviewDescr);
            param.Add("@autoId", review.AutoId);

            await _sqlDataAccess.SaveData("dbo.sp_update_review",
                                          param,
                                          _sqlConnectionString.SqlConnectionName);
            return param.Get<string>("@autoId");
        }
    }
}
