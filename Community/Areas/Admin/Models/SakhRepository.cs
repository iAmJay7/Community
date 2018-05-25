using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class SakhRepository
    {
        public static bool Add(SakhViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.Sakhs.FirstOrDefault(x => x.Name.Equals(model.Name));
                if (search == null)
                {
                    db.Sakhs.Add(new Sakh
                    {
                        Name = model.Name,
                        VillageId = model.VillageId,
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<SakhViewModel> Gets()
        {
            var list = new List<SakhViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.Sakhs)
                {
                    list.Add(new SakhViewModel
                    {
                        Name = a.Name,
                        VillageId = a.VillageId
                    });
                }
                return list;
            }

        }

        public static List<SakhViewModel> GetsSakhsBtVillage(int villageId)
        {
            var list = new List<SakhViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.Sakhs)
                {
                    if (a.VillageId == villageId)
                    {
                        list.Add(new SakhViewModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            VillageId = a.VillageId
                        });
                    }
                }
                return list;
            }
            return null;
        }

        public static SakhViewModel GetSakhById(int id)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.Sakhs.FirstOrDefault(x => x.Id == id);
                if (search != null)
                {
                    return new SakhViewModel
                    {
                        Id = search.Id,
                        Name = search.Name,
                        VillageId = search.VillageId
                    };
                }
            }
            return null;
        }
    }
}