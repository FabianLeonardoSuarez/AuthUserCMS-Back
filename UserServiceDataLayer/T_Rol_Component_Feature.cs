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
    
    public partial class T_Rol_Component_Feature
    {
        public short IdRol { get; set; }
        public int IdFeature { get; set; }
        public Nullable<long> CreatorUser { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    
        public virtual T_Feature T_Feature { get; set; }
        public virtual T_Rol T_Rol { get; set; }
    }
}
