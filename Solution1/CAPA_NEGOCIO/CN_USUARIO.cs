using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
    public class CN_USUARIO
    {
        CD_USUARIO oCdUsuario = new CD_USUARIO();

        public bool LoginUsuario(string usuario, string clave)
        {
            if (oCdUsuario.LoginUsuario(usuario, clave) == true)
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
