using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class SakhViewModel
    {
        public int Id { get; set; }
        public int VillageId { get; set; }
        public VillageViewModel Village { get; set; }
        public string Name { get; set; }
    }
}