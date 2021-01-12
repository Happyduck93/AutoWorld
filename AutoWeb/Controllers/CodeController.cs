using AutoLibrary.Models;
using AutoLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoWeb.Controllers
{
    public class CodeController : Controller
    {
        //field
        private readonly ICodeData _codeData;
        private readonly ICategoryData _categoryData;

        //constructor
        public CodeController(ICodeData codeData, ICategoryData categoryData)
        {
            _codeData = codeData;
            _categoryData = categoryData;
        }

        //Index
        public IActionResult Index()
        {
            return View();
        }

        //CodeList
        [HttpGet]
        public async Task<IActionResult> CodeList()
        {
            var code = await _codeData.GetCodeList();
            return Json(new { data = code.ToList() });
        }


        //Details
        public async Task<IActionResult> Details(string codeId, string categoryId)
        {
            var code = await _codeData.GetCodeById(codeId,categoryId);
            return View(code);
        }

        //Details
        [HttpPost]
        public async Task<IActionResult> Details(CodeModel code)
        {
            await _codeData.UpdateCode(code);
            return RedirectToAction("Details", new { codeId = code.CodeId , categoryId = code.CategoryId });
            

        }

        //Create
        public async Task<IActionResult> Create()
        {
            var category = new CodeModel();
            var categoryList = await _categoryData.GetCategoryList();

            categoryList.ForEach(x =>
            {
                category.CategoryList.Add(item: new SelectListItem { Value = x.CategoryId, Text = x.CategoryDescr });
            });
            return View(category);
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> Create(CodeModel code)
        {
            if (ModelState.IsValid == false)
            {
                return View(); 
            }
            var id = await _codeData.CreateCode(code);
            return RedirectToAction("Details", new { codeId =  id , categoryId = code.CategoryId});
        }

        //Delete
        public async Task<IActionResult> Delete(string codeId,string categoryId)
        {
            var code = await _codeData.GetCodeById(codeId,categoryId);
            return View(code);
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(CodeModel code)
        {
            await _codeData.DeleteCode(code.CodeId, code.CategoryId);
            return RedirectToAction("Index");
        }

    }
}
