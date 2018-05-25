using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Community.Areas.Admin.Models
{
    public class PersonInfoDao
    {
        public static bool Add(PersonInfoVModel model)
        {
            using(var db=new CommunityDbEntities())
            {
                var search = db.PersonInfoes.FirstOrDefault(x => x.Id == model.Id);
                if (search == null)
                {
                    db.PersonInfoes.Add(new PersonInfo
                    {
                        Id = model.Id,

                        FamilyId = model.FamilyId,
                        Name = model.Name,
                        Gender = model.Gender,
                        Age=model.Age,
                        Birthdate = model.Birthdate,
                        BirthPlace = model.BirthPlace,
                        Education = model.Education,
                        Occupation = model.Occupation,
                        FatherId = model.FatherId,
                        MotherId = model.MotherId,
                        CurrentAddresss = model.CurrentAddress,
                        IsMarried = model.IsMarried,
                        Height = model.Height,
                        Weight = model.Weight,
                        SakhId = model.SakhId,
                        Photo=model.Photo
                    });
                    using (var db1 = new CommunityDbEntities())
                    {
                        db1.LoginDetails.Add(new LoginDetail
                        {
                            Id = model.Id,
                            Email = model.Email,
                            Mobile = model.Mobile,
                            Password = Crypto.HashPassword("123123"),
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

        public static List<PersonInfoVModel> Gets()
        {
            var list = new List<PersonInfoVModel>();
            using(var db=new CommunityDbEntities())
            {
                foreach (var a in db.PersonInfoes)
                {
                    list.Add(new PersonInfoVModel
                    {
                        Id = a.Id,
                        FamilyId=a.FamilyId,
                        Name = a.Name,
                        Gender = a.Gender,
                        Age = a.Age,
                        Birthdate = a.Birthdate,
                        BirthPlace = a.BirthPlace,
                        Education = a.Education,
                        Occupation = a.Occupation,
                        FatherId = a.FatherId,
                        FatherName=a.PersonInfo2==null?"":a.PersonInfo2.Name,
                        MotherId = a.MotherId,
                        MotherName=a.PersonInfo3.Name,
                        CurrentAddress = a.CurrentAddresss,
                        IsMarried = a.IsMarried,
                        Height = a.Height,
                        Weight = a.Weight,
                        SakhId = a.SakhId ?? 0,
                        SakhName=a.Sakh.Name,
                        Photo = a.Photo

                    });
                }
            }
            return list;
        }

        public static List<PersonInfoVModel> GetsOrderBy(int field)
        {
            PersonInfoField f = (PersonInfoField)field;
            switch (f)
            {
                case PersonInfoField.Id:
                    return Gets().OrderBy(x => x.Id).ToList();
                case PersonInfoField.FamilyId:
                    return Gets().OrderBy(x => x.FamilyId).ToList();
                case PersonInfoField.Name:
                    return Gets().OrderBy(x => x.Name).ToList();
                case PersonInfoField.Gender:
                    return Gets().OrderBy(x => x.Gender).ToList();
                case PersonInfoField.Age:
                    return Gets().OrderBy(x => x.Age).ToList();
                case PersonInfoField.BirthDate:
                    return Gets().OrderBy(x => x.Birthdate).ToList();
                case PersonInfoField.BirthPlace:
                    return Gets().OrderBy(x => x.BirthPlace).ToList();
                case PersonInfoField.Education:
                    return Gets().OrderBy(x => x.Education).ToList();
                case PersonInfoField.Occupation:
                    return Gets().OrderBy(x => x.Occupation).ToList();
                case PersonInfoField.Father:
                    return Gets().OrderBy(x => x.FatherName).ToList();
                case PersonInfoField.Mother:
                    return Gets().OrderBy(x => x.MotherName).ToList();
                case PersonInfoField.CAddress:
                    return Gets().OrderBy(x => x.CurrentAddress).ToList();
                case PersonInfoField.Sakh:
                    return Gets().OrderBy(x => x.SakhName).ToList();
                case PersonInfoField.Photo:
                    return Gets().OrderBy(x => x.Photo).ToList();

            }
            return null;
        }
    }

    public enum PersonInfoField
    {
        Id,
        FamilyId,
        Name,
        Gender,
        Age,
        BirthDate,
        BirthPlace,
        Education,
        Occupation,
        Father,
        Mother,
        CAddress,
        Sakh,
        Photo
    }
}