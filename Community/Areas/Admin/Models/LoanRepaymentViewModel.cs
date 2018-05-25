using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class LoanRepaymentViewModel
    {
        public int Id { get; set; }
        public int GeneralLoanId { get; set; }
        public int StudentLoanId { get; set; }
        public string PayAmount { get; set; }
        public DateTime Date { get; set; }

        public string GeneralLoanDetail { get; set; }
        public string StudentLoanDetail { get; set; }
    }
}