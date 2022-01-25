using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceDataLayer.Objects
{
    /// <summary>
    /// Objeto de Negocio para la entidad Usuario
    /// </summary>
    public class BORol
    {
        public short IdRol        {get;set;} 
        public string RolName      {get;set;}
        public DateTime CreationDate {get;set;}
        public Int64 CreatorUser { get; set; }
    }
}
