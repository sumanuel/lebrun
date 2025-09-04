using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxTM_FISCAL;
using AxMSCommLib;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace lebrun.clases.facturacion
{
    public class ImpresoraFiscal
    {

        private AxTM_FISCAL.AxTM950 Fiscal;
        private AxMSCommLib.AxMSComm IpPuerto;
        private string mensajeX;
        private string mensajeN;
        private string mensajeZ;
        private string mensajeT;
        private string respuesta;

        public ImpresoraFiscal(AxTM_FISCAL.AxTM950 referenciaFiscal, AxMSCommLib.AxMSComm referenciaPuerto)
        {
            this.Fiscal = referenciaFiscal;
            this.IpPuerto = referenciaPuerto;
            mensajeX="X";
            mensajeN= "N";
            mensajeZ= "Z";
            mensajeT = "T";
            respuesta = null;
        }

        private void inicializarPuertos() { 
            this.IpPuerto.CommPort=1;
            this.Fiscal.NPuerto=1;
        }

        public void reporteX() {
            inicializarPuertos();
            this.Fiscal.CierreDiario(ref this.mensajeX);
        }

        public void reporteZ() {
            inicializarPuertos();
            this.Fiscal.CierreDiario(ref this.mensajeZ);
        }

        public bool reporteZExterno() {
            inicializarPuertos();
            this.Fiscal.CierreDiario(ref this.mensajeZ);
            return true;
        }

        //solo por si acaso
        public bool requiereZ() {
            respuesta = null;
            bool centinela = false;

            this.Fiscal.StatusIF(ref mensajeN);
            respuesta = this.Fiscal.Resp_4;
            if ((respuesta.Equals("04")) || (respuesta.Equals("08"))) {
                centinela = true;
            }
            return centinela;
        }

        public string estadoImpresora() {

            string estado = null;
            try
            {
                this.Fiscal.StatusIF(ref this.mensajeN);
                estado = this.Fiscal.Resp_4;
            }
            catch (COMException e) { 
                if(( e.ErrorCode ==-2146828088) && (e.Message.Equals("Error de Comunicaion"))){
                    estado = e.Message;
                }
            }
            return estado;
        }

        public void imprimirFAV(Factura facturaImprimir, TextBox txtPag) {
            string cadenaItem = null;
            string cantidad= null;
            string precio = null;
            string codigo = null;
            string iva= null;
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
            string cadenaDescuentoItem= null;
            string descuentoGeneralFac = null;
            string pagado = null;
            string numeroImpresoraFiscal = null;
            
            inicializarPuertos();
            codigo = facturaImprimir.ClienteFacturar.Nombre.Length >= 38 ? facturaImprimir.ClienteFacturar.Nombre.Substring(0, 37) : facturaImprimir.ClienteFacturar.Nombre;
            rif = facturaImprimir.ClienteFacturar.Rif;
            tipo = "F";
            vacio = "";
            rayar = "========================================";

            this.Fiscal.CerrarCF();
            this.Fiscal.AbrirCF(ref codigo, ref rif,ref tipo,ref vacio, ref vacio,ref vacio,ref vacio);
            this.Fiscal.ObtenerSerial();
            numeroImpresoraFiscal = this.Fiscal.Resp_3;

            foreach(DataGridViewRow fila in  facturaImprimir.DgvItems.Rows){
                cadenaItem = null;
                cantidad = null;
                precio = null;
                iva= null;

                iva = Convert.ToString(fila.Cells["@mov_porciva"].Value).Replace(".", ",");
                cantidad = Convert.ToString(fila.Cells["@mov_cant"].Value);
                precio = Convert.ToString(fila.Cells["@mov_precio"].Value).Replace(".",",");
                //cadenaItem = (Convert.ToString(fila.Cells["@mov_codigo"].Value).Substring(5) + " " + Convert.ToString(fila.Cells["colProducto"].Value) + " " + Convert.ToString(fila.Cells["@mov_undmed"].Value));
                cadenaItem = (Convert.ToString(fila.Cells["@mov_codigo"].Value).Substring(5)); 
                if (Convert.ToString(fila.Cells["colProducto"].Value).Length >= 21)
                {
                    cadenaItem = cadenaItem +" "+ Convert.ToString(fila.Cells["colProducto"].Value).Substring(0, 20);
                }
                else {
                    cadenaItem = cadenaItem +" "+ Convert.ToString(fila.Cells["colProducto"].Value);
                }
                cadenaItem = cadenaItem + " "+Convert.ToString(fila.Cells["@mov_undmed"].Value);
                porDescuento = porDescuento+ Convert.ToDecimal(fila.Cells["@mov_desc"].Value.ToString().Replace(".",","));

                this.Fiscal.Item(ref cadenaItem, ref valor0, ref cantidad, ref precio, ref iva, ref valor0);
            }

           
            //this.Fiscal.SubTotal();

            //if ((porDescuento + facturaImprimir.DescuentoGeneral) > 0) { 
                
            //}

            pagado = txtPag.Text;
            //this.Fiscal.PagoCF(ref pagado);
            this.Fiscal.TotalizarCF();
            this.Fiscal.StatusIF(ref mensajeN);
            facturaImprimir.NumeroFiscal = this.Fiscal.Resp_10;
            if (this.Fiscal.ObtenerSerial()) {
                facturaImprimir.SerieImpresora = this.Fiscal.Resp_3;
            }

           this.Fiscal.ExtraItem(ref rayar, ref valor0);
           if (facturaImprimir.ClienteFacturar.Direccion.Length > 0) {
               direccionCliente = "Direccion: " + facturaImprimir.ClienteFacturar.Direccion;
               if (direccionCliente.Length >= 38)
               {
                   direccionCliente = direccionCliente.Substring(0, 37);
               }else{
                   direccionCliente = direccionCliente.Substring(0);
               }
               this.Fiscal.ExtraItem(ref direccionCliente, ref valor0);
           }

           if (facturaImprimir.ClienteFacturar.Telefono.Length > 0) {
               telefono = "Tlf:" + facturaImprimir.ClienteFacturar.Telefono + " Vendedor:" + facturaImprimir.VendedorFactura.CodigoV;
               //        public void imprimirFAV(Factura facturaImprimir, TextBox txtPag) y  public void imprimirDEV(Factura facturaImprimir, TextBox txtPag)           
               //  telefono = "Rebaja IVA Dto.3085 GO.41239" 3%  le falta colocar el % de la rebaja, 12-9= 3 12-7=5
              // telefono = "Rebaja IVA Dto.3085 GO.41239";
               if (telefono.Length >= 38)
               {
                   telefono = telefono.Substring(0, 37);
               }else{
                   telefono = telefono.Substring(0);
               }
               this.Fiscal.ExtraItem(ref telefono, ref valor0);
           }

           numeroInterno = "Numero Interno: " + facturaImprimir.CorrelativoInterno;
           if (numeroInterno.Length >= 38)
           {
               numeroInterno = numeroInterno.Substring(0, 37);
           }
           else {
               numeroInterno = numeroInterno.Substring(0);
           }
           this.Fiscal.ExtraItem(ref numeroInterno, ref valor0);



            this.Fiscal.CerrarCF();
            //se guarda el numero fical de una vez
            facturaImprimir.guardarNumeroFiscal();
        }


        public void imprimirDEV(Factura facturaImprimir, TextBox txtPag)
        {
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
            string numeroFiscalAfec = null;
            string serialAfec = null;
            string fechaAfec = null;
            string horaAfec = null;
            
            inicializarPuertos();
            codigo = facturaImprimir.ClienteFacturar.Nombre.Length >= 38 ? facturaImprimir.ClienteFacturar.Nombre.Substring(0, 37) : facturaImprimir.ClienteFacturar.Nombre;
            rif = facturaImprimir.ClienteFacturar.Rif;
            if (facturaImprimir.NumeroFiscalAfectado != null)
            {
                numeroFiscalAfec = facturaImprimir.NumeroFiscalAfectado;
            }
            if (facturaImprimir.EocAfectado != null)
            {
                serialAfec = facturaImprimir.EocAfectado;
            }
            if (facturaImprimir.FechaAfectada != null)
            {
                fechaAfec = facturaImprimir.FechaAfectada.Replace("-", "/");
            }
            if (facturaImprimir.HoraAfectada != null)
            {
                horaAfec = facturaImprimir.HoraAfectada.Substring(0,5);
                //03:13:46 p.m.
            }
            tipo = "D";
            vacio = "";
            rayar = "========================================";

            this.Fiscal.CerrarCF();
            //this.Fiscal.AbrirCF(ref codigo, ref rif, ref tipo, ref vacio, ref vacio, ref vacio, ref vacio);
            this.Fiscal.AbrirCF(ref codigo, ref rif, ref tipo, ref numeroFiscalAfec, ref serialAfec, ref fechaAfec, ref horaAfec);
            if (this.Fiscal.ObtenerSerial())
            {
                facturaImprimir.SerieImpresora = this.Fiscal.Resp_3;
                numeroImpresoraFiscal = facturaImprimir.SerieImpresora;
            }
            //this.Fiscal.ObtenerSerial();
            numeroImpresoraFiscal = this.Fiscal.Resp_3;


            foreach (DataGridViewRow fila in facturaImprimir.DgvItems.Rows)
            {
                cadenaItem = null;
                cantidad = null;
                precio = null;
                iva = null;

                iva = Convert.ToString(fila.Cells["@mov_porciva"].Value).Replace(".", ",");
                cantidad = Convert.ToString(fila.Cells["@mov_cant"].Value);
                precio = Convert.ToString(fila.Cells["@mov_precio"].Value).Replace(".", ",");
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

                this.Fiscal.Item(ref cadenaItem, ref valor0, ref cantidad, ref precio, ref iva, ref valor0);
            }
            
            this.Fiscal.TotalizarCF();
            
            this.Fiscal.ExtraItem(ref rayar, ref valor0);
            //this.Fiscal.SubTotal();

            descuentoGeneralFac = Convert.ToString((1 - (0.000001) / 100));
            this.Fiscal.DescuentoCF(ref descuentoGeneralFac);
            pagado = txtPag.Text;
            //this.Fiscal.PagoCF(ref pagado);

            if (facturaImprimir.ClienteFacturar.Direccion.Length > 0)
            {
                direccionCliente = "Direccion: " + facturaImprimir.ClienteFacturar.Direccion;
                if (direccionCliente.Length >= 37)
                {
                    direccionCliente = direccionCliente.Substring(0, 37);
                }
                else
                {
                    direccionCliente = direccionCliente.Substring(0);
                }
                this.Fiscal.ExtraItem(ref direccionCliente, ref valor0);
            }

            if (facturaImprimir.ClienteFacturar.Telefono.Length > 0)
            {
                telefono = "Tlf:" + facturaImprimir.ClienteFacturar.Telefono + " Vendedor:" + facturaImprimir.VendedorFactura.CodigoV;
                if (telefono.Length >= 38)
                {
                    telefono = telefono.Substring(0, 37);
                }
                else
                {
                    telefono = telefono.Substring(0);
                }
                this.Fiscal.ExtraItem(ref telefono, ref valor0);
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
            this.Fiscal.ExtraItem(ref numeroInterno, ref valor0);
            
            this.Fiscal.StatusIF(ref mensajeT);
            facturaImprimir.NumeroFiscal = this.Fiscal.Resp_8;
            this.Fiscal.CerrarCF();
            //se guarda el numero fical de una vez
            facturaImprimir.guardarNumeroFiscal();
        }

        public void cerrarDocumentoFiscal()
        {
            this.Fiscal.CerrarCF();
        }

        //usada en mision vivienda
        public void imprimirFAV(Factura facturaImprimir, TextBox txtPag, string numeroCer, string dirObra)
        {
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
            string numeroCer1 = null;
            string decreto = null;
            string dirO = null;

            inicializarPuertos();
            codigo = facturaImprimir.ClienteFacturar.Nombre.Length >= 38 ? facturaImprimir.ClienteFacturar.Nombre.Substring(0, 37) : facturaImprimir.ClienteFacturar.Nombre;
            rif = facturaImprimir.ClienteFacturar.Rif;
            tipo = "F";
            vacio = "";
            rayar = "========================================";
            decreto = "Venta execta segun decreto Nr 8174 del 30-04-11";
            numeroCer1 = "certificado Nr.:" + numeroCer;
            dirO = "Dir Obra:" + dirObra;

            this.Fiscal.CerrarCF();
            this.Fiscal.AbrirCF(ref codigo, ref rif, ref tipo, ref vacio, ref vacio, ref vacio, ref vacio);
            this.Fiscal.ObtenerSerial();
            numeroImpresoraFiscal = this.Fiscal.Resp_3;

            foreach (DataGridViewRow fila in facturaImprimir.DgvItems.Rows)
            {
                cadenaItem = null;
                cantidad = null;
                precio = null;
                iva = null;

                iva = Convert.ToString(fila.Cells["@mov_porciva"].Value).Replace(".", ",");
                cantidad = Convert.ToString(fila.Cells["@mov_cant"].Value);
                precio = Convert.ToString(fila.Cells["@mov_precio"].Value).Replace(".", ",");
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

                this.Fiscal.Item(ref cadenaItem, ref valor0, ref cantidad, ref precio, ref iva, ref valor0);
            }

           
            //this.Fiscal.SubTotal();

            //if ((porDescuento + facturaImprimir.DescuentoGeneral) > 0) { 

            //}

            /*pagado = txtPag.Text;
            this.Fiscal.PagoCF(ref pagado);*/
            this.Fiscal.TotalizarCF();
            this.Fiscal.StatusIF(ref mensajeN);
            facturaImprimir.NumeroFiscal = this.Fiscal.Resp_10;
            if (this.Fiscal.ObtenerSerial())
            {
                facturaImprimir.SerieImpresora = this.Fiscal.Resp_3;
            }

            this.Fiscal.ExtraItem(ref dirO, ref valor0);
            this.Fiscal.ExtraItem(ref decreto, ref valor0);
            this.Fiscal.ExtraItem(ref numeroCer1, ref valor0);

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
                this.Fiscal.ExtraItem(ref direccionCliente, ref valor0);
            }

            if (facturaImprimir.ClienteFacturar.Telefono.Length > 0)
            {
                telefono = "Tlf:" + facturaImprimir.ClienteFacturar.Telefono + " Vendedor:" + facturaImprimir.VendedorFactura.CodigoV;
                if (telefono.Length >= 38)
                {
                    telefono = telefono.Substring(0, 37);
                }
                else
                {
                    telefono = telefono.Substring(0);
                }
                this.Fiscal.ExtraItem(ref telefono, ref valor0);
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
            this.Fiscal.ExtraItem(ref numeroInterno, ref valor0);



            this.Fiscal.CerrarCF();
            //se guarda el numero fical de una vez
            facturaImprimir.guardarNumeroFiscal();
        }
    }
}
