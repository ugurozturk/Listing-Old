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
    
    public partial class user_group
    {
        public user_group()
        {
            this.user = new HashSet<user>();
        }
    
        public int user_group_id { get; set; }
        public string group_name { get; set; }
    
        public virtual ICollection<user> user { get; set; }
    }
}