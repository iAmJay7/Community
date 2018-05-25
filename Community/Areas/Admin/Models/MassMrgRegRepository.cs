using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgRegRepository
    {
        public static bool Add(MassMrgRegViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.MassMrgRegs.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgRegs.Add(new MassMrgReg
                    {
                        
                        MassMrgId = model.MassMrgId,
                        GroomId = model.GroomId,
                        BrideId = model.BrideId,
                        Documents = "abc",
                        Date = model.Date
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<MassMrgRegViewModel> Gets()
        {
            var list = new List<MassMrgRegViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.MassMrgRegs)
                {
                    list.Add(new MassMrgRegViewModel
                    {
                        Id = a.Id,
                        MassMrgId = a.MassMrgId,
                        GroomId = a.GroomId,
                        BrideId = a.BrideId,
                        Documents = a.Documents,
                        Date = a.Date,
                        MassMrgLocation = a.MassMrg.Location,
                        MassMrgDate = a.MassMrg.DateTime.ToString(),
                        BrideName = a.PersonInfo.Name,
                        GroomName = a.PersonInfo1.Name
                    });
                }
                return list;
            }
        }
        
        public static List<MassMrgRegViewModel> GetMrgByMassId(int id)
        {
            var list = new List<MassMrgRegViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.MassMrgRegs.Where(x => x.MassMrgId == id))
                {
                    list.Add(new MassMrgRegViewModel
                    {
                        Id = a.Id,
                        MassMrgId = a.MassMrgId,
                        GroomId = a.GroomId,
                        BrideId = a.BrideId,
                        Documents = a.Documents,
                        Date = a.Date,
                        BrideName = a.PersonInfo.Name,
                        GroomName=a.PersonInfo1.Name
                    });
                }
                return list;
            }
        }
        public static List<MassMrgRegViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgRegField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgRegField.MassMrgId:
                    return Gets().OrderByDescending(x => x.MassMrgId).ToList();

                case (int)MassMrgRegField.GroomId:
                    return Gets().OrderBy(x => x.GroomName).ToList();

                case (int)MassMrgRegField.BrideId:
                    return Gets().OrderBy(x => x.BrideName).ToList();

                case (int)MassMrgRegField.Documents:
                    return Gets().OrderByDescending(x => x.Documents).ToList();

                case (int)MassMrgDonarDetailField.Date:
                    return Gets().OrderByDescending(x => x.Date).ToList();

            }
            return null;
        }
    }
    public enum MassMrgRegField
    {
        Id,
        MassMrgId,
        GroomId,
        BrideId,
        Documents,
        Date
    }
}