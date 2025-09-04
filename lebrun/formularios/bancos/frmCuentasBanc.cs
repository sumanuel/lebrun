using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clasesData;
//using lebrun.formularios.contabilidad;
using lebrun.clases.contabilidad;
using lebrun.clases.bancos;


namespace lebrun.formularios.bancos
{
    public partial class frmCuentasBanc : Form
    {

        private lbxBancos lbxBanco;
        private Compania compania;
        //private lbxPlanCuentas planCuentaLbx;
        private PlanCuentas planCuenta;
        private AuxiliarContable au;
        //private lbxAuxiliaresOnly auxiliar;
        private Banco banco;
        private DataTable tabla;
        private DataTable tablaChequera;
        private static frmCuentasBanc m_FormDefInstance;
        private FuncionesTexbox textBox;
        private lbxCuentasBanc lbxCuentasBan;

        private string accion;
        private string bancoM;
        private string numeroCuentaM;
        private string titularM;
        private string tipoM;
        

        public frmCuentasBanc()
        {
            InitializeComponent();
            compania = new Compania();
            planCuenta = new PlanCuentas();
            au = new AuxiliarContable();
            banco = new Banco();
            tabla = new DataTable();
            tablaChequera = new DataTable();
            textBox = new FuncionesTexbox();
            accion = "registro";
        }

        public frmCuentasBanc(string caso, string modBanco, string modCuenta, string modTitular, string mobTipo)
        {
            InitializeComponent();
            compania = new Compania();
            planCuenta = new PlanCuentas();
            au = new AuxiliarContable();
            banco = new Banco();
            tabla = new DataTable();
            tablaChequera = new DataTable();
            textBox = new FuncionesTexbox();
            accion = caso;
            bancoM = modBanco;
            numeroCuentaM = modCuenta;
            titularM = modTitular;
            tipoM = mobTipo;

        }

        public static frmCuentasBanc DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCuentasBanc();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            lbxCuentasBan = new lbxCuentasBanc();
            lbxCuentasBan.Show();
        }

        private void frmCuentasBanc_Load(object sender, EventArgs e)
        {
            txtIDB.ReadOnly = true;
            if (accion == "modificar")
            {
                txtBanco.Enabled = false;
                button3.Enabled = false;
                cargarModificacion();
            }
            else
            {
                checkedListBox1.SetItemChecked(0, true);
                checkedListBox1.SetItemChecked(1, true);
                checkedListBox1.SetItemChecked(2, true);
                checkedListBox1.SetItemChecked(3, true);
                checkedListBox1.SetItemChecked(4, false);
                cmbChequeraAct.SelectedIndex = 0;
                cmbTipCuenta.SelectedIndex = 1;
            }
        }

        private void calcularCheques(string inicio, string cant, TextBox textbox){

            if (Convert.ToInt16(cant) == 0)
            {
                textbox.Text = "0";
            }
            else
            {
                textbox.Text = "" + ((Convert.ToInt64(inicio) + Convert.ToInt16(cant)) - 1);
            }
        }

        private void txtAdesde_Leave(object sender, EventArgs e)
        {
            if (txtChe1Desde.Text == "")
            {
                txtChe1Desde.Text = "0";
            }

            if (Convert.ToInt64(txtChe1Desde.Text) != 0 && txtChe1Desde.Text != "")
            {
                calcularCheques(txtChe1Desde.Text, txtChe1Cant.Text, txtChe1Hasta);
            }
            else {
                txtChe1Hasta.Text = "0";
                txtChe1Cant.Text = "0";
                txtUltiChe1.Text = "0";
            }   

        }

