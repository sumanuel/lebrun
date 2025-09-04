using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.formularios.vendedores;
using lebrun.clases.clientes;
using lebrun.clasesData;
using lebrun.clases.contabilidad;
using lebrun.clases.vendedores;
using lebrun.clases.complementos;
namespace lebrun.formularios.clientes
{
    public partial class frmClientes : Form
    {
        private static frmClientes m_FormDefInstance;
        private lbxVendedores lbxVen1;
        private Clientes cli1;
        private AuxiliarContable auCliente;
        private Vendedor clieVendedor;
        private FuncionesTexbox funtxt;
        private Vendedor vende1;
        private bool modificar;
        private TipoNegocio tipoN;
        private Principal referenciaPrincipal;
        private CondicionPago condicion_pago;

        public frmClientes()
        {
            InitializeComponent();
        }

        public static frmClientes DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmClientes();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

     
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if (validarCampos()) {
                letraDuplicada();
                asignarCampos();
                if (cli1.existeCliente())
                {
                    MessageBox.Show("El Cliente existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    if (cli1.ingresarCliente()) {
                        MessageBox.Show("Cliente Guardado Exitosamente!!", "Exito!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarBasico();
                    }
                }
            }
        }

        public bool validarCampos()
        {
            bool centinela = true;

            if (txtRif.Text == "")
            {

                MessageBox.Show("El RIF es un campo Obligatorio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRif.Focus();
                centinela = false;
                return centinela;
            }

            if (txtRazonSocial.Text == "")
            {
                MessageBox.Show("La Razón Social es un campo Obligatorio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazonSocial.Focus();
                centinela = false;
                return centinela;
            }

            if (txtDireccion.Text == "")
            {
                MessageBox.Show("La Dirección es un campo Obligatorio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                centinela = false;
                return centinela;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("El Telefono es un campo Obligatorio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                centinela = false;
                return centinela;
            }


            if (txtVendedor.Text == "")
            {
                MessageBox.Show("El Vendedor es un campo Obligatorio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendedor.Focus();
                centinela = false;
                return centinela;
            }

            ////letra = txtRif.Text[0].ToString().ToUpper();
            ////if ((letra.Equals("J")) && !(cboTipoPersona.Text.Equals("Juridica"))) {
            ////    MessageBox.Show("El Tipo de Persona debe seleccionar Juridico!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    cboTipoPersona.Focus();
            ////    centinela = false;
            ////    return centinela;
            ////}

            ////if (((letra.Equals("V")) || (letra.Equals("E")) || (letra.Equals("P"))) && !(cboTipoPersona.Text.Equals("Natural")))
            ////{
            ////    MessageBox.Show("El Tipo de Persona debe seleccionar Natural!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    cboTipoPersona.Focus();
            ////    centinela = false;
            ////    return centinela;
            ////}

            ////if ((letra.Equals("G")) && !(cboTipoPersona.Text.Equals("Gubernamental")))
            ////{
            ////    MessageBox.Show("El Tipo de Persona debe seleccionar Gubernamental!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    cboTipoPersona.Focus();
            ////    centinela = false;
            ////    return centinela;
            ////}

            return centinela;
        }

        public void letraDuplicada()
        {
            int V = 0;
            int J = 0;
            int G = 0;
            int E = 0;
            int P = 0;
            if (txtRif.Text != "")
            {
                string rifComp = txtRif.Text;
                for (int i = 0; i < rifComp.Length; i++)
                {
                    string temp = rifComp.Substring(i, 1);
                    if (rifComp.Substring(i, 1).Equals("V"))
                    {
                        V = V + 1;
                    }
                    if (rifComp.Substring(i, 1).Equals("J"))
                    {
                        J = J + 1;
                    }
                    if (rifComp.Substring(i, 1).Equals("G"))
                    {
                        G = G + 1;
                    }
                    if (rifComp.Substring(i, 1).Equals("E"))
                    {
                        E = E + 1;
                    }
                    if (rifComp.Substring(i, 1).Equals("P"))
                    {
                        P = P + 1;
                    }
                }
                if (V >= 2)
                {
                    rifComp = rifComp.ToUpper().Replace("V", "");
                    rifComp = "V" + rifComp;
                    txtRif.Text = "";
                    txtRif.Text = rifComp;
                    txtRif_Leave(new object(), new EventArgs());
                }
                if (J >= 2)
                {
                    rifComp = rifComp.ToUpper().Replace("J", "");
                    rifComp = "J" + rifComp;
                    txtRif.Text = "";
                    txtRif.Text = rifComp;
                    txtRif_Leave(new object(), new EventArgs());
                }
                if (G >= 2)
                {
                    rifComp = rifComp.ToUpper().Replace("G", "");
                    rifComp = "G" + rifComp;
                    txtRif.Text = "";
                    txtRif.Text = rifComp;
                    txtRif_Leave(new object(), new EventArgs());
                }
                if (E >= 2)
                {
                    rifComp = rifComp.ToUpper().Replace("E", "");
                    rifComp = "E" + rifComp;
                    txtRif.Text = "";
                    txtRif.Text = rifComp;
                    txtRif_Leave(new object(), new EventArgs());
                }
                if (P >= 2)
                {
                    rifComp = rifComp.ToUpper().Replace("P", "");
                    rifComp = "P" + rifComp;
                    txtRif.Text = "";
                    txtRif.Text = rifComp;
                    txtRif_Leave(new object(), new EventArgs());
                }
            }

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRif.Text.Length == 0)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    if (!((e.KeyChar.ToString().ToUpper().Equals("J")) || (e.KeyChar.ToString().ToUpper().Equals("G")) || (e.KeyChar.ToString().ToUpper().Equals("V")) || (e.KeyChar.ToString().ToUpper().Equals("E")) || (e.KeyChar.ToString().ToUpper().Equals("P"))))
                    {
                        MessageBox.Show("El RIF debe empezar con J,G,V,E,P!!", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRif.Focus();
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("El RIF debe empezar con J,G,V,E,P!!", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRif.Focus();
                    e.Handled = true;
                }
            }
            else
            {
                if ((txtRif.Text[0].ToString().ToUpper().Equals("J")) || (txtRif.Text[0].ToString().ToUpper().Equals("G")) || (txtRif.Text[0].ToString().ToUpper().Equals("V")) || (txtRif.Text[0].ToString().ToUpper().Equals("E")) || (txtRif.Text[0].ToString().ToUpper().Equals("P")))
                {
                    if ((char.IsLetter(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                    if (char.IsSymbol(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    if (char.IsPunctuation(e.KeyChar)) { e.Handled = true; }
                }
                else
                {
                    if ((!((e.KeyChar.ToString().ToUpper().Equals("J")) || (e.KeyChar.ToString().ToUpper().Equals("G")) || (e.KeyChar.ToString().ToUpper().Equals("V")) || (e.KeyChar.ToString().ToUpper().Equals("E")) || (e.KeyChar.ToString().ToUpper().Equals("P")))))
                    {
                        MessageBox.Show("El RIF debe empezar con J,G,V,E,P!!", "Advertencia ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRif.Focus();
                        e.Handled = true;
                    }
                }
            }

            if ((e.KeyChar == (char)(Keys.Enter)) && (txtRif.Text.Length > 0))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void txtRif_Leave(object sender, EventArgs e)
        {
            txtRif.Text = txtRif.Text.ToUpper();

            if (modificar == false)
            {
                if (txtRif.Text.Length > 0)
                {
                    char[] rif;
                    rif = txtRif.Text.ToCharArray();
                    int diferencia = 0;
                    int longitud = txtRif.Text.Length;
                    diferencia = 11 - longitud;
                    txtRif.Text = null;
                    txtRif.Text = rif[0].ToString();
                    for (int i = 1; i < diferencia; i++)
                    {
                        txtRif.Text = txtRif.Text + "0";
                    }
                    for (int x = 1; x < rif.Length; x++)
                    {
                        txtRif.Text = txtRif.Text + rif[x].ToString();
                    }
                    txtCodigoCliente.Text = txtRif.Text.ToUpper();
                }
            }
        }



        private void MyTextBox_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsPunctuation(e.KeyChar)) { e.Handled = true;}
            if ((e.KeyChar == (char)(Keys.Enter)))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }

        }

        private void cmdBuscarVendedor_Click(object sender, EventArgs e)
        {
            lbxVen1 = lbxVendedores.DefInstance;
            lbxVen1.Show();
            lbxVen1.venSoloVista(this);
        }

        private void cmdBuscarCobrador_Click(object sender, EventArgs e)
        {
            lbxVen1 = lbxVendedores.DefInstance;
            lbxVen1.Show();
            lbxVen1.venSoloVista(this, 1);
        }

        public void asignarCampos()
        {
            cli1.Rif = txtRif.Text.ToUpper();
            if (modificar == true)
            {
                cli1.Codigo = txtCodigoCliente.Text.ToUpper();
            }
            else
            {
                cli1.Codigo = txtRif.Text.ToUpper();
            }
            cli1.Nombre = txtRazonSocial.Text;
            cli1.Direccion = txtDireccion.Text;
            cli1.Vendedor = txtVendedor.Text;
            cli1.Telefono = txtTelefono.Text;
            cli1.FechaInicioVaca = "" + dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            cli1.FechaFinVaca = "" + dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
            if ((cli1.Rif.Substring(0, 1).Equals("V")) || cli1.Rif.Substring(0, 1).Equals("E") || cli1.Rif.Substring(0, 1).Equals("P"))
            {
                cli1.TipoPersona = "Natural";
            }
            if ((cli1.Rif.Substring(0, 1).Equals("J")))
            {
                cli1.TipoPersona = "Juridica";
            }
            if ((cli1.Rif.Substring(0, 1).Equals("G")))
            {
                cli1.TipoPersona = "Gubernamental";
            }
            cli1.TipoLista = cboLista.SelectedValue.ToString();
            //los siguientes campos se tiene que validar porque no se llenan y si se llenan se coloca tal valor
            //Operardor ternario
            cli1.Nif = (txtNif.Text == "") ? "" : txtNif.Text;
            cli1.Representante = (txtRepresentante.Text == "") ? "" : txtRepresentante.Text;
            cli1.Direccion2 = (txtDireccion2.Text == "") ? "" : txtDireccion2.Text;
            cli1.DireccionEnvio = (txtDireccion3.Text == "") ? "" : txtDireccion3.Text;
            cli1.ZonaGeografica = (cboGeografica.Text == "") ? "" : cboGeografica.Text;
            cli1.ZonaPostal = (txtZonaPostal.Text == "") ? 0 : (Convert.ToInt32(txtZonaPostal.Text));
            cli1.Fax = (txtFax.Text == "") ? "" : txtFax.Text;
            cli1.Email = (txtEmail.Text == "") ? "" : txtEmail.Text;
            cli1.TipoNegocio = cboTipoNegocio.SelectedValue.ToString();
            cli1.Transporte = (cboTransporte.Text == "") ? "" : cboTransporte.Text;
            cli1.ComisionVen = (txtComisionVen.Text == "") ? 0 : Convert.ToDecimal(txtComisionVen.Text);
            cli1.Cobrador = (txtCobrador.Text == "") ? "" : txtCobrador.Text;
            cli1.ComisionCobrador = (txtComisionCobr.Text == "") ? 0 : Convert.ToDecimal(txtComisionCobr.Text);
            cli1.DiaCobro = (txtDiaCobro.Text == "") ? 0 : Convert.ToInt32(txtDiaCobro.Text);
            cli1.ClientePlanC = (txtPlanCuentas.Text == "") ? "" : txtPlanCuentas.Text;
            cli1.ClienteAuxiliar = (txtAuxiliar.Text == "") ? "" : txtAuxiliar.Text;
            cli1.Observaciones = (txtObservaciones.Text == "") ? "" : txtObservaciones.Text;
            cli1.Situacion = cboSituacion.Text;
            //cli1.CondicionPago = cboCondicionPago.Text;
            if (referenciaPrincipal.empresaActual.Rif.Equals("J003680290"))//rif ferle
            {
                cli1.CondicionPago = cboCPFerle.SelectedValue.ToString();
            }
            else
            {
                cli1.CondicionPago = cboCondicionPago.Text;
            }
            cli1.DescuentoEnventas = (txtDescuentoVentas.Text == "") ? 0 : Convert.ToDecimal(txtDescuentoVentas.Text.Replace(".", ","));
            cli1.descuento2 = (txtDescuento2.Text == "") ? 0 : Convert.ToDecimal((txtDescuento2.Text.Replace(".", ",")));
            cli1.descuento3 = (txtDescuento3.Text == "") ? 0 : Convert.ToDecimal(txtDescuento3.Text.Replace(".", ","));
            cli1.Contribuyente = comboBox1.Text;
            cli1.limiteCredito = string.IsNullOrEmpty(txtLimiteCredito.Text) ? 0 : Convert.ToDecimal(txtLimiteCredito.Text.Replace(".", ","));

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cli1 = new Clientes("200");
            auCliente = new AuxiliarContable();
            llenarPrecioLista();
            clieVendedor = new Vendedor();
            combosBasicos();
            funtxt = new FuncionesTexbox();
            vende1 = new Vendedor();
            tipoN = new TipoNegocio();
            cargarCombo();
            referenciaPrincipal = (Principal)this.MdiParent;
            condicion_pago = new CondicionPago();
            cboCPFerle.DataSource = condicion_pago.lbxCondPag();
            cboCPFerle.DisplayMember = "conp_descripcion";
            cboCPFerle.ValueMember = "conp_codigo";
            cboCPFerle.SelectedIndex = 14;
        }

        private void limpiarBasico() { 
                txtRif.Clear();
                txtNif.Clear();
                txtCodigoCliente.Clear();
                txtCodigoCliente.Text= "Codigo";
                txtRazonSocial.Clear();
                txtRepresentante.Clear();
                txtDireccion.Clear();
                txtDireccion2.Clear();
                txtDireccion3.Clear();
                txtZonaPostal.Clear();
                txtTelefono.Clear();
                txtFax.Clear();
                txtEmail.Clear();
                txtVendedor.Clear();
                txtNombreVendedor.Clear();
                txtNombreVendedor.Text= "Nombre Vendedor";
                txtComisionVen.Clear();
                txtCobrador.Clear();
                txtNombreCobrador.Clear();
                txtNombreCobrador.Text= "Nombre Cobrador";
                txtComisionCobr.Clear();
                txtDiaCobro.Clear();
                txtPlanCuentas.Clear();
                txtNombreCuenta.Clear(); 
                txtNombreCuenta.Text= "Nombre Plan Cuenta";
                txtAuxiliar.Clear();
                txtNombreAuxiliar.Clear();
                txtNombreAuxiliar.Text = "Nombre Auxiliar";
                cboLista.SelectedIndex = 0;
                txtObservaciones.Clear();
                cboCondicionPago.SelectedIndex = 0;
                cboSituacion.SelectedIndex = 0;
                cboTipoPersona.SelectedIndex = 0;
                txtDescuentoVentas.Clear();
                comboBox1.SelectedIndex = 0;
                cboCPFerle.SelectedIndex = 14;
        }


        public void llenarPrecioLista() {
            cboLista.DataSource = cli1.precioCliente();
            cboLista.ValueMember = "ttp_codigo";
            cboLista.DisplayMember = "ttp_codigo";
            cboLista.SelectedIndex = 0;
            
        }

        private void txtComisionVen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtCobrador.Focus();
                return;
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                if (existeCaracter(txtComisionVen.Text))
                {
                    e.Handled = true;
                    return;
                }
            }

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtComisionVen.Text.Length; i++)
            {
                if ((txtComisionVen.Text[i] == '.') || (txtComisionVen.Text[i] == ','))
                    IsDec = true;


                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void txtComisionCobr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                return;
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                if (existeCaracter(txtComisionCobr.Text))
                {
                    e.Handled = true;
                    return;
                }
            }

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtComisionCobr.Text.Length; i++)
            {
                if ((txtComisionCobr.Text[i] == '.') || (txtComisionCobr.Text[i] == ','))
                    IsDec = true;


                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

        }
        

        private Boolean existeCaracter(string cadena)
        {
            int i;
            int contador = 1;
            Boolean centinela = false;
            for (i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i] == ',') || (cadena[i] == '.'))
                {
                    contador = contador + 1;
                    if (contador > 1)
                    {
                        centinela = true;
                        break;
                    }

                }
            }
            return centinela;
        }

        public void agregar(bool value) {
            cmdAgregar.Enabled = value;
            cmdModificar.Enabled = !value;
        }

        public void cargarDatosModificar(string codigoClie)
        {
            DateTime fechaTemp;
            cli1.Codigo = codigoClie;
            modificar = true;
            if (cli1.existeCliente())
            {
                cli1.cargarDatosCliente();
                txtRif.Text = cli1.Rif;
                txtNif.Text = cli1.Nif;
                //cboTipoPersona.SelectedIndex = cboTipoPersona.FindString(cli1.TipoPersona);
                txtCodigoCliente.Text = cli1.Codigo;
                txtRazonSocial.Text = cli1.Nombre;
                txtRepresentante.Text = cli1.Representante;
                txtDireccion.Text = cli1.Direccion;
                txtDireccion2.Text = cli1.Direccion2;
                txtDireccion3.Text = cli1.DireccionEnvio;
                //cboGeografica.Text = cli1.ZonaGeografica;
                txtZonaPostal.Text = Convert.ToString(cli1.ZonaPostal);
                txtTelefono.Text = cli1.Telefono;
                txtFax.Text = cli1.Fax;
                txtEmail.Text = cli1.Email;
                //cboTipoNegocio.Text = cli1.TipoNegocio;
                //cboTransporte.Text = cli1.Transporte;
                txtVendedor.Text = cli1.Vendedor;
                //funcion para nombre 
                txtComisionVen.Text = Convert.ToString(cli1.ComisionVen);
                txtCobrador.Text = cli1.Cobrador;
                txtComisionCobr.Text = Convert.ToString(cli1.ComisionCobrador);
                txtDiaCobro.Text = Convert.ToString(cli1.DiaCobro);
                //cboLista
                //dateTimePicker1
                //dateTimePicker2
                txtPlanCuentas.Text = cli1.ClientePlanC;
                if (cli1.ClientePlanC != "")
                {
                    txtNombreCuenta.Text = auCliente.getDescripcionPlanC(cli1.ClientePlanC, "01");
                }
                txtAuxiliar.Text = cli1.ClienteAuxiliar;
                if (cli1.ClienteAuxiliar != "")
                {
                    txtNombreAuxiliar.Text = auCliente.getDescripcionAuxiliar(cli1.ClientePlanC, cli1.ClienteAuxiliar, "01");
                }
                txtVendedor.Text = cli1.Vendedor;
                if (cli1.Vendedor != "")
                {
                    txtNombreVendedor.Text = clieVendedor.getNombreVen(cli1.Vendedor);
                }
                txtCobrador.Text = cli1.Cobrador;
                if (cli1.Cobrador != "")
                {
                    txtNombreCobrador.Text = clieVendedor.getNombreVen(cli1.Cobrador);
                }
                if (cli1.TipoLista != "")
                {
                    cboLista.SelectedIndex = cboLista.FindString(cli1.TipoLista);
                }
                if (cli1.FechaInicioVaca != "")
                {
                    fechaTemp = Convert.ToDateTime(cli1.FechaInicioVaca);
                    dateTimePicker1.Value = fechaTemp;
                }
                if (cli1.FechaFinVaca != "")
                {
                    fechaTemp = Convert.ToDateTime(cli1.FechaFinVaca);
                    dateTimePicker2.Value = fechaTemp;
                }
                if (cli1.Observaciones != "")
                {
                    txtObservaciones.Text = cli1.Observaciones;
                }
                if (cli1.Situacion != "")
                {
                    cboSituacion.SelectedIndex = cboSituacion.FindString(cli1.Situacion);
                }
                //if (cli1.CondicionPago != "")
                //{
                //    cboCondicionPago.SelectedIndex = cboCondicionPago.FindString(cli1.CondicionPago);
                //}
                if (cli1.CondicionPago != "")
                {
                    if (referenciaPrincipal.empresaActual.Rif.Equals("J003680290"))//rif ferle
                    {
                        cboCPFerle.SelectedValue = cli1.CondicionPago;
                    }
                    else
                    {
                        cboCondicionPago.SelectedValue = cli1.CondicionPago;
                    }
                }
                if (cli1.DescuentoEnventas != null)
                {
                    txtDescuentoVentas.Text = "" + cli1.DescuentoEnventas;
                }

                if ((cli1.Contribuyente.ToUpper().Equals("SI")) || (cli1.Contribuyente.ToUpper().Equals("SÍ")))
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }

                if ((String.IsNullOrEmpty(cli1.idTipoNegocio)))
                {
                    cboTipoNegocio.SelectedIndex = 0;
                }
                else
                {
                    for (int i = 0; i < cboTipoNegocio.Items.Count; i++)
                    {
                        cboTipoNegocio.SelectedIndex = i;
                        if (cboTipoNegocio.SelectedValue.ToString().Equals(cli1.idTipoNegocio))
                        {
                            cboTipoNegocio.SelectedIndex = i;
                            break;
                        }
                    }
                }
                if (cli1.descuento2 != null)
                {
                    txtDescuento2.Text = "" + cli1.descuento2;
                }
                if (cli1.descuento3 != null)
                {
                    txtDescuento3.Text = "" + cli1.descuento3;
                }
                if (cli1.limiteCredito != null)
                {
                    txtLimiteCredito.Text = "" + cli1.limiteCredito;
                }
            }
            else
            {
                MessageBox.Show("El Cliente No existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                asignarCampos();
                if (cli1.existeCliente())
                {
                    if (cli1.modificarCliente())
                    {
                        MessageBox.Show("Cliente Guardado Exitosamente!!", "Exito!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarBasico();
                        modificar = false;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error al modificar Cliente!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Cliente No existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void combosBasicos() {
            cboCondicionPago.Items.Add("Contado");
            cboCondicionPago.Items.Add("Crédito");
            cboSituacion.Items.Add("Activo");
            cboSituacion.Items.Add("Inactivo");
            cboSituacion.Items.Add("En Proceso");
            cboSituacion.Items.Add("Suspendido");
            cboTipoPersona.Items.Add("Natural");
            cboTipoPersona.Items.Add("Gubernamental");
            cboTipoPersona.Items.Add("Juridica");

            cboCondicionPago.SelectedIndex = 0;
            cboSituacion.SelectedIndex = 0;
            cboTipoPersona.SelectedIndex = 0;
        }

        private void txtDescuentoVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            funtxt.conDecimalesDefinidos(sender, e, a, 2);

        }

        private void cboTipoPersona_Leave(object sender, EventArgs e)
        {
            //para que respete los codigos generados anteriormente y no de erro en modificar
            if (txtCodigoCliente.Text.Equals("Codigo"))
            {
                string letra;
                if (txtRif.Text != "")
                {
                    txtRif.Text = txtRif.Text.ToUpper();
                }

                if (txtRif.Text != "")
                {
                    letra = txtRif.Text[0].ToString().ToUpper();

                    if ((letra.Equals("J")) && !(cboTipoPersona.Text.Equals("Juridica")))
                    {
                        MessageBox.Show("El Tipo de Persona debe seleccionar Juridico!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboTipoPersona.Focus();
                    }
                    else
                    {
                        txtCodigoCliente.Text = txtRif.Text;
                        return;
                    }

                    if (((letra.Equals("V")) || (letra.Equals("E")) || (letra.Equals("P"))) && !(cboTipoPersona.Text.Equals("Natural")))
                    {
                        MessageBox.Show("El Tipo de Persona debe seleccionar Natural!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboTipoPersona.Focus();
                    }
                    else
                    {
                        txtCodigoCliente.Text = txtRif.Text;
                        return;
                    }

                    if ((letra.Equals("G")) && !(cboTipoPersona.Text.Equals("Gubernamental")))
                    {
                        MessageBox.Show("El Tipo de Persona debe seleccionar Gubernamental!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboTipoPersona.Focus();
                    }
                    else
                    {
                        txtCodigoCliente.Text = txtRif.Text;
                        return;
                    }


                }
            }
        }

        private void cboTipoPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true; SendKeys.Send("{TAB}");
            }
        }

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtVendedor.Text != "")
            {
                txtVendedor.Text = (String.Format("{0:0000000000}", Convert.ToDouble(txtVendedor.Text)));
                txtVendedor.Select(txtVendedor.Text.Length, 0);

                if (vende1.existeVendedor(txtVendedor.Text))
                {
                    vende1.CodigoV = txtVendedor.Text;
                    if (vende1.estaActivo(vende1.CodigoV))
                    {
                        vende1.CodigoV = txtVendedor.Text;
                        vende1.cargarDatosVendedor();
                        txtVendedor.Text = vende1.CodigoV;
                        txtNombreVendedor.Text = vende1.Nombre;
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        MessageBox.Show("Debe Seleccionar un vendedor Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Vendedor no Existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void txtCobrador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtCobrador.Text != "") {
                txtCobrador.Text = (String.Format("{0:0000000000}", Convert.ToDouble(txtCobrador.Text)));
                txtCobrador.Select(txtCobrador.Text.Length, 0);

                if (vende1.existeVendedor(txtCobrador.Text))
                {
                    vende1.CodigoV = txtCobrador.Text;
                    if (vende1.estaActivo(vende1.CodigoV))
                    {
                        vende1.CodigoV = txtCobrador.Text;
                        vende1.cargarDatosVendedor();
                        txtCobrador.Text = vende1.CodigoV;
                        txtNombreCobrador.Text = vende1.Nombre;
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        MessageBox.Show("Debe Seleccionar un cobrador Activo!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Cobrador no Existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    e.Handled = true; SendKeys.Send("{TAB}");
                }
            }
        }

        public void cargarCombo()
        {
            cboTipoNegocio.DisplayMember = "descripcion";
            cboTipoNegocio.ValueMember = "codigo";
            cboTipoNegocio.DataSource = tipoN.comboTipoNegocio();
            cboTipoNegocio.SelectedIndex = 0;
        }

        private void txtLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            funtxt.conDecimalesDefinidos(sender, e, a, 2);
        }

        private void txtDescuento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            funtxt.conDecimalesDefinidos(sender, e, a, 2);
        }

        private void txtDescuento3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            funtxt.conDecimalesDefinidos(sender, e, a, 2);
        }
    }
}
