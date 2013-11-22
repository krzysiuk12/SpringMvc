<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    YourCart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>YourCart
    <% if (Model.OrderEntries.Count > 0)
       { %>
        </h2>
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

        <% foreach (var item in Model.OrderEntries)
           { %>
            <tr>
                <td>
                    <%= item.Id %>
                </td>
                <td>
                    <%= item.BookType.Title %>,
                    <%= item.BookType.Authors %>
                </td>
                <td>
                    <%= item.Amount %>
                </td>
                <td>
                    <%= item.BookType.QuantityMap.Quantity %>
                </td>
            </tr>
        <% } %>
        </table>

        <%: Html.ActionLink("SubmitOrder", "SubmitOrder") %>
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