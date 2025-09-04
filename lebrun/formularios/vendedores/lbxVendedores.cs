using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.vendedores;
using lebrun.formularios.clientes;
using lebrun.formularios.facturacion;
//using lebrun.formularios.cotizacion;
//using lebrun.formularios.pedidos;
//using lebrun.formularios.prefactura;
//using lebrun.formularios.clientesMayor;

namespace lebrun.formularios.vendedores
{
    public partial class lbxVendedores : Form
    {
        private Vendedor ven1;
        private static lbxVendedores m_FormDefInstance;
        private frmClientes refCliente;
        private frmFactura refFactura1;
        private int formOrigen;
        private DataView dv;
        private DataTable dtVendedores;
        //private frmFacturaVivienda factVi;
        //private frmPreFac preFC;
        //private frmPedido referenciaPedido;
        //private frmPrefactura referenciaPrefactura;
        //private frmClientesMayor refClienteMayor;

        public lbxVendedores()
        {
            InitializeComponent();
        }

        public static lbxVendedores DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new lbxVendedores();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void lbxVendedores_Load(object sender, EventArgs e)
        {
            ven1 = new Vendedor("200");
            dtVendedores = ven1.dataLbxVendedores();
            dv = new DataView(dtVendedores);
            this.dataGridView1.DataSource = dtVendedores;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Cedula";
            dataGridView1.Columns[3].HeaderText = "Cargo";
            dataGridView1.Columns[4].HeaderText = "Status";
            formOrigen = -1;
        }

        public void venSoloVista(frmClientes referenciaCliente) {
            cmdAgregar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdEliminar.Enabled = false;
            cmdImprimir.Enabled = false;
            refCliente = referenciaCliente;
        }

        //public void venSoloVista(frmClientesMayor referenciaCliente)
        //{
        //    cmdAgregar.Enabled = false;
        //    cmdModificar.Enabled = false;
        //    cmdEliminar.Enabled = false;
        //    cmdImprimir.Enabled = false;
        //    refClienteMayor = referenciaCliente;
        //}

        //public void venSoloVista(frmClientesMayor referenciaCliente, int origen)
        //{
        //    venSoloVista(referenciaCliente);
        //    formOrigen = origen;
        //}

        public void venSoloVista(frmClientes referenciaCliente, int origen) { 
            //origen es para saber a donde va a ir en el double click del datagrid
            venSoloVista(referenciaCliente);
            formOrigen = origen;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (formOrigen == -1)
            {
                if (refCliente != null)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                    {
                        refCliente.txtVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        refCliente.txtNombreVendedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        refCliente.txtComisionVen.Focus();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //if (refClienteMayor != null)
                //{
                //    if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                //    {
                //        refClienteMayor.txtVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //        refClienteMayor.txtNombreVendedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //        refClienteMayor.txtComisionVen.Focus();
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
            }

            if (formOrigen == 1)
            {
                if (refCliente != null)
                {
                    refCliente.txtCobrador.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    refCliente.txtNombreCobrador.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    refCliente.txtComisionCobr.Focus();
                    this.Close();
                }
                //if (refClienteMayor != null)
                //{
                //    refClienteMayor.txtCobrador.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //    refClienteMayor.txtNombreCobrador.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //    refClienteMayor.txtComisionCobr.Focus();
                //    this.Close();
                //}
            }

            //2 facturacion
            if (formOrigen == 2)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                {
                    refFactura1.txtCodVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    refFactura1.txtNombreVendedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    refFactura1.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    //refFactura1.txtCodProducto.Focus();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (formOrigen == 6)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                {
                    //factVi.txtCodVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    //factVi.txtNombreVendedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //factVi.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    //refFactura1.txtCodProducto.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //3 prefactura Cotizacion
            if (formOrigen == 3)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                {
                    //preFC.txtCodVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    //preFC.txtNombreVendedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //preFC.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    //refFactura1.txtCodProducto.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //8 facturacion Mayor pedido
            if (formOrigen == 8)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                {
                    //referenciaPedido.txtCodVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    //referenciaPedido.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //referenciaPedido.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //9 facturacion Mayor prefactura
            if (formOrigen == 9)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["ven_status"].Value.ToString().Equals("Activo"))
                {
                    //referenciaPrefactura.txtCodVendedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    //referenciaPrefactura.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //referenciaPrefactura.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                filtrar(txtBuscar.Text);
            }
            else
            {
                MessageBox.Show("Debe Poner un Dato Para buscar!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Focus();
            }
        }

        private void filtrar(string filtro)
        {
            string sentencia;
            DataTable temp;

            try
            {
                sentencia = "ven_codigo LIKE '" + filtro + "%'";
                dv.RowFilter = sentencia;
                if (dv.Count == 0)
                {
                    sentencia = "ven_nombre LIKE '" + filtro + "%'";
                    dv.RowFilter = sentencia;
                    if (dv.Count == 0)
                    {
                        dataGridView1.DataSource = dv;
                        dataGridView1.Update();
                    }
                }
                if (dv.Count > 0)
                {
                    dataGridView1.DataSource = dv;
                    dataGridView1.Update();
                }
                else
                {
                    temp = ven1.vendedorBuscado(txtBuscar.Text);
                    if (temp.Rows.Count == 0)
                    {
                        MessageBox.Show("No se consiguieron Resultados!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = temp;
                        dataGridView1.Columns[0].HeaderText = "Nombre";
                        dataGridView1.Columns[1].HeaderText = "Cedula";
                        dataGridView1.Columns[2].HeaderText = "Cargo";
                        dataGridView1.Columns[3].HeaderText = "Status";
                        dataGridView1.Update();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error buscar " + e.Message);
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dtVendedores = null;
            dtVendedores = ven1.dataLbxVendedores();
            dv.Dispose();
            dv = new DataView(dtVendedores);
            this.dataGridView1.DataSource = dtVendedores;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Cedula";
            dataGridView1.Columns[3].HeaderText = "Cargo";
            dataGridView1.Columns[4].HeaderText = "Status";
            txtBuscar.Clear();
        }

        public void soloVista(bool val) { 
            cmdAgregar.Enabled = val;
            cmdModificar.Enabled = val;
            cmdEliminar.Enabled = val;
            cmdImprimir.Enabled = val;
        }

        public void busVenFac(frmFactura fact, int origen) {
            soloVista(false);
            refFactura1 = fact;
            formOrigen = origen;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells["ven_status"].Value.Equals("Inactivo"))
                {
                    dataGridView1.Rows[x].DefaultCellStyle.BackColor = Color.FromArgb(254, 198, 198);
                }
            }
        }

        private void lbxVendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formOrigen == 2) {
                refFactura1.Focus();
            }

            if (formOrigen == 6)
            {
                //factVi.Focus();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtBuscar.Text != "") {
                cmdBuscar_Click(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
            }
        }

        //public void busVenFac(frmFacturaVivienda factV, int origen)
        //{
        //    soloVista(false);
        //    factVi = factV;
        //    formOrigen = origen;
        //}


        //public void busVenFac(frmPreFac fact, int origen)
        //{
        //    soloVista(false);
        //    preFC = fact;
        //    formOrigen = origen;
        //}

        //public void busVenFac(frmPedido ped, int origen)
        //{
        //    soloVista(false);
        //    referenciaPedido = ped;
        //    formOrigen = origen;
        //}
        
        //public void busVenFac(frmPrefactura pre, int origen)
        //{
        //    soloVista(false);
        //    referenciaPrefactura = pre;
        //    formOrigen = origen;
        //}
    }
}
