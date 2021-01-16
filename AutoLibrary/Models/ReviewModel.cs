using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoLibrary.Models
{
    public class ReviewModel
    {
        public string UserName { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow.Date;
        public string ReviewDescr { get; set; }
        public string AutoId { get; set; }
        public string ReviewId { get; set; }
        public string UserId { get; set; }

        public string AutoName { get; set; }
        public string BrandName { get; set; }
        public string AutoType { get; set; }
        public string Year { get; set; }




    }
}
