using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using System.Windows.Forms;

namespace lebrun.clases.contabilidad
{
   public class ComprobanteCierre : ComprobanteContable
    {
        private ConexionBD database;
        private DataTable balance;
        private DataTable balanceGenerado;
        private DataTable comprobante;
        
        private decimal n4Debito;
        private decimal n4Credito;
        private decimal n3Debito;
        private decimal n3Credito;
        private decimal n2Debito;
        private decimal n2Credito;
        private decimal n1Debito;
        private decimal n1Credito;
        private string ultimoNivel;
        private string titulo1;
        private string titulo2;
        private string titulo3;
        private string titulo4;
        private bool centinela;
        private string cuentaActualizar;
        private string monto;

        public string CuentaActualizar
        {
            get { return cuentaActualizar; }
            set { cuentaActualizar = value; }
        }
        public string Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        

        public ComprobanteCierre(string idDataBase) {
            
            database = new ConexionBD();
            balanceGenerado = new DataTable();
            balanceGenerado.Columns.Add("codigoCuenta");
            balanceGenerado.Columns.Add("descripcion");
            balanceGenerado.Columns.Add("nivelTotal");
            balanceGenerado.Columns.Add("codigoMayor");
            balanceGenerado.Columns.Add("saldoApertura");
            balanceGenerado.Columns.Add("sumaDebito");
            balanceGenerado.Columns.Add("sumaCredito");
            balanceGenerado.Columns.Add("tipo");
            balanceGenerado.Columns.Add("saldoActual");
            ultimoNivel = null;
            centinela = false;

            comprobante = new DataTable();
            comprobante.Columns.Add("nroComprobante");
            comprobante.Columns.Add("item");
            comprobante.Columns.Add("fechaCarga");
            comprobante.Columns.Add("codigoMayor");
            comprobante.Columns.Add("codigoAuxiliar");
            comprobante.Columns.Add("nroDocumento");
            comprobante.Columns.Add("descripcion");
            comprobante.Columns.Add("status");
            comprobante.Columns.Add("login");
            comprobante.Columns.Add("ultimoLogin");
            comprobante.Columns.Add("fechaUtMod");
            comprobante.Columns.Add("compania");
            comprobante.Columns.Add("tipoTransaccion");
            comprobante.Columns.Add("monto");
            comprobante.Columns.Add("mdc_FechaComprobante");

            //se busca el numero Temporal
            this.asignarCorrelativo(idDataBase);

        }


        public DataTable balanceCierre(int idDataBase, string fechaHasta,string idQueryDataBase,string idUsuario,
            string codigoComp, string anio) {
            string sentencia = null;
            string temporalNivel = null;
            int resta = 0;
            sentencia = "CALL saldoCreditoDebitoMesGP('$1','$2','$3','5');";
            sentencia = sentencia.Replace("$1",( this.fechaInicioCierre(idQueryDataBase)));
            sentencia = sentencia.Replace("$2", fechaHasta);
            sentencia = sentencia.Replace("$3", this.cuentaAnalitico(idQueryDataBase));
            //cuentaAnalitico
            database.modificarConexionString(idDataBase);
            //para que trabaje con cualquier compañia
            database.conectionStringSysconta(idQueryDataBase);
            balance = database.fDataTable(sentencia);
            for (int i = 0; i < balance.Rows.Count; i++)
            {
                resta = 0;
                temporalNivel = balance.Rows[i]["cc_NivelTotal"].ToString();
                if (!centinela) {
                    calcularTotales2(balance.Rows[i], balance.Rows[i]["cc_NivelTotal"].ToString());
                }
                else
                {
                    resta = Convert.ToInt16(ultimoNivel) - Convert.ToInt16(balance.Rows[i]["cc_NivelTotal"].ToString());
                    if (resta == 0)
                    {
                        calcularTotales(balance.Rows[i], balance.Rows[i]["cc_NivelTotal"].ToString());
                        if (!temporalNivel.Equals("5"))
                        {
                            imprimirTitulo(balance.Rows[i], true);
                        }
                    }
                    else
                    {
                        if (resta < 0)
                        {
                            if (!temporalNivel.Equals("5"))
                            {
                                imprimirTitulo(balance.Rows[i],true);
                            }
                            else
                            {
                                calcularTotales(balance.Rows[i], balance.Rows[i]["cc_NivelTotal"].ToString());
                            }
                        }
                        else {
                            if (resta > 0) {
                                for (int z = 1; z <= resta; z++) {
                                    if (resta == 1)
                                    {
                                        calcularTotales(balance.Rows[i], balance.Rows[i]["cc_NivelTotal"].ToString());
                                        imprimirTitulo(balance.Rows[i],false);
                                    }
                                    else {
                                        calcularTotales(balance.Rows[i], (Convert.ToString(Convert.ToInt16(ultimoNivel) -1)));
                                    }
                                }
                                if (resta > 1)
                                {
                                    imprimirTitulo(balance.Rows[i],true);
                                }
                            }
                        }
                    }
                }
            }

            registroFinal();
            saldoAnterior(idQueryDataBase, idDataBase, fechaHasta);
            saldoActual();
            ////se busca el correlativo de la serie 8
            this.asignarCorrelativoFinal(idQueryDataBase);
            detalleComprobante(idUsuario, codigoComp, fechaHasta);
            diferenciaComprobante(idQueryDataBase, codigoComp, idUsuario, fechaHasta);

            cabeceraComprobante(idQueryDataBase, fechaHasta, idUsuario);
            /*this.agregarCabecera(idUsuario, codigoComp, idQueryDataBase);
            ingresarDetalle(idQueryDataBase);*/

            ////agregando el comprobante en la tabla del año
            //this.agregarCabecera2(idUsuario, codigoComp, anio, idQueryDataBase);
            //ingresarDetalle2(idQueryDataBase, anio);

            //se ingresa la cabecera y detalle en las tablas de comprobantes de Cierre correspondientes
            this.agregarCabecera_cierreEjercicio(idUsuario, codigoComp, idQueryDataBase);
            this.ingresarDetalleCierreEjercicio(idQueryDataBase);
            
            ///this.NroComprobanteCorrelativo
            return comprobante;
    
        }

