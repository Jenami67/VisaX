//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisaXCentral
{
    using System;
    using System.Collections.Generic;
    
    public partial class RemoteRequest
    {
        public int ID { get; set; }
        public int ShiftID { get; set; }
        public string FullName { get; set; }
        public byte Gender { get; set; }
        public string PassportNum { get; set; }
        public Nullable<System.DateTime> BornDate { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
    
        public virtual RemoteShift RemoteShift { get; set; }
    }
}