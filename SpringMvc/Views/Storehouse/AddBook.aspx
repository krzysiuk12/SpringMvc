<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddBook
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddBook</h2>

    <% Html.BeginForm("AddBookSave", "Storehouse", FormMethod.Post, new { enctype = "multipart/form-data" }); %>
    <div><div>Authors:</div><input type="text" value="" name="authors"/></div>
    <div><div>Title:</div><input type="text" value="" name="title"/></div>
    <div><div>Category:</div><input type="text" value="" name="category"/></div>
    <div><div>Price:</div><input type="number" value="" name="price"/></div>
    <div><div>Quantity:</div><input type="number" value="" name="quantity"/></div>
    <div><div>Image:</div><input type="file" value="" name="image"/></div>
    <input class="button" type="submit" value="Save"/>
    <% Html.EndForm(); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>