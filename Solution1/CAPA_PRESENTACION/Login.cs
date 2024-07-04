using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_NEGOCIO;
using COMMON;

namespace CAPA_PRESENTACION
{
    public partial class Login : Form
    {
        CN_USUARIO oCnUsuario = new CN_USUARIO();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (COMMON.C_APPCOMUN.VerificarTextVacios(txtUsuario, errorP_Validacion, "Usuario") & COMMON.C_APPCOMUN.VerificarTextVacios(txtClave, errorP_Validacion, "Contraseña"))
            {//Validacion casillas vacias
                if(oCnUsuario.LoginUsuario(txtUsuario.Text, txtClave.Text))
                {
                    errorP_Validacion.Clear();
                    Pan_Principal PP = new Pan_Principal();
                    PP.Show();
                    this.Hide();
                }
                else
                {
                    errorP_Validacion.SetError(txtUsuario, "El usuario o contraseña son incorrectos");
                    errorP_Validacion.SetError(txtClave, "El usuario o contraseña son incorrectos");
                }
                
                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
