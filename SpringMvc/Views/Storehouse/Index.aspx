<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.BookType>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Storehouse Summary</h2>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Id) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Title) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Authors) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Category.Name) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Price) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.QuantityMap.Quantity) %>
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Id) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Title) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Authors) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Category.Name) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Price) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.QuantityMap.Quantity) %>
            </td>
            <td>
    <%--            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>--%>
            </td>
        </tr>
    <% } %>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
