using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgGiftRepository
    {
        public static bool Add(MassMrgGiftViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.MassMrgGifts.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgGifts.Add(new MassMrgGift
                    {
                        MassMrgId=model.MassMrgId,
                        GiftTo=model.GiftTo,
                        GiftFrom=model.GiftFrom
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<MassMrgGiftViewModel> Gets()
        {
            var list = new List<MassMrgGiftViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.MassMrgGifts)
                {
                    list.Add(new MassMrgGiftViewModel
                    {
                        Id = a.Id,
                        MassMrgId=a.MassMrgId,
                        GiftTo=a.GiftTo,
                        GiftFrom=a.GiftFrom,
                        MassMrgLocation=a.MassMrg.Location,
                        MassMrgDate=a.MassMrg.DateTime.ToString(),
                        GiftToBride=a.MassMrgReg.PersonInfo.Name,
                        GiftToGroom=a.MassMrgReg.PersonInfo1.Name,
                        GiftFromPerson=a.PersonInfo.Name
                    });
                }
                return list;
            }
        }

        public static List<MassMrgGiftViewModel> GetsByMassMrgId(int id)
        {
            return Gets().Where(x => x.MassMrgId == id).ToList();
        }
        public static List<MassMrgGiftViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgGiftField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgGiftField.MassMrgId:
                    return Gets().OrderByDescending(x => x.MassMrgId).ToList();

                case (int)MassMrgGiftField.GiftTo:
                    return Gets().OrderByDescending(x => x.GiftTo).ToList();

                case (int)MassMrgGiftField.GiftFrom:
                    return Gets().OrderByDescending(x => x.GiftFromPerson).ToList();

                
            }
            return null;
        }
    }
    public enum MassMrgGiftField
    {
        Id,
        MassMrgId,
        GiftTo,
        GiftFrom
    }
}