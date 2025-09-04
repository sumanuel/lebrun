using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace lebrun.clasesData
{
    public class Compania
    {
        private string nombre;
        private string direccion;


        private string rif;
        private string codigo;
        private string baseDatosActual;
        private string baseDatosCompania;

        //campos agregados segun Haydee Rojas por el deber ser. 02:08 p.m. 19/06/2013
        private string minister;
        private string sso;
        private string telf;
        private string fax;
        private string telf1;
        private string pagina;
        private string tipper;
        private string contribuyente;
        private string moneda;
        private string moneetxt;
        private string cajain;
        private string mdcv;
        private string invcxs;
        private string cpsd;
        private string companiaConectar;

        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Rif
        {
            get { return rif; }
            set { rif = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string BaseDatosActual
        {
            get { return baseDatosActual; }
            set { baseDatosActual = value; }
        }
        public string BaseDatosCompania
        {
            get { return baseDatosCompania; }
            set { baseDatosCompania = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        //campos agregados segun Haydee Rojas por el deber ser. 02:08 p.m. 19/06/2013
        public string Invcxs
        {
            get { return invcxs; }
            set { invcxs = value; }
        }
        public string Cpsd
        {
            get { return cpsd; }
            set { cpsd = value; }
        }
        public string Mdcv
        {
            get { return mdcv; }
            set { mdcv = value; }
        }
        public string Cajain
        {
            get { return cajain; }
            set { cajain = value; }
        }
        public string Moneetxt
        {
            get { return moneetxt; }
            set { moneetxt = value; }
        }
        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }
        public string Contribuyente
        {
            get { return contribuyente; }
            set { contribuyente = value; }
        }
        public string Tipper
        {
            get { return tipper; }
            set { tipper = value; }
        }
        public string Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }
        public string Telf1
        {
            get { return telf1; }
            set { telf1 = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Telf
        {
            get { return telf; }
            set { telf = value; }
        }
        public string Sso
        {
            get { return sso; }
            set { sso = value; }
        }
        public string Minister
        {
            get { return minister; }
            set { minister = value; }
        }

        public string CompaniaConectar
        {
            get { return companiaConectar; }
            set { companiaConectar = value; }
        }

        private ConexionBD dataBase;
        private string sentencia;
        private ConexionBD dataBaseSysconta;

        public Compania() {
            dataBase = new ConexionBD(2);
        }

        public Compania(string companiaConectada)
        {
            dataBase = new ConexionBD(2);
            this.companiaConectar = companiaConectada;
        }

        public DataTable obtenerCompanias() {
            sentencia = "SELECT empre_nombre, empre_codigo, empre_actual FROM confdatosempresa";
            return dataBase.fDataTable(sentencia);
        }

        public  void obtenerCodigoCompaniaActual(){
            DataSet ds;
            DataTable dtDatosadmconfisisten;
            sentencia = "SELECT empre_codigo,empre_nombre,empre_rif FROM confdatosempresa WHERE empre_actual= true;";
            ds = dataBase.ejecutarQueryDs(sentencia);
            try
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    //esto es para dejarlo por defecto
                    this.codigo = ds.Tables[0].Rows[0]["empre_codigo"].ToString();
                    this.baseDatosCompania = ds.Tables[0].Rows[0]["empre_codigo"].ToString();
                    this.baseDatosActual = ds.Tables[0].Rows[0]["empre_codigo"].ToString();
                    /*this.nombre = ds.Tables[0].Rows[0]["empre_nombre"].ToString();
                    this.rif = ds.Tables[0].Rows[0]["empre_rif"].ToString();*/
                }

                //traer datos faltantes tabla admconfisisten
                sentencia = "SELECT * FROM admconfisisten;";
                dataBase.modificarConexionString(1);
                dtDatosadmconfisisten = dataBase.fDataTable(sentencia);
                if (dtDatosadmconfisisten.Rows.Count > 0) {
                    this.nombre = dtDatosadmconfisisten.Rows[0]["confi_nombre"].ToString();
                    this.direccion = dtDatosadmconfisisten.Rows[0]["confi_direcc"].ToString();
                    this.rif = dtDatosadmconfisisten.Rows[0]["confi_rif"].ToString();
                    this.minister = dtDatosadmconfisisten.Rows[0]["confi_minister"].ToString();
                    this.sso = dtDatosadmconfisisten.Rows[0]["confi_sso"].ToString();
                    this.telf = dtDatosadmconfisisten.Rows[0]["confi_telefono"].ToString();
                    this.fax = dtDatosadmconfisisten.Rows[0]["confi_fax"].ToString();
                    this.telf1 = dtDatosadmconfisisten.Rows[0]["confi_tel1"].ToString();
                    this.pagina = dtDatosadmconfisisten.Rows[0]["confi_pagina"].ToString();
                    this.tipper = dtDatosadmconfisisten.Rows[0]["confi_tipper"].ToString();
                    this.contribuyente = dtDatosadmconfisisten.Rows[0]["confi_contribuy"].ToString();
                    this.moneda = dtDatosadmconfisisten.Rows[0]["confi_moneda"].ToString();
                    this.moneetxt = dtDatosadmconfisisten.Rows[0]["confi_moneext"].ToString();
                    this.cajain = dtDatosadmconfisisten.Rows[0]["confi_cajain"].ToString();
                    this.mdcv = dtDatosadmconfisisten.Rows[0]["confi_mcdv"].ToString();
                    this.invcxs = dtDatosadmconfisisten.Rows[0]["confi_invcxs"].ToString();
                    this.cpsd = dtDatosadmconfisisten.Rows[0]["confi_cpsd"].ToString();
                }
                dataBase.modificarConexionString(2);
                this.dataBase.cerrarConexion();
            }
            catch (DataException e)
            {
                MessageBox.Show("Error: " + e.Message);
                MessageBox.Show("Fuente: " + e.Source);
            }
            catch (Exception e)
            {
                MessageBox.Show("General Error: " + e.Message);
                MessageBox.Show("General Fuente: " + e.Source);
            }
        }

        public DataTable obtenerCompanias2()
        {
            DataTable dt;
            sentencia = null;
            sentencia = "SELECT empre_nombre, empre_codigo, empre_actual FROM confdatosempresa order by empre_actual desc,  empre_codigo asc;";
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            return dt;
        }

        public bool isCompaniaDefault(string codigo)
        {
            bool centinela = false;
            DataTable dt;
            sentencia = null;

            sentencia = "SELECT empre_actual FROM confdatosempresa WHERE empre_codigo='$1';";
            sentencia = sentencia.Replace("$1", codigo);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["empre_actual"].ToString()))
                {
                    centinela = true;
                }
            }
            dataBase.cerrarConexion();

            return centinela;
        }

        public string getUrlService(string nameService)
        {
            DataTable dt;
            string url = null;
            sentencia = null;
            dataBase.modificarConexionString(2);
            sentencia = "SELECT $1 FROM confdatosempresa WHERE empre_codigo='$2';";
            sentencia = sentencia.Replace("$1", nameService);
            sentencia = sentencia.Replace("$2", this.companiaConectar);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                url = dt.Rows[0][0].ToString();
            }
            dataBase.cerrarConexion();
            dataBase.modificarConexionString(1);
            return url;
        }

        public DataTable cargarMenuPrincipal(string nombreMenu, string mapaMenu)
        {
            DataTable dt;
            sentencia = null;

            sentencia = "SELECT menu_padre as padre,menu_subpadre as subpadre,menu_hijo as hijo,menu_ruta as mmn_formulario, menu_nombre  " +
                                                                           "FROM conf_menu " +
                                                                           "LEFT JOIN confmapamenu ON " +
                                                                           "conf_menu.menu_antiguo = confmapamenu.mmn_menu WHERE " +
                                                                           "confmapamenu.mmn_modulo='$1' AND conf_menu.menu_padre = '$1' " +
                                                                           "and confmapamenu.mmn_codigo ='$2' AND  " +
                                                                           "confmapamenu.mmn_activo= true  order by   menu_subpadre asc, menu_hijo asc";
            sentencia = sentencia.Replace("$1", nombreMenu);
            sentencia = sentencia.Replace("$2", mapaMenu);
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            return dt;
        }

        public string getUrl(string codComp)
        {
            string url = null;
            sentencia = null;
            DataTable dt;

            dataBase.modificarConexionString(2);
            sentencia = "SELECT empre_direction FROM confdatosempresa WHERE empre_codigo ='$1';";
            sentencia = sentencia.Replace("$1", codComp);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                url = dt.Rows[0]["empre_direction"].ToString();
            }
            dataBase.cerrarConexion();
            dataBase.modificarConexionString(1);
            return url;
        }

        public void datosCompania(string cod)
        {
            DataTable dt;
            sentencia = null;
            sentencia = "SELECT empre_nombre,empre_rif FROM confdatosempresa WHERE  empre_codigo='$1';";
            sentencia = sentencia.Replace("$1", cod);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                this.nombre = dt.Rows[0]["empre_nombre"].ToString();
                this.rif = dt.Rows[0]["empre_rif"].ToString();
                this.codigo = cod;
            }
            dataBase.cerrarConexion();
        }

        public bool validarFechaLogin(DateTime fechaActual, string codigoComp)
        {
            DataTable dt = null;
            bool centinela = true;
            sentencia = null;

            dataBaseSysconta = new ConexionBD();
            dataBaseSysconta.conectionStringSysconta(codigoComp);

            sentencia = "SELECT pc_FechaUltimaDiario FROM admparametroscontables WHERE pc_idSistema='02';";
            dt = dataBaseSysconta.fDataTable(sentencia);

            if (dt.Rows.Count > 0)
            {
                if ((fechaActual.CompareTo(Convert.ToDateTime(dt.Rows[0]["pc_FechaUltimaDiario"].ToString())) < 0))
                {
                    centinela = false;
                }
            }
            dataBaseSysconta.cerrarConexion();
            return centinela;
        }

        public string obtenerSiglasEmpresa()
        {
            string siglas;
            DataTable dt;
            sentencia = "SELECT empre_siglas FROM confdatosempresa WHERE empre_actual= true;";
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            siglas = dt.Rows[0]["empre_siglas"].ToString();
            return siglas;
        }
        public string obtenerRifEmpresa()
        {
            string rif;
            DataTable dt;
            sentencia = "SELECT empre_rif FROM confdatosempresa WHERE empre_actual= true;";
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            rif = dt.Rows[0]["empre_rif"].ToString();
            return rif;
        }
        
    }
}
