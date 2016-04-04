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
    public partial class VeiculoEdicao : System.Web.UI.Page
    {
        
        private VeiculoBO veiculoBo = new VeiculoBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                List<Modelo> modelos = new ModeloBO().RetornarModelos();

                if (modelos != null)
                {
                    ddlModelo.DataSource = modelos;
                    ddlModelo.DataTextField = "Nome";
                    ddlModelo.DataValueField = "IdModelo";
                    ddlModelo.DataBind();
                }
                else
                {
                    Server.Transfer("ModeloEdicao.aspx");
                }

                List<Usuario> usuarios = new UsuarioBO().RetornarUsuarios();

                if (usuarios != null)
                {
                    ddlUsuario.DataSource = usuarios;
                    ddlUsuario.DataTextField = "Nome";
                    ddlUsuario.DataValueField = "IdUsuario";
                    ddlUsuario.DataBind();
                }
                else
                {
                    Server.Transfer("UsuarioEdicao.aspx");
                }

                string id = Page.Request.QueryString["Id"];

                if (string.IsNullOrEmpty(id))
                {
                    btnSalvar.Text = "Salvar novo";
                }
                else
                {
                    
                    Veiculo v = veiculoBo.RetornarVeiculo(Convert.ToInt32(id));

                    txtValor.Text = v.Valor.ToString();
                    txtAnoFabricacao.Text = v.AnoFabricacao.ToString();
                    txtAnoModelo.Text = v.AnoModelo.ToString();
                    txtQuilometragem.Text = v.Quilometragem.ToString();

                    ddlModelo.SelectedIndex = ddlModelo.Items.IndexOf(ddlModelo.Items.FindByValue(v.Modelo.IdModelo.ToString()));
                    ddlUsuario.SelectedIndex = ddlUsuario.Items.IndexOf(ddlUsuario.Items.FindByValue(v.Usuario.IdUsuario.ToString()));

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
                lblMensagem.Text = "Dados inválidos.";
            }

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            txtValor.Text = string.Empty;
            txtAnoFabricacao.Text = string.Empty;
            txtAnoModelo.Text = string.Empty;
            txtQuilometragem.Text = string.Empty;
            ddlModelo.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
        }

        private bool validar()
        {

            int temp;
            bool valido = true;
            decimal t;

            if (string.IsNullOrEmpty(txtAnoFabricacao.Text) || !int.TryParse(txtAnoFabricacao.Text, out temp))
                valido = false;

            if (string.IsNullOrEmpty(txtAnoModelo.Text) || !int.TryParse(txtAnoModelo.Text, out temp))
                valido = false;

            if (string.IsNullOrEmpty(txtQuilometragem.Text) || !int.TryParse(txtQuilometragem.Text, out temp))
                valido = false;

            if (string.IsNullOrEmpty(txtValor.Text) || !Decimal.TryParse(txtValor.Text, out t))
                valido = false;

            return valido;

        }

        private void salvar()
        {

            string id = Page.Request.QueryString["Id"];

            Veiculo v = new Veiculo();

            v.Valor = Convert.ToDecimal(txtValor.Text);
            v.AnoFabricacao = Convert.ToInt32(txtAnoFabricacao.Text);
            v.AnoModelo = Convert.ToInt32(txtAnoModelo.Text);
            v.Quilometragem = Convert.ToInt32(txtQuilometragem.Text);
            
            v.Modelo = new ModeloBO().RetornarModelo(Convert.ToInt32(ddlModelo.SelectedValue));
            v.Usuario = new UsuarioBO().RetornarUsuario(Convert.ToInt32(ddlUsuario.SelectedValue));

            if (string.IsNullOrEmpty(id))
            {

                v.DataCadastro = DateTime.Now;

                veiculoBo.InserirVeiculo(v);

            }
            else
            {

                v.IdVeiculo = Convert.ToInt32(id);
                v.DataCadastro = veiculoBo.RetornarVeiculo(v.IdVeiculo).DataCadastro;

                veiculoBo.AtualizarVeiculo(v);

            }

        }

    }

}