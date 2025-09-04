using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lebrun.clases.complementos
{
    class cuentasContables
    {

        private string StrSql;
        private ConexionBD database;
        private DataSet ds;
        private MySqlDataReader dr;

        private string cuentaProveedor;
        private string cuentaTipDocPro;
        private string cuentaTipDocPro_2;
        private string numeroCuenta;
        private string numeroAuxiliar;



        public string CuentaProveedor
        {
            get { return cuentaProveedor; }
            set { cuentaProveedor = value; }
        }
        
        public string CuentaTipDocPro
        {
            get { return cuentaTipDocPro; }
            set { cuentaTipDocPro = value; }
        }

        public string NumeroCuenta
        {
            get { return numeroCuenta; }
            set { numeroCuenta = value; }
        }

        public string NumeroAuxiliar
        {
            get { return numeroAuxiliar; }
            set { numeroAuxiliar = value; }
        }

        public string CuentaTipDocPro_2
        {
            get { return cuentaTipDocPro_2; }
            set { cuentaTipDocPro_2 = value; }
        }


        public cuentasContables() {

            database = new ConexionBD();
        }

        public void consultarCuentaProveedor(string proveedor)
        {

            //StrSql = "SELECT n_cuenta FROM admtipdocpro2 WHERE n_tipo='' AND n_proveedor='' ";
            //StrSql = StrSql.Replace("$1",);
            //StrSql = StrSql.Replace("$2",);

            //dr = database.ejecutarQueryDr(StrSql);

            //if (dr.HasRows)
            //{
            //    dr.Read();

            //}

        }

        public void consultarTipDocPro(string tipoDoc) {

            database.modificarConexionString(1);

            StrSql = "SELECT tdc_codcta,tdc_reporte FROM admtipdocpro WHERE tdc_codigo='$1'";
            StrSql = StrSql.Replace("$1",tipoDoc);

            dr = database.ejecutarQueryDr(StrSql);

            if (dr.HasRows)
            {
                dr.Read();

                this.cuentaTipDocPro = dr.GetString("tdc_codcta");
                this.cuentaTipDocPro_2 = dr.GetString("tdc_reporte");
            }
        }

        public void consultarTipDocPro2(string tipoDoc, string proveedor)
        {
            database.modificarConexionString(1);

            StrSql = "SELECT n_cuenta FROM admtipdocpro2 WHERE n_tipo='$1' AND n_proveedor='$2'";
            StrSql = StrSql.Replace("$1", tipoDoc);
            StrSql = StrSql.Replace("$2", proveedor);

            dr = database.ejecutarQueryDr(StrSql);

            if (dr.HasRows)
            {
                dr.Read();
                this.cuentaProveedor = dr.GetString("n_cuenta");

            }

        }

        public void asignarCuentaContable(string nombreProveedor,string codigoProveedor) {

            database.modificarConexionString(3);

            if (this.cuentaTipDocPro.Substring(4).Equals("00000"))
            {
                StrSql = "SELECT cc_CodigoCuenta FROM admcuentascontables " +
                            " WHERE cc_CodigoCuenta LIKE '" + this.cuentaTipDocPro.Substring(0,4) + "%' " +
                            " ORDER BY cc_codigoCuenta DESC limit 1";

                dr=database.ejecutarQueryDr(StrSql);

                if (dr.HasRows)
                {
                    dr.Read();
                    this.numeroCuenta = dr.GetString("cc_CodigoCuenta");
                    this.numeroCuenta =""+ (Convert.ToInt32(this.numeroCuenta) + 1);
                    
                }

                StrSql = "SELECT cc_CodigoCuenta FROM admcuentascontables " +
                            " WHERE cc_CodigoCuenta='" + this.numeroCuenta + "'";

                dr = database.ejecutarQueryDr(StrSql);

                if (!dr.HasRows)
                {
                    

                    StrSql = "";
                    StrSql = "INSERT INTO admcuentascontables " +
                   " (cc_CodigoCuenta,cc_Descripcion,cc_NivelTotal,cc_FlagAux,cc_FlagImpBal,cc_FlagImpDia,cc_SaldoIniEjerc,cc_Siglas,cc_Compania,cc_Fecha,cc_User,cc_ManejaAuxiliar,cc_control)VALUES " +
                   " ('" + this.numeroCuenta + "','" + nombreProveedor + "','5','0','1','1','0.00','CC','0','" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','0029','0','0')";
                    
                    database.modificarConexionString(3);
                    database.ejecutarInsert(StrSql);

                    StrSql = "INSERT INTO admtipdocpro2(n_tipo,n_proveedor,n_cuenta,n_auxiliar,n_fecha,n_user)VALUES('35','" + codigoProveedor + "','" + this.numeroCuenta + "','','" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','0029')";

                    database.modificarConexionString(1);
                    database.ejecutarInsert(StrSql);
                }
            }
            else
            {
                database.modificarConexionString(3);

                StrSql =    "SELECT admAC_codigoAuxiliarContable FROM admauxiliarcontable " +
                            " WHERE admAC_codigoCuenta ='" + this.cuentaTipDocPro + "' ORDER BY admAC_codigoAuxiliarContable DESC LIMIT 1  ";

                dr = database.ejecutarQueryDr(StrSql);

                if (dr.HasRows)
                {
                    dr.Read();
                    this.numeroAuxiliar = this.numeroAuxiliar + 1;
                    this.numeroAuxiliar = this.numeroAuxiliar.PadLeft(5, '0');

                }
                else {

                    this.numeroAuxiliar = "00001";
                }

                StrSql = "INSERT INTO admauxiliarcontable(admAC_codigoCuenta,admAC_descripcion,admAC_manejaDocumentos,admAC_codigoAuxiliarContable,admAC_fechaCreacion,admAC_usuario,admAC_saldoApertura,admAC_control) VALUES " +
                    "('" + this.numeroCuenta + "','" + nombreProveedor + "','1','" + this.numeroAuxiliar + "','" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','0029','0.00','0')";

                database.ejecutarInsert(StrSql);

                StrSql = "INSERT INTO admtipdocpro2(n_tipo,n_proveedor,n_cuenta,n_auxiliar)VALUES('35','" + nombreProveedor + "','" + this.numeroCuenta + "','" + this.numeroAuxiliar + "')";
                database.modificarConexionString(1);
                database.ejecutarInsert(StrSql);
            }

            database.modificarConexionString(1);
            database.cerrarConexion();
        }


        public bool consultarTipDocProBool(string tipoDoc, string proveedor)
        {
            database.modificarConexionString(1);

            StrSql = "SELECT n_cuenta FROM admtipdocpro2 WHERE n_tipo='$1' AND n_proveedor='$2'";
            StrSql = StrSql.Replace("$1", tipoDoc);
            StrSql = StrSql.Replace("$2", proveedor);

            dr = database.ejecutarQueryDr(StrSql);

            if (dr.HasRows)
            {
                return true;

            }
            else {
                return false;
            }

        }



    }
}
