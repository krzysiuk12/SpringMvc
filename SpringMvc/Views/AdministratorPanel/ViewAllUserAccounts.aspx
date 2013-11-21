<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringMvc.Models.POCO.UserAccount>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ViewAllUserAccounts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .usersTable td {
            border-bottom: 1px solid gray;
        }
    </style>
    <h2>ViewAllUserAccounts</h2>
    <table class="usersTable">
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Login) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Email) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.ValidFrom) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.ValidTo) %>
            </th>
            <th style="width: 150px;"></th>
        </tr>

        <% foreach (var item in Model) { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Login) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Email) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.ValidFrom) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.ValidTo) %>
                </td>
                <td>
                    <%: Html.ActionLink("User Informations", "ViewUserInformation", new { userId=item.Id }) %><br />
                    <%: Html.ActionLink("Change Password", "ChangeUserPassword", new { userId=item.Id }) %><br />
                    <%: Html.ActionLink("Change Status", "ChangeUserStatus", new { userId=item.Id }) %>
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
