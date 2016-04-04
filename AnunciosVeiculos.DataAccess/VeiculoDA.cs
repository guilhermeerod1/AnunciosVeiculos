using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnunciosVeiculos.Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AnunciosVeiculos.DataAccess
{
    public class VeiculoDA
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["AnunciosVeiculos"].ConnectionString;

        public int InserirVeiculo(Veiculo v)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {

                    connection.ConnectionString = connectionString;

                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("INSERT INTO Veiculos (IdUsuario, IdModelo, Valor, AnoFabricacao, AnoModelo, Quilometragem, DataCadastro) ");
                    sb.Append("VALUES (@IdUsuario, @IdModelo, @Valor, @AnoFabricacao, @AnoModelo, @Quilometragem, @DataCadastro)");

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramIdUsuario = new SqlParameter("@IdUsuario", v.Usuario.IdUsuario);
                    SqlParameter paramIdModelo = new SqlParameter("@IdModelo", v.Modelo.IdModelo);
                    SqlParameter paramValor = new SqlParameter("@Valor", v.Valor);
                    SqlParameter paramAnoFabricacao = new SqlParameter("@AnoFabricacao", v.AnoFabricacao);
                    SqlParameter paramAnoModelo = new SqlParameter("@AnoModelo", v.AnoModelo);
                    SqlParameter paramQuilometragem = new SqlParameter("@Quilometragem", v.Quilometragem);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", v.DataCadastro);

                    command.Parameters.Add(paramIdUsuario);
                    command.Parameters.Add(paramIdModelo);
                    command.Parameters.Add(paramValor);
                    command.Parameters.Add(paramAnoFabricacao);
                    command.Parameters.Add(paramAnoModelo);
                    command.Parameters.Add(paramQuilometragem);
                    command.Parameters.Add(paramDataCadastro);

                    registrosAfetados = command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

            }

            return registrosAfetados;

        }

        public Veiculo RetornarVeiculo(int idVeiculo)
        {

            return RetornarVeiculos().FirstOrDefault(x => x.IdVeiculo == idVeiculo);

        }

        public int AtualizarVeiculo(Veiculo v)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("UPDATE Veiculos SET ");
                    sb.Append("IdUsuario = @IdUsuario, ");
                    sb.Append("IdModelo = @IdModelo, ");
                    sb.Append("Valor = @Valor, ");
                    sb.Append("AnoFabricacao = @AnoFabricacao, ");
                    sb.Append("AnoModelo = @AnoModelo, ");
                    sb.Append("Quilometragem = @Quilometragem, ");
                    sb.Append("DataCadastro = @DataCadastro ");
                    sb.Append("WHERE IdVeiculo = @IdVeiculo");

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramIdUsuario = new SqlParameter("@IdUsuario", v.Usuario.IdUsuario);
                    SqlParameter paramIdModelo = new SqlParameter("@IdModelo", v.Modelo.IdModelo);
                    SqlParameter paramValor = new SqlParameter("@Valor", v.Valor);
                    SqlParameter paramAnoFabricacao = new SqlParameter("@AnoFabricacao", v.AnoFabricacao);
                    SqlParameter paramAnoModelo = new SqlParameter("@AnoModelo", v.AnoModelo);
                    SqlParameter paramQuilometragem = new SqlParameter("@Quilometragem", v.Quilometragem);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", v.DataCadastro);
                    SqlParameter paramIdVeiculo = new SqlParameter("@IdVeiculo", v.IdVeiculo);

                    command.Parameters.Add(paramIdUsuario);
                    command.Parameters.Add(paramIdModelo);
                    command.Parameters.Add(paramValor);
                    command.Parameters.Add(paramAnoFabricacao);
                    command.Parameters.Add(paramAnoModelo);
                    command.Parameters.Add(paramQuilometragem);
                    command.Parameters.Add(paramDataCadastro);
                    command.Parameters.Add(paramIdVeiculo);

                    registrosAfetados = command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

            }

            return registrosAfetados;

        }

        public int RemoverVeiculo(int idVeiculo)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {

                    String sql = "DELETE FROM Veiculos WHERE IdVeiculo = @IdVeiculo";

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlParameter paramIdVeiculo = new SqlParameter("@IdVeiculo", idVeiculo);

                    command.Parameters.Add(paramIdVeiculo);

                    registrosAfetados = command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

            }

            return registrosAfetados;

        }

        public List<Veiculo> RetornarVeiculos()
        {

            List<Veiculo> listaVeiculos = null;

            using (SqlConnection connection = new SqlConnection())
            {

                String sql = "SELECT * FROM Veiculos";

                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        listaVeiculos = new List<Veiculo>();

                        while (reader.Read())
                        { 

                            Veiculo v = new Veiculo();

                            v.IdVeiculo = Convert.ToInt32(reader["IdVeiculo"]);
                            v.Usuario = new UsuarioDA().RetornarUsuario(Convert.ToInt32(reader["IdUsuario"]));
                            v.Modelo = new ModeloDA().RetornarModelo(Convert.ToInt32(reader["IdModelo"]));
                            v.Valor = Convert.ToDecimal(reader["Valor"]);
                            v.AnoFabricacao = Convert.ToInt32(reader["AnoFabricacao"]);
                            v.AnoModelo = Convert.ToInt32(reader["AnoModelo"]);
                            v.Quilometragem = Convert.ToInt32(reader["Quilometragem"]);
                            v.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);

                            listaVeiculos.Add(v);

                        }

                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

            }

            return listaVeiculos;

        }

    }
}
