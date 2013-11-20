<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.OrderEntry>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    UserOrdersView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
    <table class="showbooks">
        <tr>
            <th></th>
            <th><%: Html.DisplayNameFor(model => model.BookType.Title) %></th>
            <th><%: Html.DisplayNameFor(model => model.BookType.Authors) %></th>
            <th><%: Html.DisplayNameFor(model => model.BookType.Price) %></th>
            <th><%: Html.DisplayNameFor(model => model.Amount) %></th>
             <th><%: Html.DisplayNameFor(model => model.Price) %></th>
        </tr>
        <% foreach (var item in Model) { %>
            <tr>
                <td>
                    <img src="<%: Html.DisplayFor(modelItem => item.BookType.Image.URL) %>" height="40px" width="26px"/>
                </td>
                <td><%: Html.DisplayFor(modelItem => item.BookType.Title) %> </td>
                <td><%: Html.DisplayFor(modelItem => item.BookType.Authors) %></td>
                <td><%: Html.DisplayFor(modelItem => item.BookType.Price) %></td>
                <td><%: Html.DisplayFor(modelItem => item.Amount) %></td>
                 <td><%: Html.DisplayFor(modelItem => item.Price) %></td>            
                <td> <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %></td>
        <%--        <td>
                    <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                    
                    <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
                </td>--%>
            </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Back to Shopping", "Index") %>
    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
