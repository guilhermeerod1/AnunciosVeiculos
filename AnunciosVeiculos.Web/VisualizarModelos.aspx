
<%@ Page Title="Modelos" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="VisualizarModelos.aspx.cs" Inherits="AnunciosVeiculos.Web.VisualizarModelos" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Tabela" ContentPlaceHolderID="cph1" runat="server">
    <asp:Repeater ID="RptModelos" runat="server" OnItemDataBound="RptModelos_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <th>ID</th>
                    <th>ID Marca</th>
                    <th>Nome da Marca</th>
                    <th>Nome do Modelo</th>
                    <th>Data de Cadastro</th>
                    <th colspan="2">Operações</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lblId" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblIdMarca" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblNomeMarca" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblNomeModelo" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblDataCadastro" runat="server"></asp:Label></td>
                        <td>
                            <asp:HyperLink ID="lnkEditar" runat="server">Editar</asp:HyperLink>
                            <asp:HyperLink ID="lnkExcluir" runat="server">Excluir</asp:HyperLink>
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