using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;

namespace lebrun.clases.clientes
{
    public class TipoNegocio
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal descuento1 { get; set; }
        public decimal descuento2 { get; set; }
        public decimal descuento3 { get; set; }
        public int primeraLeyendaDias { get; set; }
        public int segundaLeyendaDias { get; set; }
        public int activo { get; set; }
        public string observaciones { get; set; }
        public decimal pocentajePrimeraLeyenda { get; set; }
        public decimal porcentajeSegundaLeyenda { get; set; }

        private ConexionBD databaseSisadm;
        string sentenciasql;
        

        public TipoNegocio()
        {
            databaseSisadm = new ConexionBD();
            sentenciasql = null;
        }

        public DataTable  lbxTipoNegocio()
        {
            DataTable dt = null;
            sentenciasql = null;
            sentenciasql = "SELECT * FROM admtiponegocio;";
            dt = databaseSisadm.fDataTable(sentenciasql);
            databaseSisadm.cerrarConexion();
            return dt;
        }

        public bool existeTipo(string codigo)
        {
            bool centinela = false;
            sentenciasql = null;
            DataTable dt = null;

            sentenciasql = "SELECT descripcion FROM admtiponegocio WHERE codigo='$codigo';";
            sentenciasql = sentenciasql.Replace("$codigo", codigo);

            dt = databaseSisadm.fDataTable(sentenciasql);
            if (dt.Rows.Count > 0)
            {
                centinela = true;
            }

            databaseSisadm.cerrarConexion();
            return centinela;
        }

        public int insertTipoNegocio(TipoNegocio tipo)
        {
            int retorno = 0;
            sentenciasql = null;
            sentenciasql = "INSERT INTO admtiponegocio (codigo,descripcion,descuento1,descuento2, " +
                            "descuento3,primeraLeyendaDias,segundaLeyendaDias,activo,observaciones, " +
                            "pocentajePrimeraLeyenda,porcentajeSegundaLeyenda) VALUES('$codigo', " +
                            "'$descripcion',$descuento1,$descuento2,$descuento3,$primeraLeyendaDias, " +
                            "$segundaLeyendaDias,$activo,'$observaciones',$pocentajePrimeraLeyenda, " +
                            "$porcentajeSegundaLeyenda);";

            sentenciasql = sentenciasql.Replace("$codigo", tipo.codigo);
            sentenciasql = sentenciasql.Replace("$descripcion", tipo.descripcion);
            sentenciasql = sentenciasql.Replace("$descuento1", (tipo.descuento1.ToString().Replace(",",".")) );
            sentenciasql = sentenciasql.Replace("$descuento2", (tipo.descuento2.ToString().Replace(",",".")));
            sentenciasql = sentenciasql.Replace("$descuento3", (tipo.descuento3.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$primeraLeyendaDias", "" + tipo.primeraLeyendaDias);
            sentenciasql = sentenciasql.Replace("$segundaLeyendaDias", "" + tipo.segundaLeyendaDias);
            sentenciasql = sentenciasql.Replace("$activo", "" + tipo.activo);
            sentenciasql = sentenciasql.Replace("$observaciones", tipo.observaciones);
            sentenciasql = sentenciasql.Replace("$pocentajePrimeraLeyenda", (tipo.pocentajePrimeraLeyenda.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$porcentajeSegundaLeyenda", (tipo.porcentajeSegundaLeyenda.ToString().Replace(",",".")));

            retorno = databaseSisadm.ejecutarInsert2(sentenciasql);

            databaseSisadm.cerrarConexion();
            return retorno; 
        }

        public void limpiar()
        {
            this.codigo = String.Empty;
            this.descripcion = String.Empty;
            this.descuento1 = 0;
            this.descuento2 = 0;
            this.descuento3 = 0;
            this.primeraLeyendaDias = 0;
            this.segundaLeyendaDias = 0;
            this.activo = 0;
            this.observaciones = String.Empty;
            this.pocentajePrimeraLeyenda = 0;
            this.porcentajeSegundaLeyenda = 0;
        }

        public int updateTipoNegocio(TipoNegocio tipo)
        {
            int estado = 0;
            sentenciasql = null;
            sentenciasql = "UPDATE  admtiponegocio SET descripcion='$descripcion', descuento1=$descuento1," +
                            "descuento2=$descuento2, descuento3=$descuento3, primeraLeyendaDias=$primeraLeyendaDias," +
                            "segundaLeyendaDias=$segundaLeyendaDias, activo= $activo, observaciones='$observaciones'," +
                            "pocentajePrimeraLeyenda=$pocentajePrimeraLeyenda, porcentajeSegundaLeyenda=$porcentajeSegundaLeyenda " +
                            "WHERE codigo='$codigo'";
            sentenciasql = sentenciasql.Replace("$descripcion", tipo.descripcion);
            sentenciasql = sentenciasql.Replace("$descuento1", (tipo.descuento1.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$descuento2", (tipo.descuento2.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$descuento3", (tipo.descuento3.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$primeraLeyendaDias", "" + tipo.primeraLeyendaDias);
            sentenciasql = sentenciasql.Replace("$segundaLeyendaDias", "" + tipo.segundaLeyendaDias);
            sentenciasql = sentenciasql.Replace("$activo", "" + tipo.activo);
            sentenciasql = sentenciasql.Replace("$observaciones", tipo.observaciones);
            sentenciasql = sentenciasql.Replace("$pocentajePrimeraLeyenda", (tipo.pocentajePrimeraLeyenda.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$porcentajeSegundaLeyenda", (tipo.porcentajeSegundaLeyenda.ToString().Replace(",", ".")));
            sentenciasql = sentenciasql.Replace("$codigo", tipo.codigo);

            estado = databaseSisadm.ejecutarInsert2(sentenciasql);
            databaseSisadm.cerrarConexion();

            return estado;
        }

        public DataTable comboTipoNegocio()
        {
            DataTable dt = null;
            sentenciasql = null;

            sentenciasql = "SELECT codigo,descripcion FROM admtiponegocio  order by codigo asc;";
            dt = databaseSisadm.fDataTable(sentenciasql);
            databaseSisadm.cerrarConexion();
            return dt;
        }

    }
}
