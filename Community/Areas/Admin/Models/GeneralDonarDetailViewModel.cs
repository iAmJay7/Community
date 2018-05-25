using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class GeneralDonarDetailViewModel
    {
        public int Id { get; set; }
        public int DonarId { get; set; }
        public string Amount { get; set; }
        public string Discription { get; set; }
        public DateTime Date { get; set; }
        public string Donar { get; set; }
    }
}