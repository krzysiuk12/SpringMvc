<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% if (Session["LoggedUserId"] == null) { %> <!-- Before login action header (Application Start + After Logout) -->
    <ul>
        <li><%: Html.ActionLink("Register", "Register", "Logging", routeValues: null, htmlAttributes: new { id = "registerLink" })%></li>
        <li><%: Html.ActionLink("Log in", "Index", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
    </ul>
<% } else if ((long)Session["LoggedUserId"] == (long)Application["GuestId"]) { %>
     You are currently logged in as a Guest.
     <li><%: Html.ActionLink("Logout", "Logout", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
<% } else if ((long)Session["LoggedUserId"] == (long)Application["AdministratorId"]) { %>
    You are currently logged in as Administrator.
    <li><%: Html.ActionLink("Logout", "Logout", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
<% } else if ((long)Session["LoggedUserId"] == (long)Application["WorkerId"]) { %>
    You are currently logged in as Worker.
    <li><%: Html.ActionLink("Logout", "Logout", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
<% } else { %> <!-- Simple User Account-->
    Your are logged as <%: ((SpringMvc.Models.POCO.UserAccount)Session["CurrentUser"]).PersonalData.FirstName %> <%: ((SpringMvc.Models.POCO.UserAccount)Session["CurrentUser"]).PersonalData.LastName %>.
    <a href="/MainShop">Your card: <%: ((SpringMvc.Models.POCO.Order)Session["CurrentOrder"]).OrderEntries.Count %></a>
    <li><%: Html.ActionLink("Logout", "Logout", "Logging", routeValues: null, htmlAttributes: new { id = "loginLink" })%></li>
<% } %>