using AutoLibrary.Models;
using AutoLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoWeb.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewData _reviewData;

        //field
        private readonly IAutoData _autoData;
        private readonly ICodeData _codeData;

        //constructor
        public ReviewController(IReviewData reviewData, IAutoData autoData, ICodeData codeData)
        {
            _reviewData = reviewData;
            _autoData = autoData;
            _codeData = codeData;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewList(string autoId)
        {
            var review = await _reviewData.GetReviewList(autoId);
            return Json(new { data = review.ToList() });
        }


        public async Task<IActionResult> Index(string autoId)
        {
            var auto = await _autoData.GetAutoById(autoId);
            return View(auto);
        }

        //Create
        public async Task<IActionResult> Create(string autoId)
        {
            var review = new ReviewModel();
            var auto = await _autoData.GetAutoById(autoId);

            //-- get cureent user's Id  //-------------------------------------------------Q
            review.UserId = "testId";

            review.AutoId = auto.AutoId;
            review.BrandName = auto.BrandName;
            review.Year = auto.Year;
            review.AutoName = auto.AutoName;

            //current create view with review model info 
            return View(review);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewModel review)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            string autoId = await _reviewData.CreateReview(review);
            return RedirectToAction("Index", new { autoId });

        }


    }
}
