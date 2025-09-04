using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.complementos;
using lebrun.clasesData;
using lebrun.formularios.facturacion;

namespace lebrun.formularios.complementos
{
    public partial class lbxProductos2 : Form
    {

        private Producto producto;
        private static lbxProductos2 m_FormDefInstance;
        private string seleccion;
        private FuncionesTexbox funcionesTextBox;
        private frmFactura refFactura;
        private int origen;

        public lbxProductos2()
        {
            InitializeComponent();
           
        }


        public static lbxProductos2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new lbxProductos2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void lbxProductos2_Load(object sender, EventArgs e)
        {
            funcionesTextBox = new FuncionesTexbox();
            producto = new Producto();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = producto.buscarProductosFrm("", "");
            dataGridView1.AutoResizeColumns();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton1.Checked) { funcionesTextBox.OnlyNumbers(sender, e); }

            if (e.KeyChar == (char)(Keys.Enter)) {

                if (radioButton1.Checked)
                {
                    seleccion = radioButton1.AccessibleName;
                }

                if (radioButton2.Checked)
                { seleccion = radioButton2.AccessibleName; }

                if (radioButton3.Checked)
                { seleccion = radioButton3.AccessibleName; }

                if (radioButton4.Checked)
                { seleccion = radioButton4.AccessibleName; }

                if (radioButton5.Checked)
                { seleccion = radioButton5.AccessibleName; }

                if (radioButton6.Checked)
                { seleccion = radioButton6.AccessibleName; }

                if (radioButton7.Checked)
                { seleccion = radioButton7.AccessibleName; }

                if (radioButton8.Checked)
                { seleccion = radioButton8.AccessibleName; }

                if (radioButton9.Checked)
                { seleccion = radioButton9.AccessibleName; }

                if (radioButton10.Checked)
                { seleccion = radioButton10.AccessibleName; }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = producto.buscarProductosFrm(seleccion, txtBusqueda.Text);
                dataGridView1.AutoResizeColumns();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmproductos productos = new frmproductos();
            productos.Show();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void actulizarRefFactura(frmFactura fx) {
            refFactura = fx;
            origen = 2;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (origen == 2) {
                refFactura.cargarProducto(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
                this.Close();
            }
        }


    }
}
