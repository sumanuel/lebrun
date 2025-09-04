using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;

namespace lebrun.clases.contabilidad
{
    public class Balance
    {   
        DataTable dtCuentasEstruturaCostos;
        private DataTable dtEstructuraCostos;
        DataTable dtExclusionesL;
        DataTable dtCreditos;
        DataTable dtDebitos;
        DataTable dtTotalesDeterminacionPVP;
        DataTable dtFactorIncidenciaCostosOperativos;
        ConexionBD dataBase;
        ConexionBD dataBaseSysconfig;
        DataTable dt;
        DataTable dtFactorCostosOperativos;
        string sentenciaSql = null;
        string codigoComp = null;
        public DataTable DtEstructuraCostos
        {
            get { return dtEstructuraCostos; }
            set { dtEstructuraCostos = value; }
        }
        DataTable factorPrecios;

        public Balance() 
{
            dataBase = new ConexionBD(3);
            dataBaseSysconfig = new ConexionBD(2);
            dtEstructuraCostos = new DataTable("DataTable1");
            dtEstructuraCostos.Columns.Add("cc_CodigoCuenta", typeof(string));
            dtEstructuraCostos.Columns.Add("cc_Descripcion", typeof(string));
            dtEstructuraCostos.Columns.Add("saldoActual", typeof(decimal));
            dtEstructuraCostos.Columns.Add("exclusiones", typeof(decimal));
            dtEstructuraCostos.Columns.Add("costosLopj", typeof(decimal));
            dtEstructuraCostos.Columns.Add("cc_FlagImpBal", typeof(int));
            dtEstructuraCostos.Columns.Add("cc_NivelTotal", typeof(UInt32));

            dtTotalesDeterminacionPVP = new DataTable("DataTable2");
            dtTotalesDeterminacionPVP.Columns.Add("titulo", typeof(string));
            dtTotalesDeterminacionPVP.Columns.Add("monto", typeof(decimal));
            dtTotalesDeterminacionPVP.Columns.Add("montoT", typeof(decimal));

            dtFactorIncidenciaCostosOperativos = new DataTable("DataTable3");
            dtFactorIncidenciaCostosOperativos.Columns.Add("monto", typeof(decimal));
            dtFactorIncidenciaCostosOperativos.Columns.Add("porcentaje", typeof(string));

            factorPrecios = new DataTable("DataTable4");
            factorPrecios.Columns.Add("titulo", typeof(string));
            factorPrecios.Columns.Add("base1", typeof(decimal));
            factorPrecios.Columns.Add("base2", typeof(decimal));
        }

        public Balance(string codComp)
        {
            dataBase = new ConexionBD(3);
            dataBase.conectionStringSysconta(codComp);
            dataBaseSysconfig = new ConexionBD(2);

            dtEstructuraCostos = new DataTable("DataTable1");
            dtEstructuraCostos.Columns.Add("cc_CodigoCuenta", typeof(string));
            dtEstructuraCostos.Columns.Add("cc_Descripcion", typeof(string));
            dtEstructuraCostos.Columns.Add("saldoActual", typeof(decimal));
            dtEstructuraCostos.Columns.Add("exclusiones", typeof(decimal));
            dtEstructuraCostos.Columns.Add("costosLopj", typeof(decimal));
            dtEstructuraCostos.Columns.Add("cc_FlagImpBal", typeof(int));
            dtEstructuraCostos.Columns.Add("cc_NivelTotal", typeof(UInt32));

            dtTotalesDeterminacionPVP = new DataTable("DataTable2");
            dtTotalesDeterminacionPVP.Columns.Add("titulo", typeof(string));
            dtTotalesDeterminacionPVP.Columns.Add("monto", typeof(decimal));
            dtTotalesDeterminacionPVP.Columns.Add("montoT", typeof(decimal));
            
            dtFactorIncidenciaCostosOperativos = new DataTable("DataTable3");
            dtFactorIncidenciaCostosOperativos.Columns.Add("monto", typeof(decimal));
            dtFactorIncidenciaCostosOperativos.Columns.Add("porcentaje", typeof(string));

            factorPrecios = new DataTable("DataTable4");
            factorPrecios.Columns.Add("titulo", typeof(string));
            factorPrecios.Columns.Add("base1", typeof(decimal));
            factorPrecios.Columns.Add("base2", typeof(decimal));
        }

        public DataTable dtSaldoActualEC(string fecha) {
            DataTable dt = null;
            DataTable dtCreditos = null;
            DataTable dtDebitos = null;
            string fechaDesde = null;

            dt = new DataTable();
            dt.Columns.Add("mcd_CodigoMayor", typeof(string));
            dt.Columns.Add("cc_Descripcion", typeof(string));
            dt.Columns.Add("saldoActual", typeof(decimal));
            dt.Columns.Add("cc_FlagImpBal", typeof(int));
            dt.Columns.Add("cc_NivelTotal", typeof(UInt32));

            fechaDesde = fechaCierre("08");
            setCuentasEstruturaC();
            dtCreditos = creditosEstructuraC(fechaDesde, fecha);
            dtDebitos = debitosEstructuraC(fechaDesde, fecha);

            (from cuentas in dtCuentasEstruturaCostos.AsEnumerable()
             join debitos in dtDebitos.AsEnumerable() on cuentas.Field<string>("cc_CodigoCuenta") equals debitos.Field<string>("mcd_CodigoMayor") into debiNull
             join creditos in dtCreditos.AsEnumerable() on cuentas.Field<string>("cc_CodigoCuenta") equals creditos.Field<string>("mcd_CodigoMayor") into crediNull
             from d in debiNull.DefaultIfEmpty()
             from c in crediNull.DefaultIfEmpty()
             select new
             {
                 mcd_CodigoMayor = cuentas.Field<string>("cc_CodigoCuenta"),
                 cc_Descripcion = cuentas.Field<string>("cc_Descripcion"),
                 saldoActual = (cuentas.Field<decimal>("cc_SaldoIniEjerc") + (d == null ? 0 : d.Field<decimal>("Dmdc_monto"))) - (c == null ? 0 : c.Field<decimal>("Cmdc_monto")),
                 cc_FlagImpBal = cuentas.Field<int>("cc_FlagImpBal"),
                 cc_NivelTotal = cuentas.Field<UInt32>("cc_NivelTotal")
             }).Aggregate(dt, (y, x) =>
             {
                 y.Rows.Add(x.mcd_CodigoMayor, x.cc_Descripcion, x.saldoActual, x.cc_FlagImpBal, x.cc_NivelTotal); return y;
             });
            return dt;
        }

        //retorna la fecha del ultimo cierre anual + 1 dia
        public string fechaCierre(string idSistema)
        {
            DataTable dt;
            string fecha = null;

            sentenciaSql = "SELECT pc_FechaUltCieA FROM admparametroscontables WHERE pc_idSistema='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", idSistema);

