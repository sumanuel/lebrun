using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clasesData;
//using lebrun.formularios.cotizacion;
//using lebrun.formularios.pedidos;
//using lebrun.formularios.prefactura;

namespace lebrun.formularios.facturacion
{
    public partial class frmClaveConfirmacion2 : Form
    {
        public frmClaveConfirmacion2()
        {
            InitializeComponent();
        }

        private static frmClaveConfirmacion2 m_FormDefInstance;
        private UsuarioSistema usuarioValidar;
        private frmImportarDev referenciaImporDev;
        private frmFactura referenciaFactura;
        private lbxFacturas referenciaLbx;
        private string tipoOperacion;
        //private frmFacturaVivienda referenciaFactVi;
        //private frmPreFac preFC;
        //private lbxPrefacturaCtz referencialbxPreC;
        //private frmPedido referenPedido;
        //private frmPrefactura referenciaPrefactura;

        private void frmClaveConfirmacion2_Load(object sender, EventArgs e)
        {
            usuarioValidar = new UsuarioSistema(2);
            referenciaFactura = null;
            referenciaImporDev = null;
            tipoOperacion = null;
        }
        public static frmClaveConfirmacion2 DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmClaveConfirmacion2();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtClave.Text != "") && (textBox2.Text != ""))
            {
                if (usuarioValidar.existeUsuario(txtClave.Text))
                {
                    usuarioValidar.Login = txtClave.Text;
                    usuarioValidar.Contrasena = textBox2.Text;

                    if (usuarioValidar.validarUsuario())
                    {
                        if (usuarioValidar.usuarioActivo(usuarioValidar.Id))
                        {

                            if (usuarioValidar.isClaveSupervicion(txtClave.Text, textBox2.Text))
                            {
                                if (referenciaImporDev != null)
                                {
                                    referenciaImporDev.habilitarFormulario(true);
                                    referenciaImporDev.despuesConfirmacion(true, usuarioValidar.Id);
                                }
                                if (referenciaFactura != null)
                                {
                                    referenciaFactura.CentinelaConfirmacion = true;
                                }

                                if (referenciaLbx != null)
                                {
                                    referenciaLbx.despuesConfirmacionLbx(true);
                                }

                                //if (referenciaFactVi != null)
                                //{
                                //    referenciaFactVi.CentinelaConfirmacion = true;
                                //}

                                //if (preFC != null)
                                //{
                                //    preFC.CentinelaConfirmacion = true;
                                //}

                                //if (referencialbxPreC != null)
                                //{
                                //    referencialbxPreC.despuesConfirmacionLbx(true);
                                //}

                                //if (referenPedido != null)
                                //{
                                //    referenPedido.CentinelaConfirmacion = true;
                                //}

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("El usuario no posee permisos!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario esta inactivo!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Erróneos!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    textBox2.Clear();
                    txtClave.Focus();
                }
            }
            else if (txtClave.Text == "")
            {
                MessageBox.Show("El usuario no puede quedar Vacio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Focus();
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("La contraseña no puede quedar Vacio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
        }		

        

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtClave.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && textBox2.Text != "")
            {
                button1_Click(new object(), new KeyPressEventArgs((char)(Keys.Enter)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (referenciaImporDev != null)
            {
                referenciaImporDev.habilitarFormulario(true);
                referenciaImporDev.despuesConfirmacion(false, "");
            }

            if (referenciaLbx != null) {
                referenciaLbx.despuesConfirmacionLbx(false);
            }
        }

        public void cambiarReferencia(frmImportarDev referen) {
            this.referenciaImporDev = referen;
            referenciaImporDev.habilitarFormulario(false);
        }

        public void cambiarReferencia(frmFactura refFac,string tipo) {
            this.referenciaFactura = refFac;
            tipoOperacion = tipo;
        }

        public void cambiarReferencia(lbxFacturas referencia) {
            referenciaLbx = referencia;
        }

        private void frmClaveConfirmacion2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            if (referenciaImporDev != null)
            {
                referenciaImporDev.Focus();
            }
            if (referenciaFactura != null)
            {
                if (tipoOperacion.Equals("1"))
                {
                    referenciaFactura.Focus();
                    referenciaFactura.despuesdeConfirmacionPrecio(usuarioValidar.Id);
                    this.Dispose();
                }
                else
                {
                    if (referenciaFactura.CentinelaConfirmacion)
                    {
                        referenciaFactura.Focus();
                        referenciaFactura.continuarClave(usuarioValidar.Id);
                        this.Dispose();
                    }
                    else
                    {
                        referenciaFactura.Focus();
                        referenciaFactura.continuarClave("lo q sea");
                        this.Dispose();
                    }
                }
            }

            //if (referenPedido != null)
            //{
            //    if (tipoOperacion.Equals("1"))
            //    {
            //        referenPedido.Focus();
            //        referenPedido.despuesdeConfirmacionPrecio(usuarioValidar.Id);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        if (referenPedido.CentinelaConfirmacion)
            //        {
            //            referenPedido.Focus();
            //            referenPedido.continuarClave(usuarioValidar.Id);
            //            this.Dispose();
            //        }
            //        else
            //        {
            //            referenPedido.Focus();
            //            referenPedido.continuarClave("lo q sea");
            //            this.Dispose();
            //        }
            //    }
            //}


            //if (referenciaPrefactura != null)
            //{
            //    if (tipoOperacion.Equals("1"))
            //    {
            //        referenciaPrefactura.Focus();
            //        referenciaPrefactura.despuesdeConfirmacionPrecio(usuarioValidar.Id);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        if (referenciaPrefactura.CentinelaConfirmacion)
            //        {
            //            referenciaPrefactura.Focus();
            //            referenciaPrefactura.continuarClave(usuarioValidar.Id);
            //            this.Dispose();
            //        }
            //        else
            //        {
            //            referenciaPrefactura.Focus();
            //            referenciaPrefactura.continuarClave("lo q sea");
            //            this.Dispose();
            //        }
            //    }
            //}


            //if (referenciaFactVi != null)
            //{
            //    if (tipoOperacion.Equals("1"))
            //    {
            //        referenciaFactVi.Focus();
            //        referenciaFactVi.despuesdeConfirmacionPrecio(usuarioValidar.Id);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        if (referenciaFactVi.CentinelaConfirmacion)
            //        {
            //            referenciaFactVi.Focus();
            //            referenciaFactVi.continuarClave(usuarioValidar.Id);
            //            this.Dispose();
            //        }
            //        else
            //        {
            //            referenciaFactVi.Focus();
            //            referenciaFactVi.continuarClave("lo q sea");
            //            this.Dispose();
            //        }
            //    }

            //}

            //if (preFC != null)
            //{
            //    if (tipoOperacion.Equals("1"))
            //    {
            //        preFC.Focus();
            //        preFC.despuesdeConfirmacionPrecio(usuarioValidar.Id);
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        if (preFC.CentinelaConfirmacion)
            //        {
            //            preFC.Focus();
            //            preFC.continuarClave(usuarioValidar.Id);
            //            this.Dispose();
            //        }
            //        else
            //        {
            //            preFC.Focus();
            //            preFC.continuarClave("lo q sea");
            //            this.Dispose();
            //        }
            //    }
            //}

        }

        //public void cambiarReferencia(frmFacturaVivienda refFac, string tipo)
        //{
        //    this.referenciaFactVi = refFac;
        //    tipoOperacion = tipo;
        //}

        //public void cambiarReferencia(lbxPrefacturaCtz referencia)
        //{
        //    referencialbxPreC = referencia;
        //}

        //public void cambiarReferencia(frmPreFac referencia, string tipo)
        //{
        //    preFC = referencia;
        //    tipoOperacion = tipo;
        //}

        //public void cambiarReferencia(frmPrefactura pre, string tipo)
        //{
        //    referenciaPrefactura = pre;
        //    tipoOperacion = tipo;
        //}

        //public void cambiarReferencia(frmPedido ped, string tipo)
        //{
        //    this.referenPedido = ped;
        //    tipoOperacion = tipo;
        //}
    }
}
