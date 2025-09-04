using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace lebrun.clases.facturacion.SENIAT.clases
{
    public class FiscalPrinter
    {
        private SerialPort serialPort;
        private string portName = "COM1"; // Puerto serial por defecto
        private int baudRate = 9600;
        private Parity parity = Parity.None;
        private int dataBits = 8;
        private StopBits stopBits = StopBits.One;

        public FiscalPrinter(string port = "COM1")
        {
            portName = port;
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.ReadTimeout = 3000;
            serialPort.WriteTimeout = 3000;
        }
    }
}
