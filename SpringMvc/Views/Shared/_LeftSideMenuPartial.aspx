<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<ul>
    <% foreach (SpringMvc.Menu.MenuComponents.MenuComponent secondaryPosition in ((SpringMvc.Menu.MenuComponents.MenuComposite)(((SpringMvc.Menu.MenuComponents.MenuComposite)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]))).ChildMenuPositionMap.Values) { %>
        <li class="button-list"><%: Html.ActionLink(secondaryPosition.Label, secondaryPosition.ControllerAction, secondaryPosition.ControllerName) %></li>
    <% } %>
</ul>