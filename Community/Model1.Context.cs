﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Community
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CommunityDbEntities : DbContext
    {
        public CommunityDbEntities()
            : base("name=CommunityDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FamilyInfo> FamilyInfoes { get; set; }
        public virtual DbSet<GeneralDonarDetail> GeneralDonarDetails { get; set; }
        public virtual DbSet<GeneralLoan> GeneralLoans { get; set; }
        public virtual DbSet<LoanRepayment> LoanRepayments { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<Marriage> Marriages { get; set; }
        public virtual DbSet<MassMrg> MassMrgs { get; set; }
        public virtual DbSet<MassMrgCommitty> MassMrgCommitties { get; set; }
        public virtual DbSet<MassMrgDonarDetail> MassMrgDonarDetails { get; set; }
        public virtual DbSet<MassMrgExpenditure> MassMrgExpenditures { get; set; }
        public virtual DbSet<MassMrgGift> MassMrgGifts { get; set; }
        public virtual DbSet<MassMrgReg> MassMrgRegs { get; set; }
        public virtual DbSet<OtherPersonInfo> OtherPersonInfoes { get; set; }
        public virtual DbSet<PersonInfo> PersonInfoes { get; set; }
        public virtual DbSet<Sakh> Sakhs { get; set; }
        public virtual DbSet<Scheme> Schemes { get; set; }
        public virtual DbSet<StudentLoan> StudentLoans { get; set; }
        public virtual DbSet<Village> Villages { get; set; }
        public virtual DbSet<VillageStatatic> VillageStatatics { get; set; }
    }
}
