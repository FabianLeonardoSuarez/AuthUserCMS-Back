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
    public class Users
    {
        private UsersDB objUserEntities;        
        public Users()
        {
            objUserEntities = new UsersDB();
        }

        public bool CreateUser(BOUser newUser)
        {
            try
            {
                objUserEntities.T_User.Add(ModelObjtoDBObj(newUser));
                return objUserEntities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(BOUser objUser)
        {
            try
            {
                var UserinEnt = objUserEntities.T_User.FirstOrDefault(x => x.IdUser == objUser.IdUser);

                UserinEnt.UserName = objUser.UserName;
                UserinEnt.Password = objUser.Password;
                UserinEnt.Fullname = objUser.Fullname;
                UserinEnt.Address = objUser.Address;
                UserinEnt.Phone = objUser.Phone;
                UserinEnt.Email = objUser.Email;
                UserinEnt.Age = objUser.Age;
                UserinEnt.IdRol = objUser.IdRol;
                
                return objUserEntities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(Int64 delUserId)
        {
            try
            {
                var UserinEnt = objUserEntities.T_User.FirstOrDefault(x => x.IdUser == delUserId);
                objUserEntities.T_User.Remove(UserinEnt);
                return objUserEntities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BOUser ReadUserInfo(string Token)
        {
            try
            {
                
                var userobj = objUserEntities.T_User.FirstOrDefault(x=>x.IdUser == objUserEntities.T_Login_Log.FirstOrDefault(y => y.Token == Token).IdUser);
                var result = new List<BOUser>();

                return DBObjtoModelObj(userobj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<BOUser> GetUsers()
        {
            try
            {
                var userList = objUserEntities.T_User;
                var result = new List<BOUser>();
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

        public string LoginUser(string userName, string password)
        {
            try
            {
                ObjectParameter IdLoginLog = new ObjectParameter("IdLoginLog", typeof(Int64));
                objUserEntities.SP_Login_User(userName, password, IdLoginLog);
                string token = objUserEntities.T_Login_Log.FirstOrDefault(x => x.IdLoginLog == (Int64)IdLoginLog.Value).Token;
                Validations objValidations = new Validations();                
                return token;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        private T_User ModelObjtoDBObj(BOUser newUser)
        {

            return new T_User
            {
                IdUser = newUser.IdUser,
                UserName = newUser.UserName,
                Password = newUser.Password,
                Fullname = newUser.Fullname,
                Address = newUser.Address,
                Phone = newUser.Phone,
                Email = newUser.Email,
                Age = newUser.Age,
                IdRol = newUser.IdRol,  
                T_Rol = new T_Rol { IdRol = newUser.IdRol, RolName = newUser.RolName }
            };
        }

        private BOUser DBObjtoModelObj(T_User newUser)
        {

            return new BOUser
            {
                IdUser = newUser.IdUser,
                UserName = newUser.UserName,
                Password = newUser.Password,
                Fullname = newUser.Fullname,
                Address = newUser.Address,
                Phone = newUser.Phone,
                Email = newUser.Email,
                Age = short.Parse(newUser.Age.ToString()),
                IdRol = short.Parse(newUser.T_Rol.IdRol.ToString()),
                RolName = newUser.T_Rol.RolName,
            };
        }
    }
}
