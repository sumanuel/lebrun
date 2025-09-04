using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.clientes;

namespace lebrun.formularios.clientes
{
    public partial class lbxTipoNegocio : Form
    {
        TipoNegocio tipoN;
        frmTipoNegocio frmTipoN;

        public lbxTipoNegocio()
        {
            InitializeComponent();
        }

        private void lbxTipoNegocio_Load(object sender, EventArgs e)
        {
            tipoN = new TipoNegocio();
            this.dataGridView1.DataSource = tipoN.lbxTipoNegocio();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmTipoN = new frmTipoNegocio();
            frmTipoN.MdiParent = this.MdiParent;
            frmTipoN.Show();
            frmTipoN.referenciaLbxTipoNegocio = this;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void reloadLbx()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = tipoN.lbxTipoNegocio();
            formatLbx();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            frmTipoN = new frmTipoNegocio();
            frmTipoN.MdiParent = this.MdiParent;
            frmTipoN.Show();
            frmTipoN.actualizarReferencia(this, "editar");
        }


        public void formatLbx()
        {   
            foreach(DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.Visible = false;
            }
            dataGridView1.Columns["codigo"].Visible = true;
            dataGridView1.Columns["descripcion"].Visible = true;
            dataGridView1.Columns["activo"].Visible = true;
        }
    }
}
