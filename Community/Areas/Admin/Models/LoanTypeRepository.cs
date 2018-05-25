using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class LoanTypeRepository
    {
        public static bool Add(LoanTypeViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.LoanTypes.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.LoanTypes.Add(new LoanType
                    {
                        Id = model.Id,
                        Name = model.Name
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<LoanTypeViewModel> Gets()
        {
            var list = new List<LoanTypeViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.LoanTypes)
                {
                    list.Add(new LoanTypeViewModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    });
                    
                }
                return list;
            }
        }
    }
}