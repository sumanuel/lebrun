using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using lebrun.clasesData;

namespace lebrun.clases.bancos
{
    public class Banco
    {
        //atributos
        private string codBanco;
        private string nombreBanco;
        private string direccionBanco;
        private string telf1;
        private string telf2;
        private string status;
        private string paginaWeb;
        private string login;
        private string clave;
        private string casillero;
        private string memo;
        private string ultimoCod;

        private string sentenciaSql;
        private DataSet ds;
        private DataTable tabla;
        private ConexionBD databaseConection;


        public string CodBanco
        {
            get { return codBanco; }
            set { codBanco = value; }
        }

        public string NombreBanco
        {
            get { return nombreBanco; }
            set { nombreBanco = value; }
        }

        public string DireccionBanco
        {
            get { return direccionBanco; }
            set { direccionBanco = value; }
        }

        public string Telf1
        {
            get { return telf1; }
            set { telf1 = value; }
        }

        public string Telf2
        {
            get { return telf2; }
            set { telf2 = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string PaginaWeb
        {
            get { return paginaWeb; }
            set { paginaWeb = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        public string Casillero
        {
            get { return casillero; }
            set { casillero = value; }
        }

        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        // constructores

        public Banco() {
            databaseConection = new ConexionBD();
            tabla = new DataTable();
            sentenciaSql = null;
        }

        // funciones

        public DataTable lbxBancos() {
            sentenciaSql = null;
            DataTable dt;
            sentenciaSql=  "SELECT ban_codigo,ban_nombre,ban_tel3 FROM admbancos LIMIT 200;";
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
            
        }

        public void limpiarDatosBanco()
        {
            this.codBanco = null;
            this.nombreBanco = null;
        }

        public DataTable buscarBancosCodNom(string codBanco) {
            sentenciaSql = null;
            DataTable dt;
            sentenciaSql = "SELECT ban_codigo,ban_nombre,ban_tel3 FROM admbancos WHERE ban_codigo LIKE '%"+codBanco+"%' OR "+
                                  "ban_nombre LIKE '%" + codBanco + "%';";
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }



        public void registrarBanco() {

            sentenciaSql = "INSERT INTO admbancos (ban_codigo,ban_nombre,ban_direccion,ban_tel1,ban_tel2,"+
            "ban_tel3,ban_pagina,ban_login,ban_clave,ban_casillero,ban_memo)VALUES('$1','$2','$3','$4',"+
            "'$5','$6','$7','$8','$9','$casillero','$memo') ";

            sentenciaSql = sentenciaSql.Replace("$1", this.codBanco);
            sentenciaSql = sentenciaSql.Replace("$2", this.nombreBanco);
            sentenciaSql = sentenciaSql.Replace("$3", this.direccionBanco);
            sentenciaSql = sentenciaSql.Replace("$4", this.telf1);
            sentenciaSql = sentenciaSql.Replace("$5", this.telf2);
            sentenciaSql = sentenciaSql.Replace("$6", this.status);
            sentenciaSql = sentenciaSql.Replace("$7", this.paginaWeb);
            sentenciaSql = sentenciaSql.Replace("$8", this.login);
            sentenciaSql = sentenciaSql.Replace("$9", this.clave);
            sentenciaSql = sentenciaSql.Replace("$casillero", this.casillero);
            sentenciaSql = sentenciaSql.Replace("$memo", this.memo);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();

        }

        public void actualizarBanco(string numBanco) {

            sentenciaSql = "UPDATE admbancos SET ban_nombre='$2',ban_direccion='$3',ban_tel1='$4',ban_tel2='$5'," +
                            "ban_tel3='$6',ban_pagina='$7',ban_login='$8',ban_clave='$9',ban_casillero='$casillero'," +
                            "ban_memo='$memo' WHERE ban_codigo='$1' ";


            sentenciaSql = sentenciaSql.Replace("$1", numBanco);
            sentenciaSql = sentenciaSql.Replace("$2", this.nombreBanco);
            sentenciaSql = sentenciaSql.Replace("$3", this.direccionBanco);
            sentenciaSql = sentenciaSql.Replace("$4", this.telf1);
            sentenciaSql = sentenciaSql.Replace("$5", this.telf2);
            sentenciaSql = sentenciaSql.Replace("$6", this.status);
            sentenciaSql = sentenciaSql.Replace("$7", this.paginaWeb);
            sentenciaSql = sentenciaSql.Replace("$8", this.login);
            sentenciaSql = sentenciaSql.Replace("$9", this.clave);
            sentenciaSql = sentenciaSql.Replace("$casillero", this.casillero);
            sentenciaSql = sentenciaSql.Replace("$memo", this.memo);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();

        }

        public DataTable armarDatosBanco(string numBanco) {

            sentenciaSql = "SELECT ban_codigo,ban_nombre,ban_direccion,ban_tel1,ban_tel2," +
            "ban_tel3,ban_pagina,ban_login,ban_clave,ban_casillero,ban_memo FROM admbancos WHERE ban_codigo='$1'";
            
            sentenciaSql = sentenciaSql.Replace("$1", numBanco);

            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;

        }

        public string obtenerUltimoCod() {

            ds = databaseConection.ejecutarQueryDs("SELECT ban_codigo FROM admbancos ORDER BY ban_codigo DESC LIMIT 1");

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.ultimoCod = String.Format("{0:000000}", Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString()) + 1);

            }
            databaseConection.cerrarConexion();
            return ultimoCod;
        }

        public DataTable cargarLbxCuentasBanc()
        {
            sentenciaSql = "SELECT ctas_banco 'Codigo',ctas_nomban 'Banco',ctas_tirular 'Titular',ctas_tipo 'Cuenta',ctas_numero 'Numero Cuenta', "+
                "ctas_divisa 'Divisa',ctas_sucursal 'Sucursal',ctas_activa 'Activa'  FROM admcuentasbanc ";

            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;

        }

        public DataTable busquedaCuentaBanc(int opcion, string busqueda)
        {
            if (opcion == 0)
            {

                sentenciaSql = "SELECT ctas_banco 'Codigo',ctas_nomban 'Banco',ctas_tirular 'Titular',ctas_tipo 'Cuenta',ctas_numero 'Numero Cuenta', " +
                "ctas_divisa 'Divisa',ctas_sucursal 'Sucursal',ctas_activa 'Activa'  FROM admcuentasbanc ";
            }

            if (opcion == 1)
            {

                sentenciaSql = "SELECT ctas_banco 'Codigo',ctas_nomban 'Banco',ctas_tirular 'Titular',ctas_tipo 'Cuenta',ctas_numero 'Numero Cuenta', " +
                "ctas_divisa 'Divisa',ctas_sucursal 'Sucursal',ctas_activa 'Activa'  FROM admcuentasbanc WHERE ctas_nomban='$1'  ";
                sentenciaSql = sentenciaSql.Replace("$1", busqueda);
            }

            if (opcion == 2)
            {

                sentenciaSql = "SELECT ctas_banco 'Codigo',ctas_nomban 'Banco',ctas_tirular 'Titular',ctas_tipo 'Cuenta',ctas_numero 'Numero Cuenta', " +
                "ctas_divisa 'Divisa',ctas_sucursal 'Sucursal',ctas_activa 'Activa'  FROM admcuentasbanc WHERE ctas_numero='$1'  ";
                sentenciaSql = sentenciaSql.Replace("$1", busqueda);
            }


            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;
        }

        public void insertarNuevaCuentaBanc(DataTable tabla, string IDE)
        {
            sentenciaSql = null;
            string[] parametros = new string[31];

            sentenciaSql = "INSERT INTO `admcuentasbanc` " +
            "(`ctas_banco`, `ctas_tirular`, `ctas_descrip`, `ctas_numero`, `ctas_divisa`," +
            "`ctas_sucursal`, `ctas_depositos`, `ctas_pagos`, `ctas_itf`, `ctas_activa`," +
            "`ctas_cheqauto`, `ctas_formato`, `ctas_memo`, `ctas_tipo`, `ctas_nomban`," +
            "`ctas_pagCheque`, `ctas_contable3`, `ctas_contable4`, `ctas_cheIni1`," +
            "`ctas_cheFin1`, `ctas_cheIni2`, `ctas_cheFin2`, `ctas_numChe1`," +
            "`ctas_numChe2`, `ctas_cheIni3`, `ctas_cheFin3`, `ctas_numChe3`," +
            "`ctas_CheActiva`, `ctas_ultCheque`, `desdeIDB`, `hastaIDB`, `porcIDB`,`ctas_ultCheque2`,`ctas_ultCheque3`) " +
            "VALUES (@codigoBanco, @titular,@descripcion,@numeroCuenta, " +
            "@divisa,@sucursal,@deposito,@pago,@itf,@cuentaActiva,@consecutivoCheque, '', '',@tipoCuenta,@nombreBanco, " +
            "@cuentaContable,@auxiliarContable, '" + IDE + "',@che1Desde,@che1Hasta,@che2Desde,@che2Hasta, " +
            "@che1Cant,@che2Cant,@che3Desde,@che3Hasta,@che3Cant,@chequeraActiva,@ultChe1,@idbDesde,@idbHasta,@porcIdb,@ultChe2,@ultChe3);";

            parametros[0] = "@codigoBanco";
            parametros[1] = "@titular";
            parametros[2] = "@descripcion";
            parametros[3] = "@tipoCuenta";
            parametros[4] = "@numeroCuenta";
            parametros[5] = "@divisa";
            parametros[6] = "@sucursal";
            parametros[7] = "@cuentaContable";
            parametros[8] = "@auxiliarContable";
            parametros[9] = "@idbDesde";
            parametros[10] = "@idbHasta";
            parametros[11] = "@porcIdb";
            parametros[12] = "@che1Desde";
            parametros[13] = "@che1Hasta";
            parametros[14] = "@che1Cant";
            parametros[15] = "@che2Desde";
            parametros[16] = "@che2Hasta";
            parametros[17] = "@che2Cant";
            parametros[18] = "@che3Desde";
            parametros[19] = "@che3Hasta";
            parametros[20] = "@che3Cant";
            parametros[21] = "@ultChe1";
            parametros[22] = "@ultChe2";
            parametros[23] = "@ultChe3";
            parametros[24] = "@chequeraActiva";
            parametros[25] = "@cuentaActiva";
            parametros[26] = "@deposito";
            parametros[27] = "@pago";
            parametros[28] = "@itf";
            parametros[29] = "@consecutivoCheque";
            parametros[30] = "@nombreBanco";


            databaseConection.insertDataTable(tabla, parametros, sentenciaSql);
            databaseConection.cerrarConexion();

        }

        public void eliminarCuentaBancaria(string codigoBanco, string titular, string numeroCuenta)
        {

            sentenciaSql = "DELETE FROM admcuentasbanc WHERE ctas_banco='$1' AND ctas_tirular='$2' AND ctas_numero='$3'  ";
            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", titular);
            sentenciaSql = sentenciaSql.Replace("$3", numeroCuenta);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public DataTable armarModificacion(string codigoBanco, string titular, string tipoCuenta, string numeroCuenta)
        {

            sentenciaSql = "SELECT * FROM admcuentasbanc WHERE ctas_banco='$1' AND ctas_tirular='$2'AND ctas_tipo='$3' AND ctas_numero='$4'  ";
            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", titular);
            sentenciaSql = sentenciaSql.Replace("$3", tipoCuenta);
            sentenciaSql = sentenciaSql.Replace("$4", numeroCuenta);

            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;
        }

        public void modificarCuentaBanc(DataTable tabla, string IDE)
        {
            sentenciaSql = null;


            sentenciaSql = "UPDATE admcuentasbanc SET " +
                     "`ctas_banco`= '$banco'," +
                     "`ctas_tirular`='$titular'," +
                     "`ctas_descrip`='$descripcion'," +
                     "`ctas_numero`='$numeroCuenta', " +
                     "`ctas_divisa`='$divisa'," +
                     "`ctas_sucursal`='$sucursal'," +
                     "`ctas_depositos`='$deposito'," +
                     "`ctas_pagos`='$pago'," +
                     "`ctas_itf`='$itf'," +
                     "`ctas_activa`='$activa'," +
                     "`ctas_cheqauto`='$consecutivoCheque'," +
                     "`ctas_formato`=''," +
                     "`ctas_memo`='', " +
                     "`ctas_tipo`='$tipoCuenta'," +
                     "`ctas_nomban`='$nombreBanco'," +
                     "`ctas_pagCheque`='$cuentaContable'," +
                     "`ctas_contable3`='$auxiliarContable'," +
                     "`ctas_contable4`=''," +
                     "`ctas_cheIni1`='$1Desde'," +
                     "`ctas_cheFin1`='$1Hasta'," +
                     "`ctas_cheIni2`='$2Desde'," +
                     "`ctas_cheFin2`='$2Hasta'," +
                     "`ctas_numChe1`='$1Cant'," +
                     "`ctas_numChe2`='$2Cant'," +
                     "`ctas_cheIni3`='$3Desde'," +
                     "`ctas_cheFin3`='$3Hasta'," +
                     "`ctas_numChe3`='$3Cant'," +
                     "`ctas_CheActiva`='$chequeraActiva'," +
                     "`ctas_ultCheque`='$01Ultimo'," +
                     "`ctas_ultCheque2`='$02Ultimo'," +
                     "`ctas_ultCheque3`='$03Ultimo'," +
                     "`desdeIDB`='$desdeIdb'," +
                     "`hastaIDB`='$hastaIdb'," +
                     "`ctas_contable4`='" + IDE + "'," +
                     "`porcIDB`='$PorcIdb' WHERE ctas_banco='$banco' AND ctas_numero='$numeroCuenta' ";

            sentenciaSql = sentenciaSql.Replace("$banco", tabla.Rows[0][0].ToString());
            sentenciaSql = sentenciaSql.Replace("$titular", tabla.Rows[0][1].ToString());
            sentenciaSql = sentenciaSql.Replace("$descripcion", tabla.Rows[0][2].ToString());
            sentenciaSql = sentenciaSql.Replace("$tipoCuenta", tabla.Rows[0][3].ToString());
            sentenciaSql = sentenciaSql.Replace("$numeroCuenta", tabla.Rows[0][4].ToString());
            sentenciaSql = sentenciaSql.Replace("$divisa", tabla.Rows[0][5].ToString());
            sentenciaSql = sentenciaSql.Replace("$sucursal", tabla.Rows[0][6].ToString());
            sentenciaSql = sentenciaSql.Replace("$cuentaContable", tabla.Rows[0][7].ToString());
            sentenciaSql = sentenciaSql.Replace("$auxiliarContable", tabla.Rows[0][8].ToString());
            sentenciaSql = sentenciaSql.Replace("$desdeIdb", tabla.Rows[0][9].ToString());
            sentenciaSql = sentenciaSql.Replace("$hastaIdb", tabla.Rows[0][10].ToString());
            sentenciaSql = sentenciaSql.Replace("$PorcIdb", tabla.Rows[0][11].ToString());
            sentenciaSql = sentenciaSql.Replace("$1Desde", tabla.Rows[0][12].ToString());
            sentenciaSql = sentenciaSql.Replace("$1Hasta", tabla.Rows[0][13].ToString());
            sentenciaSql = sentenciaSql.Replace("$1Cant", tabla.Rows[0][14].ToString());
            sentenciaSql = sentenciaSql.Replace("$2Desde", tabla.Rows[0][15].ToString());
            sentenciaSql = sentenciaSql.Replace("$2Hasta", tabla.Rows[0][16].ToString());
            sentenciaSql = sentenciaSql.Replace("$2Cant", tabla.Rows[0][17].ToString());
            sentenciaSql = sentenciaSql.Replace("$3Desde", tabla.Rows[0][18].ToString());
            sentenciaSql = sentenciaSql.Replace("$3Hasta", tabla.Rows[0][19].ToString());
            sentenciaSql = sentenciaSql.Replace("$3Cant", tabla.Rows[0][20].ToString());
            sentenciaSql = sentenciaSql.Replace("$01Ultimo", tabla.Rows[0][21].ToString());
            sentenciaSql = sentenciaSql.Replace("$02Ultimo", tabla.Rows[0][22].ToString());
            sentenciaSql = sentenciaSql.Replace("$03Ultimo", tabla.Rows[0][23].ToString());
            sentenciaSql = sentenciaSql.Replace("$chequeraActiva", tabla.Rows[0][24].ToString());
            sentenciaSql = sentenciaSql.Replace("$activa", tabla.Rows[0][25].ToString());
            sentenciaSql = sentenciaSql.Replace("$deposito", tabla.Rows[0][26].ToString());
            sentenciaSql = sentenciaSql.Replace("$pago", tabla.Rows[0][27].ToString());
            sentenciaSql = sentenciaSql.Replace("$itf", tabla.Rows[0][28].ToString());
            sentenciaSql = sentenciaSql.Replace("$consecutivoCheque", tabla.Rows[0][29].ToString());
            sentenciaSql = sentenciaSql.Replace("$nombreBanco", tabla.Rows[0][30].ToString());


            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();


        }
        public DataTable obtenerNumerosCuenta(string codigoBan)
        {
            sentenciaSql = "";
            sentenciaSql = "SELECT ctas_numero FROM admcuentasbanc WHERE ctas_banco='$1' AND ctas_tipo='$2' AND ctas_activa='Sí'";
            sentenciaSql = sentenciaSql.Replace("$1", codigoBan);
            sentenciaSql = sentenciaSql.Replace("$2", "Corriente");

            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;

        }

        public DataTable obtenerDatosChequera(string codigoBanco, string numeroCuenta)
        {

            sentenciaSql = "";
            sentenciaSql = "SELECT " +
                    "ctas_cheIni1 'chequeDesde1',ctas_cheFin1 'chequeHasta1',ctas_numChe1 'chequeCant1'," +
                    "ctas_cheIni2 'chequeDesde2',ctas_cheFin2 'chequeHasta2',ctas_numChe2 'chequeCant2'," +
                    "ctas_cheIni3 'chequeDesde3',ctas_cheFin3 'chequeHasta3',ctas_numChe3 'chequeCant3'," +
                    "ctas_ultCheque 'UltimoCheque',ctas_ultCheque2 'UltimoCheque2',ctas_ultCheque3 'UltimoCheque3',ctas_CheActiva 'ChequeraActiva', " +
                    "ctas_cheqauto,desdeIDB,hastaIDB,porcIDB " +
                    "FROM admcuentasbanc WHERE ctas_banco='$1' AND ctas_numero='$2'";

            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", numeroCuenta);

            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;

        }

        public void reactivarChequera(string codigoBanco, string numeroCuenta, int chequera)
        {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admcuentasbanc SET ctas_CheActiva='$3' WHERE ctas_banco='$1' AND ctas_numero='$2' ";

            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", numeroCuenta);
            sentenciaSql = sentenciaSql.Replace("$3", "" + chequera);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public void actualizarUltimoCheque(string codigoBanco, string numeroCuenta, int chequera, string numeroCheque)
        {
            string ctas_ultCheque = "";

            if (chequera == 1)
            {
                ctas_ultCheque = "ctas_ultCheque";
            }
            if (chequera == 2)
            {
                ctas_ultCheque = "ctas_ultCheque2";
            }
            if (chequera == 3)
            {
                ctas_ultCheque = "ctas_ultCheque3";
            }

            sentenciaSql = null;
            sentenciaSql = "UPDATE admcuentasbanc SET $5='$4' WHERE ctas_banco='$1' AND ctas_numero='$2' ";

            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", numeroCuenta);
            sentenciaSql = sentenciaSql.Replace("$3", "" + chequera);
            sentenciaSql = sentenciaSql.Replace("$4", "" + (Convert.ToInt64(numeroCheque) + 1));
            sentenciaSql = sentenciaSql.Replace("$5", ctas_ultCheque);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public DataTable obtenerCuentaContableBanco(string codigoBanco)
        {
            sentenciaSql = "SELECT ctas_pagCheque,ctas_contable3 FROM admcuentasbanc WHERE ctas_banco='$1'";
            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;
        }

        public DataTable obtenerCuentaContableBanco(string codigoBanco, string cuentaBanc)
        {
            sentenciaSql = "SELECT ctas_pagCheque,ctas_contable3 FROM admcuentasbanc WHERE ctas_banco='$1' AND ctas_numero='$2'";
            sentenciaSql = sentenciaSql.Replace("$1", codigoBanco);
            sentenciaSql = sentenciaSql.Replace("$2", cuentaBanc);
            tabla = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return tabla;
        }

        
    }
}
