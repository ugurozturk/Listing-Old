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
    
    public partial class list_type
    {
        public list_type()
        {
            this.list = new HashSet<list>();
            this.user_list_status = new HashSet<user_list_status>();
        }
    
        public int list_type_id { get; set; }
        public string type_name { get; set; }
    
        public virtual ICollection<list> list { get; set; }
        public virtual ICollection<user_list_status> user_list_status { get; set; }
    }
}