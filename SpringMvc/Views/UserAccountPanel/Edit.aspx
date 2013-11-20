<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.UserAccount>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Personal and Address Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend><b>Personal and Address Information</b></legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.FirstName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.LastName) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.LastName) %>
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
                <%: Html.LabelFor(model => model.PersonalData.Address.Street) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.Address.Street) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.Address.Street) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.Address.PostalCode) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.Address.PostalCode) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.Address.PostalCode) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.Address.City) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.Address.City) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.Address.City) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonalData.Address.Country) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonalData.Address.Country) %>
                <%: Html.ValidationMessageFor(model => model.PersonalData.Address.Country) %>
            </div>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>