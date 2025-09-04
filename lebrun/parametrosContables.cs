using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clasesData;
using System.Text.RegularExpressions;

namespace lebrun
{
    public partial class parametrosContables : Form
    {
        private ConexionBD baseDatos;
        private DataTable tablaCuentas;
        private DataView dv;
       // private ParametroContables paramConta;
        private string empresa;

        public parametrosContables()
        {
            InitializeComponent();
        }

        private void lbxPlanCuentas_Load(object sender, EventArgs e)
        {
            //baseDatos = new ConexionBD();
            //paramConta = new ParametroContables();
            
            //tablaCuentas = baseDatos.fDataTable("SELECT pc_idSistema , pc_Descripcion   FROM admparametroscontables;");
            //txtBuscar.AutoCompleteCustomSource = LoadAutoComplete();
            //txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //dataGridView1.DataSource = tablaCuentas;            
            //label27.Visible = false;
            //dv = new DataView(tablaCuentas);
            //dataGridView1.Columns[0].HeaderText = "Código";
            //dataGridView1.Columns[1].HeaderText = "Descripción";
            //tabParametrosCon.TabPages.Remove(this.tabPage2);
            //chkComprobantesDescuadrados.Checked = true;

        }   

        private  AutoCompleteStringCollection LoadAutoComplete()
        {   
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in tablaCuentas.Rows)
            {
                stringCol.Add(Convert.ToString(row["pc_idSistema"]));
                stringCol.Add(Convert.ToString(row["pc_Descripcion"]));
            }
            return stringCol;
        }


