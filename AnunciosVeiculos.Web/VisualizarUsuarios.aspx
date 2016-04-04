<%@ Page Title="Usuários" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="VisualizarUsuarios.aspx.cs" Inherits="AnunciosVeiculos.Web.VisualizarUsuarios" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Tabela" ContentPlaceHolderID="cph1" runat="server">
    <asp:Repeater ID="RptUsuarios" runat="server" OnItemDataBound="RptUsuarios_ItemDataBound">
        <HeaderTemplate>
            <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nome</th>
                            <th>Login</th>
                            <th>Email</th>
                            <th>Data de Cadastro</th>
                            <th colspan="2">Operações</th>
                        </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lblId" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblNome" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblLogin" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblDataCadastro" runat="server"></asp:Label></td>
                        <td>
                            <asp:HyperLink ID="lnkEditar" runat="server">Editar</asp:HyperLink>
                            <asp:HyperLink ID="lnkDeletar" runat="server">Remover</asp:HyperLink>
                        </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lblMensagem" runat="server"></asp:Label>
</asp:Content>