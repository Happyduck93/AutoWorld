using AutoLibrary.Models;
using AutoLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoWeb.Controllers
{
    public class CategoryController : Controller
    {
        //field
        private readonly ICategoryData _categoryData;

        //constructor
        public CategoryController(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        //Index
        public async Task<IActionResult> Index()
        {
            //Enumerable - List
            return View(await _categoryData.GetCategoryList());
        }

        //Details
        public async Task<IActionResult> Details(string categoryId)
        {
            var category = await _categoryData.GetCategoryById(categoryId);
            return View(category);
        }

        //Details
        [HttpPost]
        public async Task<IActionResult> Details(CategoryModel category)
        {
            await _categoryData.UpdateCategory(category);
            return RedirectToAction("Details", new { category.CategoryId });
        }

        //Create 
        //simply load input form. return view.
        public IActionResult Create()
        {
            return View();
        }

        //Create - Save data to database
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            //CrreateCategory method returns id
            var id = await _categoryData.CreateCategory(category);
            //redirect to details of the CategoryModel with that id 
            return RedirectToAction("Details", new { categoryId = id });
            //return RedirectToAction("Index");

        }

        //Delete
        //get the data with categoryId  
        public async Task<IActionResult> Delete(string categoryId)
        {
            //get CategoryModel with categoryId
            var category = await _categoryData.GetCategoryById(categoryId);  //----------------------------
            return View(category);
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryModel category)
        {
            await _categoryData.DeleteCategory(category.CategoryId);
            return RedirectToAction("Index");
        }

       

    }
}
