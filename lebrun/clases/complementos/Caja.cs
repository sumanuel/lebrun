using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using lebrun.clases.facturacion;
using System.Data;
using lebrun.clases.contabilidad;

namespace lebrun.clases.complementos
{
    public class Caja
    {
        private ConexionBD dataBaseConexion;
        private ConexionBD dataBaseSysconta;
        private string sentenciaSql;
        private string correlativoCaja;
        public DataTable dtReporte;
        private DataTable admdocli_2;
        private decimal totalFacturas;
        private decimal totalDevolucion;
        private decimal totalCuadre;
        private decimal totalEfectivo;
        private decimal totalCheque;
        private decimal totalTDebito;
        private decimal totalTCredito;
        private decimal totalIva;
        private decimal total1;
        private decimal subTotalPV;
        private string ctaVta_n;
        private string ctaVta_i;
        private string ctaCos_n;
        private string ctaCos_i;
        private string idCaja;
        private bool facturasNoImpresas;

        //cuentas para el cierre
        private string cta_caja;
        private string cta_auxiliar;
        private string cta_iva;
        private string cta_vDebito;
        private string cta_vCredito;
        private string cta_cCobrar;
        private decimal ifac;
        private decimal ivaDev;
        private decimal ifavCc;
        private decimal ivaDevC;
        private decimal favContado;
        private decimal bDev;
        private decimal bFacC;
        private decimal bDevC;
        private decimal cosFacNFav;
        private decimal cosFacNDev;
        private decimal cosFacIFav;
        private decimal cosFacIDev;
        private DataTable correlativos;


        private string cta_cFilial;
        private string cta_devCredito;
        private string cta_devContado;
        private string cta_ppContado;
        private string cta_ppCredito;


        private movimientoContable movimientoS;



        #region  gets and sets
        public decimal TotalFacturas
        {
            get { return totalFacturas; }
            set { totalFacturas = value; }
        }
        public decimal TotalDevolucion
        {
            get { return totalDevolucion; }
            set { totalDevolucion = value; }
        }
        public decimal TotalCuadre
        {
            get { return totalCuadre; }
            set { totalCuadre = value; }
        }
        public decimal TotalEfectivo
        {
            get { return totalEfectivo; }
            set { totalEfectivo = value; }
        }
        public decimal TotalCheque
        {
            get { return totalCheque; }
            set { totalCheque = value; }
        }
        public decimal TotalTDebito
        {
            get { return totalTDebito; }
            set { totalTDebito = value; }
        }
        public decimal TotalTCredito
        {
            get { return totalTCredito; }
            set { totalTCredito = value; }
        }
        public decimal TotalIva
        {
            get { return totalIva; }
            set { totalIva = value; }
        }
        public decimal Total1
        {
            get { return total1; }
            set { total1 = value; }
        }
        public decimal SubTotalPV
        {
            get { return subTotalPV; }
            set { subTotalPV = value; }
        }
        public string CtaVta_n
        {
            get { return ctaVta_n; }
            set { ctaVta_n = value; }
        }
        public string CtaVta_i
        {
            get { return ctaVta_i; }
            set { ctaVta_i = value; }
        }
        public string CtaCos_n
        {
            get { return ctaCos_n; }
            set { ctaCos_n = value; }
        }
        public string CtaCos_i
        {
            get { return ctaCos_i; }
            set { ctaCos_i = value; }
        }
        public string IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }
        public decimal Ifac
        {
            get { return ifac; }
            set { ifac = value; }
        }
        public decimal IvaDev
        {
            get { return ivaDev; }
            set { ivaDev = value; }
        }
        public decimal IfavCc
        {
            get { return ifavCc; }
            set { ifavCc = value; }
        }
        public decimal IvaDevC
        {
            get { return ivaDevC; }
            set { ivaDevC = value; }
        }
        public decimal FavContado
        {
            get { return favContado; }
            set { favContado = value; }
        }
        public decimal BDev
        {
            get { return bDev; }
            set { bDev = value; }
        }
        public decimal BFacC
        {
            get { return bFacC; }
            set { bFacC = value; }
        }
        public decimal BDevC
        {
            get { return bDevC; }
            set { bDevC = value; }
        }
        public decimal CosFacNFav
        {
            get { return cosFacNFav; }
            set { cosFacNFav = value; }
        }
        public decimal CosFacNDev
        {
            get { return cosFacNDev; }
            set { cosFacNDev = value; }
        }
        public decimal CosFacIFav
        {
            get { return cosFacIFav; }
            set { cosFacIFav = value; }
        }
        public decimal CosFacIDev
        {
            get { return cosFacIDev; }
            set { cosFacIDev = value; }
        }
        internal movimientoContable MovimientoS
        {
            get { return movimientoS; }
            set { movimientoS = value; }
        }
        public DataTable Correlativos
        {
            get { return correlativos; }
            set { correlativos = value; }
        }
        public bool FacturasNoImpresas
        {
            get { return facturasNoImpresas; }
            set { facturasNoImpresas = value; }
        }
        #endregion
		

        public string CorrelativoCaja
        {
            get { return correlativoCaja; }
            set { correlativoCaja = value; }
        }


        public Caja() {
            dataBaseConexion = new ConexionBD();
            sentenciaSql = null;
            correlativoCaja = null;
            cuentasCierre();
            movimientoS = new movimientoContable();
            FacturasNoImpresas = false;
        }


