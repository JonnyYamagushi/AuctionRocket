using System.Net;

namespace AuctionRocket.API.Utilities;

public static class Functions
{
    public static void EscreveLog(string metodo, string msg)
    {
        string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs", metodo);
        string logPath = Path.Combine(logDirectory, $"Log_{DateTime.Now:ddMMyyyyhhmmssfff}.txt");

        try
        {
            //Verifica se o diretório existe e cria
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            //Escreve no arquivo de log
            using (StreamWriter sw = new StreamWriter(logPath, false))
            {
                sw.Write(msg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao escrever no arquivo de log: {ex.Message}");
        }
    }


}