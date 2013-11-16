<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Bookstore
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="indexLeftMenu" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <h2>Categories</h2>

	
    <ul class="leftmenu">
        <li><%: Html.ActionLink("User Account", "Index", "Home") %>
			<ul>
				<li><a href="#">link1</a></li>
				<li><a href="#">link2</a></li>
				<li><a href="#">link3</a></li>
			</ul>
        </li>
        <li><%: Html.ActionLink("About", "About", "Home") %></li>
        <li><%: Html.ActionLink("Contact", "Contact", "Home") %></li>
    </ul>
</asp:Content>

<asp:Content ID="indexMain" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    I need a body, body, body is what i need...
    <br/>
    <% foreach (SpringMvc.Menu.MenuObject menuObject in ((SpringMvc.Menu.MenuObjectProvider)Session["MenuProvider"]).GetAllMenuObjects) { %>
        <% if(menuObject.PrimaryMenuPositions != null) {
            foreach (SpringMvc.Menu.MenuPositions.PrimaryMenuPosition position in menuObject.PrimaryMenuPositions) { %>
                <%: Html.ActionLink(position.Label, position.ControllerAction, position.ControllerName) %>
                <ul>
                    <% if(position.SecondaryMenuPositions != null) {
                        foreach(SpringMvc.Menu.MenuPositions.SecondaryMenuPosition secondaryMenuPosition  in position.SecondaryMenuPositions) { %>
                            <li><%: Html.ActionLink(secondaryMenuPosition.Label, secondaryMenuPosition.ControllerAction, secondaryMenuPosition.ControllerName) %></li>
                        <% } 
                    } %>
                </ul>
            <% } 
        } %> <!-- If MenuObject.PrimaryMenuPositions -->
        <br/>
        <br/>
    <% } %> <!-- Foreach MenuObject -->
</asp:Content>

<asp:Content ID="indexScripts" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
