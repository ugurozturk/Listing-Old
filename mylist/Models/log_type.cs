//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mylist.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class log_type
    {
        public log_type()
        {
            this.logs = new HashSet<logs>();
        }
    
        public int log_type_id { get; set; }
        public string log_type_name { get; set; }
    
        public virtual ICollection<logs> logs { get; set; }
    }
}