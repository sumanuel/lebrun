using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.facturacion;
using lebrun.clases.clientes;
using lebrun.clases.vendedores;
using lebrun.clases.complementos;
using lebrun.clasesData;
using System.Runtime.InteropServices;

namespace lebrun.formularios.facturacion
{
    public partial class frmImportarDev : Form
    {
        private static frmImportarDev m_FormDefInstance;
        private Factura facDev;
        private Clientes cliDev;
        private Vendedor vendDev;
        private Producto prodDev;
        private frmFactura frmFactDev;
        private Principal referenciaPrincipal;
        private FuncionesTexbox funtxt;
        private frmClaveConfirmacion2 frmClave;
        [DllImport("user32.DLL")]
        public static extern void SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public frmImportarDev()
        {
            InitializeComponent();
            // Esperar a que el formulario esté completamente cargado
            //this.Load += (s, e) => ConfigurarDataGridViewCompletamente();
        }

        //private void ConfigurarDataGridViewCompletamente()
        //{
        //    // Desvincular cualquier data source primero
        //    dataGridView1.DataSource = null;

        //    // Limpiar rows y columns
        //    dataGridView1.Rows.Clear();
        //    dataGridView1.Columns.Clear();

        //    // Configurar propiedades básicas
        //    dataGridView1.AllowUserToAddRows = false;
        //    dataGridView1.AllowUserToDeleteRows = false;
        //    dataGridView1.ReadOnly = true;
        //    dataGridView1.RowHeadersVisible = false;

        //    // Agregar todas las columnas
        //    AgregarTodasLasColumnas();
        //}
    //    private void AgregarTodasLasColumnas()
    //    {
    //        // Columnas visibles
    //        var colMovCodigo = new DataGridViewTextBoxColumn { Name = "mov_codigo", HeaderText = "Código", Width = 105 };
    //        var colProducto = new DataGridViewTextBoxColumn { Name = "colProducto", HeaderText = "Producto", Width = 160 };
    //        var colUnd = new DataGridViewTextBoxColumn { Name = "Und", HeaderText = "Und", Width = 50 };
    //        var colMovCant = new DataGridViewTextBoxColumn { Name = "mov_cant", HeaderText = "Cant", Width = 50 };
    //        var colMovPrecio = new DataGridViewTextBoxColumn { Name = "mov_precio", HeaderText = "Precio" };
    //        var colMovDesc = new DataGridViewTextBoxColumn { Name = "mov_desc", HeaderText = "%Desc", Width = 50 };
    //        var colMovTotal = new DataGridViewTextBoxColumn { Name = "mov_total", HeaderText = "Total" };
    //        var colExportado = new DataGridViewTextBoxColumn { Name = "Exportado", HeaderText = "Exportado", Width = 70 };
    //        var colSaldo = new DataGridViewTextBoxColumn { Name = "Saldo", HeaderText = "Saldo", Width = 70 };

    //        // Agregar columnas visibles
    //        dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
    //    colMovCodigo, colProducto, colUnd, colMovCant, colMovPrecio,
    //    colMovDesc, colMovTotal, colExportado, colSaldo
    //});

    //        // Columnas ocultas - todas las que listaste
    //        string[] columnasOcultas = {
    //    "mov_docaso", "mov_tipoaso", "mov_cencos", "mov_codalm", "mov_cdcomp",
    //    "mov_codcta", "mov_codsuc", "mov_codtra", "mov_vendedor", "mov_docume",
    //    "mov_hora", "mov_item", "mov_itemaso", "mov_itemcomp", "mov_lista",
    //    "mov_lote", "mov_tipdoc", "mov_ivatip", "mov_tipo", "mov_undmed",
    //    "mov_usuario", "mov_fechven", "mov_fecha", "mov_bandas", "mov_contab",
    //    "mov_costo", "mov_cxund", "mov_expendio", "mov_export", "mov_fisico",
    //    "mov_import", "mov_otimp", "mov_impprodu", "mov_invact", "mov_iva",
    //    "mov_logico", "mov_mtocom", "mov_memo", "mov_talla", "mov_color",
    //    "mov_arancel", "mov_kilos", "mov_impuesto", "mov_cosmon", "mov_totalmon",
    //    "mov_precio_ini", "mov_porciva"
    //};

