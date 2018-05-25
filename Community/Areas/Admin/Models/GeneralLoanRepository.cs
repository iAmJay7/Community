using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class GeneralLoanRepository
    {
        public static bool Add(GeneralLoanViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                db.GeneralLoans.Add(new Community.GeneralLoan
                {
                    PersonId = model.PersonId,
                    Amount = model.Amount,
                    Discription = model.Discription,
                    InterestRate = model.InterestRate,
                    MonthlyPeriod = model.MonthlyPeriod,
                    Date = DateTime.Now,
                });
                db.SaveChanges();
                return true;
            }
        }

        public static List<GeneralLoanViewModel> Gets()
        {
            var list = new List<GeneralLoanViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.GeneralLoans)
                {
                    list.Add(new Models.GeneralLoanViewModel
                    {
                        Id = a.Id,
                        PersonId = a.PersonId,
                        Amount = a.Amount,
                        Discription = a.Discription,
                        InterestRate = a.InterestRate ?? 0,
                        MonthlyPeriod = a.MonthlyPeriod,
                        Date = a.Date,
                        PersonName = a.PersonInfo.Name,
                        CreatedDate = a.Date.ToString()
                    });
                }
            }
            return list;

        }



        public static List<GeneralLoanViewModel> GetsOrderBy(int loanField)
        {
            switch(loanField)
            {
                case (int)GeneralLoanField.Id:
                    return  Gets().OrderByDescending(x => x.Id).ToList();
                    
                case (int)GeneralLoanField.PersonId:
                    return  Gets().OrderByDescending(x => x.PersonId).ToList();
                    
                case (int)GeneralLoanField.Amount:
                    return  Gets().OrderByDescending(x => x.Amount).ToList();
                    
                case (int)GeneralLoanField.Discription:
                    return  Gets().OrderByDescending(x => x.Discription).ToList();
                    
                case (int)GeneralLoanField.InterestRate:
                    return  Gets().OrderByDescending(x => x.InterestRate).ToList();
                    
                case (int)GeneralLoanField.MonthlyPeriod:
                    return  Gets().OrderByDescending(x => x.MonthlyPeriod).ToList();
                    
                case (int)GeneralLoanField.Date:
                    return  Gets().OrderByDescending(x => x.Date).ToList();
                    
            }
            return null;
        }
    }

   public enum GeneralLoanField
    {
        Id,
        PersonId,
        Amount,
        Discription,
        InterestRate,
        MonthlyPeriod,
        Date
    }
}