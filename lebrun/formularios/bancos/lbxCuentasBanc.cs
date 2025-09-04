using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.bancos;

namespace lebrun.formularios.bancos
{
    public partial class lbxCuentasBanc : Form
    {

        private frmCuentasBanc frmCuentaBan;
        private Banco banco;

        private DataTable tabla;

        public lbxCuentasBanc()
        {
            InitializeComponent();
            banco = new Banco();
            tabla = new DataTable();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCuentaBan = frmCuentasBanc.DefInstance;
            frmCuentaBan.Show();
            this.Close();
        }

        private void lbxCuentasBanc_Load(object sender, EventArgs e)
        {
            armarLbx();
        }

        private void armarLbx() {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = banco.cargarLbxCuentasBanc();
            //dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int opc = 0;
            if (radioButton1.Checked) { opc = 1; }
            if (radioButton2.Checked) { opc = 2; }
            if (txtBusqueda.Text == "") { opc = 0; }

            tabla = banco.busquedaCuentaBanc(opc, txtBusqueda.Text);
            if (tabla.Rows.Count > 0)
            {
                dataGridView1.DataSource = tabla;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
            }
            else
            {
                MessageBox.Show("No se econtraron resultados", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar este registro?", "Alerta ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                banco.eliminarCuentaBancaria(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString());
                btnBuscar_Click(sender, e);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //frmCuentaBan = frmCuentasBanc.DefInstance;
            frmCuentaBan = new frmCuentasBanc("modificar", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString());
            frmCuentaBan.Show();
            this.Close();
        }

       


    }
}