        private void txtAcant_Leave(object sender, EventArgs e)
        {
            if (txtChe1Cant.Text == "")
            {
                txtChe1Cant.Text = "0";
            }

            if (Convert.ToInt64(txtChe1Desde.Text) != 0 && txtChe1Desde.Text != "" && Convert.ToInt64(txtChe1Cant.Text) != 0)
            {
                calcularCheques(txtChe1Desde.Text, txtChe1Cant.Text, txtChe1Hasta);
                txtUltiChe1.Text = txtChe1Desde.Text;
            }
            else
            {
                txtChe1Hasta.Text = "0";
                txtChe1Desde.Text = "0";
                txtUltiChe1.Text = "0";
                txtChe1Cant.Text = "0";
            }
        }

        private void txtBdesde_Leave(object sender, EventArgs e)
        {
            if (txtChe2Desde.Text == "")
            {
                txtChe2Desde.Text = "0";
            }

            if (Convert.ToInt64(txtChe2Desde.Text) != 0 && txtChe2Desde.Text != "")
            {
                calcularCheques(txtChe2Desde.Text, txtChe2Cant.Text, txtChe2Hasta);
            }
            else
            {
                txtChe2Hasta.Text = "0";
                txtChe2Cant.Text = "0";
                txtUltiChe2.Text = "0";
            }
        }

        private void txtBcant_Leave(object sender, EventArgs e)
        {
            if (txtChe2Desde.Text == "")
            {
                txtChe2Desde.Text = "0";
            }

            if (Convert.ToInt64(txtChe2Desde.Text) != 0 && txtChe2Desde.Text != "" && Convert.ToInt64(txtChe2Cant.Text) != 0)
            {
                calcularCheques(txtChe2Desde.Text, txtChe2Cant.Text, txtChe2Hasta);
                txtUltiChe2.Text = txtChe2Desde.Text;
            }
            else
            {
                txtChe2Hasta.Text = "0";
                txtChe2Desde.Text = "0";
                txtUltiChe2.Text = "0";
                txtChe2Cant.Text = "0";
            }

        }

        private void txtCdesde_Leave(object sender, EventArgs e)
        {
            if (txtChe3Desde.Text == "")
            {
                txtChe3Desde.Text = "0";
            }

            if (Convert.ToInt64(txtChe3Desde.Text) != 0 && txtChe3Desde.Text != "")
            {
                calcularCheques(txtChe3Desde.Text, txtChe3Cant.Text, txtChe3Hasta);
            }
            else
            {
                txtChe3Hasta.Text = "0";
                txtChe3Cant.Text = "0";
                txtUltiChe3.Text = "0";
            }
        }