        private void guardarComprobanteTablaAnterior(string anio) { 
        }

        private void calcularTotales(DataRow fila, string nivel)
        {   
            DataRow filaAgregar = balanceGenerado.NewRow();
            switch (nivel) { 
                case "5":
                    n4Debito = n4Debito + Convert.ToDecimal(fila["sumaDebito"]);
                    n4Credito = n4Credito + Convert.ToDecimal(fila["sumaCredito"]);
                    n3Debito = n3Debito + Convert.ToDecimal(fila["sumaDebito"]);
                    n3Credito = n3Credito + Convert.ToDecimal(fila["sumaCredito"]);
                    n2Debito = n2Debito + Convert.ToDecimal(fila["sumaDebito"]);
                    n2Credito = n2Credito + Convert.ToDecimal(fila["sumaCredito"]);
                    n1Debito = n1Debito + Convert.ToDecimal(fila["sumaDebito"]);
                    n1Credito = n1Credito + Convert.ToDecimal(fila["sumaCredito"]);
                    
                    filaAgregar["codigoCuenta"] = fila["cc_CodigoCuenta"].ToString();
                    filaAgregar["descripcion"] = fila["cc_Descripcion"].ToString();
                    filaAgregar["nivelTotal"] = fila["cc_NivelTotal"];
                    filaAgregar["codigoMayor"] = fila["mcd_CodigoMayor"].ToString();
                    filaAgregar["sumaDebito"] = fila["sumaDebito"];
                    filaAgregar["sumaCredito"] = fila["sumaCredito"];
                    filaAgregar["tipo"] = "";
                    
                    ultimoNivel = "5";
                    break;
                case "4":
                    filaAgregar["codigoCuenta"] = " ";
                    filaAgregar["descripcion"] = "Total " + titulo4;
                    filaAgregar["nivelTotal"] = "null";
                    filaAgregar["codigoMayor"] = "''";
                    filaAgregar["sumaDebito"] = n4Debito;
                    filaAgregar["sumaCredito"] = n4Credito;
                    filaAgregar["tipo"] = "titulo4";

                    n4Debito = 0;
                    n4Credito = 0;
                    titulo4 = fila["cc_Descripcion"].ToString();
                    ultimoNivel = "4";

                    break;
                case "3":
                    filaAgregar["codigoCuenta"] = " ";
                    filaAgregar["descripcion"] = "Total " + titulo3;
                    filaAgregar["nivelTotal"] = "null";
                    filaAgregar["codigoMayor"] = "''";
                    filaAgregar["sumaDebito"] = n3Debito;
                    filaAgregar["sumaCredito"] = n3Credito;
                    filaAgregar["tipo"] = "titulo3";

                    n3Debito = 0;
                    n3Credito = 0;
                    titulo3 = fila["cc_Descripcion"].ToString();
                    ultimoNivel = "3";
                    break;
                    
                case "2":
                    filaAgregar["codigoCuenta"] = " ";
                    filaAgregar["descripcion"] = "Total " + titulo2;
                    filaAgregar["nivelTotal"] = "null";
                    filaAgregar["codigoMayor"] = "''";
                    filaAgregar["sumaDebito"] = n2Debito;
                    filaAgregar["sumaCredito"] = n2Credito;
                    filaAgregar["tipo"] = "titulo2";

                    n2Debito = 0;
                    n2Credito = 0;
                    titulo2 = fila["cc_Descripcion"].ToString();
                    ultimoNivel = "2";
                    break;
                
                case "1":
                    filaAgregar["codigoCuenta"] = " ";
                    filaAgregar["descripcion"] = "Total " + titulo1;
                    filaAgregar["nivelTotal"] = "null";
                    filaAgregar["codigoMayor"] = "''";
                    filaAgregar["sumaDebito"] = n1Debito;
                    filaAgregar["sumaCredito"] = n1Credito;
                    filaAgregar["tipo"] = "titulo1";

                    n1Debito = 0;
                    n1Credito = 0;
                    titulo1 = fila["cc_Descripcion"].ToString();
                    ultimoNivel = "1";
                    break;
            }
            balanceGenerado.Rows.Add(filaAgregar);
        }

        private void calcularTotales2(DataRow fila, string nivel) {
            DataRow filaAgregar = balanceGenerado.NewRow();

            nivel = fila["cc_NivelTotal"].ToString();

            filaAgregar["codigoCuenta"] = fila["cc_CodigoCuenta"].ToString();
            filaAgregar["descripcion"] = fila["cc_Descripcion"].ToString();
            filaAgregar["nivelTotal"] = fila["cc_NivelTotal"];
            filaAgregar["codigoMayor"] = fila["mcd_CodigoMayor"].ToString();
            filaAgregar["sumaDebito"] = 0;
            filaAgregar["sumaCredito"] = 0;

            switch (nivel) { 
                case "1":
                    filaAgregar["tipo"] = "titulo1";
                    titulo1 = fila["cc_Descripcion"].ToString();
                    break;
                case "2":
                    filaAgregar["tipo"] = "titulo2";
                    titulo2 = fila["cc_Descripcion"].ToString();
                    break;
                case "3":
                    filaAgregar["tipo"] = "titulo3";
                    titulo3 = fila["cc_Descripcion"].ToString();
                    break;
                case "4":
                    filaAgregar["tipo"] = "titulo4";
                    titulo4 = fila["cc_Descripcion"].ToString();
                    break;
                case "5":
                    filaAgregar["tipo"] = "''";
                    filaAgregar["sumaDebito"] = fila["sumaDebito"];
                    filaAgregar["sumaCredito"] = fila["sumaCredito"];

                    n4Debito = n4Debito + Convert.ToDecimal(fila["sumaDebito"]);
                    n4Credito = n4Credito + Convert.ToDecimal(fila["sumaCredito"]);
                    n3Debito = n3Debito + n4Debito;
                    n3Credito = n3Credito + n4Credito;
                    n2Debito = n2Debito + n3Debito;
                    n2Credito = n2Credito + n3Credito;
                    n1Debito = n1Debito + n2Debito;
                    n1Credito = n1Credito + n2Credito;
                    centinela = true;
                    ultimoNivel = "5";
                    break;
            }
            balanceGenerado.Rows.Add(filaAgregar);
        }

