using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using UserServiceDataLayer.Models;
using UserServiceDataLayer.Utilities;
using UserServiceDataLayer.Objects;

namespace UserWS.Controllers
{
    public class PermissionController : ApiController
    {
        [HttpPost]
        [Route("CreatePermission")]
        public bool? CreatePermission(BOComponentPermission newPermission, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Permissions().CreatePermission(newPermission);
            else
                return null;
        }

        [HttpGet]
        [Route("ReadPermissions")]
        public List<BOComponentPermission> ReadPermissions(string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Permissions().GetPermissions();
            else
                return null;
        }


        [HttpGet]
        [Route("ReadUserPermissions")]
        public List<BOComponentPermission> ReadUserPermissions(string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Permissions().GetUserPermissions(Token);
            else
                return null;
        }        

        [HttpGet]
        [Route("ComponentPermissions")]
        public List<BOComponentPermission> ComponentPermissions(short idComponent, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Permissions().ComponentPermissions(idComponent, Token);
            else
                return null;
        }

        [HttpGet]
        [Route("FeaturePermissions")]
        public List<BOFeaturePermission> FeaturePermissions(short idComponent, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Permissions().FeaturePermissions(idComponent, Token);
            else
                return null;
        }
        
        [HttpDelete]
        [Route("DeletePermission")]
        public bool? DeletePermission(int delUserId, string Token)
        {
            if (new Validations().ValidateToken(Token))
                return new Users().DeleteUser(delUserId);
            else
                return null;
        }

    }
}