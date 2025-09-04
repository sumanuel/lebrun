using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace lebrun.clases.contabilidad
{
    public class PlanCuentas
    {
        private string codigoPlanCuentas;
        private string grupo;
        private string subGrupo;
        private string cuenta;
        private string subCuenta;
        private string auxiliar1;
        private string nombreCuenta;
        private string siglas;
        private string saldoInicialEjercicio;
        private Boolean imprimeDiarios;
        private Boolean imprimeBalance;
        private bool manejaAuxiliar;
        private int nivelTotal;
        private string sentencia;
        private ConexionBD dataBase;
        private DataSet ds;
        private string control;
        
        public string CodigoPlanCuentas
        {
            get { return codigoPlanCuentas; }
            set { codigoPlanCuentas = value; }
        }
        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        public string SubGrupo
        {
            get { return subGrupo; }
            set { subGrupo = value; }
        }
        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
        public string SubCuenta
        {
            get { return subCuenta; }
            set { subCuenta = value; }
        }
        public string Auxiliar1
        {
            get { return auxiliar1; }
            set { auxiliar1 = value; }
        }        
        public string NombreCuenta
        {
            get { return nombreCuenta; }
            set { nombreCuenta = value; }
        }
        public string Siglas
        {
            get { return siglas; }
            set { siglas = value; }
        }
        public string SaldoInicialEjercicio
        {
            get { return saldoInicialEjercicio; }
            set { saldoInicialEjercicio = value; }
        }
        public Boolean ImprimeDiarios
        {
            get { return imprimeDiarios; }
            set { imprimeDiarios = value; }
        }
        public Boolean ImprimeBalance
        {
            get { return imprimeBalance; }
            set { imprimeBalance = value; }
        }
        public bool ManejaAuxiliar
        {
            get { return manejaAuxiliar; }
            set { manejaAuxiliar = value; }
        }
        public int NivelTotal
        {
            get { return nivelTotal; }
            set { nivelTotal = value; }
        }

        public string Control
        {
            get { return control; }
            set { control = value; }
        }

        public PlanCuentas(){
            dataBase = new ConexionBD(3);
        }

        public void reversarCodigo(string codigo)         
        {
            
            int i;
            int contadorNumeros=0;
            int diferencia;
            string generado= null;


            /*if ((codigo.IndexOf('.')) == -1) { 
            }else{*/
            if ((!(codigo.IndexOf('.') == -1) || (codigo.Length<=13)) && (codigo.Length!=9))
            {
                for (i = 0; i < codigo.Length; i++)
                {
                    if ((i == 0))
                    {
                        generado = generado + codigo[i];
                        contadorNumeros = contadorNumeros + 1;
                    }
                    else
                    {
                        if (codigo[i] == '.')
                        {
                            continue;
                        }
                        if (codigo[i] != '.')
                        {
                            if (contadorNumeros >= 4)
                            {   // x = codigo.Substring(7, (13-codigo.Length)).ToString().Length;
                                diferencia = 13 - codigo.Length;
                                if (diferencia > 0)
                                {                                    
                                        switch (diferencia)
                                        {
                                            case 4:
                                                generado = generado + "0000" + codigo.Substring(8, 1);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 3:
                                                generado = generado + "000" + codigo.Substring(8, 2);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 2:
                                                generado = generado + "00" + codigo.Substring(8, 3);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 1:
                                                generado = generado + "0" + codigo.Substring(8, 4);
                                                contadorNumeros = generado.Length;
                                                break;
                                        }
                                }
                                else
                                {  
                                    generado = generado + codigo.Substring(8, 5);
                                    /*como el algoritmo esta muy cambiado y genera mucho problema
                                     * sumo todo porque esta parte se sobreentiende que esta completo*/
                                    contadorNumeros = contadorNumeros + generado.Length;
                                }
                                i = codigo.Length;
                            }
                            if (i < codigo.Length)
                            {
                                generado = generado + codigo[i];
                                contadorNumeros = contadorNumeros + 1;
                            }
                        }
                    }
                }

                if (contadorNumeros < 6)
                {
                    diferencia = 9 - contadorNumeros;
                    for (i = 1; i <= diferencia; i++)
                    {
                        generado = generado + '0';
                    }
                }
            }
            else {
                if (codigo.IndexOf('.')!= -1)
                {
                    for (i = 0; i < codigo.Length; i++)
                    {
                        if ((i == 0))
                        {
                            generado = generado + codigo[i];
                            contadorNumeros = contadorNumeros + 1;
                        }
                        else
                        {
                            if (codigo[i] == '.')
                            {
                                continue;
                            }
                            else {
                                if (contadorNumeros < 4)
                                {
                                    generado = generado + codigo[i];
                                    contadorNumeros = contadorNumeros + 1;
                                }
                                else {
                                    diferencia = 13 - codigo.Length;
                                    if (diferencia > 0)
                                    {
                                        switch (diferencia)
                                        {
                                            case 4:
                                                generado = generado + "0000" + codigo.Substring(8, 1);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 3:
                                                generado = generado + "000" + codigo.Substring(8, 2);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 2:
                                                generado = generado + "00" + codigo.Substring(8, 3);
                                                contadorNumeros = generado.Length;
                                                break;
                                            case 1:
                                                generado = generado + "0" + codigo.Substring(8, 4);
                                                contadorNumeros = generado.Length;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        generado = generado + codigo.Substring(8, 5);
                                        /*como el algoritmo esta muy cambiado y genera mucho problema
                                         * sumo todo porque esta parte se sobreentiende que esta completo*/
                                        contadorNumeros = contadorNumeros + generado.Length;
                                    }
                                    i = codigo.Length;
                                }
                            }
                        }
                    }

                    if (contadorNumeros < 6)
                    {
                        diferencia = 9 - contadorNumeros;
                        for (i = 1; i <= diferencia; i++)
                        {
                            generado = generado + '0';
                        }
                    }

                }else{
                    generado = codigo;
                }
            }
            //se genera el codigo Completo
            this.codigoPlanCuentas = generado;
            //y se dividen las demas partes
            generarAuxiliar1();
            generarSubCuenta();
            generarCuenta();
            generarSubGrupo();
            generarGrupo();
        }

        public void generarSubCuenta(){
            this.subCuenta = this.codigoPlanCuentas.Substring(0, 4);
        }

        private void generarCuenta() {
                this.cuenta = this.codigoPlanCuentas.Substring(0, 3);
        }

        private void generarSubGrupo() {
                this.subGrupo = this.codigoPlanCuentas.Substring(0, 2);
            
        }

        private void generarGrupo() {
            this.grupo = this.codigoPlanCuentas.Substring(0, 1);
        }

        private void generarAuxiliar1() {
                this.auxiliar1 = this.codigoPlanCuentas.Substring(4, (this.codigoPlanCuentas.Length - 4));
        }
        
        public Boolean ingresarPlan(string codCompania,string idUsuario,string idBaseDatos) {
            dataBase.conectionStringSysconta(idBaseDatos);
            Boolean centinela;
            DateTime x=DateTime.Now;
            sentencia = "INSERT INTO admcuentascontables (cc_CodigoCuenta,cc_Descripcion,cc_FlagAux, " +
                        "cc_NivelTotal, cc_FlagImpBal, cc_FlagImpDia, cc_SaldoIniEjerc, cc_Siglas, cc_Compania," +
                        " cc_Fecha, cc_User,cc_control) VALUES( '" + this.codigoPlanCuentas + "', '" + this.nombreCuenta + "', " +
                        this.manejaAuxiliar+","+this.nivelTotal+","+ this.imprimeBalance + ", " + this.imprimeDiarios + ", " + this.saldoInicialEjercicio.Replace(',','.') + "," +
                        "'" + this.siglas + "','" + codCompania + "', '" + x.Year + "-" + x.Month + "-" + x.Day + "','" + idUsuario + "','"+this.control+"');";

            centinela= dataBase.ejecutarInsert(sentencia);
            if (centinela)
                MessageBox.Show("Plan de Cuentas Agregado Exitosamente!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return centinela;
        }
        
        public bool validarPlanCuenta(int tipoCuenta,string idbaseDatos) {
            dataBase.conectionStringSysconta(idbaseDatos);
            bool centinela = true;
            ds = new DataSet();
            sentencia = "SELECT cc_CodigoCuenta FROM admcuentascontables WHERE cc_CodigoCuenta = '$1';";
            switch (tipoCuenta)
            {   
                case 12:
                    sentencia = sentencia.Replace("$1", this.codigoPlanCuentas);
                    break;
                case 11:
                    sentencia = sentencia.Replace("$1", this.codigoPlanCuentas);
                    break;
                case 10:
                    sentencia = sentencia.Replace("$1", this.codigoPlanCuentas);
                    break;
                case 7:
                    sentencia = sentencia.Replace("$1", this.subCuenta + "00000");
                    break;
                case 5:
                    sentencia = sentencia.Replace("$1", this.cuenta + "000000");
                    break;
                case 3:
                    sentencia = sentencia.Replace("$1", this.subGrupo + "0000000");
                    break;
                case 1:
                    sentencia = sentencia.Replace("$1", this.grupo + "00000000");
                    break;
            }
            ds.Clear();
            ds = dataBase.ejecutarQueryDs(sentencia);
            try
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    centinela = false;
                }
            }
            catch (DataException e)
            {
                MessageBox.Show("Error: " + e.Message);
                MessageBox.Show("Fuente: " + e.Source);
            }
            catch (Exception e) {
                MessageBox.Show("General Error: " + e.Message);
                MessageBox.Show("General Fuente: " + e.Source);
            }
            return centinela;
        }

        public bool isNivel5(string idbaseDatos) {
            DataTable dtr;
            bool valor = false;

            dataBase.conectionStringSysconta(idbaseDatos);
            sentencia = null;
            sentencia = "SELECT cc_NivelTotal FROM admcuentascontables WHERE cc_CodigoCuenta='$1';";
            sentencia = sentencia.Replace("$1", this.codigoPlanCuentas);
            dtr = dataBase.fDataTable(sentencia);
            if (dtr.Rows.Count > 0) {
                if (Convert.ToInt16(dtr.Rows[0]["cc_NivelTotal"].ToString()) == 5) {
                    valor = true;
                }
            }

            dataBase.cerrarConexion();
            return valor;
        }
       
        public void nivelDeTotal(int caso, string codigo) {
            switch (caso)
            {
                case 13:
                    if (codigo.Substring(3, 5) != "00000")
                    {
                        this.nivelTotal = 5;
                    }
                    break;
                case 12:
                    if (codigo.Substring(3, 4) != "0000")
                    {
                        this.nivelTotal = 5;
                    }
                    break;
                case 11:
                    if (codigo.Substring(3, 3) != "000")
                    {
                        this.nivelTotal = 5;
                    }
                    break;
                case 10:
                    if (codigo.Substring(3, 2) != "00")
                    {
                        this.nivelTotal = 5;
                    }
                    else
                    {
                        caso = 7;
                        nivelDeTotal(caso,codigo);
                    }
                    break;
                case 9:
                    if (codigo.Substring(3, 1) != "0")
                    {
                        this.nivelTotal = 5;
                    }
                    else
                    {
                        caso = 7;
                        nivelDeTotal(caso, codigo);
                    }
                    break;
                case 7:
                    if ((codigo.Substring(0, 4) != "0"))
                    {
                        this.nivelTotal = 4;
                    }
                    else
                    {
                        caso = 5;
                        nivelDeTotal(caso,codigo);
                    }
                    break;
                case 5:
                    if ((codigo.Substring(0, 3)) != "0")
                    {
                        this.nivelTotal = 3;
                    }
                    else
                    {
                        caso = 3;
                        nivelDeTotal(caso,codigo);
                    }
                    break;
                case 3:
                    if ((codigo.Substring(0, 2)) != "0")
                    {
                        this.nivelTotal = 2;
                    }
                    else
                    {
                        caso = 1;
                        nivelDeTotal(caso,codigo);
                    } break;
                case 1:
                    //this.codigoPlanCuentas.Substring(0, 1)
                    if ((codigo.Substring(0, 1)) != "0")
                    {
                        this.nivelTotal = 1;
                    }
                    break;
            }
        }

        public string cargarCodigo(string codigoDecodificado) {
            string cCodificado= null;
            string temporal = null;

            //this.subCuenta = this.codigoPlanCuentas.Substring(0, 4);
            //if (codigoDecodificado.Substring(4, 2) != "00")
            //{   
                
            //}

            if (codigoDecodificado.Length > 4) {
                if (codigoDecodificado.Substring(4, (codigoDecodificado.Length - 4)) != "00000")
                {
                    cCodificado = "." + codigoDecodificado.Substring(4, (codigoDecodificado.Length - 4));
                }
            }


            temporal = codigoDecodificado.Substring(0, 4);
            if (temporal[3] != '0') {
                cCodificado = "." + temporal[3] + cCodificado;
            }
            if (temporal[2] != '0') {
                cCodificado = "." + temporal[2] + cCodificado;
            }
            if (temporal[1] != '0') {
                cCodificado = "." + temporal[1] + cCodificado;
            }
            if (temporal[0] != '0')
            {
                cCodificado = temporal[0] + cCodificado;
            }
            return cCodificado;
        }

        public void limpiarObjeto() {
            this.codigoPlanCuentas = null;
            this.grupo = null;
            this.subGrupo = null;
            this.cuenta = null;
            this.subCuenta = null;
            this.auxiliar1 = null;
            this.nombreCuenta = null;
            this.siglas = null;
            this.saldoInicialEjercicio = null;
            this.imprimeDiarios = false;
            this.imprimeBalance = false;
            this.manejaAuxiliar = false;
            this.nivelTotal = 0;
            this.sentencia = null;
        }

        public DataTable lbxPCCargado(string idBaseDatos) {
            dataBase.conectionStringSysconta(idBaseDatos);
            DataTable dt = new DataTable();
            sentencia = "SELECT cc_CodigoCuenta,cc_Descripcion,cc_NivelTotal,cc_FlagAux,cc_FlagImpBal,cc_FlagImpDia, cc_SaldoIniEjerc,cc_Siglas, " +
                        " cc_control FROM admcuentascontables ORDER BY cc_CodigoCuenta,cc_NivelTotal";
            dt = dataBase.fDataTable(sentencia);
            return dt;
        }
        public void reversarAuxilar(string codigo) {

            if (codigo.Substring(4, (codigo.Length - 4)) != "00000")
                this.auxiliar1 = codigo.Substring(4, (codigo.Length - 4));
            else
                this.auxiliar1 = "";
        }

        public void reversarSubCuenta(string codigo) {
            if (codigo[3] != '0')
            {
                this.subCuenta = codigo[0] + "." + codigo[1] + "." + codigo[2] + "." + codigo[3];
            }
            else
            {
                this.subCuenta = "";
            }
        }

        public void reversarCuenta(string codigo) {
            if(codigo[2]!='0'){
                this.cuenta = codigo[0] + "." + codigo[1] + "." + codigo[2];
            }else{
                this.cuenta = "";
            }
        }

        public void reversarSubGrupo(string codigo) {
            if (codigo[1] != '0')
            {
                this.subGrupo = codigo[0] + "." + codigo[1];
            }
            else {
                this.subGrupo = "";
            }
        }

        public void reversarGrupo(string codigo) {
            if (codigo[0] != '0')
            {
                this.grupo = "" + codigo[0];
            }
            else {
                this.grupo = "";
            }
        }

        public Boolean modificarPlan(string codCompania, string idUsuario,string idBaseDatos)
        {
            dataBase.conectionStringSysconta(idBaseDatos);
            Boolean centinela;
            DateTime x = DateTime.Now;

            sentencia = "UPDATE admcuentascontables SET cc_Descripcion='$1', cc_FlagAux=$2, " +
                        "cc_FlagImpBal=$3, cc_FlagImpDia=$4, cc_SaldoIniEjerc=$5, cc_Siglas='$6', " +
                        " cc_control='$7' WHERE cc_CodigoCuenta='$8';";
            sentencia = sentencia.Replace("$1", this.nombreCuenta);
            sentencia = sentencia.Replace("$2", this.manejaAuxiliar.ToString());
            sentencia = sentencia.Replace("$3", this.imprimeBalance.ToString());
            sentencia = sentencia.Replace("$4", this.imprimeDiarios.ToString());
            sentencia = sentencia.Replace("$5", this.saldoInicialEjercicio.Replace(',', '.'));
            sentencia = sentencia.Replace("$6", this.siglas);
            sentencia = sentencia.Replace("$7", this.control);
            sentencia = sentencia.Replace("$8", this.codigoPlanCuentas);            
            centinela = dataBase.ejecutarInsert(sentencia);
            if (centinela)
                MessageBox.Show("Plan de Cuentas Modificado Exitosamente!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return centinela;
        }

        public DataTable comboPlanCuentas() {            
            sentencia = "SELECT cc_CodigoCuenta, cc_Descripcion FROM admcuentascontables WHERE cc_NivelTotal=5 ORDER BY cc_CodigoCuenta,cc_NivelTotal;";
            return dataBase.fDataTable(sentencia);            
        }


        public bool verificarManejaAuxiliar(string idDataBase, string codigoCuenta)
        {
            bool centinela = false;
            MySqlDataReader dr;
            dataBase.conectionStringSysconta(idDataBase);
            sentencia = "SELECT cc_FlagAux FROM admcuentascontables WHERE cc_CodigoCuenta ='$1';";
            sentencia = sentencia.Replace("$1", codigoCuenta);
            dr = dataBase.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    centinela = dr.GetBoolean(0);
                    
                }
            }
            dr.Close();
            dataBase.cerrarConexion();
            return centinela;
        }

        public bool tieneMovimientos(string idDataBase, string codigoCuenta) {
            bool centinela = false;
            string temp = null;
            MySqlDataReader dr;
            dataBase.conectionStringSysconta(idDataBase);
            sentencia = "SELECT mcd_NroDocum FROM admmovimientoscontabled  WHERE mcd_CodigoMayor='$1' Limit 1";
            sentencia = sentencia.Replace("$1", codigoCuenta);
            dr = dataBase.ejecutarQueryDr(sentencia);
            if (dr.HasRows) {
                while (dr.Read()) {
                    temp = dr.GetString(0);
                }

                if (temp != null) {
                    centinela = true;
                }
            }
            dr.Close();
            dataBase.cerrarConexion();

            if (!centinela) {
                sentencia = "SELECT mcd_NroDocum FROM admmovimientoscontabled_temp  WHERE mcd_CodigoMayor='$1' Limit 1";
                sentencia = sentencia.Replace("$1", codigoCuenta);
                
                dr = dataBase.ejecutarQueryDr(sentencia);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        temp = dr.GetString(0);
                    }

                    if (temp != null)
                    {
                        centinela = true;
                    }
                }
            }
            dr.Close();
            dataBase.cerrarConexion();

            return centinela;
        }


        public bool poseeAuxilar(string idDataBase, string codigoCuenta) {
            bool centinela = false;
            string temp = null;
            MySqlDataReader dr;
            dataBase.conectionStringSysconta(idDataBase);
            sentencia = "SELECT admAC_descripcion FROM admauxiliarcontable WHERE admAC_codigoCuenta='$1';";
            sentencia = sentencia.Replace("$1", codigoCuenta);

            dr = dataBase.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    temp = dr.GetString(0);
                }

                if (temp != null)
                {
                    centinela = true;
                }
            }
            dr.Close();
            dataBase.cerrarConexion();

            return centinela;
        }

        public string getControl(string codigoBPlanC, string idBaseDatos) {
            string idControl = null;
            MySqlDataReader dr;
            dataBase.conectionStringSysconta(idBaseDatos);
            sentencia = "";
            sentencia = "SELECT cc_control FROM admcuentascontables WHERE cc_CodigoCuenta = '$1';";
            sentencia = sentencia.Replace("$1", codigoBPlanC);
            dr = dataBase.ejecutarQueryDr(sentencia);

            if (dr.HasRows) {
                while (dr.Read()) {
                    idControl = dr.GetString(0);
                }
            }
            dr.Close();
            dataBase.cerrarConexion();
            return idControl;
        }

        public string getDescripcionPlanC(String codigoPlanC, string idBaseDatos) {
            string descripcionPlanC = null;
            MySqlDataReader dr;
            
            dataBase.conectionStringSysconta(idBaseDatos);
            sentencia = "";
            sentencia = "SELECT cc_Descripcion FROM admcuentascontables WHERE cc_CodigoCuenta='$1';";
            sentencia = sentencia.Replace("$1", codigoPlanC);
            dr = dataBase.ejecutarQueryDr(sentencia);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    descripcionPlanC = dr.GetString(0);
                }
            }
            dr.Close();
            dataBase.cerrarConexion();
            return descripcionPlanC;
        }


        public string maxValueAdmCuentasContable(string codigoSerie, string idBaseDatos)
        {
            DataTable dt;
            string cuenta = null;

            dataBase.conectionStringSysconta(idBaseDatos);

            sentencia = "SELECT cc_CodigoCuenta+1 FROM admcuentascontables " +
                            " WHERE  cc_CodigoCuenta LIKE '$%' ORDER BY cc_CodigoCuenta DESC LIMIT 1;";

            sentencia = sentencia.Replace("$", codigoSerie.Substring(0, 4));
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                cuenta = dt.Rows[0]["cc_CodigoCuenta+1"].ToString();
            }
            dataBase.cerrarConexion();
            return cuenta;
        }
    }
}
