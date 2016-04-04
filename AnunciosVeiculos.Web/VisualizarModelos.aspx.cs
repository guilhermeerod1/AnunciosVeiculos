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
    public partial class VisualizarModelos : System.Web.UI.Page
    {

        private ModeloBO modeloBo = new ModeloBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string id = Page.Request.QueryString["Id"];

                if(!string.IsNullOrEmpty(id))
                {
                    modeloBo.RemoverModelo(Convert.ToInt32(id));
                }

            }

            List<Modelo> modelos = modeloBo.RetornarModelos();

            if(modelos != null)
            {
                RptModelos.DataSource = modelos;
                RptModelos.DataBind();
            }
            else
            {
                lblMensagem.Text = "Nenhum registro.";
            }

        }

        protected void RptModelos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Modelo modelo = (Modelo)e.Item.DataItem;

                Label lblId = (Label)e.Item.FindControl("lblId");
                Label lblIdMarca = (Label)e.Item.FindControl("lblIdMarca");
                Label lblNomeMarca = (Label)e.Item.FindControl("lblNomeMarca");
                Label lblNome = (Label)e.Item.FindControl("lblNomeModelo");
                Label lblDataCadastro = (Label)e.Item.FindControl("lblDataCadastro");
                HyperLink lnkEditar = (HyperLink)e.Item.FindControl("lnkEditar");
                HyperLink lnkDeletar = (HyperLink)e.Item.FindControl("lnkExcluir");

                lblId.Text = Convert.ToString(modelo.IdModelo);
                lblIdMarca.Text = Convert.ToString(modelo.Marca.IdMarca);
                lblNomeMarca.Text = modelo.Marca.Nome;
                lblNome.Text = modelo.Nome;
                lblDataCadastro.Text = Convert.ToString(modelo.DataCadastro);

                lnkEditar.NavigateUrl = "~/ModeloEdicao.aspx?Id=" + modelo.IdModelo;
                lnkDeletar.NavigateUrl = "~/VisualizarModelos.aspx?Id=" + modelo.IdModelo;

            }

        }

    }

}