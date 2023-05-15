using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FindYourFate
{
    public class DataBase
    {
        SqlConnection connection = new SqlConnection(@"Data Source = Project3DataBase.mssql.somee.com;" + "Initial Catalog=Project3DataBase;" + "User id=	cargoesbrr_SQLLogin_1;" + "Password=nchbzqmryy;");

        public void openConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void closeConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
