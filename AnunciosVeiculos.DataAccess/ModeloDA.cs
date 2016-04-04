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
    public class ModeloDA
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["AnunciosVeiculos"].ConnectionString;

        public int InserirModelo(Modelo m)
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

                    sb.Append("INSERT INTO Modelos (Nome, DataCadastro, IdMarca) ");
                    sb.Append("VALUES (@Nome, @DataCadastro, @IdMarca)");

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", m.Nome);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", m.DataCadastro);
                    SqlParameter paramIdMarca = new SqlParameter("@IdMarca", m.Marca.IdMarca);

                    command.Parameters.Add(paramNome);
                    command.Parameters.Add(paramDataCadastro);
                    command.Parameters.Add(paramIdMarca);

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

        public Modelo RetornarModelo(int idModelo)
        {

            return RetornarModelos().FirstOrDefault(x => x.IdModelo == idModelo);

        }

        public int AtualizarModelo(Modelo m)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("UPDATE Modelos SET ");
                    sb.Append("Nome = @Nome, ");
                    sb.Append("DataCadastro = @DataCadastro, ");
                    sb.Append("IdMarca = @IdMarca ");
                    sb.Append("WHERE IdModelo = @IdModelo");

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", m.Nome);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", m.DataCadastro);
                    SqlParameter paramIdMarca = new SqlParameter("@IdMarca", m.Marca.IdMarca);
                    SqlParameter paramIdModelo = new SqlParameter("@IdModelo", m.IdModelo);

                    command.Parameters.Add(paramNome);
                    command.Parameters.Add(paramDataCadastro);
                    command.Parameters.Add(paramIdMarca);
                    command.Parameters.Add(paramIdModelo);

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

        public int RemoverModelo(int idModelo)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {

                    String sql = "DELETE FROM Modelos WHERE IdModelo = @IdModelo";

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlParameter paramIdModelo = new SqlParameter("@IdModelo", idModelo);

                    command.Parameters.Add(paramIdModelo);

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

        public List<Modelo> RetornarModelos()
        {

            List<Modelo> listaModelos = null;

            using (SqlConnection connection = new SqlConnection())
            {

                String sql = "SELECT * FROM Modelos";

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

                        listaModelos = new List<Modelo>();

                        while (reader.Read())
                        {

                            Modelo m = new Modelo();

                            m.IdModelo = Convert.ToInt32(reader["IdModelo"]);
                            m.Nome = Convert.ToString(reader["Nome"]);
                            m.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                            m.Marca = new MarcaDA().RetornarMarca(Convert.ToInt32(reader["IdMarca"]));

                            listaModelos.Add(m);

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

            return listaModelos;

        }

    }
}
