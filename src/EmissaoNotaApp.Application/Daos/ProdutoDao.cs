using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmissaoNotaApp.Application.Models;
using MySqlConnector;

namespace EmissaoNotaApp.Application.Daos
{
    public class ProdutoDao
    {
        private MySqlConnectionStringBuilder builder;

        public ProdutoDao()
        {
            builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Database = "EmissaoNotaApp",
                UserID = "root",
                Password = "emissaonotasapppwd@123",
                SslMode = MySqlSslMode.Required,
            };
        }

        public async Task Insert(Produto produto)
        {
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
             
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Produto (Codigo, Descricao) VALUES (@Codigo, @Descricao);";
                    command.Parameters.AddWithValue("@Codigo", produto.Codigo);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);

                    int rowCount = await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task Delete(long id)
        {
            using(var conn = new MySqlConnection(builder.ConnectionString))
            {

                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {

                    command.CommandText = "delete from Produto WHERE Id = @ID;";
                    command.Parameters.AddWithValue("@ID", id);

                    int rowCount = await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<Produto> Get(long id)
        {
            using(var conn = new MySqlConnection(builder.ConnectionString))
            {

                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {

                    command.CommandText = "SELECT * from Produto WHERE Id = @ID;";
                    command.Parameters.AddWithValue("@ID", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var produto = new Produto();
                        while(await reader.ReadAsync())
                        {
                            produto.Id = Convert.ToInt64(reader["Id"]);
                            produto.Codigo = reader["Codigo"].ToString();
                            produto.Descricao = reader["Descricao"].ToString();
                        }
                        return produto;
                    }


                }
            }
        }

        public async Task<List<Produto>> GetAll()
        {
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {

                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {

                    command.CommandText = "SELECT * from Produto";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var produtos = new List<Produto>();
                        while (await reader.ReadAsync())
                        {
                            var produto = new Produto();
                            produto.Id = Convert.ToInt64(reader["Id"]);
                            produto.Codigo = reader["Codigo"].ToString();
                            produto.Descricao = reader["Descricao"].ToString();
                            produtos.Add(produto);
                        }
                        return produtos;
                    }


                }
            }
        }
        public async Task Update(long id, string novoCodigo, string novaDescricao)
        {
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {

                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = @"UPDATE Produto SET Codigo = @Codigo, Descricao = @Descricao WHERE Id = @ID;";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Codigo", novoCodigo);
                    command.Parameters.AddWithValue("@Descricao", novaDescricao);

                    int rowCount = await command.ExecuteNonQueryAsync();

                }
            }
        }
    }
}

