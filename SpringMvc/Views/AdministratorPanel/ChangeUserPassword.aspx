﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.ChangePasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ChangeUserPassword
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Change Password For User</legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NewPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.NewPassword) %>
                <%: Html.ValidationMessageFor(model => model.NewPassword) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CurrentPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.CurrentPassword) %>
                <%: Html.ValidationMessageFor(model => model.CurrentPassword) %>
            </div>
            <p>
                <input type="submit" value="Change Password" />
            </p>
        </fieldset>
    <% } %>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Back to List", "ViewAllUserAccounts") %>
    </div>
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
