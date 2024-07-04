using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMMON;
using System.Runtime.InteropServices;

namespace CAPA_PRESENTACION
{
    public partial class Pan_Principal : Form
    {
        public Pan_Principal()
        {
            InitializeComponent();
        }
        //Variables
        bool estadoForm = false;
        private void pnContenido_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirFormHija(object formHija)
        {
            if(pnContenido.Controls.Count > 0)
            {
                pnContenido.Controls.RemoveAt(0);
            }
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnContenido.Controls.Add(fh);
            this.pnContenido.Tag = fh;
            fh.Show();
        }

        private void Pan_Principal_Load(object sender, EventArgs e)
        {
          
            ////Imagenes de botones de formulario
            btnCerrar.ImageLocation = @COMMON.C_APPCOMUN.ruta + @"img\btncerrar.png";
            btnDimension.ImageLocation = @COMMON.C_APPCOMUN.ruta + @"img\btnmaximizar.png";
            btnMinimizar.ImageLocation = @COMMON.C_APPCOMUN.ruta + @"img\btnminimizar.png";
            /////Imagenes de botones de lateral
            //Size tam = new Size(28,28);
            //Image tempImg = Image.FromFile(@COMMON.C_APPCOMUN.ruta + @"img\icoPBacklog.png");
            //btnProductBacklog.Image = tempImg;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDimension_Click(object sender, EventArgs e)
        {
            if (estadoForm == false)
            {
                btnDimension.ImageLocation = COMMON.C_APPCOMUN.ruta + @"img\btnachicar.png";
                this.WindowState = FormWindowState.Maximized;
                estadoForm = true;
            }
            else
            {
                btnDimension.ImageLocation = @COMMON.C_APPCOMUN.ruta + @"img\btnmaximizar.png";
                this.WindowState = FormWindowState.Normal;
                estadoForm = false;
            }
        }

        private void pnCabeza_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnCabeza_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void c(object sender, PaintEventArgs e)
        {

        }

        private void btnProductBacklog_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new productBack());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new sprintBancklog());
        }
    }
}
