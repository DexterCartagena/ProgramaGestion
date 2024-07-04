using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using COMMON;

namespace CAPA_DATOS
{

    //CREATE TABLE Usuario(
    //cod int primary key identity(1,1),
    //nombre varchar(50),
    //clave nvarchar(50),
    //estado int,
    //rol int foreign key references CARGO(cod_rol)
    //)
    public class CD_USUARIO: Conexionsql
    {
        SqlCommand comando = new SqlCommand();
        SqlDataReader leerFilas;
        DataTable tabla = new DataTable();

        public bool LoginUsuario(string usuario, string clave)
        {
            comando.Parameters.Clear();
            tabla.Clear();
            comando.Connection = AbrirConexion();
            comando.CommandText = "Select * from usuario where nombre = '" + usuario + "' and clave = '" + clave + "'";
            comando.CommandType = CommandType.Text;
            leerFilas = comando.ExecuteReader();
            tabla.Load(leerFilas);
            CerrarConexion();
            leerFilas.Close();
            if (tabla.Rows.Count != 0)
            {
                COMMON.C_USUARIO.cod = int.Parse(tabla.Rows[0]["cod"].ToString());
                COMMON.C_USUARIO.usuario = tabla.Rows[0]["nombre"].ToString();
                COMMON.C_USUARIO.clave = tabla.Rows[0]["clave"].ToString();
                COMMON.C_USUARIO.estado = int.Parse(tabla.Rows[0]["estado"].ToString());
                COMMON.C_USUARIO.rol = int.Parse(tabla.Rows[0]["rol"].ToString());


                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
