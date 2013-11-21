<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Undelivered Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Undelivered Orders</h2>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Id) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.OrderDate) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.SentDate) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.DeliveryDate) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Status) %>
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model) { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Id) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.OrderDate) %>
                </td>
                <td>
                    <% if(item.SentDate.Equals(DateTime.MinValue)) { %>
                       NOT SENT
                    <% } else { %>
                        <%: Html.DisplayFor(modelItem => item.SentDate) %>
                    <% } %>
                </td>
                <td>
                    <% if(item.DeliveryDate.Equals(DateTime.MinValue)) { %>
                       NOT DELIVERED
                    <% } else { %>
                        <%: Html.DisplayFor(modelItem => item.DeliveryDate) %>
                    <% } %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Status) %>
                </td>
                <td>
                    <%: Html.ActionLink("Details", "UndeliveredOrderDetails", new { orderId = item.Id }) %>
                </td>
            </tr>
        <% } %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuContent" runat="server">
    <%: Html.Partial("_LeftSideMenuPartial") %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
