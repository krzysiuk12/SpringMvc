<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.BookType>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    BookDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .showbooks th {
            width: 100px;
        }
    </style>

    <div style="float: left; margin-left: 15px; margin-right: 30px;">
        <img src="<%: Html.DisplayFor(model => model.Image.URL) %>" height="200px" width="130px"/>
    </div>
    <table class="showbooks" >
        <tr>
            <th><%: Html.DisplayNameFor(model => model.Title) %> </th> 
            <td> <%: Html.DisplayFor(model => model.Title) %> </td>         
        </tr>
        <tr>
            <th><%: Html.DisplayNameFor(model => model.Category) %> </th> 
            <td> <%: Html.DisplayFor(model => model.Category.Name) %> </td>         
        </tr>
        <tr>
            <th><%: Html.DisplayNameFor(model => model.Authors) %> </th> 
            <td> <%: Html.DisplayFor(model => model.Authors) %> </td>         
        </tr>
        <tr>
            <th><%: Html.DisplayNameFor(model => model.Price) %> </th> 
            <td> <%: Html.DisplayFor(model => model.Price) %> </td>         
        </tr>
        <tr>
            <th><%: Html.DisplayNameFor(model => model.QuantityMap.Quantity) %> </th> 
            <td> <%: Html.DisplayFor(model => model.QuantityMap.Quantity) %> </td>         
        </tr>                      
    </table>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Back to Shopping", "Index") %>
    </div>
    <div class="button" style="float: right; margin-top: 15px;">
        <%: Html.ActionLink("Add to Card", "Index") %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%: Html.Partial("_MainMenuPartial") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
