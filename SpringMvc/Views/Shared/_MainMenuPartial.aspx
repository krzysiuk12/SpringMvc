<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
        <div class="float-left">
            <%: ((SpringMvc.Menu.MenuComponents.MenuComponent)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]).Label  %>
            <% if (Session["SecondaryMenuPosition"] != null) { %>
                 -> <%: ((SpringMvc.Menu.MenuComponents.MenuComponent)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]).GetMappedChildMenuPosition((int)Session["SecondaryMenuPosition"]).Label %>  
            <% } %>
        </div>
        <div class="float-right">
            <nav>
                <ul id="menu">
                    <% foreach (SpringMvc.Menu.MenuComponents.MenuComponent primaryPosition in ((SpringMvc.Menu.MenuComponents.MenuComposite)Session["MenuObject"]).ChildMenuPositionMap.Values) { %>
                        <li><%: Html.ActionLink(primaryPosition.Label, primaryPosition.ControllerAction, primaryPosition.ControllerName) %></li>
                    <% } %>
                </ul>
            </nav>
        </div>
    </div>
</section>
