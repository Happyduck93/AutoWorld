using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLibrary.Models
{
    public class ReviewModel
    {
        public string UserName { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow.Date;
        public string ReviewDescr { get; set; }
        public string AudoId { get; set; }
        public string ReviewId { get; set; }
        //public string UserId { get; set; }

    }
}
