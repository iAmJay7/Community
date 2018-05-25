using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Models
{
    public class LoginDetailViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsVarified { get; set; }
        public bool IsActive { get; set; }
    }
}