using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lebrun.clasesData;
using System.Data;


namespace lebrun.clases.facturacion
{
    public class SerieFiscal
    {
        private string sentenciaSql;
        private ConexionBD databaseConection;
        private string ipMaquina;
        private string serieDocumento;
        private string serieImpresora;
        private string serial;
        private string seri_serie;
        private string serieAct;
        private string serieCaja;
        private bool serieActiva;
        private string serieUsuario;

        
        public string IpMaquina
        {
            get { return ipMaquina; }
            set { ipMaquina = value; }
        }
        public string SerieDocumento
        {
            get { return serieDocumento; }
            set { serieDocumento = value; }
        }
        public string SerieImpresora
        {
            get { return serieImpresora; }
            set { serieImpresora = value; }
        }
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        public string Seri_serie
        {
            get { return seri_serie; }
            set { seri_serie = value; }
        }
        public string SerieAct
        {
            get { return serieAct; }
            set { serieAct = value; }
        }
        public string SerieCaja
        {
            get { return serieCaja; }
            set { serieCaja = value; }
        }
        public bool SerieActiva
        {
            get { return serieActiva; }
            set { serieActiva = value; }
        }
        public string SerieUsuario
        {
            get { return serieUsuario; }
            set { serieUsuario = value; }
        }

        public SerieFiscal()
        {
            sentenciaSql = null;
            databaseConection = new ConexionBD();
        }

        public SerieFiscal(string ip)
        {
            sentenciaSql = null;
            databaseConection = new ConexionBD("200");
            this.ipMaquina = ip;
            numeroCaja("FAV");
        }
        
        public bool isPointFavEnabled() {
            sentenciaSql = null;
            DataTable dt;
            bool centinela = false;
            sentenciaSql = "SELECT seri_act FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_doc='FAV';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["seri_act"].ToString().Equals("Si")) {
                    centinela = true;
                }
            }
            
