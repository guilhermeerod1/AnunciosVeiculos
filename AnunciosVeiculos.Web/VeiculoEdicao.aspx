<%@ Page Title="Edição de Veículos" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="VeiculoEdicao.aspx.cs" Inherits="AnunciosVeiculos.Web.VeiculoEdicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <form id="form1" runat="server">
    <div>
        <fieldset>
                Usuário:<br />
                <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList><br /><br />
                Modelo:<br />
                <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList><br /><br />
                Valor:<br />
                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox><br /><br />
                Ano de Fabricação:<br />
                <asp:TextBox ID="txtAnoFabricacao" runat="server"></asp:TextBox><br /><br />
                Ano do Modelo:<br />
                <asp:TextBox ID="txtAnoModelo" runat="server"></asp:TextBox><br /><br />
                Quilometragem:<br />
                <asp:TextBox ID="txtQuilometragem" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" /><br />
                <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
        </fieldset>
    </div>
    </form>
</asp:Content>
