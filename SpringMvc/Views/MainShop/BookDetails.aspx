<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringMvc.Models.POCO.BookType>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    BookDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="showbooks">
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
    </table>
    <p>
        <%: Html.ActionLink("Back to Shopping", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
