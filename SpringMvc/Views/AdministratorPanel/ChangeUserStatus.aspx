<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.UserAccount>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ChangeUserStatus
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend><b>User Account</b></legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Login) %>:</b> <%: Html.DisplayFor(model => model.Login) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Email) %>:</b> <%: Html.DisplayFor(model => model.Email) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.LastSuccessfulSignInDate) %>:</b> <%: Html.DisplayFor(model => model.LastSuccessfulSignInDate) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.ValidFrom) %>:</b> <%: Html.DisplayFor(model => model.ValidFrom) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.ValidTo) %>:</b> <%: Html.DisplayFor(model => model.ValidTo) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.AccountStatus) %>:</b> <%: Html.DisplayFor(model => model.AccountStatus) %>
        </div>
    </fieldset>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Back to List", "ViewAllUserAccounts") %>
    </div>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Remove User", "ChangeUserStatusForStatusId", new { userId = Model.Id, statusId = (int)SpringMvc.Models.POCO.UserAccount.Status.REMOVED })%>
    </div>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Lock User", "ChangeUserStatusForStatusId", new { userId = Model.Id, statusId = (int)SpringMvc.Models.POCO.UserAccount.Status.LOCKED_OUT})%>
    </div>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Activate User", "ChangeUserStatusForStatusId", new { userId = Model.Id, statusId = (int)SpringMvc.Models.POCO.UserAccount.Status.ACTIVE})%>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