        public void insertMovCajaFacturacion(DataGridView datos,Factura facRelacionada){
            DataTable dt;
            string correlativo;
            string sentenciaEnviar = null;
            string[] parametros = new string[20];
            int respuestaBD;

            sentenciaEnviar = "INSERT INTO admmovcaja (movc_numtra,movc_codmaestr,movc_numdoc, " +
                                          "movc_descrioper,movc_operacion,mocv_forpag,movc_codtipopag,movc_tipoctaban, " +
                                          "movc_cuentacheq,movc_numero,movc_monto,movc_divisa,movc_fchemision, " +
                                          "movc_hora,movc_vendedor,movc_codcaja,movc_tipomovc,movc_estatus,movc_valcam,movc_memo) " +
                                          "VALUES(@movc_numtra1,@movc_codmaestr,@movc_numdoc2, " +
                                          "@movc_descrioper, @movc_operacion, @mocv_forpag, @movc_codtipopag7, @movc_tipoctaban5, " +
                                          "@movc_cuentacheq, @movc_numero3, @movc_monto, @movc_divisa, @movc_fchemision, " +
                                          "@movc_hora, @movc_vendedor, @movc_codcaja8, @movc_tipomovc6, @movc_estatus, @movc_valcam,@movc_memo" +
                                           ");";
            
            parametros[0] = "movc_numtra1";
            parametros[1] = "movc_codmaestr";
            parametros[2] = "movc_numdoc2";
            parametros[3] = "movc_descrioper";
            parametros[4] = "movc_operacion";
            parametros[5] = "mocv_forpag";
            parametros[6] = "movc_codtipopag7";
            parametros[7] = "movc_tipoctaban5";
            parametros[8] = "movc_cuentacheq";
            parametros[9] = "movc_numero3";
            parametros[10] = "movc_monto";
            parametros[11] = "movc_divisa";
            parametros[12] = "movc_fchemision";
            parametros[13] = "movc_hora";
            parametros[14] = "movc_vendedor";
            parametros[15] = "movc_codcaja8";
            parametros[16] = "movc_tipomovc6";
            parametros[17] = "movc_estatus";
            parametros[18] = "movc_valcam";
            parametros[19] = "movc_memo";
            
             foreach (DataGridViewRow fila in datos.Rows)
             {
                 
                 sentenciaSql = null;
                 dt = null;
                 correlativo = null;
                 DataGridViewRow filaNueva = new DataGridViewRow();
                 DataGridViewCell celdaNueva = new DataGridViewTextBoxCell();
                 respuestaBD=0;

                 sentenciaSql = "Call correlativoMovcaja";
                 dt = dataBaseConexion.fDataTable(sentenciaSql);
                 if(dt.Rows.Count>0){
                     correlativo = String.Format("{0:0000000000}",Convert.ToDouble( dt.Rows[0][0].ToString())+1);
                 }

                 celdaNueva = (DataGridViewCell)fila.Cells["movc_numtra"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[0].Value = correlativo;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_codmaestr"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[1].Value = fila.Cells["movc_codmaestr"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_numdoc"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[2].Value = facRelacionada.CorrelativoInterno;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_descrioper"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[3].Value = fila.Cells["movc_descrioper"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_operacion"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[4].Value = fila.Cells["movc_operacion"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["mocv_forpag"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[5].Value = fila.Cells["mocv_forpag"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_codtipopag"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[6].Value = fila.Cells["movc_codtipopag"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_tipoctaban"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[7].Value = fila.Cells["movc_tipoctaban"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_cuentacheq"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[8].Value = fila.Cells["movc_cuentacheq"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_numero"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[9].Value = fila.Cells["movc_numero"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_monto"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[10].Value = fila.Cells["movc_monto"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_divisa"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[11].Value = fila.Cells["movc_divisa"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_fchemision"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[12].Value = fila.Cells["movc_fchemision"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_hora"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[13].Value = fila.Cells["movc_hora"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_vendedor"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[14].Value = fila.Cells["movc_vendedor"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_codcaja"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[15].Value = fila.Cells["movc_codcaja"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_tipomovc"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[16].Value = fila.Cells["movc_tipomovc"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_estatus"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[17].Value = fila.Cells["movc_estatus"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_valcam"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[18].Value = fila.Cells["movc_valcam"].Value;
                 celdaNueva = (DataGridViewCell)fila.Cells["movc_memo"].Clone();
                 filaNueva.Cells.Add(celdaNueva);
                 filaNueva.Cells[19].Value = fila.Cells["movc_memo"].Value;


                 //solo si por cualquier cosa el correlativo de movcaja se duplica 0j0
                 respuestaBD = dataBaseConexion.insertDataGridViewRow(filaNueva, parametros, sentenciaEnviar);
                 while (respuestaBD == -2147467259)
                 {
                     sentenciaSql = "Call correlativoMovcaja";
                     dt = dataBaseConexion.fDataTable(sentenciaSql);
                     if (dt.Rows.Count > 0)
                     {
                         correlativo = String.Format("{0:0000000000}", Convert.ToDouble(dt.Rows[0][0].ToString()) + 1);
                     }
                     filaNueva.Cells[0].Value = correlativo;

                     respuestaBD = dataBaseConexion.insertDataGridViewRow(filaNueva, parametros, sentenciaEnviar);
                 }
             }

            dataBaseConexion.cerrarConexion();
        }

        public DataTable dtCancelado(string nroDocumento) {
            DataTable dtRegistros;
            sentenciaSql = null;
            sentenciaSql = "SELECT movc_cuentacheq 'movc_cuentacheq',movc_numero 'movc_numero',movc_divisa 'movc_divisa',movc_fchemision 'movc_fchemision',movc_hora 'movc_hora' ,   " +
                                  "movc_vendedor 'movc_vendedor',movc_codcaja 'movc_codcaja',movc_tipomovc 'movc_tipomovc',movc_estatus 'movc_estatus',movc_valcam 'movc_valcam', " +
                                  "movc_memo 'movc_memo',mocv_forpag 'mocv_forpag',movc_monto 'movc_monto',movc_numtra 'movc_numtra',movc_codmaestr 'movc_codmaestr',   " +
                                  "movc_numdoc 'movc_numdoc',movc_descrioper 'movc_descrioper',movc_operacion 'movc_operacion',movc_codtipopag 'movc_codtipopag',movc_tipoctaban 'movc_tipoctaban', " +
                                  "ban_nombre 'detalleTipo'" +
                                  "FROM admmovcaja LEFT OUTER JOIN "+
                                  "admbancos ON admbancos.ban_codigo = admmovcaja.movc_codtipopag "+
                                  "WHERE movc_numdoc ='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", nroDocumento);
            dtRegistros = dataBaseConexion.fDataTable(sentenciaSql);
            dataBaseConexion.cerrarConexion();
            return dtRegistros;
        }

      

        public DataTable cuentasCajaDoccli() {
            DataTable cuentas = null;
            sentenciaSql = null;

            sentenciaSql = "";
            return cuentas;
        }


        public void datosPrincipal(string codCaja, string codUsu)
        {

            sentenciaSql = null;


            sentenciaSql = "SELECT *, cli_nombre, cli_rif,  " +
                "IF(dcli_expexp='Activo','',IF((admmovcaja.mocv_forpag is null OR admmovcaja.mocv_forpag ='CAMBIO') and dcli_expexp='Pagado' ,'EFECTIVO',mocv_forpag)) as mocv_forpag2 " +
                "FROM admdoccli2 " +
                "LEFT JOIN admclientes ON admclientes.cli_codigo=admdoccli2.dcli_codigo " +
                "LEFT JOIN admmovcaja ON dcli_numero = admmovcaja.movc_numdoc " +
                "LEFT JOIN admcuentascaja ON admcuentascaja.ctascaj_codigo=dcli_caja " +
                "WHERE dcli_caja='$dcli_caja' AND dcli_cerrado='0' AND dcli_usuario='$usuario' AND dcli_tipdoc IN('FAV','DEV')  AND dcli_impreso='1' " +
                "GROUP BY  dcli_numero ORDER BY dcli_tipdoc, dcli_numero;";

            sentenciaSql = sentenciaSql.Replace("$dcli_caja", codCaja);
            sentenciaSql = sentenciaSql.Replace("$usuario", codUsu);
            admdocli_2 = dataBaseConexion.fDataTable(sentenciaSql);
            dataBaseConexion.cerrarConexion();

            dtReporte = new DataTable();
            dtReporte.TableName = "DataTable1";
            dtReporte.Columns.Add("dcli_numero");
            dtReporte.Columns.Add("cli_rif");
            dtReporte.Columns.Add("cli_nombre");
            dtReporte.Columns.Add("cli_telefono");
            dtReporte.Columns.Add("dcli_mtoiva");
            dtReporte.Columns.Add("dcli_neto");
            dtReporte.Columns.Add("mocv_forpag2");
            dtReporte.Columns.Add("dcli_numfis");
            dtReporte.Columns.Add("dcli_tipdoc");

            (from fila2 in admdocli_2.AsEnumerable()
             select new
             {
                 dcli_numero = fila2.Field<string>("dcli_numero"),
                 cli_rif = fila2.Field<string>("cli_rif"),
                 cli_nombre = fila2.Field<string>("cli_nombre"),
                 cli_telefono = fila2.Field<string>("cli_telefono"),
                 dcli_mtoiva = fila2.Field<decimal>("dcli_mtoiva"),
                 dcli_neto = fila2.Field<decimal>("dcli_neto"),
                 mocv_forpag2 = fila2.Field<string>("mocv_forpag2"),
                 dcli_numfis = fila2.Field<string>("dcli_numfis"),
                 dcli_tipdoc = fila2.Field<string>("dcli_tipdoc"),
             }).Aggregate(dtReporte, (z, r) =>
             {
                 z.Rows.Add(r.dcli_numero, r.cli_rif,
                     r.cli_nombre, r.cli_telefono,
                     r.dcli_mtoiva, r.dcli_neto, r.mocv_forpag2, r.dcli_numfis, r.dcli_tipdoc); return z;
             });

            DataTable resumen = new DataTable();
            resumen.Columns.Add("tDev", typeof(decimal));
            resumen.Columns.Add("tFac", typeof(decimal));
            resumen.Columns.Add("tDevC", typeof(decimal));
            resumen.Columns.Add("tFacC", typeof(decimal));
            resumen.Columns.Add("tDevF", typeof(decimal));
            resumen.Columns.Add("tFacF", typeof(decimal));
            resumen.Columns.Add("BDev", typeof(decimal));
            resumen.Columns.Add("BFac", typeof(decimal));
            resumen.Columns.Add("IDev", typeof(decimal));
            resumen.Columns.Add("IFac", typeof(decimal));
            resumen.Columns.Add("BDevC", typeof(decimal));
            resumen.Columns.Add("BFacC", typeof(decimal));
            resumen.Columns.Add("IDevC", typeof(decimal));
            resumen.Columns.Add("IFacC", typeof(decimal));
            resumen.Columns.Add("efectivo", typeof(decimal));
            resumen.Columns.Add("efectivo_dev", typeof(decimal));
            resumen.Columns.Add("cheque", typeof(decimal));
            resumen.Columns.Add("cheque_dev", typeof(decimal));
            resumen.Columns.Add("tarjetaC", typeof(decimal));
            resumen.Columns.Add("tarjetaCDev", typeof(decimal));
            resumen.Columns.Add("tarjetaD", typeof(decimal));
            resumen.Columns.Add("tarjetaDDev", typeof(decimal));
            resumen.Columns.Add("otros", typeof(decimal));
            resumen.Columns.Add("ivaFav", typeof(decimal));
            resumen.Columns.Add("ivaDev", typeof(decimal));
            resumen.Columns.Add("cosfacNFav", typeof(decimal));
            resumen.Columns.Add("cosfacNDev", typeof(decimal));
            resumen.Columns.Add("cosfacIFav", typeof(decimal));
            resumen.Columns.Add("cosfacIDev", typeof(decimal));

            (from fila in admdocli_2.AsEnumerable()

             select new
             {
                 tDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_neto") : 0),
                 tFac = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_neto") : 0),
                 tDevC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Activo") && (Convert.ToDecimal(s.Field<string>("dcli_codven").ToString()) <= Convert.ToDecimal("0000000080")) ? s.Field<decimal>("dcli_neto") : 0),
                 tFacC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Activo") && (Convert.ToDecimal(s.Field<string>("dcli_codven").ToString()) <= Convert.ToDecimal("0000000080")) ? s.Field<decimal>("dcli_neto") : 0),
                 tDevF = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Activo") && (Convert.ToDecimal(s.Field<string>("dcli_codven").ToString()) > Convert.ToDecimal("0000000080")) ? s.Field<decimal>("dcli_neto") : 0),
                 tFacF = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Activo") && (Convert.ToDecimal(s.Field<string>("dcli_codven").ToString()) > Convert.ToDecimal("0000000080")) ? s.Field<decimal>("dcli_neto") : 0),
                 BDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_baseneta") : 0),
                 BFac = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_baseneta") : 0),
                 IDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 IFac = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Pagado") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 BDevC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Activo") ? s.Field<decimal>("dcli_baseneta") : 0),
                 BFacC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Activo") ? s.Field<decimal>("dcli_baseneta") : 0),
                 IDevC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "-1") && (s.Field<string>("dcli_expexp") == "Activo") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 IFacC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_cxc") == "1") && (s.Field<string>("dcli_expexp") == "Activo") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 efectivo = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "EFECTIVO") && (s.Field<string>("dcli_cxc") == "1") ? s.Field<decimal>("dcli_neto") : 0),
                 efectivo_dev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "EFECTIVO") && (s.Field<string>("dcli_cxc") == "-1") ? s.Field<decimal>("dcli_neto") : 0),
                 cheque = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "CHEQUE") && (s.Field<string>("dcli_cxc") == "1") ? s.Field<decimal>("dcli_neto") : 0),
                 cheque_dev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "CHEQUE") && (s.Field<string>("dcli_cxc") == "-1") ? s.Field<decimal>("dcli_neto") : 0),
                 tarjetaC = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "TARJETA-C") && (s.Field<string>("dcli_cxc") == "1") ? s.Field<decimal>("dcli_neto") : 0),
                 tarjetaCDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "TARJETA-C") && (s.Field<string>("dcli_cxc") == "-1") ? s.Field<decimal>("dcli_neto") : 0),
                 tarjetaD = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "TARJETA-D") && (s.Field<string>("dcli_cxc") == "1") ? s.Field<decimal>("dcli_neto") : 0),
                 tarjetaDDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "TARJETA-D") && (s.Field<string>("dcli_cxc") == "-1") ? s.Field<decimal>("dcli_neto") : 0),
                 otros = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("mocv_forpag2") == "") || (s.Field<string>("mocv_forpag2").ToString() == null) ? s.Field<decimal>("dcli_neto") : 0),
                 ivaFav = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "FAV") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 ivaDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "DEV") ? s.Field<decimal>("dcli_mtoiva") : 0),
                 cosfacNFav = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "FAV") ? s.Field<decimal>("dcli_cosfac_n") : 0),
                 cosfacNDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "DEV") ? s.Field<decimal>("dcli_cosfac_n") : 0),
                 cosfacIFav = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "FAV") ? s.Field<decimal>("dcli_cosfac_i") : 0),
                 cosfacIDev = admdocli_2.AsEnumerable().Sum(s => (s.Field<string>("dcli_tipdoc") == "DEV") ? s.Field<decimal>("dcli_cosfac_i") : 0)

             }).Take(1).Aggregate(resumen, (x, r) =>
             {
                 x.Rows.Add(r.tDev, r.tFac, r.tDevC, r.tFacC, r.tDevF,
                                  r.tFacF, r.BDev, r.BFac, r.IDev, r.IFac, r.BDevC, r.BFacC, r.IDevC,
                                  r.IFacC, r.efectivo, r.efectivo_dev, r.cheque, r.cheque_dev, r.tarjetaC, r.tarjetaCDev, r.tarjetaD,
                                  r.tarjetaDDev, r.otros, r.ivaFav, r.ivaDev, r.cosfacNFav,
                                  r.cosfacNDev, r.cosfacIFav, r.cosfacIDev); return x;
             });

            this.totalFacturas = Convert.ToDecimal(resumen.Rows[0]["tFac"].ToString());
            this.totalDevolucion = Convert.ToDecimal(resumen.Rows[0]["tDev"].ToString());
            this.totalCuadre = Convert.ToDecimal(resumen.Rows[0]["tFac"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["tDev"].ToString());
            this.totalEfectivo = Convert.ToDecimal(resumen.Rows[0]["efectivo"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["efectivo_dev"].ToString());
            this.totalCheque = Convert.ToDecimal(resumen.Rows[0]["cheque"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["cheque_dev"].ToString());
            this.totalTDebito = Convert.ToDecimal(resumen.Rows[0]["tarjetaD"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["tarjetaDDev"].ToString());
            this.totalTCredito = Convert.ToDecimal(resumen.Rows[0]["tarjetaC"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["tarjetaCDev"].ToString());
            this.totalIva = Convert.ToDecimal(resumen.Rows[0]["ivaFav"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["ivaDev"].ToString());
            this.total1 = this.totalEfectivo + this.totalCheque + this.totalTCredito + this.totalTDebito;
            this.subTotalPV = ((Convert.ToDecimal(resumen.Rows[0]["tFacC"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["tDevC"].ToString())) + (Convert.ToDecimal(resumen.Rows[0]["tFacF"].ToString()) - Convert.ToDecimal(resumen.Rows[0]["tDevF"].ToString()))) + this.totalCuadre;
            this.ifac = Convert.ToDecimal(resumen.Rows[0]["IFac"].ToString());
            this.ivaDev = Convert.ToDecimal(resumen.Rows[0]["IDev"].ToString());
            this.ifavCc = Convert.ToDecimal(resumen.Rows[0]["IFacC"].ToString());
            this.ivaDevC = Convert.ToDecimal(resumen.Rows[0]["IDevC"].ToString());
            this.favContado = Convert.ToDecimal(resumen.Rows[0]["BFac"].ToString());
            this.bDev = Convert.ToDecimal(resumen.Rows[0]["BDev"].ToString());
            this.bFacC = Convert.ToDecimal(resumen.Rows[0]["BFacC"].ToString());
            this.bDevC = Convert.ToDecimal(resumen.Rows[0]["BDevC"].ToString());
            this.cosFacNFav = Convert.ToDecimal(resumen.Rows[0]["cosfacNFav"].ToString());
            this.cosFacNDev = Convert.ToDecimal(resumen.Rows[0]["cosfacNDev"].ToString());
            this.cosFacIFav = Convert.ToDecimal(resumen.Rows[0]["cosfacIFav"].ToString());
            this.cosFacIDev = Convert.ToDecimal(resumen.Rows[0]["cosfacIDev"].ToString());
        }

        public bool facturasCierre(string caja, string codUsu)
        {
            DataTable dt;
            bool centinela = false;
            sentenciaSql = null;

            sentenciaSql = "SELECT count(*) FROM admdoccli2 WHERE dcli_caja='$dcli_caja' AND dcli_cerrado='0' AND dcli_tipdoc IN('FAV','DEV') " +
                                  "AND dcli_impreso ='1'  AND	 dcli_usuario='$dcli_usuario';";

            sentenciaSql = sentenciaSql.Replace("$dcli_caja", caja);
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codUsu);

            dt = dataBaseConexion.fDataTable(sentenciaSql);

            if (dt.Rows.Count > 0)
            {
                if (!(dt.Rows[0]["count(*)"].ToString().Equals("0")))
                {
                    centinela = true;
                }
            }
            dataBaseConexion.cerrarConexion();
            return centinela;
        }

        public void facturasSinImprimir(string caja, string codUsu)
        {
            DataTable dt;

            sentenciaSql = null;
            sentenciaSql = "SELECT count(*) FROM admdoccli2 WHERE dcli_caja='$dcli_caja' AND dcli_cerrado='0' AND dcli_tipdoc IN('FAV','DEV') " +
                                  "AND dcli_impreso ='0'  AND	 dcli_usuario='$dcli_usuario';";

            sentenciaSql = sentenciaSql.Replace("$dcli_caja", caja);
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", codUsu);

            dt = dataBaseConexion.fDataTable(sentenciaSql);

            if (dt.Rows.Count > 0)
            {
                if (!(dt.Rows[0]["count(*)"].ToString().Equals("0")))
                {
                    this.facturasNoImpresas = true;
                }
                else
                {
                    this.facturasNoImpresas = false;
                }
            }
            dataBaseConexion.cerrarConexion();
        }
        

        public DataTable cajas()
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT DISTINCT usu_caja FROM confusuario  WHERE usu_caja!='' ORDER BY usu_caja;";
            dataBaseConexion.modificarConexionString(2);
            dt = dataBaseConexion.fDataTable(sentenciaSql);
            dataBaseConexion.modificarConexionString(1);
            dataBaseConexion.cerrarConexion();
            return dt;
        }

        public void cuentasCierre()
        {
            DataTable dt1, dt2;
            sentenciaSql = null;

            sentenciaSql = "SELECT tdc_codcta, tdc_reporte, tdc_auxiliar FROM admtipdocpro WHERE tdc_codigo='97'";
            dt1 = dataBaseConexion.fDataTable(sentenciaSql, 200);
            if (dt1.Rows.Count > 0)
            {
                this.ctaVta_n = dt1.Rows[0]["tdc_codcta"].ToString();
                this.ctaVta_i = dt1.Rows[0]["tdc_reporte"].ToString();
            }

            sentenciaSql = null;
            sentenciaSql = "SELECT tdc_codcta, tdc_reporte, tdc_auxiliar FROM admtipdocpro WHERE tdc_codigo='96'";
            dt2 = dataBaseConexion.fDataTable(sentenciaSql, 200);
            if (dt2.Rows.Count > 0)
            {
                this.ctaCos_n = dt2.Rows[0]["tdc_codcta"].ToString();
                this.ctaCos_i = dt2.Rows[0]["tdc_reporte"].ToString();
            }

            dataBaseConexion.cerrarConexion();
        }


        public Caja cierreCaja(string baseDatos, string codUsu)
        {
            DataTable tipos;
            DataRow filaDTDetalle;
            DateTime x = DateTime.Now;
            int item = 1;
            this.cuentasCierre();
            tipos = this.getnutipo();
            Correlativos = MovimientoS.obtenerNumeroComprobante(baseDatos, "02");
            MovimientoS.armarDataTableMovContab();

            this.cta_caja = admdocli_2.Rows[0]["ctascaj_cCaja"].ToString();
            this.cta_auxiliar = admdocli_2.Rows[0]["ctascaj_aCaja"].ToString();
            this.cta_iva = admdocli_2.Rows[0]["ctascaj_ivaDebito"].ToString();
            this.cta_vDebito = admdocli_2.Rows[0]["ctascaj_vDebito"].ToString();
            this.cta_vCredito = admdocli_2.Rows[0]["ctascaj_vCredito"].ToString();
            this.cta_cFilial = admdocli_2.Rows[0]["ctascaj_cxFilial"].ToString();
            this.cta_devCredito = admdocli_2.Rows[0]["ctascaj_ncDevCre"].ToString();
            this.cta_devContado = admdocli_2.Rows[0]["ctascaj_ncDevCont"].ToString();
            this.cta_ppContado = admdocli_2.Rows[0]["ctascaj_ncPPCont"].ToString();
            this.cta_ppCredito = admdocli_2.Rows[0]["ctascaj_ncPPCre"].ToString();

            if (this.total1 != 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["sufiDoc"] = "0";
                filaDTDetalle["tipoDoc"] = "0";
                filaDTDetalle["numComprobante"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["cuenta"] = this.cta_caja;
                filaDTDetalle["tipo"] = this.total1 < 0 ? "-1" : "1";
                filaDTDetalle["baseTipo"] = " ";
                filaDTDetalle["fecha"] = "" + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0') + "";
                filaDTDetalle["hora"] = x.ToString("hh:mm:ss");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                if (baseDatos.Equals("01"))
                {
                    filaDTDetalle["status"] = "1";
                }
                else
                {
                    filaDTDetalle["status"] = "2";
                }
                filaDTDetalle["login"] = codUsu;
                filaDTDetalle["idSistemas"] = Correlativos.Rows[0]["pc_idSistema"].ToString();
                filaDTDetalle["auxiliar"] = this.cta_auxiliar;
                filaDTDetalle["rif"] = " ";
                filaDTDetalle["nombre"] = " ";
                filaDTDetalle["tipoLetra"] = this.total1 < 0 ? "C" : "D";
                filaDTDetalle["islr"] = " ";
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                filaDTDetalle["referencia"] = " ";
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            for (int y = 0; y < admdocli_2.Rows.Count; y++)
            {
                if (admdocli_2.Rows[y]["dcli_expexp"].ToString().Equals("Activo"))
                {

                    filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                    filaDTDetalle["item"] = "" + item;
                    filaDTDetalle["codprove"] = admdocli_2.Rows[y]["cli_rif"].ToString();
                    filaDTDetalle["numeroDoc"] = " ";
                    filaDTDetalle["sufiDoc"] = "0";
                    filaDTDetalle["tipoDoc"] = admdocli_2.Rows[y]["dcli_tipdoc"].ToString();
                    filaDTDetalle["numComprobante"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                    filaDTDetalle["descripcion"] = admdocli_2.Rows[y]["cli_nombre"].ToString() + " " + admdocli_2.Rows[y]["dcli_numfis"].ToString();
                    filaDTDetalle["cuenta"] = admdocli_2.Rows[y]["admAC_codigoCuenta"].ToString();
                    filaDTDetalle["tipo"] = admdocli_2.Rows[y]["dcli_cxc"].ToString();
                    filaDTDetalle["baseTipo"] = " ";
                    filaDTDetalle["fecha"] = "" + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0') + "";
                    filaDTDetalle["hora"] = x.ToString("hh:mm:ss");
                    //admdocli_2.Rows[y]["dcli_neto"].ToString().Replace(",", ".");
                    filaDTDetalle["monto"] = Convert.ToString(Math.Abs(Convert.ToDecimal(admdocli_2.Rows[y]["dcli_neto"].ToString()))).Replace(",", ".");
                    if (baseDatos.Equals("01"))
                    {
                        filaDTDetalle["status"] = "1";
                    }
                    else
                    {
                        filaDTDetalle["status"] = "2";
                    }
                    filaDTDetalle["login"] = codUsu;
                    filaDTDetalle["idSistemas"] = Correlativos.Rows[0]["pc_idSistema"].ToString();
                    filaDTDetalle["auxiliar"] = admdocli_2.Rows[y]["admAC_codigoAuxiliarContable"].ToString();
                    filaDTDetalle["rif"] = admdocli_2.Rows[y]["cli_rif"].ToString();
                    filaDTDetalle["nombre"] = admdocli_2.Rows[y]["cli_nombre"].ToString();
                    filaDTDetalle["tipoLetra"] = admdocli_2.Rows[y]["dcli_cxc"].ToString().Equals("-1") ? "C" : "D";
                    filaDTDetalle["islr"] = " ";
                    filaDTDetalle["interno"] = admdocli_2.Rows[y]["dcli_numero"].ToString();//este es el campo movconnumdoc en sysconta detalles
                    filaDTDetalle["referencia"] = " ";
                    MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                    item = item + 1;
                }
            }

            if (this.ifac > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();

                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["sufiDoc"] = "0";
                filaDTDetalle["tipoDoc"] = "0";
                filaDTDetalle["numComprobante"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["cuenta"] = this.cta_iva;
                filaDTDetalle["tipo"] = "-1";
                filaDTDetalle["baseTipo"] = " ";
                filaDTDetalle["fecha"] = "" + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0') + "";
                filaDTDetalle["hora"] = x.ToString("hh:mm:ss");
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.ifac.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.ifac)).Replace(",", ".");
                if (baseDatos.Equals("01"))
                {
                    filaDTDetalle["status"] = "1";
                }
                else
                {
                    filaDTDetalle["status"] = "2";
                }
                filaDTDetalle["login"] = codUsu;
                filaDTDetalle["idSistemas"] = Correlativos.Rows[0]["pc_idSistema"].ToString();
                filaDTDetalle["auxiliar"] = " ";
                filaDTDetalle["rif"] = " ";
                filaDTDetalle["nombre"] = " ";
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["islr"] = " ";
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                filaDTDetalle["referencia"] = " ";
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.ivaDev > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["cuenta"] = this.cta_iva;
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";//aqui
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.ivaDev.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.ivaDev)).Replace(",", ".");
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }
            ///// AQUIIIIIIIIIIIIIII ERROR IVA CREDITO
            if (this.ifavCc > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];

                //filaDTDetalle["cuenta"] = admdocli_2.Rows[0]["ctascaj_ivaCredito"].ToString();
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["cuenta"] = this.cta_iva;
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["auxiliar"] = "";
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.ifavCc.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.ifavCc)).Replace(",", ".");
                filaDTDetalle["tipoLetra"] = "C";//aqui
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.ivaDevC > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];

                filaDTDetalle["cuenta"] = this.cta_iva;
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["auxiliar"] = "";
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.ivaDevC.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.ivaDevC)).Replace(",", ".");
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.favContado > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["tipo"] = "-1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.favContado.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.favContado)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.cta_vDebito;
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.bDev > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.bDev.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.bDev)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.cta_devContado;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.bFacC > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.bFacC.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.bFacC)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.cta_vCredito;
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.bDevC > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.bDevC.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.bDevC)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.cta_devCredito;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.cosFacNFav > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.cosFacNFav.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.cosFacNFav)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.ctaVta_n;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;

                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                filaDTDetalle["cuenta"] = this.ctaCos_n;
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.cosFacNDev > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.cosFacNDev.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.cosFacNDev)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.ctaVta_n;
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;

                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                filaDTDetalle["cuenta"] = this.ctaCos_n;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.cosFacIFav > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.cosFacIFav.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.cosFacIFav)).Replace(",", ".");
                filaDTDetalle["cuenta"] = this.ctaVta_i;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;

                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                filaDTDetalle["cuenta"] = this.ctaCos_i.ToString().Replace(",", ".");
                filaDTDetalle["tipoLetra"] = "C";
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            if (this.cosFacIDev > 0)
            {
                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                DataRow filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "-1";
                filaDTDetalle["cuenta"] = this.ctaVta_i;
                ////Convert.ToString(Math.Abs(this.total1)).Replace(",", ".");
                //this.cosFacIDev.ToString().Replace(",", ".");
                filaDTDetalle["monto"] = Convert.ToString(Math.Abs(this.cosFacIDev)).Replace(",", ".");
                filaDTDetalle["tipoLetra"] = "C";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;

                filaDTDetalle = MovimientoS.TablaContablidad.NewRow();
                filaCopia = MovimientoS.TablaContablidad.Rows[MovimientoS.TablaContablidad.Rows.Count - 1];
                filaDTDetalle.ItemArray = filaCopia.ItemArray.Clone() as object[];
                filaDTDetalle["numeroDoc"] = " ";
                filaDTDetalle["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + x.Year + "-" + x.Month.ToString().PadLeft(2, '0') + "-" + x.Day.ToString().PadLeft(2, '0');
                filaDTDetalle["item"] = "" + item;
                filaDTDetalle["tipo"] = "1";
                filaDTDetalle["cuenta"] = this.ctaCos_i;
                filaDTDetalle["tipoLetra"] = "D";
                filaDTDetalle["codprove"] = this.idCaja;
                filaDTDetalle["interno"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
                MovimientoS.TablaContablidad.Rows.Add(filaDTDetalle);
                item = item + 1;
            }

            MovimientoS.ingresarMovContab(MovimientoS.TablaContablidad);
            cabeceraMovContables(codUsu, baseDatos);
            return this;
        }


        public void cabeceraMovContables(string login, string idBaseDatos)
        {
            MovimientoS.armarDataTableCabeceraMovContab2();
            DateTime y = DateTime.Now;

            DataRow fila = MovimientoS.CabeceraTablaConta.NewRow();
            fila["comprobante"] = Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString();
            fila["fecSistema"] = "" + y.Year + "-" + y.Month.ToString().PadLeft(2, '0') + "-" + y.Day.ToString().PadLeft(2, '0') + "";
            fila["mcIdSistema"] = Correlativos.Rows[0]["pc_idSistema"].ToString();
            fila["Debito"] = MovimientoS.TablaContablidad.AsEnumerable().Sum(x => (x.Field<string>("tipoLetra").Equals("D") ? Convert.ToDecimal(x.Field<string>("monto").Replace(".", ",")) : 0));
            fila["Credito"] = MovimientoS.TablaContablidad.AsEnumerable().Sum(z => (z.Field<string>("tipoLetra").Equals("C") ? Convert.ToDecimal(z.Field<string>("monto").Replace(".", ",")) : 0));
            if (idBaseDatos.Equals("01"))
            {
                fila["estatus"] = "1";
            }
            else
            {
                fila["estatus"] = "2";
            }
            fila["login"] = login;
            fila["updateLogin"] = login;
            fila["compania"] = idBaseDatos;
            fila["idSistema"] = "CAJA";
            fila["hora"] = y.ToString("hh:mm:ss");
            fila["fepago"] = "" + y.Year + "-" + y.Month.ToString().PadLeft(2, '0') + "-" + y.Day.ToString().PadLeft(2, '0') + "";
            fila["descripcion"] = "CIERRE CAJA " + this.idCaja + " " + y.Year + "-" + y.Month.ToString().PadLeft(2, '0') + "-" + y.Day.ToString().PadLeft(2, '0') + "";
            fila["Debito"] = fila["Debito"].ToString().Replace(",", ".");
            fila["Credito"] = fila["Credito"].ToString().Replace(",", ".");
            MovimientoS.CabeceraTablaConta.Rows.Add(fila);

            MovimientoS.cabeceraSyscontabStatus(MovimientoS.CabeceraTablaConta, idBaseDatos);
            MovimientoS.detallesSyscontabStatus(MovimientoS.TablaContablidad, idBaseDatos);
        }


        private DataTable getnutipo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tipo1");
            dt.Columns.Add("tipo2");
            dt.Rows.Add();

            sentenciaSql = "SELECT ctd_nutipo FROM admtipdoccli WHERE ctd_tipo='FAV'";
            dt.Rows[0]["tipo1"] = dataBaseConexion.fDataTable(sentenciaSql).Rows[0]["ctd_nutipo"].ToString();

            sentenciaSql = "SELECT ctd_nutipo FROM admtipdoccli WHERE ctd_tipo='DEV'";
            dt.Rows[0]["tipo2"] = dataBaseConexion.fDataTable(sentenciaSql).Rows[0]["ctd_nutipo"].ToString();

            dataBaseConexion.cerrarConexion();
            return dt;
        }


        public void cerrarFacturas(string usu)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admdoccli SET dcli_cerrado='1' WHERE dcli_caja='$dcli_caja' AND dcli_usuario='$dcli_usuario' AND dcli_impreso='1' AND dcli_cerrado='0'";
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", this.idCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", usu);
            dataBaseConexion.ejecutarInsert(sentenciaSql, 200);
            dataBaseConexion.cerrarConexion();
        }

        public void cleanDoccli2(string usu)
        {
            sentenciaSql = null;
            sentenciaSql = "DELETE FROM admdoccli2  WHERE dcli_caja='$dcli_caja' AND dcli_usuario='$dcli_usuario' AND dcli_impreso='1';";
            sentenciaSql = sentenciaSql.Replace("$dcli_caja", this.idCaja);
            sentenciaSql = sentenciaSql.Replace("$dcli_usuario", usu);
            dataBaseConexion.ejecutarInsert(sentenciaSql, 200);
            dataBaseConexion.cerrarConexion();
        }

        public bool existeCierreCaja(string idBaseD)
        {
            bool centinela = false;
            MySqlDataReader dr;

            sentenciaSql = null;
            sentenciaSql = "SELECT mc_nroComprobante  FROM admmovimientoscontablesc WHERE mc_nroComprobante='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", Correlativos.Rows[0]["pc_CorrCompAut+1"].ToString());
            dataBaseConexion.conectionStringSysconta(idBaseD);
            dr = dataBaseConexion.ejecutarQueryDr(sentenciaSql);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetString(0) != "")
                    {
                        centinela = true;
                    }
                }
            }
            dr.Close();
            dataBaseConexion.modificarConexionString(1);
            dataBaseConexion.cerrarConexion();

            return centinela;
        }

        public void updateCierreDiario(string idSysconta)
        {
            DateTime tim = DateTime.Now;
            dataBaseSysconta = new ConexionBD(3);
            dataBaseSysconta.conectionStringSysconta(idSysconta);
            sentenciaSql = null;
            sentenciaSql = "UPDATE admparametroscontables SET pc_FechaUltimaDiario='$1' WHERE pc_idSistema='02';";
            sentenciaSql = sentenciaSql.Replace("$1", "" + tim.Year + "-" + tim.Month.ToString().PadLeft(2, '0') + "-" + tim.Day.ToString().PadLeft(2, '0'));
            dataBaseSysconta.ejecutarInsert(sentenciaSql);
            dataBaseSysconta.cerrarConexion();
        }

    }
}
