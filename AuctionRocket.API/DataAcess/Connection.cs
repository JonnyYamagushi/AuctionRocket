namespace AuctionRocket.API.DataAcess;

public class Connection
{
    public string GetConnection(string Entidade = "")
    {
        try
        {
            var builder = WebApplication.CreateBuilder();
            string connString = builder.Configuration.GetConnectionString("Conn") ?? "";

            return connString;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
