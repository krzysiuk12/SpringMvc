<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.BookType>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th></th>
            <th><%: Html.DisplayNameFor(model => model.Title) %></th>
            <th><%: Html.DisplayNameFor(model => model.Authors) %></th>
            <th><%: Html.DisplayNameFor(model => model.Price) %></th>
        </tr>
        <% foreach (var item in Model) { %>
            <tr>
                <td>
                    <img src="<%: Html.DisplayFor(modelItem => item.Image.URL) %>" height="40px" width="26px"/>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Title) %>
                </td>
                <td><%: Html.DisplayFor(modelItem => item.Authors) %></td>
                <td><%: Html.DisplayFor(modelItem => item.Price) %></td>
        <%--        <td>
                    <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
                    <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
                </td>--%>
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
