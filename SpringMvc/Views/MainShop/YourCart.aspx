<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    YourCart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Your Cart
    <% if (Model.OrderEntries.Count > 0)
       { %>
        </h2>
        <table style="width: 100%">
            <tr>
                <th>
                    Authors
                </th>
                <th>
                    Title
                </th>
                <th>
                    Amount
                </th>

                <th>
                    Price
                </th>
            </tr>
    <% decimal total = 0;%>
        <% foreach (var item in Model.OrderEntries)
           { %>
            <% total += item.Amount * item.Price; %>
            <tr>
                <td>
                    <%= item.BookType.Authors %>
                </td>
                <td>
                    <%= item.BookType.Title %>,
                </td>
                <td>
                    <%= item.Amount %>
                </td>
                <td>
                    <%= item.Price %> $
                </td>
            </tr>
        <% } %>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total:
                </td>
                <td>
                    <%= total %> $
                </td>
            </tr>
        </table>

        <div class="button"><%: Html.ActionLink("Submit Order", "SubmitOrder") %></div>
    <% }
       else
       { %>
        is empty.</h2>
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>