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
    
    public partial class Accounting
    {
        public int id { get; set; }
        public int idWorker { get; set; }
        public int idDriver { get; set; }
        public int idAuto { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public System.DateTime FirstDate { get; set; }
        public System.DateTime LastDate { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Worker Worker { get; set; }
    }
}