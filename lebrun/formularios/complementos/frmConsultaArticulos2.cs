using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.complementos;
//using lebrun.formularios.importaciones;
using lebrun.formularios.facturacion;
using lebrun.formularios.complementos;
//using lebrun.formularios.productos;

namespace lebrun.formularios.complementos
{
    public partial class frmConsultaArticulos2 : Form
    {

        //declaraciones
        private Producto producto;
        private static frmConsultaArticulos2 m_FormDefInstance;
        //private frmOrdenCompra refOrdenCompra;
        //private frmProductosImportacion refProductosImportacion;
        private string origen;
        //private frmCambioPrecio refCambioPrecio;
        //private frmPromociones refPromociones;

        //Roberto Fernandez 11:41 a.m. 25/01/2013
        private int origen2;
        private frmFactura refFactura;
        private frmOff ventanaOff;
        //private frmCalculoPrecio calculoPrecio;

        public frmConsultaArticulos2()
        {
            InitializeComponent();
            producto = new Producto();
        }

        public static frmConsultaArticulos2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmConsultaArticulos2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        //public void destino(frmOrdenCompra referencia)
        //{
        //    refOrdenCompra = referencia;
        //}

        //public void destino(Form referencia, string opcion)
        //{

        //    if (opcion.Equals("frmProductosImportacion"))
        //    {
        //        origen = opcion;
        //        refProductosImportacion = (frmProductosImportacion)referencia;
        //    }
        //    if (opcion.Equals("frmOrdenCompra"))
        //    {
        //        origen = opcion;
        //        refOrdenCompra = (frmOrdenCompra)referencia;
        //    }
        //    if (opcion.Equals("frmCambioPrecio"))
        //    {
        //        origen = opcion;
        //        refCambioPrecio = (frmCambioPrecio)referencia;
        //    }
        //    if (opcion.Equals("frmPromociones"))
        //    {
        //        origen = opcion;
        //        refPromociones = (frmPromociones)referencia;
        //    }
        //}

        private void lbxProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = producto.cargarProductos();
            dataGridView1.ClearSelection();
            ordernarGrid();
            ventanaOff = new frmOff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                RadioButton radio = (groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked));

