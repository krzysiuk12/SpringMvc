﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Bookstore
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="indexMain" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    I need a body, body, body is what i need...
</asp:Content>

<asp:Content ID="indexScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
