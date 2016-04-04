<%@ Page Title="Veículos" MasterPageFile="~/Template.Master" Language="C#" AutoEventWireup="true" CodeBehind="VisualizarVeiculos.aspx.cs" Inherits="AnunciosVeiculos.Web.VisualizarVeiculos" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Tabela" ContentPlaceHolderID="cph1" runat="server" >
    <asp:Repeater ID="RptVeiculos" runat="server" OnItemDataBound="RptVeiculos_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <th>ID</th>
                    <th>Usuário</th>
                    <th>Modelo</th>
                    <th>Valor</th>
                    <th>Ano de Fabricação</th>
                    <th>Ano do Modelo</th>
                    <th>Quilometragem</th>
                    <th>Data de Cadastro</th>
                    <th colspan="2">Operações</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lblId" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblUsuario" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblModelo" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblValor" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblAnoFabricacao" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblAnoModelo" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblQuilometragem" runat="server"></asp:Label></td>
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