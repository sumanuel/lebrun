using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;
using MySql.Data.MySqlClient;
using lebrun.clases.vendedores;
using lebrun.clases.clientes;
using System.Windows.Forms;
using lebrun.clases.complementos;

namespace lebrun.clases.facturacion
{
    public class Factura
    {
        private ConexionBD databaseConection;
        private String sentenciaSql;
        
        
        //atributos Factura
        private Decimal baseGN;
        private Decimal baseEX;
        private Decimal baseRD;
        private Decimal ivaGN;
        private Decimal ivaRD;
        private Decimal ivaTotal;
        private Decimal totalNeto;
        private Decimal totalBase;
        private Decimal descuentoItems;
        private Decimal costoNacional;
        private Decimal costoImportado;
        private Decimal baseNacional;
        private Decimal baseImportada;
        private string facturaAfectada;
        private string numeroFiscalAfectado;
        private string horaAfectada;
        private string fechaAfectada;
        private string eocAfectado;
        private string correlativoInterno;
        private string tipoDocumento;
        private DateTime fechaFactura;
        private decimal descuentoGeneral;
        private int plazoDias;
        private string condicion;
        private string divisa;
        private int totalItems;
        private int maximaCantidadDetalles;
        private DataGridView dgvItems;
        private Clientes clienteFacturar;
        private Vendedor vendedorFactura;
        private string numeroFiscal;
        private string modeloImpresora;
        private string serieImpresora;
        private string dcli_aprob1;
        private string dcli_aprob2;
        private string dcli_aprob3;
        private string dcli_estado;
        private string dcli_expexp;
        private string ctd_codcta;
        private string numeroPedido;
        private string direccionEnvio;
        private string dirObra;
        private string certificado;
        private string nombreReporte;
        public string peso { get; set; }
        public string bultos { get; set; }
        public string estatus { get; set; }
        public string diasPP1 { get; set; }
        public string diasPP2 { get; set; }
        public string porcentajePP1 { get; set; }
        public string porcentajePP2 { get; set; }
        public string codigoRechazo { get; set; }
        public string dcli_anufis { get; set; }


