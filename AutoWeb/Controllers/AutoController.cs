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
    public class AutoController : Controller
    {
        //field
        private readonly IAutoData _autoData;
        private readonly ICodeData _codeData;
        private readonly IBrandData _brandData;

        //constructor
        public AutoController(IAutoData autoData, ICodeData codeData, IBrandData brandData)
        {
            _autoData = autoData;
            _codeData = codeData;
            _brandData = brandData;
        }

        //Index
        public IActionResult Index()
        {
            return View();
        }

        //AutoList
        [HttpGet]
        public async Task<IActionResult> AutoList()
        {
            var auto = await _autoData.GetAutoList();

            

            return Json(new { data = auto.ToList() });
        }

        //Details
        public async Task<IActionResult> Details(string autoId)
        {
            var auto = await _autoData.GetAutoById(autoId);
            return View(auto);
        }

        //Details
        [HttpPost]
        public async Task<IActionResult> Details(AutoModel auto)
        {
            var autoId = await _autoData.UpdateAuto(auto);
            return RedirectToAction("Details", new { autoId });
        }

        //Create
        public async Task<IActionResult> Create()
        {
            var auto = new AutoModel();
            var brandList = await _brandData.GetBrandList();
            brandList.ForEach( x=>
            {
                auto.BrandSelectList.Add(new SelectListItem { Value = x.BrandId, Text = x.BrandName});
            });

            var autoTypeList = await _codeData.GetCodeListByCategory("AutoType");
            autoTypeList.ForEach(x=>
            {
                auto.AutoTypeSelectList.Add(new SelectListItem { Value = x.CodeId, Text = x.CodeDescr });
            });
            return View(auto);
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> Create(AutoModel auto)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
         
            

            var autoId = await _autoData.CreateAuto(auto);
            return RedirectToAction("Details", new { autoId });
        }

        //public async Task<IActionResult> Create(AutoModel auto)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Details", new { auto.AutoId });
        //}

        //Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(string autoId)
        {
            await _autoData.DeleteAuto(autoId);
            return Json(new { success = true, message = "Delete successful" });
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(AutoModel auto)
        {
            await _autoData.DeleteAuto(auto.AutoId);
            return RedirectToAction("Index");
        }



    }
}
