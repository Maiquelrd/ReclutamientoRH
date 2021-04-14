using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace GUI_V_2
{
    public class UserDao
{
    public bool Login(string user, string pass)
    {
    CD_Commands connection = new CD_Commands();
    string resultado= connection.getSpecificData("select Rol_ID from Usuario where Username='" + user + "' and password='" + pass + "'");

        if (resultado==null || resultado== "")
        {
            return false;
        }
            return true;
    }
    public string RolID(string user, string pass)
        {
        CD_Commands connection = new CD_Commands();
        string resultado = connection.getSpecificData("select Rol_ID from Usuario where Username='" + user + "' and password='" + pass + "'");

        return resultado;
        }   
    }
}




