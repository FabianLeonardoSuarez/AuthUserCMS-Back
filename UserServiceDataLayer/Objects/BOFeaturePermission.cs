using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceDataLayer.Objects
{
    public class BOFeaturePermission
    {
        public short IdRol { get; set; }
        public string RolName { get; set; }

        public int IdFeature { get; set; }
        public string FeatureName { get; set; }
        public short IdComponent { get; set; }

        public string ComponentName { get; set; }

        public Int64 CreatorUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
