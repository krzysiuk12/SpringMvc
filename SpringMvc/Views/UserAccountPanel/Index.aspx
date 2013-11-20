<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.UserAccount>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Account Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend><b>User Account Information</b></legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Login) %>:</b> <%: Html.DisplayFor(model => model.Login) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Email) %>:</b> <%: Html.DisplayFor(model => model.Email) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.LastPasswordChangedDate) %>:</b> <%: Html.DisplayFor(model => model.LastPasswordChangedDate.Date) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.LastSuccessfulSignInDate) %>:</b> <%: Html.DisplayFor(model => model.LastSuccessfulSignInDate.Date) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.ValidFrom) %>:</b> <%: Html.DisplayFor(model => model.ValidFrom.Date) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.ValidTo) %>:</b> <%: Html.DisplayFor(model => model.ValidTo) %>
        </div>
    </fieldset>
    <br />
    <fieldset>
        <legend><b>Personal Information</b></legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.FirstName) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.FirstName) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.LastName) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.LastName) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.DateOfBirth) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.DateOfBirth) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.PESEL) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.PESEL) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.PhoneNumber) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.PhoneNumber) %>
        </div>
    </fieldset>
    <br />
    <fieldset>
        <legend><b>Address Information</b></legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.Address.Street) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.Address.Street) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.Address.PostalCode) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.Address.PostalCode) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.Address.City) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.Address.City) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.PersonalData.Address.Country) %>:</b> <%: Html.DisplayFor(model => model.PersonalData.Address.Country) %>
        </div>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
