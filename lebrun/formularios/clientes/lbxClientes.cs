using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.clientes;
using lebrun.formularios.clientes;
using lebrun.formularios.facturacion;
using lebrun.clases.vendedores;
//using lebrun.formularios.tesoreria;
//using lebrun.formularios.cotizacion;
//using lebrun.formularios.pedidos;

namespace lebrun.formularios.facturacion
{
    public partial class lbxClientes : Form
    {
        private Clientes cliente1;
        private DataView dv;
        private DataTable dtClientes;
        private static lbxClientes m_FormDefInstance;
        private frmClientes frClientes1;
        public int fuente;
        private frmFactura fact2;
        //private frmRecibodeIngreso recibo;
        //private frmRetIvaCli retIvaCli;
        //private frmFacturaVivienda factVi;
        //private frmPreFac preFC;
        //private frmPedido referenPedido;
        
        public lbxClientes()
        {
            InitializeComponent();
        }

        private void lbxClientes_Load(object sender, EventArgs e)
        {
            cliente1 = new Clientes("200");
            dtClientes = cliente1.lbxClientes();
            dv = new DataView(dtClientes);
            this.dataGridView1.DataSource = dtClientes;
            dataGridView1.Columns[0].HeaderText = "Código Cliente";
            dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[2].HeaderText = "Rif";
            dataGridView1.Columns[3].HeaderText = "Condicion";
            dataGridView1.Columns[4].HeaderText = "Estado";
            //dataGridView1.Columns[4].Visible = false;
        }


        private bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
        
            //try
            //{
            //    sentencia = "cli_codigo LIKE '" + filtro + "%'";
            //    dv.RowFilter = sentencia;
            //    if (dv.Count == 0)
            //    {
            //        sentencia = "cli_nombre LIKE '" + filtro + "%'";
            //        dv.RowFilter = sentencia;
            //        if (dv.Count == 0) {
            //            sentencia = "cli_rif LIKE '" + filtro + "%'";
            //            dv.RowFilter = sentencia;
            //        }
            //    }
            //    if (dv.Count > 0)
            //    {
            //        dataGridView1.DataSource = dv;
            //        dataGridView1.Update();
            //    }
            //    else {
                    temp = cliente1.clienteBuscado(txtBuscar.Text);
                    if (temp.Rows.Count == 0)
                    {
                        MessageBox.Show("No se consiguieron Resultados!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = temp;
                        dataGridView1.Columns[0].HeaderText = "Código Cliente";
                        dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
                        dataGridView1.Columns[2].HeaderText = "Rif";
                        dataGridView1.Columns[3].HeaderText = "Condicion";
                        dataGridView1.Columns[4].HeaderText = "Estado";
                        //dataGridView1.Columns["cli_situacion"].Visible = false;
                        dataGridView1.Update();
                    }
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Error buscar " + e.Message);
            //}
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dtClientes = null;
            dtClientes = cliente1.lbxClientes();
            dv.Dispose();
            dv = new DataView(dtClientes);
            this.dataGridView1.DataSource = dtClientes;
            dataGridView1.Columns[0].HeaderText = "Código Cliente";
            dataGridView1.Columns[1].HeaderText = "Nombre Cliente";
            dataGridView1.Columns[2].HeaderText = "Rif";
            dataGridView1.Columns[3].HeaderText = "Condicion";
            txtBuscar.Clear();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frClientes1 = frmClientes.DefInstance;
            frClientes1.MdiParent = this.MdiParent;
            frClientes1.Show();
            frClientes1.agregar(true);
        }

