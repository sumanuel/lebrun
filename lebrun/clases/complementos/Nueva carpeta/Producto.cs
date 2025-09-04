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
    class Producto
    {
        //variables

        private ConexionBD database;
        private string StrSql;
        private string cadena;
        private string condicion;
        private DataSet ds;
        private DataTable tabla;


        /* atributos Roberto Fernandez  14-11-12*/
        private string editable;
        private string procedencia;
        private string iva;
        private string estado;
        private string codigoProd;
        private string descripcion;
        private decimal precio;
        private string[] unidadMedida;
        private decimal existencia;
        private decimal costoPromedio;
        private int valorUnidadPrincipal;
        private bool cenCodigoBarras;
        private bool cenPromocion;
        private decimal valorIva;
        private decimal valorPrecio;
        private string exento;
        private decimal montoBase;
        private string alicIva;
        private decimal pAlicIva;

        public decimal MONTOBASE
        {
            get { return montoBase; }
            set { montoBase = value; }
        }
        public string ALICIVA
        {
            get { return alicIva; }
            set { alicIva = value; }
        }
        public decimal PALICIVA
        {
            get { return pAlicIva; }
            set { pAlicIva = value; }
        }


        public string Editable
        {
            get { return editable; }
            set { editable = value; }
        }
        public string Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }
        public string Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string CodigoProd
        {
            get { return codigoProd; }
            set { codigoProd = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string[] UnidadMedida
        {
            get { return unidadMedida; }
            set { unidadMedida = value; }
        }
        public decimal Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }
        public decimal CostoPromedio
        {
            get { return costoPromedio; }
            set { costoPromedio = value; }
        }
        public int ValorUnidadPrincipal
        {
            get { return valorUnidadPrincipal; }
            set { valorUnidadPrincipal = value; }
        }
        public bool CenCodigoBarras
        {
            get { return cenCodigoBarras; }
            set { cenCodigoBarras = value; }
        }
        public bool CenPromocion
        {
            get { return cenPromocion; }
            set { cenPromocion = value; }
        }
        public decimal ValorIva
        {
            get { return valorIva; }
            set { valorIva = value; }
        }
        public decimal ValorPrecio
        {
            get { return valorPrecio; }
            set { valorPrecio = value; }
        }

        public string Exento
        {
            get { return exento; }
            set { exento = value; }
        }
        public decimal inv_grados { get; set; }

        public Producto()
        {
            database = new ConexionBD("200");
            cenCodigoBarras = false;
            cenPromocion = false;
            tabla = new DataTable();
        }

        //CARGAR PRODUCTOS

        public DataTable cargarProductos()
        {
            DataTable dt;
            StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
                    "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento, precio_pmvp AS PMVP, inv_proced AS Procedencia,ult_provee AS pro_principal  " +
                    "FROM  adminv " +
                    "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
                    "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
                    "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
                    "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
                    "WHERE inv_estado='Activo' AND pre_undmed=ime_undmed and Existencia >0" +
                    " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";
            dt = database.fDataTable(StrSql);
            dt = agregarOfDt(dt);
            database.cerrarConexion();
            return dt;
        }

        //public DataTable cargarProductos()
        //{
        //    DataTable dt;
        //    StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
        //            "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento,precio_pmvp AS PMVP,inv_proced AS Procedencia,ult_provee AS pro_principal  " +
        //            "FROM  adminv " +
        //            "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
        //            "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
        //            "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
        //            "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
        //            "WHERE inv_estado='Activo' AND pre_undmed=ime_undmed and Existencia >0" +
        //            " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";
        //    dt = database.fDataTable(StrSql);
        //    dt =agregarOfDt(dt);
        //    database.cerrarConexion();
        //    return dt;
        //}

        //BUSCAR PRODUCTOS
        public DataTable buscarProductos(string filtro, string tipoBusqueda)
        {
            DataTable dt;
            string condicion = null;
            //filtro = string.Format("{0:000000000000000}",filtro.ToString());
            switch (tipoBusqueda)
            {
                case "codigo":
                    //String.Format("{0:000000000000}", Convert.ToDouble(dt.Rows[0]["ctd_correlativo"].ToString()) + 1);
                    filtro = string.Format("{0:000000000000000}", Convert.ToDouble(filtro));
                    condicion = "inv_codigo>='" + filtro + "'";
                    break;
                case "descripcion":
                    condicion = "inv_descri LIKE '%" + filtro + "%'";
                    break;
                case "grupo":
                    condicion = "gru_descri LIKE '%" + filtro + "%'";
                    break;
            };

            //filtro = "000000000" + filtro;
            StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
                "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento,inv_proced AS Procedencia,ult_provee AS pro_principal  " +
                "FROM  adminv " +
                "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
                "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
                "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
                "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
                "WHERE $x  AND inv_estado='Activo' AND pre_undmed=ime_undmed AND Existencia >0" +
                " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";

            StrSql = StrSql.Replace("$x", condicion);
            dt = database.fDataTable(StrSql);

            dt = agregarOfDt(dt);
            database.cerrarConexion();
            return dt;
        }
        //public DataTable buscarProductos(string filtro,string tipoBusqueda)
        //{  
        //    DataTable dt;
        //    string condicion = null;
        //    //filtro = string.Format("{0:000000000000000}",filtro.ToString());
        //    switch (tipoBusqueda) { 
        //        case "codigo":
        //            //String.Format("{0:000000000000}", Convert.ToDouble(dt.Rows[0]["ctd_correlativo"].ToString()) + 1);
        //            filtro = string.Format("{0:000000000000000}", Convert.ToDouble(filtro));
        //            condicion = "inv_codigo>='"+ filtro+"'";
        //        break;
        //        case "descripcion":
        //            condicion = "inv_descri LIKE '%" + filtro + "%'";
        //        break;
        //        case "grupo":
        //             condicion = "gru_descri LIKE '%"+filtro+"%'";
        //        break;
        //    };

        //    //filtro = "000000000" + filtro;
        //    StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
        //        "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento,precio_pmvp AS PMVP,inv_proced AS Procedencia,ult_provee AS pro_principal  " +
        //        "FROM  adminv " +
        //        "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
        //        "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
        //        "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
        //        "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
        //        "WHERE $x  AND inv_estado='Activo' AND pre_undmed=ime_undmed AND Existencia >0" +
        //        " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";

        //    StrSql = StrSql.Replace("$x", condicion);
        //   dt = database.fDataTable(StrSql);

        //    dt = agregarOfDt(dt);
        //    database.cerrarConexion();
        //    return dt;
        //}


        public DataTable buscarProductoUnico(string filtro)
        {
            DataTable dt;
            cadena = filtro.PadLeft(15, '0');

            //StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
            //    "existencia AS Existencia,ime_presen AS Presentacion,inv_proced AS Procedencia,ult_provee AS pro_principal, ult_costo 'Ultimo Costo', pre_lista2 'Pre Lista' " +
            //    "FROM  adminv " +
            //    "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
            //    "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
            //    "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo  " +
            //    "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
            //    "WHERE inv_codigo = '$1' AND inv_estado='Activo'  " +
            //    " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";

            StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
                    "existencia AS Existencia,ime_presen AS Presentacion,inv_proced AS Procedencia,pin_proveedor AS pro_principal, ult_costo 'Ultimo Costo', pre_lista2 'Pre Lista',admarancel.ara_codigo,admarancel.ara_porcen " +
                    "FROM  adminv " +
                    "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
                    "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
                    "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo  " +
                    "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
                    "LEFT OUTER JOIN adminvparam ON adminvparam.pin_codigo = adminv.inv_codigo " +
                    "LEFT OUTER JOIN admarancel ON admarancel.ara_codigo = adminv.inv_arancel " +
                    "WHERE inv_codigo = '$1' AND inv_estado='Activo'  " +
                    " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";

            StrSql = StrSql.Replace("$1", cadena);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            return dt;
            
        }

        public DataTable buscarProductosFrm(string opcion, string value)
        {
            DataTable dt;
            if ((opcion.Equals("")) && (opcion.Equals("")) || (opcion.Equals(null)) && (opcion.Equals(null)))
            {
                StrSql = "SELECT inv_codigo AS Codigo,inv_descri AS Descripcion, " +
                        " inv_iva AS AlicuotaIva, " +
                        " inv_proced AS Procedencia,inv_utiliz AS Utilidad,inv_codfab AS Fabricante,gru_descri AS Grupo, " +
                        " sgr_descri AS SubGrupo,mar_descri AS Marca,div_descri AS Division FROM adminv " +
                        " LEFT JOIN admmarcas on admmarcas.mar_codigo=adminv.inv_codmarca " +
                        " LEFT JOIN admgrupo on admgrupo.gru_codigo=adminv.inv_grupo " +
                        " LEFT JOIN admsubgrupo on admsubgrupo.sgr_codigo=adminv.inv_subgru " +
                        " LEFT JOIN admdivision on admdivision.div_codigo=adminv.inv_divisi GROUP BY inv_codigo  ORDER BY INV_CODIGO LIMIT 200";
            }
            else
            {
                if (opcion.Equals("inv_codigo"))
                {
                    value = value.PadLeft(15, '0');
                    opcion = "inv_codigo>=";
                }
                if (opcion.Equals("inv_descri") || opcion.Equals("gru_descri") || opcion.Equals("inv_proced") || opcion.Equals("inv_codfab") || opcion.Equals("inv_utiliz"))
                {
                    value = " LIKE '" + value + "%'";
                }

                StrSql = "SELECT inv_codigo AS Codigo,inv_descri AS Descripcion, " +
                        " inv_iva AS AlicuotaIva, " +
                        " inv_proced AS Procedencia,inv_utiliz AS Utilidad,inv_codfab AS Fabricante,gru_descri AS Grupo, " +
                        " sgr_descri AS SubGrupo,mar_descri AS Marca,div_descri AS Division FROM adminv " +
                        " LEFT JOIN admmarcas on admmarcas.mar_codigo=adminv.inv_codmarca " +
                        " LEFT JOIN admgrupo on admgrupo.gru_codigo=adminv.inv_grupo " +
                        " LEFT JOIN admsubgrupo on admsubgrupo.sgr_codigo=adminv.inv_subgru " +
                        " LEFT JOIN admdivision on admdivision.div_codigo=adminv.inv_divisi WHERE " + opcion + " " + value + " GROUP BY inv_codigo  ORDER BY INV_CODIGO LIMIT 200";

            }
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            return dt;
        }

        public bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public bool existeProdAdminv(string codProducto)
        {
            bool centinela = false;
            DataTable dt;
            StrSql = null;

            StrSql = "SELECT inv_descri FROM adminv WHERE inv_codigo='$1';";
            StrSql = StrSql.Replace("$1", codProducto);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["inv_descri"].ToString() != "")
                {
                    centinela = true;
                }
            }
            database.cerrarConexion();
            return centinela;
        }

        public bool existeProdAdmEquiv(string codProducto)
        {
            bool centinela = false;
            DataTable dt;
            StrSql = null;

            StrSql = "SELECT equi_codigo FROM admequiv WHERE equi_barra='$1';";
            StrSql = StrSql.Replace("$1", codProducto);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["equi_codigo"].ToString() != "")
                {
                    this.codigoProd = dt.Rows[0]["equi_codigo"].ToString();
                    centinela = true;
                }
            }
            database.cerrarConexion();
            return centinela;
        }

        ////public void cargarDatosProd(string codProd)
        ////{
        ////    DataTable dt;
        ////    StrSql = null;
        ////    int x = 1;

        ////    /* tipo es para cargar la unidad principal o la que venga con el codigo de barras 
        ////     * en admequiv tipo=1 para cargar la principal y 2 para eq */

        ////    StrSql = "SELECT inv_editar,inv_proced,inv_iva, inv_estado, inv_descri,  " +
        ////                " adminv2.cost_prom,adminv2.existencia, adminv2.ult_provee " +
        ////                 " FROM " +
        ////                 " adminv " +
        ////                 "LEFT JOIN adminv2 ON " +
        ////                 "adminv2.inv2_codigo = adminv.inv_codigo " +
        ////                "WHERE inv_codigo='$1';";
        ////    StrSql = StrSql.Replace("$1", codProd);

        ////    dt = database.fDataTable(StrSql);
        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        this.editable = dt.Rows[0]["inv_editar"].ToString();
        ////        if ((dt.Rows[0]["ult_provee"].ToString() == "") || (dt.Rows[0]["ult_provee"].ToString() == null))
        ////        {
        ////            this.procedencia = "Nacional";
        ////        }
        ////        else
        ////        {
        ////            if ((Convert.ToDecimal(dt.Rows[0]["ult_provee"].ToString())) < 8000000)
        ////            {
        ////                this.procedencia = "Importado";
        ////            }
        ////            else
        ////            {
        ////                this.procedencia = "Nacional";
        ////            }
        ////        }
        ////        this.iva = dt.Rows[0]["inv_iva"].ToString();
        ////        this.estado = dt.Rows[0]["inv_estado"].ToString();
        ////        this.descripcion = dt.Rows[0]["inv_descri"].ToString();
        ////        this.existencia = Convert.ToDecimal(dt.Rows[0]["existencia"].ToString());
        ////        this.costoPromedio = Convert.ToDecimal(dt.Rows[0]["cost_prom"].ToString());
        ////    }

        ////    //solo porque no se puede estar seguro si no con join
        ////    StrSql = null;
        ////    StrSql = "SELECT ime_undmed, ime_principal FROM adminvmed WHERE ime_codigo ='$1' AND ime_venta='1';";
        ////    StrSql = StrSql.Replace("$1", codProd);

        ////    dt = database.fDataTable(StrSql);
        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        this.unidadMedida = new string[dt.Rows.Count];
        ////        for (int z = 0; z < dt.Rows.Count; z++)
        ////        {
        ////            // con esto se deja la unidad principal por defecto de primero en el arreglo
        ////            if (dt.Rows[z]["ime_principal"].ToString().Equals("1"))
        ////            {
        ////                this.unidadMedida[0] = dt.Rows[z]["ime_undmed"].ToString();
        ////            }
        ////            else
        ////            {
        ////                this.unidadMedida[x] = dt.Rows[z]["ime_undmed"].ToString();
        ////                x++;
        ////            }
        ////        }
        ////    }

        ////    //por ultimo el valor real del iva
        ////    StrSql = null;
        ////    StrSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
        ////    StrSql = StrSql.Replace("$1", this.iva);
        ////    dt = database.fDataTable(StrSql);
        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        this.valorIva = Convert.ToDecimal(dt.Rows[0]["alict_venta"].ToString());
        ////    }

        ////    //para obtener el valor real de la unidad 
        ////    valorUnidadP(codProd);
        ////    database.cerrarConexion();
        ////}

        public void cargarDatosProd(string codProd)
        {
            DataTable dt;

            StrSql = null;
            int x = 1;

            /* tipo es para cargar la unidad principal o la que venga con el codigo de barras 
             * en admequiv tipo=1 para cargar la principal y 2 para eq */

            StrSql = "SELECT inv_editar,inv_proced,inv_iva, inv_estado, inv_descri,inv_grados,  " +
                        " adminv2.cost_prom,adminv2.existencia, adminv2.ult_provee " +
                         " FROM " +
                         " adminv " +
                         "LEFT JOIN adminv2 ON " +
                         "adminv2.inv2_codigo = adminv.inv_codigo " +
                        "WHERE inv_codigo='$1';";
            StrSql = StrSql.Replace("$1", codProd);

            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                this.editable = dt.Rows[0]["inv_editar"].ToString();
                if ((dt.Rows[0]["ult_provee"].ToString() == "") || (dt.Rows[0]["ult_provee"].ToString() == null))
                {
                    this.procedencia = "Nacional";
                }
                else
                {
                    if ((Convert.ToDecimal(dt.Rows[0]["ult_provee"].ToString())) < 8000000)
                    {
                        this.procedencia = "Importado";
                    }
                    else
                    {
                        this.procedencia = "Nacional";
                    }
                }
                this.iva = dt.Rows[0]["inv_iva"].ToString();
                this.estado = dt.Rows[0]["inv_estado"].ToString();
                this.descripcion = dt.Rows[0]["inv_descri"].ToString();
                this.existencia = Convert.ToDecimal(dt.Rows[0]["existencia"].ToString());
                this.costoPromedio = Convert.ToDecimal(dt.Rows[0]["cost_prom"].ToString());
                this.inv_grados = Convert.ToDecimal(dt.Rows[0]["inv_grados"].ToString());
            }

            //solo porque no se puede estar seguro si no con join
            StrSql = null;
            StrSql = "SELECT ime_undmed, ime_principal FROM adminvmed WHERE ime_codigo ='$1' AND ime_venta='1';";
            StrSql = StrSql.Replace("$1", codProd);

            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                this.unidadMedida = new string[dt.Rows.Count];
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    // con esto se deja la unidad principal por defecto de primero en el arreglo
                    if (dt.Rows[z]["ime_principal"].ToString().Equals("1"))
                    {
                        this.unidadMedida[0] = dt.Rows[z]["ime_undmed"].ToString();
                    }
                    else
                    {
                        this.unidadMedida[x] = dt.Rows[z]["ime_undmed"].ToString();
                        x++;
                    }
                }
            }

            //por ultimo el valor real del iva
            StrSql = null;
            StrSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
            StrSql = StrSql.Replace("$1", this.iva);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                this.valorIva = Convert.ToDecimal(dt.Rows[0]["alict_venta"].ToString());
            }

            //si es exento
            StrSql = null;
            StrSql = "SELECT inv_ex FROM adminv2 WHERE inv2_codigo='$1';";
            StrSql = StrSql.Replace("$1", codProd);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["inv_ex"].ToString() == "1")
                {
                    this.exento = "si";
                }
                else
                {
                    this.exento = "no";
                }
            }
            //para obtener el valor real de la unidad 
            valorUnidadP(codProd);
            database.cerrarConexion();
        }


        public void cargarDatosAdmEquiv(string codigoB)
        {
            this.cargarDatosProd(this.codigoProd);
            this.cenCodigoBarras = true;
            valorUnidadAdmEquiv(codigoB);
        }

        public void valorUnidadP(string codProd)
        {
            StrSql = null;
            DataTable dt;

            StrSql = "SELECT ime_cantid FROM adminvmed WHERE ime_codigo='$1'  AND ime_principal='1'";
            StrSql = StrSql.Replace("$1", codProd);
            dt = database.fDataTable(StrSql);

            if (dt.Rows.Count > 0)
            {
                this.ValorUnidadPrincipal = Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["ime_cantid"].ToString()));
            }

            database.cerrarConexion();
        }

        public void valorUnidadAdmEquiv(string codBarras)
        {
            StrSql = null;
            DataTable dt;
            
            StrSql = "SELECT TRUNCATE((equi_contenido * ime_cantid),0) 'T' FROM admequiv " +
                        "LEFT JOIN  adminvmed ON " +
                        "ime_codigo = equi_codigo " +
                        " WHERE  equi_codigo ='$2' and equi_barra ='$1'  and ime_principal='1';";
            StrSql = StrSql.Replace("$1", codBarras);
            StrSql = StrSql.Replace("$2", this.codigoProd);


            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                this.valorUnidadPrincipal = Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["t"].ToString()));
            }
            database.cerrarConexion();
        }
        
        public void precioProductoClienteUn(string unidad, string precioLista, string divisa, string codigoProducto, string prodIva)
        {
            DataTable dt;
            DataTable dt2;
            string sentencia2;
            decimal precioTemp=0;
            decimal valorAliventa = 0;
            decimal precioDb=0;

            StrSql = null;
            StrSql = "SELECT pre_precio,ttp_inciva FROM admprecios LEFT JOIN admpreciotip ON " +
                        " ttp_codigo=pre_lista WHERE pre_codigo='$1' AND  pre_undmed='$2' " +
                         "AND pre_codmon='$3' AND pre_act='1' AND   pre_lista='$4';";

            StrSql = StrSql.Replace("$1", codigoProducto);
            StrSql = StrSql.Replace("$2", unidad);
            StrSql = StrSql.Replace("$3", divisa);
            StrSql = StrSql.Replace("$4", precioLista);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                //si el producto tiene el iva
                if (dt.Rows[0]["ttp_inciva"].ToString().Equals("1"))
                {
                    sentencia2 = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
                    sentencia2 = sentencia2.Replace("$1", prodIva);
                    dt2 = database.fDataTable(sentencia2);
                    if (dt2.Rows.Count > 0)
                    {
                        //(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()) / 100).ToString("0.##")))
                        /*precioTemp = Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()) / (Convert.ToDecimal(valorAliventa.ToString("0.##")));*/
                        precioDb = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                        valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()))) / 100);
                        precioTemp = precioDb / valorAliventa;
                    }
                } 
                else
                {
                    precioTemp = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                }
                //precioTemp = Convert.ToDecimal(precioTemp.ToString("0.##"));
                //this.precio = Convert.ToDecimal(precioTemp.ToString("0.##"));
                this.precio = Truncate(precioTemp, 2);
                
            }

            database.cerrarConexion();
        }


        public void precioRealProd(string unidad, string precioLista, string divisa, string codigoProducto, string prodIva)
        {
            DataTable dt;
            DataTable dt2;
            string sentencia2;
            decimal precioTemp = 0;
            decimal valorAliventa = 0;
            decimal precioDb = 0;

            StrSql = null;
            StrSql = "SELECT pre_precio,ttp_inciva FROM admprecios LEFT JOIN admpreciotip ON " +
                        " ttp_codigo=pre_lista WHERE pre_codigo='$1' AND  pre_undmed='$2' " +
                         "AND pre_codmon='$3' AND pre_act='1' AND   pre_lista='$4';";

            StrSql = StrSql.Replace("$1", codigoProducto);
            StrSql = StrSql.Replace("$2", unidad);
            StrSql = StrSql.Replace("$3", divisa);
            StrSql = StrSql.Replace("$4", precioLista);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                //si el producto tiene el iva
                if (dt.Rows[0]["ttp_inciva"].ToString().Equals("1"))
                {
                    sentencia2 = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
                    sentencia2 = sentencia2.Replace("$1", prodIva);
                    dt2 = database.fDataTable(sentencia2);
                    if (dt2.Rows.Count > 0)
                    {
                        //(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()) / 100).ToString("0.##")))
                        /*precioTemp = Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()) / (Convert.ToDecimal(valorAliventa.ToString("0.##")));*/
                        precioDb = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                        valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()))) / 100);
                        precioTemp = precioDb / valorAliventa;
                    }
                }
                else
                {
                    precioTemp = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                }
                //precioTemp = Convert.ToDecimal(precioTemp.ToString("0.##"));
                //this.precio = Convert.ToDecimal(precioTemp.ToString("0.##"));
                this.valorPrecio = Truncate(precioTemp, 2);

            }

            database.cerrarConexion();
        }

        public decimal precioRealProd2(string unidad, string precioLista, string divisa, string codigoProducto, string prodIva)
        {
            DataTable dt;
            DataTable dt2;
            string sentencia2;
            decimal precioTemp = 0;
            decimal valorAliventa = 0;
            decimal precioDb = 0;

            StrSql = null;
            StrSql = "SELECT pre_precio,ttp_inciva FROM admprecios LEFT JOIN admpreciotip ON " +
                        " ttp_codigo=pre_lista WHERE pre_codigo='$1' AND  pre_undmed='$2' " +
                         "AND pre_codmon='$3' AND pre_act='1' AND   pre_lista='$4';";

            StrSql = StrSql.Replace("$1", codigoProducto);
            StrSql = StrSql.Replace("$2", unidad);
            StrSql = StrSql.Replace("$3", divisa);
            StrSql = StrSql.Replace("$4", precioLista);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                //si el producto tiene el iva
                if (dt.Rows[0]["ttp_inciva"].ToString().Equals("1"))
                {
                    sentencia2 = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
                    sentencia2 = sentencia2.Replace("$1", prodIva);
                    dt2 = database.fDataTable(sentencia2);
                    if (dt2.Rows.Count > 0)
                    {
                        //(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()) / 100).ToString("0.##")))
                        /*precioTemp = Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()) / (Convert.ToDecimal(valorAliventa.ToString("0.##")));*/
                        precioDb = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                        valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt2.Rows[0]["alict_venta"].ToString()))) / 100);
                        precioTemp = precioDb / valorAliventa;
                    }
                }
                else
                {
                    precioTemp = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString()).ToString("0.##"));
                }
                //precioTemp = Convert.ToDecimal(precioTemp.ToString("0.##"));
                //this.precio = Convert.ToDecimal(precioTemp.ToString("0.##"));
                //return (Truncate(precioTemp, 2));

            }

            database.cerrarConexion();
            return (Truncate(precioTemp, 2));
        }



        public void limpiarProducto()
        {
            this.editable = null;
            this.procedencia = null;
            this.iva = null;
            this.estado = null;
            this.descripcion = null;
            this.unidadMedida = new string[0]; ;
            this.precio = 0;
            this.existencia = 0;
            this.costoPromedio = 0;
            this.codigoProd = null;
            this.valorUnidadPrincipal = 0;
            this.cenCodigoBarras = false;
            this.cenPromocion = false;
            this.valorIva = 0;
            this.valorPrecio = 0;
            this.inv_grados = 0;
        }
        
        public bool isCleanProducto() {
            bool centinela = true;

            if (!(this.editable == null)) {
                centinela = false;
                return centinela;
            }
            if (!(this.procedencia == null)) {
                centinela = false;
                return centinela;
            }
            if (!(this.iva == null)) {
                centinela = false;
                return centinela;
            }
            if (!(this.estado == null)) {
                centinela = false;
                return centinela;
            }
            if (!(this.descripcion == null)) {
                centinela = false;
                return centinela;
            }
            if (this.unidadMedida.GetLength(0) > 0) {
                centinela = false;
                return centinela;
            }
            if (!(this.precio == 0)) {
                centinela = false;
                return centinela;
            }
            if (!(this.existencia == 0)) {
                centinela = false;
                return centinela;
            }
            if (!(this.costoPromedio == 0)) {
                centinela = false;
                return centinela;
            }
            if (!(this.codigoProd == null)) {
                centinela = false;
                return centinela;
            }
            if (!(this.valorUnidadPrincipal == 0)) {
                centinela = false;
                return centinela;
            }
            if (!(this.cenCodigoBarras == false)) {
                centinela = false;
                return centinela;
            }
            if (!(this.cenPromocion == false)) {
                centinela = false;
                return centinela;
            }
            if ((this.valorIva == 0)) {
                centinela = false;
                return centinela;
            }
            if (!(this.valorPrecio == 0)) {
                centinela = false;
                return centinela;
            }

            return centinela;
        }

        //Modificada para redondear al 3 decimal por eso la modicacion 02:27 p.m. 15/07/2013
        private  decimal Truncate(decimal pImporte, int pNumDecimales)
        {
            decimal wRt = 0;
            decimal wPot10 = 1;
            //Decimal.Round2
            //for (int i = 1; i <= pNumDecimales; i++)
            for (int i = 1; i <= 3; i++)
            {
                wPot10 = wPot10 * 10;
            }

            wRt = pImporte * wPot10;
            wRt = decimal.Truncate(wRt);
            wRt = wRt / wPot10;
            //wRt = decimal.Round(wRt, 2);
            wRt = Decimal.Round(wRt, 2, MidpointRounding.AwayFromZero);

            return wRt;
        }

        public bool cargarOfertas(string codProd,string fecha,string unidad, string tipoIva, string precioLista,
            int cantidad) {
            DataTable dt;
            DataTable dt2;
            DataTable dt3;
            decimal precioDb;
            decimal valorAliventa;
            decimal precioTemp;
            bool centinela = false;

            StrSql = null;

            precioTemp = 0;

            StrSql = "SELECT prom_pordes,prom_cantpro,prom_canreq,porm_precio FROM admpromociones " +
                         "WHERE  " +
                         "prom_codigo='$1' AND " +
                         "prom_lista='$2' AND " +
                         "prom_fchedes <='$3' AND " +
                         "prom_fchfin >='$4' AND " +
                         "prom_undmed='$5' AND " +
                         "prom_cantpro >= '$6'  AND " +
                         "prom_cantpro <= '$6' ;";
            
            StrSql = StrSql.Replace("$1",codigoProd);
            StrSql = StrSql.Replace("$2", precioLista);
            StrSql = StrSql.Replace("$3", fecha);
            StrSql = StrSql.Replace("$4", fecha);
            StrSql = StrSql.Replace("$5", unidad);
            StrSql = StrSql.Replace("$6", cantidad.ToString());
            
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0) {
                StrSql = "SELECT  ttp_inciva FROM admpreciotip WHERE ttp_codigo='Z'";
                dt2 = database.fDataTable(StrSql);
                  
                if (dt2.Rows.Count > 0)
                {   //si el producto tiene el iva
                    centinela = true;
                    if (dt2.Rows[0]["ttp_inciva"].ToString().Equals("1"))
                    {
                        StrSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
                        StrSql = StrSql.Replace("$1", this.iva);
                        dt3 = database.fDataTable(StrSql);
                        if (dt3.Rows.Count > 0)
                        {
                            precioDb = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["porm_precio"].ToString()).ToString("0.##"));
                            valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt3.Rows[0]["alict_venta"].ToString()))) / 100);
                            precioTemp = precioDb / valorAliventa;
                        }
                    }
                    else {
                        precioTemp = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["porm_precio"].ToString()).ToString("0.##"));
                    }

                    this.precio = Truncate(precioTemp, 2);
                }
            }
            database.cerrarConexion();
            return centinela;
        }

        public bool cargarMutiplos(string codProd, string fecha, string unidad, string tipoIva, string precioLista,
            int cantidad)
        {
            DataTable dt;
            DataTable dt2;
            DataTable dt3;
            decimal precioDb;
            decimal valorAliventa;
            decimal precioTemp=0;
            bool centinela = false;
            StrSql = null;

            StrSql = "SELECT prom_multiplo,porm_precio FROM admpromociones " +
                        "WHERE  " +
                        "prom_codigo='$1' AND " +
                        "prom_lista='$2' AND " +
                        "prom_fchedes <='$3' AND " +
                        "prom_fchfin >='$4' AND " +
                        "prom_undmed='$5'; ";

            StrSql = StrSql.Replace("$1", codigoProd);
            StrSql = StrSql.Replace("$2", precioLista);
            StrSql = StrSql.Replace("$3", fecha);
            StrSql = StrSql.Replace("$4", fecha);
            StrSql = StrSql.Replace("$5", unidad);

            dt = database.fDataTable(StrSql);
            
            if (dt.Rows.Count > 0) {
                centinela = true;
                StrSql = "SELECT  ttp_inciva FROM admpreciotip WHERE ttp_codigo='Z'";
                dt2 = database.fDataTable(StrSql);

                    if (dt2.Rows[0]["ttp_inciva"].ToString().Equals("1"))
                    {
                        StrSql = "SELECT alict_venta FROM admiva  WHERE alict_tipodiva='$1'";
                        StrSql = StrSql.Replace("$1", this.iva);
                        dt3 = database.fDataTable(StrSql);
                        if (dt3.Rows.Count > 0)
                        {
                            precioDb = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["porm_precio"].ToString()).ToString("0.##"));
                            valorAliventa = 1 + ((Convert.ToDecimal(Convert.ToDecimal(dt3.Rows[0]["alict_venta"].ToString()))) / 100);
                            precioTemp = precioDb / valorAliventa;
                        }
                    }
                    else {
                        precioTemp = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["porm_precio"].ToString()).ToString("0.##"));
                    }

                    this.precio = Truncate(precioTemp, 2);
                }
            
            database.cerrarConexion();
            return centinela;
        }

        public double validarMultipos(string codProd, string fecha, string unidad, string tipoIva, string precioLista,
            int cantidad) {
            DataTable dt;
            StrSql = null;
            int divisor;
            double residuo;

            StrSql = "SELECT prom_pordes,prom_multiplo,porm_precio FROM admpromociones " +
                        "WHERE  " +
                        "prom_codigo='$1' AND " +
                        "prom_lista='$2' AND " +
                        "prom_fchedes <='$3' AND " +
                        "prom_fchfin >='$4' AND " +
                        "prom_undmed='$5'; ";

            StrSql = StrSql.Replace("$1", codigoProd);
            StrSql = StrSql.Replace("$2", precioLista);
            StrSql = StrSql.Replace("$3", fecha);
            StrSql = StrSql.Replace("$4", fecha);
            StrSql = StrSql.Replace("$5", unidad);

            dt = database.fDataTable(StrSql);

            if (dt.Rows.Count > 0)
            {
                divisor = Convert.ToInt32(dt.Rows[0]["prom_multiplo"].ToString());
                if (cantidad >= divisor)
                {
                    if (divisor > 0)
                    {
                        residuo = cantidad % divisor;
                        if (residuo == 0)
                        {
                            //multipo exacto
                            residuo = -1;
                        }
                    }
                    else
                    {
                        //quiere decir que tampoco hay nada para esta producto
                        residuo = -2;
                    }
                }
                else {
                    //quiere decir que tampoco hay nada para esta producto
                    residuo = -2;
                }
            }
            else {
                //quiere decir que tampoco hay nada para esta producto
                residuo = -2;
            }
            database.cerrarConexion();

            return residuo;
        }

        private DataTable agregarOfDt(DataTable dtVisor) {
            StrSql = null;

            dtVisor.Columns.Add("Off", typeof(String));

            for (int x = 0; x < dtVisor.Rows.Count; x++)
            {
                StrSql = "SELECT prom_codigo FROM admpromociones WHERE prom_codigo='$1' " +
                            "AND prom_lista = 'A' " +
                            "AND CURDATE() BETWEEN prom_fchedes AND prom_fchfin ORDER BY prom_codigo; ";
                StrSql = StrSql.Replace("$1", dtVisor.Rows[x]["Codigo"].ToString());
                if ((database.fDataTable(StrSql)).Rows.Count > 0)
                {
                    dtVisor.Rows[x]["Off"] = "Si";
                }
                else {
                    dtVisor.Rows[x]["Off"] = "";
                }

            }

            database.cerrarConexion();
            return dtVisor;
        }

        public DataTable off(string codigo) {
            DataTable dt;

            StrSql = null;
            StrSql = "SELECT prom_undpro,porm_precio,prom_lista,prom_fchedes,prom_fchfin,prom_cantpro, " +
                        "prom_canreq,prom_pordes, prom_multiplo FROM admpromociones WHERE prom_codigo='$1' " +
                        "AND prom_lista = 'A' AND CURDATE() BETWEEN prom_fchedes AND prom_fchfin ORDER BY prom_codigo; ";

            StrSql = StrSql.Replace("$1", codigo);

            dt = database.fDataTable(StrSql);
            database.cerrarConexion();

            return dt;
        }

        public void ajustarCanInventario(decimal cantidadV, string codigoP, string tipoDocumento, string numDoc, string codCliente)
        {
            decimal cantidadBD = 0;
            decimal restante = 0;
            string sentencia2 = null;
            StrSql = null;
            DataTable dtExistencia;

            StrSql = "SELECT existencia FROM adminv2 WHERE inv2_codigo='$1';";
            StrSql = StrSql.Replace("$1", codigoP);
            dtExistencia = database.fDataTable(StrSql);
            if (dtExistencia.Rows.Count > 0)
            {
                cantidadBD = Convert.ToDecimal(dtExistencia.Rows[0]["existencia"].ToString());
            }

            if (tipoDocumento.Equals("FAV"))
            {
                restante = cantidadBD - cantidadV;
                sentencia2 = "UPDATE adminv2 SET existencia=$1, fec_ult_vent='$3', ult_refer_vent='$4', ult_cliente_vent='$5', ult_cant_vent='$6' " +
                "WHERE inv2_codigo='$2'";
                sentencia2 = sentencia2.Replace("$1", Convert.ToString(restante).Replace(",", "."));
                sentencia2 = sentencia2.Replace("$3", "" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
                sentencia2 = sentencia2.Replace("$4", numDoc);
                sentencia2 = sentencia2.Replace("$5", codCliente);
                sentencia2 = sentencia2.Replace("$6", cantidadV.ToString().Replace(",", "."));
                sentencia2 = sentencia2.Replace("$2", codigoP);
            }

            if (tipoDocumento.Equals("DEV"))
            {
                restante = cantidadBD + cantidadV;
                sentencia2 = "UPDATE adminv2 SET  existencia=$1 WHERE inv2_codigo='$2'";
                sentencia2 = sentencia2.Replace("$1", Convert.ToString(restante).Replace(",", "."));
                sentencia2 = sentencia2.Replace("$2", codigoP);
            }

            database.ejecutarInsert(sentencia2);
            database.cerrarConexion();
        }
        public void actualizarItemDev(DataGridView detalles)
        {
            string sentenciaEnviar = null;
            string[] parametrosEnviar = new string[2];
            
            sentenciaEnviar = "UPDATE adminv2 SET existencia=(existencia+@mov_cant) WHERE inv2_codigo=@mov_codigo";
            parametrosEnviar[0] = "mov_cant";
            parametrosEnviar[1] = "mov_codigo";

            database.insertdataGridViewConNombre(detalles, parametrosEnviar, sentenciaEnviar);
            database.cerrarConexion();
        }

        public void habilitarNuevoPrecio(DataGridView tabla)
        {
            StrSql = null;
            string[] parametros = new string[13];

            StrSql = " INSERT INTO admprecios (pre_lista,pre_precio,pre_undmed,pre_codigo, " +
                "pre_descue,pre_desmax,pre_utilid,pre_fechav,pre_codmon,pre_fecha,pre_act, " +
                "pre_hora,pre_usuario) VALUES " +
                "(@Tipo,@PrecioNuevo,@Unidad,@Codigo,@Desc,@DescMax,@Utilidad,@fecha,'Bs'," +
                "'$Sistema','1','$hora',@usuario)";


            parametros[0] = "@item";
            parametros[1] = "@Tipo";
            parametros[2] = "@Codigo";
            parametros[3] = "@Descripcion";
            parametros[4] = "@Unidad";
            parametros[5] = "@PrecioAnterior";
            parametros[6] = "@PrecioNuevo";
            parametros[7] = "@Utilidad";
            parametros[8] = "@Desc";
            parametros[9] = "@DescMax";
            parametros[10] = "@fecha";
            parametros[11] = "@FechaVenc";
            parametros[12] = "@usuario";


            StrSql = StrSql.Replace("$Sistema", DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00"));
            StrSql = StrSql.Replace("$hora", DateTime.Now.ToString("hh:mm:ss tt"));


            database.insertdataGridView(tabla, parametros, StrSql);
            database.cerrarConexion();

        }

        public void inhabilitarPrecio(DataGridView tabla)
        {
            StrSql = null;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                StrSql = " UPDATE admprecios SET pre_act=0 where pre_codigo='$codigo' AND pre_undmed='$undMed' AND pre_lista='$tipoLista' AND pre_codmon='Bs' AND pre_act='1'";

                StrSql = StrSql.Replace("$codigo", "" + tabla.Rows[i].Cells[2].Value);
                StrSql = StrSql.Replace("$tipoLista", "" + tabla.Rows[i].Cells[1].Value);
                StrSql = StrSql.Replace("$undMed", "" + tabla.Rows[i].Cells[4].Value);
                //StrSql = StrSql.Replace("$usuario", "" + tabla.Rows[i].Cells[12].Value);

                database.ejecutarInsert(StrSql);
            }

        }

        public void buscarPrecios(string codigo, string tipoPrecio)
        {

            StrSql = "SELECT pre_precio FROM admprecios WHERE pre_codigo='$1' AND pre_act='1' AND pre_lista='$2'";
            StrSql = StrSql.Replace("$1", codigo);
            StrSql = StrSql.Replace("$2", tipoPrecio);

            ds = database.ejecutarQueryDs(StrSql);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.precio = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }

            database.cerrarConexion();

        }

        public decimal mostrarTotalProd()
        {
            return Truncate((this.precio + ((this.precio * 8) / 100)), 3);
        }


        public void eliminarOferta(string codigo, string fechaFin, string fechaInicio, string cantOtorgada, string cantRequerida)
        {

            DateTime diaAnterior = new DateTime();
            diaAnterior = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString());

            StrSql = "UPDATE admpromociones SET prom_fchfin='$1' WHERE prom_codigo='$2' AND " +
                     " prom_fchedes='$3' AND prom_fchfin='$4' AND prom_cantpro='$5' AND prom_canreq='$6'";

            StrSql = StrSql.Replace("$1", "" + diaAnterior.Year + "-" + diaAnterior.Month.ToString().PadLeft(2, '0') + "-" + diaAnterior.Day);
            StrSql = StrSql.Replace("$2", codigo);
            StrSql = StrSql.Replace("$3", fechaInicio);
            StrSql = StrSql.Replace("$4", fechaFin);
            StrSql = StrSql.Replace("$5", cantOtorgada);
            StrSql = StrSql.Replace("$6", cantRequerida);

            database.ejecutarInsert(StrSql);
            database.cerrarConexion();

        }




        public void registrarNuevasOfertas(DataGridView tabla)
        {

            StrSql = null;
            string[] parametros = new string[13];

            StrSql = "INSERT INTO admpromociones (prom_codigo,prom_undmed,prom_undpro,prom_fchfin,prom_fchedes," +
                "prom_cantpro,prom_canreq,prom_pordes,porm_precio,prom_lista,prom_observ," +
                "prom_multiplo)VALUES(@Codigo,@Unidad,@Unidad,@FechaFin1,@FechaDesde1,@CantOtorgada," +
                "@CantRequerida,'0.00',@Precio,@Tipo,'','0')";

            parametros[0] = "@item";
            parametros[1] = "@Tipo";
            parametros[2] = "@Codigo";
            parametros[3] = "@Descripcion";
            parametros[4] = "@Unidad";
            parametros[5] = "@FechaDesde";
            parametros[6] = "@FechaFin";
            parametros[7] = "@FechaFin1";
            parametros[8] = "@FechaDesde1";
            parametros[9] = "@Precio";
            parametros[10] = "@CantRequerida";
            parametros[11] = "@CantOtorgada";
            parametros[12] = "@usuario";

            database.insertdataGridView(tabla, parametros, StrSql);
            database.cerrarConexion();

        }
        public DataTable buscarMultiplo(string codProduct, string tipoPrecio)
        {

            StrSql = "SELECT prom_multiplo FROM admpromociones WHERE admpromociones.prom_codigo='$1' AND admpromociones.prom_lista='$2' LIMIT 1";
            StrSql = StrSql.Replace("$1", codProduct);
            StrSql = StrSql.Replace("$2", tipoPrecio);

            tabla = database.fDataTable(StrSql);
            return tabla;
            database.cerrarConexion();

        }

        public string obtenerImePresen(string codigo)
        {
            string presen;
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT ime_presen FROM adminvmed WHERE ime_codigo= '$1'";
            StrSql = StrSql.Replace("$1", codigo);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            presen = dt.Rows[0]["ime_presen"].ToString();
            return presen;
        }

        public string ValidarIva(string code)
        {

            StrSql = null;
            DataTable dt;
            string result;
            StrSql = "SELECT adminv.inv_codigo, adminv2.existencia , adminv.inv_descri, admpreciotip.ttp_codigo , admpreciotip.ttp_inciva FROM  adminv LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo LEFT JOIN admpreciotip ON admprecios.pre_lista = admpreciotip.ttp_codigo WHERE inv_codigo = '$1' and pre_act = '1' and pre_lista = 'A' and inv_estado = 'Activo'";

            StrSql = StrSql.Replace("$1", string.Format("{0:000000000000000}", code));
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][4].ToString() == '1'.ToString())
                {
                    result = " IVA Incl.";
                    return result;
                }
                else
                {
                    result = " P.Sin IVA";
                    return result;
                }
            }
            result = "";
            return result;
        }

        public string ValidarPreLista(string codigo)
        {
            DataTable dt;
            StrSql = null;
            string resultado;
            StrSql = "SELECT pre_lista FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1'  AND pre_act = '1' AND pre_lista = 'A' AND existencia > 0";
            StrSql = StrSql.Replace("$1", codigo);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            resultado = dt.Rows[0]["pre_lista"].ToString();
            return resultado;
        }

        public string Validar_Existencia(string codigo)
        {
            DataTable dt;

            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = 'A' AND pre_act = '1' AND existencia > 0; ";
            StrSql = StrSql.Replace("$1", codigo);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }
        }
 public string Validar_Costo(string codigo) 
          {
              DataTable dt;

              StrSql = null;
              string resultado;
              StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = 'A' AND pre_act = '1' AND ult_costo > 0 AND cost_prom > 0; ";
              StrSql = StrSql.Replace("$1", codigo);
              dt = database.fDataTable(StrSql);
              database.cerrarConexion();
              if (dt.Rows.Count > 0)
              {
                  resultado = dt.Rows[0]["existencia"].ToString();
                  return resultado;
              }
              else
              {
                  resultado = "0";
                  return resultado;
              }

          }
        public string Validar_Diponible(string codigo) 
        {
            DataTable dt;

            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = 'A' AND pre_act = '1' AND existencia > 0 AND ult_costo > 0 AND cost_prom > 0 AND existencia > 0; ";
            StrSql = StrSql.Replace("$1", codigo);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }
        
        }
      /* public string Validar_UnidaPrincipal(string codigo)
       {
           DataTable dt;

           StrSql = null;
           string resultado;
           StrSql = "SELECT adminvmed.ime_principal FROM adminvmed INNER JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo  WHERE pre_codigo = '$1' AND ime_principal > 0;";
           StrSql = StrSql.Replace("$1", codigo);
           dt = database.fDataTable(StrSql);
           database.cerrarConexion();
           if (dt.Rows.Count > 0)
           {
               resultado = dt.Rows[0]["ime_principa"].ToString();
               return resultado;
           }
           else
           {
               resultado = "0";
               return resultado;
           }

       }*/
        public string Validar_UnidaPrincipal(string codigo)
        {
            DataTable dt;

            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN adminvmed ON adminvmed.ime_codigo= adminv2.inv2_codigo  WHERE ime_codigo = '$1' AND ime_principal > 0;";
            StrSql = StrSql.Replace("$1", codigo);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }


        }

        public decimal invGrados(string codigo)
        {
            DataTable dt = null;
            decimal empaque = 0;
            StrSql = null;
            StrSql = "SELECT inv_grados FROM adminv WHERE inv_codigo='$inv_codigo';";
            StrSql = StrSql.Replace("$inv_codigo", codigo);
            dt = database.fDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (!(Decimal.TryParse(dt.Rows[0]["inv_grados"].ToString(), out empaque)))
                {
                    empaque = 0;
                }
            }
            database.cerrarConexion();
            return empaque;
        }
        public void buscarProDesg(string codigo, string tipoPrecio)
        {
            DataTable dt;
            StrSql = null;

            StrSql = "SELECT admprecios.pre_precio,adminv.inv_iva, admiva.alict_compra FROM admprecios" +
                " LEFT JOIN adminv ON admprecios.pre_codigo= adminv.inv_codigo LEFT JOIN admiva ON adminv.inv_iva= admiva.alict_tipodiva " +
                "WHERE pre_codigo='@Codigo' AND pre_act='1' AND pre_lista='@lista';";
            StrSql = StrSql.Replace("@Codigo", codigo);
            StrSql = StrSql.Replace("@lista", tipoPrecio);
            dt = database.fDataTable(StrSql);
            //this.iva = dt.Rows[0]["inv_iva"].ToString();

            if (dt.Rows.Count > 0)
            {
                this.montoBase = Convert.ToDecimal(dt.Rows[0]["pre_precio"].ToString());
                this.alicIva = dt.Rows[0]["inv_iva"].ToString();
                this.pAlicIva = Convert.ToDecimal(dt.Rows[0]["alict_compra"].ToString());
            }
            database.cerrarConexion();

        }
        //Modificado el dia 20/11/2015 por Fabian Hooker
        public string validar_Existencia(string codigo, string tipoPrecio)
        {
            DataTable dt;

            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = '$2' AND pre_act = '1' AND existencia > 0; ";
            StrSql = StrSql.Replace("$1", codigo);
            StrSql = StrSql.Replace("$2", tipoPrecio);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }

        }
        //Modificado el dia 20/11/2015 por Fabian Hooker
        public string validar_Costo(string codigo, string tipoPrecio)
        {
            DataTable dt;

            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = '$2' AND pre_act = '1' AND ult_costo > 0 AND cost_prom > 0; ";
            StrSql = StrSql.Replace("$1", codigo);
            StrSql = StrSql.Replace("$2", tipoPrecio);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }
        }
        //Modificado el dia 20/11/2015 por Fabian Hooker
        public string validar_Disponible(string codigo, string tipoPrecio)
        {
            DataTable dt;
            StrSql = null;
            string resultado;
            StrSql = "SELECT adminv2.existencia FROM adminv2 INNER JOIN admprecios ON adminv2.inv2_codigo = admprecios.pre_codigo WHERE pre_codigo = '$1' AND pre_lista = '$2' AND pre_act = '1' AND existencia > 0 AND ult_costo > 0 AND cost_prom > 0 AND existencia > 0; ";
            StrSql = StrSql.Replace("$1", codigo);
            StrSql = StrSql.Replace("$2", tipoPrecio);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                resultado = dt.Rows[0]["existencia"].ToString();
                return resultado;
            }
            else
            {
                resultado = "0";
                return resultado;
            }
        }
        public DataTable busquedaProductoVisor3(string filtro, string tipoBusqueda)
        {
            DataTable dt;
            string condicion = null;
            //filtro = string.Format("{0:000000000000000}",filtro.ToString());
            switch (tipoBusqueda)
            {
                case "codigo":
                    //String.Format("{0:000000000000}", Convert.ToDouble(dt.Rows[0]["ctd_correlativo"].ToString()) + 1);
                    filtro = string.Format("{0:000000000000000}", Convert.ToDouble(filtro));
                    condicion = "inv_codigo>='" + filtro + "'";
                    break;
                case "descripcion":
                    condicion = "inv_descri LIKE '%" + filtro + "%'";
                    break;
                case "grupo":
                    condicion = "gru_descri LIKE '%" + filtro + "%'";
                    break;
            };

            //filtro = "000000000" + filtro;
            StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
                "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento,inv_proced AS Procedencia,ult_provee AS pro_principal  " +
                "FROM  adminv " +
                "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
                "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
                "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
                "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
                "WHERE $x  AND inv_estado='Activo' AND pre_undmed=ime_undmed" +
                " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";

            StrSql = StrSql.Replace("$x", condicion);
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            return dt;
        }
        public DataTable cargarProductoVisor3()
        {
            DataTable dt;
            StrSql = "SELECT adminv.inv_codigo AS Codigo,adminv.inv_descri AS Descripcion,adminvmed.ime_undmed AS Unidad, " +
                    "admprecios.pre_precio AS Precio, existencia AS Existencia,inv_ex AS Exento,inv_proced AS Procedencia,ult_provee AS pro_principal  " +
                    "FROM  adminv " +
                    "LEFT OUTER JOIN adminv2 ON adminv.inv_codigo = adminv2.inv2_codigo " +
                    "LEFT JOIN adminvmed ON adminvmed.ime_codigo=adminv.inv_codigo " +
                    "LEFT JOIN admprecios ON admprecios.pre_codigo=adminv.inv_codigo AND admprecios.pre_lista='A' AND pre_act='1' " +
                    "LEFT JOIN admgrupo ON adminv.inv_grupo=admgrupo.gru_codigo " +
                    "WHERE inv_estado='Activo' AND pre_undmed=ime_undmed" +
                    " GROUP BY inv_codigo ORDER BY inv_codigo LIMIT 100 ";
            dt = database.fDataTable(StrSql);
            dt = agregarOfDt(dt);
            database.cerrarConexion();
            return dt;
        }

    }


    }

