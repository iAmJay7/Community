using Community.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Models
{
    public class PersonInfoViewModel
    {
        public int Id { get; set; }
        public Nullable<int> FamilyId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> FatherId { get; set; }
        public PersonInfoViewModel Father { get; set; }
        public Nullable<int> MotherId { get; set; }
        public PersonInfoViewModel Mother { get; set; }
        public Nullable<byte> IsDead { get; set; }
        public string CurrentAddresss { get; set; }
        public string Mobile { get; set; }
        public Nullable<byte> IsMemberOfCommunityServiceCenter { get; set; }
        public Nullable<System.DateTime> DeathDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<byte> IsMarried { get; set; }
        public string Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Photo { get; set; }

        //family detail

        public int FId { get; set; }
        public int VillageId { get; set; }
        public VillageViewModel Village { get; set; }
        public int SakhId { get; set; }
        public string Address { get; set; }
    }
}