        public static lbxClientes DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new lbxClientes();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void cmdModificarCli_Click(object sender, EventArgs e)
        {
            //dataGridView1.Columns[3].HeaderText = "Condicion";
            if (dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Activo"))
            {
                frClientes1 = frmClientes.DefInstance;
                frClientes1.MdiParent = this.MdiParent;
                frClientes1.Show();
                frClientes1.cargarDatosModificar(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frClientes1.agregar(false);
            }

            else
            {
                MessageBox.Show("Solo puede seleccionar clientes Activos!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //2 facturacion
            if (fuente == 2)
            {
                if ((dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Activo")))
                {
                    Vendedor venRefFac;
                    venRefFac = new Vendedor();
                    cliente1.Codigo = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                    //cliente1.cargarDatosCliente();
                    /*venRefFac.CodigoV = cliente1.Vendedor;
                    venRefFac.cargarDatosVendedor();
                    fact2.txtCodVendedor.Text = venRefFac.CodigoV;
                    fact2.txtNombreVendedor.Text = venRefFac.Nombre;*/
                    /*fact2.txtCodCliente.Text = cliente1.Codigo;
                    fact2.txtNombreCli.Text = cliente1.Nombre;
                    fact2.txtRif.Text = cliente1.Rif;*/
                    //act ref frmFac
                    fact2.txtCodCliente.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                    //fact2.cargarCliVen(cliente1.Codigo, venRefFac.CodigoV);
                    //fact2.actuCondiPag();
                    fact2.txtCodVendedor.Focus();
                    fact2.txtCodCliente_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar clientes Activos!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //3 Devolucion
            if (fuente == 3)
            {

                if ((dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Activo")) || (dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Suspendido")))
                {
                    Vendedor venRefFac;
                    venRefFac = new Vendedor();
                    cliente1.Codigo = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                    cliente1.cargarDatosCliente();
                    /*venRefFac.CodigoV = cliente1.Vendedor;
                    venRefFac.cargarDatosVendedor();
                    fact2.txtCodVendedor.Text = venRefFac.CodigoV;
                    fact2.txtNombreVendedor.Text = venRefFac.Nombre;*/
                    /* fact2.txtCodCliente.Text = cliente1.Codigo;
                     fact2.txtNombreCli.Text = cliente1.Nombre;*/
                    //act ref frmFac
                    //fact2.cargarCliVen(cliente1.Codigo, venRefFac.CodigoV);
                    // fact2.actuCondiPag();
                    fact2.txtCodCliente.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                    fact2.txtCodVendedor.Focus();
                    fact2.txtCodCliente_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar clientes Activos!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (fuente == 4)
            {
                //recibo.txtCliente.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                //recibo.lblNombreCliente.Text = dataGridView1.CurrentRow.Cells["cli_nombre"].Value.ToString();
                //recibo.txtCliente.Focus();
                //this.Close();
            }

            if (fuente == 5)
            {
                //retIvaCli.txtCodigo.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                //retIvaCli.lblNombreCliente.Text = dataGridView1.CurrentRow.Cells["cli_nombre"].Value.ToString();
                //retIvaCli.txtCodigo.Focus();
                //this.Close();

            }
            if (fuente == 6)
            {
                if ((dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Activo")))
                {
                    //Vendedor venRefFac;
                    //venRefFac = new Vendedor();
                    //cliente1.Codigo = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                    //cliente1.cargarDatosCliente();
                    //venRefFac.CodigoV = cliente1.Vendedor;
                    ///*venRefFac.cargarDatosVendedor();
                    //factVi.txtCodVendedor.Text = venRefFac.CodigoV;
                    //factVi.txtNombreVendedor.Text = venRefFac.Nombre;*/
                    //factVi.txtCodCliente.Text = cliente1.Codigo;
                    //factVi.txtNombreCli.Text = cliente1.Nombre;
                    //factVi.txtRif.Text = cliente1.Rif;
                    ////act ref frmFac
                    //factVi.cargarCliVen(cliente1.Codigo, venRefFac.CodigoV);
                    //factVi.actuCondiPag();
                    //factVi.txtCodVendedor.Focus();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar clientes Activos!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //if (fuente == 7)
            //{
            //    if ((dataGridView1.CurrentRow.Cells["cli_situacion"].Value.ToString().Equals("Activo")))
            //    {
            //        /*Vendedor venRefFac;
            //        venRefFac = new Vendedor();*/
            //        /*cliente1.Codigo = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
            //        cliente1.cargarDatosCliente();*/
            //        /* venRefFac.CodigoV = cliente1.Vendedor;
            //         venRefFac.cargarDatosVendedor();
            //         preFC.txtCodVendedor.Text = venRefFac.CodigoV;
            //         preFC.txtNombreVendedor.Text = venRefFac.Nombre;*/
            //        preFC.txtCodCliente.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
            //        /*preFC.txtNombreCli.Text = cliente1.Nombre;
            //        preFC.txtRif.Text = cliente1.Rif;
            //        //act ref frmFac
            //        preFC.cargarCliVen(cliente1.Codigo, venRefFac.CodigoV);
            //        preFC.actuCondiPag();
            //        preFC.txtCodVendedor.Focus();*/
            //        preFC.txtCodCliente_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Solo puede seleccionar clientes Activos!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}

           if (fuente == 8)
            {
                //referenPedido.txtCodCliente.Text = dataGridView1.CurrentRow.Cells["cli_codigo"].Value.ToString();
                //referenPedido.txtCodCliente_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                //referenPedido.txtCodVendedor_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
                //this.Close();
            }
        }

        public void refFacturacion(frmFactura factura, int f) {
            fact2 = factura;
            fuente = f;
        }

        //public void destino(Form formulario, int opc)
        //{
        //    recibo = (frmRecibodeIngreso)formulario;
        //    fuente = opc;
        //}


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int x = 0; x < dataGridView1.Rows.Count; x++) {
                if (dataGridView1.Rows[x].Cells["cli_situacion"].Value.Equals("Inactivo")) {
                    dataGridView1.Rows[x].DefaultCellStyle.BackColor = Color.FromArgb(254, 198,198);
                }
            }

        }

        private void lbxClientes_FormClosing(object sender, FormClosingEventArgs e)
        {  
            if ((fuente == 2)  && (fact2!= null) ){
                fact2.Focus();
            }
        }

        public void destino(Form formulario, int opc)
        {
            //if (opc == 4)
            //{
            //    recibo = (frmRecibodeIngreso)formulario;
            //    fuente = opc;
            //}

            //if (opc == 5)
            //{
            //    retIvaCli = (frmRetIvaCli)formulario;
            //    fuente = opc;
            //}
        }



        //public void refFacturacion(frmFacturaVivienda factura, int f)
        //{
        //    fuente = f;
        //    factVi = factura;

        //}

        //public void refFacturacion(frmPreFac z, int p)
        //{
        //    preFC = z;
        //    fuente = p;
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //public void refFacturacion(frmPedido pedido, int f)
        //{
        //    referenPedido = pedido;
        //    fuente = f;
        //}
     }
}
