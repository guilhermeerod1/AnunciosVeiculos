using AnunciosVeiculos.DataAccess;
using AnunciosVeiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnunciosVeiculos.Bussiness
{
    public class UsuarioBO
    {

        private UsuarioDA usuarioDA;

        public UsuarioBO()
        {
            usuarioDA = new UsuarioDA();
        }

        public int InserirUsuario(Usuario u)
        {
            return usuarioDA.InserirUsuario(u);
        }

        public Usuario RetornarUsuario(int idUsuario)
        {
            return usuarioDA.RetornarUsuario(idUsuario);
        }

        public int AtualizarUsuario(Usuario u)
        {
            return usuarioDA.AtualizarUsuario(u);
        }

        public int RemoverUsuario(int idUsuario)
        {
            return usuarioDA.RemoverUsuario(idUsuario);
        }

        public List<Usuario> RetornarUsuarios()
        {
            return usuarioDA.RetornarUsuarios();
        }

    }

}
