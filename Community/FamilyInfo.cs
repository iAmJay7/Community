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
    
    public partial class FamilyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamilyInfo()
        {
            this.PersonInfoes = new HashSet<PersonInfo>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SakhId { get; set; }
        public string Address { get; set; }
    
        public virtual Sakh Sakh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonInfo> PersonInfoes { get; set; }
    }
}
