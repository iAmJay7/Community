using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgDonarDetailRepository
    {
        public static bool Add(MassMrgDonarDetailViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.MassMrgDonarDetails.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgDonarDetails.Add(new MassMrgDonarDetail
                    {
                        Id = model.Id,
                        MassMrgId=model.MassMrgId,
                        DonarId=model.DonarId,
                        Amount=model.Amount,
                        Discription=model.Discription,
                        Date=model.Date
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        internal static object GetsByMassMrgId(object sessionWraper)
        {
            throw new NotImplementedException();
        }

        public static List<MassMrgDonarDetailViewModel> Gets()
        {
            var list = new List<MassMrgDonarDetailViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.MassMrgDonarDetails)
                {
                    list.Add(new MassMrgDonarDetailViewModel
                    {
                        Id = a.Id,
                        MassMrgId=a.MassMrgId,
                        DonarId = a.DonarId,
                        Amount = a.Amount,
                        Discription = a.Discription,
                        Date = a.Date,
                        MassMrgLocation=a.MassMrg.Location,
                        MassMrgDate=a.MassMrg.DateTime.ToString(),
                        Donar=a.PersonInfo.Name
                    });
                }
                return list;
            }
        }

        public static List<MassMrgDonarDetailViewModel> GetsByMassMrgId(int id)
        {
            return Gets().Where(x => x.MassMrgId == id).ToList();
        }
        public static List<MassMrgDonarDetailViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgDonarDetailField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgDonarDetailField.MassMrgId:
                    return Gets().OrderByDescending(x => x.MassMrgId).ToList();

                case (int)MassMrgDonarDetailField.DonarId:
                    return Gets().OrderByDescending(x => x.DonarId).ToList();

                case (int)MassMrgDonarDetailField.Amount:
                    return Gets().OrderByDescending(x => x.Amount).ToList();

                case (int)MassMrgDonarDetailField.Discription:
                    return Gets().OrderByDescending(x => x.Discription).ToList();

                case (int)MassMrgDonarDetailField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();

            }
            return null;
        }
    }
    public enum MassMrgDonarDetailField
    {
        Id,
        MassMrgId,
        DonarId,
        Amount,
        Discription,
        Date
    }
}