//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisaX
{
    using System;
    using System.Collections.Generic;
    
    public partial class RemoteUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RemoteUser()
        {
            this.RemoteShifts = new HashSet<RemoteShift>();
            this.Messages = new HashSet<Message>();
        }
    
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public System.DateTime LastSeen { get; set; }
        public bool Enabled { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemoteShift> RemoteShifts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
