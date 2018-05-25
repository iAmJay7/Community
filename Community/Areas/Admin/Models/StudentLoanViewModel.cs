using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class StudentLoanViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SchemeId { get; set; }
        public string Amount { get; set; }
        public string Discription { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaidUp { get; set; }

        public string PersonName { get; set; }
        public string SchemeName { get; set; }
    }
}