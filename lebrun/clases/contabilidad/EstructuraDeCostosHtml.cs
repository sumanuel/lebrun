using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace lebrun.clases.contabilidad
{
    public  class EstructuraDeCostosHtml
    {
        DataSet dtsP;
        string nombreE;
        string fechaRe;
        StreamWriter writer;
        string rife;
        public EstructuraDeCostosHtml(DataSet dts, string nombre,string fecha, string rif) {
            dtsP = dts;
            nombreE = nombre;
            fechaRe = fecha;
            rife = rif;
        }
        
        public void reporte() {
            writer = new StreamWriter(Application.StartupPath+"\\estructuraCostos.html");
            writer.Write("<html>");
            writer.Write("<head>");
            writer.Write("<style type='text/css' media='print'>");
            writer.Write("div.page {");
            writer.Write("writing-mode: tb-rl;");
            writer.Write("height: 80%;");
            writer.Write("margin: 10% 0%;}");
            writer.Write("</style>");
            writer.Write("</head>");
            writer.Write("<body>");

            writer.Write("<center>");
            writer.Write("<font size='3'><b>");
            writer.Write("" + nombreE + "<br>");
            writer.Write("" + rife + "<br>");
            writer.Write("Estructura de Costos<br>");
            writer.Write("Al " + fechaRe);
            writer.Write("</b></font><br><br>");
            writer.Write("<table border=0 cellspacing=0>");
                  
            writer.Write("<tr>");
                writer.Write("<th> </th>");
                writer.Write("<th> </th>");
                writer.Write("<th>Datos Contables</th>");
                writer.Write("<th>Exclusiones Legales</th>");
                writer.Write("<th>Costos Segun LOPJ</th>");
            writer.Write("</tr>");
                foreach (DataRow fila in dtsP.Tables["DataTable1"].Rows)
                {
                    writer.Write("<tr>");
                    writer.Write("<td><font size=0.1>" + fila["cc_CodigoCuenta"].ToString() + "</font></td>");
                    if (fila["cc_Descripcion"].ToString().Contains("TOTAL"))
                    {
                        writer.Write("<td><b><font size=0.1>" + fila["cc_Descripcion"].ToString() + "</font></b></td>");
                        string saldoAct = Convert.ToDecimal(fila["saldoActual"].ToString()) > 0 ? String.Format("{0:0,0.00}", Convert.ToDecimal(fila["saldoActual"].ToString())) : String.Format("{0:0.00}", Convert.ToDecimal(fila["saldoActual"].ToString()));
                        writer.Write("<td align='right'><b><font size=0.1>" + saldoAct + "</font></b></td>");
                        writer.Write("<td align='right'><b><font size=0.1>" + String.Format("{0:0.00}",Convert.ToDecimal(fila["exclusiones"].ToString())) + "</font></b></td>");
                        string costos = Convert.ToDecimal(fila["costosLopj"].ToString()) > 0 ? String.Format("{0:0,0.00}", Convert.ToDecimal(fila["costosLopj"].ToString())) : String.Format("{0:0.00}", Convert.ToDecimal(fila["costosLopj"].ToString()));
                        writer.Write("<td align='right'><b><font size=0.1>" + costos + "</font></b></td>");
                    }
                    else
                    {
                        writer.Write("<td><font size=0.1>" + fila["cc_Descripcion"].ToString() + "</font></td>");
                        string saldoAct2 = Convert.ToDecimal(fila["saldoActual"].ToString()) > 0 ? String.Format("{0:0,0.00}", Convert.ToDecimal(fila["saldoActual"].ToString())) : String.Format("{0:0.00}", Convert.ToDecimal(fila["saldoActual"].ToString()));
                        writer.Write("<td align='right'><font size=0.1>" + saldoAct2 + "</font></td>");
                        writer.Write("<td align='right'><font size=0.1>" + String.Format("{0:0.00}", Convert.ToDecimal(fila["exclusiones"].ToString())) + "</font></td>");
                        string costos2 = Convert.ToDecimal(fila["costosLopj"].ToString()) > 0 ? String.Format("{0:0,0.00}", Convert.ToDecimal(fila["costosLopj"].ToString())) : String.Format("{0:0.00}", Convert.ToDecimal(fila["costosLopj"].ToString()));
                        writer.Write("<td align='right'><font size=0.1>" + costos2 + "</font></td>");
                    }
                    
                    writer.Write("</tr>");
                }
            writer.Write("</table>");
            writer.Write("</center>");
            writer.Write("<br>");
            writer.Write("<center>");
            writer.Write("<table border=0 cellspacing=0>");
            writer.Write("<tr>");
            writer.Write("<th colspan='3'>DETERMINACION DE COSTOS SEGUN LOPJ</th>");
            writer.Write("</tr>");
            foreach (DataRow f in dtsP.Tables["DataTable2"].Rows)
            {
                writer.Write("<tr>");
                writer.Write("<td align='left'><font size=0.1>" +  f["titulo"].ToString() + "</font></td>");
                writer.Write("<td align='right'><font size=0.1>" + String.Format("{0:0,0.00}",Convert.ToDecimal(f["monto"].ToString())) + "</font></td>");

                string ae = f["montoT"].ToString().Length==0 ? "" : String.Format("{0:0,0.00}", Convert.ToDecimal(f["montoT"].ToString()));
                writer.Write("<td align='right'><b><font size=0.1>" + ae + "</font></b></td>");
                writer.Write("</tr>");
            }
            writer.Write("</table>");
            writer.Write("</center>");
            writer.Write("<br>");


            writer.Write("</table>");
            writer.Write("</center>");
            writer.Write("<br>");
            writer.Write("<center>");
            writer.Write("<table border=0 cellspacing=0>");
            writer.Write("<tr>");
            writer.Write("<th colspan='2'>FACTOR DE INCIDENCIA DE COSTOS OPERATIVOS</th>");
            writer.Write("</tr>");
            foreach (DataRow f in dtsP.Tables["DataTable3"].Rows)
            {
                writer.Write("<tr>");
                writer.Write("<td align='left'><font size=0.1>" +  f["monto"].ToString() + "</font></td>");
                writer.Write("<td align='right'><font size=0.1>" + f["porcentaje"].ToString() + "</font></td>");
                writer.Write("</tr>");
            }
            writer.Write("</table>");
            writer.Write("</center>");

            writer.Write("</table>");
            writer.Write("</center>");
            writer.Write("<br>");
            writer.Write("<center>");
            writer.Write("<table border=0 cellspacing=0>");
            writer.Write("<tr>");
            writer.Write("<th colspan='3'>FACTOR DE INCIDENCIA DE PRECIOS</th>");
            writer.Write("</tr>");
            writer.Write("<tr>");
            writer.Write("<td align='left'><font size=0.1></font></td>");
            writer.Write("<th align='right'><font size=0.1>Base 1</font></th>");
            writer.Write("<th align='right'><font size=0.1>Base 2</font></th>");
            writer.Write("</tr>");
            foreach (DataRow f in dtsP.Tables["DataTable4"].Rows)
            {
                writer.Write("<tr>");
                writer.Write("<td align='left'><font size=0.1>" + f["titulo"].ToString() + "</font></td>");
                string base1 = Convert.ToDecimal(f["base1"].ToString()) >= 10 ? String.Format("{0:0,0.000}", Convert.ToDecimal(f["base1"].ToString())) : String.Format("{0:0.000}", Convert.ToDecimal(f["base1"].ToString()));
                writer.Write("<td align='right'><font size=0.1>" +base1 + "</font></td>");
                string base2 = Convert.ToDecimal(f["base1"].ToString()) >= 10 ? String.Format("{0:0,0.000}", Convert.ToDecimal(f["base2"].ToString())) : String.Format("{0:0.000}", Convert.ToDecimal(f["base2"].ToString()));
                writer.Write("<td align='right'><font size=0.1>" + base2 + "</font></td>");
                writer.Write("</tr>");
            }
            writer.Write("</table>");
            writer.Write("</center>");

            writer.Write("</body>");
            writer.Write("<html>");
            writer.Close();
        }

    }
}
