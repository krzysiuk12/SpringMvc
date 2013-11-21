<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Order Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Order</legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Id) %>:</b> <%: Html.DisplayFor(model => model.Id) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.SentDate) %>:</b> <%: Html.DisplayFor(model => model.SentDate) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.OrderDate) %>:</b> <%: Html.DisplayFor(model => model.OrderDate) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.DeliveryDate) %>:</b> <%: Html.DisplayFor(model => model.DeliveryDate) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.Status) %>:</b> <%: Html.DisplayFor(model => model.Status) %>
        </div>
    </fieldset>
    <br />
    <fieldset>
        <legend>Delivery Address</legend>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.FirstName) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.FirstName) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.LastName) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.LastName) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.Address.Street) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.Address.Street) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.Address.PostalCode) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.Address.PostalCode) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.Address.City) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.Address.City) %>
        </div>
        <div class="display-label">
            <b><%: Html.DisplayNameFor(model => model.User.PersonalData.Address.Country) %>:</b> <%: Html.DisplayFor(model => model.User.PersonalData.Address.Country) %>
        </div>
    </fieldset>
    <br />
    <fieldset>
        <legend>Order Entries</legend>
        <table style="width: 100%;">
            <tr>
                <th></th>
                <th>Title</th>
                <th>Authors</th>
                <th>Amount</th>
                <th>Price</th>
            </tr>   
            <% foreach (var item in Model.OrderEntries) { %>
                <tr>
                    <td><img src="<%: Html.DisplayFor(modelItem => item.BookType.Image.URL) %>" height="40px" width="26px"/></td>
                    <td><%: Html.DisplayFor(modelItem => item.BookType.Title) %></td>
                    <td><%: Html.DisplayFor(modelItem => item.BookType.Authors) %></td>
                    <td><%: Html.DisplayFor(modelItem => item.Amount) %></td>
                    <td><%: Html.DisplayFor(modelItem => item.Price) %></td>
                    <td></td>
                </tr>
            <% } %>
        </table>
    </fieldset>
    <div class="button" style="margin-top: 15px;">
        <%: Html.ActionLink("Back to List", "DeliveredOrders") %>
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