        private void imprimirTitulo(DataRow fila, bool bandera) {
            DataRow filaAgregar = balanceGenerado.NewRow();
            string nivel = null;

            nivel = fila["cc_NivelTotal"].ToString();

            filaAgregar["codigoCuenta"] = fila["cc_CodigoCuenta"].ToString();
            filaAgregar["descripcion"] = fila["cc_Descripcion"].ToString();
            filaAgregar["nivelTotal"] = fila["cc_NivelTotal"];
            filaAgregar["codigoMayor"] = fila["mcd_CodigoMayor"].ToString();
            filaAgregar["sumaDebito"] = 0;
            filaAgregar["sumaCredito"] = 0;
            filaAgregar["tipo"] = "titulo";
            balanceGenerado.Rows.Add(filaAgregar);
            if (bandera)
            {
                switch (nivel)
                {
                    case "1":
                        titulo1 = fila["cc_Descripcion"].ToString();
                        break;
                    case "2":
                        titulo2 = fila["cc_Descripcion"].ToString();
                        break;
                    case "3":
                        titulo3 = fila["cc_Descripcion"].ToString();
                        break;
                    case "4":
                        titulo4 = fila["cc_Descripcion"].ToString();
                        break;
                }
            }
            
            
        }

        private void registroFinal() {
            DataRow filaAgregar = balanceGenerado.NewRow();

            filaAgregar["codigoCuenta"] = " ";
            filaAgregar["descripcion"] = "Total " + titulo4;
            filaAgregar["nivelTotal"] = "null";
            filaAgregar["codigoMayor"] = "''";
            filaAgregar["sumaDebito"] = n4Debito;
            filaAgregar["sumaCredito"] = n4Credito;
            filaAgregar["tipo"] = "titulo4";

            n4Debito = 0;
            n4Credito = 0;
            ultimoNivel = "4";

            balanceGenerado.Rows.Add(filaAgregar);

            DataRow filaAgregar1 = balanceGenerado.NewRow();
            filaAgregar1["codigoCuenta"] = " ";
            filaAgregar1["descripcion"] = "Total " + titulo3;
            filaAgregar1["nivelTotal"] = "null";
            filaAgregar1["codigoMayor"] = "''";
            filaAgregar1["sumaDebito"] = n3Debito;
            filaAgregar1["sumaCredito"] = n3Credito;
            filaAgregar1["tipo"] = "titulo3";

            n3Debito = 0;
            n3Credito = 0;
            ultimoNivel = "3";
            
            balanceGenerado.Rows.Add(filaAgregar1);

            DataRow filaAgregar2 = balanceGenerado.NewRow();
            filaAgregar2["codigoCuenta"] = " ";
            filaAgregar2["descripcion"] = "Total " + titulo2;
            filaAgregar2["nivelTotal"] = "null";
            filaAgregar2["codigoMayor"] = "''";
            filaAgregar2["sumaDebito"] = n2Debito;
            filaAgregar2["sumaCredito"] = n2Credito;
            filaAgregar2["tipo"] = "titulo2";

            n2Debito = 0;
            n2Credito = 0;
            ultimoNivel = "2";

            balanceGenerado.Rows.Add(filaAgregar2);

            DataRow filaAgregar3 = balanceGenerado.NewRow();
            filaAgregar3["codigoCuenta"] = " ";
            filaAgregar3["descripcion"] = "Total " + titulo1;
            filaAgregar3["nivelTotal"] = "null";
            filaAgregar3["codigoMayor"] = "''";
            filaAgregar3["sumaDebito"] = n1Debito;
            filaAgregar3["sumaCredito"] = n1Credito;
            filaAgregar3["tipo"] = "titulo1";

            n1Debito = 0;
            n1Credito = 0;
            ultimoNivel = "1";

            balanceGenerado.Rows.Add(filaAgregar3);
        }

        private void saldoAnterior(string idQueryDataBase, int idDataBase, string fechaHasta)
        {
            string sentencia = null;
            DataTable tablaSaldos;
            DataRow [] filaEncontrada;
            int indiceTabla = 0;

            sentencia = "SELECT cc_CodigoCuenta, cc_SaldoIniEjerc FROM admcuentascontables WHERE cc_CodigoCuenta >='$1';";            
            sentencia = sentencia.Replace("$1", this.cuentaAnalitico(idQueryDataBase));
            database.conectionStringSysconta(idQueryDataBase);
            //database.modificarConexionString(idDataBase);
            tablaSaldos = database.fDataTable(sentencia);

           for (int i = 0; i < tablaSaldos.Rows.Count; i++) {
               filaEncontrada =  balanceGenerado.Select("codigoCuenta Like '" +(tablaSaldos.Rows[i]["cc_CodigoCuenta"].ToString())+"'");
               indiceTabla = balanceGenerado.Rows.IndexOf(filaEncontrada[0]);

               balanceGenerado.Rows[indiceTabla]["saldoApertura"] =
                   Convert.ToDouble(tablaSaldos.Rows[i]["cc_SaldoIniEjerc"].ToString());
               Array.Clear(filaEncontrada,0,filaEncontrada.Length);
               indiceTabla = 0;
           }
        }

        private void saldoActual() {
            for (int i = 0; i < balanceGenerado.Rows.Count; i++) {
                if (((balanceGenerado.Rows[i]["nivelTotal"].ToString()) != "null") && (balanceGenerado.Rows[i]["codigoCuenta"].ToString()!=""))
                { 
                    balanceGenerado.Rows[i]["saldoActual"] = (Convert.ToDecimal(balanceGenerado.Rows[i]["saldoApertura"].ToString()) +
                        Convert.ToDecimal(balanceGenerado.Rows[i]["sumaDebito"].ToString()) - (Convert.ToDecimal(balanceGenerado.Rows[i]["sumaCredito"].ToString())));
                }
            }
        }

