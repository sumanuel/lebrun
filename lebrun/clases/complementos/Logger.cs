using System;
using System.IO;
using System.Text;
using System.Configuration;

namespace lebrun.clases.complementos
{

    public static class Logger
    {
        private static string logs = ConfigurationManager.AppSettings.Get("logs");
        private static string logPath = @"C:\logs\"; // Ruta por defecto
        private static string logFileName = $"log_{DateTime.Now:yyyyMMdd}.txt";

        // Configurar la ruta de logs (opcional)
        public static void ConfigurarLogger(string ruta = null, string nombreArchivo = null)
        {
            if (!string.IsNullOrEmpty(ruta))
                logPath = ruta;

            if (!string.IsNullOrEmpty(nombreArchivo))
                logFileName = nombreArchivo;
        }

        // Método principal para escribir logs
        public static void EscribirLog(string mensaje, TipoLog tipo = TipoLog.Info)
        {
            try
            {
                if (Convert.ToInt32(logs) == 0)
                {
                    return;
                }
                // Crear directorio si no existe
                Directory.CreateDirectory(logPath);

                string fullLogPath = Path.Combine(logPath, logFileName);
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{tipo}] {mensaje}{Environment.NewLine}";

                File.AppendAllText(fullLogPath, logEntry);
            }
            catch (Exception ex)
            {
                // Fallback: escribir en consola si falla el archivo
                Console.WriteLine($"Error al escribir log: {ex.Message}");
            }
        }

        // Método para escribir logs con formato de bloque (para procesos)
        public static void EscribirLogProceso(string titulo, string contenido, TipoLog tipo = TipoLog.Info)
        {

            StringBuilder logContent = new StringBuilder();
            logContent.AppendLine($"=== {titulo.ToUpper()} - INICIO: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
            logContent.AppendLine(contenido);
            logContent.AppendLine($"=== {titulo.ToUpper()} - FIN: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
            logContent.AppendLine();

            EscribirLog(logContent.ToString(), tipo);
        }

        // Método para logs de bases de datos
        public static void LogOperacionBD(string operacion, string sentenciaSql, int filasAfectadas, bool exito = true, string error = "")
        {

            string mensaje = exito
                ? $"{operacion} exitosa. Filas afectadas: {filasAfectadas}. SQL: {sentenciaSql}"
                : $"{operacion} fallida. Error: {error}. SQL: {sentenciaSql}";

            EscribirLog(mensaje, exito ? TipoLog.Info : TipoLog.Error);
        }
    }

    // Enumerado para tipos de log
    public enum TipoLog
    {
        Info,
        Advertencia,
        Error,
        Debug,
        Critico
    }
}
