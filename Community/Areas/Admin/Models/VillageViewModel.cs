using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class VillageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Taluka { get; set; }
        public string District { get; set; }
        public DateTime Date { get; set; }
    }
}