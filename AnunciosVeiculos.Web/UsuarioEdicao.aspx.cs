using AnunciosVeiculos.Bussiness;
using AnunciosVeiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnunciosVeiculos.Web
{
    public partial class UsuarioEdicao : System.Web.UI.Page
    {

        private UsuarioBO usuarioBo = new UsuarioBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string id = Page.Request.QueryString["Id"];

                if(string.IsNullOrEmpty(id))
                {

                    btnSalvar.Text = "Salvar novo";

                }
                else
                {
                    
                    btnSalvar.Text = "Salvar edição";

                    Usuario u = usuarioBo.RetornarUsuario(Convert.ToInt32(id));

                    txtNome.Text = u.Nome;
                    txtLogin.Text = u.Login;
                    txtSenha.Text = u.Senha;
                    txtEmail.Text = u.Email;

                }

            }

        }
        
        protected void btnLimpar_Click(object sender, EventArgs e)
        {

            limpar();

        }

        private void limpar()
        {

            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }

        private void salvar()
        {

            string id = Page.Request.QueryString["Id"];

            Usuario u = new Usuario();

            u.Nome = txtNome.Text;
            u.Login = txtLogin.Text;
            u.Senha = txtSenha.Text;
            u.Email = txtEmail.Text;

            if(string.IsNullOrEmpty(id))
            {

                u.DataCadastro = DateTime.Now;

                usuarioBo.InserirUsuario(u);

            }
            else
            {

                u.IdUsuario = Convert.ToInt32(id);
                u.DataCadastro = usuarioBo.RetornarUsuario(u.IdUsuario).DataCadastro;

                usuarioBo.AtualizarUsuario(u);

            }

        }

        private bool validar()
        {

            bool valido = true;

            if (string.IsNullOrEmpty(txtNome.Text) || txtNome.Text.Length > 150)
                valido = false;

            if (string.IsNullOrEmpty(txtLogin.Text) || txtLogin.Text.Length > 150)
                valido = false;

            if (string.IsNullOrEmpty(txtSenha.Text) || txtSenha.Text.Length > 150)
                valido = false;

            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text.Length > 150)
                valido = false;

            return valido;

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (validar())
            {
                salvar();
                limpar();
            }
            else
            {
                lblMensagem.Text = "Dados inválidos.";
            }

        }
    }
}