using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using lebrun.clases.clientes;

namespace lebrun.clases.contabilidad
{
    public class AuxiliarContable:PlanCuentas
    {
        private string codigoAuxiliar;
        private string nombreAuxiliar;
        private bool manejaDocumentos;
        DateTime fechaCreacion;
        private string sentencia;
        private string montoApertura;
        private string controAux;
        private bool tieneAuxiliar;
        private ConexionBD database;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public bool ManejaDocumentos
        {
            get { return manejaDocumentos; }
            set { manejaDocumentos = value; }
        }
        public string CodigoAuxiliar
        {
            get { return codigoAuxiliar; }
            set { codigoAuxiliar = value; }
        }
        public string NombreAuxiliar
        {
            get { return nombreAuxiliar; }
            set { nombreAuxiliar = value; }
        }
        public string MontoApertura
        {
            get { return montoApertura; }
            set { montoApertura = value; }
        }

        public string ControAux
        {
            get { return controAux; }
            set { controAux = value; }
        }

        public bool TieneAuxiliar
        {
            get { return tieneAuxiliar; }
            set { tieneAuxiliar = value; }
        }

        public AuxiliarContable() {
            /*para que el conexion string este en
            sysconta*/
            database = new ConexionBD(3);
        }

        public void limpiarObjetAux() { 
            codigoAuxiliar= null;
            nombreAuxiliar = null;
            manejaDocumentos = false;
            sentencia= null;
            montoApertura = null;
            controAux = null;
        }

        public DataTable lbxAuxiliar(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            DataTable dt = new DataTable();
            sentencia = "SELECT cc_CodigoCuenta  as codigo ,cc_Descripcion as Descripcion, cc_CodigoCuenta, cc_control " +
                        "FROM admcuentascontables WHERE cc_NivelTotal=5 AND cc_FlagAux= true AND (cc_control='0' "+
                        " OR  LOCATE('"+ idBaseDatos+"',cc_control) <> 0) ORDER BY cc_CodigoCuenta,cc_NivelTotal;";
            dt = database.fDataTable(sentencia);
            return dt;
        }


        public DataTable lbxAuxiliarMayor(string idBaseDatos)
        {
            database.conectionStringSysconta(idBaseDatos);
            DataTable dt = new DataTable();
            sentencia = "SELECT cc_CodigoCuenta  as codigo ,cc_Descripcion as Descripcion, cc_CodigoCuenta " +
                        "FROM admcuentascontables WHERE cc_NivelTotal=5 AND (cc_control='0' OR LOCATE('" + idBaseDatos + "',cc_control) <> 0) ORDER BY cc_CodigoCuenta,cc_NivelTotal;";
            dt = database.fDataTable(sentencia);
            return dt;
        }


        public DataTable lbxAuxiliarBaseDatos(string codigo,string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            DataTable dt = new DataTable();
            sentencia = "SELECT cc_CodigoCuenta  as codigo ,cc_Descripcion as Descripcion, cc_CodigoCuenta, cc_control  " +
                        "FROM admcuentascontables WHERE cc_CodigoCuenta LIKE '%$1%' OR cc_Descripcion LIKE '%$2%'"+
                        " AND cc_NivelTotal=5 ORDER BY cc_CodigoCuenta,cc_NivelTotal;";

            sentencia = sentencia.Replace("$1", codigo);
            sentencia = sentencia.Replace("$2", codigo);
            dt = database.fDataTable(sentencia);
            return dt;
        }


