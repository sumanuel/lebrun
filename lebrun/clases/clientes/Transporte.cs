using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using MySql.Data.MySqlClient;

namespace lebrun.clases.clientes
{
    public class Transporte
    {
        private ConexionBD dataBaseConection;
        private string codigoTransporte;
        private string transporteDescripcion;
        private string transporteCodProveedor;
        private string transporteNomProveedor;
        private string transporteStatus;
        private string transporteObservaciones;
        private string sentenciaSql;

        public string CodigoTransporte
        {
            get { return codigoTransporte; }
            set { codigoTransporte = value; }
        }
        public string TransporteDescripcion
        {
            get { return transporteDescripcion; }
            set { transporteDescripcion = value; }
        }
        public string TransporteCodProveedor
        {
            get { return transporteCodProveedor; }
            set { transporteCodProveedor = value; }
        }
        public string TransporteNomProveedor
        {
            get { return transporteNomProveedor; }
            set { transporteNomProveedor = value; }
        }
        public string TransporteStatus
        {
            get { return transporteStatus; }
            set { transporteStatus = value; }
        }
        public string TransporteObservaciones
        {
            get { return transporteObservaciones; }
            set { transporteObservaciones = value; }
        }


        public Transporte() {
            dataBaseConection = new ConexionBD();
        }

        public DataTable lbxTransp() {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT trans_cod,trans_des,trans_pronom,trans_codpro FROM admtransporte LIMIT 30";
            dt = dataBaseConection.fDataTable(sentenciaSql);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public DataTable transporteBuscado() {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT trans_cod,trans_des,trans_pronom,trans_codpro FROM  admtransporte WHERE " +
                              "trans_cod LIKE '%$1%' OR trans_des LIKE '%$1%'  OR trans_codpro LIKE '%$1%';";
            sentenciaSql = sentenciaSql.Replace("$1", this.codigoTransporte);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public bool existeTransporte() {
            MySqlDataReader dr;
            bool centinela = false;
            string temp=null;

            sentenciaSql = null;
            sentenciaSql = "SELECT trans_des FROM admtransporte WHERE trans_cod='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", this.codigoTransporte);
            dr = dataBaseConection.ejecutarQueryDr(sentenciaSql);
            if (dr.HasRows) {
                while (dr.Read()) {
                    temp = dr.GetString("trans_des");
                }
            }
            if (temp != null)
            {
                centinela = true;
            }

            dr.Close();
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public bool agregarTransporte(){
            bool centinela;
            sentenciaSql = "";
            sentenciaSql = "INSERT INTO admtransporte (trans_cod, trans_des, trans_codpro,trans_est,trans_mem) " +
                                  "VALUES('$trans_cod','$trans_des','$transcodpro','$trans_est','$trans_mem');";
            sentenciaSql = sentenciaSql.Replace("$trans_cod", this.codigoTransporte);
            sentenciaSql = sentenciaSql.Replace("$trans_des", this.transporteDescripcion);
            sentenciaSql = sentenciaSql.Replace("$transcodpro", this.transporteCodProveedor);
            sentenciaSql = sentenciaSql.Replace("$trans_est", this.transporteStatus);
            sentenciaSql = sentenciaSql.Replace("$trans_mem", this.transporteObservaciones);
            centinela = dataBaseConection.ejecutarInsert(sentenciaSql);
        
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public void cargarDatosClientes() {
            MySqlDataReader dr;
            sentenciaSql = null;

            sentenciaSql = "SELECT  trans_des, trans_codpro,trans_est,trans_mem FROM admtransporte WHERE trans_cod ='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", this.codigoTransporte);
            dr = dataBaseConection.ejecutarQueryDr(sentenciaSql);
            if (dr.HasRows) {
                limpiarObjTransporte();
                while (dr.Read()) {
                    this.transporteDescripcion = dr.GetString("trans_des");
                    this.transporteCodProveedor = dr.GetString("trans_codpro");
                    this.transporteStatus =dr.GetString("trans_est");
                    this.transporteObservaciones = dr.GetString("trans_mem");
                }
            }
            dr.Close();
            dataBaseConection.cerrarConexion();
        }

        public void limpiarObjTransporte() { 
            this.transporteDescripcion = null;
            this.transporteCodProveedor=null;
            this.transporteNomProveedor=null;
            this.transporteStatus=null;
            this.transporteObservaciones=null;
        }

        public bool modificarTransporte() {
            bool centinela;
            sentenciaSql = null;
            sentenciaSql = "UPDATE admtransporte SET trans_des ='$trans_des' , trans_codpro='$trans_codpro',trans_est='$trans_est',trans_mem='$trans_mem'";
            sentenciaSql = sentenciaSql.Replace("$trans_des", this.transporteDescripcion);
            sentenciaSql = sentenciaSql.Replace("$trans_codpro", this.transporteCodProveedor);
            sentenciaSql = sentenciaSql.Replace("$trans_est", this.transporteStatus);
            sentenciaSql = sentenciaSql.Replace("$trans_mem", this.transporteObservaciones);
            centinela = dataBaseConection.ejecutarInsert(sentenciaSql);
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public string nombreTransporte(string codigoT)
        {
            string nombre = null;
            DataTable dt = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT trans_des FROM admtransporte WHERE trans_cod ='$trans_cod';";
            sentenciaSql = sentenciaSql.Replace("$trans_cod", codigoT);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                nombre = dt.Rows[0]["trans_des"].ToString();
            }
            dataBaseConection.cerrarConexion();
            return nombre;
        }

    }
}
