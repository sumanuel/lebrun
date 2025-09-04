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
    class TipoDocumentoProveedor
    {
        private ConexionBD database;
        private string StrSql;
        private string cuentaContable;
        private string auxiliarContable;
        private DataTable tabla;

        public string CuentaContable

        {
            get { return cuentaContable; }
            set { cuentaContable = value; }
        }

        public string AuxiliarContable
        {
            get { return auxiliarContable; }
            set { auxiliarContable = value; }
        }

        public TipoDocumentoProveedor() {

            database = new ConexionBD();
            tabla = new DataTable();
        }

        public DataTable buscarDocumentos(int opcion, string value)
        {
            if (opcion == 1)
            {
                StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE tdc_codigo='$1' AND tdc_codigo<>''";
                StrSql = StrSql.Replace("$1",value);

                StrSql = StrSql.Replace("$1", value);
                database.fDataTable(StrSql);

            }
            if (opcion == 2)
            {
                StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE tdc_descri LIKE '%$1%' AND tdc_codigo<>''";       
                StrSql = StrSql.Replace("$1", value);
                database.fDataTable(StrSql);
            }
            return database.fDataTable(StrSql);
        }

        public DataTable cargarDocumentos() 
        {
            //StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE  tdc_codigo<>''";
            StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE  tdc_codigo='36' OR tdc_codigo='58' OR tdc_codigo='57' OR tdc_codigo='56' OR tdc_codigo='59' OR tdc_codigo='55'";
            return database.fDataTable(StrSql);
        }

       public DataTable consultarDocumento(string value) 
       {
           StrSql = "SELECT tdc_codigo,tdc_tipo,tdc_descri FROM admtipdocpro WHERE tdc_codigo='$1'";
            StrSql = StrSql.Replace("$1",value);
            return database.fDataTable(StrSql);
       }

       public DataTable cargarTodosDocumentos()
       {
           //StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE  tdc_codigo<>''";
           StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE tdc_estatus='1' AND tdc_codigo<>'' ORDER BY tdc_tipo";
           return database.fDataTable(StrSql);
       }

       public DataTable cargarTodosDocumentosServicios()
       {
           //StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE  tdc_codigo<>''";
           StrSql = "SELECT tdc_codigo AS Codigo,tdc_tipo AS Tipo,tdc_descri AS Descripcion,tdc_correlativo AS Correlativo,tdc_codcta AS Cuenta,tdc_reporte AS Cuenta2 FROM admtipdocpro WHERE tdc_estatus='1' AND tdc_codigo<>'' AND tdc_cxp='1' ORDER BY tdc_tipo";
           return database.fDataTable(StrSql);
       }

       public bool consultarDocProcePago(string value)
       {
           StrSql = "SELECT tdc_codigo,tdc_tipo FROM admtipdocpro  " +
                    " WHERE tdc_codigo='$1' AND tdc_correlativo<>0 AND tdc_estatus=1 AND tdc_libcom=0 AND tdc_cxp=1 AND tdc_pagos=1";

           StrSql = StrSql.Replace("$1", value);
           tabla = database.fDataTable(StrSql);

           if (tabla.Rows.Count > 0)
           {
               return true;
           }
           return false;
       }

       public bool consultarDocProcePago2(string tipo, string proveedor)
       {
           StrSql = "SELECT n_cuenta,n_auxiliar FROM admtipdocpro2 " +
           " WHERE n_tipo='$1' AND n_proveedor ='$2'";

           StrSql = StrSql.Replace("$1", tipo);
           StrSql = StrSql.Replace("$2", proveedor);

           tabla = database.fDataTable(StrSql);

           if (tabla.Rows.Count > 0)
           {
               return true;
           }
           return false;
       }













    }
}
