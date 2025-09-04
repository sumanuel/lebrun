using System;

namespace lebrun.clases.facturacion.SENIAT.clases
{
    public class FiscalOperations : DascomFiscalPrinter
    {
        public FiscalOperations(string portName) : base(portName) { }

        // Abrir documento fiscal
        public string OpenFiscalDocument(string docType = "T")
        {
            // T: Ticket, F: Factura, etc.
            string command = $"AbrirComprobante|{docType}";
            return SendCommand(command);
        }

        // Cerrar documento fiscal
        public string CloseFiscalDocument()
        {
            string command = "CerrarComprobante";
            return SendCommand(command);
        }

        // Imprimir item
        public string PrintItem(string description, decimal quantity, decimal price, string taxRate = "21.00")
        {
            string command = $"ImprimirItem|{description}|{quantity.ToString("F2")}|{price.ToString("F2")}|{taxRate}";
            return SendCommand(command);
        }

        // Imprimir pago
        public string PrintPayment(string paymentMethod, decimal amount)
        {
            string command = $"ImprimirPago|{paymentMethod}|{amount.ToString("F2")}";
            return SendCommand(command);
        }

        // Reporte X (Cierre diario)
        public string DailyClose()
        {
            string command = "ReporteX";
            return SendCommand(command);
        }

        // Reporte Z (Cierre fiscal)
        public string FiscalClose()
        {
            string command = "ReporteZ";
            return SendCommand(command);
        }

        // Consultar estado
        public string GetStatus()
        {
            string command = "ConsultarEstado";
            return SendCommand(command);
        }

        // Obtener número de último documento
        public string GetLastDocumentNumber()
        {
            string command = "ObtenerUltimoDoc";
            return SendCommand(command);
        }
    }
}