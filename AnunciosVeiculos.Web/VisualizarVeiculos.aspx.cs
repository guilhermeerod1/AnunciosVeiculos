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
    public partial class VisualizarVeiculos : System.Web.UI.Page
    {

        private VeiculoBO veiculoBo = new VeiculoBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string id = Page.Request.QueryString["Id"];

                if (!string.IsNullOrEmpty(id))
                {
                    veiculoBo.RemoverVeiculo(Convert.ToInt32(id));
                }

            }

            List<Veiculo> veiculos = veiculoBo.RetornarVeiculos();

            if (veiculos != null)
            {
                RptVeiculos.DataSource = veiculos;
                RptVeiculos.DataBind();
            }
            else
            {
                lblMensagem.Text = "Nenhum registro.";
            }

        }

        protected void RptVeiculos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Veiculo veiculo = (Veiculo)e.Item.DataItem;

                Label lblId = (Label)e.Item.FindControl("lblId");
                Label lblUsuario = (Label)e.Item.FindControl("lblUsuario");
                Label lblModelo = (Label)e.Item.FindControl("lblModelo");
                Label lblValor = (Label)e.Item.FindControl("lblValor");
                Label lblAnoFabricacao = (Label)e.Item.FindControl("lblAnoFabricacao");
                Label lblAnoModelo = (Label)e.Item.FindControl("lblAnoModelo");
                Label lblQuilometragem = (Label)e.Item.FindControl("lblQuilometragem");
                Label lblDataCadastro = (Label)e.Item.FindControl("lblDataCadastro");
                HyperLink lnkEditar = (HyperLink)e.Item.FindControl("lnkEditar");
                HyperLink lnkDeletar = (HyperLink)e.Item.FindControl("lnkExcluir");

                lblId.Text = Convert.ToString(veiculo.IdVeiculo);
                lblUsuario.Text = veiculo.Usuario.Nome;
                lblModelo.Text = veiculo.Modelo.Nome;
                lblValor.Text = veiculo.Valor.ToString();
                lblAnoFabricacao.Text = veiculo.AnoFabricacao.ToString();
                lblAnoModelo.Text = veiculo.AnoModelo.ToString();
                lblQuilometragem.Text = veiculo.Quilometragem.ToString();
                lblDataCadastro.Text = veiculo.DataCadastro.ToString();

                lnkEditar.NavigateUrl = "~/VeiculoEdicao.aspx?Id=" + veiculo.IdVeiculo;
                lnkDeletar.NavigateUrl = "~/VisualizarVeiculos.aspx?Id=" + veiculo.IdVeiculo;

            }

        }

    }

}