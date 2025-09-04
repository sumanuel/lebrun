using System;
using lebrun.clases.facturacion;
using System.Windows.Forms;
using lebrun.clases.facturacion.SENIAT.clases;

public class DascomTallyPrinter
{
    private FiscalOperations printer;
    private string portName;

    public DascomTallyPrinter(string port = "COM1")
    {
        portName = port;
        printer = new FiscalOperations(portName);
    }

    // Verificar estado de la impresora
    public string EstadoImpresora()
    {
        try
        {
            if (!printer.Connect())
                return "Error de Comunicacion";

            string respuesta = printer.GetStatus();
            printer.Disconnect();

            // Interpretar códigos de estado (ajustar según manual de Dascom)
            return InterpretarEstado(respuesta);
        }
        catch
        {
            return "Error de Comunicacion";
        }
    }

    private string InterpretarEstado(string estado)
    {
        // Aquí debes mapear los códigos de estado de Dascom según el manual
        // Este es un ejemplo, ajusta según tu impresora
        if (estado.Contains("OK") || estado.Contains("00"))
            return "00"; // Todo bien

        if (estado.Contains("PAPEL") || estado.Contains("PAPER"))
            return "04"; // Sin papel

        if (estado.Contains("ERROR") || estado.Contains("FALLO"))
            return "08"; // Error fiscal

        if (estado.Contains("ABIERTO") || estado.Contains("OPEN"))
            return "01"; // Documento abierto

        return "99"; // Estado desconocido
    }

    // Imprimir Factura de Venta (FAV)
    public void ImprimirFAV(Factura fac, string montoPagado)
    {
        try
        {
            printer.Connect();

            // Abrir documento fiscal (F para factura)
            printer.OpenFiscalDocument("F");

            // Imprimir items
            foreach (DataGridViewRow row in fac.DgvItems.Rows)
            {
                if (row.Cells["codigo"].Value != null)
                {
                    string descripcion = row.Cells["descripcion"].Value.ToString();
                    decimal cantidad = Convert.ToDecimal(row.Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(row.Cells["precio"].Value);
                    string iva = "16.00"; // Ajustar según tasa de IVA

                    printer.PrintItem(descripcion, cantidad, precio, iva);
                }
            }

            // Imprimir pago
            decimal totalPagado = decimal.Parse(montoPagado);
            printer.PrintPayment("EFECTIVO", totalPagado);

            // Cerrar documento
            printer.CloseFiscalDocument();
            printer.Disconnect();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al imprimir: " + ex.Message);
        }
    }

    // Imprimir Devolución (DEV)
    public void ImprimirDEV(Factura fac, string montoPagado)
    {
        try
        {
            printer.Connect();

            // Abrir documento de devolución (ajustar comando según manual)
            printer.OpenFiscalDocument("D"); // D para devolución

            // Imprimir items con cantidades negativas
            foreach (DataGridViewRow row in fac.DgvItems.Rows)
            {
                if (row.Cells["codigo"].Value != null)
                {
                    string descripcion = "DEV " + row.Cells["descripcion"].Value.ToString();
                    decimal cantidad = -Convert.ToDecimal(row.Cells["cantidad"].Value); // Negativo para devolución
                    decimal precio = Convert.ToDecimal(row.Cells["precio"].Value);
                    string iva = "16.00";

                    printer.PrintItem(descripcion, cantidad, precio, iva);
                }
            }

            // Imprimir pago (negativo para devolución)
            decimal totalDevuelto = -decimal.Parse(montoPagado);
            printer.PrintPayment("EFECTIVO", totalDevuelto);

            printer.CloseFiscalDocument();
            printer.Disconnect();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al imprimir devolución: " + ex.Message);
        }
    }

    // Reporte Z (Cierre fiscal)
    public void ReporteZ()
    {
        try
        {
            printer.Connect();
            printer.FiscalClose();
            printer.Disconnect();
        }
        catch (Exception ex)
        {
            throw new Exception("Error en Reporte Z: " + ex.Message);
        }
    }

    // Cerrar documento fiscal abierto
    public void CerrarDocumentoFiscal()
    {
        try
        {
            printer.Connect();
            printer.CloseFiscalDocument();
            printer.Disconnect();
        }
        catch
        {
            // Ignorar errores al intentar cerrar
        }
    }
}