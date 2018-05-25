using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class LoanRepaymentRepository
    {
        public static bool Add(LoanRepaymentViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                db.LoanRepayments.Add(new Community.LoanRepayment
                {
                    GeneralLoanId = model.GeneralLoanId,
                    StudentLoanId = model.StudentLoanId,
                    PayAmount = model.PayAmount,
                    Date = DateTime.Now
                });
                db.SaveChanges();
                return true;
            }
        }

        public static List<LoanRepaymentViewModel> Gets()
        {
            var list = new List<LoanRepaymentViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.LoanRepayments)
                {
                    list.Add(new Models.LoanRepaymentViewModel
                    {
                        Id = a.Id,
                        GeneralLoanId = a.GeneralLoanId ?? 0,
                        StudentLoanId = a.StudentLoanId ?? 0,
                        PayAmount = a.PayAmount,
                        Date = a.Date,
                        GeneralLoanDetail="Rs."+a.GeneralLoan.Amount+" "+a.GeneralLoan.PersonInfo.Name,
                        StudentLoanDetail = "Rs." +a.StudentLoan.Amount + " " + a.StudentLoan.PersonInfo.Name,
                    });
                }
                return list;
            }
        }
        public static List<LoanRepaymentViewModel> GetsOrderBy(int repaymentField)
        {
            switch (repaymentField)
            {
                case (int)LoanRepaymentField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();
                case (int)LoanRepaymentField.GeneralLoanId:
                    return Gets().OrderByDescending(x => x.GeneralLoanId).ToList();
                case (int)LoanRepaymentField.StudentLoanId:
                    return Gets().OrderByDescending(x => x.StudentLoanId).ToList();
                case (int)LoanRepaymentField.PayAmount:
                    return Gets().OrderByDescending(x => x.PayAmount).ToList();
                case (int)LoanRepaymentField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();

            }
            return null;
        }
    }
    public enum LoanRepaymentField
    {
        Id,
        GeneralLoanId,
        StudentLoanId,
        PayAmount,
        Date
    }
}