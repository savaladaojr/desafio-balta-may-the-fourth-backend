using System;
using System.IO;
using System.Reflection;

public class Logger
{
    private readonly string logFilePath;

    public Logger(string logsFolderName = "Logs")
    {
        // Obtem o diretório atual do assembly executável
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var projectBasePath = Directory.GetParent(assemblyLocation).Parent.Parent.Parent.FullName;

        // Define o diretório de logs
        string logDirectory = Path.Combine(projectBasePath, logsFolderName);

        // Verifica se o diretório de logs existe, senão cria
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // Gera o nome do arquivo de log com a data e hora atual
        string fileName = $"appLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        logFilePath = Path.Combine(logDirectory, fileName);
    }

    public void Log(string message)
    {
        lock (logFilePath)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, append: true))
            {
                string logMessage = $"{DateTime.Now}: {message}";
                sw.WriteLine(logMessage);
                sw.Close();
            }
        }
    }
}

