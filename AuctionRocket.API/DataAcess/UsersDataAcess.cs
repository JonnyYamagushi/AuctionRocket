using AuctionRocket.API.Domain.Entities;
using AuctionRocket.API.Domain.Enums;
using AuctionRocket.API.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuctionRocket.API.DataAcess;

public class UsersDataAcess
{
    string strConexao = "";

    public UsersDataAcess()
    {
        this.strConexao = new Connection().GetConnection();
    }

    public async Task<bool> ExistUser(string Email)
    {
        using (SqlConnection connection = new SqlConnection(this.strConexao))
        {
            try
            {
                await connection.OpenAsync();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ExistUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", Email);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    bool Exist = false;

                    if(await reader.ReadAsync())
                    {
                        Exist = Convert.ToBoolean(reader[0]);
                    }

                    return Exist;
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

    public async Task<User?> GetUser(string Email)
    {
        using (SqlConnection connection = new SqlConnection(this.strConexao))
        {
            try
            {
                await connection.OpenAsync();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Exec GetUser @Email";

                cmd.Parameters.AddWithValue("@Email", Email);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    User? User = null;

                    if (await reader.ReadAsync())
                    {
                        User = new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString() ?? string.Empty,
                            Email = reader["email"].ToString() ?? string.Empty,
                        };
                    }

                    return User;
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
