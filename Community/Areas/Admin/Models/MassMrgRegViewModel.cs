using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgRegViewModel
    {
        public int Id { get; set; }
        public int MassMrgId { get; set; }
        public int GroomId { get; set; }
        public int BrideId { get; set; }
        public string Documents { get; set; }
        public System.DateTime Date { get; set; }

        public string MassMrgLocation { get; set; }
        public string MassMrgDate { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }

    }
}