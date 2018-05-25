using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Models
{
    public class SessionWrapper
    {
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["userId"] != null)
                {
                    return (int)HttpContext.Current.Session["userId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["userId"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["userName"] != null)
                {
                    return (string)HttpContext.Current.Session["userName"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["userName"] = value;
            }
        }

        public static int MassMrgId
        {
            get
            {
                if (HttpContext.Current.Session["MassMrgId"] != null)
                {
                    return (int)HttpContext.Current.Session["MassMrgId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["MassMrgId"] = value;
            }
        }
    }
}