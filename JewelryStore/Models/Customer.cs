//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JewelryStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Feedback = new HashSet<Feedback>();
            this.Order = new HashSet<Order>();
            this.ReplyFeedback = new HashSet<ReplyFeedback>();
        }
    
        public long ID { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string Birthday { get; set; }
        public int Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplyFeedback> ReplyFeedback { get; set; }
    }
}
