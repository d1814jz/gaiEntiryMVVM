//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gaiEntiry
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        public Driver()
        {
            this.Accounting = new HashSet<Accounting>();
            this.Illegal = new HashSet<Illegal>();
        }
    
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string NumberDL { get; set; }
    
        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual ICollection<Illegal> Illegal { get; set; }
    }
}
