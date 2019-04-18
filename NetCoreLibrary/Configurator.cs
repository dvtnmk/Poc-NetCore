using Microsoft.Extensions.Configuration;
using System;

namespace NetCoreLibrary
{
    public static class Configurator
    {
        public static void Initialize(IConfiguration configuration)
        {
            GetLocalAppConfiguration(configuration);
        }
        private static string _sqlConnection;
        public static string SqlConnection
        {
            get { return _sqlConnection; }
        }

        private static void GetLocalAppConfiguration(IConfiguration configuration)
        {
            _sqlConnection = configuration.GetSection("ConnectionStrings:mssql_connect").Value;
        }
    }
}
