using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using MySql.Data.MySqlClient;

namespace lebrun.clases.vendedores
{
    public class Vendedor
    {
        private string nombre;
        private string cedula;
        private string cargo;
        private string status;
        private string codigoV;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string CodigoV
        {
            get { return codigoV; }
            set { codigoV = value; }
        }

        private string sentenciaSql;
        private ConexionBD dataBaseConection;

        public Vendedor() {
            this.dataBaseConection = new ConexionBD();
        }

        public Vendedor(string timeOut)
        {
            this.dataBaseConection = new ConexionBD(timeOut);
        }

        public DataTable dataLbxVendedores() {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_codigo,ven_nombre,ven_cedula,ven_cargo,ven_status FROM admvendedor WHERE ven_lbxven = TRUE limit 35;";
            dt= dataBaseConection.fDataTable(sentenciaSql,200);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public DataTable vendedorBuscado(string vendedorBuscar)
        {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_codigo,ven_nombre,ven_cedula,ven_cargo,ven_status FROM  admvendedor WHERE " +
                                "ven_codigo LIKE '%$1%' OR ven_nombre LIKE '%$1%';";
            sentenciaSql = sentenciaSql.Replace("$1", vendedorBuscar);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            dataBaseConection.cerrarConexion();
            return dt;
        }

        public string getNombreVen(string idVendedor) {
            DataTable dt;
            string nombreVen = null;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_nombre FROM admvendedor WHERE ven_codigo='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", idVendedor);

            dt = dataBaseConection.fDataTable(sentenciaSql);
            if(dt.Rows.Count>0){
                nombreVen = dt.Rows[0]["ven_nombre"].ToString();
            }
            dataBaseConection.cerrarConexion();
            return nombreVen;
        }
        
        public void cargarDatosVendedor() {
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_codigo, ven_nombre, ven_status FROM admvendedor WHERE ven_codigo='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", this.codigoV);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                this.codigoV = dt.Rows[0]["ven_codigo"].ToString();
                this.nombre = dt.Rows[0]["ven_nombre"].ToString();
                this.status = dt.Rows[0]["ven_status"].ToString();
            }
            dataBaseConection.cerrarConexion();
        }

        public bool existeVendedor(string codigoVendedor) {
            DataTable dt;
            bool centinela = false;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_nombre FROM admvendedor WHERE ven_codigo='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", codigoVendedor);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ven_nombre"].ToString() != "") {
                    centinela = true;
                }
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public bool estaActivo(string codigoVendedor) {
            bool centinela = false;
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_status FROM admvendedor WHERE ven_codigo='$1';";
            sentenciaSql = sentenciaSql.Replace("$1", codigoVendedor);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ven_status"].ToString().Equals("Activo")) {
                    centinela = true;
                }
            }
            dataBaseConection.cerrarConexion();
            return centinela;
        }

        public string nombreVende(string id)
        {
            string nombre = null;
            DataTable dt;
            sentenciaSql = null;
            sentenciaSql = "SELECT ven_nombre FROM admvendedor WHERE ven_codigo='@ven_codigo';";
            sentenciaSql = sentenciaSql.Replace("@ven_codigo", id);
            dt = dataBaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                nombre = dt.Rows[0]["ven_nombre"].ToString();
            }
            dataBaseConection.cerrarConexion();
            return nombre;
        }

    }

  
}

