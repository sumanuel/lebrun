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
    class DetalleComprobanteContable: ComprobanteContable
    {
        private string registro;       
        private string nroComprobante;
        private int item;
        private string fechaCargaD;        
        private string codigoMayor;
        private string codigoAuxiliar;
        private string nroDocumento;
        private string nroReferencia;
        private string descripcionD;        
        private int statusD;
        private string login;
        private string ultLogin;
        private string fechaMod;
        private string compania;
        private string tipoTransaccion;
        private string monto;

        public string Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        public string Registro
        {
            get { return registro; }
            set { registro = value; }
        }
        public string NroComprobante
        {
            get { return nroComprobante; }
            set { nroComprobante = value; }
        }
        public int Item
        {
            get { return item; }
            set { item = value; }
        }
        public string FechaCarga1
        {
            get { return fechaCargaD; }
            set { fechaCargaD = value; }
        }
        public string CodigoMayor
        {
            get { return codigoMayor; }
            set { codigoMayor = value; }
        }
        public string CodigoAuxiliar
        {
            get { return codigoAuxiliar; }
            set { codigoAuxiliar = value; }
        }
        public string NroDocumento
        {
            get { return nroDocumento; }
            set { nroDocumento = value; }
        }
        public string NroReferencia
         {
             get { return nroReferencia; }
             set { nroReferencia = value; }
         }
        public string Descripcion1
         {
             get { return descripcionD; }
             set { descripcionD = value; }
         }
        public int Status1
         {
             get { return statusD; }
             set { statusD = value; }
         }
        public string Login
         {
             get { return login; }
             set { login = value; }
         }
        public string UltLogin
         {
             get { return ultLogin; }
             set { ultLogin = value; }
         }
        public string FechaMod
         {
             get { return fechaMod; }
             set { fechaMod = value; }
         }
        public string Compania
         {
             get { return compania; }
             set { compania = value; }
         }
        public string TipoTransaccion
         {
             get { return tipoTransaccion; }
             set { tipoTransaccion = value; }
         }

        //base de datos
        private string sentencia;
        private ConexionBD database;

        public DetalleComprobanteContable() {
            database = new ConexionBD(3);
        }

        public void agregarDetalleTemp()
        {
            sentencia = "INSERT INTO admmovimientoscontabled_temp (mcd_idRegistro, mcd_NroComprobante, mcd_Item, mcd_FechaCarga, " +
                        "mcd_CodigoMayor, mcd_CodigoAux, mcd_NroDocum, mcd_Referencia, mcd_Descripcion, mcd_status, mcd_login, " +
                        "mcd_UltLogin, mdc_FechaUltMod, mdc_Compania, mdc_TipoTransaccion, mdc_monto) VALUES('$1','$2',$3,'$4'," +
                        "'$5', '$6','$7','$8','$9',$status,'$login','$ulLogin','$fechMod','$compania','$transaccion'," +
                        "$monto);";

            sentencia = sentencia.Replace("$1", this.registro);
            sentencia = sentencia.Replace("$2", this.nroComprobante);
            sentencia = sentencia.Replace("$3", Convert.ToString(this.item));
            sentencia = sentencia.Replace("$4", this.fechaCargaD);
            sentencia = sentencia.Replace("$5", this.codigoMayor);
            sentencia = sentencia.Replace("$6", this.codigoAuxiliar);
            sentencia = sentencia.Replace("$7", this.nroDocumento);
            sentencia = sentencia.Replace("$8", this.nroReferencia);
            sentencia = sentencia.Replace("$9", this.descripcionD);
            sentencia = sentencia.Replace("$status",Convert.ToString(this.statusD));
            sentencia = sentencia.Replace("$login", this.login) ;
            sentencia = sentencia.Replace("$ulLogin", this.ultLogin);
            sentencia = sentencia.Replace("$fechMod", this.fechaMod);
            sentencia = sentencia.Replace("$compania", this.compania);
            sentencia = sentencia.Replace("$transaccion", this.tipoTransaccion);
            sentencia = sentencia.Replace("$monto", Convert.ToString(this.monto));            
            database.ejecutarInsert(sentencia);

        }


        //public void agregarDetalleTemp(int idDB) {
        //    this.database.modificarConexionString(idDB);
        //    agregarDetalleTemp();
        //    //se deja por defecto
        //    this.database.modificarConexionString(idDB);
        //}

        public void agregarDetalleTemp(string idbaseDatos) {
            database.conectionStringSysconta(idbaseDatos);
            agregarDetalleTemp();
        }


        public void agregarDetalle() {
            sentencia = "INSERT INTO admmovimientoscontabled (mcd_NroComprobante, mcd_Item, mcd_FechaCarga, " +
                       "mcd_CodigoMayor, mcd_CodigoAux, mcd_NroDocum, mcd_Referencia, mcd_Descripcion, mcd_status, mcd_login, " +
                       "mcd_UltLogin, mdc_FechaUltMod, mdc_Compania, mdc_TipoTransaccion, mdc_monto,mdc_FechaComprobante) VALUES('$2',$3,'$4'," +
                       "'$5', '$6','$7','$8','$9',$status,'$login','$ulLogin','$fechMod','$compania','$transaccion'," +
                       "$monto, '$fechaItem');";
            
            sentencia = sentencia.Replace("$2", this.nroComprobante);
            sentencia = sentencia.Replace("$3", Convert.ToString(this.item));
            sentencia = sentencia.Replace("$4", this.fechaCargaD);
            sentencia = sentencia.Replace("$5", this.codigoMayor);
            sentencia = sentencia.Replace("$6", this.codigoAuxiliar);
            sentencia = sentencia.Replace("$7", this.nroDocumento);
            sentencia = sentencia.Replace("$8", this.nroReferencia);
            sentencia = sentencia.Replace("$9", this.descripcionD);
            sentencia = sentencia.Replace("$status", Convert.ToString(this.statusD));
            sentencia = sentencia.Replace("$login", this.login);
            sentencia = sentencia.Replace("$ulLogin", this.ultLogin);
            sentencia = sentencia.Replace("$fechMod", this.fechaMod);
            sentencia = sentencia.Replace("$compania", this.compania);
            sentencia = sentencia.Replace("$transaccion", this.tipoTransaccion);
            sentencia = sentencia.Replace("$monto", Convert.ToString(this.monto));
            sentencia = sentencia.Replace("$fechaItem", this.FechaComprobanteItem);
            database.ejecutarInsert(sentencia);
        }

        //public void agregarDetalle(int idDB) {
        //    this.database.modificarConexionString(idDB);
        //    agregarDetalle();
        //    //la base de datos por defecto
        //    this.database.modificarConexionString(3);
        //}
        public void agregarDetalle(string idBaseDatos)
        {
            database.conectionStringSysconta(idBaseDatos);
            agregarDetalle();
        }

        public void limpiar() { 
            registro = null;
            nroComprobante = null;
            item= 0;
            fechaCargaD = null;
            codigoMayor = null;
            codigoAuxiliar = null;
            nroDocumento = null;
            nroReferencia = null;
            descripcionD = null;
            statusD = 0;
            login = null;
            ultLogin = null;
            fechaMod = null;
            compania = null;
            tipoTransaccion = null;
            monto = null;
        }

        public DataTable itemsDetalle(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT mcd_Item as colItem, mcd_NroDocum as colDocumento, mcd_CodigoMayor as colPlanC, mcd_CodigoAux as colAuxiliar, mcd_Referencia as colReferencia, mcd_Descripcion as colConcepto, " +
                        "IF(mdc_TipoTransaccion='C',mdc_monto,'') as colCreditos, " +
                        "IF(mdc_TipoTransaccion='D',mdc_monto,'') as colDebito, " +
                        "mcd_CodigoMayor as colCodPlanC, date_format(mcd_FechaCarga, '%Y-%m-%d') as colFechaTrans , mcd_UltLogin as colutMod ,date_format(mdc_FechaUltMod, '%Y-%m-%d') as ultUsuariomod  FROM admmovimientoscontabled_temp WHERE mcd_idRegistro='$1';";
            sentencia = sentencia.Replace("$1", this.nroComprobante);
            return database.fDataTable(sentencia);
        }

        public DataTable itemsDetalle(string idBaseDatos, int tabla)
        {
            DataTable temporal;
            //tabla = 1 temporal tabla=2 definivito
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT mcd_Item as colItem, mcd_NroDocum as colDocumento, mcd_CodigoMayor as colPlanC, mcd_CodigoAux as colAuxiliar, mcd_Referencia as colReferencia, mcd_Descripcion as colConcepto, " +
                        "IF(mdc_TipoTransaccion='C',mdc_monto,'') as colCreditos, " +
                        "IF(mdc_TipoTransaccion='D',mdc_monto,'') as colDebito, " +
                        "mcd_CodigoMayor as colCodPlanC, date_format(mcd_FechaCarga, '%Y-%m-%d') as colFechaTrans , mcd_UltLogin as colutMod ,date_format(mdc_FechaUltMod, '%Y-%m-%d') as ultUsuariomod  FROM $tabla WHERE mcd_NroComprobante='$1';";
            //admmovimientoscontabled_temp
            if (tabla == 1) { 
                sentencia = sentencia.Replace("$tabla","admmovimientoscontabled_temp");
            }

            if (tabla == 2) {
                sentencia = sentencia.Replace("$tabla", "admmovimientoscontabled");
            }

            sentencia = sentencia.Replace("$1", this.nroComprobante);
            temporal = database.fDataTable(sentencia);
            
            //se deja por defecto la conexion original
            this.database.modificarConexionString(3);

            return temporal;
        }

        public bool borrarItemsTemporal(string codigo,string idBaseDatos) {
            bool centinela = true;
            database.conectionStringSysconta(idBaseDatos);

            if (existeTemporalDetalle(codigo))
            {
                sentencia = "DELETE FROM admmovimientoscontabled_temp WHERE mcd_NroComprobante='$1';";
                sentencia = sentencia.Replace("$1", codigo);
                centinela=  database.ejecutarInsert(sentencia);
            }
            return centinela;

        }

        //aquii
        public bool borrarItems(string codigo,string idBD)
        {
            bool centinela = true;
            database.conectionStringSysconta(idBD);
            //aqui no se modifica otra vez porque modifique el conection string arriba
            if (existeDetalle(codigo))
            {
                sentencia = "DELETE FROM admmovimientoscontabled WHERE mcd_NroComprobante='$1';";
                sentencia = sentencia.Replace("$1", codigo);
                centinela = database.ejecutarInsert(sentencia);
            }
            return centinela;

        }

        public bool existeDetalle(string codigo)
        {
            bool centinela = true;
            MySqlDataReader dr;
            sentencia = "SELECT COUNT(*) FROM admmovimientoscontabled WHERE mcd_NroComprobante='$1';";
            sentencia = sentencia.Replace("$1", codigo);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(0) == 0)
                    {
                        centinela = false;
                        dr.Close();
                        break;
                    }
                }
            }
            dr.Close();
            database.cerrarConexion();
            return centinela;
        }

        public bool existeTemporalDetalle(string codigo)
        {
            bool centinela = true;
            MySqlDataReader dr;
            sentencia = "SELECT COUNT(*) FROM admmovimientoscontabled_temp WHERE mcd_NroComprobante='$1';";
            sentencia = sentencia.Replace("$1", codigo);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(0) == 0)
                    {
                        centinela = false;
                        dr.Close();
                        break;
                    }
                }
            }
            dr.Close();
            database.cerrarConexion();
            return centinela;
        }
    }
}
