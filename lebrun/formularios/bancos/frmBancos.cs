using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lebrun.clases.bancos;
using lebrun.clasesData;

namespace lebrun.formularios.bancos
{
    public partial class frmBancos : Form
    {

        private Banco bank;
        private string codigoBanco;
        private int accion = 0;
        private DataTable tabla;
        private static frmBancos m_FormDefInstance;
        private lbxBancos refLbxBanco;
        private FuncionesTexbox textBox;
        

        public frmBancos()
        {
            InitializeComponent();
            bank = new Banco();
            textBox = new FuncionesTexbox();
        }

        public frmBancos(string codBanco, int acc)
        {
            InitializeComponent();
            codigoBanco = codBanco;
            accion = acc;
            bank = new Banco();
            textBox = new FuncionesTexbox();
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            cmbEstatus.SelectedIndex = 0;

            if (accion == 1) {
                armarDatosBanco();
            }
        }

        public static frmBancos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmBancos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void asignandoValores() {

            
            bank.CodBanco = txtCodigo.Text;
            bank.NombreBanco = txtNombre.Text;
            bank.Telf1 = txtTelf1.Text;
            bank.Telf2 = txtTelf2.Text;
            bank.Status = cmbEstatus.Text;
            bank.DireccionBanco = txtDireccion.Text;
            bank.PaginaWeb = txtWeb.Text;
            bank.Login = txtLogin.Text;
            bank.Clave = txtClave.Text;
            bank.Casillero = txtCasillero.Text;
            bank.Memo = txtObservacion.Text;
        
        }

        private bool validarCampos() 
        {
                if (txtNombre.Text != "")
                {
                    return true;
                }
                else { MessageBox.Show("El nombre del banco no debe quedar vacio"); return false; }
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void procesarInformacion() {

            if (accion == 0)
            {
                if (validarCampos())
                {
                    txtCodigo.Text = bank.obtenerUltimoCod();
                    asignandoValores();
                    bank.registrarBanco();
                    this.Close();
                }
            }

            if (accion == 1)
            {
                if (validarCampos())
                {
                    asignandoValores();
                    bank.actualizarBanco(txtCodigo.Text);
                    this.Close();
                }
            }
        }


        private void armarDatosBanco() {

            tabla = bank.armarDatosBanco(codigoBanco);

            if (tabla.Rows.Count > 0) {

                txtCodigo.Text = codigoBanco;
                txtNombre.Text = tabla.Rows[0][1].ToString();
                txtDireccion.Text = tabla.Rows[0][2].ToString();
                txtTelf1.Text = tabla.Rows[0][3].ToString();
                txtTelf2.Text = tabla.Rows[0][4].ToString();
                cmbEstatus.Text = tabla.Rows[0][5].ToString();
                txtWeb.Text = tabla.Rows[0][6].ToString();
                txtLogin.Text = tabla.Rows[0][7].ToString();
                txtClave.Text = tabla.Rows[0][8].ToString();
                txtCasillero.Text = tabla.Rows[0][9].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            procesarInformacion();
            refLbxBanco.refrescar(new object(), new EventArgs());
        }

        public void referenciaRefrescar(Form referencia)
        {
            refLbxBanco = (lbxBancos)referencia;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.tab(sender, e);
        }




    }
}
