using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class GeneralDonarDetailRepository
    {
        public static bool Add(GeneralDonarDetailViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.GeneralDonarDetails.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.GeneralDonarDetails.Add(new GeneralDonarDetail
                    {
                        DonarId = model.DonarId,
                        Amount = model.Amount,
                        Discription = model.Discription,
                        Date = DateTime.Now

                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<GeneralDonarDetailViewModel> Gets()
        {
            var list = new List<GeneralDonarDetailViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.GeneralDonarDetails)
                {
                    list.Add(new GeneralDonarDetailViewModel
                    {
                        Id = a.Id,
                        DonarId = a.DonarId,
                        Amount = a.Amount,
                        Discription = a.Discription,
                        Date = a.Date,
                        Donar = a.PersonInfo.Name
                    });
                }
                return list;
            }
        }
        public static List<GeneralDonarDetailViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)GeneralDonarDetailField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)GeneralDonarDetailField.DonarId:
                    return Gets().OrderByDescending(x => x.DonarId).ToList();

                case (int)GeneralDonarDetailField.Amount:
                    return Gets().OrderByDescending(x => x.Amount).ToList();

                case (int)GeneralDonarDetailField.Discription:
                    return Gets().OrderByDescending(x => x.Discription).ToList();

                case (int)GeneralDonarDetailField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();
                    
            }
            return null;
        }
    }

    public enum GeneralDonarDetailField
    {
        Id,
        DonarId,
        Amount,
        Discription,
        Date
    }
}