//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserServiceDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Login_Log
    {
        public long IdLoginLog { get; set; }
        public long IdUser { get; set; }
        public System.DateTime LoginDate { get; set; }
        public string Token { get; set; }
    
        public virtual T_User T_User { get; set; }
    }
}
