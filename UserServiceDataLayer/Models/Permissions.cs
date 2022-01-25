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
    public class Permissions
    {
        private UsersDB objUserEntities;
        public Permissions()
        {
            objUserEntities = new UsersDB();
        }

        public bool CreatePermission(BOComponentPermission newPermission)
        {
            try
            {
                objUserEntities.T_Rol_Component_Permission.Add(ModelObjtoDBObj(newPermission));
                return objUserEntities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePermission(BOComponentPermission delPermission)
        {
            try
            {
                var UserinEnt = objUserEntities.T_Rol_Component_Permission.FirstOrDefault(x => x.IdRol == delPermission.IdRol && x.IdComponent == delPermission.IdComponent && x.IdPermission == delPermission.IdPermission);
                objUserEntities.T_Rol_Component_Permission.Remove(UserinEnt);
                return objUserEntities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public List<BOComponentPermission> ComponentPermissions(short idComponent, string Token)
        {
            try
            {
                var permissionList = objUserEntities.SP_Component_Permissions(idComponent, Token);

                var result = new List<BOComponentPermission>();
                foreach (var tempPermission in permissionList.ToList())
                {
                    result.Add(DBObjtoModelObj(objUserEntities.T_Rol_Component_Permission.FirstOrDefault(x => x.IdComponent == tempPermission.IdComponent && x.IdRol == tempPermission.IdRol && x.IdPermission == tempPermission.IdPermission)));                    
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<BOFeaturePermission> FeaturePermissions(short idComponent, string Token)
        {
            try
            {
                var permissionList = objUserEntities.SP_Feature_Permissions(idComponent, Token);

                var result = new List<BOFeaturePermission>();
                foreach (var tempPermission in permissionList.ToList())
                {
                    result.Add(DBObjtoModelObj(objUserEntities.T_Rol_Component_Feature.FirstOrDefault(x => x.IdFeature == tempPermission.IdFeature && x.IdRol == tempPermission.IdRol)));
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<BOComponentPermission> GetPermissions()
        {
            try
            {
                var permissionList = objUserEntities.T_Rol_Component_Permission;
                var result = new List<BOComponentPermission>();
                foreach (var tempPermission in permissionList.ToList())
                {
                    result.Add(DBObjtoModelObj(tempPermission));
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<BOComponentPermission> GetUserPermissions(string Token)
        {
            try
            {
                var userobject = objUserEntities.T_User.FirstOrDefault(x => x.IdUser == objUserEntities.T_Login_Log.FirstOrDefault(y => y.Token == Token).IdUser);
                var permissionList = objUserEntities.T_Rol_Component_Permission.Where(x=>x.IdRol == userobject.IdRol);
                var result = new List<BOComponentPermission>();
                foreach (var tempPermission in permissionList.ToList())
                {
                    result.Add(DBObjtoModelObj(tempPermission));
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private T_Rol_Component_Permission ModelObjtoDBObj(BOComponentPermission newPermission)
        {
            return new T_Rol_Component_Permission
            {
                T_Rol = new T_Rol { IdRol = newPermission.IdRol },
                T_Component = new T_Component { IdComponent = newPermission.IdComponent },
                T_Permission = new T_Permission { IdPermission = newPermission.IdPermission },
                CreatorUser = newPermission.CreatorUser,
                CreationDate = newPermission.CreationDate,
            };
        }

        private BOComponentPermission DBObjtoModelObj(T_Rol_Component_Permission newPermission)
        {

            return new BOComponentPermission
            {
                IdRol = newPermission.T_Rol.IdRol,
                RolName = newPermission.T_Rol.RolName,
                IdComponent = newPermission.T_Component.IdComponent, 
                ComponentName = newPermission.T_Component.ComponentName,
                IdPermission = newPermission.T_Permission.IdPermission,  
                PermissionName = newPermission.T_Permission.PermissionName,
                CreatorUser = long.Parse(newPermission.CreatorUser.ToString()),
                CreationDate = DateTime.Parse(newPermission.CreationDate.ToString()),
            };
        }

        private BOFeaturePermission DBObjtoModelObj(T_Rol_Component_Feature newPermission)
        {

            return new BOFeaturePermission
            {
                IdRol = newPermission.T_Rol.IdRol,
                RolName = newPermission.T_Rol.RolName,
                IdComponent = newPermission.T_Feature.T_Component.IdComponent,
                ComponentName = newPermission.T_Feature.T_Component.ComponentName,
                IdFeature = newPermission.T_Feature.IdFeature,
                FeatureName = newPermission.T_Feature.FeatureName,
                CreatorUser = long.Parse(newPermission.CreatorUser.ToString()),
                CreationDate = DateTime.Parse(newPermission.CreationDate.ToString()),
            };
        }

    }
}
