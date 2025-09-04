using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace lebrun.clases.contabilidad
{
    class movimientoContable
    {
        private ConexionBD database;
        private string sql;
        private string numeroComprobante;
        private string mayorCliente;
        private string auxiliarCliente;
        private string tdc_reporte;
        private string tdc_codCta;
        private DataTable tabla;
        private DataTable tablaContablidad;
        private DataTable cabeceraTablaConta;


        public DataTable TablaContablidad
        {
            get { return tablaContablidad; }
            set { tablaContablidad = value; }
        }
        public DataTable CabeceraTablaConta
        {
            get { return cabeceraTablaConta; }
            set { cabeceraTablaConta = value; }
        }

        public movimientoContable()
        {
            database = new ConexionBD();
            tabla = new DataTable();
            tablaContablidad = new DataTable();
            cabeceraTablaConta = new DataTable();
        }

        public DataTable obtenerNumeroComprobante(string bd, string pc_idSistemas) {

            database.conectionStringSysconta(bd);

            sql = "SELECT pc_idSistema,pc_CorrCompAut+1 FROM admparametroscontables WHERE pc_idSistema='$1'";
            sql = sql.Replace("$1", pc_idSistemas);
            tabla = database.fDataTable(sql);

            database.ejecutarInsert("UPDATE admparametroscontables SET pc_CorrCompAut=pc_CorrCompAut+1 WHERE pc_idSistema='" + pc_idSistemas + "'");

            database.modificarConexionString(1);
            database.cerrarConexion();
            return tabla;
        }

        public void ingresarMovContab(DataTable tablaMovContab) {


            sql = null;
            string[] parametros = new string[23];
            sql = "INSERT INTO admmovcontab (movcon_item,movcon_proveedor,movcon_numdoc,movcon_sufdoc," +
                        "movcon_tipdoc,movcon_numcomp,movcon_descrip,movcon_cuenta,movcon_tipo,movcon_basetip,movcon_fecaha," +
                        "movcon_hora,movcon_monto,movcon_status,movcon_login,idSistemas,movcon_auxiliar,movcon_rif,movcon_nombre,codigoIslr,referencia)" +
                        "VALUES(@item,@codprove,@numeroDoc,@sufiDoc,@tipoDoc,@numComprobante,@descripcion,@cuenta,@tipo,@baseTipo, " +
                        "@fecha,@hora,@monto,'1',@login,@idSistemas,@auxiliar,@rif,@nombre,@islr,@referencia)";


            parametros[0] = "@item";
            parametros[1] = "@codprove";
            parametros[2] = "@numeroDoc";
            parametros[3] = "@sufiDoc";
            parametros[4] = "@tipoDoc";
            parametros[5] = "@numComprobante";
            parametros[6] = "@descripcion";
            parametros[7] = "@cuenta";
            parametros[8] = "@tipo";
            parametros[9] = "@baseTipo";
            parametros[10] = "@fecha";
            parametros[11] = "@hora";
            parametros[12] = "@monto";
            parametros[13] = "@status";
            parametros[14] = "@login";
            parametros[15] = "@idSistemas";
            parametros[16] = "@auxiliar";
            parametros[17] = "@rif";
            parametros[18] = "@nombre";
            parametros[19] = "@tipoLetra";
            parametros[20] = "@islr";
            parametros[21] = "@interno";
            parametros[22] = "@referencia";


            database.insertDataTable(tablaMovContab, parametros, sql);
            database.cerrarConexion();
        }


        public void cabeceraSyscontab(DataTable tablaMovContab, string compania)
        {
            string[] parametros = new string[13];

            database.conectionStringSysconta(compania);

            sql = "INSERT INTO admmovimientoscontablesc (mc_nroComprobante,mc_FechaComprobante, " +
                        " mc_FechaCarga,mc_FechaCierre,mc_IdSistema,mc_Descripcion,mc_MontoDebitos,mc_MontoCreditos,mc_Status, " +
                        " mc_Login,mc_LoginUpd,mc_FechaUltMod,mc_Compania,mc_HoraGuardado,IdSistemas) VALUES " +
                        "(@comprobante,@fecSistema,@fecSistema,@fecSistema,@mcIdSistema,@descripcion,@Debito," +
                        "@Credito,'2',@login,@updateLogin,@fepago,@compania,@hora,@idSistema)";

            parametros[0] = "@comprobante";
            parametros[1] = "@fecSistema";
            parametros[2] = "@mcIdSistema";
            parametros[3] = "@Debito";
            parametros[4] = "@Credito";
            parametros[5] = "@estatus";
            parametros[6] = "@login";
            parametros[7] = "@updateLogin";
            parametros[8] = "@compania";
            parametros[9] = "@idSistema";
            parametros[10] = "@hora";
            parametros[11] = "@fepago";
            parametros[12] = "@descripcion";

            database.insertDataTable(tablaMovContab, parametros, sql);
            database.modificarConexionString(1);
            database.cerrarConexion();
        }


        public void detallesSyscontab(DataTable tablaMovContab, string compania) {

            string[] parametros = new string[23];

            database.conectionStringSysconta(compania);

            sql = "INSERT INTO admmovimientoscontabled (mcd_NroComprobante,mcd_Item,mcd_FechaCarga,mcd_CodigoMayor," +
                    "mcd_CodigoAux,mcd_NroDocum,mcd_Referencia,mcd_Descripcion,mcd_status,mcd_login,mcd_UltLogin,mdc_FechaUltMod," +
                    "mdc_Compania,mdc_TipoTransaccion,mdc_monto,movcon_proveedor,movcon_numdoc,movcon_sufdoc,movcon_tipdoc,codigoIslr,mdc_FechaComprobante)" +
                    "VALUE(@numComprobante,@item,@fecha,@cuenta,@auxiliar,@numeroDoc,@referencia,@descripcion,'2',@login,@login,@fecha,'$compania',@tipoLetra,@monto,@codprove," +
                    "@interno,@sufiDoc,@tipoDoc,@islr,@fecha)";

            sql = sql.Replace("$compania", compania);

            parametros[0] = "@item";
            parametros[1] = "@codprove";
            parametros[2] = "@numeroDoc";
            parametros[3] = "@sufiDoc";
            parametros[4] = "@tipoDoc";
            parametros[5] = "@numComprobante";
            parametros[6] = "@descripcion";
            parametros[7] = "@cuenta";
            parametros[8] = "@tipo";
            parametros[9] = "@baseTipo";
            parametros[10] = "@fecha";
            parametros[11] = "@hora";
            parametros[12] = "@monto";
            parametros[13] = "@status";
            parametros[14] = "@login";
            parametros[15] = "@idSistemas";
            parametros[16] = "@auxiliar";
            parametros[17] = "@rif";
            parametros[18] = "@nombre";
            parametros[19] = "@tipoLetra";
            parametros[20] = "@islr";
            parametros[21] = "@interno";
            parametros[22] = "@referencia";


            database.insertDataTable(tablaMovContab, parametros, sql);
            database.modificarConexionString(1);
            database.cerrarConexion();
        
        }

        public DataTable armarDataTableMovContab()
        {
            tablaContablidad.Reset();
            tablaContablidad.Clear();

            tablaContablidad.Columns.Add("item");              //0
            tablaContablidad.Columns.Add("codprove");          //1
            tablaContablidad.Columns.Add("numeroDoc");         //2
            tablaContablidad.Columns.Add("sufiDoc");           //3
            tablaContablidad.Columns.Add("tipoDoc");           //4
            tablaContablidad.Columns.Add("numComprobante");    //5
            tablaContablidad.Columns.Add("descripcion");       //6
            tablaContablidad.Columns.Add("cuenta");            //7
            tablaContablidad.Columns.Add("tipo");              //8
            tablaContablidad.Columns.Add("baseTipo");          //9
            tablaContablidad.Columns.Add("fecha");             //10
            tablaContablidad.Columns.Add("hora");              //11
            tablaContablidad.Columns.Add("monto");             //12
            tablaContablidad.Columns.Add("status");            //13
            tablaContablidad.Columns.Add("login");             //14
            tablaContablidad.Columns.Add("idSistemas");        //15
            tablaContablidad.Columns.Add("auxiliar");          //16
            tablaContablidad.Columns.Add("rif");               //17
            tablaContablidad.Columns.Add("nombre");            //18
            tablaContablidad.Columns.Add("tipoLetra");         //19
            tablaContablidad.Columns.Add("islr");              //20
            tablaContablidad.Columns.Add("interno");           //21
            tablaContablidad.Columns.Add("referencia");        //22

            return tablaContablidad;
        }

        public DataTable armarDataTableCabeceraMovContab()
        {
            tablaContablidad.Reset();
            tablaContablidad.Clear();

            tablaContablidad.Columns.Add("comprobante");              
            tablaContablidad.Columns.Add("fecSistema");          
            tablaContablidad.Columns.Add("mcIdSistema");        
            tablaContablidad.Columns.Add("Debito");           
            tablaContablidad.Columns.Add("Credito");           
            tablaContablidad.Columns.Add("estatus");    
            tablaContablidad.Columns.Add("login");      
            tablaContablidad.Columns.Add("updateLogin");           
            tablaContablidad.Columns.Add("compania");             
            tablaContablidad.Columns.Add("idSistema");         
            tablaContablidad.Columns.Add("hora");            
            tablaContablidad.Columns.Add("fepago");              
            tablaContablidad.Columns.Add("descripcion");             

            return tablaContablidad;
        }

        public DataTable cuentaDoc(string tipoDoc) {
            //RIV

            sql = "SELECT ctd_codcta FROM admtipdoccli WHERE ctd_tipo='$1'";
            sql = sql.Replace("$1", tipoDoc);
            tabla = database.fDataTable(sql);
            database.cerrarConexion();
            return tabla;
        
        }

        public DataTable cuentaCliente(string codCliente)
        {

            sql = "SELECT admAC_codigoCuenta,admAC_codigoAuxiliarContable,cli_rif FROM admclientes WHERE cli_codigo='$1'";
            sql = sql.Replace("$1", codCliente);
            tabla = database.fDataTable(sql);
            database.cerrarConexion();
            return tabla;
        
        }

        public DataTable datosComprobante(string comprobante, string compania, string cliente)
        {
            string bd;

            if (compania.Equals("01"))
            {
                bd = "sysconta";

            }
            else
            {
                bd = "sysconta_" + compania;
            }


            sql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
                         " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
                         " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion,referencia,movcon_nombre   " +
                         " FROM admmovcontab   " +
                         " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
                         " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                         " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
                         " WHERE movcon_numcomp='$1' AND movcon_proveedor='$2'  order By length(movcon_item), movcon_item;";


            sql = sql.Replace("$1", comprobante);
            sql = sql.Replace("$2", cliente);

            return database.fDataTable(sql);
        }

        public DataTable ReimprimirComprobante(string comprobante, string compania)
        {
            string bd;

            if (compania.Equals("01"))
            {
                bd = "sysconta";

            }
            else
            {
                bd = "sysconta_" + compania;
            }


            sql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
                         " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
                         " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion,referencia,movcon_nombre   " +
                         " FROM admmovcontab   " +
                         " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
                         " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                         " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
                         " WHERE movcon_numcomp='$1' AND IdSistemas='RTI' order By length(movcon_item), movcon_item;";


            sql = sql.Replace("$1", comprobante);

            return database.fDataTable(sql);
        }


        public DataTable reimprimirComprobanteSyscontab(string comprobante, string compania)
        {
            //no esta terminada, 
            //hay que colocar los alias igual al dataset movcontab 27-09-2013

            string bd;

            if (compania.Equals("01"))
            {
                bd = "sysconta";

            }
            else
            {
                bd = "sysconta_" + compania;
            }

            sql = "SELECT mcd_Referencia,mc_Descripcion,mc_FechaComprobante,mc_Status as doc_status,cc_Descripcion as Descripcion,mc_nroComprobante as movcon_numcomp, mc_LoginUpd as doc_usuario, mcd_item as movcon_item, " +
            "mcd_CodigoMayor as movcon_cuenta, mcd_Descripcion as movcon_descrip, movcon_numdoc as doc_numerodoc,mdc_monto as movcon_monto,mcd_CodigoAux as movcon_auxiliar,usu_nombre,    " +
            "IF(mdc_tipoTransaccion='D','-1','1')AS movcon_tipo,  " +
            "IF(mdc_tipoTransaccion='D',mdc_monto,0) as debito,  " +
            "IF(mdc_tipoTransaccion='C',mdc_monto,0) as credito  " +
            "From " + bd + ".admmovimientoscontablesc " +
            "LEFT JOIN " + bd + ".admmovimientoscontabled ON mc_nroComprobante=mcd_NroComprobante  " +
            "LEFT JOIN " + bd + ".admcuentascontables ON mcd_CodigoMayor=cc_CodigoCuenta  " +
            "LEFT JOIN sysconf.confusuario ON usu_codigo =mc_LoginUpd  " +
            "WHERE mc_nroComprobante='$1' AND IdSistemas='RTI' ORDER BY length(movcon_item), movcon_item;";

            sql = sql.Replace("$1", comprobante);

            database.cerrarConexion();
            return database.fDataTable(sql);
            


        }

        public void armarDataTableCabeceraMovContab2()
        {
            cabeceraTablaConta.Reset();
            cabeceraTablaConta.Clear();

            cabeceraTablaConta.Columns.Add("comprobante");
            cabeceraTablaConta.Columns.Add("fecSistema");
            cabeceraTablaConta.Columns.Add("mcIdSistema");
            cabeceraTablaConta.Columns.Add("Debito");
            cabeceraTablaConta.Columns.Add("Credito");
            cabeceraTablaConta.Columns.Add("estatus");
            cabeceraTablaConta.Columns.Add("login");
            cabeceraTablaConta.Columns.Add("updateLogin");
            cabeceraTablaConta.Columns.Add("compania");
            cabeceraTablaConta.Columns.Add("idSistema");
            cabeceraTablaConta.Columns.Add("hora");
            cabeceraTablaConta.Columns.Add("fepago");
            cabeceraTablaConta.Columns.Add("descripcion");
        }


        public DataTable datosComprobante(string comprobante, string compania)
        {
            string bd;

            if (compania.Equals("01"))
            {
                bd = "sysconta";
            }
            else
            {
                bd = "sysconta_" + compania;
            }


            sql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
                         " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
                         " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion,referencia,movcon_nombre   " +
                         " FROM admmovcontab   " +
                         " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
                         " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                         " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
                         " WHERE movcon_numcomp='$1'  order By length(movcon_item), movcon_item;";


            sql = sql.Replace("$1", comprobante);

            return database.fDataTable(sql);
        }


        ///

        // public DataTable ReimprimirComprobante(string comprobante, string compania)
        //{
        //    string bd;

        //    if (compania.Equals("01"))
        //    {
        //        bd = "sysconta";
        //    }
        //    else
        //    {
        //        bd = "sysconta_" + compania;
        //    }


        //    sql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
        //                 " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
        //                 " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion,referencia,movcon_nombre   " +
        //                 " FROM admmovcontab   " +
        //                 " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
        //                 " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
        //                 " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
        //                 " WHERE movcon_numcomp='$1' AND IdSistemas='RTI' order By length(movcon_item), movcon_item;";


        //    sql = sql.Replace("$1", comprobante);

        //    return database.fDataTable(sql);
        //}


        //public DataTable reimprimirComprobanteSyscontab(string comprobante, string compania)
        //{
        //    //no esta terminada, 
        //    //hay que colocar los alias igual al dataset movcontab 27-09-2013

        //    string bd;

        //    if (compania.Equals("01"))
        //    {
        //        bd = "sysconta";

        //    }
        //    else
        //    {
        //        bd = "sysconta_" + compania;
        //    }

        //    sql = "SELECT mcd_Referencia,mc_Descripcion,mc_FechaComprobante,mc_Status as doc_status,cc_Descripcion as Descripcion,mc_nroComprobante as movcon_numcomp, mc_LoginUpd as doc_usuario, mcd_item as movcon_item, " +
        //    "mcd_CodigoMayor as movcon_cuenta, mcd_Descripcion as movcon_descrip, movcon_numdoc as doc_numerodoc,mdc_monto as movcon_monto,mcd_CodigoAux as movcon_auxiliar,usu_nombre,    " +
        //    "IF(mdc_tipoTransaccion='D','-1','1')AS movcon_tipo,  " +
        //    "IF(mdc_tipoTransaccion='D',mdc_monto,0) as debito,  " +
        //    "IF(mdc_tipoTransaccion='C',mdc_monto,0) as credito  " +
        //    "From " + bd + ".admmovimientoscontablesc " +
        //    "LEFT JOIN " + bd + ".admmovimientoscontabled ON mc_nroComprobante=mcd_NroComprobante  " +
        //    "LEFT JOIN " + bd + ".admcuentascontables ON mcd_CodigoMayor=cc_CodigoCuenta  " +
        //    "LEFT JOIN sysconf.confusuario ON usu_codigo =mc_LoginUpd  " +
        //    "WHERE mc_nroComprobante='$1' AND IdSistemas='RTI' ORDER BY length(movcon_item), movcon_item;";

        //    sql = sql.Replace("$1", comprobante);

        //    database.cerrarConexion();
        //    return database.fDataTable(sql);
            

        //}

        public DataTable cuentaTipDocPro2(string tipoDoc, string codigoCliente)
        {
            sql = "SELECT n_cuenta,n_auxiliar FROM admtipdocpro2 " +
                        " WHERE n_tipo='$1' AND n_proveedor ='$2'";

            sql = sql.Replace("$1", tipoDoc);
            sql = sql.Replace("$2", codigoCliente);

            //database.cerrarConexion();  // 2014_09_09 Jesus comentando la liberacion de la conexion salia el mismo error del lbx clientes en facturacion
            return database.fDataTable(sql);
        }

        public DataTable cuentaIDB(string codigo)
        {
            sql = "SELECT tdc_codcta FROM admtipdocpro WHERE tdc_codigo='$1' ";
            sql = sql.Replace("$1", codigo);

            database.cerrarConexion();
            return database.fDataTable(sql);
        }


        public DataTable ReimprimirComprobante(string comprobante, string compania, string IdSistema)
        {
            string bd;

            if (compania.Equals("01"))
            {
                bd = "sysconta";
            }
            else
            {
                bd = "sysconta_" + compania;
            }


            sql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
                         " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
                         " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion,referencia,movcon_nombre   " +
                         " FROM admmovcontab   " +
                         " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
                         " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                         " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
                         " WHERE movcon_numcomp='$1' AND IdSistemas='$2' order By length(movcon_item), movcon_item;";


            sql = sql.Replace("$1", comprobante);
            sql = sql.Replace("$2", IdSistema);

            return database.fDataTable(sql);
        }

        public void cabeceraSyscontabStatus(DataTable tablaMovContab, string compania)
        {
            string[] parametros = new string[13];

            database.conectionStringSysconta(compania);

            sql = "INSERT INTO admmovimientoscontablesc (mc_nroComprobante,mc_FechaComprobante, " +
                        " mc_FechaCarga,mc_FechaCierre,mc_IdSistema,mc_Descripcion,mc_MontoDebitos,mc_MontoCreditos,mc_Status, " +
                        " mc_Login,mc_LoginUpd,mc_FechaUltMod,mc_Compania,mc_HoraGuardado,IdSistemas) VALUES " +
                        "(@comprobante,@fecSistema,@fecSistema,@fecSistema,@mcIdSistema,@descripcion,@Debito," +
                        "@Credito,@estatus,@login,@updateLogin,@fepago,@compania,@hora,@idSistema)";

            parametros[0] = "@comprobante";
            parametros[1] = "@fecSistema";
            parametros[2] = "@mcIdSistema";
            parametros[3] = "@Debito";
            parametros[4] = "@Credito";
            parametros[5] = "@estatus";
            parametros[6] = "@login";
            parametros[7] = "@updateLogin";
            parametros[8] = "@compania";
            parametros[9] = "@idSistema";
            parametros[10] = "@hora";
            parametros[11] = "@fepago";
            parametros[12] = "@descripcion";

            database.insertDataTable(tablaMovContab, parametros, sql);
            database.modificarConexionString(1);
            database.cerrarConexion();
        }



        public void detallesSyscontabStatus(DataTable tablaMovContab, string compania)
        {

            string[] parametros = new string[23];

            database.conectionStringSysconta(compania);

            sql = "INSERT INTO admmovimientoscontabled (mcd_NroComprobante,mcd_Item,mcd_FechaCarga,mcd_CodigoMayor," +
                    "mcd_CodigoAux,mcd_NroDocum,mcd_Referencia,mcd_Descripcion,mcd_status,mcd_login,mcd_UltLogin,mdc_FechaUltMod," +
                    "mdc_Compania,mdc_TipoTransaccion,mdc_monto,movcon_proveedor,movcon_numdoc,movcon_sufdoc,movcon_tipdoc,codigoIslr,mdc_FechaComprobante)" +
                    "VALUE(@numComprobante,@item,@fecha,@cuenta,@auxiliar,@numeroDoc,@referencia,@descripcion,@status,@login,@login,@fecha,'$compania',@tipoLetra,@monto,@codprove," +
                    "@interno,@sufiDoc,@tipoDoc,@islr,@fecha)";

            sql = sql.Replace("$compania", compania);

            parametros[0] = "@item";
            parametros[1] = "@codprove";
            parametros[2] = "@numeroDoc";
            parametros[3] = "@sufiDoc";
            parametros[4] = "@tipoDoc";
            parametros[5] = "@numComprobante";
            parametros[6] = "@descripcion";
            parametros[7] = "@cuenta";
            parametros[8] = "@tipo";
            parametros[9] = "@baseTipo";
            parametros[10] = "@fecha";
            parametros[11] = "@hora";
            parametros[12] = "@monto";
            parametros[13] = "@status";
            parametros[14] = "@login";
            parametros[15] = "@idSistemas";
            parametros[16] = "@auxiliar";
            parametros[17] = "@rif";
            parametros[18] = "@nombre";
            parametros[19] = "@tipoLetra";
            parametros[20] = "@islr";
            parametros[21] = "@interno";
            parametros[22] = "@referencia";


            database.insertDataTable(tablaMovContab, parametros, sql);
            database.modificarConexionString(1);
            database.cerrarConexion();

        }



        public void eliminarMovContab(string proveedor, string docum, string suf, string tipo)
        {

            sql = "delete from admmovcontab_temp " +
            "where " +
                " movcon_proveedor='$idPro' " +
                "and movcon_numdoc='$docum' and movcon_tipdoc='$tip' and movcon_sufdoc='$sufi'";

            sql = sql.Replace("$idPro", proveedor);
            sql = sql.Replace("$docum", docum);
            sql = sql.Replace("$sufi", suf);
            sql = sql.Replace("$tip", tipo);

            database.ejecutarInsert(sql);
            database.cerrarConexion();
        }


        public void ingresarMovContab_temp(DataTable tablaMovContab)
        {


            sql = null;
            string[] parametros = new string[23];
            sql = "INSERT INTO admmovcontab_temp (movcon_item,movcon_proveedor,movcon_numdoc,movcon_sufdoc," +
                        "movcon_tipdoc,movcon_numcomp,movcon_descrip,movcon_cuenta,movcon_tipo,movcon_basetip,movcon_fecaha," +
                        "movcon_hora,movcon_monto,movcon_status,movcon_login,idSistemas,movcon_auxiliar,movcon_rif,movcon_nombre,codigoIslr,referencia)" +
                        "VALUES(@item,@codprove,@numeroDoc,@sufiDoc,@tipoDoc,@numComprobante,@descripcion,@cuenta,@tipo,@baseTipo, " +
                        "@fecha,@hora,@monto,'1',@login,@idSistemas,@auxiliar,@rif,@nombre,@islr,@referencia)";


            parametros[0] = "@item";
            parametros[1] = "@codprove";
            parametros[2] = "@numeroDoc";
            parametros[3] = "@sufiDoc";
            parametros[4] = "@tipoDoc";
            parametros[5] = "@numComprobante";
            parametros[6] = "@descripcion";
            parametros[7] = "@cuenta";
            parametros[8] = "@tipo";
            parametros[9] = "@baseTipo";
            parametros[10] = "@fecha";
            parametros[11] = "@hora";
            parametros[12] = "@monto";
            parametros[13] = "@status";
            parametros[14] = "@login";
            parametros[15] = "@idSistemas";
            parametros[16] = "@auxiliar";
            parametros[17] = "@rif";
            parametros[18] = "@nombre";
            parametros[19] = "@tipoLetra";
            parametros[20] = "@islr";
            parametros[21] = "@interno";
            parametros[22] = "@referencia";


            database.insertDataTable(tablaMovContab, parametros, sql);
            database.cerrarConexion();
        }

        public DataTable comprobaContableCompras(string tipoDoc, string codigo, string docum, string sufijo)
        {
            sql = "SELECT " +
                        "*,admproveedor.pro_nombre,admproveedor.pro_rif,cc_Descripcion as Descripcion,tdc_tipo,usu_nombre  " +
                        "From " +
                        "admmovcontab " +
                        "left join admdocpro on doc_tipdoc=movcon_tipdoc and doc_codigo=movcon_proveedor and doc_numerodoc=movcon_numdoc and doc_sufijo=movcon_sufdoc  " +
                        "left join sysconta.admcuentascontables on movcon_cuenta=cc_CodigoCuenta left join admproveedor on doc_codigo=pro_codigo " +
                        "left join admtipdocpro on doc_tipdoc=tdc_codigo  " +
                        " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                        "Where " +
                        "doc_tipdoc='$txtTipDoc ' and doc_codigo='$txtCodigo' and doc_numerodoc='$txtNumDoc' and doc_sufijo='$txtSufijo' and IdSistemas<>'CHEM' and IdSistemas<>'CHEP' and Idsistemas<>'TCXP'  " +
                        "order By " +
                        "length(movcon_item), movcon_item;";

            sql = sql.Replace("$txtTipDoc", tipoDoc);
            sql = sql.Replace("$txtCodigo", codigo);
            sql = sql.Replace("$txtNumDoc", docum);
            sql = sql.Replace("$txtSufijo", sufijo);

            tabla = database.fDataTable(sql);
            database.cerrarConexion();
            return tabla;
        }

    }
}
