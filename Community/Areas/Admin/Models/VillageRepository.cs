using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class VillageRepository
    {
        public static bool Add(VillageViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.Villages.FirstOrDefault(x => x.Name == model.Name);
                if (search == null)
                {
                    db.Villages.Add(new Village
                    {
                        Name = model.Name,
                        Taluka = model.Taluka,
                        District = model.District,
                        Date = model.Date
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<VillageViewModel> Gets()
        {
            var list = new List<VillageViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.Villages)
                {
                    list.Add(new VillageViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Taluka = a.Taluka,
                        District = a.District,
                        Date = a.Date
                    });
                }
                return list;
            }
        }

        public static string GetVillaNamegeById(int id)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.Villages.FirstOrDefault(x => x.Id == id);
                if (search != null)
                {
                    return search.Name;
                }
            }
            return "";
        }
    }
}