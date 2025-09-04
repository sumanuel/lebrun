using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lebrun.clases.complementos
{
    class pagare
    {
        private ConexionBD database;
        private DataSet ds;
        private string StrSql;

        private string idSistemasInt;
        private string montoDebito;
        private string montoCredito;
        private string codigoProveedor;
        private string numeroDoc;
        private string sufijo;
        private string tipoDoc;
        private string comprobante;
        private string descripcion;
        private string cuentaContable;
        private string tipoMov;
        private decimal baseDoc;
        private string fechaEmision;
        private string hora;
        private string montoDoc;
        private string status;
        private string login;
        private string auxiliar;
        private string idSistemas;
        private string rif;
        private string nombreProveedor;
        private string fechVen;
        private DataTable tabla;


        public string MontoDebito
        {
            get { return montoDebito; }
            set { montoDebito = value; }
        }

        public string MontoCredito
        {
            get { return montoCredito; }
            set { montoCredito = value; }
        }

        public string IdSistemasInt
        {
            get { return idSistemasInt; }
            set { idSistemasInt = value; }
        }

        public string CodigoProveedor
        {
            get { return codigoProveedor; }
            set { codigoProveedor = value; }
        }
        
        public string NumeroDoc
        {
            get { return numeroDoc; }
            set { numeroDoc = value; }
        }

        public string Sufijo
        {
            get { return sufijo; }
            set { sufijo = value; }
        }
       
        public string TipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }
       
        public string Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }
        
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        public string CuentaContable
        {
            get { return cuentaContable; }
            set { cuentaContable = value; }
        }
        
        public string TipoMov
        {
            get { return tipoMov; }
            set { tipoMov = value; }
        }
        
        public decimal BaseDoc
        {
            get { return baseDoc; }
            set { baseDoc = value; }
        }
        
        public string FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }
        
        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
       
        public string MontoDoc
        {
            get { return montoDoc; }
            set { montoDoc = value; }
        }
        
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        
        public string Auxiliar
        {
            get { return auxiliar; }
            set { auxiliar = value; }
        }
        
        public string IdSistemas
        {
            get { return idSistemas; }
            set { idSistemas = value; }
        }
        
        public string Rif
        {
            get { return rif; }
            set { rif = value; }
        }
        
        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

        public string FechVen
        {
            get { return fechVen; }
            set { fechVen = value; }
        }

            public pagare(){
                database = new ConexionBD();
                tabla = new DataTable();
            }

            public void insertarMovContab(DataTable grid)
            {

                StrSql = null;
                string[] parametros = new string[19];

                StrSql = "INSERT INTO admmovcontab (movcon_item,movcon_proveedor,movcon_numdoc,movcon_sufdoc," +
                        "movcon_tipdoc,movcon_numcomp,movcon_descrip,movcon_cuenta,movcon_tipo,movcon_basetip,movcon_fecaha," +
                        "movcon_hora,movcon_monto,movcon_status,movcon_login,idSistemas,movcon_auxiliar,movcon_rif,movcon_nombre)" +
                        "VALUES(@item,@codprove,@numeroDoc,@sufiDoc,@tipoDoc,@numComprobante,@descripcion,@cuenta,@tipo,@baseTipo, " +
                        "@fecha,@hora,@monto,'1',@login,@idSistemas,@auxiliar,@rif,@nombre)";

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

                database.insertDataTable(grid, parametros, StrSql);
                database.cerrarConexion();

            }

            public void insertarSalpro(DataTable grid)
            {
                StrSql = null;
                string[] parametros = new string[21];

            StrSql = "insert into admsalpro(IdProveedor, NroDocum, SufiDocum,NroDocumAfect, NroControlSeniat, Descripcion, " +
            "NroComprobante,FechaEmision, FechaVencimiento, FechaCarga, " +
            "FechaLibCompras, FechaPago,NroCompPago,IdTipoDoc, IdBanco,IdMoneda, " +
            "MontoEnDivisa, MontoDocum, SaldoDocum, MontoIva, " +
            "PorcIva, PorcIva2,MontoRetenc, NroCompRetenc,Status," +
            "Login, Loginact,correlativo)VALUES(@codprove,@numeroDoc,@sufiDoc,'','', " +
            "@descripcion,@numComprobante,@fecha, "+
            "@fechaVenc,@fecha,@fecha,@fecha,'0',@tipoDoc,'0','Bs','0'," +
            "@monto,@monto,'0.00','12','8','0.00','0','0',@login,@login,@tipoDoc)";


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
            parametros[20] = "@fechaVenc";
                

            database.insertDataTable(grid, parametros, StrSql);
            database.cerrarConexion();

            }

            public void insertMoviContableD(DataTable grid, string bd)
            {
                database.conectionStringSysconta(bd);
                StrSql = null;
                string[] parametros = new string[20];

                StrSql = "INSERT INTO admmovimientoscontabled (mcd_NroComprobante,mcd_Item,mcd_FechaCarga,mcd_CodigoMayor, " +
                "mcd_CodigoAux,mcd_NroDocum,mcd_Referencia,mcd_Descripcion,mcd_status,mcd_login,mcd_UltLogin,mdc_FechaUltMod," +
                "mdc_Compania,mdc_TipoTransaccion,mdc_monto,movcon_proveedor,movcon_numdoc,movcon_sufdoc,movcon_tipdoc,codigoIslr,mdc_FechaComprobante)" +
                "VALUES(@numComprobante,@item,@fecha,@cuenta,@auxiliar,@numeroDoc,'',@descripcion,'1',@login,@login,"+
                "@fecha,'$1',@tipoLetra,@monto,@codprove,@numeroDoc,@sufiDoc,@tipoDoc,'',@fecha)";

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

                StrSql = StrSql.Replace("$1", bd);

                database.insertDataTable(grid, parametros, StrSql);
                database.modificarConexionString(1);
                database.cerrarConexion();
    
            }

            public void insertMoviContableC(string bd,string usuario)
            {
            database.conectionStringSysconta(bd);

            StrSql = "INSERT INTO admmovimientoscontablesc (mc_nroComprobante,mc_FechaComprobante, " +
            "mc_FechaCarga,mc_FechaCierre,mc_IdSistema,mc_Descripcion,mc_MontoDebitos,mc_MontoCreditos,mc_Status, " +
            "mc_Login,mc_LoginUpd,mc_FechaUltMod,mc_Compania,mc_HoraGuardado,IdSistemas) VALUES ('$1','$2','$2','$2','$idSistemaInt','$4'," +
            "'$6','$5','$7','$8','$8','$2','$9','$hora','$3')";

            StrSql = StrSql.Replace("$1",this.comprobante);
            StrSql = StrSql.Replace("$2", this.fechaEmision);
            StrSql = StrSql.Replace("$3", this.idSistemas);
            StrSql = StrSql.Replace("$4", this.descripcion);
            StrSql = StrSql.Replace("$5", this.montoCredito);
            StrSql = StrSql.Replace("$6", this.montoDebito);
            StrSql = StrSql.Replace("$7", this.status);
            StrSql = StrSql.Replace("$8", usuario);
            StrSql = StrSql.Replace("$9", bd);
            StrSql = StrSql.Replace("$hora", this.hora);
            StrSql = StrSql.Replace("$idSistemaInt", this.IdSistemasInt);

            database.ejecutarInsert(StrSql);
            database.modificarConexionString(1);
            database.cerrarConexion();

            }

            public void asignarNumeroComprobante(string bd)
            {
                database.conectionStringSysconta(bd);

                ds = database.ejecutarQueryDs("SELECT pc_idSistema,pc_CorrCompAut FROM admparametroscontables WHERE pc_idSistema='04'");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    this.Comprobante = String.Format("{0:0000000000}", Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()) + 1);
                    this.IdSistemasInt=ds.Tables[0].Rows[0][0].ToString();
                    database.ejecutarInsert("UPDATE admparametroscontables SET pc_CorrCompAut='" + this.Comprobante + "' WHERE pc_idSistema='04'");

                }
                database.modificarConexionString(1);
                database.cerrarConexion();

            }


            public DataTable datosComprobante(string comprobante, string compania) {
                string bd;

                if (compania.Equals("01"))
                {
                    bd = "sysconta";

                }
                else {
                    bd = "sysconta_" + compania;
                }


                StrSql = " SELECT movcon_item, movcon_proveedor, movcon_numdoc, movcon_sufdoc,movcon_monto, " +
                             " movcon_tipdoc,movcon_tipo,movcon_fecaha,movcon_login,movcon_cuenta,movcon_auxiliar, movcon_descrip ,  " +
                             " movcon_status,movcon_numcomp,movcon_rif, pro_nombre,pro_rif,usu_nombre,admcuentascontables.cc_Descripcion   " +
                             " FROM admmovcontab   " +
                             " LEFT OUTER JOIN admproveedor ON pro_codigo=movcon_proveedor  " +
                             " LEFT OUTER JOIN sysconf.confusuario ON sysconf.confusuario.usu_codigo =movcon_login  " +
                             " LEFT OUTER JOIN " + bd + ".admcuentascontables ON " + bd + ".admcuentascontables.cc_CodigoCuenta = movcon_cuenta  " +
                             " WHERE movcon_numcomp='$1' order By length(movcon_item), movcon_item;";



                StrSql = StrSql.Replace("$1", comprobante);

                return database.fDataTable(StrSql);
            }

            public bool verificarTipDocPro2(string proveedor, string tipoDoc)
            {
                bool bandera = false;

                StrSql = "SELECT * FROM admtipdocpro2 WHERE n_proveedor='$1' AND n_tipo='$2'";

                StrSql = StrSql.Replace("$1",proveedor);
                StrSql = StrSql.Replace("$2", tipoDoc);

                tabla = database.fDataTable(StrSql);

                if (tabla.Rows.Count > 0)
                {
                    bandera = true;
                }

                database.cerrarConexion();
                return bandera;

            }


        

    }
}

