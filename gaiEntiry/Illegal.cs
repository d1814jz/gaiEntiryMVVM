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
    
    public partial class Illegal
    {
        public int id { get; set; }
        public int idIllegalType { get; set; }
        public int idDuty { get; set; }
        public int idAuto { get; set; }
        public int idDriver { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Duty Duty { get; set; }
        public virtual IllegalType IllegalType { get; set; }
    }
}