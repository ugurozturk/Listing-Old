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
    
    public partial class user_list
    {
        public int user_list_id { get; set; }
        public int user_id { get; set; }
        public int list_id { get; set; }
        public Nullable<int> score { get; set; }
        public int episode_complete { get; set; }
        public int list_status_id { get; set; }
        public Nullable<System.DateTime> addeddate { get; set; }
        public string user_tags { get; set; }
    
        public virtual list list { get; set; }
        public virtual user user { get; set; }
        public virtual user_list_status user_list_status { get; set; }
    }
}
