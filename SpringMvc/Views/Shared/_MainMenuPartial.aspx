<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
        <div class="float-right">
            <nav>
                <ul id="menu">
                    <% foreach (SpringMvc.Menu.MenuPositions.PrimaryMenuPosition position in ((SpringMvc.Menu.MenuObject)Session["MenuObject"]).PrimaryMenuPositions) { %>
                                <%: Html.ActionLink(position.Label, position.ControllerAction, position.ControllerName) %>
                    <% } %>
                </ul>
            </nav>
        </div>
    </div>
</section>
