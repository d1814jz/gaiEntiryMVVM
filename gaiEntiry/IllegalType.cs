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
    using gaiEntiry.Repositories;
    using System;
    using System.Collections.Generic;
    
    public partial class IllegalType
    {
        public IllegalType()
        {
            this.Illegal = new HashSet<Illegal>();
        }
    
        public int id { get; set; }
        public string IllegalType1 { get; set; }
        public int Fine { get; set; }
        public bool Notice { get; set; }
        public int Tod { get; set; }
    
        public virtual ICollection<Illegal> Illegal { get; set; }
        
        //IllegalTypeIllegal
        public List<Illegal> IllegalTypeIllegal
        {
            get
            {
                return IllegalRepositories.GetAllIllegalsByIllegalTypeId(id);
            }
        }
    }
}
