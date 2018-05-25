using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgRepository
    {
        public static bool Add(MassMrgViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.MassMrgs.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgs.Add(new MassMrg
                    {
                        Id = model.Id,
                        Location = model.Location,
                        DateTime = model.DateTime
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<MassMrgViewModel> Gets()
        {
            var list = new List<MassMrgViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.MassMrgs)
                {
                    list.Add(new MassMrgViewModel
                    {
                        Id = a.Id,
                        Location = a.Location,
                        DateTime = a.DateTime
                    });
                }
                return list;
            }
        }
        public static List<MassMrgViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgField.Location:
                    return Gets().OrderBy(x => x.Location).ToList();

                case (int)MassMrgField.DateTime:
                    return Gets().OrderByDescending(x => x.DateTime).ToList();

                
            }
            return null;
        }
    }
    public enum MassMrgField
    {
        Id,
        Location,
        DateTime
    }
}