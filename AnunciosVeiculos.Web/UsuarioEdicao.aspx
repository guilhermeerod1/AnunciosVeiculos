<%@ Page Title="Edição de Usuários" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="UsuarioEdicao.aspx.cs" Inherits="AnunciosVeiculos.Web.UsuarioEdicao" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="cph1" runat="server">
    <form id="form1" runat="server">
        <fieldset>
            Nome:<br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br /><br />
            Login:<br />
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br /><br />
            Senha:<br />
            <asp:TextBox ID="txtSenha" TextMode="Password" runat="server"></asp:TextBox><br /><br />
            Email:<br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"/>
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"/>
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </fieldset>
    </form>
</asp:Content>