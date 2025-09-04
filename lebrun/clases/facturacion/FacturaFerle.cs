using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;


namespace lebrun.clases.facturacion
{
    public  class FacturaFerle
    {
        string textoDefaulFAV;
        string textoTxtFav;

        public const short FILE_ATTRIBUTE_NORMAL = 0x80;
        public const short INVALID_HANDLE_VALUE = -1;
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
            uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
            uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public FacturaFerle()
        {
            #region textoDefault
            textoDefaulFAV = @"










        %Cliente                                               %               %TipoDocumento% Nr.%NroDocum  %   Hora:%Hora    %
Rif:%NroRif              %   Nit:%NroNit              %                                  
%DireccFiscal1                                            %          FECHA   :%FechEmisi%
%DireccFiscal2                                            %                        
Z.P.:%ZP%        Tlf.:%ATLF%-%Telefono           %                               PEDIDO  : %NroPedido %
N/E.:%NOTAENTR%  Fec.N/E:%FECENTRE%                                    FORMA DE PAGO: %CondPago          % VENCIMIENTO:%FechVcmto%
TD:%TDAPL% Aplica:%NRODOCAP% Control:%NROCOFAC% %FECFAC% Monto:%MONFAC% TRANSPORTE: %Transporte        % VENDEDOR: %CV%
%DireccEnvio                                                    %


                                                                                                 %Vienen...%       %Vienen         %
%Cod1  %    %Un1 % %Desc1                                             %      %Cant1  %      %Prec1       %  %A1 %  %Tot1           %
%Cod2  %    %Un2 % %Desc2                                             %      %Cant2  %      %Prec2       %  %A2 %  %Tot2           % 
%Cod3  %    %Un3 % %Desc3                                             %      %Cant3  %      %Prec3       %  %A3 %  %Tot3           % 
%Cod4  %    %Un4 % %Desc4                                             %      %Cant4  %      %Prec4       %  %A4 %  %Tot4           % 
%Cod5  %    %Un5 % %Desc5                                             %      %Cant5  %      %Prec5       %  %A5 %  %Tot5           % 
%Cod6  %    %Un6 % %Desc6                                             %      %Cant6  %      %Prec6       %  %A6 %  %Tot6           % 
%Cod7  %    %Un7 % %Desc7                                             %      %Cant7  %      %Prec7       %  %A7 %  %Tot7           % 
%Cod8  %    %Un8 % %Desc8                                             %      %Cant8  %      %Prec8       %  %A8 %  %Tot8           % 
%Cod9  %    %Un9 % %Desc9                                             %      %Cant9  %      %Prec9       %  %A9 %  %Tot9           % 
%Cod10 %    %Un10% %Desc10                                            %      %Cant10 %      %Prec10      %  %A10%  %Tot10          % 
%Cod11 %    %Un11% %Desc11                                            %      %Cant11 %      %Prec11      %  %A11%  %Tot11          % 
%Cod12 %    %Un12% %Desc12                                            %      %Cant12 %      %Prec12      %  %A12%  %Tot12          % 
%Cod13 %    %Un13% %Desc13                                            %      %Cant13 %      %Prec13      %  %A13%  %Tot13          % 
%Cod14 %    %Un14% %Desc14                                            %      %Cant14 %      %Prec14      %  %A14%  %Tot14          % 
%Cod15 %    %Un15% %Desc15                                            %      %Cant15 %      %Prec15      %  %A15%  %Tot15          % 
%Cod16 %    %Un16% %Desc16                                            %      %Cant16 %      %Prec16      %  %A16%  %Tot16          % 
%Cod17 %    %Un17% %Desc17                                            %      %Cant17 %      %Prec17      %  %A17%  %Tot17          % 
%Cod18 %    %Un18% %Desc18                                            %      %Cant18 %      %Prec18      %  %A18%  %Tot18          % 
%Cod19 %    %Un19% %Desc19                                            %      %Cant19 %      %Prec19      %  %A19%  %Tot19          % 
%Cod20 %    %Un20% %Desc20                                            %      %Cant20 %      %Prec20      %  %A20%  %Tot20          % 
%Cod21 %    %Un21% %Desc21                                            %      %Cant21 %      %Prec21      %  %A21%  %Tot21          % 
%Cod22 %    %Un22% %Desc22                                            %      %Cant22 %      %Prec22      %  %A22%  %Tot22          % 
                   $bultosKilos                                                                               *raya
                                                                                                                          

Si cancela de contado al recibir la mercanc¡a o antes del %FecDcto1% tendr  un %Pd1% de Dcto. adicional
     Mto. Factura Bs.   %  MontoSubTotd1%       I.V.A. %PorIvd1%%    %   MontoIvad1%            Total a Pagar     %    MontoTotald1%
Si cancela de contado al recibir la mercanc¡a o antes del %FecDcto2% tendr  un %Pd2% de Dcto. adicional
     Mto. Factura Bs.   %  MontoSubTotd2%       I.V.A. %PorIvd2%%    %   MontoIvad2%            Total a Pagar     %    MontoTotald2%
      %cheques                                                                                   %
      BANCOS Y NUMEROS DE CUENTAS:  
      BCO.VENEZUELA-CC.01020462310005459384 BCO.CARIBE-CC.01140161991610041023
      BCO.MERCANTIL-CC.01050026591026449715 BANESCO   -CC.01340379153791008610

-Emitir cheque  $$  unicamente  a nombre  de  FERRETERIA  FERLE  C.A.
-Favor revisar la mercancia a su entrega.No aceptamos reclamos despues de 10 dias      %Van...%                    %MontoSubTotal  %
 habiles de haber sido recibida por el comprador. 
-Como prueba de cancelacion, solo aceptamos los  recibos  numerados de Ferreteria IVA%PorcIva%%       %MontoSubTotal2 %  %      MontoIva%
 Ferle C.A., firmados por la(s) persona(s)autorizada(s).
-Para todos los efectos legales y comerciales, se elige como domicilio especial a
 la ciudad de Caracas.                                                                                            %      MontoTotal%
-La Mercancia viaja por cuenta y riesgo del comprador.";
            #endregion
            textoDefaulFAV = textoDefaulFAV.Replace("$$", "" + '\u0022' + "NO ENDOSABLE" + '\u0022');

            textoTxtFav = File.ReadAllText(Application.StartupPath + "\\FAVFerle.txt");
        }


