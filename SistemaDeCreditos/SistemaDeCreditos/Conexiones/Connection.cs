using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Conexiones
{
    public interface Connection
    {
        string Server { get; set; }
        string DataBase { get; set; }
        string User { get; set; }
        string Pass { get; set; }
        Connection Connect();
        bool DoQuery();
    }
    public class SQLServer: Connection
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public Connection Connect()
        {
            return new SQLServer();
        }
        public bool DoQuery()
        {
            return true;
        }
    }


    public class DBF <Connection>{ }
}
