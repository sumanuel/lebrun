using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.facturacion;
using System.Threading;
using System.Runtime.InteropServices;

namespace lebrun.formularios.facturacion
{
    public partial class lbxFacturas : Form {
        private static lbxFacturas m_FormDefInstance;
        private Factura fact1;
        private frmFactura frmFacturacion;
        private DataView dv;
        private DataTable dtFact;
        private Principal referenciaPrincipal;
        private string tipoOperacion;
        private bool centinelaReimpresion;
        private frmImportarDev importDevolucion;
        public SerieFiscal serFis;
        private frmClaveConfirmacion2 claveDev;

        public lbxFacturas()
        {
            InitializeComponent();
        }

        public static lbxFacturas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new lbxFacturas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void lbxFacturas_Load(object sender, EventArgs e)
        {
            dtFact = new DataTable();
            referenciaPrincipal = (Principal)this.MdiParent;
            serFis = new SerieFiscal(referenciaPrincipal.usuarioActual.IpPc);
            //se modifica para obtener la caja que esta amarrada por ip
            referenciaPrincipal.usuarioActual.NumeroCaja = serFis.SerieCaja;

            if (this.Name.Equals("Factura de Venta"))
            {
                fact1 = new Factura(200,"FAV",referenciaPrincipal.usuarioActual.IpPc);//por efectos de actualizar lbx
                dtFact = fact1.lbxFact(serFis.SerieCaja);
                dv = new DataView(dtFact);
                this.dataGridView1.DataSource = dtFact;
                this.Text = this.Text + this.Name;
            }

            if (this.Name.Equals("Devolucion de Venta"))
            {
                fact1 = new Factura(200, "DEV",referenciaPrincipal.usuarioActual.IpPc);//por efectos de actualizar lbx
                dtFact = fact1.lbxDev(serFis.SerieCaja);
                dv = new DataView(dtFact);
                this.dataGridView1.DataSource = dtFact;
                this.Text = this.Text + this.Name;
            }
            dataGridView1.Columns[0].HeaderText = "Numero";
            dataGridView1.Columns[1].HeaderText = "Codigo";
            dataGridView1.Columns[2].HeaderText = "Cliente";
            dataGridView1.Columns[3].HeaderText = "Fecha";
            dataGridView1.Columns[4].HeaderText = "Estado";
            dataGridView1.Columns[5].HeaderText = "Monto";
            dataGridView1.Columns[8].HeaderText = "Num Fiscal";
            dataGridView1.Columns[9].HeaderText = "Imp";
            dataGridView1.Columns[9].Width = 30;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns["dcli_codmon"].Visible = false;
            dataGridView1.Columns["dcli_facafe"].Visible = false;
            verificarEstadosFis();
        }