        private void cabeceraComprobante(string idBaseDatos, string fecha, string idUsuario)
        {
            decimal a,b;
            this.FechaComprobante = fecha;
            this.FechaCarga = fecha;
            this.IdOrigen = 8; //porque viene de contabilidad
            this.Descripcion = "Comprobante Cierre";

            a = totalDebito();
            b = totalCredito();
            this.MontoDebito = Convert.ToString(totalDebito()).Replace(",", ".");
            this.MontoCredito = Convert.ToString(totalCredito()).Replace(",", ".");
            this.Status = 9; //cambiado para las modificaciones!
            this.UltimoLogin = idUsuario;
            this.UltimaFecha = fecha;
        }

        private void detalleComprobante(string usuario, string compania, string fechaComprobante) {
            int z = 1;
            for (int i = 0; i < balanceGenerado.Rows.Count; i++) {
                DataRow nuevaFila = comprobante.NewRow();
                if ((balanceGenerado.Rows[i]["nivelTotal"].ToString()) != "null" && ((Convert.ToDecimal(balanceGenerado.Rows[i]["saldoActual"].ToString())) != 0) 
                    && (balanceGenerado.Rows[i]["codigoMayor"].ToString()!="")) {
                    nuevaFila["nroComprobante"] = this.NroComprobanteCorrelativo;
                    nuevaFila["item"] = z ;
                    nuevaFila["fechaCarga"] = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    nuevaFila["codigoMayor"] = balanceGenerado.Rows[i]["codigoMayor"].ToString();
                    nuevaFila["nroDocumento"] = "";
                    nuevaFila["descripcion"] = "Comprobante Cierre";
                    nuevaFila["status"] = "9";
                    nuevaFila["login"] = usuario; //sacarlo de referencia Principal
                    nuevaFila["ultimoLogin"] = usuario;
                    nuevaFila["compania"] = compania;
                    nuevaFila["fechaUtMod"] = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    nuevaFila["mdc_FechaComprobante"] = fechaComprobante;
                    if (Convert.ToDecimal(balanceGenerado.Rows[i]["saldoActual"].ToString()) > 0)
                    {
                        nuevaFila["tipoTransaccion"] = "C";
                    }
                    else {
                        nuevaFila["tipoTransaccion"] = "D";
                    }

                    //txtResultado.Text = string.Format("{0:n2}", (Math.Truncate(valor * 100) / 100)))
                    nuevaFila["monto"] = Convert.ToString(Math.Abs(Convert.ToDecimal(balanceGenerado.Rows[i]["saldoActual"].ToString()))).Replace(",", ".");
                    //nuevaFila["monto"] = string.Format("{0:n2}", (Math.Truncate(Math.Abs(Convert.ToDouble(balanceGenerado.Rows[i]["saldoActual"].ToString()) * 100) / 100))).Replace(".", "").Replace(",", ".");
                    
                    comprobante.Rows.Add(nuevaFila);
                    z++;
                    
                }
            }
        }

        private decimal totalDebito()
        {
            decimal total = 0;
            for (int i = 0; i < comprobante.Rows.Count; i++)
            {
                if (comprobante.Rows[i]["tipoTransaccion"].ToString().Equals("D"))
                {
                    total = total + Convert.ToDecimal(comprobante.Rows[i]["monto"].ToString().Replace(".",","));
                }
            }
            return total;
        }
        private decimal totalCredito()
        {
            decimal total = 0;
            for (int i = 0; i < comprobante.Rows.Count; i++)
            {
                if (comprobante.Rows[i]["tipoTransaccion"].ToString().Equals("C"))
                {
                    total = total + Convert.ToDecimal(comprobante.Rows[i]["monto"].ToString().Replace(".", ","));
                }
            }
            return total;
        }

        private void diferenciaComprobante(string idBaseDatos, string compania, string login, string fecha1) {
            DataRow nuevaFila = comprobante.NewRow();
            decimal credito = 0;
            decimal debito = 0;
            decimal diferencia = 0;

            credito = totalCredito();
            debito = totalDebito();
            diferencia = debito - credito;
            nuevaFila["nroComprobante"] = this.NroComprobanteCorrelativo;
            nuevaFila["item"] = comprobante.Rows.Count + 1;
            nuevaFila["fechaCarga"] = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            nuevaFila["codigoMayor"] = this.cuentaSupAviCie(idBaseDatos);
            nuevaFila["nroDocumento"] = "";
            nuevaFila["descripcion"] = "Comprobante Cierre";
            nuevaFila["status"] = "1";
            nuevaFila["login"] = login; //sacarlo de referencia Principal
            nuevaFila["ultimoLogin"] = login;
            nuevaFila["compania"] = compania;
            nuevaFila["fechaUtMod"] = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            nuevaFila["mdc_FechaComprobante"] = fecha1;
            if (diferencia > 0)
            {
                nuevaFila["tipoTransaccion"] = "C";
            }
            else {
                nuevaFila["tipoTransaccion"] = "D";
            }
            
            nuevaFila["monto"] = Convert.ToString(Math.Abs(diferencia)).Replace(",",".");
            comprobante.Rows.Add(nuevaFila);

            if (nuevaFila["tipoTransaccion"].ToString().Equals("C"))
            {
                this.monto = Convert.ToString(Math.Abs(diferencia)*(-1)).Replace(",", ".");
            }
            else {
                this.monto = Convert.ToString(Math.Abs(diferencia)).Replace(",", ".");
            }
            
            this.cuentaActualizar = this.cuentaSupAviCie(idBaseDatos);

            
        }

        private void ingresarDetalle(string idQueryDataBase)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[15];

            sentenciaEnviar = "INSERT INTO admmovimientoscontabled ( " +
                                      " mcd_NroComprobante, mcd_Item, mcd_FechaCarga, " +
                                      "mcd_CodigoMayor, mcd_CodigoAux, mcd_NroDocum, mcd_Descripcion, " +
                                      "mcd_status, mcd_login, mcd_UltLogin, mdc_FechaUltMod, mdc_Compania, " +
                                      "mdc_TipoTransaccion, mdc_monto,mdc_FechaComprobante) VALUES ( @nroComprobante, " +
                                      "@item, @fechaCarga, @codigoMayor, @codigoAuxilar, @nroDocumento, " +
                                      "@descripcion, @status, @login, @ultiLogin, @fechaUltMod, @compania, " +
                                      "@tipoTrans, @monto,@fechaCompro);";

