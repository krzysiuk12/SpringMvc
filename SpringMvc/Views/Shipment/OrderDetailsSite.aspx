<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.Order>" %>
<%@ Import Namespace="SpringMvc.Models.POCO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    OrderDetailsSite
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #leftmenu { display: none; }

        #shopview { width: 100%; }

        table { width: 100%; }
    </style>
    <h2>Order Details  (id: <%: Html.DisplayFor(model => model.Id) %>)</h2>

    <fieldset>
        <legend>Client Address Details</legend>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.FirstName) %> 
            <%: Html.DisplayFor(model => model.User.PersonalData.LastName) %>
        </div>

        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.Address.Street) %> 23
        </div>

        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.Address.PostalCode) %>, 
            <%: Html.DisplayFor(model => model.User.PersonalData.Address.City) %>
        </div>
    </fieldset>

    <fieldset>
        <table>
            <tr>
                <th>
                    Product Id
                </th>
                <th>
                    Description
                </th>
                <th>
                    Amount
                </th>

                <th>
                    In Stock
                </th>
            </tr>

            <% foreach (OrderEntry item in Model.OrderEntries)
               { %>
                <tr>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Id) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.BookType.Title) %>,
                        <%: Html.DisplayFor(modelItem => item.BookType.Authors) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Amount) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.BookType.QuantityMap.Quantity) %>
                    </td>
                </tr>
            <% } %>
        </table>
    </fieldset>
    <p>

        <div class="button">
            <% if (Model.Status == Order.OrderState.SENT)
               { %>
                <%: Html.ActionLink("Complete Order (If order has been delivered)", "CompleteOrder", new {orderId = Model.Id}) %>
            <% }
               else if (Model.Status == Order.OrderState.ORDERED)
               { %>
                <%: Html.ActionLink("Mark order as sent", "SendOrder", new {orderId = Model.Id}) %>
            <% } %>
        </div>

    </p>        

    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>