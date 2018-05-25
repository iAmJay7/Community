using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Community.Models
{
    public class PersonInfoRepository
    {
        public static bool Add(PersonInfoViewModel model)
        {
            var m = new FamilyInfoViewModel
            {
                Id = model.FId,
                SakhId = model.SakhId,
                Address = model.Address
            };
            using (var db = new CommunityDbEntities())
            {
                var search = db.PersonInfoes.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.PersonInfoes.Add(new PersonInfo
                    {
                        Id = model.Id,

                        FamilyId = model.FatherId != null ?
                        FamilyInfoRepository.GetFamilyId(model.FatherId) :
                        model.FamilyId,
                        
                        Name = model.Name,
                        Gender = model.Gender,

                        Birthdate = model.Birthdate,
                        BirthPlace = model.BirthPlace,
                        Education = model.Education,
                        Occupation = model.Occupation,
                        FatherId = model.FatherId,
                        MotherId = model.MotherId,
                        CurrentAddresss = model.CurrentAddresss,
                        IsMarried = model.IsMarried,
                        Height = model.Height,
                        Weight = model.Weight,
                        SakhId=model.SakhId


                    });
                    using(var db1=new CommunityDbEntities())
                    {
                        db1.LoginDetails.Add(new LoginDetail
                        {
                            Id = model.Id,
                            Email = model.Email,
                            Mobile = model.Mobile,
                            Password = Crypto.HashPassword(model.Password),
                            LastLogin = DateTime.Now,
                            IsVerified = 0,
                            Active = 1
                        });
                        db1.SaveChanges();
                    }
                    db.SaveChanges();
                    
                    return true;
                }
            }
            return false;
        }

        public static List<PersonInfoViewModel> FetchPersonsListBySakhId(int sakhId)
        {
            var list = new List<PersonInfoViewModel>();
            using (var db = new CommunityDbEntities())
            {
                foreach (var b in db.PersonInfoes.Where(x => x.SakhId == sakhId))
                {
                    list.Add(new PersonInfoViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        FatherId = b.FatherId,
                        Gender = b.Gender,
                        Age = b.Age
                    });
                }
                return list;
            }
            return null;
        }

        public static List<PersonInfoViewModel> GetsByVillageId(int id)
        {
            var list = new List<PersonInfoViewModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach(var a in db.Sakhs.Where(x => x.VillageId == id))
                {
                    var list1 = FetchPersonsListBySakhId(a.Id);
                    list.AddRange(list1);
                }
                return list;
            }
        }

        public static int GetIdByEmail(string Email)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.LoginDetails.FirstOrDefault(x => x.Email == Email);
                if (search != null)
                {
                    return search.Id;
                }
            }
            return 0;
        }

        public static string GetNameById(int id)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.PersonInfoes.FirstOrDefault(x => x.Id == id);
                if (search != null)
                {
                    return search.Name;
                }
            }
            return "";
        }

        public static PersonInfoViewModel GetPersonById(int id)
        {
            using (var db = new CommunityDbEntities())
            {
                var search = db.PersonInfoes.FirstOrDefault(x => x.Id == id);
                if (search != null)
                {
                    return new PersonInfoViewModel
                    {
                        Id = search.Id,
                        Name = search.Name,
                        SakhId=(int)search.SakhId,
                        Age = search.Age,
                        Gender = search.Gender,
                        Education=search.Education,
                        Occupation = search.Occupation,
                        Address = search.CurrentAddresss
                    };
                }
            }
            return null;
        }
    }
}