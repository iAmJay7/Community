using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgCommittiesViewModel
    {
        public int Id { get; set; }
        public int MassMrgId { get; set; }
        public int MemberId { get; set; }
        public string Post { get; set; }
        public string MassMrgLocation { get; set; }
        public string MassMrgDate { get; set; }
        public string Member { get; set; }

    }
}