        public void imprimirFav(Factura fact1)
        {
            textoTxtFav = textoTxtFav.Replace("%Vienen         %", (new String(' ', 17)));
            textoTxtFav = textoTxtFav.Replace("%Vienen...%", (new String(' ', 11)));
            textoTxtFav = textoTxtFav.Replace("%Van...%", (new String(' ', 8)));
            textoTxtFav = textoTxtFav.Replace("%Vienen...%", (new String(' ', 9)));
            textoTxtFav = textoTxtFav.Replace("%Vienen         %", (new String(' ', 17)));
            cabeceraFav(fact1);
            detalleFav(fact1);
            totales(fact1);
            if (fact1.tienePP(fact1))
            {
                leyenda(true, fact1);
            }
            else
            {
                leyenda(false,fact1);
            }
            leyenda2(true);
            lpt();
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\FAVFerle.txt");
                sw.Write(textoTxtFav);
                sw.Close();
                //aqui imprimir!!
                platillaporDefecto();
            }
            catch (Exception e)
            { 

            }
        }

        public void imprimirDev(Factura fact1)
        {
            textoTxtFav = textoTxtFav.Replace("%Vienen         %", (new String(' ', 17)));
            textoTxtFav = textoTxtFav.Replace("%Vienen...%", (new String(' ', 11)));
            textoTxtFav = textoTxtFav.Replace("%Van...%", (new String(' ', 8)));
            textoTxtFav = textoTxtFav.Replace("%Vienen...%", (new String(' ', 9)));
            textoTxtFav = textoTxtFav.Replace("%Vienen         %", (new String(' ', 17)));
            cabeceraFav(fact1);
            detalleFav(fact1);
            totales(fact1);
            leyenda(false,fact1);
            leyenda2(false);
            lpt();
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\FAVFerle.txt");
                sw.Write(textoTxtFav);
                sw.Close();
                //aqui imprimir!!
                //planilla por defecto
                platillaporDefecto();
            }
            catch (Exception e)
            {

            }
        }

        private void cabeceraFav(Factura fact1)
        {
            string nombreCliente= null;
            string direccionFiscal = null;
            string direccionFiscal2 = null;
            string direccionEnvio = null;
            string condicionPago = null;
            decimal dias = 0;
            lebrun.clases.clientes.CondicionPago condP = new lebrun.clases.clientes.CondicionPago();
            DataTable dt = null;
            DateTime fechaVecimiento;

            dt = condP.lbxCondPag();

            if (dt.Rows.Count > 0)
            {
                condicionPago = dt.AsEnumerable().ToList().
                    Find(x => x.Field<string>("conp_codigo").Equals(fact1.ClienteFacturar.CondicionPago))
                    .Field<string>("conp_descripcion");

                dias = dt.AsEnumerable().ToList().
                    Find(x => x.Field<string>("conp_codigo").Equals(fact1.ClienteFacturar.CondicionPago))
                    .Field<decimal>("conp_cant_dias");
            }
            fechaVecimiento = DateTime.Now.AddDays(Convert.ToInt32(dias));

            //quitar ñ en el nombre del cliente
            fact1.ClienteFacturar.Nombre = fact1.ClienteFacturar.Nombre.Replace("ñ", "¥");
            fact1.ClienteFacturar.Nombre = fact1.ClienteFacturar.Nombre.Replace("Ñ", "¥");
            nombreCliente = fact1.ClienteFacturar.Nombre.Length > 50 ?
                fact1.ClienteFacturar.Nombre.Substring(0, 50) :
                fact1.ClienteFacturar.Nombre;

            //quitar ñ de Direccion Fiscal
            fact1.ClienteFacturar.Direccion = fact1.ClienteFacturar.Direccion.Replace("ñ", "¥");
            fact1.ClienteFacturar.Direccion = fact1.ClienteFacturar.Direccion.Replace("Ñ", "¥");
            direccionFiscal = fact1.ClienteFacturar.Direccion;

            //quitar ñ de Direccion Fiscal2
            fact1.ClienteFacturar.Direccion2 = fact1.ClienteFacturar.Direccion2.Replace("ñ", "¥");
            fact1.ClienteFacturar.Direccion2 = fact1.ClienteFacturar.Direccion2.Replace("Ñ", "¥");
            direccionFiscal2 = fact1.ClienteFacturar.Direccion2;

            //quitar ñ de Direccion Envio
            fact1.ClienteFacturar.DireccionEnvio = fact1.ClienteFacturar.DireccionEnvio.Replace("ñ", "¥");
            fact1.ClienteFacturar.DireccionEnvio = fact1.ClienteFacturar.DireccionEnvio.Replace("Ñ", "¥");
            direccionEnvio = fact1.ClienteFacturar.DireccionEnvio;

            textoTxtFav = textoTxtFav.Replace("%TipoDocumento%", fact1.TipoDocumento.Equals("FAV")?"FACTURA":"NOTA CREDITO");
            textoTxtFav = textoTxtFav.Replace("%NroDocum  %", fact1.CorrelativoInterno);
            textoTxtFav = textoTxtFav.Replace("%Hora    %", DateTime.Now.ToString("hh:mm"));
            
            textoTxtFav = textoTxtFav.Replace("%Cliente"+(new String(' ',47))+"%", 
                fact1.ClienteFacturar.Codigo+"-"+nombreCliente+
                (new String(' ', (56-(nombreCliente.Length+fact1.ClienteFacturar.Codigo.Length))))
                );

            textoTxtFav = textoTxtFav.Replace("%DireccFiscal1" + (new String(' ', 44)) + "%",
               direccionFiscal.Length>59?
               direccionFiscal.Substring(0,59)+
               (new String(' ',(59-(direccionFiscal.Length<59?direccionFiscal.Length:59)))):
               direccionFiscal+
               (new String(' ',(59-(direccionFiscal.Length<59?direccionFiscal.Length:59)))));

            textoTxtFav = textoTxtFav.Replace("%DireccFiscal2" + (new String(' ', 44)) + "%",
                direccionFiscal2.Length>59?
                direccionFiscal2.Substring(0, 59) +
                (new String(' ', (59 - ((direccionFiscal2.Length < 59 ? direccionFiscal2.Length : 59))))):
                direccionFiscal2+
                (new String(' ', (59 - ((direccionFiscal2.Length < 59 ? direccionFiscal2.Length : 59))))));

            textoTxtFav= textoTxtFav.Replace("%DireccEnvio"+ (new String(' ', 52)) + "%",
                direccionEnvio.Length>65?direccionEnvio.Substring(0,65):direccionEnvio);

            textoTxtFav = textoTxtFav.Replace("%NroRif              %", fact1.ClienteFacturar.Rif.Length > 0 ? fact1.ClienteFacturar.Rif : (new String(' ', 22)));
            textoTxtFav = textoTxtFav.Replace("%NroNit              %", fact1.ClienteFacturar.Nif.Length > 0 ? 
                fact1.ClienteFacturar.Nif+(new String(' ',(22-fact1.ClienteFacturar.Nif.Length)))
                : (new String(' ', 22)));
            
            textoTxtFav = textoTxtFav.Replace("%FechEmisi%", 
                DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')
                +"/"+DateTime.Now.Year.ToString());

            textoTxtFav = textoTxtFav.Replace("%CondPago          %", condicionPago.Length > 20 ?
                condicionPago.Substring(0, 20) : condicionPago
                + (new String(' ', (20 - condicionPago.Length))));

            textoTxtFav = textoTxtFav.Replace("%FechVcmto%", fechaVecimiento.Day.ToString().PadLeft(2,'0')+"/"+
                fechaVecimiento.Month.ToString().PadLeft(2,'0')+"/"+fechaVecimiento.Year);//mosca
            textoTxtFav = textoTxtFav.Replace("%Transporte        %",
                fact1.ClienteFacturar.Transporte.Length>20?fact1.ClienteFacturar.Transporte.Substring(0,20):
                fact1.ClienteFacturar.Transporte +
                (new String(' ',(20- fact1.ClienteFacturar.Transporte.Length>20?
                    (fact1.ClienteFacturar.Transporte.Substring(0,20)).Length:
                    fact1.ClienteFacturar.Transporte.Length))));

            textoTxtFav = textoTxtFav.Replace("%CV%", fact1.VendedorFactura.CodigoV.Substring(7));
            textoTxtFav = textoTxtFav.Replace("%NroPedido %", fact1.NumeroPedido);//verificar
            textoTxtFav = textoTxtFav.Replace("%ZP%", fact1.ClienteFacturar.ZonaPostal.ToString());            
            textoTxtFav = textoTxtFav.Replace("%ATLF%-%Telefono           %", fact1.ClienteFacturar.Telefono);
            textoTxtFav = textoTxtFav.Replace("%NOTAENTR%", (new String(' ', 10)));// va con el cuadrado si no me equivoco
            textoTxtFav = textoTxtFav.Replace("%FECENTRE%", (new String(' ', 10)));// va con el cuadrado si no me equivoco
            textoTxtFav = textoTxtFav.Replace("%TDAPL%", (new String(' ', 3)));
            textoTxtFav = textoTxtFav.Replace("%NRODOCAP%", (new String(' ', 10)));
            textoTxtFav = textoTxtFav.Replace("%NROCOFAC%", (new String(' ', 11)));
            textoTxtFav = textoTxtFav.Replace("%FECFAC%", (new String(' ', 10)));
            textoTxtFav = textoTxtFav.Replace("%MONFAC%", (new String(' ', 11)));

        }

        private void detalleFav(Factura fact1)
        {
            string codigo,unidad,descripcion,cantidad,precio,iva,total,raya,bultosPesos;
            raya = "------------------";
            bultosPesos = "Bultos:$    Kilos:#";

            for (int i = 0; i < fact1.DgvItems.Rows.Count; i++)
            {
                if (i < fact1.DgvItems.Rows.Count)
                {
                    codigo = null;
                    codigo = "%Cod" + (i+1);
                    codigo = codigo + (new String(' ', (7 - codigo.Length))) + "%";

                    unidad = null;
                    unidad = "%Un" + (i + 1);
                    unidad = unidad + (new String(' ', (5 - unidad.Length))) + "%";

                    descripcion = null;
                    descripcion = "%Desc" + (i + 1);
                    descripcion = descripcion + (new String(' ', (51 - descripcion.Length))) + "%";

                    cantidad = null;
                    cantidad = "%Cant" + (i + 1);
                    cantidad = cantidad + (new String(' ', (8 - cantidad.Length))) + "%";

                    precio = null;
                    precio = "%Prec" + (i + 1);
                    precio = precio + (new String(' ', (13 - precio.Length))) + "%";

                    iva = null;
                    iva = "%A" + (i + 1);
                    iva = iva + (new String(' ', (4 - iva.Length))) + "%";

                    total = null;
                    total = "%Tot" + (i+1);
                    total = total + (new String(' ', (16 - total.Length))) + "%";

                    textoTxtFav = textoTxtFav.Replace(codigo, 
                        fact1.DgvItems.Rows[i].Cells["@mov_codigo"].Value.ToString().Substring(6));

                    textoTxtFav = textoTxtFav.Replace(unidad,
                        fact1.DgvItems.Rows[i].Cells["@mov_undmed"].Value.ToString().Length>6?
                        fact1.DgvItems.Rows[i].Cells["@mov_undmed"].Value.ToString().Substring(0,5):
                        (new String(' ', (6 - fact1.DgvItems.Rows[i].Cells["@mov_undmed"].Value.ToString().Length)))+
                        fact1.DgvItems.Rows[i].Cells["@mov_undmed"].Value.ToString());

                    textoTxtFav = textoTxtFav.Replace(descripcion,
                        fact1.DgvItems.Rows[i].Cells["@mov_memo"].Value.ToString().Length>52?
                        fact1.DgvItems.Rows[i].Cells["@mov_memo"].Value.ToString().Substring(0,51):
                        (new String(' ', (52 - fact1.DgvItems.Rows[i].Cells["@mov_memo"].Value.ToString().Length)))+
                        fact1.DgvItems.Rows[i].Cells["@mov_memo"].Value.ToString());

                    textoTxtFav = textoTxtFav.Replace(cantidad,
                        fact1.DgvItems.Rows[i].Cells["@mov_cant"].Value.ToString().Length>9?
                        fact1.DgvItems.Rows[i].Cells["@mov_cant"].Value.ToString().Substring(0,8):
                        (new String(' ',(9-fact1.DgvItems.Rows[i].Cells["@mov_cant"].Value.ToString().Length)))+
                        fact1.DgvItems.Rows[i].Cells["@mov_cant"].Value.ToString());

                    textoTxtFav = textoTxtFav.Replace(precio,
                        (new String(' ',
                            (14 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_precio"].Value.ToString().Replace(".",","))).Length))) +
                            String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_precio"].Value.ToString().Replace(".", ","))));

                    textoTxtFav = textoTxtFav.Replace(iva,
                        (new String(' ',
                            (5 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_porciva"].Value.ToString().Replace(".", ","))).Length))) +
                            String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_porciva"].Value.ToString().Replace(".", ","))));
                    
                    textoTxtFav = textoTxtFav.Replace(total,
                        (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_total"].Value.ToString().Replace(".", ","))).Length))) +
                            String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[i].Cells["@mov_total"].Value.ToString().Replace(".", ","))));
                }
            }

            if (fact1.DgvItems.Rows.Count < 22)
            {
                int numeroLinea = fact1.DgvItems.Rows.Count + 1;
                
                total = null;
                total = "%Tot" + numeroLinea;
                total = total + (new String(' ', (16 - total.Length))) + "%";

                descripcion = null;
                descripcion = "%Desc" + numeroLinea;
                descripcion = descripcion + (new String(' ', (51 - descripcion.Length))) + "%";

                bultosPesos = bultosPesos.Replace("$", fact1.bultos);
                bultosPesos = bultosPesos.Replace("#", fact1.peso);

                textoTxtFav = textoTxtFav.Replace(total, raya);
                textoTxtFav = textoTxtFav.Replace(descripcion,bultosPesos);
                textoTxtFav = textoTxtFav.Replace("$bultosKilos", (new String(' ', 12)));
                textoTxtFav = textoTxtFav.Replace("*raya", (new String(' ', 5)));
                

                for (int i = fact1.DgvItems.Rows.Count; i <22 ; i++)
                {
                    codigo = null;
                    codigo = "%Cod" + (i+1);
                    codigo = codigo + (new String(' ', (7 - codigo.Length))) + "%";

                    unidad = null;
                    unidad = "%Un" + (i+1);
                    unidad = unidad + (new String(' ', (5 - unidad.Length))) + "%";

                    descripcion = null;
                    descripcion = "%Desc" + (i+1);
                    descripcion = descripcion + (new String(' ', (51 - descripcion.Length))) + "%";

                    cantidad = null;
                    cantidad = "%Cant" + (i+1);
                    cantidad = cantidad + (new String(' ', (8 - cantidad.Length))) + "%";

                    precio = null;
                    precio = "%Prec" + (i+1);
                    precio = precio + (new String(' ', (13 - precio.Length))) + "%";

                    iva = null;
                    iva = "%A" + (i+1);
                    iva = iva + (new String(' ', (4 - iva.Length))) + "%";

                    total = null;
                    total = "%Tot" + (i+1);
                    total = total + (new String(' ', (16 - total.Length))) + "%";

                    textoTxtFav = textoTxtFav.Replace(codigo, (new String(' ', 8)));
                    textoTxtFav = textoTxtFav.Replace(unidad, (new String(' ', 6)));
                    textoTxtFav = textoTxtFav.Replace(descripcion, (new String(' ', 52)));
                    textoTxtFav = textoTxtFav.Replace(cantidad, (new String(' ', 9)));
                    textoTxtFav = textoTxtFav.Replace(precio, (new String(' ', 14)));
                    textoTxtFav = textoTxtFav.Replace(iva, (new String(' ', 5)));
                    textoTxtFav = textoTxtFav.Replace(total, (new String(' ', 17)));
                }

            }
            else
            {
                bultosPesos = bultosPesos.Replace("$", fact1.bultos);
                bultosPesos = bultosPesos.Replace("#", fact1.peso);
                textoTxtFav = textoTxtFav.Replace("$bultosKilos", bultosPesos);
                textoTxtFav = textoTxtFav.Replace("*raya", raya);

            }
        }

        private void mensajeProntoPago()
        { 

        }

        private void totales(Factura fact1)
        {
            textoTxtFav = textoTxtFav.Replace("%PorcIva%", (new String(' ', (9 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[0].Cells["@mov_porciva"].Value.ToString().Replace(".", ","))).Length)))
                    + String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.DgvItems.Rows[0].Cells["@mov_porciva"].Value.ToString().Replace(".", ","))));

            if (fact1.TipoDocumento.ToUpper().Equals("DEV"))
            {
                textoTxtFav = textoTxtFav.Replace("%MontoSubTotal  %", (new String(' ', (16 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))).Length)))
                + "-"+String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%MontoSubTotal2 %", (new String(' ', (16 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))).Length)))
                    +"-"+ String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%      MontoIva%", (new String(' ', (15 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.IvaTotal.ToString().Replace(".", ","))).Length)))
                    +"-"+ String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.IvaTotal.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%      MontoTotal%",
                   (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalNeto.ToString().Replace(".", ","))).Length)))
                   +"-"+ String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalNeto.ToString().Replace(".", ","))));
            }
            else
            {
                textoTxtFav = textoTxtFav.Replace("%MontoSubTotal  %", (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))).Length)))
                    + String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%MontoSubTotal2 %", (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))).Length)))
                    + String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalBase.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%      MontoIva%", (new String(' ', (16 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.IvaTotal.ToString().Replace(".", ","))).Length)))
                    + String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.IvaTotal.ToString().Replace(".", ","))));

                textoTxtFav = textoTxtFav.Replace("%      MontoTotal%",
                   (new String(' ', (18 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalNeto.ToString().Replace(".", ","))).Length)))
                   + String.Format("{0:0,0.00}", Convert.ToDecimal(fact1.TotalNeto.ToString().Replace(".", ","))));
            }

        }

        private void leyenda(bool valor, Factura fact)
        {   
            DateTime fechaPP1 = DateTime.Now;
            DateTime fechaPP2 = DateTime.Now;
            decimal descuento = 0;
            decimal totalDescuento = 0;
            decimal totalNeto = 0;
            decimal totalNetoIva = 0;
            decimal granTotal = 0;
            decimal iva = Convert.ToDecimal(fact.DgvItems.Rows[0].Cells["@mov_porciva"].Value.ToString().Replace(".",","));
//Datos plantilla Ferle  - Cuentas bancos
            if (!valor)
            {
                textoTxtFav = textoTxtFav.Replace("Si cancela de contado al recibir la mercanc¡a o antes del %FecDcto1% tendr  un %Pd1% de Dcto. adicional",
                    (new String(' ', 105)));
                textoTxtFav = textoTxtFav.Replace("Mto. Factura Bs.   %  MontoSubTotd1%       I.V.A. %PorIvd1%%    %   MontoIvad1%            Total a Pagar     %    MontoTotald1%",
                    (new String(' ',127)));
                textoTxtFav = textoTxtFav.Replace("Si cancela de contado al recibir la mercanc¡a o antes del %FecDcto2% tendr  un %Pd2% de Dcto. adicional",
                    (new String(' ', 105)));
                textoTxtFav = textoTxtFav.Replace("Mto. Factura Bs.   %  MontoSubTotd2%       I.V.A. %PorIvd2%%    %   MontoIvad2%            Total a Pagar     %    MontoTotald2%",
                    (new String(' ', 127)));
                textoTxtFav = textoTxtFav.Replace("%cheques                                                                                   %",
                    (new String(' ',92)));
                textoTxtFav = textoTxtFav.Replace("BANCOS Y NUMEROS DE CUENTAS:  ",
                    (new String(' ', 30)));
                textoTxtFav = textoTxtFav.Replace("BCO.VENEZUELA-CC.01020462310005459384 BCO.CARIBE-CC.01140161991610041023",
                    (new String(' ', 72)));
                textoTxtFav = textoTxtFav.Replace("BCO.MERCANTIL-CC.01050026591026449715 BANESCO   -CC.01340379153791008610",
                    (new String(' ', 72)));
            }
            else
            {
                textoTxtFav = textoTxtFav.Replace("%cheques                                                                                   %", 
                    "Si su Cheque resulta devuelto por cualquier motivo debera Can.el monto mayor de la Factura");
                if (!(string.IsNullOrEmpty(fact.diasPP1)))
                {
                    if (Convert.ToInt32(fact.diasPP1) > 0)
                    {
                        descuento = Convert.ToDecimal(fact.porcentajePP1);
                        totalDescuento = (fact.TotalBase * descuento) / 100;
                        totalNeto = fact.TotalBase - totalDescuento;
                        totalNetoIva = (totalNeto * iva) / 100;
                        granTotal = totalNeto + totalNetoIva;

                        fechaPP1.AddDays(Convert.ToInt32(fact.diasPP1));
                        textoTxtFav = textoTxtFav.Replace("%FecDcto1%",
                            fechaPP1.Day.ToString().PadLeft(2, '0') + "/" + fechaPP1.Month.ToString().PadLeft(2, '0') + "/" + fechaPP1.Year);

                        textoTxtFav = textoTxtFav.Replace("%Pd1%",
                            (new String(' ', (5 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact.porcentajePP1.Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(fact.porcentajePP1.Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%  MontoSubTotd1%",
                            (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact.TotalBase.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(fact.TotalBase.ToString().Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%PorIvd1%%",
                            (new String(' ', (9 - String.Format("{0:0,0.00}",Convert.ToDecimal(iva.ToString().Replace(".",","))).Length)))
                            + String.Format("{0:0,0.00}",Convert.ToDecimal(iva.ToString().Replace(".",","))) + "%");

                        textoTxtFav = textoTxtFav.Replace("%   MontoIvad1%",
                            (new String(' ', (15 - String.Format("{0:0,0.00}", Convert.ToDecimal(totalNetoIva.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(totalNetoIva.ToString().Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%    MontoTotald1%",
                            (new String(' ', (18 - String.Format("{0:0,0.00}", Convert.ToDecimal(granTotal.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(granTotal.ToString().Replace(".", ","))));
                    }
                }

                if (!(string.IsNullOrEmpty(fact.diasPP2)))
                {
                    if (Convert.ToInt32(fact.diasPP2) > 0)
                    {
                        descuento = Convert.ToDecimal(fact.porcentajePP2);
                        totalDescuento = (fact.TotalBase * descuento) / 100;
                        totalNeto = fact.TotalBase - totalDescuento;
                        totalNetoIva = (totalNeto * iva) / 100;
                        granTotal = totalNeto + totalNetoIva;

                        fechaPP2.AddDays(Convert.ToInt32(fact.diasPP2));
                        textoTxtFav = textoTxtFav.Replace("%FecDcto2%",
                            fechaPP2.Day.ToString().PadLeft(2, '0') + "/" + fechaPP2.Month.ToString().PadLeft(2, '0') + "/" + fechaPP2.Year);

                        textoTxtFav = textoTxtFav.Replace("%Pd2%",
                            (new String(' ', (5 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact.porcentajePP2.Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(fact.porcentajePP2.Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%  MontoSubTotd2%",
                            (new String(' ', (17 - String.Format("{0:0,0.00}", Convert.ToDecimal(fact.TotalBase.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(fact.TotalBase.ToString().Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%PorIvd2%%",
                            (new String(' ', (9 - String.Format("{0:0,0.00}", Convert.ToDecimal(iva.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(iva.ToString().Replace(".", ","))) + "%");

                        textoTxtFav = textoTxtFav.Replace("%   MontoIvad2%",
                            (new String(' ', (15 - String.Format("{0:0,0.00}", Convert.ToDecimal(totalNetoIva.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(totalNetoIva.ToString().Replace(".", ","))));

                        textoTxtFav = textoTxtFav.Replace("%    MontoTotald2%",
                            (new String(' ', (18 - String.Format("{0:0,0.00}", Convert.ToDecimal(granTotal.ToString().Replace(".", ","))).Length)))
                            + String.Format("{0:0,0.00}", Convert.ToDecimal(granTotal.ToString().Replace(".", ","))));
                    }
                }
                else
                {
                    textoTxtFav = textoTxtFav.Replace("Si cancela de contado al recibir la mercanc¡a o antes del %FecDcto2% tendr  un %Pd2% de Dcto. adicional",
                    (new String(' ', 105)));
                    textoTxtFav = textoTxtFav.Replace("Mto. Factura Bs.   %  MontoSubTotd2%       I.V.A. %PorIvd2%%    %   MontoIvad2%            Total a Pagar     %    MontoTotald2%",
                        (new String(' ', 127)));
                }
            }
        }

        private void leyenda2(bool valor)
        {
            if (!(valor))
            { 
                textoTxtFav = textoTxtFav.Replace("-Emitir cheque  "+'\u0022'+"NO ENDOSABLE"+'\u0022'+"  unicamente  a nombre  de  FERRETERIA  FERLE  C.A.",
                    (new String(' ',81)));
                textoTxtFav = textoTxtFav.Replace("-Favor revisar la mercancia a su entrega.No aceptamos reclamos despues de 10 dias",
                    (new String(' ',81)));
                textoTxtFav = textoTxtFav.Replace("habiles de haber sido recibida por el comprador.",
                    (new String(' ',48)));
                textoTxtFav = textoTxtFav.Replace("-Como prueba de cancelacion, solo aceptamos los  recibos  numerados de Ferreteria",
                    (new String(' ',81)));
                textoTxtFav = textoTxtFav.Replace("Ferle C.A., firmados por la(s) persona(s)autorizada(s).",
                    (new String(' ',55)));
                textoTxtFav = textoTxtFav.Replace("-La Mercancia viaja por cuenta y riesgo del comprador.",
                    (new String(' ',54)));
            }

            /*
             * textoTxtFav = textoTxtFav.Replace("-Para todos los efectos legales y comerciales, se elige como domicilio especial a",
                    (new String(' ',81)));
                textoTxtFav = textoTxtFav.Replace("la ciudad de Caracas.",(new String(' ',21)));
                
             */
        }

        private void platillaporDefecto()
        { 
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\FAVFerle.txt");
                sw.Write(textoDefaulFAV);
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void lpt()
        {
            IntPtr ptr = CreateFile("LPT1", GENERIC_WRITE, 0,
                    IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            /* Is bad handle? INVALID_HANDLE_VALUE */
            if (ptr.ToInt32() == -1)
            {
                /* ask the framework to marshall the win32 error code to an exception */
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            else
            {
                FileStream lpt = new FileStream(ptr, FileAccess.ReadWrite);
                Byte[] buffer = new Byte[2048];
                //Check to see if your printer support ASCII encoding or Unicode.
                //If unicode is supported, use the following:
                //buffer = System.Text.Encoding.Unicode.GetBytes(Temp);
                buffer = System.Text.Encoding.ASCII.GetBytes(textoTxtFav);
                lpt.Write(buffer, 0, buffer.Length);
                lpt.Close();

            }
        }

    }
}
