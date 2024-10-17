using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApiClient
{
    public class Logger
    {
        private static readonly string logFilePath = "application.log";

        public static void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        public static void LogWarning(string message)
        {
            Log(message, "WARNING");
        }

        public static void LogError(string message)
        {
            Log(message, "ERROR");
        }

        private static void Log(string message, string logLevel)
        {
            string logMessage = $"{DateTime.Now} [{logLevel}] {message}";

            // Log to console
            Console.WriteLine(logMessage);

            // Log to file
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