            parametrosEnviar[0] = "@nroComprobante";
            parametrosEnviar[1] = "@item";
            parametrosEnviar[2] = "@fechaCarga";
            parametrosEnviar[3] = "@codigoMayor";
            parametrosEnviar[4] = "@codigoAuxilar";
            parametrosEnviar[5] = "@nroDocumento";
            parametrosEnviar[6] = "@descripcion";
            parametrosEnviar[7] = "@status";
            parametrosEnviar[8] = "@login";
            parametrosEnviar[9] = "@ultiLogin";
            parametrosEnviar[10] = "@fechaUltMod";
            parametrosEnviar[11] = "@compania";
            parametrosEnviar[12] = "@tipoTrans";
            parametrosEnviar[13] = "@monto";
            parametrosEnviar[14] = "@fechaCompro";
            database.conectionStringSysconta(idQueryDataBase);
            database.insertDataTable(comprobante, parametrosEnviar, sentenciaEnviar);
            database.cerrarConexion();
        }

        private void ingresarDetalle2(string idQueryDataBase, string anio)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[15];

            sentenciaEnviar = "INSERT INTO admmovimientoscontabled_"+anio+" ( " +
                                      " mcd_NroComprobante, mcd_Item, mcd_FechaCarga, " +
                                      "mcd_CodigoMayor, mcd_CodigoAux, mcd_NroDocum, mcd_Descripcion, " +
                                      "mcd_status, mcd_login, mcd_UltLogin, mdc_FechaUltMod, mdc_Compania, " +
                                      "mdc_TipoTransaccion, mdc_monto,mdc_FechaComprobante) VALUES ( @nroComprobante, " +
                                      "@item, @fechaCarga, @codigoMayor, @codigoAuxilar, @nroDocumento, " +
                                      "@descripcion, @status, @login, @ultiLogin, @fechaUltMod, @compania, " +
                                      "@tipoTrans, @monto,@fechaCompro);";

