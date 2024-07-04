using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace COMMON
{
    public class C_APPCOMUN
    {

        public static string ruta = AppDomain.CurrentDomain.BaseDirectory;

        public static bool VerificarTextVacios(TextBox texto, ErrorProvider error, string mensaje)
        {
            if (texto.Text == "")
            {
                error.SetError(texto, "La casilla " + mensaje + " no puede estar vacia");
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }

    }
}
