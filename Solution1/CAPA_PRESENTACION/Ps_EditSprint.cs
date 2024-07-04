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

namespace CAPA_PRESENTACION
{
    public partial class Ps_EditSprint : Form
    {
        public Ps_EditSprint(int CodPermiso)
        {
            InitializeComponent();
            txtCod.Enabled = false;
            if (CodPermiso != 1)
            {
                btnEliminar.Visible = false;
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnLimpiar.Visible = false;
                btnBuscar.Visible = false;

                cbArea.Visible = false;
                cbEncargado.Visible = false;
                cbPrioridad.Visible = false;

                txtCodpb.Enabled = false;
                txtArea.Enabled = false;
                txtDetalle.Enabled = false;
                txtEncargado.Enabled = false;
                txtPrioridad.Enabled = false;
                txtFinicio.Enabled = false;
                txtFfin.Enabled=false;

                checkBox1.Enabled = false;
            }
        }
        CN_SPRINTBACK cnsprintback = new CN_SPRINTBACK();
        private void Ps_EditSprint_Load(object sender, EventArgs e)
        {
            cbPrioridad.DataSource = cnsprintback.listPrioridad();
            cbPrioridad.DisplayMember = "detalle";
            cbPrioridad.ValueMember = "cod";

            cbArea.DataSource = cnsprintback.listArea();
            cbArea.DisplayMember = "detalle";
            cbArea.ValueMember = "cod";

            cbEncargado.DataSource = cnsprintback.listEncargado();
            cbEncargado.DisplayMember = "nombre";
            cbEncargado.ValueMember = "cod";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodpb.Text="";
            txtArea.Text = "";
            txtDetalle.Text = "";
            txtEncargado.Text = "";
            txtPrioridad.Text = "";
            txtFinicio.Text = "";
            txtFfin.Text = "";

            checkBox1.Checked = false;
        }
    }
}
