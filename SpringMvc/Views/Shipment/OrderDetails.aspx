<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    OrderDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>OrderDetails</h2>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <ul>
        <% foreach (SpringMvc.Menu.MenuComponents.MenuComponent secondaryPosition in ((SpringMvc.Menu.MenuComponents.MenuComposite)(((SpringMvc.Menu.MenuComponents.MenuComposite)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]))).ChildMenuPositionMap.Values) { %>
            <li class="button-list"><%: Html.ActionLink(secondaryPosition.Label, secondaryPosition.ControllerAction, secondaryPosition.ControllerName, routeValues: new { name = secondaryPosition.Label }, htmlAttributes: new { id = "guestLink" }) %></li>
        <% } %>
    </ul>
</asp:Content>
