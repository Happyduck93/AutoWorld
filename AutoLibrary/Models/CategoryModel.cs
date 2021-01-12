using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AutoLibrary.Models
{
    public class CategoryModel
    {
        [DisplayName("Category Id")]
        public string CategoryId { get; set; }
        [DisplayName("Category Description")]

        public string CategoryDescr { get; set; }
        [DisplayName("Active Y/N")]
        public bool ActiveYn { get; set; }

        public DateTime CreateDt { get; set; } = DateTime.UtcNow.Date;

        [DisplayName("Abbreviation Code")]
        public string AbbrCd { get; set; }

    }
}
