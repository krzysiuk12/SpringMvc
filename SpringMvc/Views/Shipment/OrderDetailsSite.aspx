<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainShop.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    OrderDetailsSite
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>OrderDetailsSite</h2>

    <fieldset>
        <legend>User Personal Data</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.User.PersonalData.FirstName) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.FirstName) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.User.PersonalData.LastName) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.LastName) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.User.PersonalData.Address.Street) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.User.PersonalData.Address.Street) %>
        </div>
    </fieldset>

    <fieldset>
        <legend>Order</legend>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Id) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Id) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.OrderDate) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.OrderDate) %>
        </div>

        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.DeliveryDate) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.DeliveryDate) %>
        </div>
    </fieldset>
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
