//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class LoanRepayment
    {
        public int Id { get; set; }
        public Nullable<int> GeneralLoanId { get; set; }
        public Nullable<int> StudentLoanId { get; set; }
        public string PayAmount { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual GeneralLoan GeneralLoan { get; set; }
        public virtual StudentLoan StudentLoan { get; set; }
    }
}
