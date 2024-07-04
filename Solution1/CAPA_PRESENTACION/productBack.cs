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
    public partial class productBack : Form
    {
        public productBack()
        {
            InitializeComponent();
        }
        CN_PRODUCTBACK cnproducback = new CN_PRODUCTBACK();
        DataTable dtRegistro = new DataTable();
        private void productBack_Load(object sender, EventArgs e)
        {
            dtRegistro = cnproducback.listRegistrosOficiales();
            dgvRegistro.DataSource = dtRegistro;
            dgvRegistro.Columns[0].Width = 35;// cod
            dgvRegistro.Columns[1].Width = 120;// item
            dgvRegistro.Columns[2].Width = 200;// detalle
            dgvRegistro.Columns[3].Width = 60;// t inicio
            dgvRegistro.Columns[4].Width = 60;// t fin
            dgvRegistro.Columns[5].Width = 70;// prioridad
            dgvRegistro.Columns[6].Width = 50;// estado
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Pb_EditItem pbitem = new Pb_EditItem(COMMON.C_USUARIO.rol);
            pbitem.txtCod.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[0].Value.ToString();
            pbitem.txtitem.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[1].Value.ToString();
            pbitem.txtdetalle.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[2].Value.ToString();
            pbitem.txtfechainicio.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[3].Value.ToString();
            pbitem.txtfechafin.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[4].Value.ToString();
            pbitem.txtprioridad.Text = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[5].Value.ToString();
            pbitem.checkBox1.Checked = Convert.ToBoolean(dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[6].Value.ToString());

            pbitem.Show();
            
        
        }
    }
}
