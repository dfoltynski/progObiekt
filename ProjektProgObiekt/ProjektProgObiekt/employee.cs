//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektProgObiekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public int role { get; set; }
        public int company { get; set; }
        public int manager { get; set; }
    
        public virtual company company1 { get; set; }
        public virtual manager manager1 { get; set; }
        public virtual role role1 { get; set; }
    }
}
