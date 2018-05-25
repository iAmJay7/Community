using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Models
{
    public class FamilyInfoViewModel
    {
        public int Id { get; set; }

        public int SakhId { get; set; }
        public SakhViewModel Sakh { get; set; }
        public string Address { get; set; }
    }
}