        public void verificarEstadosFis() {
            bool cierreCaja = serFis.isCierreCaja();
            if ((serFis.isPointFavEnabled())  && (!(cierreCaja)) ){ 
                cmdAgregar.Enabled = true;
                if (this.Name.Equals("Factura de Venta"))
                {
                    cmdDevolucion.Enabled = true;
                }
                cmdImprimir.Enabled = true;
                serFis.setActivate(1);
                serFis.cambiarUsuario(referenciaPrincipal.usuarioActual.Id);
            }
            if (cierreCaja) {
                MessageBox.Show("Se ejecutando El cierre de esta Caja!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (!chkFecha.Checked)
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
            else {
                filtrarFecha();
            }
        }

        private void filtrar(string filtro)
        {
            string sentencia;
            DataTable temp;
            try
            {
                sentencia = "dcli_numero LIKE '" + filtro + "%'";
                dv.RowFilter = sentencia;
                if (dv.Count == 0)
                {
                    progressBar1.Value = 2;
                    sentencia = "cli_nombre LIKE '" + filtro + "%'";
                    dv.RowFilter = sentencia;
                    if (dv.Count == 0)
                    {
                        progressBar1.Value = 4;
                        sentencia = "dcli_numfis LIKE '" + filtro + "%'";
                        dv.RowFilter = sentencia;
                    }
                }
                if (dv.Count > 0)
                {
                    progressBar1.Value = 6;
                    dataGridView1.DataSource = dv;
                    dataGridView1.Update();
                }
                else
                {
                    temp = new DataTable();
                    if (this.Name.Equals("Factura de Venta"))
                    {
                        temp = fact1.facturaBuscada(txtBuscar.Text,"FAV");
                    }

                    if (this.Name.Equals("Devolucion de Venta"))
                    {
                        temp = fact1.facturaBuscada(txtBuscar.Text, "DEV");
                    }
                    progressBar1.Value = 6;
                    if (temp.Rows.Count == 0)
                    {   
                            MessageBox.Show("No se consiguieron Resultados!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = temp;
                        dataGridView1.Columns[0].HeaderText = "Numero";
                        dataGridView1.Columns[1].HeaderText = "Codigo";
                        dataGridView1.Columns[2].HeaderText = "Cliente";
                        dataGridView1.Columns[3].HeaderText = "Fecha";
                        dataGridView1.Columns[4].HeaderText = "Estado";
                        dataGridView1.Columns[5].HeaderText = "Monto";
                        dataGridView1.Columns[8].HeaderText = "Num Fiscal";
                        dataGridView1.Columns[9].HeaderText = "Imp";
                        dataGridView1.Columns[9].Width = 30;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns["dcli_codmon"].Visible = false;
                        dataGridView1.Columns["dcli_facafe"].Visible = false;
                        dataGridView1.Update();
                    }
                }
            }
         catch (Exception e)
            {
                MessageBox.Show("Error buscar " + e.Message);
            }
        }

        private void filtrarFecha() {
            DataTable dtemp;
            dtemp = fact1.facturaBuscada2(dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day,
                                                          dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day,"FAV");

            if (dtemp.Rows.Count == 0)
            {
                MessageBox.Show("No se consiguieron Resultados!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dtemp;//ml 370 gs
                dataGridView1.Columns[0].HeaderText = "Numero";
                dataGridView1.Columns[1].HeaderText = "Codigo";
                dataGridView1.Columns[2].HeaderText = "Cliente";
                dataGridView1.Columns[3].HeaderText = "Fecha";
                dataGridView1.Columns[4].HeaderText = "Estado";
                dataGridView1.Columns[5].HeaderText = "Monto";
                dataGridView1.Columns[8].HeaderText = "Num Fiscal";
                dataGridView1.Columns[9].HeaderText = "Imp";
                dataGridView1.Columns[9].Width = 30;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns["dcli_codmon"].Visible = false;
                dataGridView1.Columns["dcli_facafe"].Visible = false;
                dataGridView1.Update();
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            limpiarForm();
        }

        public void limpiarForm() {
            dtFact = null;
            dataGridView1.DataSource = null;
            progressBar1.Value = 1;
            txtBuscar.Clear();
            chkFecha.Checked = false;
            if (this.Name.Equals("Factura de Venta"))
            {
                dtFact = fact1.lbxFact(referenciaPrincipal.usuarioActual.NumeroCaja);
            }

            if (this.Name.Equals("Devolucion de Venta"))
            {
                dtFact = fact1.lbxDev(referenciaPrincipal.usuarioActual.NumeroCaja);
            }
            dv = new DataView(dtFact);
            this.dataGridView1.DataSource = dtFact;
            dataGridView1.Columns[0].HeaderText = "Numero";
            dataGridView1.Columns[1].HeaderText = "Codigo";
            dataGridView1.Columns[2].HeaderText = "Cliente";
            dataGridView1.Columns[3].HeaderText = "Fecha";
            dataGridView1.Columns[4].HeaderText = "Estado";
            dataGridView1.Columns[5].HeaderText = "Monto";
            dataGridView1.Columns[8].HeaderText = "Num Fiscal";
            dataGridView1.Columns[9].HeaderText = "Imp";
            dataGridView1.Columns[9].Width = 30;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns["dcli_codmon"].Visible = false;
            dataGridView1.Columns["dcli_facafe"].Visible = false;
            dataGridView1.Update();
        }

        [DllImport("user32.DLL")]
        public static extern void SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void cmdAgregar_Click_1(object sender, EventArgs e)
        {
            if (this.Name.Equals("Devolucion de Venta")) {
                claveDev = frmClaveConfirmacion2.DefInstance;
                this.Enabled = false;
                claveDev.Show();
                claveDev.cambiarReferencia(this);
                lbxFacturas.SetParent(claveDev.Handle, this.MdiParent.Handle);
                claveDev.txtClave.Focus();
                return;
            }
            //frmFacturacion = frmFactura.DefInstance;
            //frmFacturacion.Dispose();
            //frmFacturacion = frmFactura.DefInstance; 
            //Para abrir varios FRM
            frmFacturacion = new frmFactura();
            frmFacturacion.MdiParent = this.MdiParent;
            frmFacturacion.Show();
            if (this.Name.Equals("Factura de Venta"))
            {
                frmFacturacion.asignarCorrelativo("FAV");
            }
            else
            {
                frmFacturacion.asignarCorrelativo("DEV");
            }
            frmFacturacion.txtCodCliente.Focus();
        }

        public void despuesConfirmacionLbx(bool valor) {
            if (valor)
            {
                this.Enabled = true;
                frmFacturacion = frmFactura.DefInstance;
                frmFacturacion.Dispose();
                frmFacturacion = frmFactura.DefInstance;
                frmFacturacion.MdiParent = this.MdiParent;
                //para abrir varios FRM
                frmFacturacion = new frmFactura();
                frmFacturacion.MdiParent = this.MdiParent;
                frmFacturacion.Show();
                
                //frmFacturacion.asignarCorrelativo("DEV");
                frmFacturacion.fac1.TipoDocumento = "DEV";
                frmFacturacion.txtCodCliente.Focus();
                frmFacturacion.label35.Visible = true;
            }
            else {
                MessageBox.Show("Debe Colocar la clave para la devolucion!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Enabled = true;
            }
        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                pictureBox1.Visible = true;
                frmFacturacion = frmFactura.DefInstance;
                frmFacturacion.MdiParent = this.MdiParent;
                tipoOperacion = "ver";
                backgroundWorker1.RunWorkerAsync(frmFacturacion);
            }
            else {
                MessageBox.Show("Debe Existir una Factura Para Mostrar!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tipoOperacion.Equals("ver"))
            {
                System.ComponentModel.BackgroundWorker worker;
                worker = (System.ComponentModel.BackgroundWorker)sender;

                frmFactura fc = (frmFactura)e.Argument;
                fc.frmFactura_Load(new object(), new EventArgs(), true);
                this.frmFacturacion = fc.soloVista(dataGridView1.CurrentRow.Cells["dcli_numero"].Value.ToString());
            }

            if (tipoOperacion.Equals("reimp")) {
                System.ComponentModel.BackgroundWorker worker;
                worker = (System.ComponentModel.BackgroundWorker)sender;
                if (this.Name.Equals("Factura de Venta"))
                {
                    frmFactura fc = (frmFactura)e.Argument;
                    fc.frmFactura_Load(new object(), new EventArgs(), true);
                    this.frmFacturacion = fc.soloVista(dataGridView1.CurrentRow.Cells["dcli_numero"].Value.ToString());
                }
                if (this.Name.Equals("Devolucion de Venta")) {
                    frmFactura fc = (frmFactura)e.Argument;
                    fc.frmFactura_Load(new object(), new EventArgs(), true);
                    //dcli_numero
                    this.frmFacturacion = fc.soloVista2(dataGridView1.CurrentRow.Cells["dcli_numero"].Value.ToString(), "DEV", dataGridView1.CurrentRow.Cells["dcli_numero"].Value.ToString());
                }
            }

            if (tipoOperacion.Equals("reimpFAV")) {
                System.ComponentModel.BackgroundWorker worker;
                worker = (System.ComponentModel.BackgroundWorker)sender;

                frmFactura fc = (frmFactura)e.Argument;
                centinelaReimpresion= fc.reimprimirFAV();
                if (fc.fac1.Dcli_estado.Equals("Activo")) {
                    fc.fac1.guardarNumeroFiscalSalcli();
                }
                fc.limpiarCompleto();
            }

            if (tipoOperacion.Equals("reimpDEV"))
            {
                System.ComponentModel.BackgroundWorker worker;
                worker = (System.ComponentModel.BackgroundWorker)sender;

                frmFactura fc = (frmFactura)e.Argument;
                centinelaReimpresion = fc.reimprimirDEV(dataGridView1.CurrentRow.Cells["dcli_facafe"].Value.ToString());
                if (fc.fac1.Dcli_estado.Equals("Activo"))
                {
                    fc.fac1.guardarNumeroFiscalSalcli();
                }
                fc.limpiarCompleto();

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (tipoOperacion.Equals("ver"))
            {
                if (this.frmFacturacion == null)
                {
                    pictureBox1.Visible = true;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string respuesta = null;
            bool cen;
            if (tipoOperacion.Equals("ver"))
            {
                if (this.frmFacturacion != null)
                {
                    pictureBox1.Visible = false;
                    this.frmFacturacion.Show();
                }
                tipoOperacion = null;
                centinelaReimpresion = false;
                return;
            }

            if (tipoOperacion.Equals("reimp")) {
                if (this.frmFacturacion != null) {
                    respuesta = this.frmFacturacion.respuestaImpresora();

                    if (respuesta.Equals("00"))
                    {
                        //se valida que tipo de documento se va a imprimir
                        if (dataGridView1.CurrentRow.Cells["dcli_tipdoc"].Value.ToString().Equals("FAV"))
                        {
                            //se procede a imprimir
                            tipoOperacion = "reimpFAV";
                            pictureBox1.Visible = false;
                            pictureBox1.Visible = true;
                            backgroundWorker1.RunWorkerAsync(frmFacturacion);
                            return;
                        }
                        //se valida que tipo de documento se va a imprimir
                        if (dataGridView1.CurrentRow.Cells["dcli_tipdoc"].Value.ToString().Equals("DEV"))
                        {
                            //se procede a imprimir
                            tipoOperacion = "reimpDEV";
                            pictureBox1.Visible = false;
                            pictureBox1.Visible = true;
                            backgroundWorker1.RunWorkerAsync(frmFacturacion);
                            return;
                        }
                    }

                    if ((respuesta.Equals("04")) || (respuesta.Equals("08")))
                    {
                        DialogResult decision;
                        decision = MessageBox.Show("¿Desea realizar el reporte Z?", "Requiere realizar reporte Z", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (decision == System.Windows.Forms.DialogResult.Yes)
                        {
                            cen = frmFacturacion.realizarZ();
                            if (cen) {
                                //se procede a imprimir
                                tipoOperacion = "reimpFAV";
                                pictureBox1.Visible = false;
                                pictureBox1.Visible = true;
                                backgroundWorker1.RunWorkerAsync(frmFacturacion);
                                cen = false;
                                return;
                            }
                            //epsonLX300.reporteZ();
                        }
                    }

                    if (respuesta.Equals("01"))
                    {
                        MessageBox.Show("Comprobante Fiscal Abierto!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //epsonLX300.cerrarDocumentoFiscal();
                        ////epsonLX300.imprimirFAV(fac1, this.txtPagado);

                    }

                    if (respuesta.Equals("02"))
                    {
                        MessageBox.Show("Comprobante NoFiscal Abierto!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if ((Convert.ToInt32(respuesta) >= 9) && (Convert.ToInt32(respuesta) <= 14))
                    {
                        MessageBox.Show("Controlador Bloqueado!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if ((Convert.ToInt32(respuesta)) >= 15)
                    {
                        MessageBox.Show("Error Desconocido", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (tipoOperacion.Equals("reimpFAV")) {
                if (centinelaReimpresion)
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Factura Reimpresa Existosamente", "Exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tipoOperacion = null;
                    centinelaReimpresion = false;
                    limpiarForm();
                    return;
                }
                else {
                    MessageBox.Show("Error al Remprimir Factura", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (tipoOperacion.Equals("reimpDEV"))
            {
                if (centinelaReimpresion)
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Devolucion Reimpresa Existosamente", "Exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tipoOperacion = null;
                    centinelaReimpresion = false;
                    limpiarForm();
                    return;
                }
                else
                {
                    MessageBox.Show("Error al Remprimir Devolucion", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tipoOperacion.Equals("ver"))
            {
                using (Font myFont = new Font("Arial", 24))
                {
                    e.Graphics.DrawString("Cargando!", myFont, Brushes.Black, new Point(2, 2));
                }
            }

            if (tipoOperacion.Equals("reimp")) {
                using (Font myFont = new Font("Arial", 24))
                {
                    e.Graphics.DrawString("Cargando Datos Por Favor Espere!", myFont, Brushes.Black, new Point(2, 2));
                }
            }

            if (tipoOperacion.Equals("reimpFAV")) {
                using (Font myFont = new Font("Arial", 24))
                {
                    e.Graphics.DrawString("Imprimiendo Factura Por Favor Espere!", myFont, Brushes.Black, new Point(2, 2));
                }
            }

            if (tipoOperacion.Equals("reimpDEV"))
            {
                using (Font myFont = new Font("Arial", 24))
                {
                    e.Graphics.DrawString("Imprimiendo Dev. Por Favor Espere!", myFont, Brushes.Black, new Point(2, 2));
                }
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Cells["dcli_impreso"].Value.ToString().Equals("0"))
                {
                    DialogResult respuesta;
                    respuesta = MessageBox.Show("¿Desea Imprimir Documento?", "Imprimir Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == System.Windows.Forms.DialogResult.Yes)
                    {
                        tipoOperacion = "reimp";
                        frmFacturacion = frmFactura.DefInstance;
                        frmFacturacion.MdiParent = this.MdiParent;
                        pictureBox1.Visible = true;
                        backgroundWorker1.RunWorkerAsync(frmFacturacion);
                    }
                    else {
                        return;
                    }
                }
                else {
                    MessageBox.Show("Este Documento ya se encuentra Impreso!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                MessageBox.Show("Debe Existir un Documento Para Imprimir!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdDevolucion_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count > 0) && (dataGridView1.CurrentRow.Cells["dcli_impreso"].Value.ToString().Equals("1")) && (dataGridView1.CurrentRow.Cells["dcli_numfis"].Value.ToString() != "") && !(dataGridView1.CurrentRow.Cells["dcli_estado"].Value.ToString().Equals("Exportado")))
            {
                importDevolucion = frmImportarDev.DefInstance;
                importDevolucion.MdiParent = this.MdiParent;
                importDevolucion.Show();
                importDevolucion.cargarFacDev((dataGridView1.CurrentRow.Cells["dcli_numero"].Value.ToString()), (dataGridView1.CurrentRow.Cells["dcli_codigo"].Value.ToString()), (dataGridView1.CurrentRow.Cells["cli_nombre"].Value.ToString()), (dataGridView1.CurrentRow.Cells["dcli_codmon"].Value.ToString()));
            }
            else if ((dataGridView1.Rows.Count == 0))
            {
                MessageBox.Show("Debe Existir un Documento Para Procesar Devolución!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(!(dataGridView1.CurrentRow.Cells["dcli_impreso"].Value.ToString().Equals("1"))) {
                MessageBox.Show("No se Puede hacer una Devolucion a una Factura No Impresa!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if ((dataGridView1.CurrentRow.Cells["dcli_numfis"].Value.ToString() == ""))
            {
                MessageBox.Show("No se puede hacer una Devolucion a una Factura Sin numero Fiscal!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dataGridView1.CurrentRow.Cells["dcli_estado"].Value.ToString().Equals("Exportado"))
            {
                MessageBox.Show("No se puede hacer una Devolucion a una Factura en estado Exportado!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdLimpiar_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.cmdLimpiar, "Refrescar Lbx");
        }

        private void lbxFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.serFis.setActivate(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cierreCaja cie = new cierreCaja();
            //cie.MdiParent = this.MdiParent;
            //cie.Show();
        }
        
    }
}