        #region getysets
        public Decimal BaseGN
        {
            get { return baseGN; }
            set { baseGN = value; }
        }
        public Decimal BaseEX
        {
            get { return baseEX; }
            set { baseEX = value; }
        }
        public Decimal BaseRD
        {
            get { return baseRD; }
            set { baseRD = value; }
        }
        public Decimal IvaGN
        {
            get { return ivaGN; }
            set { ivaGN = value; }
        }
        public Decimal IvaRD
        {
            get { return ivaRD; }
            set { ivaRD = value; }
        }
        public Decimal IvaTotal
        {
            get { return ivaTotal; }
            set { ivaTotal = value; }
        }
        public Decimal TotalNeto
        {
            get { return totalNeto; }
            set { totalNeto = value; }
        }
        public Decimal TotalBase
        {
            get { return totalBase; }
            set { totalBase = value; }
        }
        public Decimal DescuentoItems
        {
            get { return descuentoItems; }
            set { descuentoItems = value; }
        }
        public Decimal CostoNacional
        {
            get { return costoNacional; }
            set { costoNacional = value; }
        }
        public Decimal CostoImportado
        {
            get { return costoImportado; }
            set { costoImportado = value; }
        }
        public Decimal BaseNacional
        {
            get { return baseNacional; }
            set { baseNacional = value; }
        }
        public Decimal BaseImportada
        {
            get { return baseImportada; }
            set { baseImportada = value; }
        }
        public string FacturaAfectada
        {
            get { return facturaAfectada; }
            set { facturaAfectada = value; }
        }
        public string NumeroFiscalAfectado
        {
            get { return numeroFiscalAfectado; }
            set { numeroFiscalAfectado = value; }
        }
        public string HoraAfectada
        {
            get { return horaAfectada; }
            set { horaAfectada = value; }
        }
        public string FechaAfectada
        {
            get { return fechaAfectada; }
            set { fechaAfectada = value; }
        }
        public string EocAfectado
        {
            get { return eocAfectado; }
            set { eocAfectado = value; }
        }
        public string CorrelativoInterno
        {
            get { return correlativoInterno; }
            set { correlativoInterno = value; }
        }
        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }
        public DateTime FechaFactura
        {
            get { return fechaFactura; }
            set { fechaFactura = value; }
        }
        public decimal DescuentoGeneral
        {
            get { return descuentoGeneral; }
            set { descuentoGeneral = value; }
        }
        public int PlazoDias
        {
            get { return plazoDias; }
            set { plazoDias = value; }
        }
        public string Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }
        public string Divisa
        {
            get { return divisa; }
            set { divisa = value; }
        }
        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; }
        }
        public int MaximaCantidadDetalles
        {
            get { return maximaCantidadDetalles; }
            set { maximaCantidadDetalles = value; }
        }
        public DataGridView DgvItems
        {
            get { return dgvItems; }
            set { dgvItems = value; }
        }
        public Clientes ClienteFacturar
        {
            get { return clienteFacturar; }
            set { clienteFacturar = value; }
        }
        public Vendedor VendedorFactura
        {
            get { return vendedorFactura; }
            set { vendedorFactura = value; }
        }
        public string NumeroFiscal
        {
            get { return numeroFiscal; }
            set { numeroFiscal = value; }
        }
        public string ModeloImpresora
        {
            get { return modeloImpresora; }
            set { modeloImpresora = value; }
        }
        public string SerieImpresora
        {
            get { return serieImpresora; }
            set { serieImpresora = value; }
        }
        public string Dcli_aprob1
        {
            get { return dcli_aprob1; }
            set { dcli_aprob1 = value; }
        }
        public string Dcli_aprob2
        {
            get { return dcli_aprob2; }
            set { dcli_aprob2 = value; }
        }
        public string Dcli_aprob3
        {
            get { return dcli_aprob3; }
            set { dcli_aprob3 = value; }
        }
        public string Dcli_estado
        {
            get { return dcli_estado; }
            set { dcli_estado = value; }
        }
        public string Dcli_expexp
        {
            get { return dcli_expexp; }
            set { dcli_expexp = value; }
        }
        public string Ctd_codcta
        {
            get { return ctd_codcta; }
            set { ctd_codcta = value; }
        }

        public string NumeroPedido
        {
            get { return numeroPedido; }
            set { numeroPedido = value; }
        }
        public string DireccionEnvio
        {
            get { return direccionEnvio; }
            set { direccionEnvio = value; }
        }
        public string DirObra
        {
            get { return dirObra; }
            set { dirObra = value; }
        }
        public string Certificado
        {
            get { return certificado; }
            set { certificado = value; }
        }
        public string NombreReporte
        {
            get { return nombreReporte; }
            set { nombreReporte = value; }
        }

        #endregion


        public Factura(int timeOut)
        {
            databaseConection = new ConexionBD(Convert.ToString(timeOut));
            sentenciaSql = null;
            this.dcli_aprob1 = "";
            this.dcli_aprob2 = "";
            this.dcli_aprob3 = "";
            this.vendedorFactura = new Vendedor();
        }

        public Factura(int timeOut, string tipo, string ip)
        {
            databaseConection = new ConexionBD(Convert.ToString(timeOut));
            sentenciaSql = null;
            this.tipoDocumento = tipo;
            //para obtener modeloFiscal
            obtenerModeloFiscal(ip);
            getFacturaAfectada();
            this.dcli_aprob1 = "";
            this.dcli_aprob2 = "";
            this.dcli_aprob3 = "";
            this.vendedorFactura = new Vendedor();
        }

        public Factura()
        {
            databaseConection = new ConexionBD();
            sentenciaSql = null;
            this.dcli_aprob1 = "";
            this.dcli_aprob2 = "";
            this.dcli_aprob3 = "";
            this.vendedorFactura = new Vendedor();
        }

        public Factura(string tipo, string ipMaquina)
        {
            databaseConection = new ConexionBD();
            sentenciaSql = null;
            this.tipoDocumento = tipo;
            //para obtener modeloFiscal
            obtenerModeloFiscal(ipMaquina);
            getFacturaAfectada();
            this.dcli_aprob1 = "";
            this.dcli_aprob2 = "";
            this.dcli_aprob3 = "";
            obtenerCtd_Codcta();
            this.vendedorFactura = new Vendedor();
        }


        public DataTable lbxFact(string caja) {
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = null;
            sentenciaSql = "";

            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdoccli2  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdoccli2.dcli_codigo  " +
                                "WHERE  dcli_tipdoc='FAV' AND dcli_caja='$numCaja' AND " +
                                " dcli_cerrado!='1'" +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
            
            sentenciaSql = sentenciaSql.Replace("$numCaja", caja);
            dt = databaseConection.fDataTable(sentenciaSql,200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable lbxDev(string caja)
        {
            sentenciaSql = null;
            DataTable dt;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdoccli2  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdoccli2.dcli_codigo  " +
                                "WHERE  dcli_tipdoc= 'DEV' AND dcli_caja='$numCaja' AND " +
                                " dcli_cerrado!='1'" +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";

            sentenciaSql = sentenciaSql.Replace("$numCaja", caja);
            dt = databaseConection.fDataTable(sentenciaSql, 200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable facturaBuscada(string numero,string tipoDocumento) {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccli  "+
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccli.dcli_codigo  " +
                                  "WHERE  dcli_numero LIKE '%$1%'  OR dcli_numfis LIKE '%$1%' "+
                                  "OR admclientes.cli_nombre LIKE '%$1%' AND dcli_tipdoc='$dcli_tipdoc';";
            sentenciaSql = sentenciaSql.Replace("$1", numero);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", tipoDocumento);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable facturaBuscada2(string fecha1,string fecha2, string tipoDoc)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccli  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccli.dcli_codigo  " +
                                  "WHERE dcli_fecha BETWEEN '$fecha1' AND  '$fecha2' AND dcli_tipdoc='$t';";
            sentenciaSql = sentenciaSql.Replace("$fecha1", fecha1);
            sentenciaSql = sentenciaSql.Replace("$fecha2", fecha2);
            sentenciaSql = sentenciaSql.Replace("$t", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        //public string obtenerCorrelativo(string tipoDoc) {
        //    string correlativo = null;
        //    DataTable dt;

        //    sentenciaSql = "SELECT ctd_correlativo FROM admtipdoccli WHERE ctd_tipo='$1'";
        //    sentenciaSql = sentenciaSql.Replace("$1", tipoDoc);
        //    dt = databaseConection.fDataTable(sentenciaSql);
        //    if (dt.Rows.Count > 0) {
        //        correlativo = String.Format("{0:000000000000}", Convert.ToDouble(dt.Rows[0]["ctd_correlativo"].ToString()) + 1);
        //    }
        //    databaseConection.cerrarConexion();
        //    if (tipoDoc.Equals("FAV")) {
        //        this.correlativoInterno = correlativo;
        //    }
        //    if (tipoDoc.Equals("DEV"))
        //    {
        //        this.correlativoInterno = correlativo;
        //    }
        //    return correlativo;
        //}

        public string obtenerCorrelativo(string tipoDoc)
        {
            string correlativo = null;
            MySqlDataReader dr;

            sentenciaSql = "SELECT ctd_correlativo FROM admtipdoccli WHERE ctd_tipo='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", tipoDoc);
            dr = databaseConection.ejecutarQueryDr(sentenciaSql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        correlativo = (Convert.ToDouble(dr.GetString(0)) + 1).ToString().PadLeft(12, '0');
                    }
                }
            }
            dr.Close();
            databaseConection.cerrarConexion();
            this.correlativoInterno = correlativo;
            return correlativo;
        }

        public void acumularBases(decimal precio, string iva) {
            switch (iva) { 
                case"EX":
                    this.baseEX = this.baseEX + precio;
                    break;
                case "GN":
                    this.baseGN = this.baseGN + precio;
                    break;
                case "RD":
                    this.baseRD = this.baseRD + precio;
                    break;
            }
        }
        
        //esta igual que acumular bases solo que las resta segun el monto pasado
        public void restarBases(decimal precio,string iva) {
            switch (iva)
            {
                case "EX":
                    this.baseEX = this.baseEX - precio;
                    break;
                case "GN":
                    this.baseGN = this.baseGN - precio;
                    break;
                case "RD":
                    this.baseRD = this.baseRD - precio;
                    break;
            }
        }
        
        public void acumularIvas(decimal precio, string iva) {
            sentenciaSql = null;
            DataTable dt;
            decimal valorAliventa = 0;
            decimal ivaAcumular = 0;

            sentenciaSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", iva);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["alict_venta"].ToString()))) / 100);
            }
            ivaAcumular = (Truncate((precio * valorAliventa), 2)) - precio;
            //aqui ya teniendo el precio del producto se acumula el iva
            //switch (iva) { 
            //    case "GN":
            //        ivaGN = ivaGN + ivaAcumular;
            //        ivaTotal = ivaTotal + ivaAcumular;
            //    break;
            //    case "RD":
            //        ivaRD = ivaRD + ivaAcumular;
            //        ivaTotal = ivaTotal + ivaAcumular;
            //    break;
            //}   

            switch (iva)
            {
                case "GN":
                    ivaGN = ivaAcumular;
                    ivaTotal = ivaGN+ivaRD;
                    break;
                case "RD":
                    ivaRD = ivaAcumular;
                    ivaTotal = ivaGN + ivaRD;
                    break;
                case "A":
                    ivaRD = ivaAcumular;
                    ivaTotal = ivaGN + ivaRD;
                    break;
            }
            databaseConection.cerrarConexion();
       }

        //esta es una copia de la funcion anterior solo que se dedica a restar ivas
        public void restarIvas(decimal precio, string iva)
        {
            sentenciaSql = null;
            DataTable dt;
            decimal valorAliventa = 0;
            decimal ivaAcumular = 0;

            sentenciaSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", iva);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["alict_venta"].ToString()))) / 100);
            }
            ivaAcumular = (Truncate((precio * valorAliventa), 2)) - precio;
            //aqui ya teniendo el precio del producto se acumula el iva
            switch (iva)
            {
                case "GN":
                    ivaGN = ivaGN - ivaAcumular;
                    ivaTotal = ivaTotal - ivaAcumular;
                    break;
                case "RD":
                    ivaRD = ivaRD - ivaAcumular;
                    ivaTotal = ivaTotal - ivaAcumular;
                    break;
                case "A":
                    ivaRD = ivaAcumular;
                    ivaTotal = ivaGN + ivaRD;
                    break;
            }
        }


        //private decimal Truncate(decimal pImporte, int pNumDecimales)
        //{
        //    decimal wRt = 0;
        //    decimal wPot10 = 1;

        //    for (int i = 1; i <= pNumDecimales; i++)
        //    {
        //        wPot10 = wPot10 * 10;
        //    }

        //    wRt = pImporte * wPot10;
        //    wRt = decimal.Truncate(wRt);
        //    wRt = wRt / wPot10;
        //    wRt = decimal.Round(wRt, 2);

        //    return wRt;
        //}

        //Modificada para redondear al 3 decimal por eso la modicacion 02:27 p.m. 15/07/2013
        private decimal Truncate(decimal pImporte, int pNumDecimales)
        {
            decimal wRt = 0;
            decimal wPot10 = 1;
            //Decimal.Round2
            //for (int i = 1; i <= pNumDecimales; i++)
            for (int i = 1; i <= 3; i++)
            {
                wPot10 = wPot10 * 10;
            }

            wRt = pImporte * wPot10;
            wRt = decimal.Truncate(wRt);
            wRt = wRt / wPot10;
            //wRt = decimal.Round(wRt, 2);
            wRt = Decimal.Round(wRt, 2, MidpointRounding.AwayFromZero);

            return wRt;
        }

        public int guardarCabecera()
        {
            int respuesta = 0;

            if ((this.correlativoInterno == "") || (this.correlativoInterno == null))
                return -666;
            respuesta = databaseConection.ejecutarInsert2(sentenciaSql);
            while (respuesta == 1213)
            {
                respuesta = databaseConection.ejecutarInsert2(sentenciaSql);
            }
            databaseConection.cerrarConexion();
            return respuesta;
        }


        public void acumularCostos(Decimal costoPromedio,int cantidad,string procedencia) {
            switch (procedencia) { 
                case "Nacional":
                    this.costoNacional = this.costoNacional + (Truncate((costoPromedio * cantidad), 2));
                    break;
                case "Importado":
                    this.costoImportado = this.costoImportado+(Truncate((costoPromedio*cantidad),2));
                    break;
            }
        }

        public void restarCosto(Decimal costoPromedio, int cantidad, string procedencia) {
            switch (procedencia) {
                case "Nacional":
                    this.costoNacional = this.costoNacional - (Truncate((costoPromedio * cantidad), 2));
                    break;
                case "Importado":
                    this.costoImportado = this.costoImportado - (Truncate((costoPromedio * cantidad), 2));
                    break;
            }
        }

        public void acumularBases2(int cantidad, Decimal precio, string procedencia) {
            switch (procedencia) { 
                case "Nacional":
                    this.baseNacional = this.baseNacional + (Truncate((precio * cantidad), 2));
                    break;
                case "Importado":
                    this.baseImportada = this.baseImportada + (Truncate((precio * cantidad), 2));
                    break;
            }
        }

        public void restarBases2(int cantidad, Decimal precio, string procedencia) {
            switch (procedencia)
            {
                case "Nacional":
                    this.baseNacional = this.baseNacional - (Truncate((precio * cantidad), 2));
                    break;
                case "Importado":
                    this.baseImportada = this.baseImportada - (Truncate((precio * cantidad), 2));
                    break;
            }
        }

        public void aumentarCorrelativo(string tipoDoc,string numero) {
            string  sentenciaSql1 = null;
            bool centinela = false;
            double tempCorrelativo = 0;
            double resta = 0;
            DataTable dt;

            sentenciaSql1 = "SELECT ctd_correlativo FROM admtipdoccli WHERE ctd_tipo='" + tipoDoc + "';";
            dt = databaseConection.fDataTable(sentenciaSql1);
            if (dt.Rows.Count > 0) {
                tempCorrelativo = Convert.ToDouble(dt.Rows[0]["ctd_correlativo"].ToString());
                resta = tempCorrelativo - (Convert.ToDouble(numero));
                if (resta < 0) { 
                    sentenciaSql1 = "UPDATE admtipdoccli SET ctd_correlativo ='" + "" + (String.Format("{0:000000000000}",(tempCorrelativo+(resta*-1)))) + "'" +
                                  "WHERE ctd_tipo ='" + tipoDoc + "'";
                    centinela = databaseConection.ejecutarInsert(sentenciaSql1);
                }
            }
            if (resta == 0)
            {
                sentenciaSql1 = null;
                sentenciaSql1 = "UPDATE admtipdoccli SET ctd_correlativo ='" + "" + (String.Format("{0:000000000000}", Convert.ToDouble(numero) + 1)) + "'" +
                                      "WHERE ctd_tipo ='" + tipoDoc + "'";

                centinela = databaseConection.ejecutarInsert(sentenciaSql1);
            }
            if (resta > 0) {
                sentenciaSql1 = null;
                sentenciaSql1 = "UPDATE admtipdoccli SET ctd_correlativo ='" + "" + (String.Format("{0:000000000000}", Convert.ToDouble(numero) + resta)) + "'" +
                                     "WHERE ctd_tipo ='" + tipoDoc + "'";
                centinela = databaseConection.ejecutarInsert(sentenciaSql1);
            }

            databaseConection.cerrarConexion();
        }

        public void crearSentenciaCabecera(Clientes clienteFactura, Vendedor vendedorFactura,string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                            string cambio, string pagado, string contado) {
                sentenciaSql = null;

                sentenciaSql = "INSERT INTO admdoccli " +
                                      "(dcli_cbtnum,dcli_cencos,dcli_codigo,dcli_codmon,dcli_sucursal, " +
                                      "dcli_transpo,dcli_codven,dcli_condic,dcli_destino,dcli_origen, " +
                                      "dcli_estado,dcli_expexp,dcli_facafe,dcli_girnum,dcli_hora, " +
                                      "dcli_modfis,dcli_numero,dcli_numfis,dcli_numgtr,dcli_plaexp,  " +
                                      "dcli_recnum,dcli_serfis,dcli_succli,dcli_tipafe,dcli_tipdoc, " +
                                      "dcli_tiptra,dcli_usuario,dcli_zona,dcli_fecharecep,dcli_fchven, " +
                                      "dcli_fecha,dcli_anufis,dcli_crerecibo,dcli_impreso,dcli_invmon,  " +
                                      "dcli_estatus,dcli_baseneta,dcli_cxc,dcli_dcto,dcli_otroimp, " +
                                      "dcli_mtocomisio,dcli_mtoiva,dcli_neto,dcli_numpag,dcli_otros,dcli_plazo, " +
                                      "dcli_recargo,dclli_valcamb,dcli_dctobs,dcli_totdivi,dcli_descitem, " +
                                      "dcli_descdoc,dcli_subbase,doc_impo,dcli_cantproduc,dcli_aprob1, " +
                                      "dcli_aprob2, dcli_aprob3,dcli_impresora,dcli_caja, dcli_cerrado, " +
                                      "dcli_cosfac, dcli_cosfac_n,dcli_cosfac_i,dcli_base_n,dcli_base_i, " +
                                      "dcli_saldo, dcli_facafe2,dcli_subtotal,dcli_ivaGN,dcli_ivaRD) VALUES (" +
                                      "'$dcli_cbtnum','$dcli_cencos','$dcli_codigo','$dcli_codmon','$dcli_sucursal', " +
                                      "'$dcli_transpo','$dcli_codven','$dcli_condic','$dcli_destino','$dcli_origen', " +
                                      "'$dcli_estado','$dcli_expexp','$dcli_facafe','$dcli_girnum','$dcli_hora', " +
                                      "'$dcli_modfis','$dcli_numero','$dcli_numfis','$dcli_numgtr','$dcli_plaexp', " +
                                      "'$dcli_recnum','$dcli_serfis','$dcli_succli','$dcli_tipafe','$dcli_tipdoc', " +
                                      "'$dcli_tiptra','$dcli_usuario','$dcli_zona','$dcli_fecharecep','$dcli_fchven', " +
                                      "'$dcli_fecha','$dcli_anufis','$dcli_crerecibo','$1dcli_impreso','$dcli_invmon', " +
                                      "'$dcli_estatus','$dcli_baseneta','$dcli_cxc','$1dcli_dcto','$dcli_otroimp', " +
                                      "'$dcli_mtocomisio','$dcli_mtoiva','$dcli_neto','$dcli_numpag','$dcli_otros', " +
                                      "'$dcli_plazo','$dcli_recargo','$dclli_valcamb','$dcli_dctobs','$dcli_totdivi', " +
                                      "'$dcli_descitem','$dcli_descdoc','$dcli_subbase','$doc_impo','$dcli_cantproduc', " +
                                      "'$dcli_aprob1','$dcli_aprob2','$dcli_aprob3','$dcli_impresora','$dcli_caja', " +
                                      "'$dcli_cerrado','$dcli_cosfac','$5dcli_cosfac_n','$3dcli_cosfac_i','$1dcli_base_n', " +
                                      "'$2dcli_base_i','$dcli_saldo','$1dcli_facafe2',$dcli_subtotal,$?dcli_ivaGN,$?dcli_ivaRD);";

                sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
                sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
                sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
                sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000"+codigoEmpresaActual);
                sentenciaSql = sentenciaSql.Replace("$dcli_transpo", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
                sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
                sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
                sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
                sentenciaSql = sentenciaSql.Replace("$dcli_estado", this.dcli_estado /*this.dcli_expexp*/);
                sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
                if (this.dcli_expexp != null)
                {
                    this.update_expexp();
                }
                sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV")?this.correlativoInterno:this.facturaAfectada)); 
                sentenciaSql = sentenciaSql.Replace("$dcli_girnum", " ");   
                sentenciaSql = sentenciaSql.Replace("$dcli_hora", DateTime.Now.ToString("hh:mm:ss tt"));
                sentenciaSql = sentenciaSql.Replace("$dcli_modfis", " ");//obtener el modelo de la impresora fiscal
                sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
                sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
                if (this.tipoDocumento.Equals("FAV"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
                }
                if (this.tipoDocumento.Equals("DEV"))
                {
                    if (this.numeroFiscalAfectado != null)
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", this.numeroFiscalAfectado);
                    }
                    else {
                        sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
                    }
                }
                sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
                sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");

                if (this.tipoDocumento.Equals("FAV") || this.tipoDocumento.Equals("DEV"))
                {
                sentenciaSql = sentenciaSql.Replace("$dcli_tipafe","FAV");//si es fav o dev = fav si es igual a CTZ va a ser igual a CTZ
                }
                if (this.tipoDocumento.Equals("CTZ"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "CTZ");//si es fav o dev = fav si es igual a CTZ va a ser igual a CTZ
                }
                sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
                if (this.tipoDocumento.Equals("FAV"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", "D");
                }
                if (this.tipoDocumento.Equals("DEV")) {
                    sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", "C");
                }
                sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codigoUsuario);
                sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_fecharecep", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
                sentenciaSql = sentenciaSql.Replace("$dcli_fchven", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
                sentenciaSql = sentenciaSql.Replace("$dcli_fecha", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
                sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
                sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
                sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
                sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
                sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
                if (this.tipoDocumento.Equals("FAV") || this.tipoDocumento.Equals("CTZ"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "1");
                }
                if (this.tipoDocumento.Equals("ABO") || this.tipoDocumento.Equals("DEV"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
                }
                sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
                sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
                sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
                sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
                sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
                sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
                sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
                sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
                sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",","."));
                //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
                sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
                sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
                sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
                sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
                sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
                sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
                sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
                sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
                if (this.dcli_estado.Equals("Activo"))
                {
                    if (this.tipoDocumento.Equals("FAV")){
                        sentenciaSql = sentenciaSql.Replace("$dcli_saldo", (Convert.ToString((-1) * (Convert.ToDecimal((pagado.Replace(".", ","))) - (Convert.ToDecimal(contado.Replace(".", ","))))).Replace(",", ".")));
                    }

                    if (this.tipoDocumento.Equals("DEV")) {
                        sentenciaSql = sentenciaSql.Replace("$dcli_saldo", Convert.ToString((Convert.ToDecimal(pagado.Replace(".", ","))) - (Convert.ToDecimal(contado.Replace(".", ",")))).Replace(",", "."));
                    }
                    
                }
                if (this.dcli_estado.Equals("Pagado"))
                {
                    sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
                }
                
                sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
                sentenciaSql = sentenciaSql.Replace("$dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
                sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
        }


        public void cargarFactura(string numeroInter,Clientes clientF, Vendedor vend1) {
            DataTable dtFactura;
            sentenciaSql = null;

            sentenciaSql = "SELECT dcli_codigo, dcli_codmon, dcli_codven, dcli_condic, dcli_facafe, "+
                "dcli_tipafe,dcli_tipdoc,dcli_invmon,dcli_baseneta,dcli_descitem, "+
                "dcli_subbase,doc_impo,TRUNCATE(dcli_cantproduc,0) 'dcli_cantproduc' ,dcli_cosfac_n,dcli_cosfac_i, " +
                "dcli_base_n,dcli_base_i,dcli_saldo,dcli_subtotal,dcli_ivaRD, "+
                "dcli_ivaGN, dcli_estado "+
                "FROM admdoccli WHERE dcli_numero='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", numeroInter);
            dtFactura = databaseConection.fDataTable(sentenciaSql);

            if (dtFactura.Rows.Count > 0) {
                clientF.Codigo = dtFactura.Rows[0]["dcli_codigo"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_codmon"].ToString();
                vend1.CodigoV = dtFactura.Rows[0]["dcli_codven"].ToString();
                clientF.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.correlativoInterno = numeroInter;
                this.facturaAfectada = dtFactura.Rows[0]["dcli_facafe"].ToString();
                this.TipoDocumento = dtFactura.Rows[0]["dcli_tipdoc"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_invmon"].ToString();
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_baseneta"].ToString().Replace(".",","));
                this.DescuentoItems = Convert.ToDecimal(dtFactura.Rows[0]["dcli_descitem"].ToString().Replace(".", ","));
                this.BaseEX = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subbase"].ToString().Replace(".", ","));
                this.baseGN = Convert.ToDecimal(dtFactura.Rows[0]["doc_impo"].ToString().Replace(".", ","));
                this.totalItems = Int32.Parse(dtFactura.Rows[0]["dcli_cantproduc"].ToString());
                this.CostoNacional = Convert.ToDecimal(Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_n"].ToString().Replace(".", ",")));
                this.CostoImportado = Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_i"].ToString().Replace(".", ","));
                this.BaseNacional = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_n"].ToString().Replace(".", ","));
                this.BaseImportada = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_i"].ToString().Replace(".", ","));
                this.TotalNeto = Convert.ToDecimal(dtFactura.Rows[0]["dcli_saldo"].ToString().Replace(".", ","));
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subtotal"].ToString().Replace(".", ","));
                this.ivaRD = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaRD"].ToString().Replace(".", ","));
                this.ivaGN = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaGN"].ToString().Replace(".", ","));
                this.dcli_estado = dtFactura.Rows[0]["dcli_estado"].ToString();
            }
            databaseConection.cerrarConexion();
        }

        public void guardarDetalleFac(DataGridView detalles) {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[52];

            sentenciaEnviar = "INSERT INTO adminvmov ( "+
                                      "mov_docaso,mov_tipoaso,mov_cencos,mov_codalm,mov_cdcomp,  "+
                                      "mov_codcta,mov_codigo,mov_codsuc,mov_codtra,mov_vendedor, "+
                                      "mov_docume,mov_hora,mov_item,mov_itemaso,mov_itemcomp, "+
                                      "mov_lista,mov_lote,mov_tipdoc,mov_ivatip,mov_tipo,mov_undmed, "+
                                      "mov_usuario,mov_fechven,mov_fecha,mov_bandas,mov_cant, "+
                                      "mov_contab,mov_costo,mov_cxund,mov_desc,mov_expendio, "+
                                      "mov_export,mov_fisico,mov_import,mov_otimp,mov_impprodu, "+
                                      "mov_invact,mov_iva,mov_logico,mov_mtocom,mov_memo, "+
                                      "mov_precio,mov_total,mov_talla,mov_color,mov_arancel, "+
                                      "mov_kilos,mov_impuesto,mov_cosmon,mov_totalmon,mov_precio_ini, "+
                                      "mov_porciva) VALUES( "+
                                      "@mov_docaso,@mov_tipoaso,@mov_cencos,@mov_codalm,@mov_cdcomp, "+
                                      "@mov_codcta,@mov_codigo,@mov_codsuc,@mov_codtra,@mov_vendedor, " +
                                      "@mov_docume,@mov_hora,@mov_item,@mov_itemaso,@mov_itemcomp, "+
                                      "@mov_lista,@mov_lote,@mov_tipdoc,@mov_ivatip,@mov_tipo, "+
                                      "@mov_undmed,@mov_usuario,@mov_fechven,@mov_fecha,@mov_bandas, "+
                                      "@mov_cant,@mov_contab,@mov_costo,@mov_cxund,@mov_desc, "+
                                      "@mov_expendio,@mov_export,@mov_fisico,@mov_import,@mov_otimp, "+
                                      "@mov_impprodu,@mov_invact,@mov_iva,@mov_logico,@mov_mtocom, "+
                                      "@mov_memo,@mov_precio,@mov_total,@mov_talla,@mov_color, "+
                                      "@mov_arancel,@mov_kilos,@mov_impuesto,@mov_cosmon,@mov_totalmon, "+
                                      "@mov_precio_ini,@mov_porciva);";

            parametrosEnviar[0] = "mov_docaso";
            parametrosEnviar[1] = "mov_tipoaso";
            parametrosEnviar[2] = "mov_cencos";
            parametrosEnviar[3] = "mov_codalm";
            parametrosEnviar[4] = "mov_cdcomp";
            parametrosEnviar[5] = "mov_codcta";
            parametrosEnviar[6] = "mov_codigo";
            parametrosEnviar[7] = "mov_codsuc";
            parametrosEnviar[8] = "mov_codtra";
            parametrosEnviar[9] = "mov_vendedor";
            parametrosEnviar[10] ="mov_docume";
            parametrosEnviar[11] ="mov_hora";
            parametrosEnviar[12] ="mov_item";
            parametrosEnviar[13] ="mov_itemaso";
            parametrosEnviar[14] ="mov_itemcomp";
            parametrosEnviar[15] ="mov_lista";
            parametrosEnviar[16] ="mov_lote";
            parametrosEnviar[17] ="mov_tipdoc";
            parametrosEnviar[18] ="mov_ivatip";
            parametrosEnviar[19] ="mov_tipo";
            parametrosEnviar[20] ="mov_undmed";
            parametrosEnviar[21] ="mov_usuario";
            parametrosEnviar[22] ="mov_fechven";
            parametrosEnviar[23] ="mov_fecha";
            parametrosEnviar[24] ="mov_bandas";
            parametrosEnviar[25] ="mov_cant";
            parametrosEnviar[26] ="mov_contab";
            parametrosEnviar[27] ="mov_costo";
            parametrosEnviar[28] ="mov_cxund";
            parametrosEnviar[29] ="mov_desc";
            parametrosEnviar[30] ="mov_expendio";
            parametrosEnviar[31] ="mov_export";
            parametrosEnviar[32] ="mov_fisico";
            parametrosEnviar[33] ="mov_import";
            parametrosEnviar[34] ="mov_otimp";
            parametrosEnviar[35] ="mov_impprodu";
            parametrosEnviar[36] ="mov_invact";
            parametrosEnviar[37] ="mov_iva";
            parametrosEnviar[38] ="mov_logico";
            parametrosEnviar[39] ="mov_mtocom";
            parametrosEnviar[40] ="mov_memo";
            parametrosEnviar[41] ="mov_precio";
            parametrosEnviar[42] ="mov_total";
            parametrosEnviar[43] ="mov_talla";
            parametrosEnviar[44] ="mov_color";
            parametrosEnviar[45] ="mov_arancel";
            parametrosEnviar[46] ="mov_kilos";
            parametrosEnviar[47] ="mov_impuesto";
            parametrosEnviar[48] ="mov_cosmon";
            parametrosEnviar[49] = "mov_totalmon";
            parametrosEnviar[50] = "mov_precio_ini";
            parametrosEnviar[51] = "mov_porciva";
            //MessageBox.Show(detalles.Rows[0].Cells["mov_precio_ini"].Value.ToString());
            databaseConection.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            databaseConection.cerrarConexion();
        }

        public void obtenerMaximaCantidadItemsFAV() {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ctd_items FROM admtipdoccli WHERE ctd_tipo = 'FAV'";
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                this.maximaCantidadDetalles = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            databaseConection.cerrarConexion();
        }

        public void maximaCantidadItems(string tipo) {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ctd_items FROM admtipdoccli WHERE ctd_tipo = '$1'";
            sentenciaSql= sentenciaSql.Replace("$1",tipo);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                this.maximaCantidadDetalles = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            databaseConection.cerrarConexion();
        }

        public void limpiarFactura()
        {
            this.baseGN = 0;
            this.baseEX = 0;
            this.baseRD = 0;
            this.ivaGN = 0;
            this.ivaRD = 0;
            this.ivaTotal = 0;
            this.totalNeto = 0;
            this.totalBase = 0;
            this.descuentoItems = 0;
            this.costoNacional = 0;
            this.costoImportado = 0;
            this.baseNacional = 0;
            this.baseImportada = 0;
            this.facturaAfectada = null;
            this.correlativoInterno = null;
            this.descuentoGeneral = 0;
            this.plazoDias = 0;
            this.condicion = null;
            this.divisa = null;
            this.totalItems = 0;
            this.dcli_aprob1 = null;
            this.dcli_aprob2 = null;
            this.direccionEnvio = null;
            this.numeroPedido = null;
            this.estatus = null;
            this.diasPP1 = null;
            this.diasPP2 = null;
            this.porcentajePP1 = null;
            this.porcentajePP2 = null;
            obtenerMaximaCantidadItemsFAV();
        }



       

        public bool guardarSalcli(Clientes clienteFactura, Vendedor vendedorFactura,string codigoEmpresaActual, string codigoUsuario, string codCaja, TextBox txtPagado, TextBox txtContado) {
            bool centinela = false;
            sentenciaSql = null;
            sentenciaSql = "INSERT INTO admsalcli (" +
                                  "cli_codigo,sal_actual,TipoDoc,NroDocum,CodVend," +
                                  "FechaEmision,FechaVenc,FechaCarga,MontoTotal,MontoCob," +
                                  "CostoFact,MontoNac,MontoImp,NroCaja,CondPago," +
                                  "MontoIva,dcli_cosfac_n,dcli_cosfac_i,dcli_facafe,dcli_tipdoc2," +
                                  "dcli_numfis,Status) VALUES(" +
                                  "'@cli_codigo',@sal_actual,'@TipoDoc','@NroDocum','@CodVend'," +
                                  "'@FechaEmision','@FechaVenc','@FechaCarga',@MontoTotal,@MontoCob," +
                                  "@CostoFact,@MontoNac,@MontoImp,'@NroCaja','@CondPago'," +
                                  "@MontoIva,@dcli_cosfac_n,@dcli_cosfac_i,'@dcli_facafe','@dcli_tipdoc2'," +
                                  "'@dcli_numfis',@Status);";

            DateTime diaVen = DateTime.Now.AddDays(this.plazoDias);
            sentenciaSql = sentenciaSql.Replace("@cli_codigo", clienteFactura.Codigo);
            if (this.tipoDocumento.Equals("FAV"))
            {
                sentenciaSql = sentenciaSql.Replace("@sal_actual", (Convert.ToString((-1) * (Convert.ToDecimal((txtPagado.Text.Replace(".", ","))) - (Convert.ToDecimal(txtContado.Text.Replace(".", ","))))).Replace(",", ".")));
            }
            if (this.tipoDocumento.Equals("DEV"))
            {
                sentenciaSql = sentenciaSql.Replace("@sal_actual", Convert.ToString((Convert.ToDecimal(txtPagado.Text.Replace(".", ","))) - (Convert.ToDecimal(txtContado.Text.Replace(".", ",")))).Replace(",", "."));
            }
            sentenciaSql = sentenciaSql.Replace("@TipoDoc", this.tipoDocumento);
            sentenciaSql = sentenciaSql.Replace("@NroDocum", this.correlativoInterno);
            sentenciaSql = sentenciaSql.Replace("@CodVend", vendedorFactura.CodigoV);
            sentenciaSql = sentenciaSql.Replace("@FechaEmision", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("@FechaVenc", "" + diaVen.Year + "-" + diaVen.Month + "-" + diaVen.Day);
            sentenciaSql = sentenciaSql.Replace("@FechaCarga", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("@MontoTotal", txtContado.Text.Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("@MontoCob", txtContado.Text.Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("@CostoFact", (Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", ".")));
            sentenciaSql = sentenciaSql.Replace("@MontoNac", (Convert.ToString(this.CostoNacional).Replace(",",".")));
            sentenciaSql = sentenciaSql.Replace("@MontoImp", (Convert.ToString(this.CostoImportado).Replace(",", ".")));
            sentenciaSql = sentenciaSql.Replace("@NroCaja", codCaja);
            sentenciaSql = sentenciaSql.Replace("@CondPago", clienteFactura.CodigoCondicionPago);
            sentenciaSql = sentenciaSql.Replace("@MontoIva", Convert.ToString(this.IvaTotal).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("@dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("@dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("@dcli_facafe", this.correlativoInterno);
            sentenciaSql = sentenciaSql.Replace("@dcli_tipdoc2", this.tipoDocumento);
            sentenciaSql = sentenciaSql.Replace("@dcli_numfis", " ");
            sentenciaSql = sentenciaSql.Replace("@Status", "0");

            centinela = databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
            return centinela;
        }

        public void guardarNumeroFiscalSalcli() {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admsalcli SET dcli_numfis='@dcli_numfis' WHERE NroDocum='@NroDocum';";
            sentenciaSql = sentenciaSql.Replace("@dcli_numfis", this.numeroFiscal);
            sentenciaSql = sentenciaSql.Replace("@NroDocum", this.correlativoInterno);
            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        //como el numero fiscal solo lo otorga cuando se imprime es el momento adecuado para guardar el modelo de la misma
        public void guardarNumeroFiscal()
        {
            sentenciaSql = null;
            if (this.tipoDocumento.Equals("DEV"))
            {
                sentenciaSql = "UPDATE admdoccli SET dcli_numfis='@dcli_numfis', dcli_numgtr='@dcli_numgtr', dcli_impresora='@dcli_impresora'  ,dcli_impreso='1', dcli_modfis='@dcli_modfis' WHERE dcli_numero='@dcli_numero'";
                sentenciaSql = sentenciaSql.Replace("@dcli_numfis", this.numeroFiscal);
                sentenciaSql = sentenciaSql.Replace("@dcli_numgtr", this.numeroFiscalAfectado);
                sentenciaSql = sentenciaSql.Replace("@dcli_impresora", this.serieImpresora);
                sentenciaSql = sentenciaSql.Replace("@dcli_numero", this.correlativoInterno);
                sentenciaSql = sentenciaSql.Replace("@dcli_modfis", this.modeloImpresora);
            }

            if (this.tipoDocumento.Equals("FAV")) {
                sentenciaSql = "UPDATE admdoccli SET dcli_numfis='@dcli_numfis', dcli_impresora='@dcli_impresora'  ,dcli_impreso='1', dcli_modfis='@dcli_modfis' WHERE dcli_numero='@dcli_numero'";
                sentenciaSql = sentenciaSql.Replace("@dcli_numfis", this.numeroFiscal);
                sentenciaSql = sentenciaSql.Replace("@dcli_impresora", this.serieImpresora);
                sentenciaSql = sentenciaSql.Replace("@dcli_numero", this.correlativoInterno);
                sentenciaSql = sentenciaSql.Replace("@dcli_modfis", this.modeloImpresora);
            }
            databaseConection.ejecutarInsert(sentenciaSql,200);
            databaseConection.cerrarConexion();
        }

        private void obtenerModeloFiscal(string ip) {
            DataTable dt;
            DataTable dt2;
            sentenciaSql = null;
            sentenciaSql = "SELECT ctd_serief FROM admtipdoccli WHERE ctd_tipo='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", this.tipoDocumento);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                this.serieImpresora = dt.Rows[0]["ctd_serief"].ToString();
            }

            sentenciaSql = null;
            sentenciaSql = "SELECT seri_impresora FROM admseriefiscal WHERE seri_ip = '?' AND seri_act='Si' " +
                                 "AND seri_doc='FAV';";

            sentenciaSql = sentenciaSql.Replace("?", ip);
            dt2 = databaseConection.fDataTable(sentenciaSql);
            if (dt2.Rows.Count > 0) {
                this.modeloImpresora = dt2.Rows[0]["seri_impresora"].ToString();
            }

            databaseConection.cerrarConexion();
        }

        private void getFacturaAfectada() {
            if (this.tipoDocumento.Equals("FAV")) {
                this.facturaAfectada = "FAV";
            }

            if (this.tipoDocumento.Equals("DEV"))
            {
                this.facturaAfectada = "FAV";
            }

            if (this.tipoDocumento.Equals("CTZ"))
            {
                this.facturaAfectada = "CTZ";
            }
        }

        public DataTable itemsFac2(string numeroCliente)
        {
            DataTable dtItems;
            sentenciaSql = null;
            //sentenciaSql = "SELECT mov_docaso,mov_tipoaso,mov_cencos,mov_codalm,mov_cdcomp "+
            //            ",mov_codcta,mov_codsuc,mov_codtra,mov_vendedor,mov_docume "+
            //            ",mov_hora,mov_item,mov_itemaso,mov_itemcomp,mov_lista "+
            //            ",mov_lote,mov_tipdoc,mov_ivatip,mov_tipo,mov_undmed "+
            //            ",mov_usuario,mov_fechven,mov_fecha,mov_bandas,mov_contab "+
            //            ",mov_cxund,mov_expendio,mov_export,mov_fisico,mov_import "+
            //            ",mov_otimp,mov_impprodu,mov_invact,mov_iva,mov_logico "+
            //            ",mov_mtocom,mov_memo,mov_talla,mov_color,mov_arancel "+
            //            ",mov_kilos,mov_impuesto,mov_cosmon,mov_totalmon,mov_precio_ini "+
            //            ",mov_porciva FROM adminvmov WHERE mov_docume='$1';";

            sentenciaSql = "SELECT mov_docaso  'mov_docaso',mov_tipoaso 'mov_tipoaso' ,mov_cencos 'mov_cencos',mov_codalm 'mov_codalm',mov_cdcomp 'mov_cdcomp' " +
            ",mov_codcta 'mov_codcta' ,mov_codsuc 'mov_codsuc',mov_codtra 'mov_codtra' ,mov_vendedor 'mov_vendedor',mov_docume 'mov_docume' " +
            ",mov_hora 'mov_hora',mov_item 'mov_item',mov_itemaso 'mov_itemaso' ,mov_itemcomp 'mov_itemcomp',mov_lista 'mov_lista' " +
            ",mov_lote 'mov_lote',mov_tipdoc 'mov_tipdoc',mov_ivatip 'mov_ivatip',mov_tipo 'mov_tipo' ,mov_undmed 'mov_undmed'" +
            ",mov_usuario 'mov_usuario',mov_fechven 'mov_fechven',mov_fecha 'mov_fecha',mov_bandas 'mov_bandas',mov_contab 'mov_contab' " +
            ",mov_cxund 'mov_cxund',mov_expendio 'mov_expendio',mov_export 'mov_export',mov_fisico 'mov_fisico',mov_import 'mov_import'" +
            ",mov_otimp 'mov_otimp',mov_impprodu 'mov_impprodu',mov_invact 'mov_invact',mov_iva 'mov_iva',mov_logico 'mov_logico' " +
            ",mov_mtocom 'mov_mtocom',mov_memo 'mov_memo',mov_talla 'mov_talla',mov_color 'mov_color',mov_arancel 'mov_arancel' " +
            ",mov_kilos 'mov_kilos',mov_impuesto 'mov_impuesto',mov_cosmon 'mov_cosmon',mov_totalmon 'mov_totalmon',mov_precio_ini 'mov_precio_ini' " +
            ",mov_porciva 'mov_porciva', mov_codigo 'mov_codigo', mov_precio 'mov_precio', inv_descri 'colProducto',mov_total 'mov_total',TRUNCATE(mov_cant,0) 'mov_cant', mov_desc 'mov_desc'  FROM adminvmov " +
            " LEFT JOIN  adminv ON adminv.inv_codigo = adminvmov.mov_codigo WHERE mov_docume='$1' AND mov_codcta='$mov_codcta' AND mov_tipdoc='$mov_tipdoc';";

            sentenciaSql = sentenciaSql.Replace("$1", this.correlativoInterno);
            sentenciaSql = sentenciaSql.Replace("$mov_codcta", numeroCliente);
            sentenciaSql = sentenciaSql.Replace("$mov_tipdoc", this.tipoDocumento);
            dtItems = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dtItems;
        }

        public DataTable itemsFac(string numeroDocumento, string numeroCliente, string tipoDoc)
        {
            DataTable dtItems;
            sentenciaSql = null;

            sentenciaSql = "SELECT mov_docaso  'mov_docaso',mov_tipoaso 'mov_tipoaso' ,mov_cencos 'mov_cencos',mov_codalm 'mov_codalm',mov_cdcomp 'mov_cdcomp' " +
            ",mov_codcta 'mov_codcta' ,mov_codsuc 'mov_codsuc',mov_codtra 'mov_codtra' ,mov_vendedor 'mov_vendedor',mov_docume 'mov_docume' " +
            ",mov_hora 'mov_hora',mov_item 'mov_item',mov_itemaso 'mov_itemaso' ,mov_itemcomp 'mov_itemcomp',mov_lista 'mov_lista' " +
            ",mov_lote 'mov_lote',mov_tipdoc 'mov_tipdoc',mov_ivatip 'mov_ivatip',mov_tipo 'mov_tipo' ,mov_undmed 'mov_undmed'" +
            ",mov_usuario 'mov_usuario',mov_fechven 'mov_fechven',mov_fecha 'mov_fecha',mov_bandas 'mov_bandas',mov_contab 'mov_contab' " +
            ",mov_cxund 'mov_cxund',mov_expendio 'mov_expendio',TRUNCATE(mov_export,0) 'mov_export',mov_fisico 'mov_fisico',mov_import 'mov_import'" +
            ",mov_otimp 'mov_otimp',mov_impprodu 'mov_impprodu',mov_invact 'mov_invact',mov_iva 'mov_iva',mov_logico 'mov_logico' " +
            ",mov_mtocom 'mov_mtocom',mov_memo 'mov_memo',mov_talla 'mov_talla',mov_color 'mov_color',mov_arancel 'mov_arancel' " +
            ",mov_kilos 'mov_kilos',mov_impuesto 'mov_impuesto',mov_cosmon 'mov_cosmon',mov_totalmon 'mov_totalmon',mov_precio_ini 'mov_precio_ini' " +
            ",mov_porciva 'mov_porciva', mov_codigo 'mov_codigo', mov_precio 'mov_precio', inv_descri 'colProducto',mov_total 'mov_total',TRUNCATE(mov_cant,0) 'mov_cant', mov_desc 'mov_desc', mov_costo 'mov_costo'  FROM adminvmov " +
            " LEFT JOIN  adminv ON adminv.inv_codigo = adminvmov.mov_codigo WHERE mov_docume='$1' AND mov_codcta='$mov_codcta' AND mov_tipdoc='$mov_tipdoc';";

            sentenciaSql = sentenciaSql.Replace("$1", numeroDocumento);
            sentenciaSql = sentenciaSql.Replace("$mov_codcta", numeroCliente);
            sentenciaSql = sentenciaSql.Replace("$mov_tipdoc", tipoDoc);
            dtItems = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dtItems;
        }


        public void actulizarItemsDev(string[,] valores) {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[4];
            sentenciaEnviar = "UPDATE adminvmov SET mov_export=(@mov_export+mov_export) WHERE mov_docume=@mov_docume AND mov_codigo=@mov_codigo AND mov_item=@mov_item;";
            parametrosEnviar[0] = "mov_export";
            parametrosEnviar[1] = "mov_docume";
            parametrosEnviar[2] = "mov_codigo";
            parametrosEnviar[3] = "mov_item";

            databaseConection.insertArray(valores, sentenciaEnviar, parametrosEnviar);
            databaseConection.cerrarConexion();
        }

        public void obtenerDatosFacturaAfectada(string correlativoInterno)
        {
            sentenciaSql = null;
            DataTable dt;
            sentenciaSql = "SELECT dcli_hora,dcli_numfis,dcli_fecha,dcli_impresora,dcli_codven  FROM admdoccli WHERE dcli_numero='$dcli_numero';";
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", correlativoInterno);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                this.horaAfectada = dt.Rows[0]["dcli_hora"].ToString();
                this.numeroFiscalAfectado = dt.Rows[0]["dcli_numfis"].ToString();
                this.fechaAfectada = "" + Convert.ToDateTime(dt.Rows[0]["dcli_fecha"].ToString()).Day + "-" + Convert.ToString(Convert.ToDateTime(dt.Rows[0]["dcli_fecha"].ToString()).Month).PadLeft(2, '0') + "-" + Convert.ToString(Convert.ToDateTime(dt.Rows[0]["dcli_fecha"].ToString()).Year).Substring(2);
                this.eocAfectado = dt.Rows[0]["dcli_impresora"].ToString();
                this.vendedorFactura.CodigoV = dt.Rows[0]["dcli_codven"].ToString();
            }
            databaseConection.cerrarConexion();
        }

        public void update_expexp() {
            string sTemp = null;
            sTemp = "UPDATE admdoccli SET dcli_estado='$dcli_expexp' WHERE dcli_numero='$dcli_numero';";
            sTemp = sTemp.Replace("$dcli_expexp", this.dcli_expexp);
            sTemp = sTemp.Replace("$dcli_numero", this.facturaAfectada);
            databaseConection.ejecutarInsert(sTemp);
            databaseConection.cerrarConexion();
            return;
        }
        
        private void obtenerCtd_Codcta() {
            DataTable dt;
            sentenciaSql = null;
            
            sentenciaSql = "SELECT ctd_codcta FROM admtipdoccli WHERE ctd_tipo='FAV';";
            dt = databaseConection.fDataTable(sentenciaSql);

            if (dt.Rows.Count > 0) {
                this.ctd_codcta = dt.Rows[0]["ctd_codcta"].ToString();
            }
            databaseConection.cerrarConexion();
        }


        public DataTable pedidoBuscado(string numero, string tipoDocumento)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccliped  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                  "WHERE  dcli_numero LIKE '%$1%'  OR dcli_numfis LIKE '%$1%' " +
                                  "OR admclientes.cli_nombre LIKE '%$1%' AND dcli_tipdoc='$dcli_tipdoc';";
            sentenciaSql = sentenciaSql.Replace("$1", numero);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", tipoDocumento);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }
        public DataTable pedidoBuscado2(string fecha1, string fecha2, string tipoDoc)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccliped  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                  "WHERE dcli_fecha BETWEEN '$fecha1' AND  '$fecha2' AND dcli_tipdoc='$t';";
            sentenciaSql = sentenciaSql.Replace("$fecha1", fecha1);
            sentenciaSql = sentenciaSql.Replace("$fecha2", fecha2);
            sentenciaSql = sentenciaSql.Replace("$t", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public void crearSentenciaCabeceraped(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                                            string cambio, string pagado, string contado)
        {
            sentenciaSql = null;

            sentenciaSql = "INSERT INTO admdoccliped " +
                                  "(dcli_cbtnum,dcli_cencos,dcli_codigo,dcli_codmon,dcli_sucursal, " +
                                  "dcli_transpo,dcli_codven,dcli_condic,dcli_destino,dcli_origen, " +
                                  "dcli_estado,dcli_expexp,dcli_facafe,dcli_girnum,dcli_hora, " +
                                  "dcli_modfis,dcli_numero,dcli_numfis,dcli_numgtr,dcli_plaexp,  " +
                                  "dcli_recnum,dcli_serfis,dcli_succli,dcli_tipafe,dcli_tipdoc, " +
                                  "dcli_tiptra,dcli_usuario,dcli_zona,dcli_fecharecep,dcli_fchven, " +
                                  "dcli_fecha,dcli_anufis,dcli_crerecibo,dcli_impreso,dcli_invmon,  " +
                                  "dcli_estatus,dcli_baseneta,dcli_cxc,dcli_dcto,dcli_otroimp, " +
                                  "dcli_mtocomisio,dcli_mtoiva,dcli_neto,dcli_numpag,dcli_otros,dcli_plazo, " +
                                  "dcli_recargo,dclli_valcamb,dcli_dctobs,dcli_totdivi,dcli_descitem, " +
                                  "dcli_descdoc,dcli_subbase,doc_impo,dcli_cantproduc,dcli_aprob1, " +
                                  "dcli_aprob2, dcli_aprob3,dcli_impresora,dcli_caja, dcli_cerrado, " +
                                  "dcli_cosfac, dcli_cosfac_n,dcli_cosfac_i,dcli_base_n,dcli_base_i, " +
                                  "dcli_saldo, dcli_facafe2,dcli_subtotal,dcli_ivaGN,dcli_ivaRD,idSistema) VALUES (" +
                                  "'$dcli_cbtnum','$dcli_cencos','$dcli_codigo','$dcli_codmon','$dcli_sucursal', " +
                                  "'$dcli_transpo','$dcli_codven','$dcli_condic','$dcli_destino','$dcli_origen', " +
                                  "'$dcli_estado','$dcli_expexp','$dcli_facafe','$dcli_girnum','$dcli_hora', " +
                                  "'$dcli_modfis','$dcli_numero','$dcli_numfis','$dcli_numgtr','$dcli_plaexp', " +
                                  "'$dcli_recnum','$dcli_serfis','$dcli_succli','$dcli_tipafe','$dcli_tipdoc', " +
                                  "'$dcli_tiptra','$dcli_usuario','$dcli_zona','$dcli_fecharecep','$dcli_fchven', " +
                                  "'$dcli_fecha','$dcli_anufis','$dcli_crerecibo','$1dcli_impreso','$dcli_invmon', " +
                                  "'$dcli_estatus','$dcli_baseneta','$dcli_cxc','$1dcli_dcto','$dcli_otroimp', " +
                                  "'$dcli_mtocomisio','$dcli_mtoiva','$dcli_neto','$dcli_numpag','$dcli_otros', " +
                                  "'$dcli_plazo','$dcli_recargo','$dclli_valcamb','$dcli_dctobs','$dcli_totdivi', " +
                                  "'$dcli_descitem','$dcli_descdoc','$dcli_subbase','$doc_impo','$dcli_cantproduc', " +
                                  "'$dcli_aprob1','$dcli_aprob2','$dcli_aprob3','$dcli_impresora','$dcli_caja', " +
                                  "'$dcli_cerrado','$dcli_cosfac','$5dcli_cosfac_n','$3dcli_cosfac_i','$1dcli_base_n', " +
                                  "'$2dcli_base_i','$dcli_saldo','$1dcli_facafe2',$@dcli_subtotal,$?dcli_ivaGN,$?dcli_ivaRD,'$idSistema');";

            sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
            sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
            sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
            sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
            sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
            sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
            sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", this.dcli_estado /*this.dcli_expexp*/);
            sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
            if (this.dcli_expexp != null)
            {
                this.update_expexp();
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
            sentenciaSql = sentenciaSql.Replace("$dcli_girnum", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_hora", DateTime.Now.ToString("hh:mm:ss tt"));
            sentenciaSql = sentenciaSql.Replace("$dcli_modfis", " ");//obtener el modelo de la impresora fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
            sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
            if ((this.tipoDocumento.Equals("PED")) || (this.tipoDocumento.Equals("CTZ")))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
            sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "CTZ");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PED");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codigoUsuario);
            sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_fecharecep", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_fchven", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_fecha", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
            sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
            sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            }
            sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
            if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
            }
            else
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
            sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
            sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
            sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
            //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
            sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
            sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
            sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
            if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
                sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
            else
                sentenciaSql = sentenciaSql.Replace("$idSistema", " ");
        }


        public DataSet rtpPedido(string condicionPago, string plazoDias, string nombreUsuario)
        {
            DataSet dts = new DataSet();
            DataTable dtDetalle = new DataTable("DataTable1");
            DataTable dtCabecera = new DataTable("DataTable2");

            getnombreReporte(this.tipoDocumento);

            dtDetalle.Columns.Add("@mov_codigo");
            dtDetalle.Columns.Add("colProducto");
            dtDetalle.Columns.Add("@mov_undmed");
            dtDetalle.Columns.Add("@mov_cant");
            dtDetalle.Columns.Add("@mov_precio");
            dtDetalle.Columns.Add("@mov_total");
            dtCabecera.Columns.Add("correlativoInterno");
            dtCabecera.Columns.Add("fechaFactura");
            dtCabecera.Columns.Add("condicion");
            dtCabecera.Columns.Add("txtplazoDias");
            dtCabecera.Columns.Add("nombre");
            dtCabecera.Columns.Add("rif");
            dtCabecera.Columns.Add("direccion");
            dtCabecera.Columns.Add("direccion2");
            dtCabecera.Columns.Add("direccionEnvio");
            dtCabecera.Columns.Add("telefono");
            dtCabecera.Columns.Add("codigoCli");
            dtCabecera.Columns.Add("subTotal");
            dtCabecera.Columns.Add("iva");
            dtCabecera.Columns.Add("totalDoc");
            dtCabecera.Columns.Add("@nombreReporte");
            dtCabecera.Columns.Add("@usuario");
            dtCabecera.Columns.Add("@usuarioOriginal");


            for (int x = 0; x < this.dgvItems.Rows.Count; x++)
            {
                DataRow nuevaFila = dtDetalle.NewRow();
                nuevaFila["@mov_codigo"] = this.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString();
                nuevaFila["colProducto"] = this.dgvItems.Rows[x].Cells["colProducto"].Value.ToString();
                nuevaFila["@mov_undmed"] = this.dgvItems.Rows[x].Cells["@mov_undmed"].Value.ToString();
                nuevaFila["@mov_cant"] = this.dgvItems.Rows[x].Cells["@mov_cant"].Value.ToString();
                nuevaFila["@mov_precio"] = this.dgvItems.Rows[x].Cells["@mov_precio"].Value.ToString().Replace(",", ".");
                nuevaFila["@mov_total"] = this.dgvItems.Rows[x].Cells["@mov_total"].Value.ToString().Replace(",", ".");
                dtDetalle.Rows.Add(nuevaFila);
            }

            DataRow filaDet = dtCabecera.NewRow();
            filaDet["correlativoInterno"] = this.CorrelativoInterno;
            if (this.fechaFactura.ToString().Equals("01/01/0001 12:00:00 a.m."))
            {
                filaDet["fechaFactura"] = "" + DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year;
            }
            else
            {
                if ((this.fechaFactura != null) || ((this.fechaFactura.ToString()) != ""))
                {
                    filaDet["fechaFactura"] = "" + this.fechaFactura.Day.ToString().PadLeft(2, '0') + "/" + this.fechaFactura.Month.ToString().PadLeft(2, '0') + "/" + this.fechaFactura.Year;
                }
                else
                {
                    filaDet["fechaFactura"] = "" + DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year;
                }
            }
            filaDet["condicion"] = condicionPago;
            filaDet["txtplazoDias"] = plazoDias;
            filaDet["nombre"] = this.clienteFacturar.Nombre;
            filaDet["rif"] = this.clienteFacturar.Rif;
            filaDet["direccion"] = this.clienteFacturar.Direccion;
            filaDet["direccion2"] = this.clienteFacturar.Direccion2;
            filaDet["direccionEnvio"] = this.clienteFacturar.DireccionEnvio;
            filaDet["telefono"] = this.clienteFacturar.Telefono;
            filaDet["codigoCli"] = this.clienteFacturar.Codigo;
            filaDet["subTotal"] = Convert.ToString(this.TotalBase).Replace(",", ".");
            filaDet["totalDoc"] = Convert.ToString(this.totalNeto).Replace(",", ".");
            filaDet["iva"] = Convert.ToString(this.ivaGN + this.ivaRD).Replace(",", ".");
            filaDet["@nombreReporte"] = this.nombreReporte;
            filaDet["@usuario"] = nombreUsuario;
            filaDet["@usuarioOriginal"] = nombreUsuario;

            dtCabecera.Rows.Add(filaDet);
            dts.Tables.Add(dtDetalle);
            dts.Tables.Add(dtCabecera);
            return dts;
        }

        public DataSet rtpPedido(string condicionPago, string plazoDias, string nombreUsuario, string usuario2)
        {
            DataSet dts = new DataSet();
            DataTable dtDetalle = new DataTable("DataTable1");
            DataTable dtCabecera = new DataTable("DataTable2");

            getnombreReporte(this.tipoDocumento);

            dtDetalle.Columns.Add("@mov_codigo");
            dtDetalle.Columns.Add("colProducto");
            dtDetalle.Columns.Add("@mov_undmed");
            dtDetalle.Columns.Add("@mov_cant");
            dtDetalle.Columns.Add("@mov_precio");
            dtDetalle.Columns.Add("@mov_total");
            dtCabecera.Columns.Add("correlativoInterno");
            dtCabecera.Columns.Add("fechaFactura");
            dtCabecera.Columns.Add("condicion");
            dtCabecera.Columns.Add("txtplazoDias");
            dtCabecera.Columns.Add("nombre");
            dtCabecera.Columns.Add("rif");
            dtCabecera.Columns.Add("direccion");
            dtCabecera.Columns.Add("direccion2");
            dtCabecera.Columns.Add("direccionEnvio");
            dtCabecera.Columns.Add("telefono");
            dtCabecera.Columns.Add("codigoCli");
            dtCabecera.Columns.Add("subTotal");
            dtCabecera.Columns.Add("iva");
            dtCabecera.Columns.Add("totalDoc");
            dtCabecera.Columns.Add("@nombreReporte");
            dtCabecera.Columns.Add("@usuario");
            dtCabecera.Columns.Add("@usuarioOriginal");


            for (int x = 0; x < this.dgvItems.Rows.Count; x++)
            {
                DataRow nuevaFila = dtDetalle.NewRow();
                nuevaFila["@mov_codigo"] = this.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString();
                nuevaFila["colProducto"] = this.dgvItems.Rows[x].Cells["colProducto"].Value.ToString();
                nuevaFila["@mov_undmed"] = this.dgvItems.Rows[x].Cells["@mov_undmed"].Value.ToString();
                nuevaFila["@mov_cant"] = this.dgvItems.Rows[x].Cells["@mov_cant"].Value.ToString();
                nuevaFila["@mov_precio"] = this.dgvItems.Rows[x].Cells["@mov_precio"].Value.ToString().Replace(",", ".");
                nuevaFila["@mov_total"] = this.dgvItems.Rows[x].Cells["@mov_total"].Value.ToString().Replace(",", ".");
                dtDetalle.Rows.Add(nuevaFila);
            }

            DataRow filaDet = dtCabecera.NewRow();
            filaDet["correlativoInterno"] = this.CorrelativoInterno;
            if (this.fechaFactura.ToString().Equals("01/01/0001 12:00:00 a.m."))
            {
                filaDet["fechaFactura"] = "" + DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year;
            }
            else
            {
                if ((this.fechaFactura != null) || ((this.fechaFactura.ToString()) != ""))
                {
                    filaDet["fechaFactura"] = "" + this.fechaFactura.Day.ToString().PadLeft(2, '0') + "/" + this.fechaFactura.Month.ToString().PadLeft(2, '0') + "/" + this.fechaFactura.Year;
                }
                else
                {
                    filaDet["fechaFactura"] = "" + DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year;
                }
            }
            filaDet["condicion"] = condicionPago;
            filaDet["txtplazoDias"] = plazoDias;
            filaDet["nombre"] = this.clienteFacturar.Nombre;
            filaDet["rif"] = this.clienteFacturar.Rif;
            filaDet["direccion"] = this.clienteFacturar.Direccion;
            filaDet["direccion2"] = this.clienteFacturar.Direccion2;
            filaDet["direccionEnvio"] = this.clienteFacturar.DireccionEnvio;
            filaDet["telefono"] = this.clienteFacturar.Telefono;
            filaDet["codigoCli"] = this.clienteFacturar.Codigo;
            filaDet["subTotal"] = Convert.ToString(this.TotalBase).Replace(",", ".");
            filaDet["totalDoc"] = Convert.ToString(this.totalNeto).Replace(",", ".");
            filaDet["iva"] = Convert.ToString(this.ivaGN + this.ivaRD).Replace(",", ".");
            filaDet["@nombreReporte"] = this.nombreReporte;
            filaDet["@usuario"] = nombreUsuario;
            filaDet["@usuarioOriginal"] = usuario2;

            dtCabecera.Rows.Add(filaDet);
            dts.Tables.Add(dtDetalle);
            dts.Tables.Add(dtCabecera);
            return dts;
        }


        public DataTable itemsFacPed()
        {
            DataTable dtItems;
            sentenciaSql = null;
            sentenciaSql = "SELECT mov_docaso  '@mov_docaso',mov_tipoaso '@mov_tipoaso' ,mov_cencos '@mov_cencos',mov_codalm '@mov_codalm',mov_cdcomp '@mov_cdcomp' " +
            ",mov_codcta '@mov_codcta' ,mov_codsuc '@mov_codsuc',mov_codtra '@mov_codtra' ,mov_vendedor '@mov_vendedor',mov_docume '@mov_docume' " +
            ",mov_hora '@mov_hora',mov_item '@mov_item',mov_itemaso '@mov_itemaso' ,mov_itemcomp '@mov_itemcomp',mov_lista '@mov_lista' " +
            ",mov_lote '@mov_lote',mov_tipdoc '@mov_tipdoc',mov_ivatip '@mov_ivatip',mov_tipo '@mov_tipo' ,mov_undmed '@mov_undmed'" +
            ",mov_usuario '@mov_usuario',mov_fechven '@mov_fechven',mov_fecha '@mov_fecha',mov_bandas '@mov_bandas',mov_contab '@mov_contab' " +
            ",mov_cxund '@mov_cxund',mov_expendio '@mov_expendio',mov_export '@mov_export',mov_fisico '@mov_fisico',mov_import '@mov_import'" +
            ",mov_otimp '@mov_otimp',mov_impprodu '@mov_impprodu',mov_invact '@mov_invact',mov_iva '@mov_iva',mov_logico '@mov_logico' " +
            ",mov_mtocom '@mov_mtocom',mov_memo '@mov_memo',mov_talla '@mov_talla',mov_color '@mov_color',mov_arancel '@mov_arancel' " +
            ",mov_kilos '@mov_kilos',mov_impuesto '@mov_impuesto',mov_cosmon '@mov_cosmon',mov_totalmon '@mov_totalmon',mov_precio_ini '@mov_precio_ini' " +
            ",mov_porciva '@mov_porciva', mov_codigo '@mov_codigo', mov_precio '@mov_precio', mov_costo '@mov_costo', " +
            " mov_memo 'colProducto',mov_total '@mov_total',TRUNCATE(mov_cant,0) '@mov_cant', mov_desc '@mov_desc', ult_provee 'procedencia'  FROM adminvmovped " +
            " LEFT JOIN  adminv ON adminv.inv_codigo = adminvmovped.mov_codigo " +
            " LEFT JOIN  adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
            " WHERE mov_docume='$1';";

            sentenciaSql = sentenciaSql.Replace("$1", this.correlativoInterno);
            dtItems = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dtItems;
        }


        public void cargarFacturaPed(string numeroInter, Clientes clientF, Vendedor vend1)
        {
            DataTable dtFactura;
            sentenciaSql = null;

            sentenciaSql = "SELECT dcli_codigo, dcli_codmon, dcli_codven, dcli_condic, dcli_facafe, " +
                "dcli_tipafe,dcli_tipdoc,dcli_invmon,dcli_baseneta,dcli_descitem, " +
                "dcli_subbase,doc_impo,TRUNCATE(dcli_cantproduc,0) 'dcli_cantproduc' ,dcli_cosfac_n,dcli_cosfac_i, " +
                "dcli_base_n,dcli_base_i,dcli_saldo,dcli_subtotal,dcli_ivaRD, " +
                "dcli_ivaGN, dcli_estado,dcli_numpag,idSistema,dcli_fecha,dcli_hora,dcli_transpo,dcli_estatus,dcli_cbtnum,dcli_anufis  " +
                "FROM admdoccliped WHERE dcli_numero='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", numeroInter);
            dtFactura = databaseConection.fDataTable(sentenciaSql);
            this.clienteFacturar = clientF;
            if (dtFactura.Rows.Count > 0)
            {
                clientF.Codigo = dtFactura.Rows[0]["dcli_codigo"].ToString();
                clientF.Transporte = dtFactura.Rows[0]["dcli_transpo"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_codmon"].ToString();
                vend1.CodigoV = dtFactura.Rows[0]["dcli_codven"].ToString();
                clientF.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.clienteFacturar.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.correlativoInterno = numeroInter;
                this.facturaAfectada = dtFactura.Rows[0]["dcli_facafe"].ToString();
                this.TipoDocumento = dtFactura.Rows[0]["dcli_tipdoc"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_invmon"].ToString();
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_baseneta"].ToString().Replace(".", ","));
                this.DescuentoItems = Convert.ToDecimal(dtFactura.Rows[0]["dcli_descitem"].ToString().Replace(".", ","));
                this.BaseEX = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subbase"].ToString().Replace(".", ","));
                this.baseGN = Convert.ToDecimal(dtFactura.Rows[0]["doc_impo"].ToString().Replace(".", ","));
                this.totalItems = Int32.Parse(dtFactura.Rows[0]["dcli_cantproduc"].ToString());
                this.CostoNacional = Convert.ToDecimal(Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_n"].ToString().Replace(".", ",")));
                this.CostoImportado = Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_i"].ToString().Replace(".", ","));
                this.BaseNacional = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_n"].ToString().Replace(".", ","));
                this.BaseImportada = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_i"].ToString().Replace(".", ","));
                this.TotalNeto = Convert.ToDecimal(dtFactura.Rows[0]["dcli_saldo"].ToString().Replace(".", ","));
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subtotal"].ToString().Replace(".", ","));
                this.ivaRD = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaRD"].ToString().Replace(".", ","));
                this.ivaGN = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaGN"].ToString().Replace(".", ","));
                this.dcli_estado = dtFactura.Rows[0]["dcli_estado"].ToString();
                this.numeroPedido = dtFactura.Rows[0]["dcli_numpag"].ToString();
                this.direccionEnvio = dtFactura.Rows[0]["idSistema"].ToString();
                this.fechaFactura = Convert.ToDateTime(dtFactura.Rows[0]["dcli_fecha"].ToString());
                this.HoraAfectada = dtFactura.Rows[0]["dcli_hora"].ToString();
                this.estatus = dtFactura.Rows[0]["dcli_estatus"].ToString();
                this.codigoRechazo = dtFactura.Rows[0]["dcli_cbtnum"].ToString();
                this.dcli_anufis = dtFactura.Rows[0]["dcli_anufis"].ToString();
            }
            databaseConection.cerrarConexion();
        }

        public void guardarDetallePed(DataGridView detalles)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[52];

            sentenciaEnviar = "INSERT INTO adminvmovped ( " +
                                      "mov_docaso,mov_tipoaso,mov_cencos,mov_codalm,mov_cdcomp,  " +
                                      "mov_codcta,mov_codigo,mov_codsuc,mov_codtra,mov_vendedor, " +
                                      "mov_docume,mov_hora,mov_item,mov_itemaso,mov_itemcomp, " +
                                      "mov_lista,mov_lote,mov_tipdoc,mov_ivatip,mov_tipo,mov_undmed, " +
                                      "mov_usuario,mov_fechven,mov_fecha,mov_bandas,mov_cant, " +
                                      "mov_contab,mov_costo,mov_cxund,mov_desc,mov_expendio, " +
                                      "mov_export,mov_fisico,mov_import,mov_otimp,mov_impprodu, " +
                                      "mov_invact,mov_iva,mov_logico,mov_mtocom,mov_memo, " +
                                      "mov_precio,mov_total,mov_talla,mov_color,mov_arancel, " +
                                      "mov_kilos,mov_impuesto,mov_cosmon,mov_totalmon,mov_precio_ini, " +
                                      "mov_porciva) VALUES( " +
                                      "@mov_docaso,@mov_tipoaso,@mov_cencos,@mov_codalm,@mov_cdcomp, " +
                                      "@mov_codcta,@mov_codigo,@mov_codsuc,@mov_codtra,@mov_vendedor, " +
                                      "@mov_docume,@mov_hora,@mov_item,@mov_itemaso,@mov_itemcomp, " +
                                      "@mov_lista,@mov_lote,@mov_tipdoc,@mov_ivatip,@mov_tipo, " +
                                      "@mov_undmed,@mov_usuario,@mov_fechven,@mov_fecha,@mov_bandas, " +
                                      "@mov_cant,@mov_contab,@mov_costo,@mov_cxund,@mov_desc, " +
                                      "@mov_expendio,@mov_export,@mov_fisico,@mov_import,@mov_otimp, " +
                                      "@mov_impprodu,@mov_invact,@mov_iva,@mov_logico,@mov_mtocom, " +
                                      "@mov_memo,@mov_precio,@mov_total,@mov_talla,@mov_color, " +
                                      "@mov_arancel,@mov_kilos,@mov_impuesto,@mov_cosmon,@mov_totalmon, " +
                                      "@mov_precio_ini,@mov_porciva);";

            parametrosEnviar[0] = "@mov_docaso";
            parametrosEnviar[1] = "@mov_tipoaso";
            parametrosEnviar[2] = "@mov_cencos";
            parametrosEnviar[3] = "@mov_codalm";
            parametrosEnviar[4] = "@mov_cdcomp";
            parametrosEnviar[5] = "@mov_codcta";
            parametrosEnviar[6] = "@mov_codigo";
            parametrosEnviar[7] = "@mov_codsuc";
            parametrosEnviar[8] = "@mov_codtra";
            parametrosEnviar[9] = "@mov_vendedor";
            parametrosEnviar[10] = "@mov_docume";
            parametrosEnviar[11] = "@mov_hora";
            parametrosEnviar[12] = "@mov_item";
            parametrosEnviar[13] = "@mov_itemaso";
            parametrosEnviar[14] = "@mov_itemcomp";
            parametrosEnviar[15] = "@mov_lista";
            parametrosEnviar[16] = "@mov_lote";
            parametrosEnviar[17] = "@mov_tipdoc";
            parametrosEnviar[18] = "@mov_ivatip";
            parametrosEnviar[19] = "@mov_tipo";
            parametrosEnviar[20] = "@mov_undmed";
            parametrosEnviar[21] = "@mov_usuario";
            parametrosEnviar[22] = "@mov_fechven";
            parametrosEnviar[23] = "@mov_fecha";
            parametrosEnviar[24] = "@mov_bandas";
            parametrosEnviar[25] = "@mov_cant";
            parametrosEnviar[26] = "@mov_contab";
            parametrosEnviar[27] = "@mov_costo";
            parametrosEnviar[28] = "@mov_cxund";
            parametrosEnviar[29] = "@mov_desc";
            parametrosEnviar[30] = "@mov_expendio";
            parametrosEnviar[31] = "@mov_export";
            parametrosEnviar[32] = "@mov_fisico";
            parametrosEnviar[33] = "@mov_import";
            parametrosEnviar[34] = "@mov_otimp";
            parametrosEnviar[35] = "@mov_impprodu";
            parametrosEnviar[36] = "@mov_invact";
            parametrosEnviar[37] = "@mov_iva";
            parametrosEnviar[38] = "@mov_logico";
            parametrosEnviar[39] = "@mov_mtocom";
            parametrosEnviar[40] = "@mov_memo";
            parametrosEnviar[41] = "@mov_precio";
            parametrosEnviar[42] = "@mov_total";
            parametrosEnviar[43] = "@mov_talla";
            parametrosEnviar[44] = "@mov_color";
            parametrosEnviar[45] = "@mov_arancel";
            parametrosEnviar[46] = "@mov_kilos";
            parametrosEnviar[47] = "@mov_impuesto";
            parametrosEnviar[48] = "@mov_cosmon";
            parametrosEnviar[49] = "@mov_totalmon";
            parametrosEnviar[50] = "@mov_precio_ini";
            parametrosEnviar[51] = "@mov_porciva";
            databaseConection.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            databaseConection.cerrarConexion();
        }


        public DataTable lbxO(string tipoDoc)
        {
            DataTable dt;
            dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdoccliped  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                "WHERE  dcli_tipdoc= '$tipo' " +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
            sentenciaSql = sentenciaSql.Replace("$tipo", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql, 200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public void getnombreReporte(string tipoDoc)
        {
            DataTable dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT ctd_descri FROM admtipdoccli WHERE ctd_tipo='$ctd_tipo'";
            sentenciaSql = sentenciaSql.Replace("$ctd_tipo", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                this.nombreReporte = dt.Rows[0]["ctd_descri"].ToString();
            }
            databaseConection.cerrarConexion();
        }

        public void restarIvaElemento(decimal montoIva, string tipoIiva)
        {
            montoIva = Truncate(montoIva, 2);
            switch (tipoIiva)
            {
                case "GN":
                    ivaGN = ivaGN - montoIva;
                    break;
                case "RD":
                    ivaRD = ivaRD - montoIva;
                    break;
            }

            if (ivaGN < 0)
            {
                ivaGN = 0;
            }
            if (ivaRD < 0)
            {
                ivaRD = 0;
            }
        }

        //public void ActualizarSentenciaCabecerap(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
        //                                                           string cambio, string pagado, string contado)
        //{
        //    sentenciaSql = null;

        //    sentenciaSql = "UPDATE admdoccliped SET dcli_cbtnum ='$dcli_cbtnum', dcli_cencos='$dcli_cencos',dcli_codigo ='$dcli_codigo', " +
        //                    "dcli_codmon='$dcli_codmon', dcli_sucursal='$dcli_sucursal', dcli_transpo='$dcli_transpo', dcli_codven='$dcli_codven', " +
        //                    "dcli_condic='$dcli_condic', dcli_destino='$dcli_destino',dcli_origen='$dcli_origen', dcli_estado='$dcli_estado', " +
        //                    "dcli_expexp='$dcli_expexp', dcli_facafe='$dcli_facafe', dcli_girnum='$dcli_girnum', dcli_modfis='$dcli_modfis', " +
        //                    "dcli_numfis='$dcli_numfis', dcli_numgtr='$dcli_numgtr', dcli_plaexp='$dcli_plaexp', dcli_recnum='$dcli_recnum', " +
        //                    "dcli_serfis='$dcli_serfis', dcli_succli='$dcli_succli', dcli_tipafe='$dcli_tipafe', " +
        //                    "dcli_tiptra='$dcli_tiptra', dcli_zona='$dcli_zona', dcli_anufis='$dcli_anufis', dcli_crerecibo='$1dcli_impreso', " +
        //                    "dcli_impreso='$1dcli_impreso', dcli_invmon='$dcli_invmon', dcli_estatus='$dcli_estatus', dcli_baseneta='$dcli_baseneta', " +
        //                    "dcli_cxc='$dcli_cxc', dcli_dcto='$1dcli_dcto', dcli_otroimp='$dcli_otroimp', dcli_mtocomisio='$dcli_mtocomisio', " +
        //                    "dcli_mtoiva='$dcli_mtoiva', dcli_neto='$dcli_neto', dcli_numpag='$dcli_numpag', dcli_otros='$dcli_otros', " +
        //                    "dcli_plazo='$dcli_plazo', dcli_recargo='$dcli_recargo', dclli_valcamb='$dclli_valcamb', dcli_dctobs='$dcli_dctobs', " +
        //                    "dcli_totdivi='$dcli_totdivi', dcli_descitem='$dcli_descitem', dcli_descdoc='$dcli_descdoc', dcli_subbase='$dcli_subbase', " +
        //                    "doc_impo='$doc_impo', dcli_cantproduc='$dcli_cantproduc', dcli_aprob1='$dcli_aprob1', dcli_aprob2='$dcli_aprob2', " +
        //                    "dcli_aprob3='$dcli_aprob3', dcli_impresora='$dcli_impresora', dcli_caja='$dcli_caja', dcli_cerrado='$dcli_cerrado', " +
        //                    "dcli_cosfac='$dcli_cosfac', dcli_cosfac_n='$5dcli_cosfac_n', dcli_cosfac_i='$3dcli_cosfac_i', dcli_base_n='$1dcli_base_n', " +
        //                    "dcli_base_i='$2dcli_base_i', dcli_saldo='$dcli_saldo', dcli_facafe2='$1dcli_facafe2', dcli_subtotal='$@dcli_subtotal', " +
        //                    "dcli_ivaGN='$?dcli_ivaGN', dcli_ivaRD='$?dcli_ivaRD', idSistema='$idSistema' WHERE dcli_numero='$dcli_numero' AND dcli_tipdoc='$dcli_tipdoc';";

        //    sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", string.IsNullOrEmpty(this.codigoRechazo) ? " " : this.codigoRechazo);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_estado", this.dcli_estado /*this.dcli_expexp*/);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
        //    if (this.dcli_expexp != null)
        //    {
        //        this.update_expexp();
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_girnum", codigoUsuario);//ultimo usuario que actualizo
        //    sentenciaSql = sentenciaSql.Replace("$dcli_modfis", DateTime.Now.ToString());//fecha de la ultima actualizacion
        //    sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno); sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
        //    if ((this.tipoDocumento.Equals("PED")) || (this.tipoDocumento.Equals("CTZ")))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
        //    sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");
        //    if (this.tipoDocumento.Equals("CTZ"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "CTZ");//si es fav o dev = fav si es igual a PED va a ser igual a PED
        //    }
        //    if (this.tipoDocumento.Equals("PED"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PED");//si es fav o dev = fav si es igual a PED va a ser igual a PED
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
        //    if (this.tipoDocumento.Equals("CTZ"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
        //    }
        //    if (this.tipoDocumento.Equals("PED"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
        //    }

        //    sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");

        //    sentenciaSql = sentenciaSql.Replace("$dcli_anufis", string.IsNullOrEmpty(this.dcli_anufis) ? " " : this.dcli_anufis);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
        //    sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    if (this.tipoDocumento.Equals("CTZ"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
        //    }
        //    if (this.tipoDocumento.Equals("PED"))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
        //    if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
        //    }
        //    else
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
        //    //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
        //    sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
        //    sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
        //    sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
        //    if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
        //        sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
        //    else
        //        sentenciaSql = sentenciaSql.Replace("$idSistema", " ");

        //    sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
        //}
        public void ActualizarSentenciaCabecerap(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                                   string cambio, string pagado, string contado)
        {
            sentenciaSql = null;

            sentenciaSql = "UPDATE admdoccliped SET dcli_cbtnum ='$dcli_cbtnum', dcli_cencos='$dcli_cencos',dcli_codigo ='$dcli_codigo', " +
                            "dcli_codmon='$dcli_codmon', dcli_sucursal='$dcli_sucursal', dcli_transpo='$dcli_transpo', dcli_codven='$dcli_codven', " +
                            "dcli_condic='$dcli_condic', dcli_destino='$dcli_destino',dcli_origen='$dcli_origen', dcli_estado='$dcli_estado', " +
                            "dcli_expexp='$dcli_expexp', dcli_facafe='$dcli_facafe', dcli_girnum='$dcli_girnum', dcli_modfis='$dcli_modfis', " +
                            "dcli_numfis='$dcli_numfis', dcli_numgtr='$dcli_numgtr', dcli_plaexp='$dcli_plaexp', dcli_recnum='$dcli_recnum', " +
                            "dcli_serfis='$dcli_serfis', dcli_succli='$dcli_succli', dcli_tipafe='$dcli_tipafe', " +
                            "dcli_tiptra='$dcli_tiptra', dcli_zona='$dcli_zona', dcli_anufis='$dcli_anufis', dcli_crerecibo='$1dcli_impreso', " +
                            "dcli_impreso='$1dcli_impreso', dcli_invmon='$dcli_invmon', dcli_estatus='$dcli_estatus', dcli_baseneta='$dcli_baseneta', " +
                            "dcli_cxc='$dcli_cxc', dcli_dcto='$1dcli_dcto', dcli_otroimp='$dcli_otroimp', dcli_mtocomisio='$dcli_mtocomisio', " +
                            "dcli_mtoiva='$dcli_mtoiva', dcli_neto='$dcli_neto', dcli_numpag='$dcli_numpag', dcli_otros='$dcli_otros', " +
                            "dcli_plazo='$dcli_plazo', dcli_recargo='$dcli_recargo', dclli_valcamb='$dclli_valcamb', dcli_dctobs='$dcli_dctobs', " +
                            "dcli_totdivi='$dcli_totdivi', dcli_descitem='$dcli_descitem', dcli_descdoc='$dcli_descdoc', dcli_subbase='$dcli_subbase', " +
                            "doc_impo='$doc_impo', dcli_cantproduc='$dcli_cantproduc', dcli_aprob1='$dcli_aprob1', dcli_aprob2='$dcli_aprob2', " +
                            "dcli_aprob3='$dcli_aprob3', dcli_impresora='$dcli_impresora', dcli_caja='$dcli_caja', dcli_cerrado='$dcli_cerrado', " +
                            "dcli_cosfac='$dcli_cosfac', dcli_cosfac_n='$5dcli_cosfac_n', dcli_cosfac_i='$3dcli_cosfac_i', dcli_base_n='$1dcli_base_n', " +
                            "dcli_base_i='$2dcli_base_i', dcli_saldo='$dcli_saldo', dcli_facafe2='$1dcli_facafe2', dcli_subtotal='$@dcli_subtotal', " +
                            "dcli_ivaGN='$?dcli_ivaGN', dcli_ivaRD='$?dcli_ivaRD', idSistema='$idSistema' WHERE dcli_numero='$dcli_numero' AND dcli_tipdoc='$dcli_tipdoc';";

            sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", string.IsNullOrEmpty(this.codigoRechazo) ? " " : this.codigoRechazo);
            sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
            sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
            sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
            sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
            sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
            sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
            sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", this.dcli_estado /*this.dcli_expexp*/);
            sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
            if (this.dcli_expexp != null)
            {
                this.update_expexp();
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
            sentenciaSql = sentenciaSql.Replace("$dcli_girnum", codigoUsuario);//ultimo usuario que actualizo
            sentenciaSql = sentenciaSql.Replace("$dcli_modfis", DateTime.Now.ToString());//fecha de la ultima actualizacion
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno); sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
            if ((this.tipoDocumento.Equals("PED")) || (this.tipoDocumento.Equals("CTZ")))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
            sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "CTZ");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PED");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            }

            sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");

            sentenciaSql = sentenciaSql.Replace("$dcli_anufis", string.IsNullOrEmpty(this.dcli_anufis) ? " " : this.dcli_anufis);
            sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
            sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
            sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
            if (this.tipoDocumento.Equals("CTZ"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            }
            if (this.tipoDocumento.Equals("PED"))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            }
            sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
            if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
            }
            else
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
            sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
            sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
            sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
            //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
            sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
            sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
            sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
            if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
                sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
            else
                sentenciaSql = sentenciaSql.Replace("$idSistema", " ");

            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
        }

        public int actualizarCabeceraPed()
        {
            int resultado = 0;
            resultado = databaseConection.ejecutarInsert2(sentenciaSql);
            databaseConection.cerrarConexion();
            return resultado;
        }


        public void borrarDetallePed(DataGridView detalles)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[2];

            sentenciaEnviar = "DELETE FROM adminvmovped WHERE mov_docume =@mov_docume AND mov_tipdoc=@mov_tipdoc;";
            parametrosEnviar[0] = "@mov_docume";
            parametrosEnviar[1] = "@mov_tipdoc";
            databaseConection.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            databaseConection.cerrarConexion();
        }

        public void cargarDocumento(string numeroInter, Clientes clientF, Vendedor vend1, string tipoDoc)
        {
            DataTable dtFactura;
            sentenciaSql = null;

            sentenciaSql = "SELECT dcli_codigo, dcli_codmon, dcli_codven, dcli_condic, dcli_facafe, " +
                "dcli_tipafe,dcli_tipdoc,dcli_invmon,dcli_baseneta,dcli_descitem, " +
                "dcli_subbase,doc_impo,TRUNCATE(dcli_cantproduc,0) 'dcli_cantproduc' ,dcli_cosfac_n,dcli_cosfac_i, " +
                "dcli_base_n,dcli_base_i,dcli_saldo,dcli_subtotal,dcli_ivaRD, " +
                "dcli_ivaGN, dcli_estado,dcli_numpag,idSistema,dcli_fecha, dcli_mtoiva,dcli_cbtnum,dcli_anufis " +
                "FROM admdoccliped WHERE dcli_numero='$1' AND dcli_tipdoc='$@dcli_tipdoc';";
            sentenciaSql = sentenciaSql.Replace("$1", numeroInter);
            sentenciaSql = sentenciaSql.Replace("$@dcli_tipdoc", tipoDoc);
            dtFactura = databaseConection.fDataTable(sentenciaSql);
            this.ClienteFacturar = clientF;

            if (dtFactura.Rows.Count > 0)
            {
                clientF.Codigo = dtFactura.Rows[0]["dcli_codigo"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_codmon"].ToString();
                vend1.CodigoV = dtFactura.Rows[0]["dcli_codven"].ToString();
                clientF.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.ClienteFacturar.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.correlativoInterno = numeroInter;
                this.facturaAfectada = dtFactura.Rows[0]["dcli_facafe"].ToString();
                this.TipoDocumento = dtFactura.Rows[0]["dcli_tipdoc"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_invmon"].ToString();
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_baseneta"].ToString().Replace(".", ","));
                this.DescuentoItems = Convert.ToDecimal(dtFactura.Rows[0]["dcli_descitem"].ToString().Replace(".", ","));
                this.BaseEX = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subbase"].ToString().Replace(".", ","));
                this.baseGN = Convert.ToDecimal(dtFactura.Rows[0]["doc_impo"].ToString().Replace(".", ","));
                this.totalItems = Int32.Parse(dtFactura.Rows[0]["dcli_cantproduc"].ToString());
                this.CostoNacional = Convert.ToDecimal(Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_n"].ToString().Replace(".", ",")));
                this.CostoImportado = Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_i"].ToString().Replace(".", ","));
                this.BaseNacional = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_n"].ToString().Replace(".", ","));
                this.BaseImportada = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_i"].ToString().Replace(".", ","));
                this.TotalNeto = Convert.ToDecimal(dtFactura.Rows[0]["dcli_saldo"].ToString().Replace(".", ","));
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subtotal"].ToString().Replace(".", ","));
                this.ivaRD = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaRD"].ToString().Replace(".", ","));
                this.ivaGN = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaGN"].ToString().Replace(".", ","));
                this.dcli_estado = dtFactura.Rows[0]["dcli_estado"].ToString();
                this.numeroPedido = dtFactura.Rows[0]["dcli_numpag"].ToString();
                this.direccionEnvio = dtFactura.Rows[0]["idSistema"].ToString();
                this.fechaFactura = Convert.ToDateTime(dtFactura.Rows[0]["dcli_fecha"].ToString());
                this.ivaTotal = Convert.ToDecimal(dtFactura.Rows[0]["dcli_mtoiva"].ToString());
                this.codigoRechazo = String.IsNullOrEmpty(dtFactura.Rows[0]["dcli_cbtnum"].ToString()) ? "" : dtFactura.Rows[0]["dcli_cbtnum"].ToString();
                this.dcli_anufis = String.IsNullOrEmpty(dtFactura.Rows[0]["dcli_anufis"].ToString()) ? "" : dtFactura.Rows[0]["dcli_anufis"].ToString();
            }
            databaseConection.cerrarConexion();
        }



        public DataSet rptPedidoM(Clientes cli1, string usuario, Factura fact1, string nombreTransporte, bool centinela)
        {
            DataSet dts = new DataSet();
            DataTable dt1 = new DataTable("DataTable1");
            DataTable dt2 = new DataTable("DataTable2");
            decimal acumulado = 0;
            decimal residuo = 0;
            decimal empaque = 0;
            Producto prod = new Producto();

            dt1.Columns.Add("cliente.codigo");
            dt1.Columns.Add("cliente.rif");
            dt1.Columns.Add("cliente.DirFiscal");
            dt1.Columns.Add("cliente.Des1");
            dt1.Columns.Add("cliente.Des2");
            dt1.Columns.Add("cliente.Des3");
            dt1.Columns.Add("cliente.DirEnvio");
            dt1.Columns.Add("cliente.telefono");
            dt1.Columns.Add("cliente.zonaPostal");
            dt1.Columns.Add("cliente.UltimaCompra");
            dt1.Columns.Add("cliente.SaldoAct");
            dt1.Columns.Add("cliente.SaldoVencido");
            dt1.Columns.Add("cliente.FechaApertura");
            dt1.Columns.Add("cliente.LimiteCredito");
            dt1.Columns.Add("cliente.LimiteExceso");
            dt1.Columns.Add("cliente.nombre");
            dt1.Columns.Add("numeroPedido");
            dt1.Columns.Add("cliente.CondicionPago");
            dt1.Columns.Add("cliente.Vendedor");
            dt1.Columns.Add("usuario");
            dt1.Columns.Add("fechaP");
            dt1.Columns.Add("horaP");
            dt1.Columns.Add("cliente.Transporte");
            dt1.Columns.Add("total");
            dt1.Columns.Add("totalItems");
            dt1.Columns.Add("numeroControlPed");

            dt2.Columns.Add("@mov_codigo");
            dt2.Columns.Add("colProducto");
            dt2.Columns.Add("@mov_cant");
            dt2.Columns.Add("@mov_undmed");
            dt2.Columns.Add("@mov_precio");
            dt2.Columns.Add("@mov_desc");
            dt2.Columns.Add("@mov_item");
            dt2.Columns.Add("inv_grados");
            dt2.Columns.Add("simbolo");

            for (int x = 0; x < fact1.dgvItems.Rows.Count; x++)
            {
                DataRow filaDt2 = dt2.NewRow();
                residuo = 0;
                empaque = 0;
                filaDt2["@mov_codigo"] = fact1.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString();
                filaDt2["colProducto"] = fact1.dgvItems.Rows[x].Cells["colProducto"].Value.ToString();
                filaDt2["@mov_cant"] = fact1.dgvItems.Rows[x].Cells["@mov_cant"].Value.ToString();
                filaDt2["@mov_undmed"] = fact1.dgvItems.Rows[x].Cells["@mov_undmed"].Value.ToString();
                filaDt2["@mov_precio"] = fact1.dgvItems.Rows[x].Cells["@mov_precio"].Value.ToString().Replace(",", ".");
                filaDt2["@mov_desc"] = fact1.dgvItems.Rows[x].Cells["@mov_desc"].Value.ToString().Replace(",", ".");
                filaDt2["@mov_item"] = Convert.ToInt32(fact1.dgvItems.Rows[x].Cells["@mov_item"].Value.ToString());
                empaque = prod.invGrados(fact1.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString());
                if (centinela)
                {
                    if (empaque > 0)
                    {
                        residuo = Convert.ToInt32(fact1.dgvItems.Rows[x].Cells["@mov_cant"].Value.ToString()) / prod.invGrados(fact1.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString());
                    }
                    else
                    {
                        residuo = 0;
                    }

                    if (residuo > 0)
                    {
                        filaDt2["inv_grados"] = "*";
                    }
                    else
                    {
                        filaDt2["inv_grados"] = "";
                    }
                }
                else
                {
                    filaDt2["inv_grados"] = "";
                }
                acumulado = acumulado + (Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ",")) * Convert.ToDecimal(filaDt2["@mov_cant"].ToString().Replace(".", ",")));
                if ((Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ","))) > (Convert.ToDecimal(filaDt2["@mov_precio_ini"].ToString().Replace(".", ","))))
                {
                    filaDt2["simbolo"] = "+";
                }
                else if ((Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ","))) < (Convert.ToDecimal(fact1.dgvItems.Rows[x].Cells["@mov_precio_ini"].Value.ToString().Replace(".", ","))))
                {
                    filaDt2["simbolo"] = "-";
                }
                else
                {
                    filaDt2["simbolo"] = "";
                }
                dt2.Rows.Add(filaDt2);
            }

            DataRow filaDt1 = dt1.NewRow();
            filaDt1["cliente.codigo"] = cli1.Codigo;
            filaDt1["cliente.rif"] = cli1.Rif;
            filaDt1["cliente.DirFiscal"] = cli1.Direccion;
            filaDt1["cliente.Des1"] = cli1.DescuentoEnventas;
            filaDt1["cliente.Des2"] = cli1.descuento2;
            filaDt1["cliente.Des3"] = cli1.descuento3;
            filaDt1["cliente.DirEnvio"] = fact1.DireccionEnvio;
            filaDt1["cliente.telefono"] = cli1.Telefono;
            filaDt1["cliente.zonaPostal"] = cli1.ZonaPostal;
            filaDt1["cliente.UltimaCompra"] = "";//preguntar;
            filaDt1["cliente.SaldoAct"] = (cli1.saldoActualSalcli(cli1.Codigo, 0));
            filaDt1["cliente.SaldoVencido"] = (cli1.saldoVencidoSalcli(cli1.Codigo, 0, ((fact1.FechaFactura.Year.ToString()) + "-" + (fact1.FechaFactura.Month.ToString().PadLeft(2, '0')) + "-" + (fact1.FechaFactura.Day.ToString().PadLeft(2, '0')))));
            filaDt1["cliente.FechaApertura"] = cli1.fechaRegistro;
            filaDt1["cliente.LimiteCredito"] = cli1.limiteCredito;
            //filaDt1["cliente.LimiteExceso"] = ""; //
            filaDt1["cliente.LimiteExceso"] = (cli1.saldoActualSalcli(cli1.Codigo, 0) + acumulado).ToString().Replace(",", ".");
            filaDt1["cliente.nombre"] = cli1.Nombre;
            filaDt1["numeroPedido"] = fact1.CorrelativoInterno;
            filaDt1["cliente.CondicionPago"] = cli1.CondicionPago;
            filaDt1["cliente.Vendedor"] = cli1.Vendedor;
            filaDt1["usuario"] = usuario;
            /*if (fact1.fechaFactura.ToString().Equals("01/01/0001 0:00:00"))
            {
                filaDt1["fechaP"] = DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
                filaDt1["horaP"] = DateTime.Now.ToString("hh:mm:ss tt");
            }
            else
            {
                filaDt1["fechaP"] = "" + fact1.FechaFactura.Day.ToString().PadLeft(2, '0') + "/" + fact1.FechaFactura.Month.ToString().PadLeft(2, '0') + "/" + fact1.FechaFactura.Year.ToString();
                filaDt1["horaP"] = fact1.HoraAfectada;
            }*/
            filaDt1["fechaP"] = DateTime.Now.Day.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString("00").ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
            filaDt1["horaP"] = DateTime.Now.ToString("hh:mm:ss tt");


            filaDt1["cliente.ultimaCompra"] = cli1.fechaUltimaCompra;
            filaDt1["cliente.Transporte"] = nombreTransporte;
            filaDt1["total"] = acumulado.ToString().Replace(",", ".");
            filaDt1["totalItems"] = fact1.dgvItems.Rows.Count;
            filaDt1["numeroControlPed"] = fact1.NumeroPedido;
            dt1.Rows.Add(filaDt1);

            dts.Tables.Add(dt1);
            dts.Tables.Add(dt2);
            return dts;
        }




        public DataSet rptPedidoM2(Clientes cli1, string usuario, Factura fact1, string nombreTransporte, string status)
        {
            DataSet dts = new DataSet();
            DataTable dt1 = new DataTable("DataTable1");
            DataTable dt2 = new DataTable("DataTable2");
            decimal acumulado = 0;

            dt1.Columns.Add("cliente.codigo");
            dt1.Columns.Add("cliente.rif");
            dt1.Columns.Add("cliente.DirFiscal");
            dt1.Columns.Add("cliente.Des1");
            dt1.Columns.Add("cliente.Des2");
            dt1.Columns.Add("cliente.Des3");
            dt1.Columns.Add("cliente.DirEnvio");
            dt1.Columns.Add("cliente.telefono");
            dt1.Columns.Add("cliente.zonaPostal");
            dt1.Columns.Add("cliente.UltimaCompra");
            dt1.Columns.Add("cliente.SaldoAct");
            dt1.Columns.Add("cliente.SaldoVencido");
            dt1.Columns.Add("cliente.FechaApertura");
            dt1.Columns.Add("cliente.LimiteCredito");
            dt1.Columns.Add("cliente.LimiteExceso");
            dt1.Columns.Add("cliente.nombre");
            dt1.Columns.Add("numeroPedido");
            dt1.Columns.Add("cliente.CondicionPago");
            dt1.Columns.Add("cliente.Vendedor");
            dt1.Columns.Add("usuario");
            dt1.Columns.Add("fechaP");
            dt1.Columns.Add("horaP");
            dt1.Columns.Add("cliente.ultimaCompra");
            dt1.Columns.Add("cliente.LimiteCred");
            dt1.Columns.Add("cliente.Transporte");
            dt1.Columns.Add("total");
            dt1.Columns.Add("numeroPrefactura");
            dt1.Columns.Add("status");
            dt1.Columns.Add("numeroPed2");
            dt1.Columns.Add("totalItems");
            dt1.Columns.Add("numeroControlPed");

            dt2.Columns.Add("@mov_codigo");
            dt2.Columns.Add("colProducto");
            dt2.Columns.Add("@mov_cant");
            dt2.Columns.Add("@mov_undmed");
            dt2.Columns.Add("@mov_precio");
            dt2.Columns.Add("@mov_desc");
            dt2.Columns.Add("simbolo");//

            for (int x = 0; x < fact1.dgvItems.Rows.Count; x++)
            {
                DataRow filaDt2 = dt2.NewRow();
                filaDt2["@mov_codigo"] = fact1.dgvItems.Rows[x].Cells["@mov_codigo"].Value.ToString();
                filaDt2["colProducto"] = fact1.dgvItems.Rows[x].Cells["colProducto"].Value.ToString();
                filaDt2["@mov_cant"] = fact1.dgvItems.Rows[x].Cells["@mov_cant"].Value.ToString();
                filaDt2["@mov_undmed"] = fact1.dgvItems.Rows[x].Cells["@mov_undmed"].Value.ToString();
                filaDt2["@mov_precio"] = fact1.dgvItems.Rows[x].Cells["@mov_precio"].Value.ToString().Replace(",", ".");
                filaDt2["@mov_desc"] = fact1.dgvItems.Rows[x].Cells["@mov_desc"].Value.ToString().Replace(",", ".");
                acumulado = acumulado + (Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ",")) * Convert.ToDecimal(filaDt2["@mov_cant"].ToString().Replace(".", ",")));
                if ((Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ","))) > (Convert.ToDecimal(fact1.dgvItems.Rows[x].Cells["@mov_precio_ini"].Value.ToString().Replace(".", ","))))
                {
                    filaDt2["simbolo"] = "+";
                }
                else if ((Convert.ToDecimal(filaDt2["@mov_precio"].ToString().Replace(".", ","))) < (Convert.ToDecimal(filaDt2["@mov_precio_ini"].ToString().Replace(".", ","))))
                {
                    filaDt2["simbolo"] = "-";
                }
                else
                {
                    filaDt2["simbolo"] = "";
                }
                dt2.Rows.Add(filaDt2);
            }


            DataRow filaDt1 = dt1.NewRow();
            filaDt1["cliente.codigo"] = cli1.Codigo;
            filaDt1["cliente.rif"] = cli1.Rif;
            filaDt1["cliente.DirFiscal"] = cli1.Direccion;
            filaDt1["cliente.Des1"] = cli1.DescuentoEnventas;
            filaDt1["cliente.Des2"] = cli1.descuento2;
            filaDt1["cliente.Des3"] = cli1.descuento3;
            filaDt1["cliente.DirEnvio"] = fact1.DireccionEnvio;
            filaDt1["cliente.telefono"] = cli1.Telefono;
            filaDt1["cliente.zonaPostal"] = cli1.ZonaPostal;
            filaDt1["cliente.SaldoAct"] = ""; //
            filaDt1["cliente.SaldoVencido"] = "";//
            filaDt1["cliente.FechaApertura"] = "";//
            filaDt1["cliente.LimiteCredito"] = cli1.limiteCredito;
            filaDt1["cliente.LimiteExceso"] = (cli1.saldoActualSalcli(cli1.Codigo, 0) + acumulado).ToString().Replace(",", ".");
            filaDt1["cliente.nombre"] = cli1.Nombre;
            filaDt1["numeroPedido"] = fact1.facturaAfectada;
            filaDt1["cliente.CondicionPago"] = cli1.CondicionPago;
            filaDt1["cliente.Vendedor"] = cli1.Vendedor;
            filaDt1["usuario"] = usuario;
            filaDt1["fechaP"] = "" + fact1.FechaFactura.Day.ToString().PadLeft(2, '0') + "/" + fact1.FechaFactura.Month.ToString().PadLeft(2, '0') + "/" + fact1.FechaFactura.Year.ToString();
            filaDt1["horaP"] = fact1.HoraAfectada;
            filaDt1["cliente.ultimaCompra"] = fact1.clienteFacturar.fechaUltimaCompra;
            filaDt1["cliente.LimiteCred"] = fact1.clienteFacturar.limiteCredito;
            filaDt1["cliente.Transporte"] = nombreTransporte;
            filaDt1["total"] = acumulado.ToString().Replace(",", ".");
            filaDt1["numeroPrefactura"] = fact1.CorrelativoInterno;
            filaDt1["status"] = status;
            filaDt1["numeroPed2"] = fact1.NumeroPedido;
            filaDt1["totalItems"] = fact1.dgvItems.Rows.Count;
            filaDt1["numeroControlPed"] = fact1.NumeroPedido;
            dt1.Rows.Add(filaDt1);



            dts.Tables.Add(dt1);
            dts.Tables.Add(dt2);
            return dts;
        }


        //public void crearSentenciaCabecerapre(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
        //                                                                            string cambio, string pagado, string contado, string status)
        //{
        //    sentenciaSql = null;

        //    sentenciaSql = "INSERT INTO admdocclipre " +
        //                          "(dcli_cbtnum,dcli_cencos,dcli_codigo,dcli_codmon,dcli_sucursal, " +
        //                          "dcli_transpo,dcli_codven,dcli_condic,dcli_destino,dcli_origen, " +
        //                          "dcli_estado,dcli_expexp,dcli_facafe,dcli_girnum,dcli_hora, " +
        //                          "dcli_modfis,dcli_numero,dcli_numfis,dcli_numgtr,dcli_plaexp,  " +
        //                          "dcli_recnum,dcli_serfis,dcli_succli,dcli_tipafe,dcli_tipdoc, " +
        //                          "dcli_tiptra,dcli_usuario,dcli_zona,dcli_fecharecep,dcli_fchven, " +
        //                          "dcli_fecha,dcli_anufis,dcli_crerecibo,dcli_impreso,dcli_invmon,  " +
        //                          "dcli_estatus,dcli_baseneta,dcli_cxc,dcli_dcto,dcli_otroimp, " +
        //                          "dcli_mtocomisio,dcli_mtoiva,dcli_neto,dcli_numpag,dcli_otros,dcli_plazo, " +
        //                          "dcli_recargo,dclli_valcamb,dcli_dctobs,dcli_totdivi,dcli_descitem, " +
        //                          "dcli_descdoc,dcli_subbase,doc_impo,dcli_cantproduc,dcli_aprob1, " +
        //                          "dcli_aprob2, dcli_aprob3,dcli_impresora,dcli_caja, dcli_cerrado, " +
        //                          "dcli_cosfac, dcli_cosfac_n,dcli_cosfac_i,dcli_base_n,dcli_base_i, " +
        //                          "dcli_saldo, dcli_facafe2,dcli_subtotal,dcli_ivaGN,dcli_ivaRD,idSistema) VALUES (" +
        //                          "'$dcli_cbtnum','$dcli_cencos','$dcli_codigo','$dcli_codmon','$dcli_sucursal', " +
        //                          "'$dcli_transpo','$dcli_codven','$dcli_condic','$dcli_destino','$dcli_origen', " +
        //                          "'$dcli_estado','$dcli_expexp','$dcli_facafe','$dcli_girnum','$dcli_hora', " +
        //                          "'$dcli_modfis','$dcli_numero','$dcli_numfis','$dcli_numgtr','$dcli_plaexp', " +
        //                          "'$dcli_recnum','$dcli_serfis','$dcli_succli','$dcli_tipafe','$dcli_tipdoc', " +
        //                          "'$dcli_tiptra','$dcli_usuario','$dcli_zona','$dcli_fecharecep','$dcli_fchven', " +
        //                          "'$dcli_fecha','$dcli_anufis','$dcli_crerecibo','$1dcli_impreso','$dcli_invmon', " +
        //                          "'$dcli_estatus','$dcli_baseneta','$dcli_cxc','$1dcli_dcto','$dcli_otroimp', " +
        //                          "'$dcli_mtocomisio','$dcli_mtoiva','$dcli_neto','$dcli_numpag','$dcli_otros', " +
        //                          "'$dcli_plazo','$dcli_recargo','$dclli_valcamb','$dcli_dctobs','$dcli_totdivi', " +
        //                          "'$dcli_descitem','$dcli_descdoc','$dcli_subbase','$doc_impo','$dcli_cantproduc', " +
        //                          "'$dcli_aprob1','$dcli_aprob2','$dcli_aprob3','$dcli_impresora','$dcli_caja', " +
        //                          "'$dcli_cerrado','$dcli_cosfac','$5dcli_cosfac_n','$3dcli_cosfac_i','$1dcli_base_n', " +
        //                          "'$2dcli_base_i','$dcli_saldo','$1dcli_facafe2',$@dcli_subtotal,$?dcli_ivaGN,$?dcli_ivaRD,'$idSistema');";

        //    sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_estado", status /*this.dcli_expexp*/);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
        //    if (this.dcli_expexp != null)
        //    {
        //        this.update_expexp();
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_girnum", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_hora", DateTime.Now.ToString("hh:mm:ss tt"));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_modfis", " ");//obtener el modelo de la impresora fiscal
        //    sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
        //    if ((this.tipoDocumento.Equals("PRE")) || (this.tipoDocumento.Equals("CTZ")))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", string.Empty);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_recnum", string.Empty);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
        //    sentenciaSql = sentenciaSql.Replace("$dcli_succli", string.Empty);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PRE");//si es fav o dev = fav si es igual a PED va a ser igual a PED
        //    sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
        //    sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codigoUsuario);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_fecharecep", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_fchven", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_fecha", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
        //    sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
        //    if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
        //    }
        //    else
        //    {
        //        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
        //    }
        //    sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
        //    //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
        //    sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
        //    sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
        //    sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
        //    sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", string.Empty);
        //    sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
        //    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
        //    if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
        //        sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
        //    else
        //        sentenciaSql = sentenciaSql.Replace("$idSistema", " ");
        //}

        public void crearSentenciaCabecerapre(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                                                    string cambio, string pagado, string contado, string status)
        {
            sentenciaSql = null;

            sentenciaSql = "INSERT INTO admdocclipre " +
                                  "(dcli_cbtnum,dcli_cencos,dcli_codigo,dcli_codmon,dcli_sucursal, " +
                                  "dcli_transpo,dcli_codven,dcli_condic,dcli_destino,dcli_origen, " +
                                  "dcli_estado,dcli_expexp,dcli_facafe,dcli_girnum,dcli_hora, " +
                                  "dcli_modfis,dcli_numero,dcli_numfis,dcli_numgtr,dcli_plaexp,  " +
                                  "dcli_recnum,dcli_serfis,dcli_succli,dcli_tipafe,dcli_tipdoc, " +
                                  "dcli_tiptra,dcli_usuario,dcli_zona,dcli_fecharecep,dcli_fchven, " +
                                  "dcli_fecha,dcli_anufis,dcli_crerecibo,dcli_impreso,dcli_invmon,  " +
                                  "dcli_estatus,dcli_baseneta,dcli_cxc,dcli_dcto,dcli_otroimp, " +
                                  "dcli_mtocomisio,dcli_mtoiva,dcli_neto,dcli_numpag,dcli_otros,dcli_plazo, " +
                                  "dcli_recargo,dclli_valcamb,dcli_dctobs,dcli_totdivi,dcli_descitem, " +
                                  "dcli_descdoc,dcli_subbase,doc_impo,dcli_cantproduc,dcli_aprob1, " +
                                  "dcli_aprob2, dcli_aprob3,dcli_impresora,dcli_caja, dcli_cerrado, " +
                                  "dcli_cosfac, dcli_cosfac_n,dcli_cosfac_i,dcli_base_n,dcli_base_i, " +
                                  "dcli_saldo, dcli_facafe2,dcli_subtotal,dcli_ivaGN,dcli_ivaRD,idSistema) VALUES (" +
                                  "'$dcli_cbtnum','$dcli_cencos','$dcli_codigo','$dcli_codmon','$dcli_sucursal', " +
                                  "'$dcli_transpo','$dcli_codven','$dcli_condic','$dcli_destino','$dcli_origen', " +
                                  "'$dcli_estado','$dcli_expexp','$dcli_facafe','$dcli_girnum','$dcli_hora', " +
                                  "'$dcli_modfis','$dcli_numero','$dcli_numfis','$dcli_numgtr','$dcli_plaexp', " +
                                  "'$dcli_recnum','$dcli_serfis','$dcli_succli','$dcli_tipafe','$dcli_tipdoc', " +
                                  "'$dcli_tiptra','$dcli_usuario','$dcli_zona','$dcli_fecharecep','$dcli_fchven', " +
                                  "'$dcli_fecha','$dcli_anufis','$dcli_crerecibo','$1dcli_impreso','$dcli_invmon', " +
                                  "'$dcli_estatus','$dcli_baseneta','$dcli_cxc','$1dcli_dcto','$dcli_otroimp', " +
                                  "'$dcli_mtocomisio','$dcli_mtoiva','$dcli_neto','$dcli_numpag','$dcli_otros', " +
                                  "'$dcli_plazo','$dcli_recargo','$dclli_valcamb','$dcli_dctobs','$dcli_totdivi', " +
                                  "'$dcli_descitem','$dcli_descdoc','$dcli_subbase','$doc_impo','$dcli_cantproduc', " +
                                  "'$dcli_aprob1','$dcli_aprob2','$dcli_aprob3','$dcli_impresora','$dcli_caja', " +
                                  "'$dcli_cerrado','$dcli_cosfac','$5dcli_cosfac_n','$3dcli_cosfac_i','$1dcli_base_n', " +
                                  "'$2dcli_base_i','$dcli_saldo','$1dcli_facafe2',$@dcli_subtotal,$?dcli_ivaGN,$?dcli_ivaRD,'$idSistema');";

            sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
            sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
            sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
            sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
            sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
            sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
            sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status /*this.dcli_expexp*/);
            sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
            if (this.dcli_expexp != null)
            {
                this.update_expexp();
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
            sentenciaSql = sentenciaSql.Replace("$dcli_girnum", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_hora", DateTime.Now.ToString("hh:mm:ss tt"));
            sentenciaSql = sentenciaSql.Replace("$dcli_modfis", " ");//obtener el modelo de la impresora fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
            sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
            if ((this.tipoDocumento.Equals("PRE")) || (this.tipoDocumento.Equals("CTZ")))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", string.Empty);
            sentenciaSql = sentenciaSql.Replace("$dcli_recnum", string.Empty);
            sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
            sentenciaSql = sentenciaSql.Replace("$dcli_succli", string.Empty);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PRE");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
            sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codigoUsuario);
            sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_fecharecep", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_fchven", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_fecha", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
            sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
            sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
            if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
            }
            else
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
            sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
            sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
            sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
            //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
            sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
            sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", string.Empty);
            sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
            if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
                sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
            else
                sentenciaSql = sentenciaSql.Replace("$idSistema", " ");
        }

        public void ActualizarSentenciaCabecerapre(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                                                   string cambio, string pagado, string contado, string status)
        {
            sentenciaSql = null;

            sentenciaSql = "UPDATE admdoccliped SET dcli_cbtnum ='$dcli_cbtnum', dcli_cencos='$dcli_cencos',dcli_codigo ='$dcli_codigo', " +
                            "dcli_codmon='$dcli_codmon', dcli_sucursal='$dcli_sucursal', dcli_transpo='$dcli_transpo', dcli_codven='$dcli_codven', " +
                            "dcli_condic='$dcli_condic', dcli_destino='$dcli_destino',dcli_origen='$dcli_origen', dcli_estado='$dcli_estado', " +
                            "dcli_expexp='$dcli_expexp', dcli_facafe='$dcli_facafe', dcli_girnum='$dcli_girnum', dcli_modfis='$dcli_modfis', " +
                            "dcli_numfis='$dcli_numfis', dcli_numgtr='$dcli_numgtr', dcli_plaexp='$dcli_plaexp', dcli_recnum='$dcli_recnum', " +
                            "dcli_serfis='$dcli_serfis', dcli_succli='$dcli_succli', dcli_tipafe='$dcli_tipafe', " +
                            "dcli_tiptra='$dcli_tiptra', dcli_zona='$dcli_zona', dcli_anufis='$dcli_anufis', dcli_crerecibo='$1dcli_impreso', " +
                            "dcli_impreso='$1dcli_impreso', dcli_invmon='$dcli_invmon', dcli_estatus='$dcli_estatus', dcli_baseneta='$dcli_baseneta', " +
                            "dcli_cxc='$dcli_cxc', dcli_dcto='$1dcli_dcto', dcli_otroimp='$dcli_otroimp', dcli_mtocomisio='$dcli_mtocomisio', " +
                            "dcli_mtoiva='$dcli_mtoiva', dcli_neto='$dcli_neto', dcli_numpag='$dcli_numpag', dcli_otros='$dcli_otros', " +
                            "dcli_plazo='$dcli_plazo', dcli_recargo='$dcli_recargo', dclli_valcamb='$dclli_valcamb', dcli_dctobs='$dcli_dctobs', " +
                            "dcli_totdivi='$dcli_totdivi', dcli_descitem='$dcli_descitem', dcli_descdoc='$dcli_descdoc', dcli_subbase='$dcli_subbase', " +
                            "doc_impo='$doc_impo', dcli_cantproduc='$dcli_cantproduc', dcli_aprob1='$dcli_aprob1', dcli_aprob2='$dcli_aprob2', " +
                            "dcli_aprob3='$dcli_aprob3', dcli_impresora='$dcli_impresora', dcli_caja='$dcli_caja', dcli_cerrado='$dcli_cerrado', " +
                            "dcli_cosfac='$dcli_cosfac', dcli_cosfac_n='$5dcli_cosfac_n', dcli_cosfac_i='$3dcli_cosfac_i', dcli_base_n='$1dcli_base_n', " +
                            "dcli_base_i='$2dcli_base_i', dcli_saldo='$dcli_saldo', dcli_facafe2='$1dcli_facafe2', dcli_subtotal='$@dcli_subtotal', " +
                            "dcli_ivaGN='$?dcli_ivaGN', dcli_ivaRD='$?dcli_ivaRD', idSistema='$idSistema' WHERE dcli_numero='$dcli_numero' AND dcli_tipdoc='$dcli_tipdoc';";

            sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
            sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
            sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
            sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
            sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
            sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
            sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status /*this.dcli_expexp*/);
            sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
            if (this.dcli_expexp != null)
            {
                this.update_expexp();
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
            sentenciaSql = sentenciaSql.Replace("$dcli_girnum", codigoUsuario);//ultimo usuario que actualizo
            sentenciaSql = sentenciaSql.Replace("$dcli_modfis", DateTime.Now.ToString());//fecha de la ultima actualizacion
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno); sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
            sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
            sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PRE");//si es fav o dev = fav si es igual a PED va a ser igual a PED
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
            sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
            sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
            sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
            sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
            sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
            sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
            sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
            if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
            }
            else
            {
                sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
            }
            sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
            sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
            sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
            sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
            sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
            //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
            sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
            sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
            sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
            sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
            sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
            sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
            if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
                sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
            else
                sentenciaSql = sentenciaSql.Replace("$idSistema", " ");

            sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
        }

        public void guardarDetallePre(DataGridView detalles)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[52];

            sentenciaEnviar = "INSERT INTO adminvmovpre ( " +
                                      "mov_docaso,mov_tipoaso,mov_cencos,mov_codalm,mov_cdcomp,  " +
                                      "mov_codcta,mov_codigo,mov_codsuc,mov_codtra,mov_vendedor, " +
                                      "mov_docume,mov_hora,mov_item,mov_itemaso,mov_itemcomp, " +
                                      "mov_lista,mov_lote,mov_tipdoc,mov_ivatip,mov_tipo,mov_undmed, " +
                                      "mov_usuario,mov_fechven,mov_fecha,mov_bandas,mov_cant, " +
                                      "mov_contab,mov_costo,mov_cxund,mov_desc,mov_expendio, " +
                                      "mov_export,mov_fisico,mov_import,mov_otimp,mov_impprodu, " +
                                      "mov_invact,mov_iva,mov_logico,mov_mtocom,mov_memo, " +
                                      "mov_precio,mov_total,mov_talla,mov_color,mov_arancel, " +
                                      "mov_kilos,mov_impuesto,mov_cosmon,mov_totalmon,mov_precio_ini, " +
                                      "mov_porciva) VALUES( " +
                                      "@mov_docaso,@mov_tipoaso,@mov_cencos,@mov_codalm,@mov_cdcomp, " +
                                      "@mov_codcta,@mov_codigo,@mov_codsuc,@mov_codtra,@mov_vendedor, " +
                                      "@mov_docume,@mov_hora,@mov_item,@mov_itemaso,@mov_itemcomp, " +
                                      "@mov_lista,@mov_lote,@mov_tipdoc,@mov_ivatip,@mov_tipo, " +
                                      "@mov_undmed,@mov_usuario,@mov_fechven,@mov_fecha,@mov_bandas, " +
                                      "@mov_cant,@mov_contab,@mov_costo,@mov_cxund,@mov_desc, " +
                                      "@mov_expendio,@mov_export,@mov_fisico,@mov_import,@mov_otimp, " +
                                      "@mov_impprodu,@mov_invact,@mov_iva,@mov_logico,@mov_mtocom, " +
                                      "@mov_memo,@mov_precio,@mov_total,@mov_talla,@mov_color, " +
                                      "@mov_arancel,@mov_kilos,@mov_impuesto,@mov_cosmon,@mov_totalmon, " +
                                      "@mov_precio_ini,@mov_porciva);";

            parametrosEnviar[0] = "@mov_docaso";
            parametrosEnviar[1] = "@mov_tipoaso";
            parametrosEnviar[2] = "@mov_cencos";
            parametrosEnviar[3] = "@mov_codalm";
            parametrosEnviar[4] = "@mov_cdcomp";
            parametrosEnviar[5] = "@mov_codcta";
            parametrosEnviar[6] = "@mov_codigo";
            parametrosEnviar[7] = "@mov_codsuc";
            parametrosEnviar[8] = "@mov_codtra";
            parametrosEnviar[9] = "@mov_vendedor";
            parametrosEnviar[10] = "@mov_docume";
            parametrosEnviar[11] = "@mov_hora";
            parametrosEnviar[12] = "@mov_item";
            parametrosEnviar[13] = "@mov_itemaso";
            parametrosEnviar[14] = "@mov_itemcomp";
            parametrosEnviar[15] = "@mov_lista";
            parametrosEnviar[16] = "@mov_lote";
            parametrosEnviar[17] = "@mov_tipdoc";
            parametrosEnviar[18] = "@mov_ivatip";
            parametrosEnviar[19] = "@mov_tipo";
            parametrosEnviar[20] = "@mov_undmed";
            parametrosEnviar[21] = "@mov_usuario";
            parametrosEnviar[22] = "@mov_fechven";
            parametrosEnviar[23] = "@mov_fecha";
            parametrosEnviar[24] = "@mov_bandas";
            parametrosEnviar[25] = "@mov_cant";
            parametrosEnviar[26] = "@mov_contab";
            parametrosEnviar[27] = "@mov_costo";
            parametrosEnviar[28] = "@mov_cxund";
            parametrosEnviar[29] = "@mov_desc";
            parametrosEnviar[30] = "@mov_expendio";
            parametrosEnviar[31] = "@mov_export";
            parametrosEnviar[32] = "@mov_fisico";
            parametrosEnviar[33] = "@mov_import";
            parametrosEnviar[34] = "@mov_otimp";
            parametrosEnviar[35] = "@mov_impprodu";
            parametrosEnviar[36] = "@mov_invact";
            parametrosEnviar[37] = "@mov_iva";
            parametrosEnviar[38] = "@mov_logico";
            parametrosEnviar[39] = "@mov_mtocom";
            parametrosEnviar[40] = "@mov_memo";
            parametrosEnviar[41] = "@mov_precio";
            parametrosEnviar[42] = "@mov_total";
            parametrosEnviar[43] = "@mov_talla";
            parametrosEnviar[44] = "@mov_color";
            parametrosEnviar[45] = "@mov_arancel";
            parametrosEnviar[46] = "@mov_kilos";
            parametrosEnviar[47] = "@mov_impuesto";
            parametrosEnviar[48] = "@mov_cosmon";
            parametrosEnviar[49] = "@mov_totalmon";
            parametrosEnviar[50] = "@mov_precio_ini";
            parametrosEnviar[51] = "@mov_porciva";
            databaseConection.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            databaseConection.cerrarConexion();
        }

        public void borrarDetallePre(DataGridView detalles)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[2];

            sentenciaEnviar = "DELETE FROM adminvmovpre WHERE mov_docume =@mov_docume AND mov_tipdoc=@mov_tipdoc;";
            parametrosEnviar[0] = "@mov_docume";
            parametrosEnviar[1] = "@mov_tipdoc";
            databaseConection.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            databaseConection.cerrarConexion();
        }

        public bool existePedido(string numeroInterno)
        {
            DataTable dt = null;
            sentenciaSql = null;
            bool centinela = false;
            sentenciaSql = "SELECT dcli_numero FROM admdoccliped WHERE dcli_numero='$dcli_numero';";
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", numeroInterno);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dt.Rows[0]["dcli_numero"].ToString()))
                {
                    centinela = false;
                }
                else
                {
                    centinela = true;
                }

            }
            databaseConection.cerrarConexion();
            return centinela;
        }

        public DataTable prefacturaBuscado(string numero, string tipoDocumento)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                                        "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                                        "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                                        "FROM admdocclipre  " +
                                                        "LEFT JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                                        "WHERE  dcli_numero LIKE '%$1%'  OR dcli_numfis LIKE '%$1%' " +
                                                        "OR admclientes.cli_nombre LIKE '%$1%' AND dcli_tipdoc='$dcli_tipdoc';";
            sentenciaSql = sentenciaSql.Replace("$1", numero);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", tipoDocumento);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable prefacturaBuscado2(string fecha1, string fecha2, string tipoDoc)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                                        "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                                        "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_codmon,dcli_facafe  " +
                                                        "FROM admdocclipre  " +
                                                        "LEFT JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                                        "WHERE dcli_fecha BETWEEN '$fecha1' AND  '$fecha2' AND dcli_tipdoc='$t';";
            sentenciaSql = sentenciaSql.Replace("$fecha1", fecha1);
            sentenciaSql = sentenciaSql.Replace("$fecha2", fecha2);
            sentenciaSql = sentenciaSql.Replace("$t", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

       /*public void cargarPrefactura(string numeroInter, Clientes clientF, Vendedor vend1)
        {
            DataTable dtFactura;
            sentenciaSql = null;
            this.clienteFacturar = clientF;

            sentenciaSql = "SELECT dcli_codigo, dcli_codmon, dcli_codven, dcli_condic, dcli_facafe, " +
                "dcli_tipafe,dcli_tipdoc,dcli_invmon,dcli_baseneta,dcli_descitem, " +
                "dcli_subbase,doc_impo,TRUNCATE(dcli_cantproduc,0) 'dcli_cantproduc' ,dcli_cosfac_n,dcli_cosfac_i, " +
                "dcli_base_n,dcli_base_i,dcli_saldo,dcli_subtotal,dcli_ivaRD, " +
                "dcli_ivaGN, dcli_estado,dcli_numpag,idSistema,dcli_fecha,dcli_hora,dcli_transpo,dcli_cbtnum,dcli_girnum,  " +
                "dcli_facafe2, dcli_plaexp, dcli_recnum, dcli_succli,dcli_mtoiva " +
                "FROM admdocclipre WHERE dcli_numero='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", numeroInter);
            dtFactura = databaseConection.fDataTable(sentenciaSql);

            if (dtFactura.Rows.Count > 0)
            {
                clientF.Codigo = dtFactura.Rows[0]["dcli_codigo"].ToString();
                clientF.Transporte = dtFactura.Rows[0]["dcli_transpo"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_codmon"].ToString();
                vend1.CodigoV = dtFactura.Rows[0]["dcli_codven"].ToString();
                clientF.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.clienteFacturar.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.correlativoInterno = numeroInter;
                this.facturaAfectada = dtFactura.Rows[0]["dcli_facafe"].ToString();
                this.TipoDocumento = dtFactura.Rows[0]["dcli_tipdoc"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_invmon"].ToString();
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_baseneta"].ToString().Replace(".", ","));
                this.DescuentoItems = Convert.ToDecimal(dtFactura.Rows[0]["dcli_descitem"].ToString().Replace(".", ","));
                this.BaseEX = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subbase"].ToString().Replace(".", ","));
                this.baseGN = Convert.ToDecimal(dtFactura.Rows[0]["doc_impo"].ToString().Replace(".", ","));
                this.totalItems = Int32.Parse(dtFactura.Rows[0]["dcli_cantproduc"].ToString());
                this.CostoNacional = Convert.ToDecimal(Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_n"].ToString().Replace(".", ",")));
                this.CostoImportado = Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_i"].ToString().Replace(".", ","));
                this.BaseNacional = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_n"].ToString().Replace(".", ","));
                this.BaseImportada = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_i"].ToString().Replace(".", ","));
                this.TotalNeto = Convert.ToDecimal(dtFactura.Rows[0]["dcli_saldo"].ToString().Replace(".", ","));
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subtotal"].ToString().Replace(".", ","));
                this.ivaRD = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaRD"].ToString().Replace(".", ","));
                this.ivaGN = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaGN"].ToString().Replace(".", ","));
                this.dcli_estado = dtFactura.Rows[0]["dcli_estado"].ToString();
                this.numeroPedido = dtFactura.Rows[0]["dcli_numpag"].ToString();
                this.direccionEnvio = dtFactura.Rows[0]["idSistema"].ToString();
                this.fechaFactura = Convert.ToDateTime(dtFactura.Rows[0]["dcli_fecha"].ToString());
                this.HoraAfectada = dtFactura.Rows[0]["dcli_hora"].ToString();
                this.peso = dtFactura.Rows[0]["dcli_cbtnum"].ToString().Equals(" ") ? "0" : dtFactura.Rows[0]["dcli_cbtnum"].ToString();
                this.bultos = dtFactura.Rows[0]["dcli_girnum"].ToString();
                this.diasPP1 = dtFactura.Rows[0]["dcli_facafe2"].ToString();
                this.porcentajePP1 = dtFactura.Rows[0]["dcli_plaexp"].ToString();
                this.diasPP2 = dtFactura.Rows[0]["dcli_recnum"].ToString();
                this.porcentajePP2 = dtFactura.Rows[0]["dcli_succli"].ToString();
                this.ivaTotal = Convert.ToDecimal(dtFactura.Rows[0]["dcli_mtoiva"].ToString().Replace(".", ","));
            }
            databaseConection.cerrarConexion();
        }*/
        public void cargarPrefactura(string numeroInter, Clientes clientF, Vendedor vend1)
        {
            DataTable dtFactura;
            sentenciaSql = null;
            this.clienteFacturar = clientF;

            sentenciaSql = "SELECT dcli_codigo, dcli_codmon, dcli_codven, dcli_condic, dcli_facafe, " +
                "dcli_tipafe,dcli_tipdoc,dcli_invmon,dcli_baseneta,dcli_descitem, " +
                "dcli_subbase,doc_impo,TRUNCATE(dcli_cantproduc,0) 'dcli_cantproduc' ,dcli_cosfac_n,dcli_cosfac_i, " +
                "dcli_base_n,dcli_base_i,dcli_saldo,dcli_subtotal,dcli_ivaRD, " +
                "dcli_ivaGN, dcli_estado,dcli_numpag,idSistema,dcli_fecha,dcli_hora,dcli_transpo,dcli_cbtnum,dcli_girnum,  " +
                "dcli_facafe2, dcli_plaexp, dcli_recnum, dcli_succli,dcli_mtoiva " +
                "FROM admdocclipre WHERE dcli_numero='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", numeroInter);
            dtFactura = databaseConection.fDataTable(sentenciaSql);

            if (dtFactura.Rows.Count > 0)
            {
                clientF.Codigo = dtFactura.Rows[0]["dcli_codigo"].ToString();
                clientF.Transporte = dtFactura.Rows[0]["dcli_transpo"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_codmon"].ToString();
                vend1.CodigoV = dtFactura.Rows[0]["dcli_codven"].ToString();
                clientF.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.clienteFacturar.CondicionPago = dtFactura.Rows[0]["dcli_condic"].ToString();
                this.correlativoInterno = numeroInter;
                this.facturaAfectada = dtFactura.Rows[0]["dcli_facafe"].ToString();
                this.TipoDocumento = dtFactura.Rows[0]["dcli_tipdoc"].ToString();
                this.Divisa = dtFactura.Rows[0]["dcli_invmon"].ToString();
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_baseneta"].ToString().Replace(".", ","));
                this.DescuentoItems = Convert.ToDecimal(dtFactura.Rows[0]["dcli_descitem"].ToString().Replace(".", ","));
                this.BaseEX = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subbase"].ToString().Replace(".", ","));
                this.baseGN = Convert.ToDecimal(dtFactura.Rows[0]["doc_impo"].ToString().Replace(".", ","));
                this.totalItems = Int32.Parse(dtFactura.Rows[0]["dcli_cantproduc"].ToString());
                this.CostoNacional = Convert.ToDecimal(Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_n"].ToString().Replace(".", ",")));
                this.CostoImportado = Convert.ToDecimal(dtFactura.Rows[0]["dcli_cosfac_i"].ToString().Replace(".", ","));
                this.BaseNacional = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_n"].ToString().Replace(".", ","));
                this.BaseImportada = Convert.ToDecimal(dtFactura.Rows[0]["dcli_base_i"].ToString().Replace(".", ","));
                this.TotalNeto = Convert.ToDecimal(dtFactura.Rows[0]["dcli_saldo"].ToString().Replace(".", ","));
                this.TotalBase = Convert.ToDecimal(dtFactura.Rows[0]["dcli_subtotal"].ToString().Replace(".", ","));
                this.ivaRD = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaRD"].ToString().Replace(".", ","));
                this.ivaGN = Convert.ToDecimal(dtFactura.Rows[0]["dcli_ivaGN"].ToString().Replace(".", ","));
                this.dcli_estado = dtFactura.Rows[0]["dcli_estado"].ToString();
                this.numeroPedido = dtFactura.Rows[0]["dcli_numpag"].ToString();
                this.direccionEnvio = dtFactura.Rows[0]["idSistema"].ToString();
                this.fechaFactura = Convert.ToDateTime(dtFactura.Rows[0]["dcli_fecha"].ToString());
                this.HoraAfectada = dtFactura.Rows[0]["dcli_hora"].ToString();
                this.peso = dtFactura.Rows[0]["dcli_cbtnum"].ToString().Equals(" ") ? "0" : dtFactura.Rows[0]["dcli_cbtnum"].ToString();
                this.bultos = dtFactura.Rows[0]["dcli_girnum"].ToString();
                this.diasPP1 = dtFactura.Rows[0]["dcli_facafe2"].ToString();
                this.porcentajePP1 = dtFactura.Rows[0]["dcli_plaexp"].ToString();
                this.diasPP2 = dtFactura.Rows[0]["dcli_recnum"].ToString();
                this.porcentajePP2 = dtFactura.Rows[0]["dcli_succli"].ToString();
                this.ivaTotal = Convert.ToDecimal(dtFactura.Rows[0]["dcli_mtoiva"].ToString().Replace(".", ","));
            }
            databaseConection.cerrarConexion();
        }


        public DataTable itemsPre()
        {
            DataTable dtItems;
            sentenciaSql = null;
            sentenciaSql = "SELECT mov_docaso  '@mov_docaso',mov_tipoaso '@mov_tipoaso' ,mov_cencos '@mov_cencos',mov_codalm '@mov_codalm',mov_cdcomp '@mov_cdcomp' " +
            ",mov_codcta '@mov_codcta' ,mov_codsuc '@mov_codsuc',mov_codtra '@mov_codtra' ,mov_vendedor '@mov_vendedor',mov_docume '@mov_docume' " +
            ",mov_hora '@mov_hora',mov_item '@mov_item',mov_itemaso '@mov_itemaso' ,mov_itemcomp '@mov_itemcomp',mov_lista '@mov_lista' " +
            ",mov_lote '@mov_lote',mov_tipdoc '@mov_tipdoc',mov_ivatip '@mov_ivatip',mov_tipo '@mov_tipo' ,mov_undmed '@mov_undmed'" +
            ",mov_usuario '@mov_usuario',mov_fechven '@mov_fechven',mov_fecha '@mov_fecha',mov_bandas '@mov_bandas',mov_contab '@mov_contab' " +
            ",mov_cxund '@mov_cxund',mov_expendio '@mov_expendio',mov_export '@mov_export',mov_fisico '@mov_fisico',mov_import '@mov_import'" +
            ",mov_otimp '@mov_otimp',mov_impprodu '@mov_impprodu',mov_invact '@mov_invact',mov_iva '@mov_iva',mov_logico '@mov_logico' " +
            ",mov_mtocom '@mov_mtocom',mov_memo '@mov_memo',mov_talla '@mov_talla',mov_color '@mov_color',mov_arancel '@mov_arancel' " +
            ",mov_kilos '@mov_kilos',mov_impuesto '@mov_impuesto',mov_cosmon '@mov_cosmon',mov_totalmon '@mov_totalmon',mov_precio_ini '@mov_precio_ini' " +
            ",mov_porciva '@mov_porciva', mov_codigo '@mov_codigo', mov_precio '@mov_precio', mov_memo 'colProducto',mov_total '@mov_total',TRUNCATE(mov_cant,0) '@mov_cant', mov_desc '@mov_desc', mov_costo '@mov_costo', " +
            " ult_provee 'procedencia'  FROM adminvmovpre " +
            " LEFT JOIN  adminv ON adminv.inv_codigo = adminvmovpre.mov_codigo " +
            " LEFT JOIN  adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
            " WHERE mov_docume='$1';";

            sentenciaSql = sentenciaSql.Replace("$1", this.correlativoInterno);
            dtItems = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dtItems;
        }

        public DataTable lbxPreBulto()
        {
            DataTable dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado " +
                                "FROM admdocclipre  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                "WHERE  dcli_estado='1' OR dcli_estado='2'  " +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";

            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable lbxOPRE(string tipoDoc)
        {
            DataTable dt;
            dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdocclipre  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                "WHERE  dcli_tipdoc= '$tipo' " +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
            sentenciaSql = sentenciaSql.Replace("$tipo", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql, 200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable lbxOPRE(string tipoDoc, string status)
        {
            DataTable dt;
            dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdocclipre  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                "WHERE  dcli_tipdoc= '$tipo' AND dcli_estado='$dcli_estado' " +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
            sentenciaSql = sentenciaSql.Replace("$tipo", tipoDoc);
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status);
            dt = databaseConection.fDataTable(sentenciaSql, 200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable prefacturaBuscado(string numero, string tipoDocumento, string status)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                  "FROM admdocclipre  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                  "WHERE  dcli_numero LIKE '%$1%'  OR dcli_numfis LIKE '%$1%' AND dcli_estado='$dcli_estado' " +
                                  "OR admclientes.cli_nombre LIKE '%$1%' AND dcli_tipdoc='$dcli_tipdoc';";
            sentenciaSql = sentenciaSql.Replace("$1", numero);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", tipoDocumento);
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable prefacturaBuscado2(string fecha1, string fecha2, string tipoDoc, string status)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_codmon,dcli_facafe  " +
                                  "FROM admdocclipre  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdocclipre.dcli_codigo  " +
                                  "WHERE dcli_fecha BETWEEN '$fecha1' AND  '$fecha2' AND dcli_tipdoc='$t' AND dcli_estado='$dcli_estado';";
            sentenciaSql = sentenciaSql.Replace("$fecha1", fecha1);
            sentenciaSql = sentenciaSql.Replace("$fecha2", fecha2);
            sentenciaSql = sentenciaSql.Replace("$t", tipoDoc);
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public void ActualizarSentenciaCabecerpre(Clientes clienteFactura, Vendedor vendedorFactura, string codigoEmpresaActual, string codigoUsuario, string codCaja,
                                                                           string cambio, string pagado, string contado)
                {
                    sentenciaSql = null;

                    sentenciaSql = "UPDATE admdocclipre SET dcli_cbtnum ='$dcli_cbtnum', dcli_cencos='$dcli_cencos',dcli_codigo ='$dcli_codigo', " +
                                    "dcli_codmon='$dcli_codmon', dcli_sucursal='$dcli_sucursal', dcli_transpo='$dcli_transpo', dcli_codven='$dcli_codven', " +
                                    "dcli_condic='$dcli_condic', dcli_destino='$dcli_destino',dcli_origen='$dcli_origen', dcli_estado='$dcli_estado', " +
                                    "dcli_expexp='$dcli_expexp', dcli_facafe='$dcli_facafe', dcli_girnum='$dcli_girnum', dcli_modfis='$dcli_modfis', " +
                                    "dcli_numfis='$dcli_numfis', dcli_numgtr='$dcli_numgtr', dcli_plaexp='$dcli_plaexp', dcli_recnum='$dcli_recnum', " +
                                    "dcli_serfis='$dcli_serfis', dcli_succli='$dcli_succli', dcli_tipafe='$dcli_tipafe', " +
                                    "dcli_tiptra='$dcli_tiptra', dcli_zona='$dcli_zona', dcli_anufis='$dcli_anufis', dcli_crerecibo='$1dcli_impreso', " +
                                    "dcli_impreso='$1dcli_impreso', dcli_invmon='$dcli_invmon', dcli_estatus='$dcli_estatus', dcli_baseneta='$dcli_baseneta', " +
                                    "dcli_cxc='$dcli_cxc', dcli_dcto='$1dcli_dcto', dcli_otroimp='$dcli_otroimp', dcli_mtocomisio='$dcli_mtocomisio', " +
                                    "dcli_mtoiva='$dcli_mtoiva', dcli_neto='$dcli_neto', dcli_numpag='$dcli_numpag', dcli_otros='$dcli_otros', " +
                                    "dcli_plazo='$dcli_plazo', dcli_recargo='$dcli_recargo', dclli_valcamb='$dclli_valcamb', dcli_dctobs='$dcli_dctobs', " +
                                    "dcli_totdivi='$dcli_totdivi', dcli_descitem='$dcli_descitem', dcli_descdoc='$dcli_descdoc', dcli_subbase='$dcli_subbase', " +
                                    "doc_impo='$doc_impo', dcli_cantproduc='$dcli_cantproduc', dcli_aprob1='$dcli_aprob1', dcli_aprob2='$dcli_aprob2', " +
                                    "dcli_aprob3='$dcli_aprob3', dcli_impresora='$dcli_impresora', dcli_caja='$dcli_caja', dcli_cerrado='$dcli_cerrado', " +
                                    "dcli_cosfac='$dcli_cosfac', dcli_cosfac_n='$5dcli_cosfac_n', dcli_cosfac_i='$3dcli_cosfac_i', dcli_base_n='$1dcli_base_n', " +
                                    "dcli_base_i='$2dcli_base_i', dcli_saldo='$dcli_saldo', dcli_facafe2='$1dcli_facafe2', dcli_subtotal='$@dcli_subtotal', " +
                                    "dcli_ivaGN='$?dcli_ivaGN', dcli_ivaRD='$?dcli_ivaRD', idSistema='$idSistema' WHERE dcli_numero='$dcli_numero' AND dcli_tipdoc='$dcli_tipdoc';";

                    sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", " ");
                    sentenciaSql = sentenciaSql.Replace("$dcli_cencos", "0000000001");
                    sentenciaSql = sentenciaSql.Replace("$dcli_codigo", clienteFactura.Codigo);
                    sentenciaSql = sentenciaSql.Replace("$dcli_codmon", "Bs");
                    sentenciaSql = sentenciaSql.Replace("$dcli_sucursal", "0000" + codigoEmpresaActual);
                    sentenciaSql = sentenciaSql.Replace("$dcli_transpo", clienteFactura.Transporte);
                    sentenciaSql = sentenciaSql.Replace("$dcli_codven", vendedorFactura.CodigoV);
                    sentenciaSql = sentenciaSql.Replace("$dcli_condic", clienteFactura.CodigoCondicionPago);
                    sentenciaSql = sentenciaSql.Replace("$dcli_destino", "Nacional");
                    sentenciaSql = sentenciaSql.Replace("$dcli_origen", "Nacional");
                    sentenciaSql = sentenciaSql.Replace("$dcli_estado", this.dcli_estado /*this.dcli_expexp*/);
                    sentenciaSql = sentenciaSql.Replace("$dcli_expexp", this.dcli_estado);
                    if (this.dcli_expexp != null)
                    {
                        this.update_expexp();
                    }
                    sentenciaSql = sentenciaSql.Replace("$dcli_facafe", (this.tipoDocumento.Equals("FAV") ? this.correlativoInterno : this.facturaAfectada));
                    sentenciaSql = sentenciaSql.Replace("$dcli_girnum", codigoUsuario);//ultimo usuario que actualizo
                    sentenciaSql = sentenciaSql.Replace("$dcli_modfis", DateTime.Now.ToString());//fecha de la ultima actualizacion
                    sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno); sentenciaSql = sentenciaSql.Replace("$dcli_numfis", " ");//obtener numero fiscal de la impresora
                    if ((this.tipoDocumento.Equals("PRE")) || (this.tipoDocumento.Equals("CTZ")))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_numgtr", " ");
                    }
                    sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", " ");
                    sentenciaSql = sentenciaSql.Replace("$dcli_recnum", " ");
                    sentenciaSql = sentenciaSql.Replace("$dcli_serfis", " ");//obtener la serie fiscal del punto de venta habilitado
                    sentenciaSql = sentenciaSql.Replace("$dcli_succli", " ");
                    if (this.tipoDocumento.Equals("CTZ"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "CTZ");//si es fav o dev = fav si es igual a PED va a ser igual a PED
                    }
                    if (this.tipoDocumento.Equals("PRE"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_tipafe", "PRE");//si es fav o dev = fav si es igual a PED va a ser igual a PED
                    }
                    sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
                    if (this.tipoDocumento.Equals("CTZ"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
                    }
                    if (this.tipoDocumento.Equals("PRE"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_tiptra", " ");
                    }

                    sentenciaSql = sentenciaSql.Replace("$dcli_zona", " ");

                    sentenciaSql = sentenciaSql.Replace("$dcli_anufis", " ");
                    sentenciaSql = sentenciaSql.Replace("$dcli_crerecibo", " ");
                    sentenciaSql = sentenciaSql.Replace("$1dcli_impreso", "0");//0 por defecto y se actualiza cuando se obtiene numero fiscal
                    sentenciaSql = sentenciaSql.Replace("$dcli_invmon", "Bs");
                    sentenciaSql = sentenciaSql.Replace("$dcli_estatus", this.dcli_estado);
                    sentenciaSql = sentenciaSql.Replace("$dcli_baseneta", Convert.ToString(this.TotalBase).Replace(",", "."));
                    if (this.tipoDocumento.Equals("CTZ"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
                    }
                    if (this.tipoDocumento.Equals("PRE"))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_cxc", "-1");
                    }
                    sentenciaSql = sentenciaSql.Replace("$1dcli_dcto", Convert.ToString(this.DescuentoGeneral).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_otroimp", "0");
                    sentenciaSql = sentenciaSql.Replace("$dcli_mtocomisio", "0");
                    sentenciaSql = sentenciaSql.Replace("$dcli_mtoiva", Convert.ToString(this.IvaTotal).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_neto", Convert.ToString(this.totalNeto).Replace(",", "."));
                    if (!((this.numeroPedido.Equals("")) || (this.numeroPedido.Equals(" ")) || (this.numeroPedido == null)))
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", this.numeroPedido);
                    }
                    else
                    {
                        sentenciaSql = sentenciaSql.Replace("$dcli_numpag", "");
                    }
                    sentenciaSql = sentenciaSql.Replace("$dcli_otros", "0");
                    sentenciaSql = sentenciaSql.Replace("$dcli_plazo", Convert.ToString(this.PlazoDias));
                    sentenciaSql = sentenciaSql.Replace("$dcli_recargo", "0");
                    sentenciaSql = sentenciaSql.Replace("$dclli_valcamb", "1");
                    sentenciaSql = sentenciaSql.Replace("$dcli_dctobs", "0.00");
                    sentenciaSql = sentenciaSql.Replace("$dcli_totdivi", Convert.ToString(this.totalNeto).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_descitem", Convert.ToString(this.DescuentoItems).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_descdoc", "0.00");
                    sentenciaSql = sentenciaSql.Replace("$dcli_subbase", Convert.ToString(this.BaseEX).Replace(",", "."));
                    //sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.baseGN).Replace(",","."));
                    sentenciaSql = sentenciaSql.Replace("$doc_impo", Convert.ToString(this.TotalBase).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_cantproduc", Convert.ToString(this.totalItems));
                    sentenciaSql = sentenciaSql.Replace("$dcli_aprob1", this.dcli_aprob1);
                    sentenciaSql = sentenciaSql.Replace("$dcli_aprob2", this.dcli_aprob2);
                    sentenciaSql = sentenciaSql.Replace("$dcli_aprob3", this.dcli_aprob3);
                    sentenciaSql = sentenciaSql.Replace("$dcli_impresora", " ");//obtener serie fiscal impresora
                    sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
                    sentenciaSql = sentenciaSql.Replace("$dcli_cerrado", "0");
                    sentenciaSql = sentenciaSql.Replace("$dcli_cosfac", Convert.ToString((this.CostoNacional + this.CostoImportado)).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$5dcli_cosfac_n", Convert.ToString(this.CostoNacional).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$3dcli_cosfac_i", Convert.ToString(this.CostoImportado).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$1dcli_base_n", Convert.ToString(this.BaseNacional).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$2dcli_base_i", Convert.ToString(this.BaseImportada).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$dcli_saldo", "0");
                    sentenciaSql = sentenciaSql.Replace("$1dcli_facafe2", " ");
                    sentenciaSql = sentenciaSql.Replace("$@dcli_subtotal", Convert.ToString(this.TotalBase).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaGN", Convert.ToString(this.ivaGN).Replace(",", "."));
                    sentenciaSql = sentenciaSql.Replace("$?dcli_ivaRD", Convert.ToString(this.ivaRD).Replace(",", "."));
                    if ((this.direccionEnvio != null) || (this.direccionEnvio != ""))
                        sentenciaSql = sentenciaSql.Replace("$idSistema", this.direccionEnvio);
                    else
                        sentenciaSql = sentenciaSql.Replace("$idSistema", " ");

                    sentenciaSql = sentenciaSql.Replace("$dcli_numero", this.CorrelativoInterno);
                    sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", this.TipoDocumento);//dependiendo de que lbx se llama se da el valor de SIN,CTZ,PED,NEN,CSG,FAV,DEV,DNE
                }
        public void dcli_impreso(Factura fact, string status)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admdoccli2 SET dcli_impreso='$dcli_impreso' WHERE dcli_numero" +
                "='$dcli_numero' AND dcli_tipdoc='$dcli_tipdoc$'";

            sentenciaSql = sentenciaSql.Replace("$dcli_impreso", status);
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", fact.correlativoInterno);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", fact.TipoDocumento);
            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }


        public string pedidoPrefactura(string num)
        {
            DataTable dt = null;
            sentenciaSql = null;
            string numero = "";
            sentenciaSql = "SELECT dcli_numero FROM admdocclipre WHERE dcli_facafe='$dcli_facafe';";
            sentenciaSql = sentenciaSql.Replace("$dcli_facafe", num);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                numero = dt.Rows[0]["dcli_numero"].ToString();
            }
            databaseConection.cerrarConexion();
            return numero;
        }

        

        //public DataTable lbxPed(string tipoDoc, string estatus)
        //{
        //    DataTable dt;
        //    dt = null;
        //    sentenciaSql = null;
        //    sentenciaSql = "SELECT " +
        //                        "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
        //                        "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
        //                        "FROM admdoccliped  " +
        //                        "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
        //                        "WHERE  dcli_tipdoc= '$tipo' " +
        //                        "AND dcli_estatus ='$dcli_estatus'" +
        //                        "GROUP BY dcli_codigo,dcli_numero " +
        //                        "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
        //    sentenciaSql = sentenciaSql.Replace("$tipo", tipoDoc);
        //    sentenciaSql = sentenciaSql.Replace("$dcli_estatus", estatus);
        //    dt = databaseConection.fDataTable(sentenciaSql, 200);
        //    databaseConection.cerrarConexion();
        //    return dt;
        //}

        public DataTable lbxPed(string tipoDoc, string estatus)
        {
            DataTable dt;
            dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                "FROM admdoccliped  " +
                                "LEFT OUTER JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                "WHERE  dcli_tipdoc= '$tipo' " +
                                "AND dcli_estatus ='$dcli_estatus'" +
                                "GROUP BY dcli_codigo,dcli_numero " +
                                "ORDER BY dcli_numero DESC, dcli_codigo ASC LIMIT 100; ";
            sentenciaSql = sentenciaSql.Replace("$tipo", tipoDoc);
            sentenciaSql = sentenciaSql.Replace("$dcli_estatus", estatus);
            dt = databaseConection.fDataTable(sentenciaSql, 200);
            databaseConection.cerrarConexion();
            return dt;
        }

        public void guardarProntoPagos(Factura fact)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admdocclipre SET dcli_facafe2='$dcli_facafe2'," +
                "dcli_plaexp='$dcli_plaexp', dcli_recnum='$dcli_recnum', dcli_succli='$dcli_succli' " +
                "WHERE dcli_numero='$dcli_numero';";

            sentenciaSql = sentenciaSql.Replace("$dcli_facafe2", string.IsNullOrEmpty(fact.diasPP1) ? "0" : fact.diasPP1);
            sentenciaSql = sentenciaSql.Replace("$dcli_plaexp", string.IsNullOrEmpty(fact.porcentajePP1) ? "0" : fact.porcentajePP1);
            sentenciaSql = sentenciaSql.Replace("$dcli_recnum", string.IsNullOrEmpty(fact.diasPP2) ? "0" : fact.diasPP2);
            sentenciaSql = sentenciaSql.Replace("$dcli_succli", string.IsNullOrEmpty(fact.porcentajePP2) ? "0" : fact.porcentajePP2);
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", fact.CorrelativoInterno);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public bool tienePP(Factura fact)
        {
            bool centinela = false;
            if (!(string.IsNullOrEmpty(fact.diasPP1)))
            {
                if (Convert.ToInt32(fact.diasPP1) > 0)
                {
                    centinela = true;
                    return centinela;
                }
            }
            return centinela;
        }

        public void UpdateRechazo(Factura fact, string codigo)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admdoccliped SET dcli_cbtnum ='$dcli_cbtnum'" +
                " WHERE dcli_numero='$dcli_numero';";
            sentenciaSql = sentenciaSql.Replace("$dcli_cbtnum", codigo);
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", fact.correlativoInterno);
            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public DataTable pedidoBuscado3(string fecha1, string fecha2, string tipoDoc, string status)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccliped  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                  "WHERE dcli_fecha BETWEEN '$fecha1' AND  '$fecha2' AND dcli_tipdoc='$t' " +
                                  "AND dcli_estado='$dcli_estado'";
            sentenciaSql = sentenciaSql.Replace("$fecha1", fecha1);
            sentenciaSql = sentenciaSql.Replace("$fecha2", fecha2);
            sentenciaSql = sentenciaSql.Replace("$t", tipoDoc);
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable pedidoBuscado4(string numero, string tipoDocumento, string status)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT " +
                                  "dcli_numero,dcli_codigo,cli_nombre,dcli_fecha,dcli_estado,dcli_neto, " +
                                  "dcli_tiptra,dcli_baseneta,dcli_numfis,dcli_impreso,dcli_tipdoc,dcli_codmon,dcli_facafe  " +
                                  "FROM admdoccliped  " +
                                  "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccliped.dcli_codigo  " +
                                  "WHERE  dcli_numero LIKE '%$1%'  OR dcli_numfis LIKE '%$1%' " +
                                  "OR admclientes.cli_nombre LIKE '%$1%' AND dcli_tipdoc='$dcli_tipdoc' " +
                                  "AND dcli_estado='$dcli_estado'";
            sentenciaSql = sentenciaSql.Replace("$1", numero);
            sentenciaSql = sentenciaSql.Replace("$dcli_tipdoc", tipoDocumento);
            sentenciaSql = sentenciaSql.Replace("$dcli_estado", status);
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public void aprobacionPedido(Factura fact, string status)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admdoccliped SET dcli_anufis='$dcli_anufis' WHERE dcli_numero='$dcli_numero';";
            sentenciaSql = sentenciaSql.Replace("$dcli_anufis", status);
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", fact.CorrelativoInterno);
            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public bool pedidoAprobado(Factura fact)
        {
            bool centinela = false;
            DataTable dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT dcli_anufis FROM admdoccliped WHERE dcli_numero='$dcli_numero';";
            sentenciaSql = sentenciaSql.Replace("$dcli_numero", fact.CorrelativoInterno);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["dcli_anufis"].ToString()))
                {
                    if ((dt.Rows[0]["dcli_anufis"].ToString().Equals("1")))
                    {
                        centinela = true;
                        return centinela;
                    }
                }
            }
            databaseConection.cerrarConexion();
            return centinela;
        }

    }
};