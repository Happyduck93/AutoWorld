using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLibrary.Models
{
    public class ReviewModel
    {
        public string UserName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Review { get; set; }
        public string AudoId { get; set; }

    }
}
