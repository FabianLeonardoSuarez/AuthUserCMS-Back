using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UserServiceDataLayer.Models;
using UserServiceDataLayer.Utilities;
using UserServiceDataLayer.Objects;

namespace UserWS.Controllers
{
    //[EnableCors(origins: "http://localhost:3000/", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]        
        [Route("CreateUser")]
        public bool? CreateUser(BOUser newUser, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().CreateUser(newUser);
            else
                return null;
        }

        [HttpGet]
        [Route("ReadUsers")]
        public List<BOUser> GetUsersList(string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().GetUsers();
            else
                return null;
        }

        [HttpGet]
        [Route("ReadUserInfo")]
        public BOUser ReadUserInfo(string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().ReadUserInfo(Token);
            else
                return null;
        }

        [HttpGet]
        [Route("ReadRoles")]
        public List<BORol> GetRolesList(string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Roles().GetRoles();
            else
                return null;
        }

        [HttpPut]
        [Route("UpdateUser")]
        public bool? UpdateUser(BOUser objUser, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().UpdateUser(objUser);
            else
                return null;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public bool? DeleteUser(long delUserId, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().DeleteUser(delUserId);
            else
                return null;
        }

        [HttpGet]
        [Route("Login")]
        public string GetToken(string username, string password)
        {           
            return new Users().LoginUser(username, password);
        }      
    }
}