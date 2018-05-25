using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class SchemeRepository
    {
        public static bool Add(SchemeViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.Schemes.FirstOrDefault(x => x.Name == model.Name);
                if (search == null)
                {
                    db.Schemes.Add(new Community.Scheme
                    {
                        Name = model.Name
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<SchemeViewModel> Gets()
        {
            var list = new List<SchemeViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.Schemes)
                {
                    list.Add(new Models.SchemeViewModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    });
                }
                return list;
            }
        }
        public static List<SchemeViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)SchemeField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();
                case (int)SchemeField.Name:
                    return Gets().OrderBy(x => x.Name).ToList();
            }
            return null;
        }
    }
    public enum SchemeField
    {
        Id,
        Name
    }
}