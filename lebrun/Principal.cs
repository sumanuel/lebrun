using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using lebrun.formularios.contabilidad;
using lebrun.clasesData;
using lebrun.clases.contabilidad;
using lebrun.formularios.complementos;
using System.Reflection;
using lebrun;
using System.Net;
//using lebrun.formularios.productos;

namespace lebrun
{
    public partial class Principal : Form
    {
        //parametrosContables pContables;        
        //public lbxPlanCuentas lxPlanC;
        //lbxAuxiliarContable lbxAuxiliarC;
        public UsuarioSistema usuarioActual;
        //public lbxComprobanteContable lbxComprobante;
        public Compania empresaActual;
        //frmPlanCuentas frmPlanC;
        //frmComprobanteCierre frCompro;
        //frmPagare pagare;
        frmConsultaArticulos visorPrecios;
        //private ConexionBD databaseConection;
        //frmEstructuraCostos estrucC;
        //frmVisor2 visor2;
        

        //lbxComprobanteContable lbxComprobante;
        //public ComprobanteCierre compr1;

        public Principal()
        {
            InitializeComponent();
            usuarioActual = new UsuarioSistema();
            empresaActual = new Compania();
            empresaActual.obtenerCodigoCompaniaActual();
            //switch (empresaActual.Codigo)
            //{
            //    case ("01"):
            //        this.BackgroundImage = Properties.Resources.FondoFLebrun;
            //        break;
            //    case ("02"):
            //        this.BackgroundImage = Properties.Resources.Fondoeltimon_ws;
            //        break;
            //    case ("03"):
            //        this.BackgroundImage = Properties.Resources.Fondolatienda_ws;
            //        break;
            //    case ("04"):
            //        this.BackgroundImage = Properties.Resources.Fondobrunle_ws;
            //        break;
            //    case ("05"):
            //        this.BackgroundImage = Properties.Resources.Fondoferrecarpi_ws;
            //        break;
            //    case ("06"):
            //        this.BackgroundImage = Properties.Resources.Fondoferresama;
            //        break;
            //}
        }

