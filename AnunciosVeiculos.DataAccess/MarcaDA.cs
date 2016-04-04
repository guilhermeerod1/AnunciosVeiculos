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
    public class MarcaDA
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["AnunciosVeiculos"].ConnectionString;

        public int InserirMarca(Marca m)
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

                    sb.Append("INSERT INTO Marcas (Nome, DataCadastro) ");
                    sb.Append("VALUES (@Nome, @DataCadastro)");

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", m.Nome);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", m.DataCadastro);

                    command.Parameters.Add(paramNome);
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

        public Marca RetornarMarca(int idMarca)
        {

            return RetornarMarcas().FirstOrDefault(x => x.IdMarca == idMarca);

        }

        public int AtualizarMarca(Marca m)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("UPDATE Marcas SET ");
                    sb.Append("Nome = @Nome, ");
                    sb.Append("DataCadastro = @DataCadastro ");
                    sb.Append("WHERE IdMarca = @IdMarca");

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", m.Nome);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", m.DataCadastro);
                    SqlParameter paramIdUsuario = new SqlParameter("@IdMarca", m.IdMarca);

                    command.Parameters.Add(paramNome);
                    command.Parameters.Add(paramDataCadastro);
                    command.Parameters.Add(paramIdUsuario);

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

        public int RemoverMarca(int idMarca)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {

                    String sql = "DELETE FROM Marcas WHERE IdMarca = @IdMarca";

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlParameter paramIdMarca = new SqlParameter("@IdMarca", idMarca);

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

        public List<Marca> RetornarMarcas()
        {

            List<Marca> listaMarcas = null;

            using (SqlConnection connection = new SqlConnection())
            {

                String sql = "SELECT * FROM Marcas";

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

                        listaMarcas = new List<Marca>();

                        while (reader.Read())
                        {

                            Marca m = new Marca();

                            m.IdMarca = Convert.ToInt32(reader["IdMarca"]);
                            m.Nome = Convert.ToString(reader["Nome"]);
                            m.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);

                            listaMarcas.Add(m);

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

            return listaMarcas;

        }

    }
}
