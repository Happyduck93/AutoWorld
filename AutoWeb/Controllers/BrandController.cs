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
    public class BrandController : Controller
    {
        //field
        private readonly IBrandData _brandData;
        private readonly ICodeData _codeData;
        //private readonly ICategoryData _categoryData;

        //constructor
        public BrandController(IBrandData brandData, ICodeData codeData)
        {
            _brandData = brandData;
            _codeData = codeData;
            //_categoryData = categoryData;
        }

        //Index
        public IActionResult Index()
        {
            return View();
        }

        //BrandList
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var brand = await _brandData.GetBrandList();
            

            var code = await _codeData.GetCodeListByCategory("BrandType");
            brand.ForEach( x =>
            {
                x.BrandCodeDescr = code.Where(n => x.BrandCodeId == n.CodeId).FirstOrDefault()?.CodeDescr;
            });
            return Json(new { data = brand.ToList() });
        }

        //Details
        public async Task<IActionResult> Details(string brandId)
        {
            var brand = await _brandData.GetBrandById(brandId);

            return View(brand);
        }

        //Details
        [HttpPost]
        public async Task<IActionResult> Details(BrandModel brand)
        {
           
            var brandId =  await _brandData.UpdateBrand(brand);
            return RedirectToAction("Details", new { brandId });
        }

        //Create
        public async Task<IActionResult> Create()
        {
            var brand = new BrandModel();
            //get 
           

            var codeList = await _codeData.GetCodeListByCategory("BrandType");

            codeList.ForEach(x =>
            {
                brand.CodeList.Add(new SelectListItem { Value = x.CodeId, Text = x.CodeDescr });
            });
            return View(brand);
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> Create(BrandModel brand)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            brand.CategoryId = (await _codeData.GetCategoryByCode(brand.BrandCodeId)).CategoryId;
            brand.BrandCodeDescr = (await _codeData.GetCodeById(brand.BrandCodeId, brand.CategoryId)).CodeDescr;
            
            var brandId = await _brandData.CreateBrand(brand);
            return RedirectToAction("Details", new { brandId });
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(string brandId)
        {
            await _brandData.DeleteBrand(brandId);
            return Json(new { success = true, message= "Delete successful"});
        }

        //Delete
        [HttpPost]
        public async Task<IActionResult> Delete(BrandModel brand)
        {
            await _brandData.DeleteBrand(brand.BrandId);
            return RedirectToAction("Index");
        }

    }

}   
