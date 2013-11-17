<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
        <div class="float-left">
            <% if (((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions != null) { %>
                 <%: ((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((SpringMvc.Menu.MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].Label %>  
            <% } %>
            <% if (((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((SpringMvc.Menu.MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].SecondaryMenuPositions != null) { %>
                 -> <%: ((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((SpringMvc.Menu.MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].SecondaryMenuPositions[((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((SpringMvc.Menu.MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].CurrentSecondaryPosition].Label %>  
            <% } %>
        </div>
        <div class="float-right">
            <nav>
                <ul id="menu">
                    <% foreach (SpringMvc.Menu.MenuPositions.PrimaryMenuPosition position in ((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions) { %>
                        <li><%: Html.ActionLink(position.Label, position.ControllerAction, position.ControllerName) %></li>
                    <% } %>
                </ul>
            </nav>
        </div>
    </div>
</section>
