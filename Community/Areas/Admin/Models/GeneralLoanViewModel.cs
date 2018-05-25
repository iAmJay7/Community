using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class GeneralLoanViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Amount { get; set; }
        public string Discription { get; set; }
        public decimal InterestRate { get; set; }
        public int MonthlyPeriod { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaidUp { get; set; }

        public string PersonName { get; set; }
        public string CreatedDate { get; set; }
    }
}