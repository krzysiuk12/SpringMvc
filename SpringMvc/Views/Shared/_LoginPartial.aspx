<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% if (Session["LoggedUserId"] == null) { %>
    <ul>
        <li><%: Html.ActionLink("Register", "Register", "Logging", routeValues: null, htmlAttributes: new { id = "registerLink" })%></li>
        <li><%: Html.ActionLink("Log in", "Index", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
    </ul>
<% } else if ((long)Session["LoggedUserId"] == (long)Application["GuestId"]) { %>
    Hello Guest
<% } else if ((long)Session["LoggedUserId"] == (long)Application["AdministratorId"]) { %>
    Hello Administrator
<% } else if ((long)Session["LoggedUserId"] == (long)Application["WorkerId"]) { %>
    Hello worker
<% } else { %>
    <ul>
        <li><%: Html.ActionLink("Register", "Register", "Logging", routeValues: null, htmlAttributes: new { id = "registerLink" })%></li>
        <li><%: Html.ActionLink("Log in", "Index", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
    </ul>
<% } %>