            parametrosEnviar[0] = "@nroComprobante";
            parametrosEnviar[1] = "@item";
            parametrosEnviar[2] = "@fechaCarga";
            parametrosEnviar[3] = "@codigoMayor";
            parametrosEnviar[4] = "@codigoAuxilar";
            parametrosEnviar[5] = "@nroDocumento";
            parametrosEnviar[6] = "@descripcion";
            parametrosEnviar[7] = "@status";
            parametrosEnviar[8] = "@login";
            parametrosEnviar[9] = "@ultiLogin";
            parametrosEnviar[10] = "@fechaUltMod";
            parametrosEnviar[11] = "@compania";
            parametrosEnviar[12] = "@tipoTrans";
            parametrosEnviar[13] = "@monto";
            parametrosEnviar[14] = "@fechaCompro";
            database.conectionStringSysconta(idQueryDataBase);
            database.insertDataTable(comprobante, parametrosEnviar, sentenciaEnviar);
            database.cerrarConexion();
        }


        private void ingresarDetalleCierreEjercicio(string idQueryDataBase)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[15];

            sentenciaEnviar = "INSERT INTO admmovimientoscontabled_cierreejercicio ( " +
                                      " mcd_NroComprobante, mcd_Item, mcd_FechaCarga, " +
                                      "mcd_CodigoMayor, mcd_CodigoAux, mcd_NroDocum, mcd_Descripcion, " +
                                      "mcd_status, mcd_login, mcd_UltLogin, mdc_FechaUltMod, mdc_Compania, " +
                                      "mdc_TipoTransaccion, mdc_monto,mdc_FechaComprobante) VALUES ( @nroComprobante, " +
                                      "@item, @fechaCarga, @codigoMayor, @codigoAuxilar, @nroDocumento, " +
                                      "@descripcion, @status, @login, @ultiLogin, @fechaUltMod, @compania, " +
                                      "@tipoTrans, @monto,@fechaCompro);";

            parametrosEnviar[0] = "@nroComprobante";
            parametrosEnviar[1] = "@item";
            parametrosEnviar[2] = "@fechaCarga";
            parametrosEnviar[3] = "@codigoMayor";
            parametrosEnviar[4] = "@codigoAuxilar";
            parametrosEnviar[5] = "@nroDocumento";
            parametrosEnviar[6] = "@descripcion";
            parametrosEnviar[7] = "@status";
            parametrosEnviar[8] = "@login";
            parametrosEnviar[9] = "@ultiLogin";
            parametrosEnviar[10] = "@fechaUltMod";
            parametrosEnviar[11] = "@compania";
            parametrosEnviar[12] = "@tipoTrans";
            parametrosEnviar[13] = "@monto";
            parametrosEnviar[14] = "@fechaCompro";
            database.conectionStringSysconta(idQueryDataBase);
            database.insertDataTable(comprobante, parametrosEnviar, sentenciaEnviar);
            database.cerrarConexion();
        }



        public void actualizarSaldoActualComprobanteCierre(string idDataBase) {
            string sentenciaSql = null;
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[2];
            DataTable saldosCierre;
            database.conectionStringSysconta(idDataBase);
            sentenciaSql = "SELECT saldoActual, codigoCuenta FROM temporalbalancecomprobacion WHERE nivelTotal is not null " +
                                " AND codigoCuenta<='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", this.cuentaSupAviCie(idDataBase));
            saldosCierre = database.fDataTable(sentenciaSql);
            sentenciaEnviar = "UPDATE admcuentascontables SET cc_SaldoIniEjerc =@saldo WHERE cc_CodigoCuenta= @codigo";
            parametrosEnviar[0] = "@saldo";
            parametrosEnviar[1] = "@codigo";
            database.insertDataTable(saldosCierre, parametrosEnviar, sentenciaEnviar,0);
            
            ////se actualiza la diferencia
            //sentenciaSql = "UPDATE admcuentascontables SET cc_SaldoIniEjerc= (cc_SaldoIniEjerc+($1)) WHERE cc_CodigoCuenta= 'codigo'";
            //sentenciaSql = sentenciaSql.Replace("$1", this.monto);
            //sentenciaSql = sentenciaSql.Replace("codigo", this.cuentaActualizar);

            //database.ejecutarInsert(sentenciaSql,0);
            database.cerrarConexion();
        }

        public void actualizarDiferenciaCuenta(string idDataBase) {
            string sentenciaSql = null;
            database.conectionStringSysconta(idDataBase);
            //se actualiza la diferencia
            sentenciaSql = "UPDATE admcuentascontables SET cc_SaldoIniEjerc= (cc_SaldoIniEjerc+($1)) WHERE cc_CodigoCuenta= 'codigo'";
            sentenciaSql = sentenciaSql.Replace("$1", this.monto);
            sentenciaSql = sentenciaSql.Replace("codigo", this.cuentaActualizar);

            database.ejecutarInsert(sentenciaSql, 0);
            database.cerrarConexion();
        }

       //public void updateSaldoAuxiliaresContables(string fecha, string codigoCompania) {
       //    string sentencia = null;
       //    string fechaXC = null;
       //    bool resultado = false;
       //    string fechaUtlCierre = null;
       //    string fechaUnMesAntes = null;
       //    string fechaUltimoCierreOriginal = null;
       //    DateTime temporalFecha;

       //    fechaXC = this.fechaInicioCierre(codigoCompania);
       //    fechaUltimoCierreOriginal = fechaXC;
           
       //    temporalFecha = Convert.ToDateTime(fechaXC);
       //    temporalFecha= temporalFecha.AddDays(1);
       //    fechaUtlCierre = "" + temporalFecha.Year + "-" + temporalFecha.Month + "-" + temporalFecha.Day + "";

       //    temporalFecha = Convert.ToDateTime(fechaXC);
       //    temporalFecha.AddMonths(-1);
       //    fechaUnMesAntes = "" + temporalFecha.Year + "-" + temporalFecha.Month + "-" + temporalFecha.Day + "";


       //    //      Call saldoAnteriorAnalitico((Format(tfechaUltimoCierre(), "YYYY-MM-DD")), (Format(compararFecha(fechaDesde.Value), "YYYY-MM-DD")))


       //    database.conectionStringSysconta(codigoCompania);
       //         sentencia = "UPDATE admauxiliarcontable  W "+
       //         "INNER JOIN( "+

       //         "SELECT  "+
       //         "( "+
       //             "(SUM(IF(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fechaUnMesAntes + "', " +
       //             "(IF(movimiento.mdc_TipoTransaccion = 'D',movimiento.mdc_monto,((movimiento.mdc_monto*-1))) ),0)) +cuenta.cc_SaldoIniEjerc ) "+
       //             "+ "+
       //             "SUM( "+
       //             "IF( "+
       //                 "(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fecha + "'), " +
       //                 "(IF(movimiento.mdc_TipoTransaccion = 'D',movimiento.mdc_monto,0)),0 "+
       //             ")) "+
       //             "- "+
       //             "SUM( "+
       //             "IF( "+
       //                 "(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fecha + "'), " +
       //                 "(IF(movimiento.mdc_TipoTransaccion = 'C',movimiento.mdc_monto,0)),0 "+
       //             ") "+
       //         ") "+
                	
       //         ") as saldoNuevo, "+
       //         "concat(cuenta.cc_CodigoCuenta,auxiliar.admAC_codigoAuxiliarContable) as codigoAuxiliar "+
       //         "FROM admcuentascontables cuenta "+
       //         "LEFT OUTER JOIN admmovimientoscontabled movimiento "+
       //         "ON cuenta.cc_CodigoCuenta = movimiento.mcd_CodigoMayor "+


       //         "LEFT OUTER JOIN admauxiliarcontable auxiliar "+
       //         "ON cuenta.cc_CodigoCuenta = auxiliar.admAC_codigoCuenta "+
       //         "WHERE  movimiento.mdc_monto> 0 "+
       //         "AND "+
       //         "auxiliar.admAC_control REGEXP '@compania' "+
       //         "OR auxiliar.admAC_control REGEXP '0' "+ /* por las cuentas que tienen permisos 0*/
       //         "GROUP BY cuenta.cc_CodigoCuenta, cuenta.cc_NivelTotal "+
       //         ") cuenta ON CONCAT(W.admAC_codigoCuenta,W.admAC_codigoAuxiliarContable) = cuenta.codigoAuxiliar "+
       //         "SET W.admAC_saldoApertura = cuenta.saldoNuevo ";
       //         resultado = database.ejecutarInsert(sentencia,0);
       //         database.cerrarConexion();
       // }

        //public void updateSaldoAuxiliaresContables(string fecha, string codigoCompania)
        //{
        //    string sentencia = null;
        //    string fechaXC = null;
        //    bool resultado = false;
        //    DateTime fechaDesde;

        //    fechaXC = this.fechaInicioCierre(codigoCompania);
        //    fechaDesde = Convert.ToDateTime(fechaXC);
        //    fechaDesde = fechaDesde.AddDays(1);

        //    //fechaUtlCierre = "" + temporalFecha.Year + "-" + temporalFecha.Month + "-" + temporalFecha.Day + "";

        //    //temporalFecha = Convert.ToDateTime(fechaXC);
        //    //temporalFecha.AddMonths(-1);
        //    //fechaUnMesAntes = "" + temporalFecha.Year + "-" + temporalFecha.Month + "-" + temporalFecha.Day + "";


        //    //     Call saldoAnteriorAnalitico((Format(tfechaUltimoCierre(), "YYYY-MM-DD")), (Format(compararFecha(fechaDesde.Value), "YYYY-MM-DD")))


        //    database.conectionStringSysconta(codigoCompania);
        //    //sentencia = "UPDATE admauxiliarcontable  W "+
        //    //"INNER JOIN( "+

        //    //"SELECT  "+
        //    //"( "+
        //    //    "(SUM(IF(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fechaUnMesAntes + "', " +
        //    //    "(IF(movimiento.mdc_TipoTransaccion = 'D',movimiento.mdc_monto,((movimiento.mdc_monto*-1))) ),0)) +cuenta.cc_SaldoIniEjerc ) "+
        //    //    "+ "+
        //    //    "SUM( "+
        //    //    "IF( "+
        //    //        "(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fecha + "'), " +
        //    //        "(IF(movimiento.mdc_TipoTransaccion = 'D',movimiento.mdc_monto,0)),0 "+
        //    //    ")) "+
        //    //    "- "+
        //    //    "SUM( "+
        //    //    "IF( "+
        //    //        "(DATE(movimiento.mdc_FechaComprobante) BETWEEN  '" + fechaUtlCierre + "' AND '" + fecha + "'), " +
        //    //        "(IF(movimiento.mdc_TipoTransaccion = 'C',movimiento.mdc_monto,0)),0 "+
        //    //    ") "+
        //    //") "+

        //    //") as saldoNuevo, "+
        //    //"concat(cuenta.cc_CodigoCuenta,auxiliar.admAC_codigoAuxiliarContable) as codigoAuxiliar "+
        //    //"FROM admcuentascontables cuenta "+
        //    //"LEFT OUTER JOIN admmovimientoscontabled movimiento "+
        //    //"ON cuenta.cc_CodigoCuenta = movimiento.mcd_CodigoMayor "+


        //    //"LEFT OUTER JOIN admauxiliarcontable auxiliar "+
        //    //"ON cuenta.cc_CodigoCuenta = auxiliar.admAC_codigoCuenta "+
        //    //"WHERE  movimiento.mdc_monto> 0 "+
        //    //"AND "+
        //    //"auxiliar.admAC_control REGEXP '@compania' "+
        //    //"OR auxiliar.admAC_control REGEXP '0' "+ /* por las cuentas que tienen permisos 0*/
        //    //"GROUP BY cuenta.cc_CodigoCuenta, cuenta.cc_NivelTotal "+
        //    //") cuenta ON CONCAT(W.admAC_codigoCuenta,W.admAC_codigoAuxiliarContable) = cuenta.codigoAuxiliar "+
        //    //"SET W.admAC_saldoApertura = cuenta.saldoNuevo ";

        //    sentencia = "UPDATE admauxiliarcontable W INNER JOIN( " +
        //                     "SELECT ( " +
        //                         "SUM( " +
        //                         "(IF(admmovimientoscontabled.mdc_TipoTransaccion= 'D',admmovimientoscontabled.mdc_monto,((admmovimientoscontabled.mdc_monto*-1))))	" +
        //                         ")+ admauxiliarcontable.admAC_saldoApertura " +
        //                     ") AS saldoNuevo, CONCAT(admauxiliarcontable.admAC_codigoCuenta, admauxiliarcontable.admAC_codigoAuxiliarContable) AS codigoAuxiliar " +
        //                     "FROM admmovimientoscontabled " +
        //                     "LEFT OUTER JOIN admauxiliarcontable  " +
        //                     "ON (CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable)) =  " +
        //                     "(CONCAT(admmovimientoscontabled.mcd_CodigoMayor,admmovimientoscontabled.mcd_CodigoAux)) " +
        //                     "WHERE  admmovimientoscontabled.mdc_monto> 0 " +
        //                     "AND admauxiliarcontable.admAC_control REGEXP '$codigoComp' OR admauxiliarcontable.admAC_control ='0' " +
        //                     "AND  (DATE(admmovimientoscontabled.mdc_FechaComprobante)BETWEEN  '$fechaDesde' AND '$fechaHasta') " +
        //                     "GROUP BY (CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable)) " +
        //                     ") " +
        //                     "cuenta ON " +
        //                     "CONCAT(W.admAC_codigoCuenta,W.admAC_codigoAuxiliarContable) = cuenta.codigoAuxiliar SET W.admAC_saldoApertura = cuenta.saldoNuevo;  ";
        //    sentencia = sentencia.Replace("$codigoComp", codigoCompania);
        //    sentencia = sentencia.Replace("$fechaDesde", "" + fechaDesde.Year + "-" + fechaDesde.Month.ToString().PadLeft(2, '0') + "-" + fechaDesde.Day.ToString().PadLeft(2, '0'));
        //    sentencia = sentencia.Replace("$fechaHasta", fecha);
        //    resultado = database.ejecutarInsert(sentencia, 0);
        //    database.cerrarConexion();
        //}

        //public void updateSaldoAuxiliaresContables(string fecha, string codigoCompania)
        //{
        //    string sentencia = null;
        //    string fechaXC = null;
        //    bool resultado = false;
        //    DateTime fechaDesde;
        //    DataTable dtSaldosAux;

        //    fechaXC = this.fechaInicioCierre(codigoCompania);
        //    fechaDesde = Convert.ToDateTime(fechaXC);
        //    fechaDesde = fechaDesde.AddDays(1);


        //    database.conectionStringSysconta(codigoCompania);
        //    sentencia = "SELECT ( SUM( (IF(admmovimientoscontabled.mdc_TipoTransaccion= 'D',admmovimientoscontabled.mdc_monto,((admmovimientoscontabled.mdc_monto*-1))))	)+ admauxiliarcontable.admAC_saldoApertura ) AS saldoNuevo, " +
        //      "admauxiliarcontable.admAC_codigoCuenta AS mayor, " +
        //      "admauxiliarcontable.admAC_codigoAuxiliarContable as auxiliar " +
        //      "FROM admmovimientoscontabled  " +
        //      "LEFT OUTER JOIN admauxiliarcontable  ON (CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable)) =  (CONCAT(admmovimientoscontabled.mcd_CodigoMayor,admmovimientoscontabled.mcd_CodigoAux)) " +
        //      "WHERE  admmovimientoscontabled.mdc_monto> 0 AND admauxiliarcontable.admAC_control REGEXP '$codigoComp' OR admauxiliarcontable.admAC_control ='0' AND  (DATE(admmovimientoscontabled.mdc_FechaComprobante)BETWEEN  '$desde' AND '$hasta') " +
        //      "GROUP BY (CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable))  ";
        //    sentencia = sentencia.Replace("$codigoComp", codigoCompania);
        //    sentencia = sentencia.Replace("$desde", "" + fechaDesde.Year + "-" + fechaDesde.Month.ToString().PadLeft(2, '0') + "-" + fechaDesde.Day.ToString().PadLeft(2, '0'));
        //    sentencia = sentencia.Replace("$hasta", fecha);
        //    dtSaldosAux = database.fDataTable(sentencia);

        //    for (int p = 0; p < dtSaldosAux.Rows.Count; p++)
        //    {
        //        sentencia = "UPDATE admauxiliarcontable SET admAC_saldoApertura=$admAC_saldoApertura WHERE admAC_codigoCuenta='$admAC_codigoCuenta' AND admAC_codigoAuxiliarContable ='$admAC_codigoAuxiliarContable';";
        //        sentencia = sentencia.Replace("$admAC_saldoApertura", dtSaldosAux.Rows[p]["saldoNuevo"].ToString().Replace(",", "."));
        //        sentencia = sentencia.Replace("$admAC_codigoCuenta", dtSaldosAux.Rows[p]["mayor"].ToString());
        //        sentencia = sentencia.Replace("$admAC_codigoAuxiliarContable", dtSaldosAux.Rows[p]["auxiliar"].ToString());

        //        database.ejecutarInsert(sentencia, 200);
        //    }
        //    database.cerrarConexion();
        //}

        public void updateSaldoAuxiliaresContables(string fecha, string codigoCompania)
        {
            string sentencia = null;
            string fechaXC = null;
            bool resultado = false;
            DateTime fechaDesde;
            DataTable dtSaldosAux;

            fechaXC = this.fechaInicioCierre(codigoCompania);
            fechaDesde = Convert.ToDateTime(fechaXC);
            fechaDesde = fechaDesde.AddDays(1);


            database.conectionStringSysconta(codigoCompania);
            sentencia = "SELECT " +
                          "(SUM( (IF(admmovimientoscontabled.mdc_TipoTransaccion= 'D',(admmovimientoscontabled.mdc_monto),0)))) as DEBITO, " +
                          "(SUM( (IF(admmovimientoscontabled.mdc_TipoTransaccion= 'C',(admmovimientoscontabled.mdc_monto*-1),0)))) as CREDITO, " +
                          "admAC_saldoApertura, " +
                          "admauxiliarcontable.admAC_codigoCuenta AS mayor, admauxiliarcontable.admAC_codigoAuxiliarContable as auxiliar  " +
                          "FROM admmovimientoscontabled " +
                            "LEFT OUTER JOIN admauxiliarcontable  " +
                            "ON (CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable)) =  (CONCAT(admmovimientoscontabled.mcd_CodigoMayor,admmovimientoscontabled.mcd_CodigoAux))  " +
                            "WHERE  admmovimientoscontabled.mdc_monto> 0 AND (admauxiliarcontable.admAC_control REGEXP '$codigoComp' OR admauxiliarcontable.admAC_control ='0') AND     " +
                            "admmovimientoscontabled.mdc_FechaComprobante BETWEEN  '$fechaDesde' AND '$fechaHasta' " +
                           "AND admmovimientoscontabled.mcd_CodigoAux!='' " +
                             "GROUP BY CONCAT(admauxiliarcontable.admAC_codigoCuenta,admauxiliarcontable.admAC_codigoAuxiliarContable)";
            sentencia = sentencia.Replace("$codigoComp", codigoCompania);
            sentencia = sentencia.Replace("$fechaDesde", "" + fechaDesde.Year + "-" + fechaDesde.Month.ToString().PadLeft(2, '0') + "-" + fechaDesde.Day.ToString().PadLeft(2, '0'));
            sentencia = sentencia.Replace("$fechaHasta", fecha);

            dtSaldosAux = database.fDataTable(sentencia);
            for (int p = 0; p < dtSaldosAux.Rows.Count; p++)
            {
                sentencia = "UPDATE admauxiliarcontable SET admAC_saldoApertura=$admAC_saldoApertura WHERE admAC_codigoCuenta='$admAC_codigoCuenta' AND admAC_codigoAuxiliarContable ='$admAC_codigoAuxiliarContable';";
                sentencia = sentencia.Replace("$admAC_saldoApertura", Convert.ToString((Convert.ToDecimal(dtSaldosAux.Rows[p]["DEBITO"].ToString())) + (Convert.ToDecimal(dtSaldosAux.Rows[p]["CREDITO"].ToString())) + (Convert.ToDecimal(dtSaldosAux.Rows[p]["admAC_saldoApertura"].ToString()))).Replace(",", "."));
                sentencia = sentencia.Replace("$admAC_codigoCuenta", dtSaldosAux.Rows[p]["mayor"].ToString());
                sentencia = sentencia.Replace("$admAC_codigoAuxiliarContable", dtSaldosAux.Rows[p]["auxiliar"].ToString());
                database.ejecutarInsert(sentencia, 200);
            }

            //for (int p = 0; p < dtSaldosAux.Rows.Count; p++)
            //{
            //    sentencia = "UPDATE admauxiliarcontable SET admAC_saldoApertura=$admAC_saldoApertura WHERE admAC_codigoCuenta='$admAC_codigoCuenta' AND admAC_codigoAuxiliarContable ='$admAC_codigoAuxiliarContable';";
            //    sentencia = sentencia.Replace("$admAC_saldoApertura", dtSaldosAux.Rows[p]["saldoNuevo"].ToString().Replace(",","."));
            //    sentencia = sentencia.Replace("$admAC_codigoCuenta", dtSaldosAux.Rows[p]["mayor"].ToString());
            //    sentencia = sentencia.Replace("$admAC_codigoAuxiliarContable", dtSaldosAux.Rows[p]["auxiliar"].ToString());

            //    database.ejecutarInsert(sentencia, 200);
            //}
            database.cerrarConexion();
        }
    
    }
}

  
