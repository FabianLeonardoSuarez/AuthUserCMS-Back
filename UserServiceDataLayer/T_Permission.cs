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
    
    public partial class T_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Permission()
        {
            this.T_Rol_Component_Permission = new HashSet<T_Rol_Component_Permission>();
        }
    
        public short IdPermission { get; set; }
        public string PermissionName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Rol_Component_Permission> T_Rol_Component_Permission { get; set; }
    }
}