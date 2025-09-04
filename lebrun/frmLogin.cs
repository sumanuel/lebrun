using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using lebrun.clasesData;
using lebrun;
using System.Runtime.Serialization;

    public partial class frmLogin : Form
    {   
        UsuarioSistema usuario;
        Compania empreTemp;
        Principal frmPrincipal;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loguear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            usuario = new UsuarioSistema();
            cboCompanias.DisplayMember = "empre_nombre";
            cboCompanias.ValueMember = "empre_codigo";
            cboCompanias.DataSource = usuario.obtenerCompanias2();
            empreTemp = new Compania();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && textBox1.Text != "")
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)(Keys.Enter)) && textBox2.Text != "")
            {
                loguear();
            }
        }

        private void loguear()
        {
            string direc = null;
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                usuario.Login = textBox1.Text;
                usuario.Contrasena = textBox2.Text;
                if (usuario.isCompaniaDefault(cboCompanias.SelectedValue.ToString()))
                {
                    if (usuario.validarUsuario())
                    {
                        if (usuario.usuarioActivo(usuario.Id))
                        {
                            if (usuario.permisoDeCompania(cboCompanias.SelectedValue.ToString()))
                            {
                                frmPrincipal = new Principal(usuario);
                                this.Hide();
                                frmPrincipal.Show();
                            }
                            else
                            {
                                MessageBox.Show("No posee permisos para esta compañia!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no esta Activo!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login o Contraseña Incorrectos!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                }
                else
                {
                    try
                    {
                        direc = empreTemp.getUrl(cboCompanias.SelectedValue.ToString());
                        if ((direc != null) && (!direc.Equals("")))
                        {
                            ConfigurationManager.AppSettings.Set("server", direc);
                            if (usuario.validarUsuario())
                            {
                                if (usuario.permisoDeCompania(cboCompanias.SelectedValue.ToString()))
                                {
                                    frmPrincipal = new Principal(usuario);
                                    this.Hide();
                                    frmPrincipal.Show();
                                }
                                else
                                {
                                    MessageBox.Show("No posee permisos para esta compañia!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Login o Contraseña Incorrectos!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error al conectar a Compañia deseada!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("El programa se cerrara", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }

                    }
                    catch (System.Configuration.ConfigurationException e)
                    {
                        MessageBox.Show("Error de configuracion");
                        MessageBox.Show(e.Message);
                    }

                }
            }
            else
            {
                if ((textBox1.Text == ""))
                {
                    MessageBox.Show("El Login No puede quedar vacio!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }

                if ((textBox2.Text == ""))
                {
                    MessageBox.Show("La contraseña No puede quedar vacia!!", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
        }

        
    }

