using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.bancos;
using lebrun.formularios.facturacion;
//using lebrun.formularios.compras;
//using lebrun.formularios.cotizacion;
using lebrun.formularios.complementos;

namespace lebrun.formularios.bancos
{
    public partial class lbxBancos : Form
    {
        //private frmProveedores proveedor;
        private Banco ban1;
        private static lbxBancos m_FormDefInstance;
        private frmFactura referenciaFactura;
        private string origen = null;
        private frmBancos frmBanco;
        private frmCuentasBanc RefCuentasBan;
        //private frmProcesoPago refProcesoPago;
        //private frmProcesoPagoManual refProcesoPagoManual;
        //private frmFacturaVivienda referenciaFactVi;
        //private frmPreFac preFC;
        public delegate void lbxBanco(string BancoSelect);
        public event lbxBanco bancoSelec;
        public lbxBancos()
        {
            InitializeComponent();
        }

        private void lbxBancos_Load(object sender, EventArgs e)
        {
            //proveedor = new frmProveedores();
            ban1 = new Banco();
            cargarBancos();
            
        }

        public static lbxBancos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new lbxBancos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public void actualizarRefFact(frmFactura factReferen, string refOrigen) {
            this.referenciaFactura = factReferen;
            origen = refOrigen;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((origen != null) && (origen.Equals("facturacion")) ) {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    referenciaFactura.txtBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    referenciaFactura.actualizarCodBanco(this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());

                    referenciaFactura.txtNumeroT.Focus();
                    this.Close();
                }
                else {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if ((origen != null) && (origen.Equals("CuentasBancarias")))
            {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    RefCuentasBan.lblNombreBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    RefCuentasBan.txtBanco.Text = (this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());
                    RefCuentasBan.txtBanco.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if ((origen != null) && (origen.Equals("procesoPago")))
            {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    //refProcesoPago.lblNombreBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    //refProcesoPago.txtCodigoBanco.Text = (this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());
                    //refProcesoPago.cmbNumeroCuenta.Text = "";
                    //refProcesoPago.txtCodigoBanco.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            if ((origen != null) && (origen.Equals("procesoPagoManual")))
            {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    //refProcesoPagoManual.lblNombreBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    //refProcesoPagoManual.txtCodigoBanco.Text = (this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());
                    //refProcesoPagoManual.cmbNumeroCuenta.Text = "";
                    //refProcesoPagoManual.txtCodigoBanco.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if ((origen != null) && (origen.Equals("facturacionV")))
            {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    //referenciaFactVi.txtBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    //referenciaFactVi.actualizarCodBanco(this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());

                    //referenciaFactVi.txtNumeroT.Focus();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if ((origen != null) && (origen.Equals("preFC")))
            {
                if ((this.dataGridView1.Rows[e.RowIndex].Cells["ban_tel3"].Value.ToString().Equals("Activo")))
                {
                    //preFC.txtBanco.Text = this.dataGridView1.Rows[e.RowIndex].Cells["ban_nombre"].Value.ToString();
                    //preFC.actualizarCodBanco(this.dataGridView1.Rows[e.RowIndex].Cells["ban_codigo"].Value.ToString());

                    //preFC.txtNumeroT.Focus();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Solo puede seleccionar Banco Activo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void lbxBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((origen != null) && (origen.Equals("facturacion"))) {
                referenciaFactura.Focus();
            }

            if ((origen != null) && (origen.Equals("facturacionV")))
            {
                //referenciaFactVi.Focus();
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargarBancos() {
            this.dataGridView1.DataSource = ban1.lbxBancos();
            this.dataGridView1.Columns["ban_codigo"].HeaderText = "Código Banco";
            this.dataGridView1.Columns["ban_nombre"].HeaderText = "Nombre Banco";
            this.dataGridView1.Columns["ban_tel3"].HeaderText = "Status Banco";
        }

        public void limpiarTotal() {
            txtBuscar.Clear();
            dataGridView1.DataSource = null;
            cargarBancos();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            limpiarTotal();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataTable dtTemp;
            if ((e.KeyChar == (char)(Keys.Enter)) && txtBuscar.Text != "")
            {
                dtTemp = ban1.buscarBancosCodNom(txtBuscar.Text);
                if (dtTemp.Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = dtTemp;
                    this.dataGridView1.Columns["ban_codigo"].HeaderText = "Código Banco";
                    this.dataGridView1.Columns["ban_nombre"].HeaderText = "Nombre Banco";
                    this.dataGridView1.Columns["ban_tel3"].HeaderText = "Status Banco";
                }
                else
                {
                    MessageBox.Show("No se consiguieron Resultados!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBuscar.Focus();
                }
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_KeyPress(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmBanco = new frmBancos();
            frmBanco.referenciaRefrescar(this);
            frmBanco.ShowDialog();
        }

        private void cmdModificarCli_Click(object sender, EventArgs e)
        {
            frmBanco = new frmBancos(dataGridView1.CurrentRow.Cells[0].Value.ToString(), 1);
            frmBanco.referenciaRefrescar(this);
            frmBanco.ShowDialog();
        }

        public void refrescar(object sender, EventArgs e)
        {
            cargarBancos();
        }

        public void destino(Form formulario, string opc)
        {
            //if (opc == "CuentasBancarias")
            //{
            //    RefCuentasBan = (frmCuentasBanc)formulario;
            //    origen = opc;
            //}

            //if (opc == "procesoPago")
            //{
            //    refProcesoPago = (frmProcesoPago)formulario;
            //    origen = opc;
            //}

            //if (opc == "procesoPagoManual")
            //{
            //    refProcesoPagoManual = (frmProcesoPagoManual)formulario;
            //    origen = opc;
            //}

        }

        //public void actualizarRefFact(frmFacturaVivienda factReferen, string refOrigen)
        //{
        //    this.referenciaFactVi = factReferen;
        //    origen = refOrigen;
        //}

        //public void actualizarRefFact(frmPreFac factReferen, string refOrigen)
        //{
        //    this.preFC = factReferen;
        //    origen = refOrigen;
        //}

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           bancoSelec(dataGridView1.CurrentRow.Cells["ban_nombre"].Value.ToString());
           this.Close();
        }

    }
}
