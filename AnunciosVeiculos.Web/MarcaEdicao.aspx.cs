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
    public partial class MarcaEdicao : System.Web.UI.Page
    {

        private MarcaBO marcaBo = new MarcaBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {

                string id = Request.QueryString["Id"];

                if (string.IsNullOrEmpty(id))
                {
                    btnSalvar.Text = "Salvar Novo";
                }
                else
                {
                    
                    Marca edicao = marcaBo.RetornarMarca(Convert.ToInt32(id));

                    txtNome.Text = edicao.Nome;

                    btnSalvar.Text = "Salvar edição";

                }

            }

            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (validar())
            {
                Salvar();
                Limpar();
            }
            else
            {
                lblMensagem.Text = "Dados inválidos";
            }

        }

        private bool validar()
        {
            return !(string.IsNullOrEmpty(txtNome.Text) || txtNome.Text.Length > 150);
        }

        private void Salvar()
        {

            string id = Page.Request.QueryString["Id"];

            Marca marca = new Marca();

            marca.Nome = txtNome.Text;

            if (string.IsNullOrEmpty(id))
            {

                marca.DataCadastro = DateTime.Now;

                marcaBo.InserirMarca(marca);

            }
            else
            {
                
                marca.IdMarca = Convert.ToInt32(id);
                marca.DataCadastro = marcaBo.RetornarMarca(marca.IdMarca).DataCadastro;

                marcaBo.AtualizarMarca(marca);

            }

            Limpar();

        }

        private void Limpar()
        {
            txtNome.Text = string.Empty;
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

    }
}