        internal bool existeAxulilar() { 
            bool centinela = true;
            MySqlDataReader dr;
            sentencia = "SELECT COUNT(*) FROM admauxiliarcontable WHERE admAC_codigoCuenta='$1' " +
                        "and admAC_codigoAuxiliarContable='$2'";
            sentencia = sentencia.Replace("$1", this.CodigoPlanCuentas);
            sentencia = sentencia.Replace("$2", this.codigoAuxiliar);

            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    if (dr.GetInt32(0) == 0) {
                        centinela = false;
                        break;
                    }
                }
                dr.Close();
                database.cerrarConexion();               
            }
            return centinela;
        }

        public bool permisoAuxiliar(string codigoMayor, string codigoAux ,string idBaseDatos)
        {
            bool centinela = false;
            DataTable dt;
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT admAC_codigoAuxiliarContable,admAC_descripcion,admAC_manejaDocumentos,admAC_saldoApertura, admAC_control FROM admauxiliarcontable " +
                        "WHERE admAC_codigoCuenta='$1' AND admAC_codigoAuxiliarContable='$2' AND (admAC_control='0' OR LOCATE('$3',admAC_control)<>0);";

            sentencia = sentencia.Replace("$1", codigoMayor);
            sentencia = sentencia.Replace("$2", codigoAux);
            sentencia = sentencia.Replace("$3", idBaseDatos);
            dt= database.fDataTable(sentencia);
            if (dt.Rows.Count>0){
                centinela = true;
            }
            return centinela;
        }


        public bool agregarAuxiliar(string usuario,string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            bool centinela = true;
            DateTime x = DateTime.Now;
            if (!existeAxulilar())
            {
                sentencia = "INSERT INTO admauxiliarcontable (admAC_codigoCuenta, admAC_descripcion,admAC_manejaDocumentos, " +
                            "admAC_codigoAuxiliarContable, admAC_fechaCreacion, admAC_usuario, admAC_saldoApertura,admAC_control) VALUES ('$1','$2',$3,'$4','$5','$6', $7,'$8')";
                sentencia = sentencia.Replace("$1", this.CodigoPlanCuentas);
                sentencia = sentencia.Replace("$2", this.nombreAuxiliar);
                sentencia = sentencia.Replace("$3", this.manejaDocumentos.ToString());
                sentencia = sentencia.Replace("$4", this.codigoAuxiliar);
                sentencia = sentencia.Replace("$5", "" + x.Year + "-" + x.Month + "-" + x.Day + "");
                sentencia = sentencia.Replace("$6", usuario);
                sentencia = sentencia.Replace("$7", this.montoApertura);
                sentencia = sentencia.Replace("$8", this.controAux);
                centinela = database.ejecutarInsert(sentencia);
            }
            else {
                MessageBox.Show("El Auxiliar: " + this.codigoAuxiliar+" Ya Existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centinela = false;
            }
            return centinela;
        }

        public DataTable detalleAuxiliar(string codigo,string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT admAC_codigoAuxiliarContable,admAC_descripcion,admAC_manejaDocumentos,admAC_saldoApertura, admAC_control FROM admauxiliarcontable " +
                        "WHERE admAC_codigoCuenta='$1' AND (admAC_control='0' OR LOCATE('$2',admAC_control)<>0);";

            sentencia = sentencia.Replace("$1", codigo);
            sentencia = sentencia.Replace("$2", idBaseDatos);
            return database.fDataTable(sentencia);
        }

        public bool modificarAuxiliar(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            bool centinela = true;
            sentencia = "UPDATE admauxiliarcontable SET admAC_descripcion='$1', admAC_saldoApertura = $4, admAC_control = '$5' WHERE " +
                        "admAC_codigoCuenta = '$2' AND admAC_codigoAuxiliarContable='$3';";
            sentencia = sentencia.Replace("$1", this.nombreAuxiliar);
            sentencia = sentencia.Replace("$2", this.CodigoPlanCuentas);
            sentencia = sentencia.Replace("$3", this.codigoAuxiliar);
            sentencia = sentencia.Replace("$4", this.montoApertura);
            sentencia = sentencia.Replace("$5", this.controAux);
            centinela = database.ejecutarInsert(sentencia);
            return centinela;
        }


        public DataTable mostrarAuxiliares(string codigoCuentaCon, string idBaseDatos) { 
            DataTable dt = new DataTable();
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT admAC_codigoAuxiliarContable,CONCAT(admAC_codigoAuxiliarContable, '  ',admAC_descripcion) as descricion FROM admauxiliarcontable  " +
                        "WHERE admAC_codigoCuenta='$1' AND (admAC_control='0' OR LOCATE('$2',admAC_control)<>0);";

            sentencia = sentencia.Replace("$1", codigoCuentaCon);
            sentencia = sentencia.Replace("$2", idBaseDatos);
            dt = database.fDataTable(sentencia);
            return dt;
        }

        public bool valManejaDocumentos(string codigoAuxiliar2, string codigoCuenta2, string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            bool centinela = false;
            MySqlDataReader dr;
            sentencia = "SELECT admAC_manejaDocumentos FROM admauxiliarcontable WHERE admAC_codigoCuenta ='$1'"+
                        " AND admAC_codigoAuxiliarContable='$2';";
            sentencia = sentencia.Replace("$1", codigoCuenta2);
            sentencia = sentencia.Replace("$2", codigoAuxiliar2);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetBoolean(0))
                    {
                        centinela = true;
                        break;
                    }
                    else {
                        centinela = false;
                    }
                }
                dr.Close();
                database.cerrarConexion();
            }
            return centinela;
        }

        public string convertirAuxiliar(string codAuxiliar) { 
            string convertido= null;

            if (Convert.ToDouble(codAuxiliar) >= 10000)
            {
                convertido= codAuxiliar;
            }
            else {
                if ((Convert.ToDouble(codAuxiliar) <= 9)){
                    convertido = "0000" + Convert.ToString(Convert.ToDouble(codAuxiliar));
                }

                if ((Convert.ToDouble(codAuxiliar) >= 10) && ((Convert.ToDouble(codAuxiliar) <= 99))) {
                    convertido = "000" + Convert.ToString(Convert.ToDouble(codAuxiliar));
                }

                if ((Convert.ToDouble(codAuxiliar) >= 100) && ((Convert.ToDouble(codAuxiliar) <= 999)))
                {
                    convertido = "00" + Convert.ToString(Convert.ToDouble(codAuxiliar));
                }

                if ((Convert.ToDouble(codAuxiliar) >= 1000) && ((Convert.ToDouble(codAuxiliar) <= 9999)))
                {
                    convertido = "0" + Convert.ToString(Convert.ToDouble(codAuxiliar));
                }
            }
            return convertido;
        }

        public string getDescripcionAuxiliar(string codigoPlanC, string codigoAux, string idBaseDatos) {
            string descripcionAux = null;
            MySqlDataReader dr;
            
            database.conectionStringSysconta(idBaseDatos);
            
            sentencia = "";
            sentencia = "SELECT admAC_descripcion FROM admauxiliarcontable WHERE admAC_codigoCuenta='$1' " +
                                "AND admAC_codigoAuxiliarContable='$2'";
            sentencia = sentencia.Replace("$1", codigoPlanC);
            sentencia = sentencia.Replace("$2", codigoAux);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    descripcionAux = dr.GetString(0);
                }
            }
            dr.Close();
            database.cerrarConexion();
            return descripcionAux;
        }

        public void ingresarMCuentaFAV(string idBaseDatos, Clientes cli1, string codoFav, string usuario)
        {
            DateTime x = DateTime.Now;
            string cuenta = null;
            sentencia = null;

            database.conectionStringSysconta(idBaseDatos);

            cuenta = maxValueAdmCuentasContable(codoFav, idBaseDatos);
            sentencia = "INSERT INTO admcuentascontables (cc_CodigoCuenta,cc_Descripcion, cc_NivelTotal, " +
                             "cc_FlagAux, cc_FlagImpBal, cc_FlagImpDia, cc_SaldoIniEjerc, cc_Siglas, cc_Compania, " +
                             "cc_Fecha, cc_User,cc_ManejaAuxiliar, cc_control) VALUES( '" + cuenta +
                             "' ,'" + cli1.Nombre + "','5','0','1','1','0.00','CC','0','" + x.Year + "-" + x.Month + "-" + x.Day + "','" + usuario + "'," +
                             "'0','0');";

            database.ejecutarInsert(sentencia);
            database.cerrarConexion();
            cli1.actualizarCuentaMA(cuenta, null);
        }

        public void ingresarACuentaFAV(string idBaseDatos, Clientes cli1, string codoFav, string usuario)
        {
            DateTime x = DateTime.Now;
            string cuenta = null;
            sentencia = null;

            cuenta = maxValueAdmAuxiliar(codoFav, idBaseDatos);
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "INSERT INTO admauxiliarcontable(admAC_codigoCuenta,admAC_descripcion,admAC_manejaDocumentos,admAC_codigoAuxiliarContable, " +
                              "admAC_fechaCreacion,admAC_usuario,admAC_saldoApertura,admAC_control) " +
                              "VALUES (" +
                              "'" + codoFav + "','" + cli1.Nombre + "','1','" + cuenta + "', " +
                              "'" + x.Year + "-" + x.Month + "-" + x.Day + "','" + usuario + "', '0.00','0')";
            database.ejecutarInsert(sentencia);
            database.cerrarConexion();
            cli1.actualizarCuentaMA(codoFav, cuenta);
        }


        public string maxValueAdmAuxiliar(string codigo, string idBaseDatos)
        {
            DataTable dt;
            string auxiliar = null;
            sentencia = null;
            database.conectionStringSysconta(idBaseDatos);

            sentencia = "SELECT admAC_codigoAuxiliarContable FROM admauxiliarcontable " +
                             "WHERE admAC_codigoCuenta ='$1' ORDER BY admAC_codigoAuxiliarContable DESC LIMIT 1;";
            sentencia = sentencia.Replace("$1", codigo);

            dt = database.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                auxiliar = Convert.ToString(Convert.ToDouble(dt.Rows[0]["admAC_codigoAuxiliarContable"].ToString()) + 1).PadLeft(5, '0');
            }
            database.cerrarConexion();
            return auxiliar;
        }
    }
}
