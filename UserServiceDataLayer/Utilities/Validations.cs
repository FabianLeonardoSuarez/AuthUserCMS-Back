using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace UserServiceDataLayer.Utilities
{
    public class Validations
    {
        private UsersDB objUserEntities;
        public Validations()
        {
            objUserEntities = new UsersDB();
        }
        public bool ValidateToken(string Token)
        {
            try
            {
                int ValidTokenTime = int.Parse(WebConfigurationManager.AppSettings["ValidTokenTime"]);
                var modelresult = objUserEntities.SP_Validate_Token(Token, ValidTokenTime);
                return (bool)modelresult.ToList()[0];
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
