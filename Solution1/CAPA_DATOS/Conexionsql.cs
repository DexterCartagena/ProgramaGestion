using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public abstract class Conexionsql
    {
        //"Data Source = .; dataBase=DBSCRUM; User ID = user; Password=contra;"
        SqlConnection conexion = new SqlConnection("Data Source = .; dataBase=DBSCRUM;integrated security = true");

        public SqlConnection AbrirConexion()
        {
            if(conexion.State== System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                return conexion;
            }
            else
            {
                return conexion;
            }
        }
        public SqlConnection CerrarConexion()
        {
            if(conexion.State== System.Data.ConnectionState.Open)
            {
                conexion.Close();
                return conexion;
            }
            else
            {
                return conexion;
            }
        }
    }
}
