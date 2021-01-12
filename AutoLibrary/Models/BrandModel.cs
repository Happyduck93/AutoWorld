using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoLibrary.Models
{
    public class BrandModel
    {
        [DisplayName("Category Id")]
        public string CategoryId { get; set; } 
        public string BrandId { get; set; }
        [DisplayName("Country")]
        public string BrandCodeId { get; set; }
        public string BrandCodeDescr { get; set; }
        [DisplayName("Company Name")]
        [Required]
        public string BrandName { get; set; }
        [DisplayName("Description")]
        public string BrandDescr { get; set; }
        [DisplayName("Founded")]
        public DateTime EstablishmentDate { get; set; } = DateTime.UtcNow.Date;
        public string Headquarters { get; set; }
        public List<SelectListItem> CodeList { get; set; } = new List<SelectListItem>();

    }
}
