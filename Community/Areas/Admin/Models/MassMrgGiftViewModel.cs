using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Areas.Admin.Models
{
    public class MassMrgGiftViewModel
    {
        public int Id { get; set; }
        public int MassMrgId { get; set; }
        public int GiftTo { get; set; }
        public int GiftFrom { get; set; }

        public string MassMrgLocation { get; set; }
        public string MassMrgDate { get; set; }
        public string GiftToBride { get; set; }
        public string GiftToGroom { get; set; }
        public string GiftFromPerson { get; set; }

    }
}