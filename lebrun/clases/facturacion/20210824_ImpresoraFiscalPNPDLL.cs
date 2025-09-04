using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace lebrun.clases.facturacion
{
    public class ImpresoraFiscalPNPDLL
    {

        #region DECLARACIÓN DE LAS FUNCIONES de PNPDLL.DLL
        [DllImport("PNPDLL.dll")]
        public static extern string PFAbreNF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFabrefiscal(String Razon, String RIF);
        [DllImport("PNPDLL.dll")]
        public static extern string PFtotal();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepz();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepx();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrenglon(String Descripcion, String cantidad, String monto, String iva);
        [DllImport("PNPDLL.dll")]
        public static extern string PFabrepuerto(String numero);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcierrapuerto();
        [DllImport("PNPDLL.dll")]
        public static extern string PFDisplay950(String edlinea);
        
        [DllImport("PNPDLL.dll")]
        public static extern string PFLineaNF(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCierraNF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFCortar();
        [DllImport("PNPDLL.dll")]
        public static extern string PFTfiscal(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFparcial();
        [DllImport("PNPDLL.dll")]
        public static extern string PFSerial();
        [DllImport("PNPDLL.dll")]
        public static extern string PFtoteconomico();
        [DllImport("PNPDLL.dll")]
        public static extern string PFCancelaDoc(String edlinea, String monto);
        [DllImport("PNPDLL.dll")]
        public static extern string PFGaveta();
        [DllImport("PNPDLL.dll")]
        public static extern string PFDevolucion(String razon, String rif, String comp, String maqui, String fecha, String hora);
        [DllImport("PNPDLL.dll")]
        public static extern string PFSlipON();
        [DllImport("PNPDLL.dll")]
        public static extern string PFSLIPOFF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFestatus(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFreset();
        [DllImport("PNPDLL.dll")]
        public static extern string PFendoso(String campo1, String campo2, String campo3, String tipoendoso);
        [DllImport("PNPDLL.dll")]
        public static extern string PFvalida675(String campo1, String campo2, String campo3, String campo4);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCheque2(String mon, String ben, String fec, String c1, String c2, String c3, String c4, String campo1, String campo2);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcambiofecha(String edfecha, String edhora);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcambiatasa(String t1, String t2, String t3);
        [DllImport("PNPDLL.dll")]
        public static extern string PFBarra(String edbarra);
        [DllImport("PNPDLL.dll")]
        public static extern string PFVoltea();
        [DllImport("PNPDLL.dll")]
        public static extern string PFLeereloj();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepMemNF(String desf, String hasf, String modmem);
        [DllImport("PNPDLL.dll")]
        public static extern string PFRepMemoriaNumero(String desn, String hasn, String modmem);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCambtipoContrib(String tip);
        [DllImport("PNPDLL.dll")]
        public static extern string PFultimo();
        [DllImport("PNPDLL.dll")]
        public static extern string PFTipoImp(String edtexto);
        #endregion
        
        private string respuesta;
        public string fiscal;
        public string todo = null;

        public ImpresoraFiscalPNPDLL(){}

        private String inicializarPuertos()
        {
            //this.IpPuerto.CommPort = 1;
            return PFabrepuerto("1");
        }

        private String cerrar_puerto() {
            return PFcierrapuerto();
        }

        public void reporteX()
        {
            inicializarPuertos();
            PFrepx();
            cerrar_puerto();
        }

        public String statusN() {
            return PFestatus("N");
        }

        //por si lo requiere la impresora fiscal
        public void reporteZ()
        {
            inicializarPuertos();
            respuesta = null;
            //inicializarPuertos();
            respuesta = PFrepz();
            //puerto no abierto
            if (respuesta.Equals("NP"))
            {
                //1 por defecto
                respuesta = inicializarPuertos();
                if (respuesta.Equals("OK"))
                {
                    respuesta = PFrepz();
                }
            }
            cerrar_puerto();
        }

        public bool reporteZExterno()
        {
            reporteZ();
            return true;
        }

        public string estadoImpresora()
        {
            respuesta = null;
            string estado = null;
            inicializarPuertos();

            respuesta = statusN();
            if (respuesta.Equals("OK"))
            {
                String[] temp = ultimo().Split(',');
                estado = temp[3];

            }
            else {
                estado = "15";
            }

            cerrar_puerto();
            return estado;
        }

        //obtener el valor en string del ultimo comando
        public string ultimo()
        {
            return PFultimo();
        }

        //obtener serial
        public string serial() {
            return PFSerial();
        }

        public void imprimirFAV(Factura facturaImprimir, TextBox txtPag) {
            string cadenaItem = null;
            string cantidad = null;
            string precio = null;
            string codigo = null;
            string iva = null;
            string rif = null;
            string tipo = null;
            string vacio = null;
            short valor0 = 0;
            short valor01 = 0;
            string rayar = null;
            string direccionCliente = null;
            string telefono = null;
            string numeroInterno = null;
            decimal porDescuento = 0;
            string cadenaDescuentoItem = null;
            string descuentoGeneralFac = null;
            string pagado = null;
            string numeroImpresoraFiscal = null;

            respuesta = null;
            
            this.inicializarPuertos();
            codigo = facturaImprimir.ClienteFacturar.Nombre.Length >= 38 ? facturaImprimir.ClienteFacturar.Nombre.Substring(0, 37) : facturaImprimir.ClienteFacturar.Nombre;
            rif = facturaImprimir.ClienteFacturar.Rif;
            tipo = "F";
            vacio = "";
            rayar = "========================================";
            respuesta = PFabrefiscal(codigo,rif);
            
            if (respuesta.Equals("OK")) {
                foreach (DataGridViewRow fila in facturaImprimir.DgvItems.Rows) {
                    cadenaItem = null;
                    cantidad = null;
                    precio = null;
                    iva = null;

                    iva = Convert.ToString(fila.Cells["@mov_porciva"].Value).Replace(',','.');
                    iva = iva.Replace(".", "");
                    //iva = Convert.ToString(fila.Cells["@mov_porciva"].Value).Replace(",", "");
                    cantidad = Convert.ToString(fila.Cells["@mov_cant"].Value);
                    precio = Convert.ToString(fila.Cells["@mov_precio"].Value);
                    //precio = Convert.ToString(fila.Cells["@mov_precio"].Value).Replace(",", "");
                    //cadenaItem = (Convert.ToString(fila.Cells["@mov_codigo"].Value).Substring(5) + " " + Convert.ToString(fila.Cells["colProducto"].Value) + " " + Convert.ToString(fila.Cells["@mov_undmed"].Value));
                    cadenaItem = (Convert.ToString(fila.Cells["@mov_codigo"].Value).Substring(5));
                    if (Convert.ToString(fila.Cells["colProducto"].Value).Length >= 21)
                    {
                        cadenaItem = cadenaItem + " " + Convert.ToString(fila.Cells["colProducto"].Value).Substring(0, 20);
                    }
                    else
                    {
                        cadenaItem = cadenaItem + " " + Convert.ToString(fila.Cells["colProducto"].Value);
                    }
                    cadenaItem = cadenaItem + " " + Convert.ToString(fila.Cells["@mov_undmed"].Value);
                    porDescuento = porDescuento + Convert.ToDecimal(fila.Cells["@mov_desc"].Value.ToString().Replace(".", ","));
                    respuesta = null;
                    respuesta = PFrenglon(cadenaItem,cantidad, precio,iva);
                }
                //pagado = txtPag.Text.Replace(',','.');
                //PFCancelaDoc("", pagado);
                respuesta =PFparcial();


                respuesta = PFTfiscal(rayar);
                if (facturaImprimir.ClienteFacturar.Direccion.Length > 0)
                {
                    direccionCliente = "Direccion: " + facturaImprimir.ClienteFacturar.Direccion;
                    if (direccionCliente.Length >= 38)
                    {
                        direccionCliente = direccionCliente.Substring(0, 37);
                    }
                    else
                    {
                        direccionCliente = direccionCliente.Substring(0);
                    }
                    respuesta = PFTfiscal(direccionCliente);
                }
                if (facturaImprimir.ClienteFacturar.Telefono.Length > 0)
                {
                    telefono = "Tlf:" + facturaImprimir.ClienteFacturar.Telefono + " Vendedor:" + facturaImprimir.VendedorFactura.CodigoV;
                    //        public void imprimirFAV(Factura facturaImprimir, TextBox txtPag) y  public void imprimirDEV(Factura facturaImprimir, TextBox txtPag)           
                    //  telefono = "Rebaja IVA Dto.3085 GO.41239" 3%  le falta colocar el % de la rebaja, 12-9= 3 12-7=5
                    // telefono = "Rebaja IVA Dto.3085 GO.41239";
                    if (telefono.Length >= 38)
                    {
                        telefono = telefono.Substring(0, 37);
                    }
                    else
                    {
                        telefono = telefono.Substring(0);
                    }
                    respuesta = PFTfiscal(telefono);
                }
                numeroInterno = "Numero Interno: " + facturaImprimir.CorrelativoInterno;
                if (numeroInterno.Length >= 38)
                {
                    numeroInterno = numeroInterno.Substring(0, 37);
                }
                else
                {
                    numeroInterno = numeroInterno.Substring(0);
                }
                respuesta = PFTfiscal(numeroInterno);


                respuesta = PFtotal();
                respuesta = statusN();
                String[] temp2 = ultimo().Split(',');
                facturaImprimir.NumeroFiscal = temp2[9];
                respuesta = serial();
                String[] temp3 = ultimo().Split(',');
                facturaImprimir.SerieImpresora = temp3[2];
                //PFtotal();
                //se guarda el numero fical de una vez
                facturaImprimir.guardarNumeroFiscal();
                
                cerrar_puerto();
            }

        }


    }
}



