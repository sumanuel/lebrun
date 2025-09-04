using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;
using System.Windows.Forms;

namespace lebrun.clasesData
{
    public class UsuarioSistema : Compania
    {
        private ConexionBD dataBase;
        private string sentencia= null;
        private DataSet ds;
        private string id;
        private string codigoCompania;
        private string login;
        private string contrasena;
        private string mapaMenu;
        private string numeroCaja;
        private string nombreUsuario;
        private string ipPc;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string CodigoCompania
        {
            get { return codigoCompania; }
            set { codigoCompania = value; }
        }
        public string Login
        {
              get { return login; }
              set { login = value; }
        }
        public string Contrasena
        {
          get { return contrasena; }
          set { contrasena = value; }
        }
        public string MapaMenu
        {
            get { return mapaMenu; }
            set { mapaMenu = value; }
        }
        public string NumeroCaja
        {
            get { return numeroCaja; }
            set { numeroCaja = value; }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string IpPc
        {
            get { return ipPc; }
            set { ipPc = value; }
        }

        public UsuarioSistema(){
            //para obtener la compañia
            dataBase = new ConexionBD();
            //ds = new DataSet();
            //this.obtenerCompania();
            
        }

        public UsuarioSistema(int tipoConexion) {
            dataBase = new ConexionBD(tipoConexion);
        }

        public bool validarContrasenaParametrosC(string pasword, string idDatabase) {
            DataTable dt;
            bool centinela = false;

            sentencia = "";
            sentencia = "SELECT pc_Descripcion FROM admparametroscontables WHERE " +
            "(pc_ClaveComprob='$1' OR pc_ClaveAsesorTributario='$1' OR pc_ClaveGerenteAdministrativo='$1') AND " +
            " pc_idSistema='08';";
            sentencia = sentencia.Replace("$1", pasword);

            dt = new DataTable();
            dataBase.conectionStringSysconta(idDatabase);
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();

            if (dt.Rows.Count > 0) {
                centinela = true;
            }

            return centinela;
        }

        public bool validarUsuario()
        {
            bool centinela = false;
            DataTable dt;

            sentencia = null;
            dataBase.modificarConexionString(2);

            sentencia = "SELECT usu_mapmnu, usu_nombre,usu_codigo,usu_caja FROM confusuario WHERE usu_nombre='$1' AND usu_clave='$2';";
            sentencia = sentencia.Replace("$1", this.login);
            sentencia = sentencia.Replace("$2", this.contrasena);

            dt = dataBase.fDataTable(sentencia);

            if (dt.Rows.Count > 0)
            {
                this.mapaMenu = dt.Rows[0]["usu_mapmnu"].ToString();
                this.id = dt.Rows[0]["usu_codigo"].ToString();
                this.nombreUsuario = dt.Rows[0]["usu_nombre"].ToString();
                this.numeroCaja = dt.Rows[0]["usu_caja"].ToString();

                //if (dt.Rows[0]["usu_caja"].ToString() != null)
                //{
                //    this.numeroCaja = dt.Rows[0]["usu_caja"].ToString();
                //}
                //else {
                //    this.numeroCaja = "";
                //}
                centinela = true;
            }
            dataBase.modificarConexionString(1);
            dataBase.cerrarConexion();
            return centinela;
        }



        public bool existeUsuario(string nombreUsuario) {
            DataTable dt;
            sentencia = null;
            bool resultado = false;
            dataBase.modificarConexionString(2);

            sentencia = "SELECT usu_nombre FROM confusuario WHERE  usu_nombre='$1'";
            sentencia = sentencia.Replace("$1",nombreUsuario);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0) {
                resultado = true;
            }

            dataBase.modificarConexionString(1);
            dataBase.cerrarConexion();
            return resultado;
        }


        public bool isClaveSupervicion(string nombreUsuario, string contrasena) {
            DataTable dt;
            sentencia = null;
            bool centinela = false;
            
            dataBase.modificarConexionString(2);
            sentencia = "SELECT usu_fav_confirmacion FROM confusuario WHERE usu_nombre='$1' AND usu_clave='$2';";
            sentencia = sentencia.Replace("$1", nombreUsuario);
            sentencia = sentencia.Replace("$2", contrasena);

            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["usu_fav_confirmacion"].ToString().Equals("1")) {
                    centinela = true;
                }
            }

