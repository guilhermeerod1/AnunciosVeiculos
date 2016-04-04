<%@ Page Title="Edição de Marcas" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="MarcaEdicao.aspx.cs" Inherits="AnunciosVeiculos.Web.MarcaEdicao" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Form" ContentPlaceHolderID="cph1" runat="server">
    <form id="form1" runat="server">
    <div>
        <fieldset>
            Nome da Marca:<br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"/>
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"/><br />
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
        </fieldset>
    </div>
    </form>
</asp:Content>