using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;

namespace lebrun.clases.clientes
{
    public class CondicionPago
    {
        public string conp_codigo { get; set; }
        public string conp_descripcion { get; set; }
        public decimal conp_cant_dias { get; set; }
        public string conp_observ { get; set; }
        public string conp_status { get; set; }
        public int mora_fact1 { get; set; }
        private string sentenciaSql;
        private ConexionBD sisadm;

        public CondicionPago()
        {
            sisadm = new ConexionBD();
            sentenciaSql = null;
        }

        public DataTable lbxCondPag()
        {
            DataTable dt = null;
            sentenciaSql = "select conp_codigo,conp_descripcion, conp_cant_dias from admcondpago;";
            dt = sisadm.fDataTable(sentenciaSql);
            sisadm.cerrarConexion();
            return dt;
        }
    }
}
