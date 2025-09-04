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
    class proveedor
    {
        // variables
        private ConexionBD database;
        private String StrSql;
        private string nombreProveedor;
        private string codigoProveedor;
        private string cuentaContable;
        private string auxiliarContable;
        private MySqlDataReader dr;
        private string porcReten;
        private string codPais; 

        /////////////// proverdo frmProverdores 03/02/2015/////////////

        private string provCod;
        private string provNom;
        private string provRif;
        private string provPais;
        private string provEstado;
        private string provMun;
        private string provParr;
        private string provDirr1;
        private string provDirr2;
        private string provDirr3;
        private string provCodArea;
        private string provTelf1;
        private string provtelf2;
        private string provtelf3;
        private string provCel1;
        private string provCel2;
        private string provCorreo;
        private string provPagina;
        private string provFechReg;
        private string provResid;
        private string provTipPer;
        private string provSistua;
        private string provClase;
        private string provCate;
        private string provContri;
        private string provContEsp;
        private string provDiv;
        private string provDesp;
        private string provLimCre;
        private string provDiazPlaz;
        private string provCondpago;
        private string provMonVen;
        private string provDiasVen;
        private string provActDes;
        private string provCuentCom;
        private string provCuentEfec;
        private string provCCCXP;
        private string provOrdCompra;
        private string provCxpom;
        private string provZonaLibre;
        private string provSoliCotZom;
        private string provBanco;
        private string provTipoCuentas;
        private string provCcpTran;
        private string provFoto;
        private string provComent;
        private string provRegion;
        private string provRet;
        private string provDcto2;
        private string provDcto3;
        private string provDescPais;



        
        // Get and Set de FrmProverdores
        public string ProvDescPais 
        {
            get { return provDescPais; }
            set { provDescPais = value; }
        }
        public string ProvCod
        {
            get {  return provCod; }
            set { provCod = value; }
        }
        public string ProvNom
        {
            get { return provNom ; }
            set { provNom= value; }
        }
        public string ProvRif
        {
            get { return provRif ; }
            set { provRif= value; }
        }
        public string ProvPais
        {
            get { return provPais ; }
            set { provPais = value; }
        }
        public string ProvEstado
        {
            get {  return provEstado; }
            set { provEstado = value; }
        }
        public string ProvMun
        {
            get { return provMun; }
            set { provMun = value; }
        }
        public string ProvParr
        {
            get { return provParr ; }
            set { provParr= value; }
        }
        public string ProvDirr3
        {
            get { return provDirr1; }
            set { provDirr1 = value; }
        }
        public string ProvDirr2
        {
            get { return provDirr2; }
            set {provDirr2 = value; }
        }
         public string ProvDir3
        {
            get { return provDirr3; }
            set { provDirr3= value; }
        }
         public string ProvCodArea
        {
            get { return provCodArea; }
            set { provCodArea = value; }
        }
        public string ProvTelf1
        {
            get { return provTelf1; } 
            set { provTelf1 = value; }
        }
         public string ProvTelf2
        {
            get { return provtelf2 ; } 
            set { provtelf2 = value; }
        }
        public string ProvTelf3
        {
            get { return provtelf3; }
            set { provtelf3= value; }
        }

       public string ProvCel1
        {
            get { return provCel1; }
            set { provCel1= value; }
        }
        public string ProvCel2
        {
            get { return provCel2; }
            set { provCel2= value; }
        }
         public string ProvCorreo
        {
            get { return provCorreo; }
            set { provCorreo= value; }
        }
        public string  ProvPagina
        {
            get { return provPagina ; }
            set { provPagina= value; }
        } 
         public string ProvFechReg
        {
            get { return provFechReg; }
            set { provFechReg= value; }
        }
         public string ProvResid
        {
            get { return provResid; }
            set { provResid= value; }
        }

         public string  ProvTippER
        {
            get { return provTipPer; }
            set { provTipPer = value; }
        }
        public string ProvSitua
        {
            get { return provSistua; }
            set { provSistua = value; }
        }
        public string ProvClase
        {
            get { return provClase; }
            set { provClase= value; }
        }
       public string ProvCate
        {
            get { return provCate; }
            set { provCate= value; }
        }
        public string ProvContri
        {
            get { return provContri; }
            set { provContri = value; }
        }
         public string ProvContEsp
        {
            get { return provContEsp; }
            set { provContEsp= value; }
        }
        public string ProvDiv
        {
            get { return provDiv; }
            set { provDiv= value; }
        }
        public string ProvDesp
        {
            get { return provDesp; }
            set { provDesp= value; }
        }
        public string ProvLimCre
        {
            get { return provLimCre; }
            set { provLimCre = value; }
        }
        public string ProvDiasPlaz
        {
            get { return provDiazPlaz; }
            set { provDiazPlaz= value; }
        }

        public string  ProvCondPago
        {
            get { return provCondpago; }
            set { provCondpago= value; }
        }
        public string ProvMonVen
        {
            get { return provMonVen; }
            set { provMonVen= value; }
        }
        public string ProvDiasVen
        {
            get { return provDiasVen; }
            set { provDiasVen = value; }
        }
        public string ProvActDes
        {
            get { return provActDes; }
            set { provActDes= value; }
        }
        public string ProvCuentCom
        {
            get { return provCuentCom; }
            set { provCuentCom = value; }
        }
         public string ProvCuentEfec
        {
            get { return provCuentEfec; }
            set { provCuentEfec= value; }
        }
        public string ProvCCCXP
        {
            get { return provCCCXP; }
            set { provCCCXP= value; }
        }
        public string ProvOrdCompra
        {
            get { return provOrdCompra; }
            set { provOrdCompra= value; }
        }
        public string ProvCxpom
        {
            get { return provCxpom; }
            set { provCxpom= value; }
        }
        public string ProvZonaLibre
        {
            get { return provZonaLibre; }
            set { provZonaLibre = value; }
        }
        public string ProvSoliCotZom
        {
            get { return provSoliCotZom; }
            set { provSoliCotZom= value; }
        }
        public string Provbanco
        {
            get { return provBanco; }
            set { provBanco= value; }
        }
        public string ProvTipoCuenta
        {
            get { return provTipoCuentas;; }
            set { provTipoCuentas= value; }
        }
        public string ProvCcptran
        {
            get { return provCcpTran; }
            set { provCcpTran= value; }
        }
        public string ProvFoto
        {
            get { return provFoto; }
            set { provFoto= value; }
        }
        public string ProvComent
        {
            get { return provComent; }
            set { provComent = value; }
        }
         public string ProvRegion
        {
            get { return provRegion; }
            set { provRegion = value; }
        }
        public string ProvRet
        {
            get { return provRet; }
            set { provRet= value; }
        }
        public string ProvDcto2
        {
            get { return provDcto2; }
            set { provDcto2= value; }
        }
        public string ProvDcto3
        {
            get { return provDcto3; ; }
            set { provDcto3 = value; }
        }






        //get and Set

        public string CodPais 
        {
            get { return codPais; }
            set { codPais =value; }
        }
        public string CodigoProveedor
        {
            get { return codigoProveedor; }
            set { codigoProveedor = value; }
        }

        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

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


        public proveedor() {
            database = new ConexionBD(); //sisadm
        }

        //CARGAR
        public DataTable cargarProveedores()
        {
            StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif, pro_divisa AS moneda,histo_valor,pro_descuento,pro_dcto2,pro_dcto3  " +
                " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda ORDER BY pro_codigo ASC LIMIT 300";
            return database.fDataTable(StrSql);
            //database.cerrarConexion();
        }

        //CONSULTAR
        public DataTable consultarProveedor(int opcion, string value)
            
        {

            if (opcion == 1)
            {
                value = string.Format("{0:0000000}",value.ToString());
                StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif,pro_divisa AS moneda,histo_valor,pro_descuento,pro_dcto2,pro_dcto3  " +
                    " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda WHERE pro_codigo >= '$1' ORDER BY pro_codigo ASC LIMIT 300";
          
                StrSql = StrSql.Replace("$1",value);
                database.fDataTable(StrSql);

            }
            if (opcion == 2) {

                StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif,pro_divisa AS moneda,histo_valor,pro_descuento,pro_dcto2,pro_dcto3  " +
                        " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda WHERE pro_nombre LIKE '%$1%' ORDER BY pro_codigo ASC LIMIT 300";
                StrSql = StrSql.Replace("$1",value);
                database.fDataTable(StrSql);
            }
            return database.fDataTable(StrSql);
   
        }

        //CONSULTAR 2
        public DataTable consultarProveedor(string filtro) {
            
            int i = 0;
            bool centinela = false;

            while (i < filtro.Length)
            {
                if (IsNumeric(filtro[i]))
                {
                    i++;
                    centinela = true;
                }
                else
                {
                    if (filtro[i].Equals('.'))
                    {
                        i++;
                    }
                    else
                    {
                        centinela = false;
                        break;
                    }
                }
            }

            if (centinela)
            {

                //filtro = string.Format("{0:0000000}", filtro.ToString());
                filtro = filtro.PadLeft(1,'0');
                StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif,pro_divisa AS moneda,histo_valor,pro_descuento,pro_dcto2,pro_dcto3 " +
                        " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda WHERE pro_codigo >= '$1' ORDER BY pro_codigo ASC LIMIT 300";

                StrSql = StrSql.Replace("$1", filtro);
                database.fDataTable(StrSql);

            }
            else 
            {
                StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif,pro_divisa AS moneda,histo_valor,pro_descuento,pro_dcto2,pro_dcto3 " +
                         " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda WHERE pro_nombre LIKE '%$1%' ORDER BY pro_codigo ASC LIMIT 300";
                StrSql = StrSql.Replace("$1", filtro);
                database.fDataTable(StrSql);

            }
            return database.fDataTable(StrSql);
        
        }



        public DataTable consultarProveedorUnico(string filtro)
        {

                filtro = filtro.PadLeft(1, '0');
                StrSql = "SELECT pro_codigo AS Codigo,pro_nombre AS Nombre,pro_rif AS Rif,pro_divisa AS moneda, histo_valor,pro_descuento,pro_dcto2,pro_dcto3 " +
                    " FROM admproveedor LEFT OUTER JOIN admhistodivi ON pro_divisa=histo_moneda WHERE pro_codigo = '$1' ORDER BY pro_codigo ASC LIMIT 300";

                StrSql = StrSql.Replace("$1", filtro);
                database.fDataTable(StrSql);
            return database.fDataTable(StrSql);

        }



        public bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public DataTable consultarCuentaContable(string proveedor, string tipoDoc)
        {
            StrSql = "SELECT n_cuenta,n_auxiliar FROM admtipdocpro2 WHERE n_proveedor='$1' AND n_tipo='$2'";

            StrSql = StrSql.Replace("$1", proveedor);
            StrSql = StrSql.Replace("$2", tipoDoc);
            return database.fDataTable(StrSql);
        }


        public void obtenerCuentaContable(string TipoDoc, string proveedor)
        {

            StrSql = "SELECT * FROM admtipdocpro2 WHERE n_proveedor='$1' AND n_tipo='$2'";
            StrSql = StrSql.Replace("$1", proveedor);
            StrSql = StrSql.Replace("$2", TipoDoc);

            dr = database.ejecutarQueryDr(StrSql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.cuentaContable = dr.GetString(0);
                    this.auxiliarContable = dr.GetString(1);
                }
            }
        }

        public string porcRetenPro(string proveedor)
        {

            StrSql = "select pro_ret from admproveedor where pro_codigo='$1'";
            StrSql = StrSql.Replace("$1", proveedor);

            dr = database.ejecutarQueryDr(StrSql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    porcReten = dr.GetString(0);
                }
            }
            return porcReten;
        }
        /////////////////////////////// CLASIFICACION ECONOMICA//////////////////////
        public DataTable clasificacionEconomica() 
        {
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT act_codigo,act_descri,act_memo FROM admactividadeco;";
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            return dt;
        }
        public bool InsertClasificacionEconomica(string codigo,string descrip,string memo) 
        {
            bool Ciclope = true;
            StrSql = null;
            StrSql = "INSERT INTO admactividadeco(act_codigo,act_descri,act_memo)" +
                "Value('" + codigo + "','" + descrip + "','" + memo + "')";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
            return Ciclope;
        }
        public bool updateClasificacionEconominca(string codigo, string descrip, string memo)
        {
            bool Ciclope = true;
            StrSql = null;
            StrSql = "UPDATE admactividadeco SET act_codigo='" + codigo + "',act_descri='" + descrip + "'," +
            "act_memo='" + memo + "'WHERE ime_codigo='" + codigo + "';";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
            return Ciclope;
        }
        public void eliminarClasificacionEconomica(string codigo) 
        {
            StrSql = null;
            StrSql = "DELETE FROM admactividadeco WHERE act_codigo='" + codigo + "'";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
        }
        /////////////////////////////// CLASIFICACION MONEDA/////////////////////
        public DataTable monedaOdivisa() 
        {
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT mon_codigo,mon_descri FROM admmoneda;";
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            return dt;
        }
        public bool insertMoneda(string codigo, string descrip) 
        {
            bool Ciclope = true;
            StrSql = null;
            StrSql = "INSERT INTO admmoneda(mon_codigo,mon_descri)" +
                "Value('" + codigo + "','" + descrip + "')";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
            return Ciclope;
        }
        public bool trazUsuario(string usuario, string ip, string modulo, string accion, string codigo)
        {
            bool Ciclope = true;
            StrSql = null;
            StrSql = "INSERT INTO admtrazausuario(trz_codusu,trz_ip,trz_modulo,trz_accion,trz_fchreg,trz_hora,trz_codigo)" +
                "Value('" + usuario + "','" + ip + "','" + modulo + "','" + accion + "'," +
                "'" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "','" + codigo + "')";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
            return Ciclope;
        }
        //senteciaSql=null;
        public void llenarPais(ComboBox cb)
        {
            try
            {
                StrSql = "SELECT pais_descri FROM admpais";
                dr = database.ejecutarQueryDr(StrSql);
                while (dr.Read())
                {
                    cb.Items.Add(dr["pais_descri"].ToString());

                }
                database.cerrarConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Se Llenado ComboBox:" + ex.ToString());
            }
        }
        public void llenarCodPais(string descrip) 
        {
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT pais_codigo FROM admpais WHERE pais_descri='" + descrip + "'";
            dt = database.fDataTable(StrSql);
            this.codPais = dt.Rows[0]["pais_codigo"].ToString();
            database.cerrarConexion();
        }
        /////////////////////////////////// FrmProductos///////////////////////////////////

        public void insertProveedor(string proCod,string proNom,string proRif,string proPais, string proEstado,string proMun,string parro,
          string dirr1,string dirr2,string dirr3,string proCodArea,string proTelf,string proTelf2,string proTelf3,string proCel1
            ,string proCel2,string proCorreo,string proPag,string fechaReg,string proResi,string proTipPer,string proSistua,string proClas
            ,string proCate,string proContri, string proContEspe,string proDivi,string proDesc,string proLimCre,string proDiaPlaz
            ,string proCondiPago,string proMonVen,string proDiasVen,string proActDesc, string proCuenCon,string proCuenEfec,string proCCCXP
            ,string porOrdencono,string proCxpom,string porZonaLibre,string proSoliCotZom, string proBanco,string tipoCuenta,string proCcpTran
            ,string proFoto,string proComentario,string proRegion,string proRet, string Dcto2,string Dcto3) 
        {
          
            StrSql = null;
            StrSql = "INSERT INTO admproveedor(pro_codigo,pro_nombre,pro_rif,pro_pais,pro_estado,pro_municipio," +
                "pro_parroquia,pro_direcc1,pro_direcc2,pro_direcc3,pro_codarea,pro_telefono1,pro_telefono2,pro_telefono3,"+
                "pro_cel1,pro_cel2,pro_correo,pro_pagina,pro_fechareg,pro_reside,pro_tipoper,pro_situacion,pro_clasificac,"+
                "pro_categoria,pro_contribuyen, pro_contriespe,pro_divisa,pro_descuento,pro_limcre,pro_diaspla,pro_condipago,"+
                "pro_monven,pro_diasven,pro_actividadec,pro_cuentacon,pro_cuentaefec,pro_cccxp,pro_ordencono,"+
                "pro_cxpom,pro_zonalibre,pro_soliccotzom,pro_banco,pro_tipocuenta,pro_ccptran,pro_foto,"+
                "pro_comentario,pro_region,pro_ret, pro_dcto2,pro_dcto3)" +
                "Value('" + proCod + "','" + proNom + "','" + proRif + "','" + proPais + "','" + proEstado + "'," +
                "'" + proMun + "','" + parro + "','" + dirr1 + "','" + dirr2 + "','" + dirr3 + "','" + proCodArea + "'," +
                "'" + proTelf + "','" + proTelf2 + "','" + proTelf3 + "','" + proCel1 + "','" + proCel2 + "','" + proCorreo + "'," +
                "'" + proPag + "','" + fechaReg + "','" + proResi + "','" + proTipPer + "','" + proSistua + "','" + proClas + "'," +
                "'" + proCate + "','" + proContri + "','" + proContEspe + "','" + proDivi + "','" + proDesc + "','" + proLimCre + "'," +
                "'" + proDiaPlaz + "','" + proCondiPago + "','" + proMonVen + "','" + proDiasVen + "','" + proActDesc + "','" + proCuenCon + "'," +
                "'" + proCuenEfec + "','" + proCCCXP + "','" + porOrdencono + "','" + proCxpom + "','" + porZonaLibre + "','" + proSoliCotZom + "'," +
                "'" + proBanco + "','" + tipoCuenta + "','" + proCcpTran + "','" + proFoto + "','" + proComentario + "','" + proRegion + "'," +
                "'" + proRet + "','" + Dcto2 + "','" + Dcto3 + "')";
            database.ejecutarInsert(StrSql);
            database.cerrarConexion();
           
        }
        public void modificProveedor(string codigo) 
        {
            DataTable dt;
            StrSql = null;
            StrSql = "Select * from admproveedor Where pro_codigo='"+codigo+"';";
            dt= database.fDataTable(StrSql);
            database.cerrarConexion();
            this.provCod = dt.Rows[0]["pro_codigo"].ToString();
            this.provNom = dt.Rows[0]["pro_nombre"].ToString();
            this.provRif= dt.Rows[0]["pro_rif"].ToString();
            this.provPais = dt.Rows[0]["pro_pais"].ToString();
            this.provEstado = dt.Rows[0]["pro_estado"].ToString();
            this.provMun = dt.Rows[0]["pro_municipio"].ToString();
            this.provParr = dt.Rows[0]["pro_parroquia"].ToString();
            this.provDirr1 = dt.Rows[0]["pro_direcc1"].ToString();
            this.provDirr2 = dt.Rows[0]["pro_direcc2"].ToString();
            this.provDirr3= dt.Rows[0]["pro_direcc3"].ToString();
            this.provCodArea = dt.Rows[0]["pro_codarea"].ToString();
            this.provTelf1 = dt.Rows[0]["pro_telefono1"].ToString();
            this.provtelf2 = dt.Rows[0]["pro_telefono2"].ToString();
            this.provtelf3= dt.Rows[0]["pro_telefono3"].ToString();
            this.provCel1 = dt.Rows[0]["pro_cel1"].ToString();
            this.provCel2= dt.Rows[0]["pro_cel2"].ToString();
            this.provCorreo = dt.Rows[0]["pro_correo"].ToString();
            this.provPagina = dt.Rows[0]["pro_pagina"].ToString();
            this.provFechReg = dt.Rows[0]["pro_fechareg"].ToString();
            this.provResid = dt.Rows[0]["pro_reside"].ToString();
            this.provTipPer = dt.Rows[0]["pro_tipoper"].ToString();
            this.provSistua = dt.Rows[0]["pro_situacion"].ToString();
            this.provContri= dt.Rows[0]["pro_contribuyen"].ToString();
            this.provCate= dt.Rows[0]["pro_categoria"].ToString();
            this.provContEsp = dt.Rows[0]["pro_contriespe"].ToString();
            this.provDesp = dt.Rows[0]["pro_descuento"].ToString();
            this.provLimCre = dt.Rows[0]["pro_limcre"].ToString();
            this.provDiazPlaz= dt.Rows[0]["pro_diaspla"].ToString();
            this.provCondpago = dt.Rows[0]["pro_condipago"].ToString();
            this.provMonVen = dt.Rows[0]["pro_monven"].ToString();
            this.provDiasVen = dt.Rows[0]["pro_diasven"].ToString();
            this.provActDes = dt.Rows[0]["pro_actividadec"].ToString();
            this.provCuentCom = dt.Rows[0]["pro_cuentacon"].ToString();
            this.provCuentEfec = dt.Rows[0]["pro_cuentaefec"].ToString(); 
            this.provCCCXP = dt.Rows[0]["pro_cccxp"].ToString();
            this.provOrdCompra = dt.Rows[0]["pro_ordencono"].ToString();
            this.provZonaLibre = dt.Rows[0]["pro_zonalibre"].ToString();
            this.provSoliCotZom= dt.Rows[0]["pro_soliccotzom"].ToString();
            this.provTipoCuentas = dt.Rows[0]["pro_tipocuenta"].ToString();
            this.provCcpTran = dt.Rows[0]["pro_ccptran"].ToString(); 
            this.provFoto = dt.Rows[0]["pro_foto"].ToString();
            this.provComent = dt.Rows[0]["pro_comentario"].ToString();
            this.provRegion = dt.Rows[0]["pro_region"].ToString();
            this.provRet = dt.Rows[0]["pro_ret"].ToString();
            this.provDcto2 = dt.Rows[0]["pro_dcto2"].ToString();
            this.provDcto3 = dt.Rows[0]["pro_dcto3"].ToString();
            this.provBanco = dt.Rows[0]["pro_banco"].ToString();
            this.provDiv = dt.Rows[0]["pro_divisa"].ToString();
            this.provCxpom = dt.Rows[0]["pro_cxpom"].ToString();
        }

        public bool updateProveedor(string proCod, string proNom, string proRif, string proPais, string proEstado, string proMun, string parro,
          string dirr1, string dirr2, string dirr3, string proCodArea, string proTelf, string proTelf2, string proTelf3, string proCel1
            , string proCel2, string proCorreo, string proPag, string fechaReg, string proResi, string proTipPer, string proSistua, string proClas
            , string proCate, string proContri, string proContEspe, string proDivi, string proDesc, string proLimCre, string proDiaPlaz
            , string proCondiPago, string proMonVen, string proDiasVen, string proActDesc, string proCuenCon, string proCuenEfec, string proCCCXP
            , string porOrdencono, string proCxpom, string porZonaLibre, string proSoliCotZom, string proBanco, string tipoCuenta, string proCcpTran
            , string proFoto, string proComentario, string proRegion, string proRet, string Dcto2, string Dcto3) 
        {
            bool Ciclope = true;
            StrSql = null;
            try
            {
                StrSql = "UPDATE admproveedor SET pro_nombre='" + proNom + "',pro_rif='" + proRif + "',pro_pais='" + proPais + "',pro_estado='" + proEstado + "',pro_municipio='" + proMun + "'," +
                "pro_parroquia='" + parro + "',pro_direcc1='" + dirr1 + "',pro_direcc2='" + dirr2 + "',pro_direcc3='" + dirr3 + "',pro_codarea='" + proCodArea + "',pro_telefono1='" + proTelf + "',pro_telefono2='" + proTelf2 + "',pro_telefono3='" + proTelf3+ "'," +
                "pro_cel1='" + proCel1 + "',pro_cel2='" + proCel2 + "',pro_correo='" + proCorreo + "',pro_pagina='" + proPag + "',pro_fechareg='" + fechaReg + "',pro_reside='" + proResi + "',pro_tipoper='" + proTipPer + "',pro_situacion='" + proSistua + "',pro_clasificac='" + proClas + "'," +
                "pro_categoria='" + proCate + "',pro_contribuyen='" + proContri + "',pro_contriespe='" + proContEspe + "',pro_divisa='" + proDivi + "',pro_descuento='" + proDesc + "',pro_limcre='" + proLimCre + "',pro_diaspla='" + proDiaPlaz + "',pro_condipago='" + proCondiPago + "'," +
                "pro_monven='" + proMonVen + "',pro_diasven='" + proDiasVen + "',pro_actividadec='" + proActDesc + "',pro_cuentacon='" + proCuenCon + "',pro_cuentaefec='" + proCuenEfec + "',pro_cccxp='" + proCCCXP + "',pro_ordencono='" + porOrdencono + "'," +
                "pro_cxpom='" + proCxpom + "',pro_zonalibre='" + porZonaLibre + "',pro_soliccotzom='" + proSoliCotZom + "',pro_banco='" + proBanco + "',pro_tipocuenta='" + tipoCuenta + "',pro_ccptran='" + proCcpTran + "',pro_foto='" + proFoto + "'," +
                "pro_comentario='" + proComentario + "',pro_region='" + proRegion + "',pro_ret='" + proRet + "', pro_dcto2='" + Dcto2 + "',pro_dcto3='" + Dcto3 + "'WHERE pro_codigo='" + proCod + "';";
                database.ejecutarInsert(StrSql);

            }
            catch (Exception e)
            {

            }
            database.cerrarConexion();
            return Ciclope;
        
        }
        public void desactivarProveedor(string codigo) 
        {
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT pro_situacion FROM admproveedor WHERE pro_codigo='" + codigo + "'";
            dt = database.fDataTable(StrSql);
            this.provSistua = dt.Rows[0]["pro_situacion"].ToString();
            database.cerrarConexion();
        }
        public bool updateProvee(string codigo) 
        {
            bool Ciclope = true;
            StrSql = null;
            try
            {
                StrSql = "UPDATE admproveedor SET pro_situacion='Inactivo'WHERE pro_codigo='" + codigo + "';";
                database.ejecutarInsert(StrSql);
            }
            catch (Exception e)
            {
            }
            database.cerrarConexion();
            return Ciclope;
        }
        public string validarProveedor(string codigo) 
        {
            DataTable dt;
            string codigoExite;
            StrSql = null;
            StrSql = "SELECT pro_codigo FROM admproveedor WHERE pro_codigo='" + codigo + "';";
            dt = database.fDataTable(StrSql);
            database.cerrarConexion();
            if (dt.Rows.Count > 0)
            {
                codigoExite = dt.Rows[0]["pro_codigo"].ToString();
                return codigoExite;
            }
            else
            {
                codigoExite = "0";
                return codigoExite;
            }
            
        }
        public void descriPais(string codigo)
        {
            DataTable dt;
            StrSql = null;
            StrSql = "SELECT pais_descri FROM admpais WHERE pais_codigo='" + codigo + "'";
            dt = database.fDataTable(StrSql);
            this.provDescPais = dt.Rows[0]["pais_descri"].ToString();
            database.cerrarConexion();
        }
    }
}
