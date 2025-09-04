using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;
using MySql.Data.MySqlClient;

namespace lebrun.clases.complementos
{
    class RetencionISLR
    {

        private string StrSql;
        private ConexionBD database;
        private DataTable tarifasRetencion;
        //private string porcentajeBase;
        //private string porcentajeRetencion;
        //private string sustraendo;

        public RetencionISLR() 
        {
            database = new ConexionBD();
        }

        public DataTable armarRegistros(){

            StrSql = "SELECT tar_codconcep,tar_descripcion,tar_tipper,tar_reside,tar_porcenbase,tar_porcenreten,tar_sustraendo FROM admtarifasreten";
            tarifasRetencion = database.fDataTable(StrSql);
            database.cerrarConexion();
            return tarifasRetencion;
            
        }

        public DataTable armarRegistros(string tipoPersona, string residente)
        {

            StrSql = "SELECT tar_codconcep,tar_descripcion,tar_tipper,tar_reside,tar_porcenbase,tar_porcenreten,tar_sustraendo FROM admtarifasreten";
            tarifasRetencion = database.fDataTable(StrSql);
            database.cerrarConexion();
            return tarifasRetencion;

        }

        public DataTable armarRegistrosOpcion(string rifprofac, string codproFac, string opcion)
        {
            //string letra;

            //if (tipoPersona == "Juridica")
            //{
            //    letra = "J";
            //}
            //if (pro_tipoper == "Natural")
            //{
            //    letra = "N";
            //}
            //if (pro_tipoper == "Gubernamental")
            //{
            //    letra = "N";
            //}

            StrSql = "SELECT tar_codconcep,tar_descripcion,tar_conceptoXml,tar_numeral, " +
                     "tar_tipper,tar_reside,tar_acumm,tar_porcenbase,tar_porcenreten, " +
                     "tar_undtrid,tar_monmin,tar_unitrimin,tar_sustraendo,tar_tarifa  FROM  admtarifasreten " +
                     "LEFT OUTER JOIN admproveedor ON tar_tipper=(SELECT mid(pro_tipoper,1,1)  FROM admproveedor " +
                     "WHERE pro_rif='$rif' AND pro_codigo = '$codigo') AND tar_reside=pro_reside " +
                     "WHERE pro_rif='$rif' AND pro_codigo = '$codigo'";

            StrSql = StrSql.Replace("$rif", rifprofac);
            StrSql = StrSql.Replace("$codigo", codproFac);
            //StrSql = StrSql.Replace("$letra", letra);

            tarifasRetencion = database.fDataTable(StrSql);
            database.cerrarConexion();
            return tarifasRetencion;

        }

        
    }
}
