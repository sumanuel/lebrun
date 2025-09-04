using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace lebrun.clases.facturacion.SENIAT.clases
{
    public class DascomFiscalPrinter
    {
        private SerialPort serialPort;
        private bool isConnected = false;
        private string portName;

        // Constructor
        public DascomFiscalPrinter(string portName, int baudRate = 9600)
        {
            this.portName = portName;
            InitializeSerialPort(portName, baudRate);
        }

        private void InitializeSerialPort(string portName, int baudRate)
        {
            serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.RequestToSend,
                ReadTimeout = 5000,
                WriteTimeout = 5000
            };
        }

        // Conectar a la impresora
        public bool Connect()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    isConnected = true;
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar: {ex.Message}");
                return false;
            }
        }

        // Desconectar
        public void Disconnect()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                isConnected = false;
            }
        }

        // Enviar comando a la impresora (PROTEGIDO para que las clases heredadas puedan usarlo)
        protected string SendCommand(string command)
        {
            if (!isConnected)
            {
                if (!Connect()) return "ERROR: No conectado";
            }

            try
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();

                // Agregar caracteres de inicio y fin del comando
                string fullCommand = "\u0002" + command + "\u0003";

                serialPort.Write(fullCommand);

                // Leer respuesta
                Thread.Sleep(500); // Esperar para la respuesta
                string response = ReadResponse();

                return ProcessResponse(response);
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

        private string ReadResponse()
        {
            StringBuilder response = new StringBuilder();
            DateTime timeout = DateTime.Now.AddMilliseconds(serialPort.ReadTimeout);

            while (DateTime.Now < timeout)
            {
                if (serialPort.BytesToRead > 0)
                {
                    char c = (char)serialPort.ReadChar();
                    response.Append(c);

                    // Verificar si es el fin del mensaje (ETX)
                    if (c == '\u0003')
                        break;
                }
                Thread.Sleep(10);
            }

            return response.ToString();
        }

        private string ProcessResponse(string response)
        {
            // Remover caracteres de control STX y ETX
            response = response.Replace("\u0002", "").Replace("\u0003", "");
            return response.Trim();
        }
    }
}