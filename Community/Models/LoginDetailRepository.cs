using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Community.Models
{
    public class LoginDetailRepository
    {
        public static bool Login(LoginDetailViewModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.LoginDetails.FirstOrDefault(x => x.Email == model.Email || x.Mobile == model.Mobile);
                if (search != null)
                {
                    if (Crypto.VerifyHashedPassword(search.Password, model.Password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}