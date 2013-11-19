<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <style type="text/css">
.wysylka {
        display: table;
        width: 1000px;
        height: 600px;
        margin-right: auto;
        margin-left: auto;
        border-style: solid;

}

.orderDetails {
        display: table-cell;
        width: 75%;
        float: left;
        margin: 0;

}
.orders {
        display: table-cell;
        background-color: #E8E8E8;
        width: 25%;
        float: left;
        margin: 0;
        height: 600px;
}

.active {
        background-color: #E8E8B8;
}

h2{
        padding-left: 3%;
}
.clientDetails {

        background-color: #E8E8E8;
        width: 80%;
        margin-right: auto;
        margin-left: auto;
}

.productList {
        background-color: #E8E8E8;
        width: 80%;
        margin-top: 2%;
        margin-right: auto;
        margin-left: auto;
        display: table;
}

.product {
        display: table-row;
        margin-bottom: 20px;
}

.productID {
        width: 5%;

}
.productName {
        width: 60%;
}
.cell {
        display: table-cell;        
}

.productHeader {
        display: table-row;
        background-color: silver;
}

.confirmation {
        width: 80%;
        margin-right: auto;
        margin-left: auto;        
}
</style>
    

<div class="wysylka">
        <div class="orders"> 
                <h2>Niezrealizowane Zamówienia:</h2>
        <ol class="orderList">
            <% foreach (SpringMvc.Models.POCO.Order order in ViewBag.Orders)
                    { %>
                        <div class="order">
                            <%=order.OrderDate%>,   <%=order.Id%> 
                        </div>
                    <% }; %>
        </ol>
        <div class="orderFiltering"></div>
        </div>
        <div class="orderDetails">
                <h2>Details:  <%=ViewBag.Order.OrderDate%>,   <%=ViewBag.Order.Status%></h2>
                <div class="clientDetails">
                        <h3>Dane do wysyłki:</h3>
                        <%=ViewBag.Client.FirstName %> <%=ViewBag.Client.LastName %></br>
                        <%=ViewBag.Client.Address.Street %> </br>
                        <%=ViewBag.Client.Address.PostalCode %> <%=ViewBag.Client.Address.City %>, <%=ViewBag.Client.Address.Country %></br>
                </div>
                <div class="productList">

                        <div class="productHeader">
                                <div class="productID cell">ID</div>
                                <div class="productName cell">Opis</div>
                                <div class="productsDesired cell">Ilosc</div>
                                <div class="productsInStock cell">W magazynie</div>                        
                        </div>
                    <% foreach (SpringMvc.Models.POCO.OrderEntry entry in ViewBag.OrderEntries)
                    { %>
                        <div class="product">
                                <div class="productID cell"><%=entry.Id %></div>
                                <div class="productName cell"><%=entry.BookType.Authors %> - <%=entry.BookType.Title %></div>
                                <div class="productsDesired cell"><%=entry.Amount %></div>
                                <div class="productsInStock cell"><%=entry.BookType.QuantityMap.Quantity %></div>
                        </div>
                    <% }; %>
                </div>                        
                <div class="confirmation">
                        <h3>Status zamówienia:</h3>
                        <form>
                                <input type="radio" name="status" value="inProgress" checked> W trakcie realizacji </br>
                                <input type="radio" name="status" value="completed"> Przygotowane do wysylki </br>
                                <input type="radio" name="status" value="completed"> Wyslane </br>
                                <input type="radio" name="status" value="delayed"> Anulowane </br>
                                <input type="submit" value="Zmien status zamowienia">
                        </form> 
                </div>
        </div>
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <ul>
        <% foreach (SpringMvc.Menu.MenuComponents.MenuComponent secondaryPosition in ((SpringMvc.Menu.MenuComponents.MenuComposite)(((SpringMvc.Menu.MenuComponents.MenuComposite)Session["MenuObject"]).GetMappedChildMenuPosition((int)Session["PrimaryMenuPosition"]))).ChildMenuPositionMap.Values) { %>
            <li class="button-list"><%: Html.ActionLink(secondaryPosition.Label, secondaryPosition.ControllerAction, secondaryPosition.ControllerName, routeValues: new { name = secondaryPosition.Label }, htmlAttributes: new { id = "guestLink" }) %></li>
        <% } %>
    </ul>
</asp:Content>