        public Principal(UsuarioSistema usuarioVerificado) {
            InitializeComponent();
            usuarioActual = usuarioVerificado;
            empresaActual = new Compania();
            empresaActual.obtenerCodigoCompaniaActual();
            if (!(this.empresaActual.validarFechaLogin(DateTime.Now, empresaActual.Codigo)))
            {
                MessageBox.Show("La fecha del Sistema es menor que la fecha del último cierre, por favor verifíquela", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }

            cargarMenuPrincipal();
            //switch (empresaActual.Codigo)
            //{
            //    case ("01"):
            //        this.BackgroundImage = Properties.Resources.FondoFLebrun;
            //        break;
            //    case ("02"):
            //        this.BackgroundImage = Properties.Resources.Fondoeltimon_ws;
            //        break;
            //    case ("03"):
            //        this.BackgroundImage = Properties.Resources.Fondolatienda_ws;
            //        break;
            //    case ("04"):
            //        this.BackgroundImage = Properties.Resources.Fondobrunle_ws;
            //        break;
            //    case ("05"):
            //        this.BackgroundImage = Properties.Resources.Fondoferrecarpi_ws;
            //        break;
            //    case ("06"):
            //        this.BackgroundImage = Properties.Resources.Fondoferresama;
            //        break;
            //}
        }

        public Principal(UsuarioSistema usuarioVerificado,string companiaConectada) {
            InitializeComponent();
            //switch (companiaConectada) {
            //    case("01"):
            //        this.BackgroundImage = Properties.Resources.FondoFLebrun;
            //        break;
            //    case ("02"):
            //        this.BackgroundImage = Properties.Resources.Fondoeltimon_ws;
            //        break;
            //    case ("03"):
            //        this.BackgroundImage = Properties.Resources.Fondolatienda_ws;
            //        break;
            //    case ("04"):
            //        this.BackgroundImage = Properties.Resources.Fondobrunle_ws;
            //        break;
            //    case ("05"):
            //        this.BackgroundImage = Properties.Resources.Fondoferrecarpi_ws;
            //        break;
            //    case ("06"):
            //        this.BackgroundImage = Properties.Resources.Fondoferresama;
            //        break;
            //}
            usuarioActual = usuarioVerificado;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            string[] parametros;
            parametros = Environment.GetCommandLineArgs();
            /************************
             * 
             * ejemplo ruta base de datos
             * lebrun.formularios.complementos.frmPagare
             * campo mmn_activo = 1
             * ************/
           
            if (parametros.Length > 1)
            {
                //usuarioActual.Id = parametros[1];
                //if (parametros[2] == "parametrosContables")
                //{
                //    pContables = new parametrosContables();
                //    pContables.MdiParent = this;
                //    pContables.Show();
                //}
                //if (parametros[2] == "lbxPlanCuentas")
                //{
                //    lxPlanC = new lbxPlanCuentas();
                //    lxPlanC.MdiParent = this;
                //    lxPlanC.Show();
                //}
                //if (parametros[2] == "lbxAuxiliarContable")
                //{
                //    lbxAuxiliarC = new lbxAuxiliarContable();
                //    lbxAuxiliarC.MdiParent = this;
                //    lbxAuxiliarC.Show();
                //}
                //if (parametros[2] == "lbxComprobanteContable")
                //{
                //    lbxComprobante = new lbxComprobanteContable();
                //    lbxComprobante.MdiParent = this;
                //    lbxComprobante.Show();
                //}

                //if (parametros[2] == "comprobanteCierre") {
                //    //panel1.Visible = true;
                //    //compr1 = new ComprobanteCierre(this.empresaActual.BaseDatosActual);
                     
                //    frCompro = new frmComprobanteCierre();
                //    frCompro.MdiParent = this;
                //    frCompro.Show();
                //}

                if (parametros[2] == "frmPagare")
                {
                    //panel1.Visible = true;
                    //compr1 = new ComprobanteCierre(this.empresaActual.BaseDatosActual);

                    //pagare = new frmPagare();
                    //pagare.MdiParent = this;
                    //pagare.Show();
                }

                if (parametros[2] == "frmEstructuraCostos")
                {
                    //estrucC = new frmEstructuraCostos();
                    //this.usuarioActual.Id = parametros[1];
                    //estrucC.MdiParent = this;
                    //estrucC.Show();
                    //empresaActual.datosCompania(parametros[3]);
                }

            }
            else
            {
                /*frCompro = new frmComprobanteCierre();
                frCompro.MdiParent = this;
                frCompro.Show();*/
                 //usuarioActual.Id = "0028";
                /*
                 frCompro = new frmComprobanteCierre();
                 frCompro.MdiParent = this;
                 frCompro.Show();
                 frCompro.statusPasos(this.empresaActual.BaseDatosActual);*/
                 
             //compr1 = new ComprobanteCierre(this.empresaActual.BaseDatosActual);
              
                  /*lbxComprobante = new lbxComprobanteContable();
              lbxComprobante.MdiParent = this;
              lbxComprobante.Show();*/
              /*lbxAuxiliarC = new lbxAuxiliarContable();
              lbxAuxiliarC.MdiParent = this;
              lbxAuxiliarC.Show();*/
             /*lxPlanC = new lbxPlanCuentas();
                lxPlanC.MdiParent = this;
                lxPlanC.Show();*/

                /*frmPlanC = new frmPlanCuentas();
                frmPlanC.MdiParent = this;
                frmPlanC.Show();*/
            }

            llenarCombo();
            menuStrip1.Items.Remove(toolStripComboBox1);
            menuStrip1.Items.Add(toolStripComboBox1);
            llenarCombo();
            string hostname = Dns.GetHostName();
            string ip = Dns.GetHostByName(hostname).AddressList[0].ToString();
            toolStripStatusLabel21.Text = "IP del equipo: " + ip;
            toolStripStatusLabel2.Text = "Codigo de Usuario =" + this.usuarioActual.Id + ".      Nombre de Usuario=" + this.usuarioActual.NombreUsuario;
            this.usuarioActual.IpPc = ip;
        }

        private void llenarCombo()
        {
            string[] parametros;
            string[] codCompanias;

            parametros = Environment.GetCommandLineArgs();
            DataTable tablaCompanias;
            DataTable tablaCompanias2;
            DataRow fila;

            tablaCompanias = empresaActual.obtenerCompanias();

            if (parametros.Length > 3)
            {
                tablaCompanias2 = tablaCompanias.Clone();
                codCompanias = parametros[3].Split('-');
                for (int x = 0; x < tablaCompanias.Rows.Count; x++)
                {
                    fila = tablaCompanias.Rows[x];
                    for (int y = 0; y < codCompanias.Length; y++)
                    {
                        if (fila["empre_codigo"].ToString().Equals(codCompanias[y]))
                        {
                            tablaCompanias2.ImportRow(fila);
                        }
                    }
                }
            }
            else
            {
                tablaCompanias2 = tablaCompanias.Copy();
            }

            toolStripComboBox1.ComboBox.DisplayMember = "empre_nombre";
            toolStripComboBox1.ComboBox.ValueMember = "empre_codigo";
            toolStripComboBox1.ComboBox.DataSource = tablaCompanias2;



            for (int i = 0; i < tablaCompanias2.Rows.Count; i++)
            {
                fila = tablaCompanias2.Rows[i];

                if (tablaCompanias2.Rows[i][2].ToString().Equals("True"))
                {

                    toolStripComboBox1.ComboBox.SelectedIndex = toolStripComboBox1.ComboBox.FindString(tablaCompanias2.Rows[i][0].ToString());
                }

            }
            if (toolStripComboBox1.ComboBox.SelectedValue == null)
            {
                toolStripComboBox1.ComboBox.SelectedIndex = 1;
            }

            if (empresaActual.Codigo != "01")
            {
                toolStripComboBox1.Enabled = true;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            empresaActual.BaseDatosActual = toolStripComboBox1.ComboBox.SelectedValue.ToString();

            if (Application.OpenForms["lbxComprobanteContable"] != null)
            {
                //// form is opened, so activate it
                //Application.OpenForms["lbxComprobanteContable"].Activate();
                Application.OpenForms["lbxComprobanteContable"].Close();
                //Application.OpenForms["lbxComprobanteContable"].Show();
                //lbxComprobante = lbxComprobanteContable.DefInstance;
                //lbxComprobante.MdiParent = this;
                //lbxComprobante.Show();
               
            }

            if (Application.OpenForms["parametrosContables"] != null)
            {
                //Application.OpenForms["parametrosContables"].Close();
                //pContables = new parametrosContables();
                //pContables.MdiParent = this;
                //pContables.Show();
            }


            if (Application.OpenForms["lbxPlanCuentas"] != null)
            {
                //Application.OpenForms["lbxPlanCuentas"].Close();
                //lxPlanC = new lbxPlanCuentas();
                //lxPlanC.MdiParent = this;
                //lxPlanC.Show();
            }

            if (Application.OpenForms["lbxAuxiliarContable"] != null)
            {
                //Application.OpenForms["lbxAuxiliarContable"].Close();
                //lbxAuxiliarC = new lbxAuxiliarContable();
                //lbxAuxiliarC.MdiParent = this;
                //lbxAuxiliarC.Show();
            }
        }

        private void cargarMenu(DataTable dtMenuCargar1)
        {

            DataTable dtMenuCargar = dtMenuCargar1.Clone(); // Crear una estructura vacía

            // Filtrar las filas que cumplen con la condición
            DataRow[] filasFiltradas = dtMenuCargar1.Select("subpadre = 'Transacciones' AND (hijo = 'Factura de Venta' OR hijo = 'Devolucion de Venta')");

            // Agregar las filas filtradas al nuevo DataTable
            foreach (DataRow row in filasFiltradas)
            {
                dtMenuCargar.ImportRow(row);
            }


            ToolStripItem[] Menu = new ToolStripItem[1];
            Menu[0] = new ToolStripMenuItem();


            for (int i = 0; i < dtMenuCargar.Rows.Count; i++)
            {
                ToolStripMenuItem[] busqueda = new ToolStripMenuItem[(menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString(), true).Length)];
                if (busqueda.Length > 0)
                {
                    if (dtMenuCargar.Rows[i]["subpadre"].ToString() != "")
                    {
                        ToolStripMenuItem[] busquedaSub = new ToolStripMenuItem[(menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString(), true).Length)];
                        if (busquedaSub.Length > 0)
                        {
                            agregarHijo(((menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString(), true))[0]), dtMenuCargar.Rows[i]);
                        }
                        else
                        {
                            agregarSubPadre((ToolStripMenuItem)Menu[0], Menu[0], dtMenuCargar.Rows[i]);

                            if ((menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString() + " " + dtMenuCargar.Rows[i]["hijo"].ToString(), true).Length) == 0)
                            {
                                agregarHijo(((menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString(), true))[0]), dtMenuCargar.Rows[i]);
                            }
                        }
                    }
                }
                else
                {
                    Menu[0].Name = dtMenuCargar.Rows[i]["padre"].ToString();
                    Menu[0].Text = dtMenuCargar.Rows[i]["padre"].ToString();
                    Menu[0].Tag = dtMenuCargar.Rows[i]["padre"].ToString();
                    menuStrip1.Items.Add(Menu[0]);
                    if (dtMenuCargar.Rows[i]["subpadre"].ToString() != "")
                    {
                        ToolStripMenuItem[] busquedaSub = new ToolStripMenuItem[(menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString(), true).Length)];
                        if (busquedaSub.Length == 0)
                        {
                            agregarSubPadre((ToolStripMenuItem)Menu[0], Menu[0], dtMenuCargar.Rows[i]);
                            if ((menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString() + " " + dtMenuCargar.Rows[i]["hijo"].ToString(), true).Length) == 0)
                            {
                                agregarHijo(((menuStrip1.Items.Find(dtMenuCargar.Rows[i]["padre"].ToString() + " " + dtMenuCargar.Rows[i]["subpadre"].ToString(), true))[0]), dtMenuCargar.Rows[i]);
                            }
                        }
                    }
                }
            }
            
        }

        private void agregarVisorPrecios() {
            ToolStripItem[] Menu = new ToolStripItem[1];
            Menu[0] = new ToolStripMenuItem();
            Menu[0].Name = "Visor de Precios";
            Menu[0].Text = "Visor de Precios";
            Menu[0].Click += new EventHandler(visorClicked);
            //Menu[0].Image = Properties.Resources.Find_16x16;
            menuStrip1.Items.Add(Menu[0]);
        }
      
        public void agregarSubPadre(ToolStripMenuItem MenuPadre, ToolStripItem MenuItemPadre, DataRow fila)
        {

            ToolStripItem[] NuevoMenu = new ToolStripItem[1];
            NuevoMenu[0] = new ToolStripMenuItem();
            NuevoMenu[0].Name = fila["padre"].ToString() + " " + fila["subpadre"].ToString();
            NuevoMenu[0].Text = fila["subpadre"].ToString();
            NuevoMenu[0].Tag = fila["subpadre"].ToString();
            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
            

        }

        private void agregarHijo(ToolStripItem MenuItemPadre, DataRow fila)
        {
            ToolStripMenuItem MenuPadre = (ToolStripMenuItem)MenuItemPadre;
            ToolStripItem[] NuevoMenu = new ToolStripItem[1];
            NuevoMenu[0] = new ToolStripMenuItem(); 
            NuevoMenu[0].Name = fila["padre"].ToString() + " " + fila["subpadre"].ToString() + " " + fila["hijo"].ToString();
            NuevoMenu[0].Text = fila["hijo"].ToString();
            NuevoMenu[0].Tag = fila["mmn_formulario"].ToString();
            NuevoMenu[0].Click += new EventHandler(MenuItemClicked);
            
            if (fila["menu_nombre"].ToString() != "") {
                NuevoMenu[0].Name = fila["menu_nombre"].ToString();
                //NuevoMenu[0].
            }
            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem menuPresionado = (ToolStripMenuItem)sender;

            Assembly asm = Assembly.GetEntryAssembly();
            ToolStripItem temp = (ToolStripItem)sender;


            if (temp.Tag.ToString().Length > 0)
            {
                Type formtype = asm.GetType(temp.Tag.ToString());
                Form f = (Form)Activator.CreateInstance(formtype);
                f.MdiParent = this;
                if ((menuPresionado.Name.ToString() != "") || (menuPresionado.Name != null))
                {
                    f.Name = menuPresionado.Name;
                }
                if ((menuPresionado.Name.Equals("Factura de Venta")) || (menuPresionado.Name.Equals("Devolucion de Venta"))
                    || (menuPresionado.Name.Equals("Reporte X")) || (menuPresionado.Name.Equals("Reporte Z")) || (menuPresionado.Name.Equals("Pedido")))
                {
                    f.Name = menuPresionado.Name;
                }
                try
                {
                    f.Show();
                }
                catch (Win32Exception w)
                {

                }

            }
        }

        private void visorClicked(object sender, EventArgs e)
        {
            frmConsultaArticulos.DefInstance.Dispose();
            visorPrecios = frmConsultaArticulos.DefInstance;
            visorPrecios.MdiParent = this;
            visorPrecios.Select();
            visorPrecios.TopMost = true;
            visorPrecios.Show();
        }

        private void cargarMenuPrincipal() {
            DataTable dt;
            ////Inventario
            //cargarMenu(empresaActual.cargarMenuPrincipal("Inventario", usuarioActual.MapaMenu));
            //////Compras
            //cargarMenu(empresaActual.cargarMenuPrincipal("Compras", usuarioActual.MapaMenu));
            ////Ventas
            dt = empresaActual.cargarMenuPrincipal("Ventas", usuarioActual.MapaMenu);
            cargarMenu(empresaActual.cargarMenuPrincipal("Ventas", usuarioActual.MapaMenu));
            //////Tesoreria
            //cargarMenu(empresaActual.cargarMenuPrincipal("Tesoreria", usuarioActual.MapaMenu));
            //////Contabilidad
            //cargarMenu(empresaActual.cargarMenuPrincipal("Contabilidad", usuarioActual.MapaMenu));
            //////Gerencial
            //cargarMenu(empresaActual.cargarMenuPrincipal("Gerencial", usuarioActual.MapaMenu));
            //////Definiciones
            //cargarMenu(empresaActual.cargarMenuPrincipal("Definiciones", usuarioActual.MapaMenu));
            //////Administracion
            //cargarMenu(empresaActual.cargarMenuPrincipal("Administracion", usuarioActual.MapaMenu));

            var p = from x in dt.AsEnumerable() where ((x.Field<string>("padre") == "Ventas") && (x.Field<string>("subpadre") == "Otros") && (x.Field<string>("hijo") == "Visor")) select x;
            if (p.Count() > 0)
            {
                agregarVisorPrecios();
            }
            var q = from x in dt.AsEnumerable() where ((x.Field<string>("padre") == "Ventas") && (x.Field<string>("subpadre") == "Otros") && (x.Field<string>("hijo") == "Visor2")) select x;
            if (q.Count() > 0)
            {
                agregarVisorPrecios2();
            }
        }
        

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frCompro = new frmComprobanteCierre();
            //frCompro.MdiParent = this;
            //frCompro.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString().ToString() + " - " + DateTime.Now.ToLongTimeString().ToString();
            //toolStripStatusLabel21.Text = "Fecha:" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + ". Hora:" + DateTime.Now.ToLongTimeString().ToString();
            toolStripStatusLabel1.Text = "Fecha:" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + ". Hora:" + DateTime.Now.ToLongTimeString().ToString();
        }

        public void actualizarCodCompania(string cod) {
            //this.empresaActual.CompaniaConectar = cod;
        }

        private void agregarVisorPrecios2()
        {
            ToolStripItem[] Menu = new ToolStripItem[1];
            Menu[0] = new ToolStripMenuItem();
            Menu[0].Name = "Visor de Precios 2";
            Menu[0].Text = "Visor de Precios2";
            Menu[0].Click += new EventHandler(visorClicked2);
            //Menu[0].Image = Properties.Resources.Find_16x16;
            menuStrip1.Items.Add(Menu[0]);
        }

        private void visorClicked2(object sender, EventArgs e)
        {
            //frmVisor2.DefInstance.Dispose();
            //visor2 = frmVisor2.DefInstance;
            //visor2.MdiParent = this;
            //visor2.Select();
            //visor2.TopMost = true;
            //visor2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
     
    }
}