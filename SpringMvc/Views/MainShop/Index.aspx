<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.BookType>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="showbooks">
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
                <td>
                    <%: Html.ActionLink("Details", "BookDetails", new { booktypeId = item.Id }) %>
                </td>
            </tr>
        <% } %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <ul>
        <% foreach (SpringMvc.Menu.MenuComponents.MenuComponent secondaryPosition in ((SpringMvc.Menu.MenuComponents.MenuComposite)(((SpringMvc.Menu.MenuComponents.MenuComposite)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]))).ChildMenuPositionMap.Values) { %>
            <li class="button-list"><%: Html.ActionLink(secondaryPosition.Label, secondaryPosition.ControllerAction, secondaryPosition.ControllerName, routeValues: new { name = secondaryPosition.Label }, htmlAttributes: new { id = "guestLink" }) %></li>
        <% } %>
    </ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
