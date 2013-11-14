<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<% if (Session["LoggedUserId"] != null) { %>
    <% if ((long)Session["LoggedUserId"] == (long)Application["AdministratorId"])
       { %>    
        Administrator Session Created.
<% } } else { %>
    <ul>
        <li><%: Html.ActionLink("Register", "Register", "Logging", routeValues: null, htmlAttributes: new { id = "registerLink" })%></li>
        <li><%: Html.ActionLink("Log in", "Index", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
    </ul>
<% } %>