                //dataGridView1.DataSource = null;
                if (producto.buscarProductos(textBox1.Text, radio.Name).Rows.Count > 0)
                {
                    dataGridView1.DataSource = producto.buscarProductos(textBox1.Text, radio.Name);
                    dataGridView1.ClearSelection();
                    ordernarGrid();
                    dataGridView1.Update();
                    ordernarGrid();
                }
                else
                {
                    MessageBox.Show("No existe ningún producto que cumpla con el parámetro suministrado", "Aviso ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Focus();
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (origen2 == 1)
            {
                //if (dataGridView1.CurrentRow.Cells["Codigo"].Selected)
                //{
                //    refFactura.cargarProducto(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
                //    this.Close();
                //    return;
                //}

                //if (dataGridView1.CurrentRow.Cells["Off"].Selected)
                //{
                //    if ((dataGridView1.CurrentRow.Cells["Off"].Value.ToString()).Equals("Si"))
                //    {
                //        ventanaOff.datos(producto.off(dataGridView1.CurrentRow.Cells[0].Value.ToString()), (dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                //        ventanaOff.ShowDialog();
                //    }
                //}

                //if (dataGridView1.CurrentRow.Cells["Precio"].Selected)
                //{
                //    calculoPrecio = new frmCalculoPrecio(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString());
                //    calculoPrecio.ShowDialog();
                //}

            }



            //else
            //{
            //
            if (origen != null)
            {
                //if (origen.Equals("frmOrdenCompra"))
                //{

                //    refOrdenCompra.txtProducto.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //    refOrdenCompra.lblDesProducto.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //    refOrdenCompra.txtUnidad.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //    refOrdenCompra.lblDescriUni.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //    refOrdenCompra.lblOrigen.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                //    refOrdenCompra.lblpro_principal.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
                //    refOrdenCompra.txtProducto.Focus();

                //    this.Close();
                //    return;
                //}

                //if (origen.Equals("frmProductosImportacion"))
                //{

                //    refProductosImportacion.txtCodigo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //    refProductosImportacion.lblDescripcionPro.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //    //refProductosImportacion.txtUnidad.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //    refProductosImportacion.lblunidadpro.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //    refProductosImportacion.txtCodigo.Focus();

                //    this.Close();
                //    return;
                //}
                ////}

                //if (origen.Equals("frmPromociones"))
                //{

                //    refPromociones.txtCodigo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //    refPromociones.lblDescripcionPro.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //    refPromociones.txtCodigo.Focus();

                //    this.Close();
                //    return;
                //}
            }

            //if (dataGridView1.CurrentRow.Cells["Off"].Selected)
            //{
            //    if ((dataGridView1.CurrentRow.Cells["Off"].Value.ToString()).Equals("Si"))
            //    {
            //        ventanaOff.datos(producto.off(dataGridView1.CurrentRow.Cells[0].Value.ToString()), (dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            //        ventanaOff.ShowDialog();
            //    }

            //}

            if (dataGridView1.CurrentRow.Cells["Precio"].Selected)
            {
                //calculoPrecio = new frmCalculoPrecio(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString());
                //calculoPrecio.ShowDialog();
            }
        }

        public void actulizarRefFactura(frmFactura fx)
        {
            refFactura = fx;
            origen2 = 1;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ordernarGrid()
        {
            dataGridView1.Columns["Codigo"].DisplayIndex = 0;
            dataGridView1.Columns["Descripcion"].DisplayIndex = 1;
            dataGridView1.Columns["Existencia"].DisplayIndex = 2;
            dataGridView1.Columns["Precio"].DisplayIndex = 3;
            dataGridView1.Columns["Unidad"].DisplayIndex = 4;
            dataGridView1.Columns["Off"].DisplayIndex = 5;
            dataGridView1.Columns["Exento"].DisplayIndex = 6;
            //dataGridView1.Columns["PMVP"].DisplayIndex = 7;
            dataGridView1.Columns["Procedencia"].DisplayIndex = 7;
            dataGridView1.Columns["Procedencia"].Visible = false;
            dataGridView1.Columns["pro_principal"].Visible = false;


            //dandole estilo al grid
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 382;//383;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 74;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 74;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridView1.Columns["Presentacion"].Visible = false;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Off"].Width = 40;
            dataGridView1.Columns["Off"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Exento"].Width = 40;
            dataGridView1.Columns["Exento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns["PMVP"].Width = 40;
            //dataGridView1.Columns["PMVP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            if (dataGridView1.Rows.Count > 0)
            {
                lblUltimoCod.Text = (dataGridView1.Rows.Count - 1) + " Articulos Mostrados Ult. Art:" + dataGridView1.Rows[(dataGridView1.Rows.Count - 2)].Cells["Codigo"].Value.ToString();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value != null)
            {
                if ((dataGridView1.Rows[e.RowIndex].Cells["Off"].Value.ToString()).Equals("Si"))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Off"].Style.BackColor = Color.Red;
                }

                if ((dataGridView1.Rows[e.RowIndex].Cells["Exento"].Value.ToString()).Equals("1"))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Exento"].Style.BackColor = Color.YellowGreen;
                }
            }
        }

        //private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    int columna = e.ColumnIndex;
        //    if ((dataGridView1.CurrentRow.Cells[columna].Value.ToString()).Equals("Si"))
        //    {
        //        ventanaOff.datos(producto.off(dataGridView1.CurrentRow.Cells[0].Value.ToString()), (dataGridView1.CurrentRow.Cells[0].Value.ToString()));
        //        ventanaOff.ShowDialog();
        //    }

        //}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            RadioButton radio = (groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked));

            if (radio.Name.Equals("codigo"))
            {
                if ((e.KeyChar == '.') || (e.KeyChar == ','))
                {
                    e.Handled = true;
                    return;
                }
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                if (Char.IsSymbol(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                if ((e.KeyChar == (char)(Keys.Enter)) && textBox1.Text != "")
                {
                    if (producto.buscarProductos(textBox1.Text, radio.Name).Rows.Count > 0)
                    {
                        dataGridView1.DataSource = producto.buscarProductos(textBox1.Text, radio.Name);
                        dataGridView1.ClearSelection();
                        ordernarGrid();
                        dataGridView1.Update();
                        ordernarGrid();
                    }
                    else
                    {
                        MessageBox.Show("No existe ningún producto que cumpla con el parámetro suministrado", "Aviso ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Focus();
                    }
                }
            }

            if ((e.KeyChar == (char)(Keys.Enter)) && textBox1.Text != "")
            {
                if (producto.buscarProductos(textBox1.Text, radio.Name).Rows.Count > 0)
                {
                    dataGridView1.DataSource = producto.buscarProductos(textBox1.Text, radio.Name);
                    dataGridView1.ClearSelection();
                    ordernarGrid();
                    dataGridView1.Update();
                    ordernarGrid();
                }
                else
                {
                    MessageBox.Show("No existe ningún producto que cumpla con el parámetro suministrado", "Aviso ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Focus();
                }
            }

        }

        private void lbxProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (origen2 == 1)
            {
                refFactura.Focus();
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox a = (TextBox)sender;
            a.SelectAll();
        }



    }
}
