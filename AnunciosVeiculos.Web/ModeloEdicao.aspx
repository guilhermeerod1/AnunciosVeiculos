<%@ Page Title="Edição de Modelos" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="ModeloEdicao.aspx.cs" Inherits="AnunciosVeiculos.Web.ModeloEdicao" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Form" ContentPlaceHolderID="cph1" runat="server">
    <form id="form1" runat="server">
    <div>
        <fieldset>
            Nome do Modelo:<br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br /><br />
            Marca do Modelo:<br />
            <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList><br /><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"/>
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"/><br />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </fieldset>
    </div>
    </form>
</asp:Content>