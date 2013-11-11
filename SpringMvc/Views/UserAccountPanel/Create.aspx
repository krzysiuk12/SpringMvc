<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.UserAccountModel>" %>

<asp:Content ID="createTitle" ContentPlaceHolderID="TitleContent" runat="server">
    User Account
</asp:Content>

<asp:Content ID="createFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="createMain" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
           <legend>UserAccountModel</legend>
           <section class="login dataPanels">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.FirstName) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.FirstName) %>
                    <%: Html.ValidationMessageFor(model => model.FirstName) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.MiddleName) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.MiddleName) %>
                    <%: Html.ValidationMessageFor(model => model.MiddleName) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.LastName) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.LastName) %>
                    <%: Html.ValidationMessageFor(model => model.LastName) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.DateOfBirth) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.DateOfBirth) %>
                    <%: Html.ValidationMessageFor(model => model.DateOfBirth) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.IdentityCardNumber) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.IdentityCardNumber) %>
                    <%: Html.ValidationMessageFor(model => model.IdentityCardNumber) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.PESEL) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.PESEL) %>
                    <%: Html.ValidationMessageFor(model => model.PESEL) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.PhoneNumber) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.PhoneNumber) %>
                    <%: Html.ValidationMessageFor(model => model.PhoneNumber) %>
                </div>
            </section>
            <section class="social dataPanels">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Street) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Street) %>
                    <%: Html.ValidationMessageFor(model => model.Street) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.City) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.City) %>
                    <%: Html.ValidationMessageFor(model => model.City) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.PostalCode) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.PostalCode) %>
                    <%: Html.ValidationMessageFor(model => model.PostalCode) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Country) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Country) %>
                    <%: Html.ValidationMessageFor(model => model.Country) %>
                </div>
            </section>
            <p>
                <input type="submit" value="Go to login site" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="createScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
