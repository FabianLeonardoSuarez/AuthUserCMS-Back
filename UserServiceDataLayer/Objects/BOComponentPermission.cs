using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceDataLayer.Objects
{
    public class BOComponentPermission
    {
        public short IdRol { get; set; }

        public string RolName { get; set; }
        public short IdComponent { get; set; }

        public string ComponentName { get; set; }
        public short IdPermission { get; set; }

        public string PermissionName { get; set; }
        public Int64 CreatorUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
