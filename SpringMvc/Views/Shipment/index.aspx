<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style>
    #leftmenu {
        display: none;
    }
    #shopview {
        width: 100%;
    }
    table {
        width: 100%;
    }
</style>
<h2>Unrealised Orders</h2>
<table>
    <tr>
        <th>
<%--            <%: Html.DisplayNameFor(model => model.Id) %>--%>
            Id
        </th>
        <th>
<%--            <%: Html.DisplayNameFor(model => model.User) %>--%>
            Client
        </th>
<%--        <th>--%>
<%--            <%: Html.DisplayNameFor(model => model.SentDate) %>--%>
<%--        </th>--%>
        <th>
<%--            <%: Html.DisplayNameFor(model => model.OrderDate) %>--%>
            Order Date
        </th>
        <th>
<%--            <%: Html.DisplayNameFor(model => model.DeliveryDate) %>--%>
            Status
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Id) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.User.PersonalData.FirstName) %>
            <%: Html.DisplayFor(modelItem => item.User.PersonalData.LastName) %>
        </td>

<%--        <td>--%>
<%--            <%: Html.DisplayFor(modelItem => item.SentDate) %>--%>
<%--        </td>--%>

        <td>
            <%: Html.DisplayFor(modelItem => item.OrderDate) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Status) %>
        </td>
        <td>
            <%: Html.ActionLink("Details", "OrderDetailsSite", new { orderId=item.Id }) %>
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

