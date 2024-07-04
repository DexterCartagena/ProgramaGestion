using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class CD_SPRINTBACK: Conexionsql
    {
        SqlCommand comando = new SqlCommand();
        SqlDataReader leerFilas;
        DataTable tabla = new DataTable();

        public DataTable ListSprintBack()
        {
            comando.Parameters.Clear();
            tabla.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT * FROM VIS_REGSPRINT";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            return tabla;
        }
        public DataTable listPrioridad()
        {
            comando.Parameters.Clear();
            tabla = new DataTable();
            comando.Connection = AbrirConexion();
            comando.CommandText = "Select * from Prioridad";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            return tabla;
        }
        public DataTable listArea()
        {
            comando.Parameters.Clear();
            tabla = new DataTable();
            comando.Connection = AbrirConexion();
            comando.CommandText = "Select * from Area";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            return tabla;
        }
        public DataTable listEncargado()
        {
            comando.Parameters.Clear();
            tabla = new DataTable();
            comando.Connection = AbrirConexion();
            comando.CommandText = "Select cod, nombre from usuario";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            return tabla;
        }
        public bool agregarRegSprintOf(int codrdp,int prioridad,string detalle,int area,int encargado,string inicio,string fin,int estado,int estadoof)
        {
            int cont = 0;
            comando.Parameters.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "ADDSprintBack";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codpb", codrdp);
            comando.Parameters.AddWithValue("@prioridad", prioridad);
            comando.Parameters.AddWithValue("@detalle", detalle);
            comando.Parameters.AddWithValue("@area", area);
            comando.Parameters.AddWithValue("@encargado",encargado);
            comando.Parameters.AddWithValue("@finicio", inicio);
            comando.Parameters.AddWithValue("@ffin", fin);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@estadoof", estadoof);
            cont= comando.ExecuteNonQuery();
            CerrarConexion();
            if (cont > 0)
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
