<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="registerMain" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Register</h1>
    </hgroup>
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>RegisterModel</legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Login) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Login) %>
                <%: Html.ValidationMessageFor(model => model.Login) %>
                <%: Html.ValidationMessage("Login Unique Error") %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            <p>
                <input type="submit" value="Register"/>
            </p>
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="registerScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
