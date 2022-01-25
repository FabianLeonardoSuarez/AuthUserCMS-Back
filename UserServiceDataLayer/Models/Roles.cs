using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using UserServiceDataLayer.Utilities;
using UserServiceDataLayer.Objects;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace UserServiceDataLayer.Models
{
    public class Roles
    {
        private UsersDB objUserEntities;
        public Roles()
        {
            objUserEntities = new UsersDB();
        }

        public List<BORol> GetRoles()
        {
            try
            {
                var userList = objUserEntities.T_Rol;
                var result = new List<BORol>();
                foreach (var tempuser in userList.ToList())
                {
                    result.Add(DBObjtoModelObj(tempuser));
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }        

        private BORol DBObjtoModelObj(T_Rol newRol)
        {

            return new BORol
            {
                IdRol = newRol.IdRol,
                RolName = newRol.RolName,
                CreationDate = DateTime.Parse(newRol.CreationDate.ToString()),
                CreatorUser = long.Parse(newRol.CreatorUser.ToString())
            };
        }

    }
}
