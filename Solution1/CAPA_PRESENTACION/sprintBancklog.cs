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
    public partial class sprintBancklog : Form
    {
        public sprintBancklog()
        {
            InitializeComponent();
        }

        CN_SPRINTBACK cnprintback = new CN_SPRINTBACK();
        DataTable DT = new DataTable();
        private void sprintBancklog_Load(object sender, EventArgs e)
        {
            DT = cnprintback.ListRegSprintBack();
            dgvRegSprint.DataSource = DT;
            dgvRegSprint.Columns[0].Width = 35;
            dgvRegSprint.Columns[1].Width = 40;
            dgvRegSprint.Columns[2].Width = 80;
            dgvRegSprint.Columns[3].Width = 250;
            dgvRegSprint.Columns[4].Width = 60;
            dgvRegSprint.Columns[5].Width = 70;
            dgvRegSprint.Columns[6].Width = 70;
            dgvRegSprint.Columns[7].Width = 60;
            dgvRegSprint.Columns[8].Width = 60;
        }

        private void dgvRegSprint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ps_EditSprint pssprint = new Ps_EditSprint(COMMON.C_USUARIO.cod);
            pssprint.Show();
            pssprint.txtCod.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[0].Value.ToString();
            pssprint.txtCodpb.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[1].Value.ToString();
            pssprint.txtPrioridad.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[2].Value.ToString();
            pssprint.txtDetalle.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[3].Value.ToString();
            pssprint.txtArea.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[4].Value.ToString();
            pssprint.txtEncargado.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[5].Value.ToString();
            pssprint.txtFinicio.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[6].Value.ToString();
            pssprint.txtFfin.Text = dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[7].Value.ToString();
            pssprint.checkBox1.Checked= Boolean.Parse(dgvRegSprint.Rows[dgvRegSprint.CurrentRow.Index].Cells[8].Value.ToString());
        }
    }
}
