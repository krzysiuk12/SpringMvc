<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Bookstore
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="indexLeftMenu" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <h2>Categories</h2>
	<ul>
		<li>cat1</li>	
		<li>cat2</li>
	</ul>
</asp:Content>

<asp:Content ID="indexMain" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    I need a body, body, body is what i need...
<%--	//do zmiany
	<table id="booktable">
		<tr id="book-title">
			<td>title 1</td>
			<td>title 2</td>
		</tr>
		<tr id="book-authors">
			<td>authors</td>
			<td>authors</td>
		</tr>
		<tr>
			<td>price</td>
			<td>price</td>
		</tr>
	</table>--%>

</asp:Content>

<asp:Content ID="indexScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
