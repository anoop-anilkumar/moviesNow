using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace moviesNow.Connection
{
    public class dbConnect
    {
        public OdbcConnection connection;
        protected OdbcConnection DBConnection
        {
            get
            {

                var connectionString = "Dsn=moviesNow;uid=mAdmin;pwd=12345";
                connection = new OdbcConnection(connectionString);
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                    
                connection.Open();
                return connection;
            }
        }

        public OdbcConnection GetConnection()
        {
            return DBConnection;
        }
    }
}