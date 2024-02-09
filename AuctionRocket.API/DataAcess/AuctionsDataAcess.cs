using AuctionRocket.API.Domain.Entities;
using AuctionRocket.API.Domain.Enums;
using AuctionRocket.API.Utilities;
using Microsoft.Data.SqlClient;

namespace AuctionRocket.API.DataAcess;

public class AuctionsDataAcess
{
    string strConexao = "";

    public AuctionsDataAcess()
    {
        this.strConexao = new Connection().GetConnection();
    }

    public async Task<List<Auction>> GetActiveAuctions()
    {
        using (SqlConnection connection = new SqlConnection(this.strConexao))
        {
            try
            {
                await connection.OpenAsync();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Exec GetActiveAuctions";

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    List<Auction> ListAuctions = new();

                    while (await reader.ReadAsync())
                    {
                        Auction Auction = new Auction
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString() ?? "",
                            Starts = Convert.ToDateTime(reader["starts"]),
                            Ends = Convert.ToDateTime(reader["ends"])
                        };

                        ListAuctions.Add(Auction);
                    }

                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AuctionItem item = new AuctionItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Id_Auction = Convert.ToInt32(reader["id_Auction"]),
                                Name = reader["name"].ToString() ?? "",
                                Brand = reader["brand"].ToString() ?? "",
                                Condition = (Condition)Convert.ToInt32(reader["condition"]),
                                BasePrice = Convert.ToDecimal(reader["basePrice"])
                            };

                            if (ListAuctions.Exists(x => x.Id == item.Id_Auction) == true)
                            {
                                Auction Auction = ListAuctions.First(x => x.Id == item.Id_Auction);
                                Auction.Items.Add(item);
                            }                            
                        }
                    }

                    return ListAuctions;
                }
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