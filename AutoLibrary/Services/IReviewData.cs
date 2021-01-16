using AutoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoLibrary.Services
{
    public interface IReviewData
    {
        Task<string> CreateReview(ReviewModel review);
        Task<int> DeleteReview(string userId, string autoId);
        Task<string> UpdateReview(ReviewModel review);
        Task<List<ReviewModel>> GetReviewList(string autoId);
        Task<ReviewModel> GetReviewByUserId(string userId);
    }
}
