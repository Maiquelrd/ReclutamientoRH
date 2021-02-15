using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace GUI_V_2
{
    public class CD_Commands
    {
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        CD_Conexion conexion = new CD_Conexion();

        public DataTable getData(string command)
        {

            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = command;
                comando.CommandType = CommandType.Text;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }finally
            {
                conexion.CerrarConexion();
            }
           

            return tabla;

        }





    }
}