        private void txtCcant_Leave(object sender, EventArgs e)
        {
            if (txtChe1Cant.Text == "")
            {
                txtChe1Cant.Text = "0";
            }


            if (Convert.ToInt64(txtChe3Desde.Text) != 0 && txtChe3Desde.Text != "" && Convert.ToInt64(txtChe3Cant.Text) != 0)
            {
                calcularCheques(txtChe3Desde.Text, txtChe3Cant.Text, txtChe3Hasta);
                txtUltiChe3.Text = txtChe3Desde.Text;
            }
            else
            {
                txtChe3Hasta.Text = "0";
                txtChe3Desde.Text = "0";
                txtUltiChe3.Text = "0";
                txtChe3Cant.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbxBanco = lbxBancos.DefInstance;
            lbxBanco.destino(this, "CuentasBancarias");
            lbxBanco.Show();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            //compania.obtenerCodigoCompaniaActual();
            //planCuentaLbx = lbxPlanCuentas.DefInstance;
            //planCuentaLbx.soloVista(this, this.Name, compania.BaseDatosActual);
            //planCuentaLbx.Show();
        }

        private void buscarVerificarPlanC()
        {
            if (txtCuenta.Text != "")
            {
                txtAuxiliar.Text = "";
                au.CodigoPlanCuentas = txtCuenta.Text;

                if (au.validarPlanCuenta(10, "01"))
                {
                    lblDescripcionCuenta.Text = au.getDescripcionPlanC(au.CodigoPlanCuentas, "01");
                    if (au.poseeAuxilar("01", au.CodigoPlanCuentas))
                    {
                        btnAuxiliar.Enabled = true;
                        txtAuxiliar.Enabled = true;
                        txtAuxiliar.Focus();
                    }
                    else
                    {
                        btnAuxiliar.Enabled = false;
                        txtAuxiliar.Enabled = false;
                    }

                }
                else
                {
                    MessageBox.Show("El numero de cuenta ingresado no existe", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDescripcionCuenta.Text = "";
                    txtCuenta.Text = "";
                    txtAuxiliar.Text = "";

                    //guard2 = false;
                    txtCuenta.Focus();
                }
            }
        }

        private void txtCuenta_Leave(object sender, EventArgs e)
        {
            buscarVerificarPlanC();
        }

        private void txtAuxiliar_Leave(object sender, EventArgs e)
        {
            compania.obtenerCodigoCompaniaActual();
            if (txtAuxiliar.Text != "")
            {
                if (!au.permisoAuxiliar(txtCuenta.Text, txtAuxiliar.Text, compania.BaseDatosActual))
                {
                    MessageBox.Show("El auxiliar seleccionado no existe", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuxiliar.Text = "";
                }
            }
        }

        private void btnAuxiliar_Click(object sender, EventArgs e)
        {
            if (txtCuenta.Text != "")
            {
                //auxiliar = lbxAuxiliaresOnly.DefInstance;
                //auxiliar.destino(this, this.Name);
                //auxiliar.codCuenta(txtCuenta.Text);
                ////auxiliar.llenarAuxiliares();
                //auxiliar.Show();
                //auxiliar.llenarAuxiliares();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una cuenta antes de elegir un auxiliar", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBanco_Leave(object sender, EventArgs e)
        {

            if (txtBanco.Text != "")
            {
                tabla.Clear();
                tabla.Reset();

                tabla = banco.armarDatosBanco(txtBanco.Text);

                if (tabla.Rows.Count > 0)
                {
                    if (tabla.Rows[0][5].ToString() == "Activo")
                    {
                        lblNombreBanco.Text = tabla.Rows[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El banco " + tabla.Rows[0][1].ToString() + " está inactivo", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBanco.Text = "";
                        lblNombreBanco.Text = "";
                        txtBanco.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El codigo del banco ingresado no existe", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBanco.Text = "";
                    txtBanco.Focus();
                }
            }
        }

        private bool validandoCampos()
        {
            if (txtBanco.Text == "") {

                MessageBox.Show("El campo codigo del banco no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBanco.Focus();
                return false;
            }

            if (txtTitular.Text == "")
            {
                MessageBox.Show("El campo titular no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitular.Focus();
                return false;
            }

            if (cmbTipCuenta.Text == "")
            {

                MessageBox.Show("El tipo de cuenta no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNumeroCuentaBan.Text == "")
            {

                MessageBox.Show("El numero de la cuenta no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroCuentaBan.Focus();
                return false;
            }

            if (txtDivisa.Text == "")
            {
                MessageBox.Show("La divisa no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDivisa.Focus();
                return false;
            }

            if (txtSucursal.Text == "")
            {
                MessageBox.Show("La sucursal no debe quedar vacio", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSucursal.Focus();
                return false;
            }

            return true;

        }

        private void armarDTChequera() {

            tablaChequera.Reset();
            tablaChequera.Clear();

            tablaChequera.Columns.Add("codigoBanco");              //0
            tablaChequera.Columns.Add("titular");                  //1
            tablaChequera.Columns.Add("descripcion");              //2
            tablaChequera.Columns.Add("tipoCuenta");               //3
            tablaChequera.Columns.Add("numeroCuenta");             //4
            tablaChequera.Columns.Add("divisa");                   //5
            tablaChequera.Columns.Add("sucursal");                 //6
            tablaChequera.Columns.Add("cuentaContable");           //7
            tablaChequera.Columns.Add("auxiliarContable");         //8
            tablaChequera.Columns.Add("idbDesde");                 //9
            tablaChequera.Columns.Add("idbhasta");                 //10
            tablaChequera.Columns.Add("porcIdb");                  //11
            tablaChequera.Columns.Add("che1Desde");                //12
            tablaChequera.Columns.Add("che1Hasta");                //13
            tablaChequera.Columns.Add("che1Cant");                 //14
            tablaChequera.Columns.Add("che2Desde");                //15
            tablaChequera.Columns.Add("che2Hasta");                //16
            tablaChequera.Columns.Add("che2Cant");                 //17
            tablaChequera.Columns.Add("che3Desde");                //18
            tablaChequera.Columns.Add("che3Hasta");                //19
            tablaChequera.Columns.Add("che3Cant");                 //20
            tablaChequera.Columns.Add("ultChe1");                  //21
            tablaChequera.Columns.Add("ultChe2");                  //22
            tablaChequera.Columns.Add("ultChe3");                  //23
            tablaChequera.Columns.Add("chequeraActiva");           //24
            tablaChequera.Columns.Add("cuentaActiva");             //25
            tablaChequera.Columns.Add("deposito");                 //26
            tablaChequera.Columns.Add("pago");                     //27
            tablaChequera.Columns.Add("itf");                      //28
            tablaChequera.Columns.Add("consecutivoCheque");        //29
            tablaChequera.Columns.Add("nombreBanco");              //30

        }

        private DataTable contenidoDTChequeras() {


            DataRow fila = tablaChequera.NewRow();

            fila[0] = txtBanco.Text;
            fila[1] = txtTitular.Text;
            fila[2] = txtDescripcion.Text;
            fila[3] = cmbTipCuenta.Text;
            fila[4] = txtNumeroCuentaBan.Text;
            fila[5] = txtDivisa.Text;
            fila[6] = txtSucursal.Text;
            fila[7] = txtCuenta.Text;
            fila[8] = txtAuxiliar.Text;
            fila[9] = txtIDBdesde.Text.Replace(",", ".");
            fila[10] = txtIDBHasta.Text.Replace(",", ".");
            fila[11] = txtPorcIDB.Text.Replace(",", ".");
            fila[12] = txtChe1Desde.Text;
            fila[13] = txtChe1Hasta.Text;
            fila[14] = txtChe1Cant.Text;
            fila[15] = txtChe2Desde.Text;
            fila[16] = txtChe2Hasta.Text;
            fila[17] = txtChe2Cant.Text;
            fila[18] = txtChe3Desde.Text;
            fila[19] = txtChe3Hasta.Text;
            fila[20] = txtChe3Cant.Text;
            fila[21] = txtUltiChe1.Text;
            fila[22] = txtUltiChe2.Text;
            fila[23] = txtUltiChe3.Text;
            fila[24] = cmbChequeraAct.Text;

            if (checkedListBox1.GetItemCheckState(0).ToString() == "Checked")
            {
                fila[25] = "Sí";
            }
            else
            {
                fila[25] = "No";
            }

            if (checkedListBox1.GetItemCheckState(1).ToString() == "Checked")
            {
                fila[26] = "1";
            }
            else
            {
                fila[26] = "0";
            }

            if (checkedListBox1.GetItemCheckState(2).ToString() == "Checked")
            {
                fila[27] = "1";
            }
            else
            {
                fila[27] = "0";
            }

            if (checkedListBox1.GetItemCheckState(3).ToString() == "Checked")
            {
                fila[28] = "1";
            }
            else
            {
                fila[28] = "0";
            }

            if (checkedListBox1.GetItemCheckState(4).ToString() == "Checked")
            {
                fila[29] = "1";
            }
            else
            {
                fila[29] = "0";
            }

            fila[30] = lblNombreBanco.Text;

            tablaChequera.Rows.Add(fila);

            return tablaChequera;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (accion == "registro")
            {
                if (validandoCampos() && validarActivacionChequera())
                {
                    armarDTChequera();
                    contenidoDTChequeras();
                    banco.insertarNuevaCuentaBanc(tablaChequera,txtIDB.Text);
                    lbxCuentasBan = new lbxCuentasBanc();
                    lbxCuentasBan.Show();
                    this.Close();
                }
            }

            if (accion == "modificar")
            {
                if (validandoCampos() && validarActivacionChequera())
                {
                    armarDTChequera();
                    contenidoDTChequeras();
                    banco.modificarCuentaBanc(tablaChequera,txtIDB.Text);
                    lbxCuentasBan = new lbxCuentasBanc();
                    lbxCuentasBan.Show();
                    this.Close();
                }
            }

        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.onlyNumberWithTab(sender, e);
        }

        private void cmbTipCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumeroCuentaBan.Focus();
            }
            else {
                e.Handled = true;
            }
        }

        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.tab(sender, e);
        }

        private void txtIDBdesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.conDecimalesDefinidos(sender, e, txtIDBdesde, 2);
        }

        private void txtIDBHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.conDecimalesDefinidos(sender, e, txtIDBHasta, 2);
        }

        private void txtPorcIDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.conDecimalesDefinidos(sender, e, txtPorcIDB, 3);
            if (e.KeyChar == 13) { groupBox3.Focus(); }
        }

        private void txtChe1Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.onlyNumberWithTab(sender, e);
        }

        private void cmbChequeraAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAceptar.Focus();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cargarModificacion() {

            tabla = banco.armarModificacion(bancoM, titularM, tipoM, numeroCuentaM);

            txtBanco.Text = tabla.Rows[0]["ctas_banco"].ToString();
            txtTitular.Text = tabla.Rows[0]["ctas_tirular"].ToString();
            txtDescripcion.Text = tabla.Rows[0]["ctas_descrip"].ToString();
            cmbTipCuenta.Text = tabla.Rows[0]["ctas_tipo"].ToString();
            txtNumeroCuentaBan.Text = tabla.Rows[0]["ctas_numero"].ToString();
            txtDivisa.Text = tabla.Rows[0]["ctas_divisa"].ToString();
            txtSucursal.Text = tabla.Rows[0]["ctas_sucursal"].ToString();
            txtCuenta.Text = tabla.Rows[0]["ctas_pagCheque"].ToString();
            txtAuxiliar.Text = tabla.Rows[0]["ctas_contable3"].ToString();
            txtIDBdesde.Text = tabla.Rows[0]["desdeIDB"].ToString();
            txtIDBHasta.Text = tabla.Rows[0]["hastaIDB"].ToString();
            txtPorcIDB.Text = tabla.Rows[0]["porcIDB"].ToString();
            txtChe1Desde.Text = tabla.Rows[0]["ctas_cheIni1"].ToString();
            txtChe1Hasta.Text = tabla.Rows[0]["ctas_cheFin1"].ToString();
            txtChe1Cant.Text = tabla.Rows[0]["ctas_numChe1"].ToString();
            txtChe2Desde.Text = tabla.Rows[0]["ctas_cheIni2"].ToString();
            txtChe2Hasta.Text = tabla.Rows[0]["ctas_cheFin2"].ToString();
            txtChe2Cant.Text = tabla.Rows[0]["ctas_numChe2"].ToString();
            txtChe3Desde.Text = tabla.Rows[0]["ctas_cheIni3"].ToString();
            txtChe3Hasta.Text = tabla.Rows[0]["ctas_cheFin3"].ToString();
            txtChe3Cant.Text = tabla.Rows[0]["ctas_numChe3"].ToString();
            txtUltiChe1.Text = tabla.Rows[0]["ctas_ultCheque"].ToString();
            txtUltiChe2.Text = tabla.Rows[0]["ctas_ultCheque2"].ToString();
            txtUltiChe3.Text = tabla.Rows[0]["ctas_ultCheque3"].ToString();
            cmbChequeraAct.Text = tabla.Rows[0]["ctas_CheActiva"].ToString();
            lblNombreBanco.Text = tabla.Rows[0]["ctas_nomban"].ToString();
            txtIDB.Text = tabla.Rows[0]["ctas_contable4"].ToString();


            if (tabla.Rows[0]["ctas_activa"].ToString() == "Sí")
            {
                checkedListBox1.SetItemChecked(0, true);
            }

            if (tabla.Rows[0]["ctas_depositos"].ToString() == "1")
            {
                checkedListBox1.SetItemChecked(1, true);
            }

            if (tabla.Rows[0]["ctas_pagos"].ToString() == "1")
            {
                checkedListBox1.SetItemChecked(2, true);
            }

            if (tabla.Rows[0]["ctas_itf"].ToString() == "1")
            {
                checkedListBox1.SetItemChecked(3, true);
            }

            if (tabla.Rows[0]["ctas_cheqauto"].ToString() == "1")
            {
                checkedListBox1.SetItemChecked(4, true);
            }


        
        }

        private bool validarActivacionChequera()
        {
            if (Convert.ToInt64(txtChe1Hasta.Text) == 0 && Convert.ToInt64(cmbChequeraAct.Text) == 1)
            {
                cmbChequeraAct.Text = "0";
                MessageBox.Show("No se puede activar chequera 1, No existen cheques cargados", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToInt64(txtChe2Hasta.Text) == 0 && Convert.ToInt64(cmbChequeraAct.Text) == 2)
            {
                cmbChequeraAct.Text = "0";
                MessageBox.Show("No se puede activar chequera 2, No existen cheques cargados", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToInt64(txtChe3Hasta.Text) == 0 && Convert.ToInt64(cmbChequeraAct.Text) == 3)
            {
                cmbChequeraAct.Text = "0";
                MessageBox.Show("No se puede activar chequera 3, No existen cheques cargados", "Algo no esta bien ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void cmbTipCuenta_Leave(object sender, EventArgs e)
        {
            if (cmbTipCuenta.Text == "Corriente")
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void cmbTipCuenta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipCuenta.Text == "Corriente")
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void txtIDBdesde_Leave(object sender, EventArgs e)
        {
            if (txtIDBdesde.Text == "")
            {
                txtIDBdesde.Text = "0";
            }
        }

        private void txtIDBHasta_Leave(object sender, EventArgs e)
        {
            if (txtIDBHasta.Text == "")
            {
                txtIDBHasta.Text = "0";
            }
        }

        private void txtPorcIDB_Leave(object sender, EventArgs e)
        {
            if (txtPorcIDB.Text == "")
            {
                txtPorcIDB.Text = "0";
            }
        }

    
        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            //if (checkedListBox1.GetItemCheckState(4).ToString() == "Checked")
            //{
            //    txtIDB.ReadOnly = true;
            //}
            //else if (checkedListBox1.GetItemCheckState(4).ToString() != "Checked") 
            //{
            //    txtIDB.ReadOnly = false;
            //}
            //else
            //{
            //    txtIDB.ReadOnly = true;
            ////}
            //string listChest;
            //if (checkedListBox1.GetItemCheckState(4).ToString() == "Checked")
            //{
            //    foreach (string s in checkedListBox1.CheckedItems)
            //    {
            //        listChest = s;
            //        if (listChest == "Calcula Debito Bancario")
            //        {
            //            txtIDB.ReadOnly = false;
            //        }
            //    }
            //}
            //else
            //{
            //    txtIDB.ReadOnly = true;
            //}
            
        }

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            string listChest;
            if (checkedListBox1.GetItemCheckState(4).ToString() == "Checked")
            {
                foreach (string s in checkedListBox1.CheckedItems)
                {
                    listChest = s;
                    if (listChest == "Calcula Debito Bancario")
                    {
                        txtIDB.ReadOnly = false;
                    }
                }
            }
            else
            {
                txtIDB.ReadOnly = true;
                txtIDB.Clear();
            }
        }

        private void txtIDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        






    }
}
