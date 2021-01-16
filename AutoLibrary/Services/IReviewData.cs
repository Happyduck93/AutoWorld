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
        Task<int> DeleteReview(string reviewId);
        Task<string> UpdateReview(ReviewModel review);
        Task<List<ReviewModel>> GetReviewList();
        Task<ReviewModel> GetReviewById(string ReviewId);
    }
}