            dataBase.modificarConexionString(1);
            dataBase.cerrarConexion();
            return centinela;
        }
		
		  public DataTable lbxUsuarios() {
            DataTable dt;
            sentencia = null;

            sentencia = "SELECT confusuario.usu_codigo,confusuario.usu_nombre,confusuario.usu_cargo,confusuario.usu_mapmnu, " +
                              "usu_compania,usu_administracion FROM confusuario LEFT " +
                              "JOIN confusuario2 ON confusuario.usu_codigo= confusuario2.usu_codigo LIMIT 100;";
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            return dt;
        }

        public DataTable buscarUsuarios(string filtro,string tipoBusqueda) {
            DataTable dt;
            sentencia = null;
            string condicion = null;
            switch (tipoBusqueda) { 
                case "codigo":
                    condicion = "confusuario.usu_codigo LIKE '%" + filtro + "%'";
                break;
                case "descripcion":
                condicion = "usu_nombre LIKE '%" + filtro + "%'";
                break;
            }

            sentencia = "SELECT confusuario.usu_codigo,confusuario.usu_nombre,confusuario.usu_cargo,confusuario.usu_mapmnu, " +
                              "usu_compania,usu_administracion FROM confusuario LEFT " +
                              "JOIN confusuario2 ON confusuario.usu_codigo= confusuario2.usu_codigo " +
                              " WHERE  $x  LIMIT 100 ";
            
            sentencia = sentencia.Replace("$x", condicion);
            dt = dataBase.fDataTable(sentencia);
            dataBase.cerrarConexion();
            return dt;
        }

        public bool existeUsuario2(string codUsu) {
            bool centinela = false;
            DataTable dt;
            sentencia = null;
            sentencia = "SELECT usu_nombre FROM confusuario WHERE usu_codigo='$usu_codigo';";
            sentencia = sentencia.Replace("$usu_codigo", codUsu);

            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0) {
                centinela = true;
            }
            dataBase.cerrarConexion();
            return centinela;
        }

        public string nombreCodUsu(string z) {
            DataTable dt;
            sentencia = null;
            string nombre = null;
            sentencia = "SELECT usu_codigo, usu_nombre FROM confusuario WHERE usu_codigo='$usu_codigo';";
            sentencia = sentencia.Replace("$usu_codigo", z);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count>0)
            {   
                nombre = dt.Rows[0]["usu_nombre"].ToString();
            }
            dataBase.cerrarConexion();
            return nombre;
        }
        public string nombreCodUsu(string z, int y)
        {
            string nombre = null;
            dataBase.modificarConexionString(y);
            nombre = nombreCodUsu(z);
            dataBase.modificarConexionString(1);
            return nombre;
        }

        public bool usuarioActivo(string codUsu)
        {
            bool centinela = false;
            sentencia = null;
            DataTable dt;
            dataBase.modificarConexionString(2);
            sentencia = "SELECT usu_status  FROM confusuario2  WHERE usu_codigo='$1'";
            sentencia = sentencia.Replace("$1", codUsu);
            dt = dataBase.fDataTable(sentencia);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["usu_status"].ToString().Equals("True"))
                {
                    centinela = true;
                }
            }
            dataBase.cerrarConexion();
            dataBase.modificarConexionString(1);
            return centinela;
        }


        public bool permisoDeCompania(string comp)
        {
            bool centinela = false;
            DataTable permisosUsuarioA;
            string[] arregloComp;

            permisosUsuarioA = this.permisosAdministracion();
            arregloComp = permisosUsuarioA.Rows[0]["usu_administracion"].ToString().Split('-');

            for (int y = 0; y < arregloComp.Length; y++)
            {
                if (comp.Equals(arregloComp[y]))
                {
                    centinela = true;
                    break;
                }
            }

            return centinela;
        }

        public DataTable permisosAdministracion()
        {
            sentencia = null;
            DataTable dt;
            dataBase.modificarConexionString(2);
            sentencia = "SELECT usu_administracion FROM confusuario2  WHERE usu_codigo='$usu_codigo';";
            sentencia = sentencia.Replace("$usu_codigo", this.id);
            dt = dataBase.fDataTable(sentencia);
            dataBase.modificarConexionString(1);
            dataBase.cerrarConexion();
            return dt;
        }


    }
}
