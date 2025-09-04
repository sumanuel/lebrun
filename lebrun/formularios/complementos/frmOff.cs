using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lebrun.formularios.complementos
{
    public partial class frmOff : Form
    {
        public frmOff()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void datos(DataTable dt, string articulo) {
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            //this.dataGridView1.CurrentRow.Selected = false;

            label1.Text = articulo;

            dataGridView1.Columns[0].HeaderText = "Unidad";
            dataGridView1.Columns[1].HeaderText = "Precio";
            dataGridView1.Columns[2].HeaderText = "Tip Precio";
            dataGridView1.Columns[3].HeaderText = "Fecha Inic";
            dataGridView1.Columns[4].HeaderText = "Fecha Fin";
            dataGridView1.Columns[5].HeaderText = "Cant Promo";
            dataGridView1.Columns[6].HeaderText = "Cant Reque";
            dataGridView1.Columns[7].HeaderText = "Porc Desc";
            dataGridView1.Columns[8].HeaderText = "Multiplo";

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 75;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 75;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 75;
            dataGridView1.Columns[8].Width = 76;

            for (int x = 0; x < 9; x++)
            {
                dataGridView1.Columns[x].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
        }

        private void frmOff_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].Width = 50;
            //dataGridView1.Columns[2].Width = 50;
            //dataGridView1.Columns[3].Width = 75;
            //dataGridView1.Columns[4].Width = 75;
            //dataGridView1.Columns[5].Width = 75;
            //dataGridView1.Columns[6].Width = 75;
            //dataGridView1.Columns[7].Width = 75;
            //dataGridView1.Columns[8].Width = 75;

            //for (int x = 0; x < 9; x++)
            //{
            //    dataGridView1.Columns[x].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
        }
    }
}
