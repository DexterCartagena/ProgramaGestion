using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class CD_PRODUCTBACK:Conexionsql
    {
        SqlCommand comando = new SqlCommand();
        SqlDataReader leerFilas;
        DataTable tabla = new DataTable();

        public DataTable listRegistrosOficial()
        {
            comando.Parameters.Clear();
            tabla.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT * FROM VIS_REGPRODUCT";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            CerrarConexion();
            return tabla;
        }

        public bool AgregarRegistroProductBack(string item,string detalle, string creacion, string fin, int prioridad, int estadoof)
        {
            comando.Parameters.Clear();
            tabla.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "ADDProductBack";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@item",item);
            comando.Parameters.AddWithValue("@detalle", detalle);
            comando.Parameters.AddWithValue("@creacion", creacion);
            comando.Parameters.AddWithValue("@fin", fin);
            comando.Parameters.AddWithValue("@prioridad", prioridad);
            comando.Parameters.AddWithValue("@estadoOf", estadoof);
            if(comando.ExecuteNonQuery() == 1)
            {
                CerrarConexion();
                return true;
            }
            else
            {
                CerrarConexion();
                return false;
            }
        }
        public DataTable listPrioridad()
        {
            tabla.Clear();
            comando.Parameters.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT * FROM prioridad";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            return tabla;
        }
        public bool ModifRegProducBack(int cod,string item, string detalle, string creacion, string fin,int estado, int prioridad, int estadoof)
        {
            comando.Parameters.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "ModfRegProducBak";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod",cod);
            comando.Parameters.AddWithValue("@item",item);
            comando.Parameters.AddWithValue("@detalle", detalle);
            comando.Parameters.AddWithValue("@creacion", creacion);
            comando.Parameters.AddWithValue("@fin", fin);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@prioridad", prioridad);
            comando.Parameters.AddWithValue("@estadoof", estadoof);
            if (comando.ExecuteNonQuery() == 1)
            {
                CerrarConexion();
                return true;
            }
            else
            {
                CerrarConexion();
                return false;
            }

        }
        public bool EliminarRegProducBack(int cod)
        {
            comando.Parameters.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "DesacRegProductBack";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cod", cod);
            if (comando.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
