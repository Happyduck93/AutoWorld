using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AutoLibrary.Models
{
    public class CodeModel
    {
        [DisplayName("Code ID")]
        public string CodeId { get; set; }
        [DisplayName("Category Id")]
        public string CategoryId { get; set; }
        [DisplayName("Code Description")]
        public string CodeDescr { get; set; }
        [DisplayName("Active Y/N")]
        public bool ActiveYn { get; set; }
        public DateTime CreateDt { get; set; } = DateTime.UtcNow.Date;

        // List of codes within category
        //Create new list object for later use
        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();
    }
}
