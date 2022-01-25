using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace UserServiceDataLayer.Utilities
{
    public class ConnectionHelper
    {
        private readonly EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
        public string GetCS()
        {
            
            entityBuilder.ProviderConnectionString = ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString;
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.Metadata = GetMetadata("UsersDBModel");

            return entityBuilder.ConnectionString;
        }
        private string GetMetadata(string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
                throw new ArgumentNullException("Model Name for EF can't be null. Please contact the admin");

            return @"res://*/EF." + modelName + ".csdl"
                    + "|res://*/EF." + modelName + ".ssdl"
                    + "|res://*/EF." + modelName + ".msl";
        }
    }
}
