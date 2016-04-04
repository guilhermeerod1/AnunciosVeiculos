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
    public partial class VisualizarMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MarcaBO marcaBo = new MarcaBO();

            if(!Page.IsPostBack)
            {

                string id = Page.Request.QueryString["Id"];

                if (!string.IsNullOrEmpty(id))
                {
                    marcaBo.RemoverMarca(Convert.ToInt32(id));
                }

            }

            List<Marca> marcas = marcaBo.RetornarMarcas();

            if(marcas == null)
            {
                lblMensagem.Text = "Nenhum registro";
            } 
            else
            {
                RptMarcas.DataSource = marcas;
                RptMarcas.DataBind();
            }

        }

        protected void RptMarcas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Marca marca = (Marca)e.Item.DataItem;

                Label lblId = (Label)e.Item.FindControl("lblId");
                Label lblNome = (Label)e.Item.FindControl("lblNome");
                Label lblDataCadastro = (Label)e.Item.FindControl("lblDataCadastro");
                HyperLink lnkEditar = (HyperLink)e.Item.FindControl("lnkEditar");
                HyperLink lnkDeletar = (HyperLink)e.Item.FindControl("lnkDeletar");

                lblId.Text = Convert.ToString(marca.IdMarca);
                lblNome.Text = marca.Nome;
                lblDataCadastro.Text = Convert.ToString(marca.DataCadastro);

                lnkEditar.NavigateUrl = "~/MarcaEdicao.aspx?Id=" + marca.IdMarca;
                lnkDeletar.NavigateUrl = "~/VisualizarMarcas.aspx?Id=" + marca.IdMarca;

            }

        }
    }
}