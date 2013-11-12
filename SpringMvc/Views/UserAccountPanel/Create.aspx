<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.UserAccountModel>" %>

<asp:Content ID="createTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>


<asp:Content ID="createFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="createMain" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Personal Data</h2>

    <p>
        Hello <%: @Html.DisplayFor(model => model.UserAccount.Login) %> your account has been successfully created.
        Please fulfil  the form to provide mandatory personal data.
    </p>
    
    <% using (Html.BeginForm()) { %>      
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>UserAccountModel</legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.FirstName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.MiddleName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.MiddleName) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.MiddleName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.LastName) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.LastName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.DateOfBirth) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.DateOfBirth) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.DateOfBirth) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.IdentityCardNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.IdentityCardNumber) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.IdentityCardNumber) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.PESEL) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.PESEL) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.PESEL) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.PhoneNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.PhoneNumber) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.PhoneNumber) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.Street) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.Street) %>
                <%: Html.ValidationMessageFor(model => model.Address.Street) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.City) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.City) %>
                <%: Html.ValidationMessageFor(model => model.Address.City) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.PostalCode) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.PostalCode) %>
                <%: Html.ValidationMessageFor(model => model.Address.PostalCode) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address.Country) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address.Country) %>
                <%: Html.ValidationMessageFor(model => model.Address.Country) %>
            </div>
            <p>
                <input type="submit" value="Go to login site" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="createScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
