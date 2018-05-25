using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class StudentLoanRepository
    {
        public static bool Add(StudentLoanViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                db.StudentLoans.Add(new Community.StudentLoan
                {
                    PersonId = model.PersonId,
                    SchemeId = model.SchemeId,
                    Amount = model.Amount,
                    Discription = model.Discription,
                    Date = model.Date
                });
                db.SaveChanges();
                return true;
            }
        }

        public static List<StudentLoanViewModel> Gets()
        {
            var list = new List<StudentLoanViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.StudentLoans)
                {
                    list.Add(new Models.StudentLoanViewModel
                    {
                        Id = a.Id,
                        PersonId = a.PersonId,
                        SchemeId = a.SchemeId,
                        Amount = a.Amount,
                        Discription = a.Discription,
                        Date = a.Date,
                        IsPaidUp = a.IsPaidUp == 1 ? true : false,
                        PersonName=a.PersonInfo.Name,
                        SchemeName=a.Scheme.Name
                    });
                }
                return list;
            }
        }
        public static List<StudentLoanViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)StudentLoanField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)StudentLoanField.PersonId:
                    return Gets().OrderBy(x => x.PersonName).ToList();

                case (int)StudentLoanField.SchemeId:
                    return Gets().OrderBy(x => x.SchemeName).ToList();

                case (int)StudentLoanField.Amount:
                    return Gets().OrderByDescending(x => x.Amount).ToList();

                case (int)StudentLoanField.Discription:
                    return Gets().OrderByDescending(x => x.Discription).ToList();

                case (int)StudentLoanField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();

                case (int)StudentLoanField.IsPaidUp:
                    return Gets().OrderByDescending(x => x.IsPaidUp).ToList();
            }
            return null;
        }
    }
    public enum StudentLoanField
    {
        Id,
        PersonId,
        SchemeId,
        Amount,
        Discription,
        Date,
        IsPaidUp
    }
}