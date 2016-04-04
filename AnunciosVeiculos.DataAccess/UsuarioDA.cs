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
    public class UsuarioDA
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["AnunciosVeiculos"].ConnectionString;

        public int InserirUsuario(Usuario u)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try {

                    connection.ConnectionString = connectionString;

                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("INSERT INTO Usuarios (Nome, Login, Senha, Email, DataCadastro) ");
                    sb.Append("VALUES (@Nome, @Login, @Senha, @Email, @DataCadastro)");

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", u.Nome);
                    SqlParameter paramLogin = new SqlParameter("@Login", u.Login);
                    SqlParameter paramSenha = new SqlParameter("@Senha", u.Senha);
                    SqlParameter paramEmail = new SqlParameter("@Email", u.Email);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", u.DataCadastro);

                    command.Parameters.Add(paramNome);
                    command.Parameters.Add(paramLogin);
                    command.Parameters.Add(paramSenha);
                    command.Parameters.Add(paramEmail);
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

        public Usuario RetornarUsuario(int idUsuario)
        {

            return RetornarUsuarios().FirstOrDefault(x => x.IdUsuario == idUsuario);            

        }

        public int AtualizarUsuario(Usuario u)
        {

            int registrosAfetados = 0;

            using (SqlConnection connection = new SqlConnection())
            {

                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    StringBuilder sb = new StringBuilder();

                    sb.Append("UPDATE Usuarios SET ");
                    sb.Append("Nome = @Nome, ");
                    sb.Append("Login = @Login, ");
                    sb.Append("Senha = @Senha, ");
                    sb.Append("Email = @Email, ");
                    sb.Append("DataCadastro = @DataCadastro ");
                    sb.Append("WHERE IdUsuario = @IdUsuario");

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sb.ToString();

                    SqlParameter paramNome = new SqlParameter("@Nome", u.Nome);
                    SqlParameter paramLogin = new SqlParameter("@Login", u.Login);
                    SqlParameter paramSenha = new SqlParameter("@Senha", u.Senha);
                    SqlParameter paramEmail = new SqlParameter("@Email", u.Email);
                    SqlParameter paramDataCadastro = new SqlParameter("@DataCadastro", u.DataCadastro);
                    SqlParameter paramIdUsuario = new SqlParameter("@IdUsuario", u.IdUsuario);

                    command.Parameters.Add(paramNome);
                    command.Parameters.Add(paramLogin);
                    command.Parameters.Add(paramSenha);
                    command.Parameters.Add(paramEmail);
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

        public int RemoverUsuario(int idUsuario)
        {

            int registrosAfetados = 0;

            using(SqlConnection connection = new SqlConnection())
            {

                try
                {

                    String sql = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlParameter paramIdUsuario = new SqlParameter("@IdUsuario", idUsuario);

                    command.Parameters.Add(paramIdUsuario);

                    registrosAfetados = command.ExecuteNonQuery();

                }
                catch(Exception e)
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

        public List<Usuario> RetornarUsuarios()
        {

            List<Usuario> listaUsuarios = null;

            using(SqlConnection connection = new SqlConnection())
            {

                String sql = "SELECT * FROM Usuarios";

                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {

                        listaUsuarios = new List<Usuario>();

                        while(reader.Read())
                        {

                            Usuario u = new Usuario();

                            u.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            u.Nome = Convert.ToString(reader["Nome"]);
                            u.Login = Convert.ToString(reader["Login"]);
                            u.Senha = Convert.ToString(reader["Senha"]);
                            u.Email = Convert.ToString(reader["Email"]);
                            u.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);

                            listaUsuarios.Add(u);

                        }

                    }

                }
                catch(Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

            }

            return listaUsuarios;

        }

    }
}
