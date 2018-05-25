using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Models
{
    public class FamilyInfoRepository
    {
        public static int Add(FamilyInfoViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.FamilyInfoes.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    var m = new FamilyInfo
                    {
                        Id = model.Id,
                        SakhId = model.SakhId,
                        Address = model.Address
                    };
                    db.FamilyInfoes.Add(m);
                    db.SaveChanges();
                    return m.Id;
                }
            }
            return 0;
        }
        public static int GetFamilyId(int? FatherId)
        {
            if (FatherId != null)
            {
                using (var db = new CommunityDbEntities())
                {
                    var fatherId = db.PersonInfoes.FirstOrDefault(x => x.Id == FatherId);
                    if (fatherId != null)
                    {
                        return (int)db.PersonInfoes.Find(fatherId).FatherId;
                    }
                }
            }
            return 0;
        }
    }
}