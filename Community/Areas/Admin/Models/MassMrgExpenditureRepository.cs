using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgExpenditureRepository
    {
        public static bool Add(MassMrgExpenditureViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.MassMrgExpenditures.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgExpenditures.Add(new MassMrgExpenditure
                    {
                        Id = model.Id,
                        MassMrgId = model.MassMrgId,
                        Amount = model.Amount,
                        ForDiscription = model.ForDiscription,
                        Date = model.Date
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<MassMrgExpenditureViewModel> Gets()
        {
            var list = new List<MassMrgExpenditureViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.MassMrgExpenditures)
                {
                    list.Add(new MassMrgExpenditureViewModel
                    {
                        Id = a.Id,
                        MassMrgId = a.MassMrgId,
                        Amount = a.Amount,
                        ForDiscription = a.ForDiscription,
                        Date = a.Date,
                        MassMrgLocation=a.MassMrg.Location,
                        MassMrgDate=a.MassMrg.DateTime.ToString()
                    });
                }
                return list;
            }
        }

        public static List<MassMrgExpenditureViewModel> GetsByMassMrgId(int id)
        {
            return Gets().Where(x => x.MassMrgId == id).ToList();
        }
        public static List<MassMrgExpenditureViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgExpenditureField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgExpenditureField.MassMrgId:
                    return Gets().OrderByDescending(x => x.MassMrgId).ToList();
                    
                case (int)MassMrgExpenditureField.Amount:
                    return Gets().OrderByDescending(x => x.Amount).ToList();

                case (int)MassMrgExpenditureField.ForDiscription:
                    return Gets().OrderByDescending(x => x.ForDiscription).ToList();

                case (int)MassMrgExpenditureField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();

            }
            return null;
        }
    }
    public enum MassMrgExpenditureField
    {
        Id,
        MassMrgId,
        Amount,
        ForDiscription,
        Date
    }
}