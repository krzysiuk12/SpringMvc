<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.UserAccountsPages.UserAccountModel>" %>

<asp:Content ID="editTitle" ContentPlaceHolderID="TitleContent" runat="server">
    User Account
</asp:Content>

<asp:Content ID="editFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
        <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="editMain" ContentPlaceHolderID="MainContent" runat="server">
    User account
</asp:Content>

<asp:Content ID="editScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
