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
    public class BOUser
    {
        public Int64 IdUser   {get;set;}
        public string UserName {get;set;}
        public string Password {get;set;}
        public string Fullname {get;set;}
        public string Address  {get;set;}
        public string Phone    {get;set;}
        public string Email    {get;set;}
        public short Age      {get;set;}
        public short IdRol    { get; set; }
        public string RolName { get; set; }
    }
}
