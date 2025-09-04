using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;

namespace lebrun.clases.complementos
{
    class trabajador
    {
        private ConexionBD database;
        private string StrSql;
        private DataTable tabla;

        public trabajador() {

            database = new ConexionBD();

        }
        //http://picasion.com

        public DataTable cargarTrabajadoresLBX()
        {
            StrSql = "SELECT tra_rif AS Codigo, tra_nombre AS Nombre,tra_rif AS Rif FROM admtrabajador2";
            tabla = database.fDataTable(StrSql);
            database.cerrarConexion();
            return tabla;
            

        }

        public DataTable buscarTrabajador(string nombre) 
        {
            StrSql = "SELECT tra_rif AS Codigo, tra_nombre AS Nombre,tra_rif AS Rif FROM admtrabajador2 WHERE tra_nombre LIKE  '%$1%' ";
            StrSql = StrSql.Replace("$1",nombre);
            tabla = database.fDataTable(StrSql);
            database.cerrarConexion();
            return tabla;
        }



    }
}