     //importante para capturar el enter con el autocomplete
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdBuscar.Focus();
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            filtrar(txtBuscar.Text);

        }
        
        private void filtrar(string filtro) {
            string sentencia;
            try {
                filtro = filtro.Trim();

                if (IsNumeric(filtro))
                {
                    sentencia = "pc_idSistema =" + filtro + "";   
                }else{                   
                    sentencia = "pc_Descripcion LIKE '%" + filtro + "%'";
                }
                dv.RowFilter = sentencia;
                dataGridView1.DataSource = dv;              
                dataGridView1.Update();
            }
            catch (Exception e){
                MessageBox.Show("error " + e.Message);                
            }
        }

        private void cmdLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            dataGridView1.DataSource = tablaCuentas;
            dataGridView1.Update();
        }

        private bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            agregarTab(1,true);
        }

        private void tabParametrosCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabParametrosCon.SelectedIndex == 0)
            {
                this.txtBuscar.Focus();
                label27.Visible = false;
                limpiarCamposPC();
                tabParametrosCon.TabPages.Remove(this.tabPage2);
            }

            //if (this.tabParametrosCon.SelectedIndex == 1)
            //{
            //    this.txtDescripcion.Focus();
            //}
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos() == true)
            {
                asignarObjeto();
                //if (paramConta.agregarParametro("01") == true) {
                //    label27.Visible = false;
                //    limpiarCamposPC();
                //    actualizarTablaParametros();
                //    tabParametrosCon.TabPages.Remove(this.tabPage2);
                //}                
            }            
        }//fin de aceptarClick

        private Boolean validarCampos() {
            Boolean centinela = true;
            label27.Visible = false;

            if (txtSiglas.Text == "")
            {
                label4.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label4.BackColor = TransparencyKey; }

            if (txtCodigoSiglas.Text == "")
            {
                label26.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label26.BackColor = TransparencyKey; }

            if (txtDescripcion.Text == "")
            {
                label5.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label5.BackColor = TransparencyKey; }

            if (txt1CuentaGP.Text == "")
            {
                label6.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label6.BackColor = TransparencyKey; }

            if (txtUltCuentaGP.Text == "")
            {
                label19.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label19.BackColor = TransparencyKey; }

            //if (txtCuentaSuperAvit.Text == "")
            //{
            //    label20.BackColor = Color.FromArgb(255, 0, 0);
            //    centinela = false;
            //    label27.Visible = true;
            //}
            //else { label20.BackColor = TransparencyKey; }

            //if (txtMascaraImpresion.Text == "")
            //{
            //    label23.BackColor = Color.FromArgb(255, 0, 0);
            //    centinela = false;
            //    label27.Visible = true;
            //}
            //else { label23.BackColor = TransparencyKey; }

            if (txtNroDigitosCta.Text == "")
            {
                label24.BackColor = Color.FromArgb(255, 0, 0);
                centinela = false;
                label27.Visible = true;
            }
            else { label24.BackColor = TransparencyKey; }          
            return centinela;
        }

        private void limpiarCamposPC() {            
            txtDescripcion.Text = "";
            txt1CuentaGP.Text = "";
            txtUltCuentaGP.Text = "";
            txtCuentaSuperAvit.Text = "";
            txtMascaraImpresion.Text = "";
            txtNroDigitosCta.Text = "";
            txtSiglas.Text = "";
            txtCodigoSiglas.Text = "";
            //timePickUltimoCierreMensual.Value= today
            timePickUltimoCierreMensual.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            TimePickerCierreAnual.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            chckConsolidaContabilidad.Checked = false;
            chkParametroGlobal.Checked = false;
            txtClaveCompro.Text = "";
        }

        private void limpiarCamposPC(Boolean sn) {
            limpiarCamposPC();
            label27.Visible = sn;
            if (sn == false)
            {                
                label4.BackColor = TransparencyKey;
                label26.BackColor = TransparencyKey;
                label5.BackColor = TransparencyKey;
                label6.BackColor = TransparencyKey;
                label19.BackColor = TransparencyKey;
                label20.BackColor = TransparencyKey;
                label23.BackColor = TransparencyKey;
                label24.BackColor = TransparencyKey;                
            }
            else {                
                label4.BackColor = Color.FromArgb(255, 0, 0);
                label26.BackColor = Color.FromArgb(255, 0, 0);
                label5.BackColor = Color.FromArgb(255, 0, 0);
                label6.BackColor = Color.FromArgb(255, 0, 0);
                label19.BackColor = Color.FromArgb(255, 0, 0);
                label20.BackColor = Color.FromArgb(255, 0, 0);
                label23.BackColor = Color.FromArgb(255, 0, 0);
                label24.BackColor = Color.FromArgb(255, 0, 0);                
            }
        }

        private void actualizarTablaParametros() {
            tablaCuentas = baseDatos.fDataTable("SELECT pc_idSistema , pc_Descripcion   FROM admparametroscontables;");
            dataGridView1.DataSource = tablaCuentas;
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCamposPC(false);
            activarCampos(true);
        }

        //pasar tab con enter en todos los text designados
        private void MyTextBox_KeyPress(Object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)(Keys.Enter)) {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void cmdBotonModificar_Click(object sender, EventArgs e)
        {
            agregarTab(3,true);
            cargarParametros(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1) {
                agregarTab(2,false);
                cargarParametros(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), false);
                
            }
        }

        private void activarCampos(Boolean valor) {
            txtDescripcion.Enabled = valor;
            txt1CuentaGP.Enabled = valor;
            txtUltCuentaGP.Enabled = valor;
            txtCuentaSuperAvit.Enabled = valor;
            txtMascaraImpresion.Enabled = valor;
            txtNroDigitosCta.Enabled = valor;
            txtSiglas.Enabled = valor;
            txtCodigoSiglas.Enabled = valor;
            timePickUltimoCierreMensual.Enabled = valor;
            TimePickerCierreAnual.Enabled = valor;
            chckConsolidaContabilidad.Enabled = valor;
            chkParametroGlobal.Enabled = valor;
            chkComprobantesDescuadrados.Enabled = valor;
            txtClaveCompro.Enabled = valor;
            cmdAceptar.Visible = valor;
            dateTimePickerDiario.Enabled = valor;
        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            agregarTab(2,false);
            cargarParametros(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(),false);           
        }

        private void cargarParametros(string idParametro) {
            DateTime ultCierreSemanal;
            DateTime ultCierreMen;
            DateTime ultiCierreAnual;

            //paramConta.IdSistema = idParametro;
            //paramConta.cargarParametroCon(paramConta.IdSistema);
            //limpiarCamposPC();
            //limpiarCamposPC(false);

            ////despues de cargar los datos se procede a mostrarlos en el formulario
            //txtDescripcion.Text = paramConta.Descripcion;
            //txt1CuentaGP.Text = paramConta.CuentaIngresos1GP;
            //txtUltCuentaGP.Text = paramConta.CuentaIngresos2GP;
            //txtCuentaSuperAvit.Text = paramConta.CuentaSuperACli;
            //txtMascaraImpresion.Text = paramConta.MascaraImpresion;
            //txtNroDigitosCta.Text = Convert.ToString(paramConta.DigitosCuenta);
            //txtSiglas.Text = paramConta.Siglas;
            //txtCodigoSiglas.Text = paramConta.CorrelativoCuenta;
            //ultCierreMen = Convert.ToDateTime(paramConta.UltimoCierreMensual);
            //ultiCierreAnual = Convert.ToDateTime(paramConta.UltimoCierreAnual);
            //timePickUltimoCierreMensual.Value = new DateTime(ultCierreMen.Year, ultCierreMen.Month, ultCierreMen.Day);
            //TimePickerCierreAnual.Value = new DateTime(ultiCierreAnual.Year, ultiCierreAnual.Month, ultiCierreAnual.Day);
            //chckConsolidaContabilidad.Checked = paramConta.ConsolidaContabilidad;
            //chkParametroGlobal.Checked = paramConta.ParametroGlobal;
            //chkComprobantesDescuadrados.Checked = paramConta.ComprobantesDescuadrados;
            //txtClaveCompro.Text = paramConta.ClaveComprobacion;            
            //this.tabParametrosCon.SelectedIndex = 1;
            //ultCierreSemanal = Convert.ToDateTime(paramConta.UltimoCierreDiario);
            //dateTimePickerDiario.Value = new DateTime(ultCierreSemanal.Year, ultCierreSemanal.Month, ultCierreSemanal.Day);
            //dateTimePickerDiario
        }

        private void cargarParametros(string idParametro, Boolean sn)        {
            cargarParametros(idParametro);
            activarCampos(sn);
        }

        private void btnGrabarModifc_Click(object sender, EventArgs e)
        {
            if (validarCampos() == true) {
                asignarObjeto();

                //label27.Visible = false;
                //limpiarCamposPC();
                //paramConta.actualizarParametro();
                //actualizarTablaParametros();
                //limpiarCamposPC(false);
                //activarCampos(true);
                //tabParametrosCon.TabPages.Remove(this.tabPage2);
            }
        }

        private void asignarObjeto() {
            //paramConta.Siglas = txtSiglas.Text;
            //paramConta.CorrelativoCuenta = txtCodigoSiglas.Text;
            //paramConta.Descripcion = txtDescripcion.Text;
            //paramConta.CuentaIngresos1GP = txt1CuentaGP.Text;
            //paramConta.CuentaIngresos2GP = txtUltCuentaGP.Text;
            //paramConta.CuentaSuperACli = txtCuentaSuperAvit.Text;
            //paramConta.MascaraImpresion = txtMascaraImpresion.Text;
            //paramConta.DigitosCuenta = int.Parse(txtNroDigitosCta.Text);
            //paramConta.ClaveComprobacion = txtClaveCompro.Text;
            //paramConta.ConsolidaContabilidad = chckConsolidaContabilidad.Checked;
            //paramConta.ParametroGlobal = chkParametroGlobal.Checked;
            //paramConta.UltimoCierreMensual = timePickUltimoCierreMensual.Value.Year + "-" + timePickUltimoCierreMensual.Value.Month + "-" + timePickUltimoCierreMensual.Value.Day;
            //paramConta.UltimoCierreAnual = TimePickerCierreAnual.Value.Year + "-" + TimePickerCierreAnual.Value.Month + "-" + TimePickerCierreAnual.Value.Day;
            //paramConta.ComprobantesDescuadrados = chkComprobantesDescuadrados.Checked;
            //paramConta.UltimoCierreDiario = dateTimePickerDiario.Value.Year + "-" + dateTimePickerDiario.Value.Month + "-" + dateTimePickerDiario.Value.Day;
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Seguro que desea Eliminar el Parametro?", "Eliminar Parametro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == System.Windows.Forms.DialogResult.Yes) {
                //paramConta.eliminarParametro(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                MessageBox.Show("Parametro Eliminado Con Exito!!!", "Exito", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                actualizarTablaParametros();
            }
        }

        private void agregarTab(int tipo, Boolean sn) {
            
            switch (tipo) {
                //agregar
                case 1:                    
                    btnGrabarModifc.Visible = false;
                    cmdAceptar.Visible = true;
                    cmdLimpiar.Visible = true;
                    break;
                //ver
                case 2:                    
                    btnGrabarModifc.Visible = false;
                    cmdAceptar.Visible = false;
                    cmdLimpiar.Visible = false;
                    break;
                //modificar
                case 3:                    
                    btnGrabarModifc.Visible = true;
                    cmdAceptar.Visible = false;
                    cmdLimpiar.Visible = false;
                    break;
             }
            if (tabParametrosCon.TabPages.IndexOf(this.tabPage2) == -1)
            {
                tabParametrosCon.TabPages.Add(this.tabPage2);
            }
            else {
                tabParametrosCon.TabPages.Remove(this.tabPage2);
                tabParametrosCon.TabPages.Add(this.tabPage2);
            }
            limpiarCamposPC(false);
            activarCampos(sn);
            this.tabParametrosCon.SelectedIndex = 1;
        }

        private void txtCodigoSiglas_Enter(object sender, EventArgs e)
        {
            txtCodigoSiglas.SelectionStart = 0;
        }

        private void txtCodigoSiglas_Leave(object sender, EventArgs e)
        {
            txtCodigoSiglas.SelectionStart = 0;
        }

        private void txtNroDigitosCta_Enter(object sender, EventArgs e)
        {
            txtNroDigitosCta.SelectionStart = 0;
        }

        private void txtNroDigitosCta_Leave(object sender, EventArgs e)
        {
            txtNroDigitosCta.SelectionStart = 0;
        }

        private void txtDescripcion_Validated(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "") {
                label5.BackColor = Color.FromArgb(255, 0, 0);                
                MessageBox.Show("El Campo Descripción es Obligatorio","Información",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            label5.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txt1CuentaGP_Validated(object sender, EventArgs e)
        {
            if (txt1CuentaGP.Text == "") {
                label6.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo 1ra. Cuenta de Ingresos G. y P. es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txt1CuentaGP_TextChanged(object sender, EventArgs e)
        {
            label6.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txtUltCuentaGP_Validated(object sender, EventArgs e)
        {
            if (txtUltCuentaGP.Text == "")
            {
                label19.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo Ult. Cuenta de Ingresos G. y P. es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtUltCuentaGP_TextChanged(object sender, EventArgs e)
        {
            label19.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txtMascaraImpresion_Validated(object sender, EventArgs e)
        {
            if (txtMascaraImpresion.Text == "")
            {
                label23.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo Mascara de Impresión es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtMascaraImpresion_TextChanged(object sender, EventArgs e)
        {
            label23.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txtNroDigitosCta_Validated(object sender, EventArgs e)
        {
            if (txtNroDigitosCta.Text == "") {
                label24.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo Nro. Digitos Cuenta es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtNroDigitosCta_TextChanged(object sender, EventArgs e)
        {
            label24.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txtSiglas_Validated(object sender, EventArgs e)
        {
            if(txtSiglas.Text == ""){
                label4.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo Siglas es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtSiglas_TextChanged(object sender, EventArgs e)
        {
            label4.BackColor = TransparencyKey;
            validarValidated();
        }

        private void txtCodigoSiglas_Validated(object sender, EventArgs e)
        {   if(txtCodigoSiglas.Text == ""){
                label26.BackColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("El Campo Correlativo Sistema es Obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validarValidated();
            }
        }

        private void txtCodigoSiglas_TextChanged(object sender, EventArgs e)
        {
            label26.BackColor = TransparencyKey;
            validarValidated();
        }

        private void validarValidated() {            
            if ((label5.BackColor.Name != "Transparent") || (label6.BackColor.Name != "Transparent") || (label19.BackColor.Name != "Transparent")
                || (label23.BackColor.Name!= "Transparent") || (label24.BackColor.Name != "Transparent") || (label4.BackColor.Name != "Transparent")
                || (label26.BackColor.Name !="Transparent"))
            {
                label27.Visible = true;
            }
            else {
                label27.Visible = false;
            }
        }

        private void dateTimePickerDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void timePickUltimoCierreMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void TimePickerCierreAnual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }
       
   
    }
}
