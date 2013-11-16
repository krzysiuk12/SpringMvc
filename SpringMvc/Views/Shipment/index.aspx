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
        <% foreach (var order in ViewBag.Orders) { %>
            <li class="order"><%=order %></li>
        <% } %>
                </ol>
                <div class="orderFiltering">
                </div>
        </div>
        <div class="orderDetails">
                <h2>Zamowienie 3 - detal</h2>
                <div class="clientDetails">
                        <h3>Dane do wysyłki:</h3>
                        <%=ViewBag.AddressDetails.FirstName %> <%=ViewBag.AddressDetails.LastName %></br>
                        ul. Partyzantów 24/56 </br>
                        30-150 Kraków</br>
                </div>
                <div class="productList">
                        <div class="productHeader">
                                <div class="productID cell">ID</div>
                                <div class="productName cell">Opis</div>
                                <div class="productsDesired cell">Ilosc</div>
                                <div class="productsInStock cell">W magazynie</div>                        
                        </div>
                        <div class="product">
                                <div class="productID cell">1</div>
                                <div class="productName cell">Description </div>
                                <div class="productsDesired cell">1</div>
                                <div class="productsInStock cell">2</div>
                        </div>
                        <div class="product">
                                <div class="productID cell">2</div>
                                <div class="productName cell">Author -Title</div>
                                <div class="productsDesired cell">1</div>
                                <div class="productsInStock cell">32 </div>
                        </div>
                        <div class="product">
                                <div class="productID cell">3</div>
                                <div class="productName cell">Author2 -Title2</div>
                                <div class="productsDesired cell"> 2</div>
                                <div class="productsInStock cell"> 1</div>
                        </div>
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

