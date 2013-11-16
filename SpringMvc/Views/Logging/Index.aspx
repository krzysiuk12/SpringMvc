<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.LogInModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="indexFetured" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="indexMain" ContentPlaceHolderID="MainContent" runat="server">
    <section id="loginForm">
        <h2>Log in</h2>
        <% using (Html.BeginForm()) { %>
            <%: Html.AntiForgeryToken() %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <legend>LogInModel</legend>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.UserName) %>
                    <%: Html.ValidationMessageFor(model => model.UserName) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Password) %>
                    <%: Html.ValidationMessageFor(model => model.Password) %>
                </div>
                <p>
                    <input type="submit" value="Log In" />
                </p>
            </fieldset>

        <% } %>
        If you don't have an account: 
        <%: Html.ActionLink("register", "Register", "Logging", routeValues: null, htmlAttributes: new { id = "registerLink" })%>
    </section>
    <section class="section" id="social">
        <h2>Try without account</h2>
            <%: Html.ActionLink("Log As Guest", "GuestLogin", "Logging", routeValues: null, htmlAttributes: new { id = "guestLink" })%>
    </section>
</asp:Content>

<asp:Content ID="indexScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
