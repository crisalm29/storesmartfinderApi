//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class locals
    {
        public locals()
        {
            this.promos_events = new HashSet<promos_events>();
        }
    
        public int id { get; set; }
        public int establishment { get; set; }
        public string google_key { get; set; }
        public string zone { get; set; }
        public string telefono { get; set; }
    
        public virtual establishments establishments { get; set; }
        public virtual ICollection<promos_events> promos_events { get; set; }
    }
}
