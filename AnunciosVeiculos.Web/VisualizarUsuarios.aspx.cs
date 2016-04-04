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
    public partial class VisualizarUsuarios : System.Web.UI.Page
    {

        private UsuarioBO usuarioBo = new UsuarioBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string id = Page.Request.QueryString["Id"];

                if (!string.IsNullOrEmpty(id))
                {
                    usuarioBo.RemoverUsuario(Convert.ToInt32(id));
                }

            }

            List<Usuario> usuarios = usuarioBo.RetornarUsuarios();

            if(usuarios == null)
            {
                lblMensagem.Text = "Nenhum registro.";
            }
            else
            {
                RptUsuarios.DataSource = usuarios;
                RptUsuarios.DataBind();
            }

        }

        protected void RptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Usuario usuario = (Usuario)e.Item.DataItem;

                Label lblId = (Label)e.Item.FindControl("lblId");
                Label lblNome = (Label)e.Item.FindControl("lblNome");
                Label lblLogin = (Label)e.Item.FindControl("lblLogin");
                Label lblEmail = (Label)e.Item.FindControl("lblEmail");
                Label lblDataCadastro = (Label)e.Item.FindControl("lblDataCadastro");
                HyperLink lnkEditar = (HyperLink)e.Item.FindControl("lnkEditar");
                HyperLink lnkDeletar = (HyperLink)e.Item.FindControl("lnkDeletar");

                lblId.Text = Convert.ToString(usuario.IdUsuario);
                lblNome.Text = usuario.Nome;
                lblLogin.Text = usuario.Login;
                lblEmail.Text = usuario.Email;
                lblDataCadastro.Text = Convert.ToString(usuario.DataCadastro);

                lnkEditar.NavigateUrl = "~/UsuarioEdicao.aspx?Id=" + usuario.IdUsuario;
                lnkDeletar.NavigateUrl = "~/VisualizarUsuarios.aspx?Id=" + usuario.IdUsuario;

            }

        }

    }

}