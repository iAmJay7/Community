using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgCommittiesRepository
    {
        public static bool Add(MassMrgCommittiesViewModel model)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.MassMrgCommitties.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.MassMrgCommitties.Add(new MassMrgCommitty
                    {
                        Id = model.Id,
                        MassMrgId = model.MassMrgId,
                        MemberId = model.MemberId,
                        Post = model.Post
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static List<MassMrgCommittiesViewModel> Gets()
        {
            var list = new List<MassMrgCommittiesViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var a in db.MassMrgCommitties)
                {
                    list.Add(new MassMrgCommittiesViewModel
                    {
                        Id = a.Id,
                        MassMrgId=a.MassMrgId,
                        MemberId=a.MemberId,
                        Post=a.Post,
                        MassMrgLocation=a.MassMrg.Location,
                        MassMrgDate=a.MassMrg.DateTime.ToString(),
                        Member=a.PersonInfo.Name
                    });
                }
                return list;
            }
        }

        public static List<MassMrgCommittiesViewModel> GetsByMassMrgId(int id)
        {
            return Gets().Where(x => x.MassMrgId == id).ToList();
        }
        public static List<MassMrgCommittiesViewModel> GetsOrderBy(int Field)
        {
            switch (Field)
            {
                case (int)MassMrgCommittiesField.Id:
                    return Gets().OrderByDescending(x => x.Id).ToList();

                case (int)MassMrgCommittiesField.MassMrgId:
                    return Gets().OrderByDescending(x => x.MassMrgId).ToList();

                case (int)MassMrgCommittiesField.MemberId:
                    return Gets().OrderByDescending(x => x.MemberId).ToList();

                case (int)MassMrgCommittiesField.Post:
                    return Gets().OrderByDescending(x => x.Post).ToList();

            }
            return null;
        }
    }
    public enum MassMrgCommittiesField
    {
        Id,
        MassMrgId,
        MemberId,
        Post
    }
}