            databaseConection.cerrarConexion();
            return centinela;
        }

        public bool isPointDevEneabled()
        {
            sentenciaSql = null;
            DataTable dt;
            bool centinela = false;
            sentenciaSql = "SELECT seri_act FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_doc='DEV';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["seri_act"].ToString().Equals("Si"))
                {
                    centinela = true;
                }
            }

            databaseConection.cerrarConexion();
            return centinela;
        }
        
        public void numeroCaja(string tipoDoc) {
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = "SELECT seri_caja FROM  admseriefiscal WHERE seri_ip='@seri_ip' AND seri_doc='@seri_doc';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);
            sentenciaSql = sentenciaSql.Replace("@seri_doc", tipoDoc);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["seri_caja"].ToString() != null) {
                    this.serieCaja = dt.Rows[0]["seri_caja"].ToString();
                }
            }
            databaseConection.cerrarConexion();
        }

        public bool isActivate() {
            sentenciaSql = null;
            DataTable dt;
            bool centinela = false;

            sentenciaSql = "SELECT seri_open FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_doc='FAV';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (Convert.ToBoolean(Convert.ToInt16(dt.Rows[0]["seri_open"].ToString()))) {
                    centinela = true;
                }
            }
            databaseConection.cerrarConexion();
            return centinela;
        }

        public bool isActivate(string caja, string idUsuario) {
            bool centinela = false;
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = "SELECT seri_open FROM admseriefiscal WHERE seri_caja='?seri_caja' AND seri_user='?seri_user';";
            sentenciaSql = sentenciaSql.Replace("?seri_caja", caja);
            sentenciaSql = sentenciaSql.Replace("?seri_user", idUsuario);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["seri_open"].ToString().Equals("1")) {
                    centinela = true;
                }
            }
            databaseConection.cerrarConexion();
            return centinela;
        }

        public void setActivate(int val) {
            sentenciaSql = null;
            sentenciaSql = "UPDATE admseriefiscal SET seri_open=@seri_open WHERE seri_ip='@seri_ip' AND seri_doc='FAV';";
            sentenciaSql = sentenciaSql.Replace("@seri_open", "" + val);
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);
            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public string userConected() {
            sentenciaSql = null;
            DataTable dt;
            string usuario= null;

            sentenciaSql = "SELECT seri_user FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_caja='@seri_caja';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);
            sentenciaSql = sentenciaSql.Replace("@seri_caja", serieCaja);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["seri_user"].ToString() != null) {
                    usuario = dt.Rows[0]["seri_user"].ToString();
                }
            }
            databaseConection.cerrarConexion();

            return usuario;
        }

        public void cambiarUsuario(string cod) {
            sentenciaSql = null;

            sentenciaSql = "UPDATE admseriefiscal SET seri_user='@seri_user' WHERE seri_ip='@seri_ip';";
            sentenciaSql = sentenciaSql.Replace("@seri_user", cod);
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public bool isCierreCaja() {
            bool centinela = false;
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = "SELECT seri_cierreCaja FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_doc='FAV';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);
            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                if (Convert.ToBoolean(Convert.ToInt16(dt.Rows[0]["seri_cierreCaja"].ToString())))
                {
                    centinela = true;
                }
            }

            databaseConection.cerrarConexion();
            return centinela;
        }

        public void setCierreCaja(int val) {
            sentenciaSql = null;

            sentenciaSql = "UPDATE admseriefiscal SET seri_cierreCaja='@seri_cierreCaja' WHERE seri_ip='@seri_ip' AND seri_doc='FAV';";
            sentenciaSql = sentenciaSql.Replace("@seri_cierreCaja", ""+val);
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ipMaquina);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }

        public DataTable lbxSerieFis() {
            DataTable dt;
            sentenciaSql = null;

            sentenciaSql = "SELECT seri_ip,seri_impresora,seri_serial,seri_serie,seri_act,seri_caja FROM admseriefiscal LIMIT 100;";
            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;
        }

        public DataTable buscarLbxSeriFis(string campo, string valor) {
            DataTable dt;
            sentenciaSql = null;

            sentenciaSql = "SELECT seri_ip,seri_impresora,seri_serial,seri_serie,seri_act FROM admseriefiscal " +
                                  "WHERE $campo LIKE '%" + valor + "%' LIMIT 100;";
            sentenciaSql = sentenciaSql.Replace("$campo", campo);

            dt = databaseConection.fDataTable(sentenciaSql);
            databaseConection.cerrarConexion();
            return dt;

        }

        public bool existeSerieFiscal(string ip, string serie) {
            bool centinela = false;
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = "SELECT seri_ip FROM admseriefiscal WHERE seri_ip='@seri_ip' AND seri_serie='@seri_serie';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ip);
            sentenciaSql = sentenciaSql.Replace("@seri_serie", serie);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                centinela = true;
            }
            databaseConection.cerrarConexion();
            return centinela;
        }

        public void guardarSerieFiscal() {
            sentenciaSql = null;
            sentenciaSql = "INSERT INTO admseriefiscal(seri_ip,seri_doc,seri_impresora,seri_serial,seri_serie,seri_caja) VALUES( " +
                                    "'@seri_ip','@seri_doc','Epson LX300 +II','@seri_serial','@seri_serie','@seri_caja');";

            sentenciaSql = sentenciaSql.Replace("@seri_ip", this.ipMaquina);
            sentenciaSql = sentenciaSql.Replace("@seri_doc", this.serieDocumento);
            sentenciaSql = sentenciaSql.Replace("@seri_serial", this.Serial);
            sentenciaSql = sentenciaSql.Replace("@seri_serie", this.Seri_serie);
            sentenciaSql = sentenciaSql.Replace("@seri_caja", this.serieCaja);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
            return;
        }

        public void cargarSerieFiscal(string ip, string serie) {
            sentenciaSql = null;
            DataTable dt;

            sentenciaSql = "SELECT seri_doc,seri_impresora,seri_serial,seri_act,seri_caja FROM admseriefiscal " +
                                   "WHERE  seri_ip='@seri_ip' AND seri_serie='@seri_serie';";
            sentenciaSql = sentenciaSql.Replace("@seri_ip", ip);
            sentenciaSql = sentenciaSql.Replace("@seri_serie", serie);

            dt = databaseConection.fDataTable(sentenciaSql);
            if (dt.Rows.Count > 0) {
                this.ipMaquina = ip;
                this.seri_serie = serie;
                this.serieDocumento = dt.Rows[0]["seri_doc"].ToString();
                this.serieImpresora = dt.Rows[0]["seri_impresora"].ToString();
                this.Serial = dt.Rows[0]["seri_serial"].ToString();
                this.serieAct = dt.Rows[0]["seri_act"].ToString();
                this.serieCaja = dt.Rows[0]["seri_caja"].ToString();
            }
            databaseConection.cerrarConexion();
        }

        public void updateSerieFiscal() {
            sentenciaSql = null;

            sentenciaSql = "UPDATE admseriefiscal SET seri_serial='@seri_serial', seri_act='@seri_act', seri_caja='@seri_caja' WHERE seri_ip='@seri_ip' AND seri_serie='@seri_serie';";
            sentenciaSql = sentenciaSql.Replace("@seri_serial", this.serial);
            sentenciaSql = sentenciaSql.Replace("@seri_act", this.serieAct);
            sentenciaSql = sentenciaSql.Replace("@seri_caja", this.serieCaja);
            sentenciaSql = sentenciaSql.Replace("@seri_ip", this.ipMaquina);
            sentenciaSql = sentenciaSql.Replace("@seri_serie", this.Seri_serie);

            databaseConection.ejecutarInsert(sentenciaSql);
            databaseConection.cerrarConexion();
        }
    }
}
