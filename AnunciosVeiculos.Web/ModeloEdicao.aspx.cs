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
    public partial class ModeloEdicao : System.Web.UI.Page
    {
        
        private ModeloBO modeloBo = new ModeloBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {

                List<Marca> marcas = new MarcaBO().RetornarMarcas();

                if (marcas != null)
                {
                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataTextField = "Nome";
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataBind();
                }
                else
                {
                    Server.Transfer("MarcaEdicao.aspx");
                }

                string id = Page.Request.QueryString["Id"];

                if (string.IsNullOrEmpty(id))
                {
                    btnSalvar.Text = "Salvar novo";
                }
                else
                {
 
                    Modelo m = modeloBo.RetornarModelo(Convert.ToInt32(id));

                    txtNome.Text = m.Nome;
                    //ddlMarca.SelectedIndex = ddlMarca.Items.IndexOf(ddlMarca.Items.FindByValue(m.Marca.IdMarca.ToString()));

                    btnSalvar.Text = "Salvar edição";

                }

            }

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
                lblMensagem.Text = "Dados inválidos";
            }

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {

            limpar();

        }

        private void limpar()
        {

            txtNome.Text = string.Empty;
            ddlMarca.SelectedIndex = 0;

        }

        private bool validar()
        {

            return !(string.IsNullOrEmpty(txtNome.Text) || txtNome.Text.Length > 150);

        }

        private void salvar()
        {

            string id = Page.Request.QueryString["Id"];

            Modelo m = new Modelo();

            m.Nome = txtNome.Text;
            
            m.Marca = new MarcaBO().RetornarMarca(Convert.ToInt32(ddlMarca.SelectedValue));

            if (string.IsNullOrEmpty(id))
            {

                m.DataCadastro = DateTime.Now;

                modeloBo.InserirModelo(m);

            }
            else
            {

                m.IdModelo = Convert.ToInt32(id);
                m.DataCadastro = modeloBo.RetornarModelo(m.IdModelo).DataCadastro;

                modeloBo.AtualizarModelo(m);

            }

            limpar();

        }

    }
}