    //        foreach (var columnaNombre in columnasOcultas)
    //        {
    //            var columna = new DataGridViewTextBoxColumn
    //            {
    //                Name = columnaNombre,
    //                HeaderText = columnaNombre,
    //                Visible = false
    //            };
    //            dataGridView1.Columns.Add(columna);
    //        }
    //    }
        public static frmImportarDev DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmImportarDev();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void frmImportarDev_Load(object sender, EventArgs e)
        {


            referenciaPrincipal = (Principal)this.MdiParent;
            facDev = new Factura(200, "DEV",referenciaPrincipal.usuarioActual.IpPc);
            cliDev = new Clientes("200") ;
            vendDev = new Vendedor("200");
            prodDev = new Producto();
            funtxt = new FuncionesTexbox();

            cboTipoDevolucion.Items.Add("Parcial");
            cboTipoDevolucion.Items.Add("Total");
            cboTipoDevolucion.SelectedIndex = 0;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            referenciaPrincipal = (Principal)this.MdiParent;
        }

        public void cargarFacDev(string codDocument, string codClient, string nameClient, string tipoDivisa)
        {
            referenciaPrincipal = (Principal)this.MdiParent;
            txtCodCliente.Text = codClient;
            txtNombreCli.Text = nameClient;
            cliDev.Codigo = codClient;
            cliDev.cargarDatosCliente();
            //vendDev.CodigoV = cliDev.Vendedor;
            //vendDev.cargarDatosVendedor();
            facDev.FacturaAfectada = codDocument;
            facDev.obtenerDatosFacturaAfectada(codDocument);
            vendDev.CodigoV = facDev.VendedorFactura.CodigoV;
            vendDev.cargarDatosVendedor();
            facDev.Divisa = tipoDivisa;
            txtCorrelativo.Text = codDocument;
            facDev.CorrelativoInterno = facDev.obtenerCorrelativo(facDev.TipoDocumento);
            dataGridView1.DataSource = facDev.itemsFac(facDev.FacturaAfectada, cliDev.Codigo, "FAV");

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if ((dataGridView1.Columns[i].Name.Equals("mov_codigo")) || (dataGridView1.Columns[i].Name.Equals("colProducto"))
                    || (dataGridView1.Columns[i].Name.Equals("mov_cant")) || (dataGridView1.Columns[i].Name.Equals("mov_precio"))
                    || (dataGridView1.Columns[i].Name.Equals("mov_desc")) || (dataGridView1.Columns[i].Name.Equals("mov_total")))
                {
                    dataGridView1.Columns[i].Visible = true;
                }
                else
                {
                    dataGridView1.Columns[i].Visible = false;
                }
            }

            dataGridView1.Columns["Und"].Visible = true;
            dataGridView1.Columns["Exportado"].Visible = true;
            dataGridView1.Columns["Saldo"].Visible = true;
            dataGridView1.ClearSelection();

        }


        private void cmdCancelarF_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Desea Salir del Modulo y Cancelar el Documento Actual?", "Cancelar Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool centinela = false;
            if (cboTipoDevolucion.Text.Equals("Parcial"))
            {
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                cboTipoDevolucion.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }

