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
    public partial class Pb_EditItem : Form
    {
        CN_PRODUCTBACK cnproductback = new CN_PRODUCTBACK();

        //INSERT INTO CARGO VALUES('ADM') - cod 1
        //INSERT INTO CARGO VALUES('USER') - cod 2
        Form form_ante = new Form();
        public Pb_EditItem(int CodPermiso)
        {
            InitializeComponent();

            txtCod.Enabled = false;
            if(CodPermiso != 1)
            {
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                btnLimpiar.Visible = false;

                txtitem.Enabled = false;
                txtdetalle.Enabled = false;
                txtfechainicio.Enabled = false;
                txtfechafin.Enabled = false;
                checkBox1.Enabled = false;
                txtprioridad.Enabled = false;
                cbprioridad.Visible = false;
            }
        }

        private void Pb_EditItem_Load(object sender, EventArgs e)
        {
            cbprioridad.DataSource = cnproductback.listPrioridad();
            cbprioridad.DisplayMember = "detalle";
            cbprioridad.ValueMember = "cod";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea agregar este nuevo registro de producto?","Aviso de registro",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                cnproductback.agregarProductBack(txtitem.Text, txtdetalle.Text, CambioFormato(txtfechainicio.Text), CambioFormato(txtfechafin.Text), int.Parse(cbprioridad.SelectedValue.ToString()), 1);
            }
        }
        string CambioFormato(string ddmmyyyy)
        {
            string an;
            string mes;
            string dia;
            string yyyymmdd;
            dia = ddmmyyyy.Substring(0, 2);
            mes = ddmmyyyy.Substring(3, 2);
            an = ddmmyyyy.Substring(6, 4);
            yyyymmdd = an + mes + dia;
            return yyyymmdd;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtitem.Text = "";
            txtdetalle.Text = "";
            txtfechainicio.Text = "";
            txtfechafin.Text = "";
            txtprioridad.Text = "";txtprioridad.Enabled = false;
            checkBox1.Checked = false;

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Modificar el registro [ " + txtCod.Text + "] ?", "Aviso de Moficacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int est=0;
                if (checkBox1.Checked == true) { est = 1; }

                cnproductback.modfRegProducBack(int.Parse(txtCod.Text), txtitem.Text, txtdetalle.Text, CambioFormato(txtfechainicio.Text), CambioFormato(txtfechafin.Text), est, int.Parse(cbprioridad.SelectedValue.ToString()), 1);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea Eliminar el registro [ "+txtCod.Text+" ] ?","Aviso de Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cnproductback.eliminarRegProducBack(int.Parse(txtCod.Text));
            }
        }

        private void Pb_EditItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
