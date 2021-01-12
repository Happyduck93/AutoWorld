using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AutoLibrary.Models
{
    public class AutoModel
    {

        public string AutoId { get; set; }
        public string AutoType { get; set; }
        public DateTime ReleasedDate { get; set; } = DateTime.UtcNow.Date;
        public string Year { get; set; }
        [DisplayName("Description")]
        public string AutoDescr { get; set; }
        [DisplayName("Model Name")]
        public string AutoName { get; set; }
        [DisplayName("Type")]
        public string AutoTypeName { get; set; }
        public string BrandId { get; set; }
        [DisplayName("Brand")]
        public string BrandName { get; set; }
        public string Trim { get; set; }

        public decimal Price { get; set; }
        //price range?
        //color?
        public string Color { get; set; }

        public List<SelectListItem> BrandSelectList { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> AutoTypeSelectList { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> ColorSelectList { get; set; } = new List<SelectListItem>();
        //public string FullModelName { get { return $"{ReleasedDate} {ModelName}"; } }
    }
}
