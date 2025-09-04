using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clasesData;
using lebrun.clases.clientes;

namespace lebrun.formularios.clientes
{
    public partial class frmTipoNegocio : Form
    {
        FuncionesTexbox funtxt;
        TipoNegocio tipoN;
        public lbxTipoNegocio referenciaLbxTipoNegocio;
        public string ope;
        public frmTipoNegocio()
        {
            InitializeComponent();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTipoNegocio_Load(object sender, EventArgs e)
        {
            funtxt = new FuncionesTexbox();
            tipoN = new TipoNegocio();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
             if ((e.KeyChar == (char)(Keys.Enter)) && txtCodigo.Text != "")
             {
                 SendKeys.Send("{TAB}");
             }
             else
             {
                 funtxt.sinCharEspeciales(sender, e);
             }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDescripcion.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void chechActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDes1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDes1.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.only2Decimal(sender, e, this.txtDes1);
            }
        }

        private void txtDes2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDes2.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.only2Decimal(sender, e, this.txtDes2);
            }
        }

        private void txtDes3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDes3.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.only2Decimal(sender, e, this.txtDes3);
            }
        }

        private void txtDial1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDial1.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.OnlyNumbers(sender, e);
            }

        }

        private void txtPorcen1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) &&  txtPorcen1.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.only2Decimal(sender, e, this.txtPorcen1);
            }
        }

        private void txtDial2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtDial2.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.OnlyNumbers(sender, e);
            }
        }

        private void txtPorce2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && txtPorce2.Text != "")
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                funtxt.only2Decimal(sender, e, this.txtPorce2);
            }
        }

        private void cmdAgregarItem_Click(object sender, EventArgs e)
        {
            if (camposObligatorios())
            {
                if (ope != "editar")
                {
                    if (tipoN.existeTipo(txtCodigo.Text))
                    {
                        MessageBox.Show("El código para este tipo de Negocio Existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigo.Focus();
                        return;
                    }
                    else
                    {
                        asignarObjeto();
                        if (tipoN.insertTipoNegocio(tipoN) == -1)
                        {
                            MessageBox.Show("Tipo de Neogocio Grabado Existosamente", "Exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tipoN.limpiar();
                            referenciaLbxTipoNegocio.reloadLbx();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al Grabar Tipo de Negocio, el programa se cerrara, vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            referenciaLbxTipoNegocio.reloadLbx();
                            this.Close();
                        }
                    }
                }
                else
                {
                    asignarObjeto();
                    if ((tipoN.updateTipoNegocio(tipoN)) == -1)
                    {
                        MessageBox.Show("Tipo de Neogocio Modificado Existosamente", "Exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tipoN.limpiar();
                        this.ope = null;
                        referenciaLbxTipoNegocio.reloadLbx();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar Tipo de Negocio, el programa se cerrara, vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        referenciaLbxTipoNegocio.reloadLbx();
                        this.Close();
                    }
                }
            }

        }


        public bool camposObligatorios()
        { 
            bool centinela = true;

            if ((String.IsNullOrEmpty(txtCodigo.Text)))
            {
                MessageBox.Show("El código no puede quedar vacio!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centinela = false;
                txtCodigo.Focus();
                return centinela;
            }
            if ((String.IsNullOrEmpty(txtDescripcion.Text)))
            {
                MessageBox.Show("La Descricion no puede quedar Vacio!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centinela = false;
                txtDescripcion.Focus();
                return centinela;
            }
            
            return centinela;
        }

        public void asignarObjeto()
        {
            tipoN.codigo = txtCodigo.Text;
            tipoN.descripcion = txtDescripcion.Text;
            tipoN.descuento1 = String.IsNullOrEmpty(txtDes1.Text)? 0 : Convert.ToDecimal(txtDes1.Text.Replace(".",","));
            tipoN.descuento2 = String.IsNullOrEmpty(txtDes2.Text) ? 0 : Convert.ToDecimal(txtDes2.Text.Replace(".", ","));
            tipoN.descuento3 = String.IsNullOrEmpty(txtDes3.Text)? 0 : Convert.ToDecimal(txtDes3.Text.Replace(".",","));
            tipoN.primeraLeyendaDias = String.IsNullOrEmpty(txtDial1.Text) ? 0 : Convert.ToInt32(txtDial1.Text);
            tipoN.segundaLeyendaDias = String.IsNullOrEmpty(txtDial2.Text) ? 0 : Convert.ToInt32(txtDial2.Text);
            tipoN.activo = Convert.ToInt32(this.chechActivo.Checked);
            tipoN.observaciones = String.IsNullOrEmpty(txtObservaciones.Text) ? "" : txtObservaciones.Text;
            tipoN.pocentajePrimeraLeyenda = String.IsNullOrEmpty(txtPorcen1.Text) ? 0 : Convert.ToDecimal(txtPorcen1.Text.Replace(".", ","));
            tipoN.porcentajeSegundaLeyenda = String.IsNullOrEmpty(txtPorce2.Text) ? 0 : Convert.ToDecimal(txtPorce2.Text.Replace(".", ","));
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        public void actualizarReferencia(lbxTipoNegocio lbx, string ope)
        {
            this.referenciaLbxTipoNegocio = lbx;
            this.ope = ope;
            if (this.ope.Equals("editar"))
            {
                txtCodigo.Enabled = false;
            }
            cargarDatos();
            this.cmdAgregarItem.Image = lebrun.Properties.Resources.Edit_16x16;
            this.cmdAgregarItem.Text = "Modificar";
        }

        private void cargarDatos()
        {
            txtCodigo.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();
            txtDescripcion.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
            chechActivo.Checked = Convert.ToBoolean(referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["activo"].Value);
            txtDes1.Text =  referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["descuento1"].Value.ToString();
            txtDes2.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["descuento2"].Value.ToString();
            txtDes3.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["descuento3"].Value.ToString();
            txtDial1.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["primeraLeyendaDias"].Value.ToString();
            txtDial2.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["segundaLeyendaDias"].Value.ToString();
            txtObservaciones.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["observaciones"].Value.ToString();
            txtPorcen1.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["pocentajePrimeraLeyenda"].Value.ToString();
            txtPorce2.Text = referenciaLbxTipoNegocio.dataGridView1.CurrentRow.Cells["porcentajeSegundaLeyenda"].Value.ToString();
        }

        
    }
}
