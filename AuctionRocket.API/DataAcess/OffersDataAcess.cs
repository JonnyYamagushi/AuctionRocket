using AuctionRocket.API.Domain.Entities;
using AuctionRocket.API.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuctionRocket.API.DataAcess;

public class OffersDataAcess
{

    string strConexao = "";

    public OffersDataAcess()
    {
        this.strConexao = new Connection().GetConnection();
    }

    public async Task CreateOffer(Offer offer)
    {
        using (SqlConnection connection = new SqlConnection(this.strConexao))
        {
            try
            {
                await connection.OpenAsync();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CreateOffer";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Item", offer.Id_Item);
                cmd.Parameters.AddWithValue("@Id_User", offer.Id_User);
                cmd.Parameters.AddWithValue("@Price", offer.Price);

                offer.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
            catch (SqlException ex)
            {
                Functions.EscreveLog("AuctionsDataAcess/BuscaAuction", ex.Message);
                throw new Exception("Erro ao executar a consulta SQL.", ex);
            }
            catch (Exception ex)
            {
                Functions.EscreveLog("AuctionsDataAcess/BuscaAuction", ex.Message);
                throw new Exception("Erro desconhecido ao executar a consulta.", ex);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}
