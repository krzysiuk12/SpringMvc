<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.Order>>" %>
<%@ Import Namespace="SpringMvc.Models.POCO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table { width: 100%; }
    </style>
    <h2>Unrealised Orders</h2>
    <table>
        <tr>
            <th>
                Id
            </th>
            <th>
                Client
            </th>

            <th>
                Order Date
            </th>
            <th>
                Sent Date
            </th>
            <th>
                Status
            </th>
        </tr>

        <% foreach (Order item in Model)
           { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Id) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.User.PersonalData.FirstName) %>
                    <%: Html.DisplayFor(modelItem => item.User.PersonalData.LastName) %>
                </td>

                <td>
                    <%: Html.DisplayFor(modelItem => item.OrderDate) %>
                </td>
                <td>
                    <% if (item.Status == Order.OrderState.SENT)
                       { %>
                        <%: Html.DisplayFor(modelItem => item.SentDate) %>
                    <% } %>

                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Status) %>
                </td>
                <td>
                    <%: Html.ActionLink("Details", "OrderDetailsSite", new {orderId = item.Id}) %>
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