            if (cboTipoDevolucion.Text.Equals("Total"))
            {

                for (int c = 0; c < dataGridView1.Rows.Count; c++) {
                    if (dataGridView1.Rows[c].Cells["mov_cant"].Value.ToString().Equals(dataGridView1.Rows[c].Cells["Exportado"].Value.ToString())) {
                        MessageBox.Show("No se puede Procesar la devolucion Total!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    centinela = true;
                }

                if (centinela)
                {
                    frmClave = frmClaveConfirmacion2.DefInstance;
                    frmClave.Show();
                    frmClave.cambiarReferencia(this);
                    frmImportarDev.SetParent(frmClave.Handle, this.MdiParent.Handle);
                    frmClave.txtClave.Focus();
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["mov_cant"].Value.ToString().Equals(dataGridView1.CurrentRow.Cells["Exportado"].Value.ToString()))
            {
                MessageBox.Show("Ya se exportaron toda la cantidad de ítems para este artículo!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   
                txtCodProducto.Text = dataGridView1.CurrentRow.Cells["mov_codigo"].Value.ToString();
                cboUnidad.Items.Clear();
                cboUnidad.Items.Add(dataGridView1.CurrentRow.Cells["Und"].Value.ToString());
                cboUnidad.SelectedIndex = 0;
                txtCodProducto.Focus();
            }
        }

        private void cmdAgregarItem_Click(object sender, EventArgs e)
        {
            if ((txtCodProducto.Text != "") && (buscarItem(txtCodProducto.Text)))
            {
                if (txtCantidad.Text != "")
                {
                    int filaDGW1 = indexOfItem(txtCodProducto.Text);
                    if ((Convert.ToInt32(txtCantidad.Text)) <= ((Convert.ToInt32(dataGridView1.Rows[filaDGW1].Cells["mov_cant"].Value)) - (Convert.ToInt32(dataGridView1.Rows[filaDGW1].Cells["Exportado"].Value))))
                    {
                        agregarItemDev(txtCodProducto.Text);
                        dataGridView2.ClearSelection();
                    }
                    else {
                        MessageBox.Show("La cantidad a reversar no puede ser mayor que la cantidad Facturada!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                if (txtCodProducto.Text == "") { 

                }
            }
        }


        private bool buscarItem(string codProd)
        {
            bool centinela = false;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if ((fila.Cells["mov_codigo"].Value.ToString().Equals(codProd)))
                {
                    centinela = true;
                }
            }
            return centinela;
        }

        private int indexOfItem(string codProd){
            int indice = -1;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if ((fila.Cells["mov_codigo"].Value.ToString().Equals(codProd)))
                {
                    indice = fila.Index;
                    break;
                }
            }
            return indice;
        }

        private void agregarItemDev(string cod)
        {
            int fila =0;
            int filaGrid1 = indexOfItem(cod);
            dataGridView2.Rows.Add();
            fila = dataGridView2.Rows.Count - 1;
            dataGridView2.Rows[fila].Cells["codigo"].Value = dataGridView1.Rows[filaGrid1].Cells["mov_codigo"].Value;
            dataGridView2.Rows[fila].Cells["producto"].Value = dataGridView1.Rows[filaGrid1].Cells["colProducto"].Value;
            dataGridView2.Rows[fila].Cells["und1"].Value = dataGridView1.Rows[filaGrid1].Cells["Und"].Value;
            //dataGridView2.Rows[fila].Cells["cant"].Value = dataGridView1.Rows[filaGrid1].Cells["mov_cant"].Value;
            dataGridView2.Rows[fila].Cells["cant"].Value = txtCantidad.Text;
            dataGridView2.Rows[fila].Cells["precio"].Value = dataGridView1.Rows[filaGrid1].Cells["mov_precio"].Value;
            dataGridView2.Rows[fila].Cells["des"].Value = dataGridView1.Rows[filaGrid1].Cells["mov_desc"].Value;
            dataGridView2.Rows[fila].Cells["total"].Value = Convert.ToDecimal(dataGridView1.Rows[filaGrid1].Cells["mov_precio"].Value) * Convert.ToInt32(txtCantidad.Text);
            //actualizar grid1
            dataGridView1.Rows[filaGrid1].Cells["Exportado"].Value = txtCantidad.Text;
            dataGridView1.Rows[filaGrid1].Cells["Saldo"].Value =  Convert.ToInt32(dataGridView1.Rows[filaGrid1].Cells["mov_cant"].Value) - Convert.ToInt32( txtCantidad.Text);
        }


        private void agregarItemDev2()
        {
            int filax = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                dataGridView2.Rows.Add();
                filax = dataGridView2.Rows.Count - 1;

                dataGridView2.Rows[filax].Cells["codigo"].Value = fila.Cells["mov_codigo"].Value;
                dataGridView2.Rows[filax].Cells["producto"].Value = fila.Cells["colProducto"].Value;
                dataGridView2.Rows[filax].Cells["und1"].Value = fila.Cells["Und"].Value;
                dataGridView2.Rows[filax].Cells["cant"].Value = fila.Cells["mov_cant"].Value;
                dataGridView2.Rows[filax].Cells["precio"].Value = fila.Cells["mov_precio"].Value;
                dataGridView2.Rows[filax].Cells["des"].Value = fila.Cells["mov_desc"].Value;
                dataGridView2.Rows[filax].Cells["total"].Value = fila.Cells["mov_total"].Value;
                fila.Cells["Exportado"].Value = fila.Cells["mov_cant"].Value;
                fila.Cells["Saldo"].Value = 0;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (txtCantidad.Text != "")
                {
                    cmdAgregarItem_Click(new object(), new EventArgs());
                    limpiarCamposReverso();
                    txtCodProducto.Focus();
                }
                else {
                    MessageBox.Show("Necesita Una cantidad para reversar!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void limpiarCamposReverso() { 
            txtCodProducto.Clear();
            cboUnidad.Items.Clear();
            txtCantidad.Clear();
        }

        private void cmdEliminarItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Items para eliminar!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                int temp = indexOfItem(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["codigo"].Value.ToString());
                dataGridView1.Rows[temp].Cells["Exportado"].Value = (Convert.ToInt32(dataGridView1.Rows[temp].Cells["Exportado"].Value.ToString())) - (Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["cant"].Value.ToString()));
                dataGridView1.Rows[temp].Cells["Saldo"].Value = (Convert.ToInt32(dataGridView1.Rows[temp].Cells["mov_cant"].Value.ToString())) - (Convert.ToInt32(dataGridView1.Rows[temp].Cells["Exportado"].Value.ToString()));
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            while ((dataGridView2.Rows.Count) > 0) {
                dataGridView2.Rows.RemoveAt(0);
            }
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                fila.Cells["Exportado"].Value = fila.Cells["mov_export"].Value;
                fila.Cells["Saldo"].Value = "";
            }

            cboTipoDevolucion.SelectedIndex = 0;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtCodProducto.Text != "") {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        private void cmdConfirmar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                cargarDev();
            }
            else {
                MessageBox.Show("Debe Agregar Items en la Devolucion", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDev() {
            int filaGridFac;
            decimal temp;
            //frmFactDev = frmFactura.DefInstance;
            //frmFactDev.Dispose();
            //frmFactDev = frmFactura.DefInstance;
            //frmFactDev.MdiParent = this.MdiParent;
            //para que abra varias instancias de frm
            frmFactDev = new frmFactura();
            frmFactDev.MdiParent = this.MdiParent;
            frmFactDev.Show();            frmFactDev.Visible = false;
            frmFactDev.fac1 = facDev;
            frmFactDev.client1 = cliDev;
            frmFactDev.vende1 = vendDev;
            frmFactDev.label35.Visible = true;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                frmFactDev.dataGridView1.Rows.Add();
                filaGridFac = frmFactDev.dataGridView1.Rows.Count - 1;
                prodDev.CodigoProd =fila.Cells["codigo"].Value.ToString();
                prodDev.cargarDatosProd(prodDev.CodigoProd);
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_codigo"].Value = fila.Cells["codigo"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["colProducto"].Value = fila.Cells["producto"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["colMed"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_undmed"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cant"].Value = fila.Cells["cant"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_precio"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_precio"].Value;
                temp = Convert.ToDecimal(frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_precio"].Value.ToString().Replace(".", ",")) *
                    Convert.ToDecimal(frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cant"].Value.ToString());
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_desc"].Value = fila.Cells["des"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_total"].Value = fila.Cells["total"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_docaso"].Value = "DEV";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_tipoaso"].Value = "";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cencos"].Value = "0000000001";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_codalm"].Value = "000001";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cdcomp"].Value = " ";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_codcta"].Value = cliDev.Codigo;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_codsuc"].Value = "0000" + "01";//temporal
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_codtra"].Value = "E000";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_vendedor"].Value = vendDev.CodigoV;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_docume"].Value = "";//?
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_hora"].Value = DateTime.Now.ToString("hh:mm:ss tt");
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_item"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_item"].Value; /*String.Format("{0:000}", (filaGridFac + 1));*/
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_itemaso"].Value = " ";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_itemcomp"].Value = " ";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_lista"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_lista"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_lote"].Value = " ";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_tipdoc"].Value = "DEV";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_ivatip"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_ivatip"].Value;   //prodDev.Iva;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_tipo"].Value = "V";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_undmed"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_undmed"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_usuario"].Value = referenciaPrincipal.usuarioActual.Id;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_fechven"].Value = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_fecha"].Value = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_bandas"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_contab"].Value = -1;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_costo"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_costo"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cxund"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_cxund"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["procedencia"].Value = prodDev.Procedencia;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_expendio"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_export"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["Exportado"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_fisico"].Value = 1;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_import"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_otimp"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_impprodu"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_invact"].Value = "1";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_iva"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_iva"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_logico"].Value = 1;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_mtocom"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_memo"].Value = " ";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_talla"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_color"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_arancel"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_kilos"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_impuesto"].Value = "0";
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_cosmon"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_cosmon"].Value;
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_totalmon"].Value = temp;
                if (frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_lista"].Value.ToString().Equals("Z"))
                {
                    frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_precio_ini"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_precio_ini"].Value;
                }
                else
                {
                    frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_precio_ini"].Value = "0.00";
                }
                //se llama a la funcion para acumular bases e iva
                frmFactDev.fac1.acumularBases(temp, dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_ivatip"].Value.ToString());
                switch (dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_ivatip"].Value.ToString())
                {
                    case "GN":
                        frmFactDev.fac1.acumularIvas(frmFactDev.fac1.BaseGN,dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_ivatip"].Value.ToString());
                        break;
                    case "RD":
                        frmFactDev.fac1.acumularIvas(frmFactDev.fac1.BaseRD, dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_ivatip"].Value.ToString());
                        break;
                };
                frmFactDev.dataGridView1.Rows[filaGridFac].Cells["mov_porciva"].Value = dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_porciva"].Value;
                facDev.acumularCostos(Convert.ToDecimal(dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_costo"].Value.ToString().Replace(".", ",")), Convert.ToInt32(fila.Cells["cant"].Value.ToString()), prodDev.Procedencia);
                facDev.acumularBases2(Convert.ToInt32(fila.Cells["cant"].Value.ToString()), Convert.ToDecimal(dataGridView1.Rows[indexOfItem(fila.Cells["codigo"].Value.ToString())].Cells["mov_precio"].Value.ToString().Replace(".", ",")), prodDev.Procedencia);
            }

            for (int i = 0; i < frmFactDev.dataGridView1.Rows.Count; i++) {
                frmFactDev.actualizarTextPagos(i);
            }
            
            frmFactDev.Visible = true;
            frmFactDev.txtCodCliente.Text = frmFactDev.client1.Codigo;
            frmFactDev.txtNombreCli.Text = frmFactDev.client1.Nombre;
            frmFactDev.txtRif.Text = frmFactDev.client1.Rif;
            frmFactDev.txtCodVendedor.Text = frmFactDev.vende1.CodigoV;
            frmFactDev.txtNombreVendedor.Text = frmFactDev.vende1.Nombre;
            frmFactDev.groupBox5.Enabled = false;
            frmFactDev.txtCodCliente.Enabled = false;
            frmFactDev.cmdBuscarCliente.Enabled = false;
            frmFactDev.txtNombreCli.Enabled = false;
            frmFactDev.fac1.TipoDocumento = "DEV";
            //frmFactDev.asignarCorrelativo("DEV");
            //frmFactDev.actualizarCorrelativoGrid();
            frmFactDev.cantidadItemDev();
            frmFactDev.exportDev = true;
            frmFactDev.dev_valVendedor();
            this.Close();
        }

        public void habilitarFormulario(bool valor) {
            this.Enabled = valor;
        }

        public void despuesConfirmacion(bool valor,string codigoU) {
            if (valor)
            {
                facDev.Dcli_aprob3 = codigoU;
                facDev.Dcli_expexp = "Exportado";
                agregarItemDev2();
                cboTipoDevolucion.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else {
                MessageBox.Show("Se necesita la clave de supervisión para la importación Total!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            for (int j = 0; j < dataGridView1.Rows.Count; j++) {
                if ((dataGridView1.Rows[j].Cells["mov_cant"].Value.ToString()).Equals(dataGridView1.Rows[j].Cells["Exportado"].Value.ToString())) {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(254, 198, 198);
                }
            }
        }


    }
}