            dt = dataBase.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                fecha = dt.Rows[0]["pc_FechaUltCieA"].ToString();
                fecha = "" + Convert.ToDateTime(fecha).AddDays(1).Year + "/" + Convert.ToDateTime(fecha).AddDays(1).Month.ToString().PadLeft(2, '0') + "/" + Convert.ToDateTime(fecha).AddDays(1).Day.ToString().PadLeft(2, '0');
            }
            dataBase.cerrarConexion();
            return fecha;
        }

        public void setCuentasEstruturaC() {
            sentenciaSql = null;

            sentenciaSql = "SELECT cc_CodigoCuenta, cc_Descripcion,cc_SaldoIniEjerc, cc_FlagImpBal, cc_NivelTotal " +
                                 "FROM admcuentascontables " +
                                  "WHERE cc_FlagImpBal !=0 ORDER BY cc_CodigoCuenta, cc_NivelTotal asc,cc_FlagImpBal asc ";

            dtCuentasEstruturaCostos = dataBase.fDataTable(sentenciaSql);
            dataBase.cerrarConexion();
        }

        public DataTable debitosEstructuraC(string desde, string hasta) {
            sentenciaSql = null;
            DataTable dtTotal = new DataTable();

            dtTotal.Columns.Add("mcd_CodigoMayor", typeof(string));
            dtTotal.Columns.Add("Dmdc_monto", typeof(decimal));

            sentenciaSql = "SELECT  mcd_NroComprobante,mcd_CodigoMayor, mdc_TipoTransaccion, mdc_monto as Dmdc_monto FROM admmovimientoscontabled " +
            "WHERE mdc_FechaComprobante >= '$DESDE' AND mdc_FechaComprobante <= '$HASTA' "+
            "AND mdc_TipoTransaccion='D' ORDER BY mcd_CodigoMayor";

            sentenciaSql = sentenciaSql.Replace("$DESDE", desde);
            sentenciaSql = sentenciaSql.Replace("$HASTA", hasta);

            dtDebitos = dataBase.fDataTable(sentenciaSql);
            dataBase.cerrarConexion();

            (from fila in dtDebitos.AsEnumerable()
                 group fila by fila.Field<string>("mcd_CodigoMayor") into z
                 let row = z.First()
                 select new{
                     mcd_CodigoMayor = z.Key,
                     Dmdc_monto = z.Sum(p => p.Field<decimal>("Dmdc_monto"))
                 }).Aggregate(dtTotal, (q, s) =>
          {
              q.Rows.Add(s.mcd_CodigoMayor,  s.Dmdc_monto); return q;
          }
          );
           
            return dtTotal;
        }

        public DataTable creditosEstructuraC(string desde, string hasta) {
            sentenciaSql = null;
            DataTable dtTotal = new DataTable();

            dtTotal.Columns.Add("mcd_CodigoMayor", typeof(string));
            dtTotal.Columns.Add("Cmdc_monto", typeof(decimal));

            sentenciaSql = "SELECT  mcd_NroComprobante,mcd_CodigoMayor, mdc_TipoTransaccion,mdc_monto as Cmdc_monto " +
           "FROM admmovimientoscontabled " +
           "WHERE mdc_FechaComprobante >= '$DESDE' AND mdc_FechaComprobante <= '$HASTA' " +
           "AND mdc_TipoTransaccion='C' ORDER BY mcd_CodigoMayor";

            sentenciaSql = sentenciaSql.Replace("$DESDE", desde);
            sentenciaSql = sentenciaSql.Replace("$HASTA", hasta);

            dtCreditos = dataBase.fDataTable(sentenciaSql);
            dataBase.cerrarConexion();

            (from fila in dtCreditos.AsEnumerable()
             group fila by fila.Field<string>("mcd_CodigoMayor") into z
             let row = z.First()
             select new
             {
                 mcd_CodigoMayor = z.Key,
                 Cmdc_monto = z.Sum(p => p.Field<decimal>("Cmdc_monto"))
             }).Aggregate(dtTotal, (q, s) =>
             {
                 q.Rows.Add(s.mcd_CodigoMayor,  s.Cmdc_monto); return q;
             }
          );
            return dtTotal;
        }

        public bool isFechaUltCierreA(string fecha,string idSistema) {
            DataTable dt = null;
            bool cen = false;
            sentenciaSql = null;

            sentenciaSql = "SELECT pc_FechaUltCieA FROM admparametroscontables WHERE pc_idSistema='$IDSISTEMA';";
            sentenciaSql = sentenciaSql.Replace("$IDSISTEMA", idSistema);
            dt = dataBase.fDataTable(sentenciaSql);

            if (dt.Rows.Count > 0) {
                if (fecha.Equals(""+Convert.ToDateTime(dt.Rows[0]["pc_FechaUltCieA"].ToString()).Year+"/"+(Convert.ToDateTime(dt.Rows[0]["pc_FechaUltCieA"].ToString()).Month.ToString().PadLeft(2,'0'))+"/"+(Convert.ToDateTime(dt.Rows[0]["pc_FechaUltCieA"].ToString()).Day.ToString().PadLeft(2,'0')) ))
                    cen = true;
            }
            dataBase.cerrarConexion();
            return cen;
        }

        public void dtConTotal(DataTable dtSaldoAct) {
            dt = new DataTable();
            DataRow filaTemporal = null;
            string codigotemd;
            int nivelTotalTem;
            int c;
            int d;
            decimal acumulador;

            dt.Columns.Add("tipoC", typeof(string));
            dt.Columns.Add("mcd_CodigoMayor", typeof(string));
            dt.Columns.Add("cc_Descripcion", typeof(string));
            dt.Columns.Add("saldoActual", typeof(decimal));
            dt.Columns.Add("cc_FlagImpBal", typeof(int));
            dt.Columns.Add("cc_NivelTotal", typeof(UInt32));
          
            (from saldos in dtSaldoAct.AsEnumerable()
             group saldos by new
             {
                 //original
                 campo = (saldos.Field<string>("mcd_CodigoMayor").Substring(0, 4)).ToString()
             } into g
             from row in g
             select new
             {
                 tipoC = g.Key.campo.ToString(),
                 mcd_CodigoMayor = row.Field<string>("mcd_CodigoMayor"),
                 cc_Descripcion = "TOTAL " + row.Field<string>("cc_Descripcion"),
                 saldoActual = g.Sum(r => r.Field<decimal>("saldoActual")),
                 cc_FlagImpBal = row.Field<int>("cc_FlagImpBal"),
                 cc_NivelTotal = row.Field<UInt32>("cc_NivelTotal")
             }).GroupBy(ped => ped.tipoC).Select(p => p.FirstOrDefault()).Aggregate(dt, (x, y) =>
             {
                 x.Rows.Add(y.tipoC, y.mcd_CodigoMayor, y.cc_Descripcion, y.saldoActual, y.cc_FlagImpBal, y.cc_NivelTotal); return x;
             });
            
            #region original
            //foreach (DataRow fila in dtSaldoAct.Rows)
                //{
                //    DataRow filaNueva = DtEstructuraCostos.NewRow();
                //    string temp = null;
                //    if (codigo == null)
                //    {
                //        codigo = fila["mcd_CodigoMayor"].ToString();
                //    }
                //    temp = fila["mcd_CodigoMayor"].ToString().Substring(0, 3);
                //    if ((codigo.Substring(0, 3)).Equals(temp))
                //    {
                //        filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                //        filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                //        filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                //        filaNueva["exclusiones"] = 0.00;
                //        filaNueva["costosLopj"] = 0.00;
                //        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                //        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                //        DtEstructuraCostos.Rows.Add(filaNueva);
                //        ultimoCodigo = codigo;
                //    }
                //    else
                //    {
                //        foreach (DataRow fila2 in dt.Rows)
                //        {
                //            if (fila2["mcd_CodigoMayor"].ToString().Substring(0, 3).Equals(codigo.Substring(0, 3)))
                //            {
                //                filaNueva["cc_CodigoCuenta"] = "";
                //                filaNueva["cc_Descripcion"] = fila2["cc_Descripcion"].ToString();
                //                filaNueva["saldoActual"] = fila2["saldoActual"].ToString();
                //                filaNueva["exclusiones"] = 0.00;
                //                filaNueva["costosLopj"] = 0.00;
                //                filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila2["cc_FlagImpBal"].ToString());
                //                filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila2["cc_NivelTotal"].ToString());
                //                DtEstructuraCostos.Rows.Add(filaNueva);
                //                codigo = null;
                //                filaNueva = DtEstructuraCostos.NewRow();
                //                filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                //                filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                //                filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                //                filaNueva["exclusiones"] = 0.00;
                //                filaNueva["costosLopj"] = 0.00;
                //                filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                //                filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                //                DtEstructuraCostos.Rows.Add(filaNueva);
                //                ultimoCodigo = fila["mcd_CodigoMayor"].ToString();
                                
                //                if(!(fila["mcd_CodigoMayor"].ToString().Substring(0, 3).Equals(dtSaldoAct.Rows[dtSaldoAct.Rows.IndexOf(fila) + 1]["mcd_CodigoMayor"].ToString().Substring(0, 3)))){
                //                    foreach (DataRow fila3 in dt.Rows) {
                //                        if (fila3["mcd_CodigoMayor"].ToString().Substring(0, 3).Equals(fila["mcd_CodigoMayor"].ToString().Substring(0,3))) {
                //                            filaNueva = DtEstructuraCostos.NewRow();
                //                            filaNueva["cc_CodigoCuenta"] = "";
                //                            filaNueva["cc_Descripcion"] = fila3["cc_Descripcion"].ToString();
                //                            filaNueva["saldoActual"] = fila3["saldoActual"].ToString();
                //                            filaNueva["exclusiones"] = 0.00;
                //                            filaNueva["costosLopj"] = 0.00;
                //                            filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila3["cc_FlagImpBal"].ToString());
                //                            filaNueva["<cc_NivelTotal"] = Convert.ToUInt32(fila3["cc_NivelTotal"].ToString());
                //                            DtEstructuraCostos.Rows.Add(filaNueva);
                //                            codigo = null;
                //                            break;
                //                        }
                //                    }
                //                }
                //                break;
                //            }
                //        }
                //    }

                //}

            //if (ultimoCodigo != null)
            //{
            //    DataRow filaNueva = DtEstructuraCostos.NewRow();
            //    foreach (DataRow fila2 in dt.Rows)
            //    {
            //        if (fila2["mcd_CodigoMayor"].ToString().Substring(0, 3).Equals(ultimoCodigo.Substring(0, 3)))
            //        {
            //            filaNueva["cc_CodigoCuenta"] = "";
            //            filaNueva["cc_Descripcion"] = fila2["cc_Descripcion"].ToString();
            //            filaNueva["saldoActual"] = fila2["saldoActual"].ToString();
            //            filaNueva["exclusiones"] = 0.00;
            //            filaNueva["costosLopj"] = 0.00;
            //            filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila2["cc_FlagImpBal"].ToString());
            //            filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila2["cc_NivelTotal"].ToString());
            //            DtEstructuraCostos.Rows.Add(filaNueva);
            //            break;
            //        }
            //    }
            //}
#endregion 

            List<DataRow> lista = new List<DataRow>();
            foreach (DataRow fila in dtSaldoAct.Rows)
            {
                codigotemd = fila["mcd_CodigoMayor"].ToString();
                nivelTotalTem = Convert.ToInt32(fila["cc_NivelTotal"].ToString());
                DataRow filaNueva = dtEstructuraCostos.NewRow();
                if (lista.Count == 0)
                {
                    
                    if (Convert.ToInt16(fila["cc_NivelTotal"].ToString()) < 5)
                    {
                        lista.Add(fila);
                        filaNueva = dtEstructuraCostos.NewRow();
                        filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                        filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                        filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                        filaNueva["exclusiones"] = 0.00;
                        filaNueva["costosLopj"] = 0.00;
                        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                        DtEstructuraCostos.Rows.Add(filaNueva); 
                    }
                }    
                else {
                    c = Convert.ToInt32(fila["cc_NivelTotal"].ToString());
                    d = Convert.ToInt32(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString());
                    if (Convert.ToInt32(fila["cc_NivelTotal"].ToString()) >= Convert.ToInt32(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()))
                    {
                        if (esHijoDe((DataRow)lista[lista.Count - 1], fila))
                        {
                            if (Convert.ToInt32(fila["cc_NivelTotal"].ToString()) <= 4)
                            {
                                lista.Add(fila);
                            }
                            filaNueva = dtEstructuraCostos.NewRow();
                            filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                            filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                            filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                            filaNueva["exclusiones"] = 0.00;
                            filaNueva["costosLopj"] = 0.00;
                            filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                            filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                            DtEstructuraCostos.Rows.Add(filaNueva);
                        }
                        else
                        {
                            //se sabe que es un total y por ende se busca para agregarlo
                            foreach (DataRow fila2 in dt.Rows)
                            {
                                string a = fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString()));
                                string b = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()));
                                string codigo = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString();

                                if (fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString())).Equals(((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()))))
                                {
                                    filaNueva = dtEstructuraCostos.NewRow();
                                    filaNueva["cc_CodigoCuenta"] = "";
                                    filaNueva["cc_Descripcion"] = fila2["cc_Descripcion"].ToString();
                                    filaNueva["saldoActual"] = fila2["saldoActual"].ToString();
                                    filaNueva["exclusiones"] = 0.00;
                                    filaNueva["costosLopj"] = 0.00;
                                    filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila2["cc_FlagImpBal"].ToString());
                                    filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila2["cc_NivelTotal"].ToString());
                                    DtEstructuraCostos.Rows.Add(filaNueva);
                                    filaTemporal = ((DataRow)(lista[lista.Count - 1]));
                                    lista.RemoveAt(lista.Count - 1);
                                    lista.Insert(lista.Count, fila);
                                    break;
                                }
                            }
                            //despues de agregarlo valido si el anterior total es de el mismo nivel que el nuevo si es asi no pasa nada.
                            //si no se busca imprimir el otro total
                            if ((!(c == d)) || !(mismoNivelTotal(filaTemporal, ((DataRow)(lista[lista.Count - 1])))))
                            {
                                
                                //para saber si falta otro total
                                for (int k = dt.Rows.Count - 1; k > 0; k--)
                                {
                                    if (Convert.ToUInt32(dt.Rows[k]["cc_NivelTotal"].ToString()) < nivelTotalTem)
                                    {
                                        int putoNivelTotal = Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString());
                                        string sdfdfs = dt.Rows[k]["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()));
                                        string jajajaja = codigotemd.Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()));
                                        if (!(dt.Rows[k]["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString())) ==
                                            codigotemd.Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()))))
                                        {
                                            acumulador = 0;
                                            for (int y = 0; y < dtEstructuraCostos.Rows.Count; y++)
                                            {
                                                if (dtEstructuraCostos.Rows[y]["cc_CodigoCuenta"].ToString().Length > 0)
                                                {
                                                    if (esHijoDe(dt.Rows[k], dtEstructuraCostos.Rows[y]))
                                                    {
                                                        acumulador = acumulador + Convert.ToDecimal(dtEstructuraCostos.Rows[y]["saldoActual"].ToString());
                                                    }
                                                }
                                            }

                                            filaNueva = dtEstructuraCostos.NewRow();
                                            filaNueva["cc_CodigoCuenta"] = "";
                                            filaNueva["cc_Descripcion"] = dt.Rows[k]["cc_Descripcion"].ToString();
                                            filaNueva["saldoActual"] = acumulador;
                                            dt.Rows[k]["saldoActual"] = acumulador;
                                            filaNueva["exclusiones"] = 0.00;
                                            filaNueva["costosLopj"] = 0.00;
                                            filaNueva["cc_FlagImpBal"] = Convert.ToInt32(dt.Rows[k]["cc_FlagImpBal"].ToString());
                                            filaNueva["cc_NivelTotal"] = Convert.ToUInt32(dt.Rows[k]["cc_NivelTotal"].ToString());
                                            DtEstructuraCostos.Rows.Add(filaNueva);

                                            //para agregar el titulo
                                            filaNueva = dtEstructuraCostos.NewRow();
                                            filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                                            filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                                            filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                                            filaNueva["exclusiones"] = 0.00;
                                            filaNueva["costosLopj"] = 0.00;
                                            filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                                            filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                                            DtEstructuraCostos.Rows.Add(filaNueva);
                                        }
                                    }

                                }
                            }
                            else {
                                var nose = (from v in DtEstructuraCostos.AsEnumerable()
                                            where v.Field<string>("cc_CodigoCuenta").Equals(fila["mcd_CodigoMayor"].ToString())
                                            select new
                                            {
                                                primerCampo = v.Field<string>("cc_CodigoCuenta")
                                            });
                                if (nose.Count() == 0) {
                                    //para agregar el titulo
                                    filaNueva = dtEstructuraCostos.NewRow();
                                    filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                                    filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                                    filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                                    filaNueva["exclusiones"] = 0.00;
                                    filaNueva["costosLopj"] = 0.00;
                                    filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                                    filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                                    DtEstructuraCostos.Rows.Add(filaNueva);
                                }

                            }
                        }
                    }
                    else
                    {
                        #region antiguo
                        ////foreach(DataRow fila2 in dt.Rows){
                        ////    string a = fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString()));
                        ////    string b = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()));
                        ////    string codigo = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString();

                        ////    if (fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString())).Equals(((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()))))
                        ////    {
                        ////        filaNueva = dtEstructuraCostos.NewRow();
                        ////        filaNueva["cc_CodigoCuenta"] = "";
                        ////        filaNueva["cc_Descripcion"] = fila2["cc_Descripcion"].ToString();
                        ////        filaNueva["saldoActual"] = fila2["saldoActual"].ToString();
                        ////        filaNueva["exclusiones"] = 0.00;
                        ////        filaNueva["costosLopj"] = 0.00;
                        ////        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila2["cc_FlagImpBal"].ToString());
                        ////        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila2["cc_NivelTotal"].ToString());
                        ////        DtEstructuraCostos.Rows.Add(filaNueva);
                        ////        break;
                        ////    }   
                        ////}
                        ////lista.RemoveAt(lista.Count - 1);
                        ////lista.Insert(lista.Count, fila);
                        #endregion 
                        //se sabe que es un total y por ende se busca para agregarlo
                        foreach (DataRow fila2 in dt.Rows)
                        {
                            string a = fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString()));
                            string b = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()));
                            string codigo = ((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString();

                            if (fila2["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(fila2["cc_NivelTotal"].ToString())).Equals(((DataRow)(lista[lista.Count - 1]))["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(((DataRow)(lista[lista.Count - 1]))["cc_NivelTotal"].ToString()))))
                            {
                                filaNueva = dtEstructuraCostos.NewRow();
                                filaNueva["cc_CodigoCuenta"] = "";
                                filaNueva["cc_Descripcion"] = fila2["cc_Descripcion"].ToString();
                                filaNueva["saldoActual"] = fila2["saldoActual"].ToString();
                                filaNueva["exclusiones"] = 0.00;
                                filaNueva["costosLopj"] = 0.00;
                                filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila2["cc_FlagImpBal"].ToString());
                                filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila2["cc_NivelTotal"].ToString());
                                DtEstructuraCostos.Rows.Add(filaNueva);
                                filaTemporal = ((DataRow)(lista[lista.Count - 1]));
                                lista.RemoveAt(lista.Count - 1);
                                lista.Insert(lista.Count, fila);
                                break;
                            }
                        }
                        //despues de agregarlo valido si el anterior total es de el mismo nivel que el nuevo si es asi no pasa nada.
                        //si no se busca imprimir el otro total
                        if ((!(c == d)) || !(mismoNivelTotal(filaTemporal, ((DataRow)(lista[lista.Count - 1])))))
                        {
                            if (c < d) {
                                for (int k = dt.Rows.Count - 1; k > 0; k--) {
                                    if (Convert.ToUInt32(dt.Rows[k]["cc_NivelTotal"].ToString()) < nivelTotalTem) {
                                        acumulador = 0;
                                        for (int y = 0; y < dtEstructuraCostos.Rows.Count; y++)
                                        {
                                            if (dtEstructuraCostos.Rows[y]["cc_CodigoCuenta"].ToString().Length > 0)
                                            {
                                                if (esHijoDe(dt.Rows[k+1], dtEstructuraCostos.Rows[y]))
                                                {
                                                    acumulador = acumulador + Convert.ToDecimal(dtEstructuraCostos.Rows[y]["saldoActual"].ToString());
                                                }
                                            }
                                        }

                                        filaNueva = dtEstructuraCostos.NewRow();
                                        filaNueva["cc_CodigoCuenta"] = "";
                                        filaNueva["cc_Descripcion"] = dt.Rows[k+1]["cc_Descripcion"].ToString();
                                        filaNueva["saldoActual"] = acumulador;
                                        dt.Rows[k]["saldoActual"] = acumulador;
                                        filaNueva["exclusiones"] = 0.00;
                                        filaNueva["costosLopj"] = 0.00;
                                        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(dt.Rows[k+1]["cc_FlagImpBal"].ToString());
                                        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(dt.Rows[k+1]["cc_NivelTotal"].ToString());
                                        DtEstructuraCostos.Rows.Add(filaNueva);

                                        //para agregar el titulo
                                        filaNueva = dtEstructuraCostos.NewRow();
                                        filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                                        filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                                        filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                                        filaNueva["exclusiones"] = 0.00;
                                        filaNueva["costosLopj"] = 0.00;
                                        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                                        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                                        DtEstructuraCostos.Rows.Add(filaNueva);

                                    }
                                }
                            }

                            //para saber si falta otro total
                            for (int k = dt.Rows.Count - 1; k > 0; k--)
                            {
                                if (Convert.ToUInt32(dt.Rows[k]["cc_NivelTotal"].ToString()) < nivelTotalTem)
                                {
                                    int putoNivelTotal = Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString());
                                    string sdfdfs = dt.Rows[k]["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()));
                                    string jajajaja = codigotemd.Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()));
                                    if (!(dt.Rows[k]["mcd_CodigoMayor"].ToString().Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString())) ==
                                        codigotemd.Substring(0, Convert.ToInt16(dt.Rows[k]["cc_NivelTotal"].ToString()))))
                                    {
                                        acumulador = 0;
                                        for (int y = 0; y < dtEstructuraCostos.Rows.Count; y++)
                                        {
                                            if (dtEstructuraCostos.Rows[y]["cc_CodigoCuenta"].ToString().Length > 0)
                                            {
                                                if (esHijoDe(dt.Rows[k], dtEstructuraCostos.Rows[y]))
                                                {
                                                    acumulador = acumulador + Convert.ToDecimal(dtEstructuraCostos.Rows[y]["saldoActual"].ToString());
                                                }
                                            }
                                        }

                                        filaNueva = dtEstructuraCostos.NewRow();
                                        filaNueva["cc_CodigoCuenta"] = "";
                                        filaNueva["cc_Descripcion"] = dt.Rows[k]["cc_Descripcion"].ToString();
                                        filaNueva["saldoActual"] = acumulador;
                                        dt.Rows[k]["saldoActual"] = acumulador;
                                        filaNueva["exclusiones"] = 0.00;
                                        filaNueva["costosLopj"] = 0.00;
                                        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(dt.Rows[k]["cc_FlagImpBal"].ToString());
                                        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(dt.Rows[k]["cc_NivelTotal"].ToString());
                                        DtEstructuraCostos.Rows.Add(filaNueva);

                                        //para agregar el titulo
                                        filaNueva = dtEstructuraCostos.NewRow();
                                        filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                                        filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                                        filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                                        filaNueva["exclusiones"] = 0.00;
                                        filaNueva["costosLopj"] = 0.00;
                                        filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                                        filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                                        DtEstructuraCostos.Rows.Add(filaNueva);
                                    }
                                }

                            }
                        }
                        else
                        {
                            var nose = (from v in DtEstructuraCostos.AsEnumerable()
                                        where v.Field<string>("cc_CodigoCuenta").Equals(fila["mcd_CodigoMayor"].ToString())
                                        select new
                                        {
                                            primerCampo = v.Field<string>("cc_CodigoCuenta")
                                        });
                            if (nose.Count() == 0)
                            {
                                //para agregar el titulo
                                filaNueva = dtEstructuraCostos.NewRow();
                                filaNueva["cc_CodigoCuenta"] = fila["mcd_CodigoMayor"].ToString();
                                filaNueva["cc_Descripcion"] = fila["cc_Descripcion"].ToString();
                                filaNueva["saldoActual"] = Convert.ToDecimal(fila["saldoActual"].ToString());
                                filaNueva["exclusiones"] = 0.00;
                                filaNueva["costosLopj"] = 0.00;
                                filaNueva["cc_FlagImpBal"] = Convert.ToInt32(fila["cc_FlagImpBal"].ToString());
                                filaNueva["cc_NivelTotal"] = Convert.ToUInt32(fila["cc_NivelTotal"].ToString());
                                DtEstructuraCostos.Rows.Add(filaNueva);
                            }

                        }

                    }

                }

                if (dtSaldoAct.Rows.IndexOf(fila) == (dtSaldoAct.Rows.Count - 1))
                {
                    int cuenta = dtSaldoAct.Rows.IndexOf(fila);
                    int abvs = (dtSaldoAct.Rows.Count - 2);
                    filaNueva = dtEstructuraCostos.NewRow();
                    filaNueva["cc_CodigoCuenta"] = "";
                    filaNueva["cc_Descripcion"] = dt.Rows[dt.Rows.Count-1]["cc_Descripcion"].ToString();
                    filaNueva["saldoActual"] = dt.Rows[dt.Rows.Count - 1]["saldoActual"].ToString();
                    filaNueva["exclusiones"] = 0.00;
                    filaNueva["costosLopj"] = 0.00;
                    filaNueva["cc_FlagImpBal"] = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["cc_FlagImpBal"].ToString());
                    filaNueva["cc_NivelTotal"] = Convert.ToUInt32(dt.Rows[dt.Rows.Count - 1]["cc_NivelTotal"].ToString());
                    DtEstructuraCostos.Rows.Add(filaNueva);
                }

            }
        
            //setExclucionesLegales();
            setCostosLOPJ();
            //totalExclusionesCostos();
            //totalExclusionesCostos2();
            totalCostosDirectosOperaciones();
            llenarDeterminacionPVP();
            setFactorIncidenciaCO();
        }

        public bool esHijoDe(DataRow filaGuardada, DataRow filaComparar)
        {
            char[] arregloGuardada;
            char[] arregloComparar;
            bool centinela = true;

            arregloGuardada = filaGuardada["mcd_CodigoMayor"].ToString().ToCharArray();
            try
            {
                arregloComparar = filaComparar["mcd_CodigoMayor"].ToString().ToCharArray();
            }
            catch (Exception e) {
                string a = filaComparar["cc_CodigoCuenta"].ToString();
                arregloComparar = filaComparar["cc_CodigoCuenta"].ToString().ToCharArray();
            }
            for (int i = 0; i < Convert.ToInt16(filaGuardada["cc_NivelTotal"].ToString()); i++)
            {
                if (!(arregloGuardada[i].Equals(arregloComparar[i]))) {
                    centinela = false;
                    i = Convert.ToInt16(filaGuardada["cc_NivelTotal"].ToString()) + 1;
                }
            }
            return centinela;
        }

        public bool mismoNivelTotal(DataRow filaGuardada, DataRow filaComparar) {
            char[] arregloGuardada;
            char[] arregloComparar;
            bool centinela = false;
            
            arregloGuardada = filaGuardada["mcd_CodigoMayor"].ToString().ToCharArray();
            try
            {
                arregloComparar = filaComparar["mcd_CodigoMayor"].ToString().ToCharArray();
            }
            catch (Exception e)
            {
                string a = filaComparar["cc_CodigoCuenta"].ToString();
                arregloComparar = filaComparar["cc_CodigoCuenta"].ToString().ToCharArray();
            }

            if (filaGuardada["cc_NivelTotal"].ToString().Equals(filaComparar["cc_NivelTotal"].ToString())) {
                for (int u = 0; u < Convert.ToInt32(filaGuardada["cc_NivelTotal"].ToString())-1; u++)
                {
                    if (!(arregloGuardada[u].Equals(arregloComparar[u])))
                    {
                        centinela = false;
                        u = Convert.ToInt16(filaGuardada["cc_NivelTotal"].ToString()) + 1;
                    }
                    else
                    {
                        centinela = true;
                    }

                }
            }
            return centinela;
        }

        public void setExclucionesLegales() {
            dtExclusionesL = new DataTable();
            dtExclusionesL.Columns.Add("mcd_CodigoMayor", typeof(string));
            dtExclusionesL.Columns.Add("debitos", typeof(decimal));
            dtExclusionesL.Columns.Add("creditos", typeof(decimal));
            
            var debitos = (from total in dtDebitos.AsEnumerable()
                           group total by new
                           {
                               campo = (total.Field<string>("mcd_CodigoMayor"))
                           } into g
                           from row in g
                           select new
                           {
                               mcd_CodigoMayor = row.Field<string>("mcd_CodigoMayor"),
                               debitos = g.Sum(r => (r.Field<string>("mcd_NroComprobante").Substring(0,1).Equals("4")) ? r.Field<decimal>("Dmdc_monto") : 0)
                           }).GroupBy(l => l.mcd_CodigoMayor).Select(m => m.FirstOrDefault());

            var creditos = (from total2 in dtCreditos.AsEnumerable()
                            group total2 by new
                            {
                                campo2 = (total2.Field<string>("mcd_CodigoMayor"))
                            } into g
                            from r in g
                            select new
                            {
                                mcd_CodigoMayor = r.Field<string>("mcd_CodigoMayor"),
                                creditos = g.Sum(s =>(r.Field<string>("mcd_NroComprobante").Substring(0,1).Equals("4"))? s.Field<decimal>("Cmdc_monto") : 0)
                            }).GroupBy(m => m.mcd_CodigoMayor).Select(n => n.FirstOrDefault());

            var totalDC = (from totalDebitos in debitos.AsEnumerable()
                          join totalCreditos in creditos.AsEnumerable() on totalDebitos.mcd_CodigoMayor equals totalCreditos.mcd_CodigoMayor into agru
                          from totalX in agru
                          select new
                          {
                              mcd_CodigoMayor = totalDebitos.mcd_CodigoMayor,
                              sumatoria = totalDebitos.debitos - (totalX.creditos)
                          });

            foreach (var f in totalDC) {
                foreach (DataRow fila in DtEstructuraCostos.Rows) {
                    if (fila["cc_CodigoCuenta"].ToString() != null)
                    {
                        if ((fila["cc_CodigoCuenta"].ToString().Equals(f.mcd_CodigoMayor.ToString())) && (fila["cc_FlagImpBal"].ToString().Equals("1")) &&
                             (Convert.ToDecimal(fila["cc_CodigoCuenta"].ToString()) < 512000000))
                        {
                            fila["costosLopj"] = f.sumatoria.ToString();
                            fila["exclusiones"] = 0; /*Convert.ToDecimal(fila["saldoActual"].ToString()) - Convert.ToDecimal(f.sumatoria.ToString());*/
                            break;
                        }


                        if ((fila["cc_FlagImpBal"].ToString().Equals("2")) && (Convert.ToDecimal(fila["cc_CodigoCuenta"].ToString()) < 512000000))
                        {
                            fila["exclusiones"] = fila["saldoActual"].ToString();
                            break;
                        }
                    }
                }
            }
            
        }

        public void setCostosLOPJ() {

            //foreach (DataRow fila in DtEstructuraCostos.Rows) {
            //    if (fila["cc_CodigoCuenta"].ToString()!=""){
            //        if ((Convert.ToDecimal(fila["cc_CodigoCuenta"].ToString()) >= 400000000) && (fila["cc_FlagImpBal"].ToString().Equals("4")))
            //        {
            //            fila["exclusiones"] = fila["saldoActual"];
            //        }

            //        if ((Convert.ToDecimal(fila["cc_CodigoCuenta"].ToString()) >= 400000000) && (fila["cc_FlagImpBal"].ToString().Equals("3")))
            //        {
            //            fila["costosLopj"] = fila["saldoActual"];
            //        }
            //    }
            //}
            foreach (DataRow fila in DtEstructuraCostos.Rows) {
                fila["costosLopj"] = fila["saldoActual"];
            }
        }

        public void totalExclusionesCostos() {
            decimal acumulador = 0;
            string codigo = null;
            string titulo = null;

            for (int i = 0; i <DtEstructuraCostos.Rows.Count; i++) {
                if (codigo == null)
                {
                    if (DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString() != "")
                    {
                        if (Convert.ToDecimal(DtEstructuraCostos.Rows[i][0].ToString()) < 400000000)
                        {
                            codigo = DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString();
                            acumulador = acumulador + Convert.ToDecimal(DtEstructuraCostos.Rows[i]["costosLopj"].ToString());
                            titulo = DtEstructuraCostos.Rows[i]["cc_Descripcion"].ToString();
                        }
                    }
                }
                else {
                    if (DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString() != "")
                    {
                        if (Convert.ToDecimal(DtEstructuraCostos.Rows[i][0].ToString()) < 400000000)
                        {
                            if (codigo.Substring(0, 4).Equals(DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString().Substring(0, 4)))
                            {
                                acumulador = acumulador + Convert.ToDecimal(DtEstructuraCostos.Rows[i]["costosLopj"].ToString());
                            }
                        }
                    }
                    else {
                        if(DtEstructuraCostos.Rows[i]["cc_Descripcion"].ToString().ToUpper().Equals("TOTAL " + titulo.ToUpper()))
                        {
                            DtEstructuraCostos.Rows[i]["costosLopj"] = acumulador;
                            acumulador = 0;
                            codigo = null;
                        }
                    }
                }
            }
        }

        public void totalExclusionesCostos2()
        {
            decimal acumulador = 0;
            string codigo = null;
            string titulo = null;

            for (int i = 0; i < DtEstructuraCostos.Rows.Count; i++)
            {
                if (codigo == null)
                {
                    if (DtEstructuraCostos.Rows[i][0].ToString()!= "")
                    {
                        if (Convert.ToDecimal(DtEstructuraCostos.Rows[i][0].ToString()) >= 400000000)
                        {
                            codigo = DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString();
                   
                            acumulador = acumulador + Convert.ToDecimal(DtEstructuraCostos.Rows[i]["costosLopj"].ToString());
                            titulo = DtEstructuraCostos.Rows[i]["cc_Descripcion"].ToString();
                        }
                    }
                }
                else
                {
                    if (DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString() != "")
                    {
                        if (Convert.ToDecimal(DtEstructuraCostos.Rows[i][0].ToString()) >= 400000000)
                        {
                            if (codigo.Substring(0, 4).Equals(DtEstructuraCostos.Rows[i]["cc_CodigoCuenta"].ToString().Substring(0, 4)))
                            {
                                acumulador = acumulador + Convert.ToDecimal(DtEstructuraCostos.Rows[i]["costosLopj"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (DtEstructuraCostos.Rows[i]["cc_Descripcion"].ToString().ToUpper().Equals("TOTAL " + titulo.ToUpper()))
                        {
                            DtEstructuraCostos.Rows[i]["costosLopj"] = acumulador;
                            acumulador = 0;
                            codigo = null;
                        }
                    }
                }
            }
        }

        public void llenarDeterminacionPVP()
        {
            var sumau = (from t in dtEstructuraCostos.AsEnumerable()
                            .Where(x => x.Field<string>("cc_Descripcion").Equals("TOTAL COSTO DE VENTA MERCANCIA NACIONAL") ||
                                x.Field<string>("cc_Descripcion").Equals("TOTAL COSTO DE VENTA MERCANCIA IMPORTADA")
                            )
                            select t
                            ).ToList().Select(r => r.Field<Decimal>("saldoActual")).Sum();
            var suma2 = (from i in dtEstructuraCostos.AsEnumerable()
                             .Where(s=>s.Field<string>("cc_Descripcion").Equals("TOTAL REMUNERACIONES PERSONAL ALMACEN Y DEPOSITO")||
                             s.Field<string>("cc_Descripcion").Equals("TOTAL CONTRIBUCIONES SOCIALES PERSONAL OBRERO")||
                             s.Field<string>("cc_Descripcion").Equals("TOTAL REMUNERACION PERSONAL VENTAS")||
                             s.Field<string>("cc_Descripcion").Equals("TOTAL CONTRIBUCIONES SOCIALES PERSONAL VENTAS") ||
                             s.Field<string>("cc_Descripcion").Equals("TOTAL COSTO DE EMBALAJE DESPACHO Y VENTAS"))
                         select i).ToList().Select(q => q.Field<Decimal>("saldoActual")).Sum();

            foreach (DataRow filaTotal in DtEstructuraCostos.Rows)
            {
                if (filaTotal["cc_Descripcion"].ToString().Contains("TOTAL"))
                {   
                    DataRow fila = dtTotalesDeterminacionPVP.NewRow();
                    fila["titulo"] = filaTotal["cc_Descripcion"].ToString().Replace("TOTAL", "");
                    fila["monto"] = filaTotal["saldoActual"];
                    dtTotalesDeterminacionPVP.Rows.Add(fila);
                }
            }

            for (int i = 0; i < dtTotalesDeterminacionPVP.Rows.Count; i++) {
                if (dtTotalesDeterminacionPVP.Rows[i]["titulo"].ToString().Equals(" COSTO DE VENTA MERCANCIA VENDIDA")) {
                    dtTotalesDeterminacionPVP.Rows[i]["montoT"] = sumau;
                }
                if (dtTotalesDeterminacionPVP.Rows[i]["titulo"].ToString().Equals(" COSTOS DIRECTOS DE OPERACIONES"))
                {
                    dtTotalesDeterminacionPVP.Rows[i]["montoT"] = suma2;
                }

            }
            
        }

        public void setFactorIncidenciaCO() {
            decimal temp = 0;
            foreach (DataRow fila in dtTotalesDeterminacionPVP.Rows) {
                if (fila["titulo"].ToString().ToUpper().Equals(" COSTO DE VENTA MERCANCIA VENDIDA"))
                {
                    DataRow nuevaFila = dtFactorIncidenciaCostosOperativos.NewRow();
                    nuevaFila["monto"] = Convert.ToDecimal(fila["monto"].ToString()) / 1000;
                    temp = Convert.ToDecimal(fila["monto"].ToString()) / 1000;
                    nuevaFila["porcentaje"] = "100%";
                    dtFactorIncidenciaCostosOperativos.Rows.Add(nuevaFila);
                }
                ////if (fila["titulo"].ToString().ToUpper().Equals("COSTOS DE OPERACIONES"))
                ////{
                ////    DataRow nuevaFila = dtFactorIncidenciaCostosOperativos.NewRow();
                ////    nuevaFila["monto"] = Convert.ToDecimal(fila["monto"].ToString()) / 1000;
                ////    nuevaFila["porcentaje"] = ""+Math.Truncate(((Convert.ToDecimal(fila["monto"].ToString()) / 1000) / temp)*1000)/1000+" %";
                ////    dtFactorIncidenciaCostosOperativos.Rows.Add(nuevaFila);
                ////}
            }
            var suma = (from plus in dtTotalesDeterminacionPVP.AsEnumerable()
                                .Where(x => x.Field<string>("titulo").Equals(" REMUNERACIONES PERSONAL ALMACEN Y DEPOSITO") ||
                                x.Field<string>("titulo").Equals(" CONTRIBUCIONES SOCIALES PERSONAL OBRERO") ||
                                x.Field<string>("titulo").Equals(" REMUNERACION PERSONAL VENTAS") ||
                                x.Field<string>("titulo").Equals(" CONTRIBUCIONES SOCIALES PERSONAL VENTAS") ||
                                x.Field<string>("titulo").Equals(" COSTO DE EMBALAJE DESPACHO Y VENTAS")
                                )
                        select plus
                             ).ToList().Select(c => c.Field<Decimal>("monto")).Sum();

            DataRow nuevaFila2 = dtFactorIncidenciaCostosOperativos.NewRow();
            nuevaFila2["monto"] = Convert.ToDecimal(suma) / 1000;
            nuevaFila2["porcentaje"] = "" + Math.Truncate(((Convert.ToDecimal(suma) / 1000) / temp) * 1000) / 1000 + " %";
            dtFactorIncidenciaCostosOperativos.Rows.Add(nuevaFila2);

        }

        public void totalCostosDirectosOperaciones() {
            DataRow filaNueva;
            var suma2 = (from i in dtEstructuraCostos.AsEnumerable()
                          .Where(s => s.Field<string>("cc_Descripcion").Equals("TOTAL REMUNERACIONES PERSONAL ALMACEN Y DEPOSITO") ||
                          s.Field<string>("cc_Descripcion").Equals("TOTAL CONTRIBUCIONES SOCIALES PERSONAL OBRERO") ||
                          s.Field<string>("cc_Descripcion").Equals("TOTAL REMUNERACION PERSONAL VENTAS") ||
                          s.Field<string>("cc_Descripcion").Equals("TOTAL CONTRIBUCIONES SOCIALES PERSONAL VENTAS") ||
                          s.Field<string>("cc_Descripcion").Equals("TOTAL COSTO DE EMBALAJE DESPACHO Y VENTAS"))
                         select i).ToList().Select(q => q.Field<Decimal>("saldoActual")).Sum();

            filaNueva = DtEstructuraCostos.NewRow();
            filaNueva["cc_CodigoCuenta"] = "";
            filaNueva["cc_Descripcion"] = "TOTAL COSTOS DIRECTOS DE OPERACIONES";
            filaNueva["saldoActual"] = suma2;
            filaNueva["exclusiones"] = 0;
            filaNueva["costosLopj"] = suma2;
            filaNueva["cc_FlagImpBal"] = 0;
            filaNueva["cc_NivelTotal"] = 0;
            DtEstructuraCostos.Rows.Add(filaNueva);
        }
        public DataSet repoteEstructuraC() {
            DataSet dts = new DataSet();
            dts.Tables.Add(dtEstructuraCostos.Copy());
            dts.Tables.Add(dtTotalesDeterminacionPVP.Copy());
            foreach (DataRow fila in dtFactorIncidenciaCostosOperativos.Rows) {
                fila["monto"] = Truncate(Convert.ToDecimal(fila["monto"].ToString()), 3);
            }
            dts.Tables.Add(dtFactorIncidenciaCostosOperativos.Copy());
            foreach (DataRow fila2 in factorPrecios.Rows) {
                fila2["base1"] = Truncate(Convert.ToDecimal(fila2["base1"].ToString()), 3);
                fila2["base2"] = Truncate(Convert.ToDecimal(fila2["base2"].ToString()), 3);
            }
            dts.Tables.Add(factorPrecios.Copy());
            return dts;
        }

        public void setCostosOperativos(string codigo) {
            DataTable dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT factor1,factor2,GN,RD FROM confdatosempresa WHERE empre_codigo='$codigo';";
            sentenciaSql = sentenciaSql.Replace("$codigo", codigo);
            dt = dataBaseSysconfig.fDataTable(sentenciaSql);

            DataRow filaN = factorPrecios.NewRow();
            filaN["titulo"] = "Cto.Mercancia";
            filaN["base1"] = 1.00;
            filaN["base2"] = 10.00;
            factorPrecios.Rows.Add(filaN);

            filaN = factorPrecios.NewRow();
            filaN["titulo"] = "+ Factor Incidencia Cto Operativo";
            filaN["base1"] = Convert.ToDecimal(dtFactorIncidenciaCostosOperativos.Rows[1]["porcentaje"].ToString().Replace("%", ""));
            filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString())*10;
            factorPrecios.Rows.Add(filaN);

            filaN = factorPrecios.NewRow();
            filaN["titulo"] = "1._ Cto de Produccion";
            filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[0]["base1"].ToString()) + Convert.ToDecimal(dtFactorIncidenciaCostosOperativos.Rows[1]["porcentaje"].ToString().Replace("%",""));
            filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
            factorPrecios.Rows.Add(filaN);

            if (dt.Rows.Count > 0) {
                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "2._+ Gto Ajeno a Produccion";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[2]["base1"].ToString()) * (Convert.ToDecimal(dt.Rows[0]["factor1"].ToString()) / 100);
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);

                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "Cto. Produccion + Gto. Ajeno a Produccion";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[2]["base1"].ToString()) + Convert.ToDecimal(factorPrecios.Rows[3]["base1"].ToString());
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);

                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "3._+ Utilidad Segun LOPJ";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[4]["base1"].ToString()) * (Convert.ToDecimal(dt.Rows[0]["factor2"].ToString()) / 100);
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);

                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "PVP (Base sin IVA)";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[4]["base1"].ToString()) + Convert.ToDecimal(factorPrecios.Rows[5]["base1"].ToString());
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);

                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "Precio Alicuota Reducida (RD)";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[6]["base1"].ToString()) * Convert.ToDecimal(dt.Rows[0]["RD"].ToString());
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);
                
                filaN = factorPrecios.NewRow();
                filaN["titulo"] = "Precio Alicuota General (GN)";
                filaN["base1"] = Convert.ToDecimal(factorPrecios.Rows[6]["base1"].ToString()) * Convert.ToDecimal(dt.Rows[0]["GN"].ToString());
                filaN["base2"] = Convert.ToDecimal(filaN["base1"].ToString()) * 10;
                factorPrecios.Rows.Add(filaN);
            }

            dataBaseSysconfig.cerrarConexion();
            
        }

        private decimal Truncate(decimal pImporte, int pNumDecimales)
        {
            decimal wRt = 0;
            decimal wPot10 = 1;

            for (int i = 1; i <= pNumDecimales; i++)
            {
                wPot10 = wPot10 * 10;
            }

            wRt = pImporte * wPot10;
            wRt = decimal.Truncate(wRt);
            wRt = wRt / wPot10;
            //wRt = decimal.Round(wRt, 2);

            return wRt;
        }

        public void guardarHistorico(string fecha, string codUsu,int status ) {
            DateTime timX = DateTime.Now;
            sentenciaSql = null;
            sentenciaSql = "INSERT INTO historicoestructuracostos (fechaEjecucion,horaEjecucion,"+
                "fechaHastaBalance,factor,usuario,status) VALUES ('$fechaEjecucion'," +
                "'$horaEjecucion','$fechaHastaBalance',$factor,'$usuario', $status);";
            sentenciaSql = sentenciaSql.Replace("$fechaEjecucion",""+timX.Year+"-"+timX.Month.ToString().PadLeft(2,'0')+"-"+timX.Day.ToString().PadLeft(2,'0')+"");
            sentenciaSql = sentenciaSql.Replace("$horaEjecucion", "" + timX.ToString("hh:mm:ss"));
            sentenciaSql = sentenciaSql.Replace("$fechaHastaBalance",fecha.Replace("/","-"));
            sentenciaSql = sentenciaSql.Replace("$factor", (dtFactorIncidenciaCostosOperativos.Rows[1]["porcentaje"].ToString().Replace("%", "")).Replace(",", "."));
            sentenciaSql = sentenciaSql.Replace("$usuario",codUsu);
            sentenciaSql = sentenciaSql.Replace("$status", ""+status);
            dataBase.ejecutarInsert(sentenciaSql);
            dataBase.cerrarConexion();
        }

        public void modificarFechaParametros(string fecha) {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admparametroscontables SET pc_FechaUltCiem='$fecha' WHERE pc_idSistema='08'";
            sentenciaSql = sentenciaSql.Replace("$fecha",fecha.Replace("/","-"));
            dataBase.ejecutarInsert(sentenciaSql);
            dataBase.cerrarConexion();
        }

        public bool definitivaEstructura() {
            bool centinela = false;
            DataTable dt1 = null;
            
            sentenciaSql = null;
            sentenciaSql = "SELECT status FROM historicoestructuracostos WHERE status=1;";
            dt1 = dataBase.fDataTable(sentenciaSql);
            if (dt1.Rows.Count > 0) {
                if (dt1.Rows[0]["status"].ToString().Equals("1")) {
                    centinela = true;
                }
            }
            dataBase.cerrarConexion();
            return centinela;
        }

        public bool definitivaEstructura(string fechaOb)
        {
            bool centinela = false;
            DataTable dt1;
            sentenciaSql = null;
            sentenciaSql = "SELECT status FROM historicoestructuracostos WHERE status=1 AND fechaHastaBalance='$fechaHastaBalance';";
            sentenciaSql = sentenciaSql.Replace("$fechaHastaBalance", (fechaOb.Replace('/', '-')));
            dt1 = dataBase.fDataTable(sentenciaSql);
            if (dt1.Rows.Count > 0)
            {
                centinela = true;
            }
            dataBase.cerrarConexion();
            return centinela;
        }

    }
}
