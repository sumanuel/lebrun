using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using lebrun.clasesData;

namespace lebrun.formularios.facturacion
{
    public partial class frmNetoMonedaExt : Form
    {
        private ConexionBD databaseConection;
        private string neto;
        public frmNetoMonedaExt()
        {
            InitializeComponent();
        }

        public frmNetoMonedaExt(string neto1)
        {
            InitializeComponent();
            neto = neto1;
            databaseConection = new ConexionBD();
            mostrarValores();
        }

        public void mostrarValores(){

            try
            {
                if (Convert.ToDecimal(neto) > 0)
                {
                    DataTable tablaDolar8;
                    DataTable tablaeuro8;

                    decimal valorDolar8 = 0;
                    decimal valorEuro8 = 0;

                    string sqldolar8 = "select histo_valor from admhistodivi where histo_moneda='$8' order by histo_fecha desc, histo_hora desc  limit 1";
                    string sqleuro8 = "select histo_valor from admhistodivi where histo_moneda='€8' order by histo_fecha desc, histo_hora desc  limit 1";


                    tablaDolar8 = databaseConection.fDataTable(sqldolar8);
                    tablaeuro8 = databaseConection.fDataTable(sqleuro8);

                    valorDolar8 = Convert.ToDecimal(tablaDolar8.Rows[0]["histo_valor"]);
                    valorEuro8 = Convert.ToDecimal(tablaeuro8.Rows[0]["histo_valor"]);

                    lbl_valorDolar.Text = valorDolar8.ToString();
                    lbl_ValorEuro.Text = valorEuro8.ToString();

                    txt_netoEuro.Text = (Convert.ToDecimal(neto) / valorEuro8).ToString("N2");
                    txt_netoDolar.Text = (Convert.ToDecimal(neto) / valorDolar8).ToString("N2");
                }
            }
            catch
            {

            }
        }

        private void limpiar()
        {
            lbl_valorDolar.Text = "0";
            lbl_ValorEuro.Text = "0";
            txt_netoEuro.Text = "0";
            txt_netoDolar.Text = "0";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }
    }
}
