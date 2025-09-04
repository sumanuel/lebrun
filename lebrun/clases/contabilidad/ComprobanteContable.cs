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
   public class ComprobanteContable
    {
        // esto forma la cabecera que llenan en el formulario
        private string nroComprobanteCorrelativo;
        private string descripcion;
        private int status;
        private int idOrigen;
        private string fechaComprobante;
        private string fechaCarga;
        private string nroCierre;
        private string montoDebito;
        private string montoCredito;
        private string ultimoLogin;
        private string ultimaFecha;
        private string compania1;
        private string fechaComprobanteItem;
        

        //base de datos
        private string sentencia;
        private ConexionBD database;
        private DataSet ds;
        private MySqlDataReader dr;

        public string NroComprobanteCorrelativo
        {
            get { return nroComprobanteCorrelativo; }
            set { nroComprobanteCorrelativo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int IdOrigen
        {
            get { return idOrigen; }
            set { idOrigen = value; }
        }
        public string FechaComprobante
        {
            get { return fechaComprobante; }
            set { fechaComprobante = value; }
        }
        public string FechaCarga
        {
            get { return fechaCarga; }
            set { fechaCarga = value; }
        }
        public string NroCierre
        {
            get { return nroCierre; }
            set { nroCierre = value; }
        }
        public string MontoCredito
        {
            get { return montoCredito; }
            set { montoCredito = value; }
        }
        public string MontoDebito
        {
            get { return montoDebito; }
            set { montoDebito = value; }
        }
        public string UltimaFecha
        {
            get { return ultimaFecha; }
            set { ultimaFecha = value; }
        }
        public string UltimoLogin
        {
            get { return ultimoLogin; }
            set { ultimoLogin = value; }
        }
        public string Compania1
        {
            get { return compania1; }
            set { compania1 = value; }
        }
        public string FechaComprobanteItem
        {
            get { return fechaComprobanteItem; }
            set { fechaComprobanteItem = value; }
        }

        public ComprobanteContable() {
            database = new ConexionBD(3);
        }

        public void asignarCorrelativo(string idBaseDatos){
            this.database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT pc_CorrCompAut FROM admparametroscontables WHERE pc_idSistema = '09';";
            ds = database.ejecutarQueryDs(sentencia);
            if (ds.Tables[0].Rows.Count != 0) {
                this.nroComprobanteCorrelativo = String.Format("{0:0000000000}", Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString()) + 1);
                sentencia = "UPDATE admparametroscontables SET pc_CorrCompAut='$1' WHERE pc_idSistema = '09';";
                sentencia = sentencia.Replace("$1", this.nroComprobanteCorrelativo);
                database.ejecutarInsert(sentencia);
            }
        }

        public void agregarCabeceraTemp(string login, string compania,string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "INSERT INTO admmovimientoscontablesc_temp (mc_nroComprobante, mc_FechaComprobante, " +
                        "mc_FechaCarga, mc_IdSistema, mc_Descripcion, mc_MontoDebitos, mc_MontoCreditos, mc_Status, mc_Login, " +
                        "mc_Compania, mc_LoginUpd, mc_FechaUltMod,mc_HoraGuardado) VALUES ('$2', '$3', '$4', $5, '$6', '$7','$8', $9, '$login', '$compania'," +
                        "'$ultimoLog','$ultimaFecha','$horaGuardado');";
            
            sentencia = sentencia.Replace("$2", this.nroComprobanteCorrelativo);
            sentencia = sentencia.Replace("$3", this.fechaComprobante);
            sentencia = sentencia.Replace("$4", this.fechaCarga);
            sentencia = sentencia.Replace("$5", this.idOrigen.ToString());
            sentencia = sentencia.Replace("$6", this.descripcion);
            sentencia = sentencia.Replace("$7", this.montoDebito);
            sentencia = sentencia.Replace("$8", this.MontoCredito);
            sentencia = sentencia.Replace("$9", this.status.ToString());
            sentencia = sentencia.Replace("$login", login);
            sentencia = sentencia.Replace("$compania", compania);
            sentencia = sentencia.Replace("$ultimoLog", this.ultimoLogin);
            sentencia = sentencia.Replace("$ultimaFecha", this.ultimaFecha);
            sentencia = sentencia.Replace("$horaGuardado", DateTime.Now.ToString("hh:mm:ss"));            
            database.ejecutarInsert(sentencia);
        }

        public void agregarCabecera(string login, string compania)
        {
            //DateTime.Now.ToString("hh:mm:ss")
            sentencia = "INSERT INTO admmovimientoscontablesc (mc_nroComprobante, mc_FechaComprobante, " +
                        "mc_FechaCarga, mc_IdSistema, mc_Descripcion, mc_MontoDebitos, mc_MontoCreditos, mc_Status, mc_Login, " +
                        "mc_Compania, mc_LoginUpd, mc_FechaUltMod,mc_HoraGuardado,mc_FechaCierre) VALUES ('$2', '$3', '$4', $5, '$6', '$7','$8', $9, '$login', '$compania'," +
                        "'$ultimoLog','$ultimaFecha','$horaGuardado','$fechaCerrado');";

            sentencia = sentencia.Replace("$2", this.nroComprobanteCorrelativo);
            sentencia = sentencia.Replace("$3", this.fechaComprobante);
            sentencia = sentencia.Replace("$4", this.fechaCarga);
            sentencia = sentencia.Replace("$5", this.idOrigen.ToString());
            sentencia = sentencia.Replace("$6", this.descripcion);
            sentencia = sentencia.Replace("$7", this.montoDebito);
            sentencia = sentencia.Replace("$8", this.MontoCredito);
            sentencia = sentencia.Replace("$9", this.status.ToString());
            sentencia = sentencia.Replace("$login", login);
            sentencia = sentencia.Replace("$compania", compania);
            sentencia = sentencia.Replace("$ultimoLog", this.ultimoLogin);
            sentencia = sentencia.Replace("$ultimaFecha", this.ultimaFecha);
            sentencia = sentencia.Replace("$horaGuardado", DateTime.Now.ToString("hh:mm:ss"));
            sentencia = sentencia.Replace("$fechaCerrado", "" + DateTime.Now.Year + "-" + DateTime.Now.Month+"-"+DateTime.Now.Day);
            database.ejecutarInsert(sentencia);
        }


        public void agregarCabecera2(string login, string compania, string anio, string idBaseDatos)
        {
            //DateTime.Now.ToString("hh:mm:ss")
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "INSERT INTO admmovimientoscontablesc_"+anio+" (mc_nroComprobante, mc_FechaComprobante, " +
                        "mc_FechaCarga, mc_IdSistema, mc_Descripcion, mc_MontoDebitos, mc_MontoCreditos, mc_Status, mc_Login, " +
                        "mc_Compania, mc_LoginUpd, mc_FechaUltMod,mc_HoraGuardado,mc_FechaCierre) VALUES ('$2', '$3', '$4', $5, '$6', '$7','$8', $9, '$login', '$compania'," +
                        "'$ultimoLog','$ultimaFecha','$horaGuardado','$fechaCerrado');";

            sentencia = sentencia.Replace("$2", this.nroComprobanteCorrelativo);
            sentencia = sentencia.Replace("$3", this.fechaComprobante);
            sentencia = sentencia.Replace("$4", this.fechaCarga);
            sentencia = sentencia.Replace("$5", this.idOrigen.ToString());
            sentencia = sentencia.Replace("$6", this.descripcion);
            sentencia = sentencia.Replace("$7", this.montoDebito);
            sentencia = sentencia.Replace("$8", this.MontoCredito);
            sentencia = sentencia.Replace("$9", this.status.ToString());
            sentencia = sentencia.Replace("$login", login);
            sentencia = sentencia.Replace("$compania", compania);
            sentencia = sentencia.Replace("$ultimoLog", this.ultimoLogin);
            sentencia = sentencia.Replace("$ultimaFecha", this.ultimaFecha);
            sentencia = sentencia.Replace("$horaGuardado", DateTime.Now.ToString("hh:mm:ss"));
            sentencia = sentencia.Replace("$fechaCerrado", "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            database.ejecutarInsert(sentencia);
        }

        public void agregarCabecera_cierreEjercicio(string login, string compania,string idBaseDatos)
        {
            //DateTime.Now.ToString("hh:mm:ss")
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "INSERT INTO admmovimientoscontablesc_cierreEjercicio  (mc_nroComprobante, mc_FechaComprobante, " +
                        "mc_FechaCarga, mc_IdSistema, mc_Descripcion, mc_MontoDebitos, mc_MontoCreditos, mc_Status, mc_Login, " +
                        "mc_Compania, mc_LoginUpd, mc_FechaUltMod,mc_HoraGuardado,mc_FechaCierre) VALUES ('$2', '$3', '$4', $5, '$6', '$7','$8', $9, '$login', '$compania'," +
                        "'$ultimoLog','$ultimaFecha','$horaGuardado','$fechaCerrado');";

            sentencia = sentencia.Replace("$2", this.nroComprobanteCorrelativo);
            sentencia = sentencia.Replace("$3", this.fechaComprobante);
            sentencia = sentencia.Replace("$4", this.fechaCarga);
            sentencia = sentencia.Replace("$5", this.idOrigen.ToString());
            sentencia = sentencia.Replace("$6", this.descripcion);
            sentencia = sentencia.Replace("$7", this.montoDebito);
            sentencia = sentencia.Replace("$8", this.MontoCredito);
            sentencia = sentencia.Replace("$9", this.status.ToString());
            sentencia = sentencia.Replace("$login", login);
            sentencia = sentencia.Replace("$compania", compania);
            sentencia = sentencia.Replace("$ultimoLog", this.ultimoLogin);
            sentencia = sentencia.Replace("$ultimaFecha", this.ultimaFecha);
            sentencia = sentencia.Replace("$horaGuardado", DateTime.Now.ToString("hh:mm:ss"));
            sentencia = sentencia.Replace("$fechaCerrado", "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            database.ejecutarInsert(sentencia);
        }




        public void agregarCabecera(string login, string compania, string idBaseDatos)
        {
            database.conectionStringSysconta(idBaseDatos);
            agregarCabecera(login, compania);
        }

        public DataTable lbxComprobante(string idDataBase) {
            DataTable ordenada = new DataTable();
            MySqlDataReader dr;
            database.conectionStringSysconta(idDataBase);
            ordenada.Columns.Add("mc_nroComprobante");
            ordenada.Columns.Add("mc_FechaComprobante");
            ordenada.Columns.Add("mc_Descripcion");
            ordenada.Columns.Add("mc_MontoDebitos");
            ordenada.Columns.Add("mc_MontoCreditos");
            ordenada.Columns.Add("mc_Status");

            sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante,mc_Descripcion, mc_MontoDebitos," +
                        " mc_MontoCreditos,mc_Status" +
                        " FROM admmovimientoscontablesc_temp ORDER BY mc_nroComprobante DESC LIMIT 15;";
            
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    DataRow nuevaLinea = ordenada.NewRow();
                    nuevaLinea["mc_nroComprobante"] = dr.GetString(0);
                    nuevaLinea["mc_FechaComprobante"] = dr.GetString(1);
                    nuevaLinea["mc_Descripcion"] = dr.GetString(2);
                    nuevaLinea["mc_MontoDebitos"] = dr.GetDouble(3);
                    nuevaLinea["mc_MontoCreditos"] = dr.GetDouble(4);
                    if (dr.GetBoolean(5) == true)
                    {
                        nuevaLinea["mc_Status"] = "Procesado";
                    }
                    else {
                        nuevaLinea["mc_Status"] = "En Carga";
                    }
                    ordenada.Rows.Add(nuevaLinea);
                }
            }
            //DATE_FORMAT(fecha, '%d/%m/%Y %H:%i:%s')

            sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante ,mc_Descripcion, mc_MontoDebitos," +
                        " mc_MontoCreditos,mc_Status" +
                        " FROM admmovimientoscontablesc ORDER BY mc_nroComprobante DESC LIMIT 15;";
            
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow nuevaLinea = ordenada.NewRow();
                    nuevaLinea["mc_nroComprobante"] = dr.GetString(0);
                    nuevaLinea["mc_FechaComprobante"] = dr.GetString(1);
                    nuevaLinea["mc_Descripcion"] = dr.GetString(2);
                    nuevaLinea["mc_MontoDebitos"] = dr.GetDouble(3);
                    nuevaLinea["mc_MontoCreditos"] = dr.GetDouble(4);
                    if (dr.GetInt16(5) == 0) {
                        nuevaLinea["mc_Status"] = "En Carga";
                    }
                    if (dr.GetInt16(5) == 1)
                    {
                        nuevaLinea["mc_Status"] = "Procesado";
                    }
                    if (dr.GetInt16(5) == 2)
                    {
                        nuevaLinea["mc_Status"] = "Revision";
                    }
                    ordenada.Rows.Add(nuevaLinea);
                }
            }
            dr.Close();
            dr.Dispose();
            database.cerrarConexion();
            return ordenada;

        }


        public DataTable lbxBuscarComprobante(string idDataBase, string codigo)
        {
            DataTable ordenada = new DataTable();
            MySqlDataReader dr;
            database.conectionStringSysconta(idDataBase);
            ordenada.Columns.Add("mc_nroComprobante");
            ordenada.Columns.Add("mc_FechaComprobante");
            ordenada.Columns.Add("mc_Descripcion");
            ordenada.Columns.Add("mc_MontoDebitos");
            ordenada.Columns.Add("mc_MontoCreditos");
            ordenada.Columns.Add("mc_Status");

            sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante,mc_Descripcion, mc_MontoDebitos," +
                       " mc_MontoCreditos,mc_Status" +
                       " FROM admmovimientoscontablesc_temp WHERE mc_nroComprobante LIKE '%$1%' ORDER BY mc_nroComprobante DESC LIMIT 15;";
            sentencia = sentencia.Replace("$1", codigo);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow nuevaLinea = ordenada.NewRow();
                    nuevaLinea["mc_nroComprobante"] = dr.GetString(0);
                    nuevaLinea["mc_FechaComprobante"] = dr.GetString(1);
                    nuevaLinea["mc_Descripcion"] = dr.GetString(2);
                    nuevaLinea["mc_MontoDebitos"] = dr.GetDouble(3);
                    nuevaLinea["mc_MontoCreditos"] = dr.GetDouble(4);
                    
                    if (dr.GetInt16(5) == 1)
                    {
                        nuevaLinea["mc_Status"] = "Procesado";
                    }
                    if (dr.GetInt16(5) == 0)
                    {
                        nuevaLinea["mc_Status"] = "En Carga";
                    }
                    if (dr.GetInt16(5) == 2)
                    {
                        nuevaLinea["mc_Status"] = "Revision";
                    }


                    ordenada.Rows.Add(nuevaLinea);
                }
            }

                sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante ,mc_Descripcion, mc_MontoDebitos," +
                        " mc_MontoCreditos,mc_Status" +
                        " FROM admmovimientoscontablesc WHERE mc_nroComprobante LIKE '%$1%'  ORDER BY mc_nroComprobante DESC LIMIT 15;";
                sentencia = sentencia.Replace("$1", codigo);
               
                dr = database.ejecutarQueryDr(sentencia);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataRow nuevaLinea = ordenada.NewRow();
                        nuevaLinea["mc_nroComprobante"] = dr.GetString(0);
                        nuevaLinea["mc_FechaComprobante"] = dr.GetString(1);
                        nuevaLinea["mc_Descripcion"] = dr.GetString(2);
                        nuevaLinea["mc_MontoDebitos"] = dr.GetDouble(3);
                        nuevaLinea["mc_MontoCreditos"] = dr.GetDouble(4);
                        if (dr.GetInt16(5) == 1)
                        {
                            nuevaLinea["mc_Status"] = "Procesado";
                        }
                        if (dr.GetInt16(5) == 0)
                        {
                            nuevaLinea["mc_Status"] = "En Carga";
                        }
                        if (dr.GetInt16(5) == 2)
                        {
                            nuevaLinea["mc_Status"] = "Revision";
                        }
                        ordenada.Rows.Add(nuevaLinea);
                    }
                }
                dr.Close();
                database.cerrarConexion();
                return ordenada;
            }
 


        public void cargarCabecera(string idBaseDatos) {
            DateTime fecha;
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT mc_nroComprobante, mc_FechaComprobante,mc_FechaCarga,mc_Descripcion,mc_MontoDebitos, "+
                        "mc_MontoCreditos, mc_LoginUpd, mc_FechaUltMod,mc_Compania FROM admmovimientoscontablesc_temp WHERE mc_nroComprobante ='$1';";
            sentencia = sentencia.Replace("$1", this.nroComprobanteCorrelativo);
            dr = database.ejecutarQueryDr(sentencia);

            //si tiene filas
            if (dr.HasRows) {
                dr.Read();
                
                this.nroComprobanteCorrelativo = dr.GetString(0);
                fecha = dr.GetDateTime(1);                
                this.fechaComprobante = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;                
                fecha = dr.GetDateTime(2);
                this.fechaCarga = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                this.descripcion = dr.GetString(3);
                this.montoDebito = Convert.ToString(dr.GetDecimal(4));
                this.montoCredito = Convert.ToString(dr.GetDecimal(5));
                this.ultimoLogin = dr.GetString(6);
                fecha = dr.GetDateTime(7);
                this.ultimaFecha = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                this.compania1 = dr.GetString(8);
            }

            dr.Close();
            database.cerrarConexion();
        }

        public void cargarCabecera(string idBaseDatos, int tabla)
        {
            //tabla = 1 para temporales
            //tabla = 2 para definivito
            DateTime fecha;
            //esto es para la diferentes sucursales
            database.conectionStringSysconta(idBaseDatos);

            sentencia = "SELECT mc_nroComprobante, mc_FechaComprobante,mc_FechaCarga,mc_Descripcion,mc_MontoDebitos, " +
                        "mc_MontoCreditos, mc_LoginUpd, mc_FechaUltMod,mc_Compania FROM $tabla WHERE mc_nroComprobante ='$1';";
            //admmovimientoscontablesc_temp
            if (tabla == 1) {
                sentencia = sentencia.Replace("$tabla", "admmovimientoscontablesc_temp");
            }
            if (tabla == 2) {
                sentencia = sentencia.Replace("$tabla", "admmovimientoscontablesc");
            }

            sentencia = sentencia.Replace("$1", this.nroComprobanteCorrelativo);
            
            dr = database.ejecutarQueryDr(sentencia);

            //si tiene filas
            if (dr.HasRows)
            {
                dr.Read();

                this.nroComprobanteCorrelativo = dr.GetString(0);
                fecha = dr.GetDateTime(1);
                this.fechaComprobante = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                fecha = dr.GetDateTime(2);
                this.fechaCarga = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                this.descripcion = dr.GetString(3);
                this.montoDebito = Convert.ToString(dr.GetDecimal(4));
                this.montoCredito = Convert.ToString(dr.GetDecimal(5));
                this.ultimoLogin = dr.GetString(6);
                fecha = dr.GetDateTime(7);
                this.ultimaFecha = "" + fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                this.compania1 = dr.GetString(8);
            }
            //se deja la base de datos original por defecto
            this.database.modificarConexionString(3);
            dr.Close();
            database.cerrarConexion();
        }



        //primera version
        public bool actualizarCabeceraTemporal(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "UPDATE admmovimientoscontablesc_temp SET mc_Descripcion='$1', mc_FechaComprobante='$2', " +
                        "mc_MontoDebitos=$3, mc_MontoCreditos=$4,  mc_LoginUpd='$5', mc_FechaUltMod='$6' WHERE mc_nroComprobante='$7';";
            
            sentencia = sentencia.Replace("$1", this.descripcion);
            sentencia = sentencia.Replace("$2", this.fechaComprobante);
            sentencia = sentencia.Replace("$3", this.montoDebito);
            sentencia = sentencia.Replace("$4", this.MontoCredito);
            sentencia = sentencia.Replace("$5", this.ultimoLogin);
            sentencia = sentencia.Replace("$6", this.ultimaFecha);
            sentencia = sentencia.Replace("$7", this.nroComprobanteCorrelativo);
            return database.ejecutarInsert(sentencia);
            
        }

        public bool actualizarCabecera(string idBaseDatos)
        {
            bool centinela = false;
            database.conectionStringSysconta(idBaseDatos);            
            sentencia = "UPDATE admmovimientoscontablesc SET mc_Descripcion='$1', mc_FechaComprobante='$2', " +
                        "mc_MontoDebitos=$3, mc_MontoCreditos=$4,  mc_LoginUpd='$5', mc_FechaUltMod='$6', mc_Status=$8 WHERE mc_nroComprobante='$7';";

            sentencia = sentencia.Replace("$1", this.descripcion);
            sentencia = sentencia.Replace("$2", this.fechaComprobante);
            sentencia = sentencia.Replace("$3", this.montoDebito);
            sentencia = sentencia.Replace("$4", this.MontoCredito);
            sentencia = sentencia.Replace("$5", this.ultimoLogin);
            sentencia = sentencia.Replace("$6", this.ultimaFecha);
            sentencia = sentencia.Replace("$7", this.nroComprobanteCorrelativo);
            sentencia = sentencia.Replace("$8", ""+this.status);

            centinela = database.ejecutarInsert(sentencia);
            return centinela;
        }


        public void asignarCorrelativoFinal(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT pc_CorrCompAut FROM admparametroscontables WHERE pc_idSistema = '08';";
            ds = database.ejecutarQueryDs(sentencia);
            if (ds.Tables[0].Rows.Count != 0)
            {
                this.nroComprobanteCorrelativo = String.Format("{0:0000000000}", Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString()) + 1);
                sentencia = "UPDATE admparametroscontables SET pc_CorrCompAut='$1' WHERE pc_idSistema = '08';";
                sentencia = sentencia.Replace("$1", this.nroComprobanteCorrelativo);
                database.ejecutarInsert(sentencia);
            }

        }

        public void borrarCabeceraTemp(string codigo,string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            if (existeTemporal(codigo, idBaseDatos))
            {
                sentencia = "DELETE FROM admmovimientoscontablesc_temp WHERE mc_nroComprobante='$1';";
                sentencia = sentencia.Replace("$1", codigo);
                database.ejecutarInsert(sentencia);
            }
        }



        public bool existeTemporal(string codigo, string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            bool centinela = true;
            MySqlDataReader dr;
            sentencia = "SELECT COUNT(*) FROM admmovimientoscontablesc_temp WHERE mc_nroComprobante='$1';";
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

        public bool comprobanteDescuadre(string idBaseDatos) {
            database.conectionStringSysconta(idBaseDatos);
            //centinela  = true pueden cerrar descuadrado
            // centinela = false no pueden cerrar descuadrado
            bool centinela = false;
            MySqlDataReader dr;
            sentencia = "SELECT pc_FlagDescuadre FROM admparametroscontables WHERE pc_idSistema='08';";
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    if (dr.GetBoolean(0) == false)
                    {
                        dr.Close();
                        centinela = true;
                        return centinela;
                    }
                }
            }
            dr.Close();
            database.cerrarConexion();
            return centinela;

        }

        public bool estaDescuadrado(string codigo) {
            bool centinela = true;
            double credito = 0;
            double debito = 0;

            MySqlDataReader dr;
            sentencia = "SELECT mc_MontoDebitos, mc_MontoCreditos FROM admmovimientoscontablesc_temp WHERE mc_nroComprobante='$1';";
            sentencia = sentencia.Replace("$1", codigo);
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    debito = dr.GetDouble(0);
                    credito = dr.GetDouble(1);
                }
            }

            if (debito == credito) {
                centinela = false;
            }
            dr.Close();
            database.cerrarConexion();
            return centinela;
        }

        public int validarFechaCierre(DateTime fecha,string idBaseDatos) {
            /*
             * resultado =0 para decir que esta bien
             * resultado = 1 para decir que la fecha mensual es mayor a la que 
             * estan comparando
             * resultado = 2 para decir que es menor que la anual 
            */
            int resultado = 0;
            database.conectionStringSysconta(idBaseDatos);
            DateTime cierreMensual= DateTime.Now;
            DateTime cierreAnual = DateTime.Now;
            MySqlDataReader dr;
            sentencia = "SELECT pc_FechaUltCiem,pc_FechaUltCieA FROM admparametroscontables WHERE pc_idSistema='08';";

            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    cierreMensual = dr.GetDateTime(0);
                    cierreAnual = dr.GetDateTime(1);
                }
            }
            dr.Close();
            database.cerrarConexion();
            if (fecha > cierreMensual)
            {
                if (fecha > cierreAnual)
                {
                    return resultado;
                }
                else {
                    resultado = 2;
                }
            }
            else {
                resultado = 1;
            }
            return resultado;
        }

        public bool validarContrasena(string contrasena,string idDataBase) {
            bool centinela = false;
            string temporal = null;
            database.conectionStringSysconta(idDataBase);
            sentencia = "SELECT pc_ClaveComprob FROM admparametroscontables WHERE pc_idSistema='08'";
            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows) { 
                while(dr.Read()){
                    temporal = dr.GetString(0);
                }
            }

            if (contrasena.Equals(temporal)) {
                centinela = true;
            }
            dr.Close();
            database.cerrarConexion();
            return centinela;
        
        }

        public DataTable buscarComprobantesStatus(string idDataBase,int statusC) {
            DataTable ordenada = new DataTable();
            MySqlDataReader dr;
            sentencia = "";
            if (statusC == 0)
            {
                sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante,mc_Descripcion, mc_MontoDebitos," +
                    " mc_MontoCreditos,mc_Status" +
                    " FROM admmovimientoscontablesc_temp WHERE mc_Status =$2 ORDER BY mc_nroComprobante DESC;";
            }
            else {
                sentencia = "SELECT mc_nroComprobante,DATE_FORMAT(mc_FechaComprobante, '%d/%m/%Y') as mc_FechaComprobante,mc_Descripcion, mc_MontoDebitos," +
                    " mc_MontoCreditos,mc_Status" +
                    " FROM admmovimientoscontablesc WHERE mc_Status =$2 ORDER BY mc_nroComprobante DESC;";
            }
            sentencia = sentencia.Replace("$2", ""+ statusC);
            
            
            database.conectionStringSysconta(idDataBase);
            ordenada.Columns.Add("mc_nroComprobante");
            ordenada.Columns.Add("mc_FechaComprobante");
            ordenada.Columns.Add("mc_Descripcion");
            ordenada.Columns.Add("mc_MontoDebitos");
            ordenada.Columns.Add("mc_MontoCreditos");
            ordenada.Columns.Add("mc_Status");
          

            dr = database.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow nuevaLinea = ordenada.NewRow();
                    nuevaLinea["mc_nroComprobante"] = dr.GetString(0);
                    nuevaLinea["mc_FechaComprobante"] = dr.GetString(1);
                    nuevaLinea["mc_Descripcion"] = dr.GetString(2);
                    nuevaLinea["mc_MontoDebitos"] = dr.GetDouble(3);
                    nuevaLinea["mc_MontoCreditos"] = dr.GetDouble(4);

                    if (dr.GetInt16(5) == 1)
                    {
                        nuevaLinea["mc_Status"] = "Procesado";
                    }
                    if (dr.GetInt16(5) == 0)
                    {
                        nuevaLinea["mc_Status"] = "En Carga";
                    }
                    if (dr.GetInt16(5) == 2)
                    {
                        nuevaLinea["mc_Status"] = "Revision";
                    }


                    ordenada.Rows.Add(nuevaLinea);
                }
            }
            dr.Close();
            database.cerrarConexion();
            return ordenada;
        }

        public string cuentaSupAviCie(string idBaseDatos) {
            DataTable resultado;
            string cuenta = null;
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "";
            sentencia = "SELECT pc_CtaSupAvitCie FROM admparametroscontables WHERE pc_idSistema ='08';";
            resultado = database.fDataTable(sentencia);

            if (resultado.Rows.Count > 0) {
                cuenta = resultado.Rows[0]["pc_CtaSupAvitCie"].ToString();
            }
            database.cerrarConexion();
            return cuenta;
        }

        public string fechaInicioCierre(string idBaseDatos) {
            DataTable resultado;
            string fecha = null;
            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT DATE_FORMAT(pc_FechaUltCieA, '%Y-%m-%d') as pc_FechaUltCieA FROM admparametroscontables WHERE pc_idSistema ='08';";
            resultado = database.fDataTable(sentencia);

            if (resultado.Rows.Count > 0) {
                fecha = resultado.Rows[0]["pc_FechaUltCieA"].ToString();
            }
            database.cerrarConexion();
            return fecha;
        }

        public string cuentaAnalitico(string idBaseDatos) {
            DataTable resultado;
            string cuenta = null;
            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT pc_CtaContablng2 FROM admparametroscontables WHERE pc_idSistema='08';";
            resultado = database.fDataTable(sentencia);
            if (resultado.Rows.Count > 0) {
                cuenta = resultado.Rows[0]["pc_CtaContablng2"].ToString();
            }
            return cuenta;
        }

        public string statusCierreContable(string idBaseDatos) {
            DataTable resultado;
            string cierreStatus = null;

            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT pc_StatusCierre FROM admparametroscontables WHERE pc_idSistema='08';";
            resultado = database.fDataTable(sentencia);
            if (resultado.Rows.Count > 0) {
                cierreStatus = resultado.Rows[0]["pc_StatusCierre"].ToString();
            }
            database.cerrarConexion();
            return cierreStatus;
        }

        public bool updateStatusCierreContable(string idBaseDatos, string valor) {
            bool bandera = false;
            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "UPDATE admparametroscontables SET pc_StatusCierre ='$1' WHERE pc_idSistema='08';";
            sentencia = sentencia.Replace("$1", valor);
            bandera= database.ejecutarInsert(sentencia);
            database.cerrarConexion();
            return bandera;
        }

        public void borrarTemporalBalanceCierre(string idBaseDatos) {
            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "DELETE FROM temporalbalancecomprobacion;";
            database.ejecutarInsert(sentencia);
            database.cerrarConexion();
        }

        public void updateUltCierreAnual(string idBaseDatos, string fecha) {
            sentencia = "";
            database.conectionStringSysconta(idBaseDatos);
            sentencia = "UPDATE admparametroscontables SET pc_FechaUltCieA= '$1' WHERE pc_idSistema='08';";
            sentencia = sentencia.Replace("$1", fecha);
            database.ejecutarInsert(sentencia);
            database.cerrarConexion();
        }


        
        public bool existeComprobantesRevision(string idBaseDatos, string fechaDesdeC, string fechaHastaC) {
            bool bandera = false;
            DataTable dtTemp;
            sentencia = "";

            database.conectionStringSysconta(idBaseDatos);
            sentencia = "SELECT admcuentascontables.cc_CodigoCuenta,admcuentascontables.cc_Descripcion,  " +
                                "admcuentascontables.cc_NivelTotal,  " +
                                "IF(admmovimientoscontabled.mcd_CodigoMayor IS NULL, '',admmovimientoscontabled.mcd_CodigoMayor) as mcd_CodigoMayor,  " +
                                "SUM(IF(admmovimientoscontabled.mdc_TipoTransaccion = 'D',admmovimientoscontabled.mdc_monto,0)) as  sumaDebito,  " +
                                "SUM(IF(admmovimientoscontabled.mdc_TipoTransaccion = 'C',admmovimientoscontabled.mdc_monto,0)) as  sumaCredito,  " +
                                "admmovimientoscontablesc.mc_Status " +
                                "From admcuentascontables " +
                                "LEFT OUTER JOIN admmovimientoscontabled  " +
                                "ON admcuentascontables.cc_CodigoCuenta = admmovimientoscontabled.mcd_CodigoMayor  " +
                                "and admmovimientoscontabled.mdc_FechaComprobante >= '$1' AND admmovimientoscontabled.mdc_FechaComprobante <= '$2'  " +
                                "LEFT OUTER JOIN admmovimientoscontablesc  " +
                                "ON admmovimientoscontablesc.mc_nroComprobante = admmovimientoscontabled.mcd_NroComprobante  " +
                                "Where admmovimientoscontablesc.mc_Status = 2  " +
                                "GROUP BY admcuentascontables.cc_CodigoCuenta, mcd_CodigoMayor limit 1  ";

            sentencia = sentencia.Replace("$1", fechaDesdeC);
            sentencia = sentencia.Replace("$2", fechaHastaC);

            dtTemp = database.fDataTable(sentencia);

            if (dtTemp.Rows.Count > 0) {
                if (dtTemp.Rows[0]["cc_CodigoCuenta"].ToString() != "") {
                    bandera = true;
                }
            }
            database.cerrarConexion();
            return bandera;
        }

        public void borrarTablas(string idBaseDatos,string fechaHasta,string codigoCompania)
        {
            sentencia = "";
            DateTime fechaTemp;
            string fechaulCie=null;

            fechaTemp = Convert.ToDateTime(this.fechaInicioCierre(codigoCompania));
            database.conectionStringSysconta(idBaseDatos);
            fechaTemp.AddDays(1);
            fechaulCie = "" + fechaTemp.Year + "-" + fechaTemp.Month + "-" + fechaTemp.Day + "";

            sentencia = "DELETE FROM admmovimientoscontablesc WHERE mc_FechaComprobante BETWEEN '" + fechaulCie+"' AND '"+fechaHasta+"';";
            database.ejecutarInsert(sentencia);
            sentencia = "DELETE FROM admmovimientoscontabled WHERE mdc_FechaComprobante BETWEEN '" + fechaulCie + "' AND '" + fechaHasta + "';";
            database.ejecutarInsert(sentencia);
        }

    }
}