﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgDonarDetailViewModel
    {
        public int Id { get; set; }
        public int MassMrgId { get; set; }
        public int DonarId { get; set; }
        public string Amount { get; set; }
        public string Discription { get; set; }
        public System.DateTime Date { get; set; }
        public string MassMrgLocation { get; set; }
        public string MassMrgDate { get; set; }
        public string Donar { get; set; }

    }
}