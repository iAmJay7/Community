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
    
    public partial class StudentLoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentLoan()
        {
            this.LoanRepayments = new HashSet<LoanRepayment>();
        }
    
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SchemeId { get; set; }
        public string Amount { get; set; }
        public string Discription { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<byte> IsPaidUp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanRepayment> LoanRepayments { get; set; }
        public virtual PersonInfo PersonInfo { get; set; }
        public virtual Scheme Scheme { get; set; }
    }
}
