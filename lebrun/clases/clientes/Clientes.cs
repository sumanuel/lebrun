using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using MySql.Data.MySqlClient;

namespace lebrun.clases.clientes
{
    public class Clientes
    {
        private string codigo;
        private string nombre;
        private string rif;
        private string nif;
        private string categoria;
        private string direccion;
        private string direccion2;
        private string direccionEnvio;
        private string representante;
        private string zonaGeografica;
        private int zonaPostal;
        private string telefono;
        private string fax;
        private string email;
        private string tipoNegocio;
        private string transporte;
        private string vendedor;
        private decimal comisionVen;
        private string cobrador;
        private decimal comisionCobrador;
        private int diaCobro;
        private string tipoLista;
        private string situacion;
        private string fechaInicioVaca;
        private string fechaFinVaca;
        private string tipoPersona;
        private string clientePlanC;
        private string clienteAuxiliar;
        private string observaciones;
        private string condicionPago;
        private string divisaCliente;
        private decimal descuentoEnventas;
        private string codigoCondicionPago;
        private string cuentaManor;
        private string auxiliarC;
        private string contribuyente;
        public string idTipoNegocio { get; set; }
        public decimal descuento2 { get; set; }
        public decimal descuento3 { get; set; }
        public decimal limiteCredito { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaUltimaCompra { get; set; }
        
        private ConexionBD dataBaseConection;
        private string sentenciaS;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Representante
        {
            get { return representante; }
            set { representante = value; }
        }
        public string Rif
        {
            get { return rif; }
            set { rif = value; }
        }
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Direccion2
        {
            get { return direccion2; }
            set { direccion2 = value; }
        }
        public string DireccionEnvio
        {
            get { return direccionEnvio; }
            set { direccionEnvio = value; }
        }
        public string ZonaGeografica
        {
            get { return zonaGeografica; }
            set { zonaGeografica = value; }
        }
        public int ZonaPostal
        {
            get { return zonaPostal; }
            set { zonaPostal = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string TipoNegocio
        {
            get { return tipoNegocio; }
            set { tipoNegocio = value; }
        }
        public string Transporte
        {
            get { return transporte; }
            set { transporte = value; }
        }
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
        public decimal ComisionVen
        {
            get { return comisionVen; }
            set { comisionVen = value; }
        }
        public string Cobrador
        {
            get { return cobrador; }
            set { cobrador = value; }
        }
        public decimal ComisionCobrador
        {
            get { return comisionCobrador; }
            set { comisionCobrador = value; }
        }
        public int DiaCobro
        {
            get { return diaCobro; }
            set { diaCobro = value; }
        }
        public string TipoLista
        {
            get { return tipoLista; }
            set { tipoLista = value; }
        }
        public string Situacion
        {
            get { return situacion; }
            set { situacion = value; }
        }
        public string FechaInicioVaca
        {
            get { return fechaInicioVaca; }
            set { fechaInicioVaca = value; }
        }
        public string FechaFinVaca
        {
            get { return fechaFinVaca; }
            set { fechaFinVaca = value; }
        }
        public string TipoPersona
        {
            get { return tipoPersona; }
            set { tipoPersona = value; }
        }
        public string ClientePlanC
        {
            get { return clientePlanC; }
            set { clientePlanC = value; }
        }
        public string ClienteAuxiliar
        {
            get { return clienteAuxiliar; }
            set { clienteAuxiliar = value; }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        public string CondicionPago
        {
            get { return condicionPago; }
            set { condicionPago = value; }
        }
        public string DivisaCliente
        {
            get { return divisaCliente; }
            set { divisaCliente = value; }
        }
        public decimal DescuentoEnventas
        {
            get { return descuentoEnventas; }
            set { descuentoEnventas = value; }
        }

        public string CodigoCondicionPago
        {
            get { return codigoCondicionPago; }
            set { codigoCondicionPago = value; }
        }

        public string CuentaManor
        {
            get { return cuentaManor; }
            set { cuentaManor = value; }
        }
        public string AuxiliarC
        {
            get { return auxiliarC; }
            set { auxiliarC = value; }
        }

        public string Contribuyente
        {
            get { return contribuyente; }
            set { contribuyente = value; }
        }

        public Clientes()
        {
            this.dataBaseConection = new ConexionBD("50000");
        }
        public Clientes(string timeOut)
        {
            this.dataBaseConection = new ConexionBD(timeOut);
        }

        public DataTable lbxClientes() {
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT cli_codigo,cli_nombre,cli_rif,cli_categoria,cli_situacion FROM admclientes LIMIT 45;";
            dt = dataBaseConection.fDataTable(sentenciaS,200);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public DataTable clienteBuscado(string clienteBuscar) {
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT cli_codigo,cli_nombre,cli_rif,cli_categoria,cli_situacion FROM  admclientes WHERE " +
                                "cli_codigo LIKE '%$1%' OR cli_nombre LIKE '%$1%'  OR cli_rif LIKE '%$1%';";
            sentenciaS = sentenciaS.Replace("$1", clienteBuscar);
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        /* public bool ingresarCliente() {
             bool centinela = false;
             DateTime x = DateTime.Now;
             sentenciaS = null;
             sentenciaS = "INSERT INTO admclientes (cli_codigo,cli_nombre,cli_rif,cli_vendedor,cli_telefono,cli_direc1, " +
                                 " cli_pais, cli_region, cli_estado, cli_municipio, cli_parroqia, cli_direc2, cli_direc3, cli_codarea, " +
                                 " cli_telmaster, cli_fax, cli_celular, cli_otrocel, cli_correo, cli_pagina, cli_fechareg, cli_reside, " +
                                 " cli_tipoper, cli_contribuyen, cli_contriespe, cli_categoria, cli_clasificac, cli_situacion, cli_memo1, " +
                                 " cli_actividadec, cli_capipaga, cli_capisuscri, cli_gacenun, cli_nonmbreg, cli_zona, cli_memo2, " +
                                 " cli_cobrador, cli_divisa, cli_condipag, cli_diacaja, cli_horacaj, cli_ultiprecio, Cli_lisprecio, " +
                                 " cli_descuento, cli_credito, cli_lincredito, cli_diasplazo, cli_linmonvenci, cli_lindiasven, " +
                                 " cli_memo3, admAC_codigoCuenta, admAC_codigoAuxiliarContable,cli_inivaca, cli_finvaca)" +
                                 "VALUES('$1','$2','$3','$4','$5','$6','0089','0001','0001','0001',$,$,$,$,$,$,$,$,$,$,'$fechaSistema', "+
                                 " 'SI','$tipoper','SI','No','Buena', '000001','Activo', $,$, 0.00, 0.00, $,$,'No', $,$,'Bs', 'Contado',$,$, "+
                                 " 'No','$prelist',0.00,'No',0.00, $,0.00, $, '000001', $, $,'$fechaIncioV','$fechaFinV');";

             sentenciaS = sentenciaS.Replace("$1", this.codigo);
             sentenciaS = sentenciaS.Replace("$2", this.nombre);
             sentenciaS = sentenciaS.Replace("$3", this.rif);
             sentenciaS = sentenciaS.Replace("$4", this.vendedor);
             sentenciaS = sentenciaS.Replace("$5", this.telefono);
             sentenciaS = sentenciaS.Replace("$6", this.direccion);
             sentenciaS = sentenciaS.Replace("$fechaSistema", "" + x.Year + "-" + x.Month + "-" + x.Day);
             sentenciaS = sentenciaS.Replace("$fechaIncioV", this.fechaInicioVaca);
             sentenciaS = sentenciaS.Replace("$fechaFinV", this.fechaFinVaca);
             sentenciaS = sentenciaS.Replace("$tipoper",this.tipoPersona);
             sentenciaS = sentenciaS.Replace("$prelist", this.tipoLista);
             sentenciaS = sentenciaS.Replace("$", "''");
             centinela = dataBaseConection.ejecutarInsert(sentenciaS);
             return true; 
         }*/




        public bool ingresarCliente()
        {
            bool centinela = true;
            DateTime x = DateTime.Now;
            try
            {
                sentenciaS = null;
                sentenciaS = "INSERT INTO admclientes (cli_codigo,cli_nombre,cli_rif,cli_vendedor,cli_telefono,cli_direc1, " +
                                    " cli_pais, cli_region, cli_estado, cli_municipio, cli_parroqia, cli_direc2, cli_direc3, cli_codarea, " +
                                    " cli_telmaster, cli_fax, cli_celular, cli_otrocel, cli_correo, cli_pagina, cli_fechareg, cli_reside, " +
                                    " cli_tipoper, cli_contribuyen, cli_contriespe, cli_categoria, cli_clasificac, cli_situacion, cli_memo1, " +
                                    " cli_actividadec, cli_capipaga, cli_capisuscri, cli_gacenun, cli_nonmbreg, cli_zona, cli_memo2, " +
                                    " cli_cobrador, cli_divisa, cli_condipag, cli_diacaja, cli_horacaj, cli_ultiprecio, Cli_lisprecio, " +
                                    " cli_descuento, cli_credito, cli_lincredito, cli_diasplazo, cli_linmonvenci, cli_lindiasven, " +
                                    " cli_memo3, admAC_codigoCuenta, admAC_codigoAuxiliarContable,cli_inivaca, cli_finvaca )" +
                                    "VALUES( '$cli_codigo','$cli_nombre','$cli_rif','$cli_vendedor','$cli_telefono','$cli_direc1', " +
                                    "'$cli_pais','$cli_region','$cli_estado','$cli_municipio','$cli_parroqia','$cli_direc2','$cli_direc3','$cli_codarea', " +
                                    "'$cli_telmaster','$cli_fax','$cli_celular','$cli_otrocel','$cli_correo','$cli_pagina','$cli_fechareg','$cli_reside', " +
                                    "'$cli_tipoper','$cli_contribuyen','$cli_contriespe','$cli_categoria','$cli_clasificac','$cli_situacion','$cli_memo1', " +
                                    "'$cli_actividadec','$cli_capipaga','$cli_capisuscri','$cli_gacenun','$cli_nonmbreg','$cli_zona','$cli_memo2', " +
                                    "'$cli_cobrador','$cli_divisa','$cli_condipag','$cli_diacaja','$cli_horacaj','$cli_ultiprecio','$Cli_lisprecio', " +
                                    "'$cli_descuento','$cli_credito','$cli_lincredito','$cli_diasplazo','$cli_linmonvenci','$cli_lindiasven', " +
                                    "'$cli_memo3','$admAC_codigoCuenta','$admAC_codigoAuxiliarContable','$cli_inivaca','$cli_finvaca');";

                sentenciaS = sentenciaS.Replace("$cli_codigo", this.codigo);
                sentenciaS = sentenciaS.Replace("$cli_nombre", this.nombre);
                sentenciaS = sentenciaS.Replace("$cli_rif", this.rif);
                sentenciaS = sentenciaS.Replace("$cli_vendedor", this.vendedor);
                sentenciaS = sentenciaS.Replace("$cli_telefono", this.telefono);
                sentenciaS = sentenciaS.Replace("$cli_direc1", this.direccion);
                sentenciaS = sentenciaS.Replace("$cli_pais", "");
                sentenciaS = sentenciaS.Replace("$cli_region", "");
                sentenciaS = sentenciaS.Replace("$cli_estado", this.zonaGeografica);
                sentenciaS = sentenciaS.Replace("$cli_municipio", "");
                sentenciaS = sentenciaS.Replace("$cli_parroqia", "");
                sentenciaS = sentenciaS.Replace("$cli_direc2", this.direccion2);
                sentenciaS = sentenciaS.Replace("$cli_direc3", this.direccionEnvio);
                sentenciaS = sentenciaS.Replace("$cli_codarea", "");
                sentenciaS = sentenciaS.Replace("$cli_telmaster", "");
                sentenciaS = sentenciaS.Replace("$cli_fax", this.fax);
                sentenciaS = sentenciaS.Replace("$cli_celular", "");
                sentenciaS = sentenciaS.Replace("$cli_otrocel", "");
                sentenciaS = sentenciaS.Replace("$cli_correo", this.email);
                sentenciaS = sentenciaS.Replace("$cli_pagina", "");
                sentenciaS = sentenciaS.Replace("$cli_fechareg", "" + x.Year + "-" + x.Month + "-" + x.Day);
                sentenciaS = sentenciaS.Replace("$cli_reside", "Sí");
                sentenciaS = sentenciaS.Replace("$cli_tipoper", this.tipoPersona);
                sentenciaS = sentenciaS.Replace("$cli_contribuyen", this.contribuyente);
                sentenciaS = sentenciaS.Replace("$cli_contriespe", "No");
                sentenciaS = sentenciaS.Replace("$cli_categoria", "Buena");
                sentenciaS = sentenciaS.Replace("$cli_clasificac", "");
                sentenciaS = sentenciaS.Replace("$cli_situacion", this.situacion);
                sentenciaS = sentenciaS.Replace("$cli_memo1", "");
                sentenciaS = sentenciaS.Replace("$cli_actividadec", "");
                sentenciaS = sentenciaS.Replace("$cli_capipaga", "0.00");
                sentenciaS = sentenciaS.Replace("$cli_capisuscri", "0.00");
                sentenciaS = sentenciaS.Replace("$cli_gacenun", "");
                sentenciaS = sentenciaS.Replace("$cli_nonmbreg", "");
                sentenciaS = sentenciaS.Replace("$cli_zona", "No");
                sentenciaS = sentenciaS.Replace("$cli_memo2", this.Observaciones);
                sentenciaS = sentenciaS.Replace("$cli_cobrador", this.cobrador);
                sentenciaS = sentenciaS.Replace("$cli_divisa", "Bs");
                sentenciaS = sentenciaS.Replace("$cli_condipag", this.condicionPago);
                sentenciaS = sentenciaS.Replace("$cli_diacaja", "" + this.diaCobro);
                sentenciaS = sentenciaS.Replace("$cli_horacaj", "");
                sentenciaS = sentenciaS.Replace("$cli_ultiprecio", "No");
                sentenciaS = sentenciaS.Replace("$Cli_lisprecio", this.tipoLista);
                sentenciaS = sentenciaS.Replace("$cli_descuento", (Convert.ToString(this.descuentoEnventas).Replace(",", ".")));
                sentenciaS = sentenciaS.Replace("$cli_credito", "No");
                sentenciaS = sentenciaS.Replace("$cli_lincredito", (String.IsNullOrEmpty(this.limiteCredito.ToString()) ? "0" : (this.limiteCredito.ToString().Replace(",", "."))));
                sentenciaS = sentenciaS.Replace("$cli_diasplazo", "");
                sentenciaS = sentenciaS.Replace("$cli_linmonvenci", "0.00");
                sentenciaS = sentenciaS.Replace("$cli_lindiasven", "");
                sentenciaS = sentenciaS.Replace("$cli_memo3", "");
                sentenciaS = sentenciaS.Replace("$admAC_codigoCuenta", (this.cuentaManor == null ? "" : this.cuentaManor));
                sentenciaS = sentenciaS.Replace("$admAC_codigoAuxiliarContable", (this.auxiliarC == null ? "" : this.auxiliarC));
                sentenciaS = sentenciaS.Replace("$cli_inivaca", this.fechaInicioVaca);
                sentenciaS = sentenciaS.Replace("$cli_finvaca", this.fechaFinVaca);
                dataBaseConection.ejecutarInsert(sentenciaS);

                sentenciaS = null;
                if (this.transporte != null)
                {
                    sentenciaS = "INSERT INTO admclientes2 (" +
                                    "cli2_codigo,cli2_zonaPostal,cli2_fechaRegistro,cli2_nif," +
                                    "cli2_representante,cli2_comisionVendedor,cli2_comisionCobrador,cli2_tipoNegocio, " +
                                    "cli2_descuento2,cli2_descuento3, cli2_fechaUltimaCompra,cli2_fechaUltimoPago, dcli_transporte)" +
                                    "VALUES('$cli2_codigo',$cli2_zonaPostal,'$cli2_fechaRegistro','$cli2_nif'," +
                                    " '$cli2_representante',$cli2_comisionVendedor,$cli2_comisionCobrador, '$cli2_tipoNegocio', " +
                                    "$cli_descuento2, $cli2_descuento3, '$cli2_fechaUltimaCompra','$cli2_fechaUltimoPago','$dcli_transporte');";
                    sentenciaS = sentenciaS.Replace("$dcli_transporte", this.transporte);
                }
                else
                {
                    sentenciaS = "INSERT INTO admclientes2 (" +
                                       "cli2_codigo,cli2_zonaPostal,cli2_fechaRegistro,cli2_nif," +
                                       "cli2_representante,cli2_comisionVendedor,cli2_comisionCobrador,cli2_tipoNegocio, " +
                                       "cli2_descuento2,cli2_descuento3, cli2_fechaUltimaCompra,cli2_fechaUltimoPago)" +
                                       "VALUES('$cli2_codigo',$cli2_zonaPostal,'$cli2_fechaRegistro','$cli2_nif'," +
                                       " '$cli2_representante',$cli2_comisionVendedor,$cli2_comisionCobrador, '$cli2_tipoNegocio', " +
                                       "$cli_descuento2, $cli2_descuento3, '$cli2_fechaUltimaCompra','$cli2_fechaUltimoPago');";
                }

                sentenciaS = sentenciaS.Replace("$cli2_codigo", this.codigo);
                sentenciaS = sentenciaS.Replace("$cli2_zonaPostal", "" + this.zonaPostal);
                sentenciaS = sentenciaS.Replace("$cli2_fechaRegistro", "" + x.Year + "-" + x.Month + "-" + x.Day);
                sentenciaS = sentenciaS.Replace("$cli2_nif", this.nif);
                sentenciaS = sentenciaS.Replace("$cli2_representante", this.representante);
                sentenciaS = sentenciaS.Replace("$cli2_comisionVendedor", this.ComisionVen.ToString().Replace(",", "."));
                sentenciaS = sentenciaS.Replace("$cli2_comisionCobrador", "" + this.ComisionCobrador.ToString().Replace(",", "."));
                sentenciaS = sentenciaS.Replace("$cli2_tipoNegocio", this.TipoNegocio);
                sentenciaS = sentenciaS.Replace("$cli_descuento2", (this.descuento2.ToString().Replace(",", ".")));
                sentenciaS = sentenciaS.Replace("$cli2_descuento3", (this.descuento3.ToString().Replace(",", ".")));
                sentenciaS = sentenciaS.Replace("$cli2_fechaUltimaCompra", "1800-01-01");
                sentenciaS = sentenciaS.Replace("$cli2_fechaUltimoPago", "1800-01-01");
                dataBaseConection.ejecutarInsert(sentenciaS);
            }
            catch (Exception e)
            {

            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }


        public bool existeCliente() {
            bool centinela = false;
            sentenciaS = null;
            MySqlDataReader dr;
            
            sentenciaS = "SELECT cli_nombre FROM admclientes WHERE cli_codigo='$1'";
            sentenciaS = sentenciaS.Replace("$1",this.codigo);
            dr = dataBaseConection.ejecutarQueryDr(sentenciaS);
            if (dr.HasRows) {
                while (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        centinela = true;
                    }
                }
                dr.Close(); 
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public DataTable precioCliente() {
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT ttp_codigo FROM admpreciotip";
            dt=  dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        //public void cargarDatosCliente() {
        //    MySqlDataReader dr;

        //    sentenciaS = "";
        //    sentenciaS = "SELECT cli_codigo,cli_nombre,cli_rif,cli_vendedor,cli_telefono,cli_direc1, " +
        //                            " cli_estado, cli_direc2, cli_direc3,  " +
        //                            " cli_fax, cli_otrocel, cli_correo, cli_pagina,  " +
        //                            " cli_tipoper, cli_divisa,  " +
        //                            " cli_memo2, " +
        //                            " cli_cobrador,  cli_diacaja,  Cli_lisprecio, " +
        //                            " cli_inivaca, cli_finvaca,admAC_codigoCuenta, admAC_codigoAuxiliarContable, " +
        //                            " cli_condipag, cli_situacion, cli_descuento FROM admclientes WHERE cli_codigo='$1';";
            
        //    sentenciaS = sentenciaS.Replace("$1", this.codigo);
        //    dr = dataBaseConection.ejecutarQueryDr(sentenciaS);
        //    if (dr.HasRows) {
        //        while (dr.Read()) {
        //            this.nombre = (dr.GetString("cli_nombre") == "") ? "" : dr.GetString("cli_nombre");
        //            this.rif = (dr.GetString("cli_rif") == "") ? "" : dr.GetString("cli_rif");
        //            this.vendedor = (dr.GetString("cli_vendedor") == "") ? "" : dr.GetString("cli_vendedor");
        //            this.telefono = (dr.GetString("cli_telefono") == "") ? "" : dr.GetString("cli_telefono");
        //            this.direccion = (dr.GetString("cli_direc1") == "") ? "" : dr.GetString("cli_direc1");
        //            this.zonaGeografica = (dr.GetString("cli_estado") == "") ? "" : dr.GetString("cli_estado");
        //            this.direccion2 = (dr.GetString("cli_direc2") == "") ? "" : dr.GetString("cli_direc2");
        //            this.direccionEnvio = (dr.GetString("cli_direc3") == "") ? "" : dr.GetString("cli_direc3");
        //            this.fax = (dr.GetString("cli_fax") == "") ? "" : dr.GetString("cli_fax");
        //            this.tipoNegocio = (dr.GetString("cli_otrocel") == "") ? "" : dr.GetString("cli_otrocel");
        //            this.email = (dr.GetString("cli_correo") == "") ? "" : dr.GetString("cli_correo");
        //            this.tipoPersona = (dr.GetString("cli_tipoper") == "") ? "" : dr.GetString("cli_tipoper");
        //            this.observaciones = (dr.GetString("cli_memo2") == "") ? "" : dr.GetString("cli_memo2");
        //            this.cobrador = (dr.GetString("cli_cobrador") == "") ? "" : dr.GetString("cli_cobrador");
        //            this.diaCobro = (dr.GetString("cli_diacaja") == "") ? 0 : Convert.ToInt32(dr.GetString("cli_diacaja"));
        //            this.tipoLista = (dr.GetString("Cli_lisprecio") == "") ? "" : dr.GetString("Cli_lisprecio");
        //            this.fechaInicioVaca = (dr.GetString("cli_inivaca") == "") ? "" : dr.GetString("cli_inivaca");
        //            this.fechaFinVaca = (dr.GetString("cli_finvaca") == "") ? "" : dr.GetString("cli_finvaca");
        //            this.clientePlanC = (dr.GetString("admAC_codigoCuenta") == "") ? "" : dr.GetString("admAC_codigoCuenta");
        //            this.clienteAuxiliar = (dr.GetString("admAC_codigoAuxiliarContable") == "") ? "" : dr.GetString("admAC_codigoAuxiliarContable");
        //            this.condicionPago = (dr.GetString("cli_condipag") == "" ? "" : dr.GetString("cli_condipag"));
        //            this.divisaCliente = (dr.GetString("cli_divisa") == "" ? "" : dr.GetString("cli_divisa"));
        //            this.situacion = (dr.GetString("cli_situacion") == "" ? "" : dr.GetString("cli_situacion"));
        //            this.condicionPago = (dr.GetString("cli_condipag") == "" ? "" : dr.GetString("cli_condipag"));
        //            this.descuentoEnventas = (dr.GetDecimal("cli_descuento") == null ? 0 : dr.GetDecimal("cli_descuento"));
        //        }
        //    }

        //    dr.Close();
        //    dataBaseConection.cerrarConexion();

        //    sentenciaS = null;
        //    sentenciaS = "SELECT   " +
        //                          "cli2_codigo,cli2_zonaPostal,cli2_fechaRegistro,cli2_nif, " +
        //                          "cli2_representante,cli2_comisionVendedor,cli2_comisionCobrador " +
        //                          "FROM admclientes2 WHERE   cli2_codigo='$1';";
            
        //    sentenciaS = sentenciaS.Replace("$1", this.codigo);
        //    dr = dataBaseConection.ejecutarQueryDr(sentenciaS);
        //    if (dr.HasRows) {
        //        while (dr.Read()) {
        //            this.zonaPostal = (dr.GetInt32("cli2_zonaPostal") == 0) ? 0  : dr.GetInt32("cli2_zonaPostal");
        //            this.nif = (dr.GetString("cli2_nif") == "") ? "" : dr.GetString("cli2_nif");
        //            this.representante = (dr.GetString("cli2_representante") == "") ? "" : dr.GetString("cli2_representante");
        //            this.comisionVen = (dr.GetDecimal("cli2_comisionVendedor") == 0) ? 0 : dr.GetDecimal("cli2_comisionVendedor");
        //            this.comisionCobrador = (dr.GetDecimal("cli2_comisionCobrador") == 0) ? 0 : dr.GetDecimal("cli2_comisionCobrador");
        //        }
        //    }
        //    dr.Close();
        //    dataBaseConection.cerrarConexion();
        //}


        public void cargarDatosCliente()
        {
            MySqlDataReader dr;
            DataTable dt;

            sentenciaS = "";
            sentenciaS = "SELECT cli_codigo,cli_nombre,cli_rif,cli_vendedor,cli_telefono,cli_direc1, " +
                                    " cli_estado, cli_direc2, cli_direc3,  " +
                                    " cli_fax, cli_otrocel, cli_correo, cli_pagina,  " +
                                    " cli_tipoper, cli_divisa,  " +
                                    " cli_memo2, " +
                                    " cli_cobrador,  cli_diacaja,  Cli_lisprecio, " +
                                    " cli_inivaca, cli_finvaca,cli_contriespe  , cli_lincredito, admAC_codigoCuenta, admAC_codigoAuxiliarContable, " +
                                    " cli_condipag, cli_situacion, cli_descuento, admAC_codigoCuenta, admAC_codigoAuxiliarContable  FROM admclientes WHERE cli_codigo='$1';";

            sentenciaS = sentenciaS.Replace("$1", this.codigo);
            dr = dataBaseConection.ejecutarQueryDr(sentenciaS, 200);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.nombre = (dr.GetString("cli_nombre") == "") ? "" : dr.GetString("cli_nombre");
                    this.rif = (dr.GetString("cli_rif") == "") ? "" : dr.GetString("cli_rif");
                    this.vendedor = (dr.GetString("cli_vendedor") == "") ? "" : dr.GetString("cli_vendedor");
                    this.telefono = (dr.GetString("cli_telefono") == "") ? "" : dr.GetString("cli_telefono");
                    this.direccion = (dr.GetString("cli_direc1") == "") ? "" : dr.GetString("cli_direc1");
                    this.zonaGeografica = (dr.GetString("cli_estado") == "") ? "" : dr.GetString("cli_estado");
                    this.direccion2 = (dr.GetString("cli_direc2") == "") ? "" : dr.GetString("cli_direc2");
                    this.direccionEnvio = (dr.GetString("cli_direc3") == "") ? "" : dr.GetString("cli_direc3");
                    this.fax = (dr.GetString("cli_fax") == "") ? "" : dr.GetString("cli_fax");
                    this.tipoNegocio = (dr.GetString("cli_otrocel") == "") ? "" : dr.GetString("cli_otrocel");
                    this.email = (dr.GetString("cli_correo") == "") ? "" : dr.GetString("cli_correo");
                    this.tipoPersona = (dr.GetString("cli_tipoper") == "") ? "" : dr.GetString("cli_tipoper");
                    this.observaciones = (dr.GetString("cli_memo2") == "") ? "" : dr.GetString("cli_memo2");
                    this.cobrador = (dr.GetString("cli_cobrador") == "") ? "" : dr.GetString("cli_cobrador");
                    this.diaCobro = (dr.GetString("cli_diacaja") == "") ? 0 : Convert.ToInt32(dr.GetString("cli_diacaja"));
                    this.tipoLista = (dr.GetString("Cli_lisprecio") == "") ? "" : dr.GetString("Cli_lisprecio");
                    this.fechaInicioVaca = (dr.GetString("cli_inivaca") == "") ? "" : dr.GetString("cli_inivaca");
                    this.fechaFinVaca = (dr.GetString("cli_finvaca") == "") ? "" : dr.GetString("cli_finvaca");
                    this.clientePlanC = (dr.GetString("admAC_codigoCuenta") == "") ? "" : dr.GetString("admAC_codigoCuenta");
                    this.clienteAuxiliar = (dr.GetString("admAC_codigoAuxiliarContable") == "") ? "" : dr.GetString("admAC_codigoAuxiliarContable");
                    this.condicionPago = (dr.GetString("cli_condipag") == "" ? "" : dr.GetString("cli_condipag"));
                    this.divisaCliente = (dr.GetString("cli_divisa") == "" ? "" : dr.GetString("cli_divisa"));
                    this.situacion = (dr.GetString("cli_situacion") == "" ? "" : dr.GetString("cli_situacion"));
                    this.condicionPago = (dr.GetString("cli_condipag") == "" ? "" : dr.GetString("cli_condipag"));
                    this.descuentoEnventas = (dr.GetDecimal("cli_descuento") == null ? 0 : dr.GetDecimal("cli_descuento"));
                    this.cuentaManor = ((dr.GetString("admAC_codigoCuenta") == null) ? null : dr.GetString("admAC_codigoCuenta"));
                    this.auxiliarC = ((dr.GetString("admAC_codigoAuxiliarContable") == null) ? null : dr.GetString("admAC_codigoAuxiliarContable"));
                    this.contribuyente = dr.GetString("cli_contriespe").ToString();
                    this.limiteCredito = dr.GetDecimal("cli_lincredito");
                    //            sentenciaS = sentenciaS.Replace("$cli_lincredito", (this.limiteCredito.ToString().Replace(",", ".")));
                    sentenciaS = null;
                    sentenciaS = "SELECT conp_codigo FROM admcondpago WHERE conp_descripcion ='$1';";
                    sentenciaS = sentenciaS.Replace("$1", this.condicionPago);
                    dt = dataBaseConection.fDataTable(sentenciaS);
                    if (dt.Rows.Count > 0)
                    {
                        this.codigoCondicionPago = dt.Rows[0][0].ToString();
                    }
                }
            }
            dr.Close();
            dataBaseConection.cerrarConexion();

            sentenciaS = null;
            sentenciaS = "SELECT   " +
                                  "cli2_codigo,cli2_zonaPostal,cli2_fechaRegistro,cli2_nif, " +
                                  "cli2_representante,cli2_comisionVendedor,cli2_comisionCobrador,cli2_tipoNegocio, " +
                                  "cli2_descuento2, cli2_descuento3,cli2_fechaUltimaCompra,dcli_transporte  " +
                                  "FROM admclientes2 WHERE   cli2_codigo='$1';";

            sentenciaS = sentenciaS.Replace("$1", this.codigo);
            dr = dataBaseConection.ejecutarQueryDr(sentenciaS, 200);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.zonaPostal = (dr.GetInt32("cli2_zonaPostal") == 0) ? 0 : dr.GetInt32("cli2_zonaPostal");
                    this.nif = (dr.GetString("cli2_nif") == "") ? "" : dr.GetString("cli2_nif");
                    this.representante = (dr.GetString("cli2_representante") == "") ? "" : dr.GetString("cli2_representante");
                    this.comisionVen = (dr.GetDecimal("cli2_comisionVendedor") == 0) ? 0 : dr.GetDecimal("cli2_comisionVendedor");
                    this.comisionCobrador = (dr.GetDecimal("cli2_comisionCobrador") == 0) ? 0 : dr.GetDecimal("cli2_comisionCobrador");
                    this.idTipoNegocio = (dr.GetString("cli2_tipoNegocio") == "") ? "01" : dr.GetString("cli2_tipoNegocio");
                    this.descuento2 = (dr.GetDecimal("cli2_descuento2") == 0) ? 0 : dr.GetDecimal("cli2_descuento2");
                    this.descuento3 = (dr.GetDecimal("cli2_descuento3") == 0) ? 0 : dr.GetDecimal("cli2_descuento3");
                    this.fechaUltimaCompra = (dr.GetDateTime("cli2_fechaUltimaCompra") == null) ? "" : "" + dr.GetDateTime("cli2_fechaUltimaCompra").Day.ToString().PadLeft(2, '0') + "/" + dr.GetDateTime("cli2_fechaUltimaCompra").Month.ToString().PadLeft(2, '0') + "/" + dr.GetDateTime("cli2_fechaUltimaCompra").Year.ToString();
                    //cli2_fechaRegistro
                    this.fechaRegistro = (dr.GetDateTime("cli2_fechaRegistro") == null) ? "" : "" + dr.GetDateTime("cli2_fechaRegistro").Day.ToString().PadLeft(2, '0') + "/" + dr.GetDateTime("cli2_fechaRegistro").Month.ToString().PadLeft(2, '0') + "/" + dr.GetDateTime("cli2_fechaRegistro").Year.ToString();
                    this.transporte = (dr.GetString("dcli_transporte") == null ? null : dr.GetString("dcli_transporte"));
                }
            }
            dr.Close();
            dataBaseConection.cerrarConexion();
        }

        public DataTable condigPag()
        {
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT conp_codigo,conp_descripcion, conp_cant_dias FROM admcondpago WHERE conp_descripcion='$1';";
            sentenciaS = sentenciaS.Replace("$1", this.condicionPago);
            dt = dataBaseConection.fDataTable(sentenciaS);

            if (dt.Rows.Count > 0)
            {
                this.condicionPago = dt.Rows[0]["conp_codigo"].ToString();
            }

            return dt;
        }

        public bool modificarCliente()
        {
            bool centinela = false;

            sentenciaS = null;
            sentenciaS = "";
            sentenciaS = "UPDATE admclientes SET cli_nombre ='$cli_nombre',cli_rif='$cli_rif',cli_vendedor='$cli_vendedor', " +
                 " cli_telefono='$cli_telefono',cli_direc1 = '$cli_direc1', " +
                         " cli_estado='$cli_estado', cli_direc2='$cli_direc2', cli_direc3='$cli_direc3',  " +
                         " cli_fax='$cli_fax', cli_otrocel='$cli_otrocel', cli_correo='$cli_correo', " +
                         " cli_tipoper='$cli_tipoper',  " +
                         " cli_memo2='$cli_memo2', " +
                         " cli_cobrador='$cli_cobrador', cli_diacaja='$cli_diacaja',  Cli_lisprecio='$Cli_lisprecio', " +
                         " cli_inivaca='$cli_inivaca', cli_finvaca='$cli_finvaca',admAC_codigoCuenta='$admAC_codigoCuenta', admAC_codigoAuxiliarContable='$admAC_codigoAuxiliarContable', " +
                         " cli_condipag = '$cli_condipag', cli_situacion='$cli_situacion', cli_descuento ='$cli_descuento', cli_contriespe='$cli_contribuyen', " +
                         " cli_lincredito= '$cli_lincredito' " +
                         " WHERE cli_codigo='$1';";

            sentenciaS = sentenciaS.Replace("$cli_nombre", this.nombre);
            sentenciaS = sentenciaS.Replace("$cli_rif", this.rif);
            sentenciaS = sentenciaS.Replace("$cli_vendedor", this.vendedor);
            sentenciaS = sentenciaS.Replace("$cli_telefono", this.telefono);
            sentenciaS = sentenciaS.Replace("$cli_direc1", this.direccion);
            sentenciaS = sentenciaS.Replace("$cli_estado", this.zonaGeografica);
            sentenciaS = sentenciaS.Replace("$cli_direc2", this.direccion2);
            sentenciaS = sentenciaS.Replace("$cli_direc3", this.direccionEnvio);
            sentenciaS = sentenciaS.Replace("$cli_fax", this.fax);
            sentenciaS = sentenciaS.Replace("$cli_otrocel", "");
            sentenciaS = sentenciaS.Replace("$cli_correo", this.email);
            sentenciaS = sentenciaS.Replace("$cli_tipoper", this.tipoPersona);
            sentenciaS = sentenciaS.Replace("$cli_memo2", this.observaciones);
            sentenciaS = sentenciaS.Replace("$cli_cobrador", this.cobrador);
            sentenciaS = sentenciaS.Replace("$cli_diacaja", "" + this.diaCobro);
            sentenciaS = sentenciaS.Replace("$Cli_lisprecio", this.tipoLista);
            sentenciaS = sentenciaS.Replace("$cli_inivaca", this.fechaInicioVaca);
            sentenciaS = sentenciaS.Replace("$cli_finvaca", this.fechaFinVaca);
            sentenciaS = sentenciaS.Replace("$admAC_codigoCuenta", this.clientePlanC);
            sentenciaS = sentenciaS.Replace("$admAC_codigoAuxiliarContable", this.clienteAuxiliar);
            sentenciaS = sentenciaS.Replace("$cli_condipag", this.condicionPago);
            sentenciaS = sentenciaS.Replace("$cli_situacion", this.situacion);
            sentenciaS = sentenciaS.Replace("$cli_descuento", (Convert.ToString(this.descuentoEnventas).Replace(",", ".")));
            sentenciaS = sentenciaS.Replace("$1", this.codigo);
            sentenciaS = sentenciaS.Replace("$cli_contribuyen", this.contribuyente);
            sentenciaS = sentenciaS.Replace("$cli_lincredito", (this.limiteCredito.ToString().Replace(",", ".")));
            if (dataBaseConection.ejecutarInsert(sentenciaS))
            {
                sentenciaS = null;
                sentenciaS = "UPDATE  admclientes2 SET  " +
                                "cli2_zonaPostal='$cli2_zonaPostal',cli2_nif='$Ci2_nif', " +
                                "cli2_representante='$cli2_representante',cli2_comisionVendedor=$cli2_comisionVendedor, " +
                                "cli2_comisionCobrador='$cli2_comisionCobrador', cli2_tipoNegocio='$cli2_tipoNegocio', " +
                                "cli2_descuento2=$cli2_descuento2, cli2_descuento3=$cli2_descuento3 " +
                                "WHERE   cli2_codigo='$1';";
                sentenciaS = sentenciaS.Replace("$cli2_zonaPostal", "" + this.zonaPostal);
                sentenciaS = sentenciaS.Replace("$Ci2_nif", this.nif);
                sentenciaS = sentenciaS.Replace("$cli2_representante", this.representante);
                sentenciaS = sentenciaS.Replace("$cli2_comisionVendedor", Convert.ToString(this.comisionVen));
                sentenciaS = sentenciaS.Replace("$cli2_comisionCobrador", Convert.ToString(this.comisionCobrador));
                sentenciaS = sentenciaS.Replace("$1", this.codigo);
                sentenciaS = sentenciaS.Replace("$cli2_tipoNegocio", this.idTipoNegocio);
                sentenciaS = sentenciaS.Replace("$cli2_descuento2", (this.descuento2.ToString().Replace(",", ".")));
                sentenciaS = sentenciaS.Replace("$cli2_descuento3", (this.descuento3.ToString().Replace(",", ".")));
                centinela = dataBaseConection.ejecutarInsert(sentenciaS);
            }

            dataBaseConection.cerrarConexion();
            return centinela;
        }


        public bool estaActivo(string codCli) {
            bool centinela = false;
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT cli_situacion FROM admclientes WHERE cli_codigo='$1';";
            sentenciaS = sentenciaS.Replace("$1", codCli);

            dt = dataBaseConection.fDataTable(sentenciaS);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["cli_situacion"].ToString().Equals("Activo")) {
                    centinela = true;
                }
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public DataTable buscarClienteUnico(string codigo)
        {
            DataTable dt;
            sentenciaS = null;
            sentenciaS = "SELECT cli_codigo,cli_nombre,cli_rif FROM admclientes WHERE cli_codigo='$1';";
            sentenciaS = sentenciaS.Replace("$1", codigo);
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            return dt;


        }

        public void suspenderCLientes(string cliente)
        {

            sentenciaS = "UPDATE admclientes clientes INNER JOIN( " +
                            "SELECT Datediff(curdate(),FechaEmision) AS DIFERENCIA,cli_codigo " +
                            "FROM admsalcli saldo  WHERE cli_codigo='$1' AND Status=0 AND tipodoc <> 'DEV' " +
                            "AND codvend <0000000080 AND Datediff(curdate(),FechaEmision)>(SELECT mora_fact1 FROM admcondpago " +
                            "LEFT OUTER JOIN admclientes ON conp_descripcion=cli_condipag " +
                            "WHERE conp_descripcion=cli_condipag AND cli_codigo='$1' " +
                            "AND mora_fact1>0)) lala  " +
                            "ON clientes.cli_codigo = lala.cli_codigo " +
                            "SET clientes.cli_situacion ='Suspendido' WHERE clientes.cli_codigo='$1'";

            sentenciaS = sentenciaS.Replace("$1", cliente);
            dataBaseConection.ejecutarInsert(sentenciaS);
            dataBaseConection.cerrarConexion();

        }

        /// <summary>
        /// ready 
        /// </summary>
        /// 

        public void habilitarCliente(string cliente)
        {
            sentenciaS = "update admclientes set cli_situacion = 'Activo'  where cli_codigo='$1'";
            sentenciaS = sentenciaS.Replace("$1", cliente);
            dataBaseConection.ejecutarInsert(sentenciaS);
            dataBaseConection.cerrarConexion();
        }

       

        public void actualizarCuentaMA(string m, string a)
        {
            sentenciaS = null;

            if ((m != null) && (a == null))
            {
                sentenciaS = "UPDATE admclientes SET admAC_codigoCuenta ='$1' WHERE cli_codigo='$3'";
                sentenciaS = sentenciaS.Replace("$1", m);
            }
            else
            {
                sentenciaS = "UPDATE admclientes SET admAC_codigoCuenta ='$1', admAC_codigoAuxiliarContable='$2' WHERE cli_codigo='$3'";
                sentenciaS = sentenciaS.Replace("$1", m);
                sentenciaS = sentenciaS.Replace("$2", a);
            }
            sentenciaS = sentenciaS.Replace("$3", this.codigo);
            dataBaseConection.ejecutarInsert(sentenciaS);
            dataBaseConection.cerrarConexion();
        }

        public void limpiarCliente()
        {
            this.Codigo = null;
            this.nombre = null;
            this.representante = null;
            this.rif = null;
            this.categoria = null;
            this.nif = null;
            this.direccion = null;
            this.direccion2 = null;
            this.direccionEnvio = null;
            this.zonaGeografica = null;
            this.ZonaPostal = 0;
            this.telefono = null;
            this.fax = null;
            this.email = null;
            this.tipoNegocio = null;
            this.transporte = null;
            this.vendedor = null;
            this.comisionVen = 0;
            this.cobrador = null;
            this.comisionCobrador = 0;
            this.diaCobro = 0;
            this.tipoLista = null;
            this.situacion = null;
            this.fechaInicioVaca = null;
            this.fechaFinVaca = null;
            this.tipoPersona = null;
            this.clientePlanC = null;
            this.clienteAuxiliar = null;
            this.observaciones = null;
            this.condicionPago = null;
            this.divisaCliente = null;
            this.descuentoEnventas = 0;
            this.cuentaManor = null;
            this.auxiliarC = null;
        }

        public bool documentosVencidos()
        {
            DataTable dt = null;
            bool centinela = false;
            sentenciaS = "SELECT FechaVenc FROM admsalcli WHERE cli_codigo='@cli_codigo' AND FechaVenc<='$FechaVenc' LIMIT 1;";
            sentenciaS = sentenciaS.Replace("@cli_codigo", this.codigo);
            sentenciaS = sentenciaS.Replace("$FechaVenc", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0'));
            dt = dataBaseConection.fDataTable(sentenciaS);
            if (dt.Rows.Count > 0)
            {
                centinela = true;
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public decimal saldoActualSalcli(string codigoCliente, int status)
        {
            DataTable dt = null;
            sentenciaS = null;
            sentenciaS = "SELECT SUM(sal_actual) FROM admsalcli WHERE cli_codigo='$cli_codigo' AND status=$status";
            sentenciaS = sentenciaS.Replace("$cli_codigo", codigoCliente);
            sentenciaS = sentenciaS.Replace("$status", "" + status);
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dt.Rows[0]["SUM(sal_actual)"].ToString()))
                {
                    return (Convert.ToDecimal("0,00"));
                }
                else
                {
                    return (Convert.ToDecimal(dt.Rows[0]["SUM(sal_actual)"].ToString()));
                }
            }

            return (Convert.ToDecimal("0,00"));
        }

        public decimal saldoVencidoSalcli(string codigoCliente, int status, string fecha)
        {
            DataTable dt = null;
            sentenciaS = null;
            sentenciaS = "SELECT SUM(sal_actual) FROM admsalcli WHERE cli_codigo='$cli_codigo' AND status=$status " +
                "AND FechaVenc<'$FechaVenc';";
            sentenciaS = sentenciaS.Replace("$cli_codigo", codigoCliente);
            sentenciaS = sentenciaS.Replace("$status", "" + status);
            sentenciaS = sentenciaS.Replace("$FechaVenc", fecha);
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dt.Rows[0]["SUM(sal_actual)"].ToString()))
                {
                    return (Convert.ToDecimal("0,00"));
                }
                else
                {
                    return (Convert.ToDecimal(dt.Rows[0]["SUM(sal_actual)"].ToString()));
                }

            }

            return (Convert.ToDecimal("0,00"));
        }

        public bool documentosVencidos(string codigo)
        {
            DataTable dt = null;
            bool centinela = false;
            sentenciaS = "SELECT FechaVenc FROM admsalcli WHERE cli_codigo='@cli_codigo' AND FechaVenc<='$FechaVenc' LIMIT 1;";
            sentenciaS = sentenciaS.Replace("@cli_codigo", codigo);
            sentenciaS = sentenciaS.Replace("$FechaVenc", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0'));
            dt = dataBaseConection.fDataTable(sentenciaS);
            if (dt.Rows.Count > 0)
            {
                centinela = true;
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public DataTable cboTransporte()
        {
            DataTable dt = null;
            sentenciaS = null;
            sentenciaS = "SELECT trans_cod,trans_des FROM admtransporte WHERE trans_est='Activo';";
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public DataTable cboEstado()
        {
            DataTable dt = null;
            sentenciaS = null;
            sentenciaS = "SELECT est_codigo, est_descri FROM admestado;";
            dt = dataBaseConection.fDataTable(sentenciaS);
            dataBaseConection.cerrarConexion();
            return dt;
        }

    }
}

